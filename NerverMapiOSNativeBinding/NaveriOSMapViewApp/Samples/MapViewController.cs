using System;
using UIKit;
using NMapViewerSDK.iOS;
using System.Diagnostics;
using CoreGraphics;
using CoreAnimation;

namespace NaveriOSMapViewApp
{
    public partial class MapViewController : UIViewController, INMapViewNPOIdataOverlayDelegate
    {
        #region private member fields area
        NMapView mapView;
        #endregion

        public MapViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            mapView = new NMapView(View.Frame)
            {
                //set the delegate for map view
                WeakDelegate = this
            };
            // set the application api key for Open MapViewer Library
            mapView.SetClientId(AppSetting.CLIENT_ID);
            mapView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
            View.InsertSubview(mapView, 0);

            // set min and max level for range in the UIStepper
            InitStepper(mapView.MaxZoomLevel(), mapView.MinZoomLevel(), 11);
            View.BringSubviewToFront(levelSetpper);

            mapView.SetBuiltInAppControl(true);
            mapView.Layer.AddAnimation(new Animation(this), "mapViewAnimation");
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            mapView.Frame = View.Bounds;
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
            mapView.ViewDidAppear();
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            mapView.ViewWillDisappear();
            base.ViewWillDisappear(animated);
        }
        #region Implement INMapViewNPOIdataOverlayDelegate
        public void OnMapView(NMapView mapView, NMapError error)
        {
            //base.OnMapView(mapView, error);
            if (error == null)
            {
                //[self.mapView setMapCenter:NGeoPointMake(126.978371, 37.5666091) atLevel:11];
                //[self.mapView setMapEnlarged:YES mapHD:YES];
                var location = new NGeoPoint
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
        #endregion

        #region private Method
        void InitStepper(int maxValue, int minValue, int intValue)
        {
            levelSetpper.MaximumValue = maxValue;
            levelSetpper.MinimumValue = minValue;
            levelSetpper.StepValue = 1;
            levelSetpper.Value = intValue;
        }
        #endregion

        #region Controller Event 처리

        partial void showOverlayLayers(UIBarButtonItem sender)
        {
            UIAlertController alertController = UIAlertController.Create("Overlay Layers", null, UIAlertControllerStyle.ActionSheet);

            UIAlertAction trafficAction = UIAlertAction.Create
                                           (
                                                $"Traffic layer is {mapView.GetMapViewTrafficMode()} ? On : Off",
                                                UIAlertActionStyle.Default,
                                                (action) =>
                                                {
                                                    mapView.SetMapViewTrafficMode(!mapView.GetMapViewTrafficMode());
                                                }
                                            );
            UIAlertAction bicycleAction = UIAlertAction.Create
                                           (
                                                 $"Bicycle layer is {mapView.GetMapViewBicycleMode()} ? On : Off",
                                                UIAlertActionStyle.Default,
                                                (action) =>
                                                {
                                                    mapView.SetMapViewBicycleMode(!mapView.GetMapViewBicycleMode());
                                                }
                                           );
            //NMapViewerSDK 2.1.1 버전에는 MapViewAlphaLayerMode 가 구현되어 있지 않음.
            //UIAlertAction alphaAction = UIAlertAction.Create
            //(
            // $"Alpha layer is {mapView.MapViewAlphaLayerMode()} ? On : Off",
            //    UIAlertActionStyle.Default,
            //    (action) =>
            //    {
            //        mapView.SetMapViewAlphaLayerMode(!mapView.MapViewAlphaLayerMode());
            //    }
            //);
            alertController.AddAction(trafficAction);
            alertController.AddAction(bicycleAction);
            //alertController.AddAction(alphaAction);

            this.PresentViewController(alertController, true, null);
        }

        partial void changeMapMode(UISegmentedControl sender)
        {
            switch (sender.SelectedSegment)
            {
                case 0:
                    mapView.SetMapViewMode(NMapViewMode.Vector);
                    break;
                case 1:
                    mapView.SetMapViewMode(NMapViewMode.Satellite);
                    break;
                case 2:
                    mapView.SetMapViewMode(NMapViewMode.Hybrid);
                    break;
                default:
                    break;
            }
        }

        partial void levelStepperValeChanged(UIStepper sender)
        {
            mapView.SetZoomLevel((int)sender.Value);
        }

        #endregion

        #region private class
        class Animation : CAAnimation
        {
            MapViewController ctrl;
            public Animation(MapViewController ctrl)
            {
                this.ctrl = ctrl;
                this.Delegate = new CAAnimationDelegate();
            }

        }
        #endregion
    }
}