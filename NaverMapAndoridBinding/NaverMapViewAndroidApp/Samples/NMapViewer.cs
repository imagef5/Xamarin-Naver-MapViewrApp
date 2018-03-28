
using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Provider;
using Android.Widget;
using Com.Nhn.Android.Maps;
using Com.Nhn.Android.Maps.Maplib;
using Com.Nhn.Android.Maps.Overlay;
using Com.Nhn.Android.Mapviewer.Overlay;
using static Com.Nhn.Android.Mapviewer.Overlay.NMapPOIdataOverlay;
using Android.Util;
using Android.Graphics;

namespace NaverMapViewAndroidApp.Samples
{
    [Activity(Label = "Naver Map Viewer", Name = "naver.map.NMapViewer")]
    public class NMapViewer : NMapActivity, NMapOverlayManager.IOnCalloutOverlayListener, NMapView.IOnMapViewDelegate
    {
        #region private member fields area
        const string LOG_TAG = "NMapViewer";
        const bool DEBUG = true;

        // set your Client ID which is registered for NMapViewer library.
        const string CLIENT_ID = AppSetting.CLIENT_ID;

        MapContainerView mMapContainerView;

        NMapView mMapView;
        NMapController mMapController;

        readonly NGeoPoint NMAP_LOCATION_DEFAULT = new NGeoPoint(126.978371, 37.5666091);
        const int NMAP_ZOOMLEVEL_DEFAULT = 11;
        const int NMAP_VIEW_MODE_DEFAULT = NMapView.ViewModeVector;
        const bool NMAP_TRAFFIC_MODE_DEFAULT = false;
        const bool NMAP_BICYCLE_MODE_DEFAULT = false;

        const string KEY_ZOOM_LEVEL = "NMapViewer.zoomLevel";
        const string KEY_CENTER_LONGITUDE = "NMapViewer.centerLongitudeE6";
        const string KEY_CENTER_LATITUDE = "NMapViewer.centerLatitudeE6";
        const string KEY_VIEW_MODE = "NMapViewer.viewMode";
        const string KEY_TRAFFIC_MODE = "NMapViewer.trafficMode";
        const string KEY_BICYCLE_MODE = "NMapViewer.bicycleMode";

        ISharedPreferences mPreferences;

        NMapOverlayManager mOverlayManager;

        NMapMyLocationOverlay mMyLocationOverlay;
        NMapLocationManager mMapLocationManager;
        NMapCompassManager mMapCompassManager;

        NMapViewerResourceProvider mMapViewerResourceProvider;

        NMapPOIdataOverlay mFloatingPOIdataOverlay;
        NMapPOIitem mFloatingPOIitem;

        static bool USE_XML_LAYOUT = false;

        static bool mIsMapEnlared = false;

        const long AUTO_ROTATE_INTERVAL = 2000;
        readonly Handler mHnadler = new Handler();
        #endregion

        #region override methods area
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            if (USE_XML_LAYOUT)
            {
                SetContentView(Resource.Layout.Main);

                mMapView = FindViewById<NMapView>(Resource.Id.mapView);
            }
            else
            {
                // create map view
                mMapView = new NMapView(this);

                // create parent view to rotate map view
                mMapContainerView = new MapContainerView(this, this);
                mMapContainerView.AddView(mMapView);

                // set the activity content to the parent view
                SetContentView(mMapContainerView);
            }

            // set a registered Client Id for Open MapViewer Library
            mMapView.SetClientId(CLIENT_ID);

            // initialize map view
            mMapView.Clickable = true;
            mMapView.Enabled = true;
            mMapView.Focusable = true;
            mMapView.FocusableInTouchMode = true;
            mMapView.RequestFocus();

            // register listener for map state changes
            //mMapView.SetOnMapStateChangeListener(onMapViewStateChangeListener);
            mMapView.MapInitHandler += OnMapInit;
            mMapView.AnimationStateChange += OnAnimationStateChange;
            mMapView.MapCenterChange += OnMapCenterChange;
            mMapView.ZoomLevelChange += OnZoomLevelChage;
            //mMapView.MapCenterChangeFine += OnMapCenterChangeFine;

