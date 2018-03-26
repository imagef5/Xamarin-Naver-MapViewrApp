using CoreGraphics;
using NMapViewerSDK.iOS;
using System;
using System.Diagnostics;
using UIKit;

namespace NaveriOSMapViewApp
{
    public partial class RotationViewController : UIViewController, INMapViewNPOIdataOverlayDelegate
    {
        #region private member fields area
        NMapView mapView;
        float viewAngle ;
        bool hasInit;
        #endregion

        public RotationViewController(IntPtr handle) : base(handle)
        {
        }

        #region override methods area
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            mapView = new NMapView()
            {
                Frame = View.Frame,
            };
            NavigationController.NavigationBar.Translucent = false;
            // set the delegate for map view
            mapView.WeakDelegate = this;

            // set the application api key for Open MapViewer Library
            //[self.mapView setClientId:@"YOUR CLIENT ID"];
            mapView.SetClientId(AppSetting.CLIENT_ID);
            mapView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

            View.InsertSubview(mapView,0);
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

		public override void ViewWillTransitionToSize(CGSize toSize, IUIViewControllerTransitionCoordinator coordinator)
		{
            if (toSize.Width != View.Frame.Size.Width)
            {
                if (mapView.AutoRotateEnabled && hasInit)
                {
                    viewAngle = (float)mapView.RotateAngle();
                    mapView.SetAutoRotateEnabled(false, false);
                    coordinator.AnimateAlongsideTransition
                    (
                        (context) =>
                        {
                            if (hasInit)
                            {
                                mapView.SetAutoRotateEnabled(true, true);
                                mapView.SetRotateAngle(viewAngle);
                            }
                        },
                        null
                    );
                }
            }
		}
		#endregion

		#region Implement INMapViewNPOIdataOverlayDelegate
		public void OnMapView(NMapView mapView, NMapError error)
        {
            //base.OnMapView(mapView, error);
            if (error == null)
            {
                var location = new NGeoPoint
                {
                    Longitude = 126.978391,
                    Latitude = 37.5666091,
                };
                mapView.SetMapCenter(location, 11);
                mapView.SetMapEnlarged(true, true);
                mapView.SetMapViewMode(NMapViewMode.Vector);
                hasInit = true;
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

        #region button event area
        partial void leftButtonClicked(UIButton sender)
        {
            if(!mapView.AutoRotateEnabled)
            {
                mapView.SetAutoRotateEnabled(true, true);
            }
            viewAngle += 45.0f;
            mapView.SetRotateAngle(viewAngle);
        }

        partial void rightButtonClicked(UIButton sender)
        {
            if (!mapView.AutoRotateEnabled)
            {
                mapView.SetAutoRotateEnabled(true, true);
            }
            viewAngle -= 45.0f;
            mapView.SetRotateAngle(viewAngle);
        }
        #endregion
    }
}