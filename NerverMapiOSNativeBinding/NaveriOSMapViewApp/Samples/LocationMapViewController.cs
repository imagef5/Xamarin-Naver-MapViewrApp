/*
 * 소스 참조 : https://developers.naver.com/docs/map/android/
 *           https://github.com/navermaps/maps.android
 * 네이버 지도에 서비스 저작권에 대한 자세한 내용은 Naver Developer 페이지를 참조하시기 바랍니다.
 * (https://github.com/navermaps/maps.android#license)
 * 
 * Copyright 2016 NAVER Corp.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
using System;
using UIKit;
using NMapViewerSDK.iOS;
using CoreGraphics;
using System.Diagnostics;
using CoreLocation;
using Foundation;

namespace NaveriOSMapViewApp
{
    public partial class LocationMapViewController : UIViewController, INMapViewNPOIdataOverlayDelegate, INMapLocationManagerDelegate
    {
        #region Fields Area
        NMapView mapView;
        State currentState;
        UIButton changeStateButton;
        #endregion

        public LocationMapViewController() : base("LocationMapViewController", null)
        {
        }

        #region override methods Area
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            mapView = new NMapView(View.Frame);
            NavigationController.NavigationBar.Translucent = false;
            // set the delegate for map view
            mapView.WeakDelegate = this;

            // set the application api key for Open MapViewer Library
            //[self.mapView setClientId:@"YOUR CLIENT ID"];
            mapView.SetClientId(AppSetting.CLIENT_ID);
            mapView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

            View.AddSubview(mapView);
            currentState = State.Disabled;

            UIButton button = new UIButton(new CGRect(15, 30, 36, 36));
            var image = UIImage.FromBundle("v4_btn_navi_location_normal");
            button.SetImage(image, UIControlState.Normal);
            button.AddTarget(buttonClicked, UIControlEvent.TouchUpInside);
            changeStateButton = button;
            View.AddSubview(button);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewWillTransitionToSize(CGSize toSize, IUIViewControllerTransitionCoordinator coordinator)
        {
            //base.ViewWillTransitionToSize(toSize, coordinator);
            if (toSize.Width != View.Frame.Size.Width)
            {
                if (mapView.AutoRotateEnabled)
                {
                    mapView.SetAutoRotateEnabled(false, false);
                    coordinator.AnimateAlongsideTransition
                    (
                        (context) =>
                        {
                            mapView.SetAutoRotateEnabled(true, true);
                        },
                        null
                    );
                }
            }
        }

        public override void WillTransitionToTraitCollection(UITraitCollection traitCollection, IUIViewControllerTransitionCoordinator coordinator)
        {
            if (traitCollection != null)
            {
                base.WillTransitionToTraitCollection(traitCollection, coordinator);
                if (View.TraitCollection.HorizontalSizeClass != traitCollection.HorizontalSizeClass
                   || View.TraitCollection.VerticalSizeClass != traitCollection.VerticalSizeClass)
                {
                    if (mapView.AutoRotateEnabled)
                    {
                        mapView.SetAutoRotateEnabled(false, false);
                    }
                }
            }
        }

        public override void TraitCollectionDidChange(UITraitCollection previousTraitCollection)
        {
            //base.TraitCollectionDidChange(previousTraitCollection);
            if (previousTraitCollection != null)
            {
                if (View.TraitCollection.HorizontalSizeClass != previousTraitCollection.HorizontalSizeClass
                    || View.TraitCollection.VerticalSizeClass != previousTraitCollection.VerticalSizeClass)
                {
                    if (currentState == State.TrackingWithHeading)
                    {
                        mapView.SetAutoRotateEnabled(true, true);
                    }
                }
            }
        }

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            mapView.ViewWillAppear();
        }

        public override void ViewDidDisappear(bool animated)
        {
            mapView.ViewDidDisappear();
            base.ViewDidDisappear(animated);
        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            mapView.ViewWillDisappear();
            StopLocationUpdating();
        }
        #endregion

        #region Implement INMapViewNPOIdataOverlayDelegate
        public void OnMapView(NMapView mapView, NMapError error)
        {
            //base.OnMapView(mapView, error);
            if (error == null)
            {
                //[self.mapView setMapCenter:NGeoPointMake(126.978371, 37.5666091) atLevel:11];
                //[self.mapView setMapEnlarged:YES mapHD:YES];
                var location = new NGeoPoint()
                {
                    Longitude = 126.978391,
                    Latitude = 37.5666091,
                };
                mapView.SetMapCenter(location, 11);
                mapView.SetMapEnlarged(true, true);
                mapView.SetMapViewMode(NMapViewMode.Vector);

            }
            else
            {
                Debug.WriteLine("OnMapView:initHandler:" + error.Description);
            }
        }

        public UIImage OnMapOverlay(NMapPOIdataOverlay poiDataOverlay, NMapPOIitem poiItem, bool selected)
        {
            return NMapViewResource.ImageWithType(poiItem.PoiFlagType, selected); ;
        }

        public CGPoint OnMapOverlay(NMapPOIdataOverlay poiDataOverlay, int poiFlagType)
        {
            return NMapViewResource.AnchorPoint(poiFlagType);
        }

        public UIImage OnMapOverlay(NMapPOIdataOverlay poiDataOverlay, NMapPOIitem poiItem, CGSize constraintSize, bool selected, UIImage imageForCalloutRightAccessory, CGPoint calloutPosition, CGRect calloutHitRect)
        {
            return null;
        }

        public CGPoint OnMapOverlayCalloutOffsetWithType(NMapPOIdataOverlay poiDataOverlay, int poiFlagType)
        {
            return CGPoint.Empty;
        }

        // @optional -(BOOL)onMapViewIsGPSTracking:(NMapView *)mapView;
        [Export("onMapViewIsGPSTracking:")]
        public bool OnMapViewIsGPSTracking(NMapView mapView)
        {
            return NMapLocationManager.SharedInstance.IsTrackingEnabled;
        }
        #endregion

        #region Implement INMapLocationManagerDelegate Area
        public void DidUpdateToLocation(NMapLocationManager locationManager, CLLocation location)
        {
            CLLocationCoordinate2D coordinate = location.Coordinate;
            NGeoPoint myLocation = new NGeoPoint();
            myLocation.Longitude = coordinate.Latitude;
            myLocation.Latitude = coordinate.Latitude;
            var locationAccuracy = (float)location.HorizontalAccuracy;
            mapView.MapOverlayManager.SetMyLocation(myLocation, locationAccuracy);
            mapView.SetMapCenter(myLocation);
        }

        public void DidFailWithError(NMapLocationManager locationManager, NMapLocationManagerErrorType errorType)
        {
            string message = string.Empty;
            switch (errorType)
            {
                case NMapLocationManagerErrorType.Unknown:
                case NMapLocationManagerErrorType.Canceled:
                    message = "일시적으로 내위치를 확인 할 수 없습니다.";
                    break;
                case NMapLocationManagerErrorType.Denied:
                    if (UIDevice.CurrentDevice.CheckSystemVersion(4, 0))
                    {
                        message = "위치 정보를 확인 할 수 없습니다.\\n사용자의 위치 정보를 확인하도록 허용하시려면 위치서비스를 켜십시오.";
                    }
                    else
                    {
                        message = "위치 정보를 확인 할 수 없습니다.";
                    }
                    break;
                case NMapLocationManagerErrorType.UnavailableArea:
                    message = "현재 위치는 지도내에 표시 할 수 없습니다.";
                    break;
                case NMapLocationManagerErrorType.Heading:
                    message = "나침반 정보를 확인 할 수 없습니다.";
                    break;
            }
            if (!string.IsNullOrEmpty(message))
            {
                UIAlertController alert = UIAlertController.Create("NMapViewer", message, UIAlertControllerStyle.Alert);
                UIAlertAction ok = UIAlertAction.Create("OK", UIAlertActionStyle.Default, null);

                alert.AddAction(ok);
                this.PresentViewController(alert, true, null);
                if (mapView.AutoRotateEnabled)
                {
                    mapView.SetAutoRotateEnabled(false, false);
                }
                mapView.MapOverlayManager.ClearMyLocationOverlay();
            }
        }

        // @optional -(void)locationManager:(NMapLocationManager *)locationManager didUpdateHeading:(CLHeading *)heading;
        [Export("locationManager:didUpdateHeading:")]
        public void DidUpdateHeading(NMapLocationManager locationManager, CLHeading heading)
        {
            var headingValue = heading.TrueHeading < 0.0 ? heading.MagneticHeading : heading.TrueHeading;
            SetCompassHeadingValue((float)headingValue);
        }
        #endregion

        #region button Clicked Action
        void buttonClicked(object sender, EventArgs e)
        {
            var lm = NMapLocationManager.SharedInstance;
            switch (currentState)
            {
                case State.Disabled:
                    EnableLocationUpdate();
                    UpdateState(State.Tracking);
                    break;
                case State.Tracking:
                    if (lm.HeadingAvailable)
                    {
                        EnableLocationUpdate();
                        if (EnableHeading())
                        {
                            UpdateState(State.TrackingWithHeading);
                        }
                        else
                        {
                            StopLocationUpdating();
                            UpdateState(State.Disabled);
                        }
                    }
                    break;
                case State.TrackingWithHeading:
                    StopLocationUpdating();
                    UpdateState(State.Disabled);
                    break;
            }
        }
        #endregion

        #region private method area
        void StopLocationUpdating()
        {
            DisableHeading();
            DisableLocationUpdate();
        }

        bool EnableHeading()
        {
            var lm = NMapLocationManager.SharedInstance;
            if (lm.HeadingAvailable)
            {
                mapView.SetAutoRotateEnabled(true, true);
                lm.StartUpdatingHeading();
            }
            else
            {
                return false;
            }
            return true;
        }

        void DisableHeading()
        {
            NMapLocationManager lm = NMapLocationManager.SharedInstance;
            if (lm.HeadingAvailable)
            {
                lm.StopUpdatingHeading();
            }
            mapView.SetAutoRotateEnabled(false, true);
        }

        void EnableLocationUpdate()
        {
            var lm = NMapLocationManager.SharedInstance;
            if (!lm.LocationServiceEnabled)
            {
                DidFailWithError(lm, NMapLocationManagerErrorType.Denied);
                return;
            }
            if (!lm.IsUpdateLocationStarted)
            {
                lm.SetDelegate(this);
                lm.StartContinuousLocationInfo();
            }
        }

        void DisableLocationUpdate()
        {
            NMapLocationManager lm = NMapLocationManager.SharedInstance;
            if (lm.IsUpdateLocationStarted)
            {
                lm.StopUpdateLocationInfo();
                lm.SetDelegate(null);
            }
            mapView.MapOverlayManager.ClearOverlays();
        }

        void SetCompassHeadingValue(float headingValue)
        {
            if (mapView.AutoRotateEnabled)
            {
                mapView.SetRotateAngle(headingValue, true);
            }
        }

        void UpdateState(State newState)
        {
            currentState = newState;
            switch (currentState)
            {
                case State.Disabled:
                    changeStateButton.SetImage(UIImage.FromBundle("v4_btn_navi_location_normal"), UIControlState.Normal);
                    break;
                case State.Tracking:
                    changeStateButton.SetImage(UIImage.FromBundle("v4_btn_navi_location_selected"), UIControlState.Normal);
                    break;
                case State.TrackingWithHeading:
                    changeStateButton.SetImage(UIImage.FromBundle("v4_btn_navi_location_my"), UIControlState.Normal);
                    break;
            }
        }
        #endregion
    }

    enum State
    {
        Disabled,
        Tracking,
        TrackingWithHeading
    }
}