            //mMapView.SetOnMapViewTouchEventListener(onMapViewTouchEventListener);
            //이벤트 방식으로 구현시 약한 결합을 지원하므로 좀더 유연하게 핸드러를 구현할 수 있음(필요시에만 구현)
            //mMapView.LongPress += OnLongPress;
            //mMapView.LongPressCanceled += OnLongPressCanceled;
            //mMapView.SingleTapUp += OnSingleTapUp;
            //mMapView.TouchDown += OnTouchDown;
            //mMapView.TouchUp += OnTouchUp;
            //mMapView.Scroll += OnScroll;

            mMapView.SetOnMapViewDelegate(this);

            // use map controller to zoom in/out, pan and set map center, zoom level etc.
            mMapController = mMapView.MapController;

            // use built in zoom controls
            var lp = new NMapView.LayoutParams(ViewGroup.LayoutParams.WrapContent,
                                               ViewGroup.LayoutParams.WrapContent, 
                                               NMapView.LayoutParams.BottomRight);
            mMapView.SetBuiltInZoomControls(true, lp);

            // create resource provider
            mMapViewerResourceProvider = new NMapViewerResourceProvider(this);

            // set data provider listener
            //base.SetMapDataProviderListener(onDataProviderListener);
            base.MapDataProvider += OnReverseGeocoderResponse;

            // create overlay manager
            mOverlayManager = new NMapOverlayManager(this, mMapView, mMapViewerResourceProvider);
            // register callout overlay listener to customize it.
            mOverlayManager.SetOnCalloutOverlayListener(this);
            // register callout overlay view listener to customize it.
            //mOverlayManager.SetOnCalloutOverlayViewListener(onCalloutOverlayViewListener);
            mOverlayManager.CalloutOverlayViewEvent = OnCreateCalloutOverlayView;

            // location manager
            mMapLocationManager = new NMapLocationManager(this);
            //mMapLocationManager.SetOnLocationChangeListener(onMyLocationChangeListener);
            mMapLocationManager.LocationChanged += OnLocationChanged;
            mMapLocationManager.LocationUnavailableArea += OnLocationUnablableArea;
            mMapLocationManager.LocationUpdateTimeout += OnLocationUpdateTimeout;

            // compass manager
            mMapCompassManager = new NMapCompassManager(this);

            // create my location overlay
            mMyLocationOverlay = mOverlayManager.CreateMyLocationOverlay(mMapLocationManager, mMapCompassManager);
        }

        protected override void OnStart()
		{
            base.OnStart();
		}

		protected override void OnResume()
		{
            base.OnResume();
		}

		protected override void OnStop()
		{
            StopMyLocation();
            base.OnStop();
		}

		protected override void OnDestroy()
		{
            // save map view state such as map center position and zoom level.
            SaveInstanceState();
            base.OnDestroy();
		}

		/**
         * Invoked during init to give the Activity a chance to set up its Menu.
         * 
         * @param menu the Menu to which entries may be added
         * @return true
         */
		public override bool OnCreateOptionsMenu(IMenu menu)
		{
            MenuInflater.Inflate(Resource.Menu.menu, menu);
            return true;
		}

		public override bool OnPrepareOptionsMenu(IMenu menu)
		{
            var viewMode = mMapController.MapViewMode;
            var isTraffic = mMapController.MapViewTrafficMode;
            var isBicycle = mMapController.MapViewBicycleMode;
            var isAlphaLayer = mMapController.MapAlphaLayerMode;

            menu.FindItem(Resource.Id.action_revert).SetEnabled((viewMode != NMapView.ViewModeVector) || isTraffic || mOverlayManager.SizeofOverlays() > 0);
            menu.FindItem(Resource.Id.action_vector).SetChecked(viewMode == NMapView.ViewModeVector);
            menu.FindItem(Resource.Id.action_satellite).SetChecked(viewMode == NMapView.ViewModeHybrid);
            menu.FindItem(Resource.Id.action_traffic).SetChecked(isTraffic);
            menu.FindItem(Resource.Id.action_bicycle).SetChecked(isBicycle);
            menu.FindItem(Resource.Id.action_alpha_layer).SetChecked(isAlphaLayer);

            return true;
		}

