using System;
using System.Diagnostics;

using UIKit;
using CoreGraphics;
using NMapViewerSDK.iOS;

namespace NaveriOSMapViewApp
{
    public partial class ViewController : UIViewController, INMapViewNPOIdataOverlayDelegate
    {
        NMapView mapView;
        //UIStepper levelStepper;

        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            mapView = new NMapView()
            {
                Frame = View.Frame,
            };

            //// set the delegate for map view
            mapView.WeakDelegate = this;//new NMapViewNPOIdataOverlayDelegate();

            mapView.SetClientId(AppSetting.CLIENT_ID);
            View.AddSubview(mapView);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }

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
                    Latitude = 37.5666091,
                    Longitude = 126.978391
                };
                mapView.SetMapCenter(location, 11);
                mapView.SetMapEnlarged(true, true);
            }
            else
            {
                Debug.WriteLine("OnMapView:initHandler:" + error.Description);
            }
        }

        public UIImage OnMapOverlay(NMapPOIdataOverlay poiDataOverlay, NMapPOIitem poiItem, bool selected)
        {
            return null;
        }

        public CGPoint OnMapOverlay(NMapPOIdataOverlay poiDataOverlay, int poiFlagType)
        {
            return CGPoint.Empty;
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
    }
}
