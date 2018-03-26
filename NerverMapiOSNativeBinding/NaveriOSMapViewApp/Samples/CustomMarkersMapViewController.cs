using Foundation;
using System;
using UIKit;
using NMapViewerSDK.iOS;
using System.Diagnostics;
using CoreGraphics;
using System.Drawing;

namespace NaveriOSMapViewApp
{
    public partial class CustomMarkersMapViewController : UIViewController, INMapViewNPOIdataOverlayDelegate
    {
        #region private member fields area
        NMapView mapView;
        UIView calloutView;
        UILabel calloutLabel;
        UIImageView tipDistance1;
        UIImageView tipDistance2;
        #endregion
        public CustomMarkersMapViewController(IntPtr handle) : base(handle)
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

            InitCalloutView(ref calloutView);
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
            base.ViewWillDisappear(animated);
            ClearOverlays();
            mapView.ViewWillDisappear();
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

        [Export("onMapOverlay:viewForCalloutOverlayItem:calloutPosition:")]
        public UIView OnMapOverlay(NMapPOIdataOverlay poiDataOverlay, NMapPOIitem poiItem, CGPoint calloutPosition)
        {
            calloutPosition.X = (nfloat)(Math.Round(calloutView.Bounds.Size.Width / 2) + 1);
            calloutLabel.Text = poiItem.Title;

            return calloutView;
        }

        public UIImage OnMapOverlay(NMapPOIdataOverlay poiDataOverlay, NMapPOIitem poiItem, CGSize constraintSize, bool selected, UIImage imageForCalloutRightAccessory, CGPoint calloutPosition, CGRect calloutHitRect)
        {
            return null;
        }

        public CGPoint OnMapOverlayCalloutOffsetWithType(NMapPOIdataOverlay poiDataOverlay, int poiFlagType)
        {
            return new CGPoint(0.5, 0.5);
        }
        #endregion

        #region private Methods Area
        void ClearOverlays()
        {
            var mapOverlayManager = mapView.MapOverlayManager;
            mapOverlayManager.ClearOverlays();
        }

        void AddMarkers()
        {
            var mapOverlayManager = mapView.MapOverlayManager;
            var poiDataOverlay = mapOverlayManager.NewPOIdataOverlay();

            poiDataOverlay.InitPOIdata(3);
            poiDataOverlay.AddPOIitemAtLocation(NMapViewResource.NGeoPointMake(126.979, 37.567), "마커 1", UserPOIflagType.Default, 0, null);
            poiDataOverlay.AddPOIitemAtLocation(NMapViewResource.NGeoPointMake(126.974, 37.566), "마커 2", UserPOIflagType.Default, 1, null);
            poiDataOverlay.AddPOIitemAtLocation(NMapViewResource.NGeoPointMake(126.984, 37.565), "마커 3", UserPOIflagType.Default, 2, null);
            poiDataOverlay.EndPOIdata();

            // show all POI data
            poiDataOverlay.ShowAllPOIdata();

            poiDataOverlay.SelectPOIitemAtIndex(2, false, true);
        }

        void InitCalloutView(ref UIView view)
        {
            view = new UIView(new RectangleF(0, 0, 250, 32));
            view.AutoresizingMask = UIViewAutoresizing.FlexibleLeftMargin | UIViewAutoresizing.FlexibleTopMargin 
                                    | UIViewAutoresizing.FlexibleRightMargin | UIViewAutoresizing.FlexibleBottomMargin;
            view.BackgroundColor = UIColor.Clear;

            tipDistance1 = new UIImageView(new RectangleF(0, 0, 250, 28));
            tipDistance1.Image = UIImage.FromBundle("v4_tooltip_distance1");
            view.AddSubview(tipDistance1);

            tipDistance2 = new UIImageView(new RectangleF(121, 27, 8, 6));
            tipDistance2.AutoresizingMask = UIViewAutoresizing.FlexibleRightMargin | UIViewAutoresizing.FlexibleBottomMargin;
            tipDistance2.Image = UIImage.FromBundle("v4_tooltip_distance2");
            view.AddSubview(tipDistance2);

            calloutLabel = new UILabel(new RectangleF(6, 4, 238, 21));
            calloutLabel.AutoresizingMask = UIViewAutoresizing.FlexibleRightMargin | UIViewAutoresizing.FlexibleBottomMargin;
            calloutLabel.TextAlignment = UITextAlignment.Center;
            calloutLabel.Font = UIFont.SystemFontOfSize(14.0f);
            view.AddSubview(calloutLabel);

            //return calloutView;
        }
        #endregion
    }
}