		public override bool OnMenuItemSelected(int featureId, IMenuItem item)
		{
            switch (item.ItemId)
            {
                case Resource.Id.action_revert:
                    if (mMyLocationOverlay != null)
                    {
                        StopMyLocation();
                        mOverlayManager.RemoveOverlay(mMyLocationOverlay);
                    }

                    mMapController.MapViewMode = NMapView.ViewModeVector;
                    mMapController.MapViewTrafficMode = false;
                    mMapController.MapViewBicycleMode = false;

                    mOverlayManager.ClearOverlays();
                    return true;
                case Resource.Id.action_vector:
                    InvalidateMenu();
                    mMapController.MapViewMode = NMapView.ViewModeVector;
                    return true;

                case Resource.Id.action_satellite:
                    InvalidateMenu();
                    mMapController.MapViewMode = NMapView.ViewModeHybrid;
                    return true;

                case Resource.Id.action_traffic:
                    InvalidateMenu();
                    mMapController.MapViewTrafficMode = !mMapController.MapViewTrafficMode;
                    return true;

                case Resource.Id.action_bicycle:
                    InvalidateMenu();
                    mMapController.MapViewBicycleMode = !mMapController.MapViewBicycleMode;
                    return true;

                case Resource.Id.action_alpha_layer:
                    InvalidateMenu();
                    var color = Convert.ToInt32("0xccFFFFFF", 16);
                    mMapController.SetMapAlphaLayerMode(!mMapController.MapAlphaLayerMode, color);
                    return true;

                case Resource.Id.action_zoom:
                    mMapView.DisplayZoomControls(true);
                    return true;

                case Resource.Id.action_my_location:
                    StartMyLocation();
                    return true;

                case Resource.Id.action_poi_data:
                    mOverlayManager.ClearOverlays();

                    // add POI data overlay
                    TestPOIdataOverlay();
                    return true;

                case Resource.Id.action_path_data:
                    mOverlayManager.ClearOverlays();

                    // add path data overlay
                    TestPathDataOverlay();

                    // add path POI data overlay
                    TestPathPOIdataOverlay();
                    return true;

                case Resource.Id.action_floating_data:
                    mOverlayManager.ClearOverlays();
                    TestFloatingPOIdataOverlay();
                    return true;

                case Resource.Id.action_new_activity:
                    Intent intent = new Intent(this.ApplicationContext, typeof(FragmentMapActivity));
                    StartActivity(intent);
                    return true;

                case Resource.Id.action_visible_bounds:
                    // test visible bounds
                    var viewFrame = mMapView.MapController.ViewFrameVisible;
                    mMapController.SetBoundsVisible(0, 0, viewFrame.Width(), viewFrame.Height() - 200);

                    // add POI data overlay
                    mOverlayManager.ClearOverlays();

                    TestPathDataOverlay();
                    return true;

                case Resource.Id.action_scale_factor:
                    if (mMapView.MapProjection.IsProjectionScaled) 
                    {
                        if (mMapView.MapProjection.IsMapHD) 
                        {
                            mMapView.SetScalingFactor(2.0F, false);
                        } 
                        else 
                        {
                            mMapView.SetScalingFactor(1.0F, false);
                        }
                    } 
                    else 
                    {
                        mMapView.SetScalingFactor(2.0F, true);
                    }
                    mIsMapEnlared = mMapView.MapProjection.IsProjectionScaled;
                    return true;

                case Resource.Id.action_auto_rotate:
                    if(mMapView.IsAutoRotateEnabled) 
                    {
                        mMapView.SetAutoRotateEnabled(false, false);

                        mMapContainerView.RequestLayout();

                        mHnadler.RemoveCallbacks(mTestAutoRotation);
                    } 
                    else 
                    {
                        mMapView.SetAutoRotateEnabled(true, false);

                        mMapView.SetRotateAngle(30);
                        mHnadler.PostDelayed(mTestAutoRotation, AUTO_ROTATE_INTERVAL);

                        mMapContainerView.RequestLayout();
                    }
                    return true;
                case Resource.Id.action_navermap:
                    mMapView.ExecuteNaverMap();
                    return true;

                }
            return false;
		}

