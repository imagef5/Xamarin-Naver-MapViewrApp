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

namespace NaveriOSMapViewApp
{
    public partial class PolylinesViewController : UIViewController, INMapViewNPOIdataOverlayDelegate
    {
        #region private member fields area
        NMapView mapView;
        #endregion

        public PolylinesViewController() : base("PolylinesViewController", null)
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
            AddPolylines();
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
        void AddPolylines()
        {
            ClearOverlays();

            var mapOverlayManager = mapView.MapOverlayManager;
            // set path data points
            var pathData1 = new NMapPathData(9);

            pathData1.InitPathData();
            pathData1.AddPathPoint(127.108099, 37.366034, NMapPathLineType.Solid);
            pathData1.AddPathPoint(127.108088, 37.366043, NMapPathLineType.None);
            pathData1.AddPathPoint(127.108079, 37.365619, NMapPathLineType.None);
            pathData1.AddPathPoint(127.107458, 37.365608, NMapPathLineType.None);
            pathData1.AddPathPoint(127.107232, 37.365608, NMapPathLineType.None);
            pathData1.AddPathPoint(127.106904, 37.365624, NMapPathLineType.None);
            pathData1.AddPathPoint(127.105933, 37.365621, NMapPathLineType.Dash);
            pathData1.AddPathPoint(127.105929, 37.366378, NMapPathLineType.None);
            pathData1.AddPathPoint(127.106279, 37.366380, NMapPathLineType.None);
            pathData1.EndPathData();

            // create path data overlay
            var pathDataOverlay = mapOverlayManager.NewPathDataOverlay(pathData1);

            if (pathDataOverlay != null)
            {
                var pathData2 = new NMapPathData(7);

                pathData2.InitPathData();
                pathData2.AddPathPoint(127.108099, 37.367034, NMapPathLineType.Solid);
                pathData2.AddPathPoint(127.108088, 37.367043, NMapPathLineType.None);
                pathData2.AddPathPoint(127.108079, 37.366619, NMapPathLineType.None);
                pathData2.AddPathPoint(127.107458, 37.366608, NMapPathLineType.None);
                pathData2.AddPathPoint(127.107232, 37.366608, NMapPathLineType.None);
                pathData2.AddPathPoint(127.106904, 37.366624, NMapPathLineType.Dash);
                pathData2.AddPathPoint(127.106904, 37.367721, NMapPathLineType.None);
                pathData2.EndPathData();

                //NMapPathLineStyle* style = [[NMapPathLineStyle alloc] init];
                //[style setPathDataType:NMapPathDataTypePolyline];
                //[style setLineColor:[UIColor greenColor]];
                //[pathData2 setPathLineStyle:style];

                //[pathDataOverlay addPathData:pathData2];
                var style = new NMapPathLineStyle();
                style.PathDataType = NMapPathDataType.Line;
                style.LineColor = UIColor.Green;
                pathData2.PathLineStyle = style;

                pathDataOverlay.AddPathData(pathData2);
            }
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

