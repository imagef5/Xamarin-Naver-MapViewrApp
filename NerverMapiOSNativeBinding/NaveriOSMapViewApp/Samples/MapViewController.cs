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

        public CGPoint OnMapOverlayWithType(NMapPOIdataOverlay poiDataOverlay, int poiFlagType)
        {
            return NMapViewResource.AnchorPoint(poiFlagType);
        }

        public UIImage OnMapOverlayForCalloutOverlayItem(NMapPOIdataOverlay poiDataOverlay, NMapPOIitem poiItem, CGSize constraintSize, bool selected, UIImage imageForCalloutRightAccessory, CGPoint calloutPosition, CGRect calloutHitRect)
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
            UIAlertAction alphaAction = UIAlertAction.Create
                                            (
                                                $"Alpha layer is {mapView.MapViewAlphaLayerMode} ? On : Off",
                                                UIAlertActionStyle.Default,
                                                (action) =>
                                                {
                                                    mapView.MapViewAlphaLayerMode = !mapView.MapViewAlphaLayerMode;
                                                }
                                            );
            alertController.AddAction(trafficAction);
            alertController.AddAction(bicycleAction);
            alertController.AddAction(alphaAction);
            alertController.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, null));

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