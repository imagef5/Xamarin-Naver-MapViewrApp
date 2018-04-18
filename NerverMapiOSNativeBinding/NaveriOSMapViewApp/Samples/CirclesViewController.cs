/*
 * 소스 참조 : https://developers.naver.com/docs/map/ios/
 *           https://github.com/navermaps/maps.ios
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
using System.Diagnostics;
using CoreGraphics;
using NMapViewerSDK.iOS;
using UIKit;

namespace NaveriOSMapViewApp
{
    public partial class CirclesViewController : UIViewController, INMapViewNPOIdataOverlayDelegate
    {
        #region private member fields area
        NMapView mapView;
        #endregion

        public CirclesViewController() : base("CirclesViewController", null)
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
            AddCircles();
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

        #region private Methods Area
        void AddCircles()
        {
            ClearOverlays();

            var mapOverlayManager = mapView.MapOverlayManager;
            var pathDataOverlay = mapOverlayManager.NewPathDataOverlay(new NMapPathData());

            // add circle data  
            var circleData1 = new NMapCircleData(1);
            circleData1.InitCircleData();
            circleData1.AddCirclePoint(127.1085, 37.3675, 50.5f);

            //// set circle style
            var circleStyle1 = new NMapCircleStyle();
            circleStyle1.SetLineType(NMapPathLineType.Dash);
            circleData1.CircleStyle = circleStyle1;
            circleData1.EndCircleData();

            pathDataOverlay.AddCircleData(circleData1);

            // add circle data  
            var circleData2 = new NMapCircleData(1);
            circleData2.InitCircleData();
            circleData2.AddCirclePoint(127.1065, 37.3685, 27.0f);
            circleData2.EndCircleData();

            // set circle style
            var circleStyle2 = new NMapCircleStyle();
            circleStyle2.SetLineType(NMapPathLineType.Solid);
            circleStyle2.FillColor = UIColor.Green;
            circleData2.CircleStyle = circleStyle2;

            pathDataOverlay.AddCircleData(circleData2);
    
            // add circle data  
            var circleData3 = new NMapCircleData(1);
            circleData3.InitCircleData();
            circleData3.AddCirclePoint(127.1085, 37.3685, 35.0f);
            circleData3.EndCircleData();

            // set circle style
            var circleStyle3 = new NMapCircleStyle();
            circleStyle3.SetLineType(NMapPathLineType.Solid);
            circleStyle3.FillColor = UIColor.Gray;
            circleData3.CircleStyle = circleStyle3;

            pathDataOverlay.AddCircleData(circleData3);
            // show all POI data
            pathDataOverlay.ShowAllPathData();
        }

        void ClearOverlays()
        {
            var mapOverlayManager = mapView.MapOverlayManager;
            mapOverlayManager.ClearOverlays();
        }
        #endregion
    }
}