        private void mTestAutoRotation()
        {
            //if (mMapView.IsAutoRotateEnabled) 
            //{
            //    var random = new Random();
            //    var degree = (float)random.Next(360);
            //    degree = mMapView.RoateAngle + 30;
            //    mMapView.SetRotateAngle(degree);    
            //    mHnadler.PostDelayed(mTestAutoRotation, AUTO_ROTATE_INTERVAL);
            //}
        }

        private void InvalidateMenu()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Honeycomb)
            {
                InvalidateOptionsMenu();
            }
        }
		#endregion

		#region private method area
		private void StartMyLocation()
        {

            if (mMyLocationOverlay != null)
            {
                if (!mOverlayManager.HasOverlay(mMyLocationOverlay))
                {
                    mOverlayManager.AddOverlay(mMyLocationOverlay);
                }

                if (mMapLocationManager.IsMyLocationEnabled)
                {

                    if (!mMapView.IsAutoRotateEnabled)
                    {
                        mMyLocationOverlay.CompassHeadingVisible = true;

                        mMapCompassManager.EnableCompass();

                        mMapView.SetAutoRotateEnabled(true, false);

                        mMapContainerView.RequestLayout();
                    }
                    else
                    {
                        StopMyLocation();
                    }

                    mMapView.PostInvalidate();
                }
                else
                {
                    var isMyLocationEnabled = mMapLocationManager.EnableMyLocation(true);
                    if (!isMyLocationEnabled)
                    {
                        Toast.MakeText(this, "Please enable a My Location source in system settings",
                                       ToastLength.Long).Show();

                        Intent goToSettings = new Intent(Settings.ActionLocationSourceSettings);
                        StartActivity(goToSettings);

                        return;
                    }
                }
            }
        }

        private void StopMyLocation()
        {
            if (mMyLocationOverlay != null)
            {
                mMapLocationManager.DisableMyLocation();

                if (mMapView.IsAutoRotateEnabled)
                {
                    mMyLocationOverlay.CompassHeadingVisible = false;

                    mMapCompassManager.DisableCompass();

                    mMapView.SetAutoRotateEnabled(false, false);

                    mMapContainerView.RequestLayout();
                }
            }
        }

        private void RestoreInstanceState()
        {
            mPreferences = GetPreferences(FileCreationMode.Private);

            var longitudeE6 = mPreferences.GetInt(KEY_CENTER_LONGITUDE, NMAP_LOCATION_DEFAULT.LongitudeE6);
            var latitudeE6 = mPreferences.GetInt(KEY_CENTER_LATITUDE, NMAP_LOCATION_DEFAULT.LatitudeE6);
            var level = mPreferences.GetInt(KEY_ZOOM_LEVEL, NMAP_ZOOMLEVEL_DEFAULT);
            var viewMode = mPreferences.GetInt(KEY_VIEW_MODE, NMAP_VIEW_MODE_DEFAULT);
            var trafficMode = mPreferences.GetBoolean(KEY_TRAFFIC_MODE, NMAP_TRAFFIC_MODE_DEFAULT);
            var bicycleMode = mPreferences.GetBoolean(KEY_BICYCLE_MODE, NMAP_BICYCLE_MODE_DEFAULT);

            mMapController.MapViewMode = viewMode;
            mMapController.MapViewTrafficMode = trafficMode;
            mMapController.MapViewBicycleMode = bicycleMode;
            mMapController.SetMapCenter(new NGeoPoint(longitudeE6, latitudeE6), level);

            if (mIsMapEnlared)
            {
                mMapView.SetScalingFactor(2.0F);
            }
            else
            {
                mMapView.SetScalingFactor(1.0F);
            }
        }

        private void SaveInstanceState()
        {
            if (mPreferences == null)
            {
                return;
            }

            var center = mMapController.MapCenter;
            var level = mMapController.ZoomLevel;
            var viewMode = mMapController.MapViewMode;
            var trafficMode = mMapController.MapViewTrafficMode;
            var bicycleMode = mMapController.MapViewBicycleMode;

            var edit = mPreferences.Edit();

            edit.PutInt(KEY_CENTER_LONGITUDE, center.LongitudeE6);
            edit.PutInt(KEY_CENTER_LATITUDE, center.LatitudeE6);
            edit.PutInt(KEY_ZOOM_LEVEL, level);
            edit.PutInt(KEY_VIEW_MODE, viewMode);
            edit.PutBoolean(KEY_TRAFFIC_MODE, trafficMode);
            edit.PutBoolean(KEY_BICYCLE_MODE, bicycleMode);

            edit.Commit();
        }

        private void TestPathDataOverlay()
        {

            // set path data points
            NMapPathData pathData = new NMapPathData(9);

            pathData.InitPathData();
            pathData.AddPathPoint(127.108099, 37.366034, NMapPathLineStyle.TypeSolid);
            pathData.AddPathPoint(127.108088, 37.366043, 0);
            pathData.AddPathPoint(127.108079, 37.365619, 0);
            pathData.AddPathPoint(127.107458, 37.365608, 0);
            pathData.AddPathPoint(127.107232, 37.365608, 0);
            pathData.AddPathPoint(127.106904, 37.365624, 0);
            pathData.AddPathPoint(127.105933, 37.365621, NMapPathLineStyle.TypeDash);
            pathData.AddPathPoint(127.105929, 37.366378, 0);
            pathData.AddPathPoint(127.106279, 37.366380, 0);
            pathData.EndPathData();

            NMapPathDataOverlay pathDataOverlay = mOverlayManager.CreatePathDataOverlay(pathData);
            if (pathDataOverlay != null)
            {

                // add path data with polygon type
                NMapPathData pathData2 = new NMapPathData(4);
                pathData2.InitPathData();
                pathData2.AddPathPoint(127.106, 37.367, NMapPathLineStyle.TypeSolid);
                pathData2.AddPathPoint(127.107, 37.367, 0);
                pathData2.AddPathPoint(127.107, 37.368, 0);
                pathData2.AddPathPoint(127.106, 37.368, 0);
                pathData2.EndPathData();
                pathDataOverlay.AddPathData(pathData2);
                // set path line style
                NMapPathLineStyle pathLineStyle = new NMapPathLineStyle(mMapView.Context);
                pathLineStyle.PataDataType = NMapPathLineStyle.DataTypePolygon;
                pathLineStyle.SetLineColor(0xA04DD2, 0xff);
                pathLineStyle.SetFillColor(0xFFFFFF, 0x00);
                pathData2.PathLineStyle = pathLineStyle;

                // add circle data
                NMapCircleData circleData = new NMapCircleData(1);
                circleData.InitCircleData();
                circleData.AddCirclePoint(127.1075, 37.3675, 50.0F);
                circleData.EndCircleData();
                pathDataOverlay.AddCircleData(circleData);
                // set circle style
                NMapCircleStyle circleStyle = new NMapCircleStyle(mMapView.Context);
                circleStyle.SetLineType(NMapPathLineStyle.TypeDash);
                circleStyle.SetFillColor(0x000000, 0x00);
                circleData.CircleStyle = circleStyle;

                // show all path data
                pathDataOverlay.ShowAllPathData(0);
            }
        }

        private void TestPathPOIdataOverlay()
        {
            // set POI data
            NMapPOIdata poiData = new NMapPOIdata(4, mMapViewerResourceProvider, true);
            poiData.BeginPOIdata(4);
            poiData.AddPOIitem(349652983, 149297368, "Pizza 124-456", NMapPOIflagType.FROM, null);
            poiData.AddPOIitem(349652966, 149296906, null, NMapPOIflagType.NUMBER_BASE + 1, null);
            poiData.AddPOIitem(349651062, 149296913, null, NMapPOIflagType.NUMBER_BASE + 999, null);
            poiData.AddPOIitem(349651376, 149297750, "Pizza 000-999", NMapPOIflagType.TO, null);
            poiData.EndPOIdata();

            // create POI data overlay
            NMapPOIdataOverlay poiDataOverlay = mOverlayManager.CreatePOIdataOverlay(poiData, null);

            // set event listener to the overlay
            //poiDataOverlay.OnStateChangeListener = onPOIdataStateChangeListener;
            poiDataOverlay.CalloutClick += OnCalloutClick;
            poiDataOverlay.FocusChanged += OnFocusChanged;

        }

        private void TestPOIdataOverlay()
        {

            // Markers for POI item
            int markerId = NMapPOIflagType.PIN;

            // set POI data
            NMapPOIdata poiData = new NMapPOIdata(2, mMapViewerResourceProvider);
            poiData.BeginPOIdata(2);
            NMapPOIitem item = poiData.AddPOIitem(127.0630205, 37.5091300, "Pizza 777-111", markerId, 0);
            item.SetRightAccessory(true, NMapPOIflagType.CLICKABLE_ARROW);
            poiData.AddPOIitem(127.061, 37.51, "Pizza 123-456", markerId, 0);
            poiData.EndPOIdata();

            // create POI data overlay
            NMapPOIdataOverlay poiDataOverlay = mOverlayManager.CreatePOIdataOverlay(poiData, null);

            // set event listener to the overlay
            //poiDataOverlay.OnStateChangeListener = onPOIdataStateChangeListener;
            poiDataOverlay.CalloutClick += OnCalloutClick;
            poiDataOverlay.FocusChanged += OnFocusChanged;

            // select an item
            poiDataOverlay.SelectPOIitem(0, true);

            // show all POI data
            //poiDataOverlay.showAllPOIdata(0);
        }

        private void TestFloatingPOIdataOverlay()
        {
            // Markers for POI item
            int marker1 = NMapPOIflagType.PIN;

            // set POI data
            NMapPOIdata poiData = new NMapPOIdata(1, mMapViewerResourceProvider);
            poiData.BeginPOIdata(1);
            NMapPOIitem item = poiData.AddPOIitem(null, "Touch & Drag to Move", marker1, 0);
            if (item != null)
            {
                // initialize location to the center of the map view.
                item.Point = mMapController.MapCenter;
                // set floating mode
                item.FloatingMode = NMapPOIitem.FloatingTouch | NMapPOIitem.FloatingDrag;
                // show right button on callout
                item.SetRightButton(true);

                mFloatingPOIitem = item;
            }
            poiData.EndPOIdata();

            // create POI data overlay
            NMapPOIdataOverlay poiDataOverlay = mOverlayManager.CreatePOIdataOverlay(poiData, null);
            if (poiDataOverlay != null)
            {
                //poiDataOverlay.SetOnFloatingItemChangeListener(onPOIdataFloatingItemChangeListener);
                poiDataOverlay.FloatingItemChange += onPointChanged;

                // set event listener to the overlay
                //poiDataOverlay.OnStateChangeListener = onPOIdataStateChangeListener;
                poiDataOverlay.CalloutClick += OnCalloutClick;
                poiDataOverlay.FocusChanged += OnFocusChanged;

                poiDataOverlay.SelectPOIitem(0, false);

                mFloatingPOIdataOverlay = poiDataOverlay;
            }
        }
        #endregion

        #region  Listener area
        //OnMapDataProviderListener
        //NMapPlacemark p0, NMapError p1
        void OnReverseGeocoderResponse(object sender, DataProviderEventArgs e) 
        {
            var placeMark = e.P0;
            var errInfo = e.P1;
            if (DEBUG)
            {
                Log.Info(LOG_TAG, "onReverseGeocoderResponse: placeMark="
                         + ((placeMark != null) ? placeMark.ToString() : null));
            }

            if (errInfo != null)
            {
                Log.Error(LOG_TAG, "Failed to findPlacemarkAtLocation: error=" + errInfo.ToString());

                Toast.MakeText(this, errInfo.ToString(), ToastLength.Long).Show();
                return;
            }

            if (mFloatingPOIitem != null && mFloatingPOIdataOverlay != null)
            {
                mFloatingPOIdataOverlay.DeselectFocusedPOIitem();

                if (placeMark != null)
                {
                    mFloatingPOIitem.Title = placeMark.ToString();
                }
                mFloatingPOIdataOverlay.SelectPOIitemBy(mFloatingPOIitem.Id, false);
            }
        }

        /* MyLocation Listener start*/
        private void OnLocationChanged(object sender, NMapLocationManager.LocationChangedEventArgs e)
        {
            var myLocation = e.P1;
            if (mMapController != null)
            {
                mMapController.AnimateTo(myLocation);
            }
        }

        private void OnLocationUnablableArea(object sender, NMapLocationManager.LocationUnavailableAreaEventArgs e)
        {
            Toast.MakeText(this, "Your current location is unavailable area.", ToastLength.Long).Show();
            StopMyLocation();
        }

        private void OnLocationUpdateTimeout(object sender, NMapLocationManager.LocationUpdateTimeoutEventArgs e)
        {
            // stop location updating
            //          Runnable runnable = new Runnable() {
            //              public void run() {                                     
            //                  stopMyLocation();
            //              }
            //          };
            //          runnable.run(); 

            Toast.MakeText(this, "Your current location is temporarily unavailable.", ToastLength.Long).Show();
            
        }
        /* MyLocation Listener end*/

        /* MapView State Change Listener start*/
        private void OnMapInit(object sender, NMapView.MapInitHandlerEventArgs e)
        {
            var errorInfo = e.P1;
            if (e.P1 == null)
            { // success
              // restore map view state such as map center position and zoom level.
                RestoreInstanceState();
            }
            else
            { // fail
                
                Log.Error(LOG_TAG, "onFailedToInitializeWithError: " + errorInfo.ToString());

                Toast.MakeText(this, errorInfo.ToString(), ToastLength.Long).Show();
            }
        }

        //NMapView mapView, int animType, int animState
        private void OnAnimationStateChange(object sender, NMapView.AnimationStateChangeEventArgs e)
        {
            if (DEBUG)
            {
                var animType = e.P1;
                var animState = e.P2;
                Log.Info(LOG_TAG, "onAnimationStateChange: animType=" + animType + ", animState=" + animState);
            }
        }

        //NMapView mapView, NGeoPoint center
        private void OnMapCenterChange(object sender, NMapView.MapCenterChangeEventArgs e)
        {
            if (DEBUG)
            {
                var center = e.P1;
                Log.Info(LOG_TAG, "onMapCenterChange: center=" + center.ToString());
            }
        }

        //NMapView mapView, int level
        private void OnZoomLevelChage(object sender, NMapView.ZoomLevelChangeEventArgs e)
        {
            if (DEBUG)
            {
                var level = e.P1;
                Log.Info(LOG_TAG, "onZoomLevelChange: level=" + level);
            }
        }
        /* MapView State Change Listener end*/

        //IOnMapViewDelegate
        public bool IsLocationTracking
        {
            get
            {
                if (mMapLocationManager != null)
                {
                    if (mMapLocationManager.IsMyLocationEnabled)
                    {
                        return mMapLocationManager.IsMyLocationFixed;
                    }
                }
                return false;
            }
        }

        /* POI data State Change Listener start*/
        //NMapPOIdataOverlay poiDataOverlay, NMapPOIitem item
        private void OnCalloutClick(object sender, CalloutClickEventArgs e)
        {
            var item = e.P1;
            if (DEBUG)
            {
                Log.Info(LOG_TAG, "onCalloutClick: title=" + item.Title);
            }

            // [[TEMP]] handle a click event of the callout
            Toast.MakeText(this, "onCalloutClick: " + item.Title, ToastLength.Long).Show();
        }

        //NMapPOIdataOverlay poiDataOverlay, NMapPOIitem item
        private void OnFocusChanged(object sender, FocusChangedEventArgs e)
        {
            var item = e.P1;

            if (DEBUG)
            {
                if (item != null)
                {
                    Log.Info(LOG_TAG, "onFocusChanged: " + item.ToString());
                }
                else
                {
                    Log.Info(LOG_TAG, "onFocusChanged: ");
                }
            }
        }
        /* POI data State Change Listener end*/

        //OnFloatingItemChangeListener
        //NMapPOIdataOverlay poiDataOverlay, NMapPOIitem item
        void onPointChanged(object sender , FloatingItemChangeEventArgs e) 
        {
            var item = e.P1;
            var point = item.Point;//item.getPoint();

            if (DEBUG)
            {
                Log.Info(LOG_TAG, "onPointChanged: point=" + point.ToString());
            }

            FindPlacemarkAtLocation(point.Longitude, point.Latitude);
            item.Title = null;
        }

        //OnCalloutOverlayViewListener
        View OnCreateCalloutOverlayView(NMapOverlay itemOverlay, NMapOverlayItem overlayItem,Rect itemBounds)
        {
            if (overlayItem != null)
            {
                // [TEST] 말풍선 오버레이를 뷰로 설정함
                String title = overlayItem.Title;
                if (title != null && title.Length > 5)
                {
                    return new NMapCalloutCustomOverlayView(this, itemOverlay, overlayItem, itemBounds);
                }
            }

            // null을 반환하면 말풍선 오버레이를 표시하지 않음
            return null;
        }

        // Implement IOnCalloutOverlayListener
        public NMapCalloutOverlay OnCreateCalloutOverlay(NMapOverlay itemOverlay, NMapOverlayItem overlayItem,Rect itemBounds)
        {
            // handle overlapped items
            if (itemOverlay is NMapPOIdataOverlay poiDataOverlay) 
            {
                // check if it is selected by touch event
                if (!poiDataOverlay.IsFocusedBySelectItem)
                {
                    int countOfOverlappedItems = 1;

                    var poiData = poiDataOverlay.POIdata;
                    for (int i = 0; i < poiData.Count(); i++)
                    {
                        var poiItem = poiData.GetPOIitem(i);

                        // skip selected item
                        if (poiItem == overlayItem)
                        {
                            continue;
                        }

                        // check if overlapped or not
                        if (Rect.Intersects(poiItem.BoundsInScreen, overlayItem.BoundsInScreen))
                        {
                            countOfOverlappedItems++;
                        }
                    }

                    if (countOfOverlappedItems > 1)
                    {
                        var text = countOfOverlappedItems + " overlapped items for " + overlayItem.Title;
                        Toast.MakeText(this, text, ToastLength.Long).Show();
                        return null;
                    }
                }
            }

            // use custom old callout overlay
            if (overlayItem is NMapPOIitem nMapPOIitem) 
            {
                if (nMapPOIitem.ShowRightButton())
                {
                    return new NMapCalloutCustomOldOverlay(itemOverlay, overlayItem, itemBounds, mMapViewerResourceProvider);
                }
            }

            // use custom callout overlay
            return new NMapCalloutCustomOverlay(itemOverlay, overlayItem, itemBounds, mMapViewerResourceProvider);

            // set basic callout overlay
            //return new NMapCalloutBasicOverlay(itemOverlay, overlayItem, itemBounds);         
        }
        #endregion

        #region private class area
        /** 
         * Container view class to rotate map view.
         */
        class MapContainerView : ViewGroup
        {
            NMapViewer parent;
            public MapContainerView(Context context, NMapViewer parent) : base(context)
            {
                this.parent = parent;
            }

            protected override void OnLayout(bool changed, int left, int top, int right, int bottom)
            {
                int width = Width;
                int height = Height;
                int count = ChildCount;
                for (int i = 0; i < count; i++)
                {
                    var view = GetChildAt(i);
                    int childWidth = view.MeasuredWidth;
                    int childHeight = view.MeasuredHeight;
                    int childLeft = (width - childWidth) / 2;
                    int childTop = (height - childHeight) / 2;
                    view.Layout(childLeft, childTop, childLeft + childWidth, childTop + childHeight);
                }

                if (changed)
                {
                    parent.mOverlayManager.OnSizeChanged(width, height);
                }
            }

            protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
            {
                int w = GetDefaultSize(SuggestedMinimumWidth, widthMeasureSpec);
                int h = GetDefaultSize(SuggestedMinimumHeight, heightMeasureSpec);
                int sizeSpecWidth = widthMeasureSpec;
                int sizeSpecHeight = heightMeasureSpec;

                int count = ChildCount;
                for (int i = 0; i < count; i++)
                {
                    var view = GetChildAt(i);

                    if (view is NMapView) 
                    {
                        if (parent.mMapView.IsAutoRotateEnabled)
                        {
                            int diag = (((int)(Math.Sqrt(w * w + h * h)) + 1) / 2 * 2);
                            sizeSpecWidth = MeasureSpec.MakeMeasureSpec(diag, MeasureSpecMode.Exactly);
                            sizeSpecHeight = sizeSpecWidth;
                        }
                    }

                    view.Measure(sizeSpecWidth, sizeSpecHeight);
                }
                base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
            }
        }
        #endregion
    }
}
