using System;

using UIKit;
using NMapViewerSDK.iOS;
using CoreGraphics;
using System.Diagnostics;

namespace NaveriOSMapViewApp
{
    public partial class MovableMarkerViewController : UIViewController, INMapViewNPOIdataOverlayDelegate
    {
        #region private member fields area
        NMapView mapView;
        #endregion

        public MovableMarkerViewController() : base("MovableMarkerViewController", null)
        {
        }

        #region override methods area
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
            base.ViewDidAppear(animated);
            AddMarkers();
        }

        public override void ViewWillDisappear(bool animated)
        {
            ClearOverlays();
            mapView.ViewWillDisappear();
            base.ViewWillDisappear(animated);
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

        #region private Methods Area
        void AddMarkers()
        {
            ClearOverlays();

            var mapOverlayManager = mapView.MapOverlayManager;
            var poiDataOverlay = mapOverlayManager.NewPOIdataOverlay();

            poiDataOverlay.InitPOIdata(1);
            var poiItem = poiDataOverlay.AddPOIitemAtLocation(NMapViewResource.NGeoPointMake(126.979, 37.567), "Touch & Drag to Move", UserPOIflagType.Default, 0, null);
            // set floating mode
            poiItem.SetPOIflagMode(NMapPOIflagMode.Touch);
            // hide right button on callout
            poiItem.HasRightCalloutAccessory = false;
            poiDataOverlay.EndPOIdata();
            // select item
            poiDataOverlay.SelectPOIitemAtIndex(0, true);
            // show all POI data
            poiDataOverlay.ShowAllPOIdata();
        }

        void ClearOverlays()
        {
            var mapOverlayManager = mapView.MapOverlayManager;
            mapOverlayManager.ClearOverlays();
        }
        #endregion
    }
}

