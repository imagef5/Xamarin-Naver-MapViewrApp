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
using System.Diagnostics;
using CoreGraphics;
using Foundation;
using NMapViewerSDK.iOS;
using UIKit;

namespace NaveriOSMapViewApp
{
    public partial class ReverseGeocoderViewController : UIViewController, INMapViewNPOIdataOverlayDelegate, IMMapReverseGeocoderDelegate
    {
        #region private fields member area
        NMapView mapView;
        //private NMapPOIdataOverlay mapPOIdataOverlay;
        #endregion

        public ReverseGeocoderViewController() : base("ReverseGeocoderViewController", null)
        {
        }

        #region override methods Area
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.
            // Perform any additional setup after loading the view, typically from a nib.
            mapView = new NMapView(View.Frame);
            NavigationController.NavigationBar.Translucent = false;
            // set the delegate for map view
            mapView.WeakDelegate = this;

            // set the application api key for Open MapViewer Library
            //[self.mapView setClientId:@"YOUR CLIENT ID"];
            mapView.SetClientId(AppSetting.CLIENT_ID);
            mapView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;

            // set delegate to use reverse geocoder API
            mapView.WeakReverseGeocoderDelegate = this;

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
            //[self.mapView viewDidAppear];
            //[self requestAddressByCoordination:NGeoPointMake(126.978371, 37.5666091)];
            mapView.ViewDidAppear();
            var location = new NGeoPoint
            {
                Longitude = 126.978391,
                Latitude = 37.5666091,
            };
            RequestAddressByCoordination(location);
            base.ViewDidAppear(animated);
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

        public UIImage OnMapOverlay(NMapPOIdataOverlay poiDataOverlay, NMapPOIitem poiItem, CGSize constraintSize, bool selected, UIImage imageForCalloutRightAccessory, CGPoint calloutPosition, CGRect calloutHitRect)
        {
            return null;
        }

        public CGPoint OnMapOverlayCalloutOffsetWithType(NMapPOIdataOverlay poiDataOverlay, int poiFlagType)
        {
            return CGPoint.Empty;
        }

        public void OnMapViewTouchesEnded(NMapView mapView, NSSet touches, UIEvent @event)
        {
            UITouch touch = touches.AnyObject as UITouch;
            if (touch != null)
            {
                var scrPoint = touch.LocationInView(mapView);
                RequestAddressByCoordination(mapView.FromPoint(scrPoint));
            }
        }
        #endregion

        #region Implement IMMapReverseGeocoderDelegate
        public void DidFindPlacemark(NGeoPoint location, NMapPlacemark placemark)
        {
            Debug.Write($"Location({location.Longitude},{location.Latitude}) DidFindPlacemark : {placemark.Address}");
            Title = placemark.Address;
            var alert = UIAlertController.Create("ReverseGeocoder", placemark.Address, UIAlertControllerStyle.Alert);
            var ok = UIAlertAction.Create("OK", UIAlertActionStyle.Default, null);
            alert.AddAction(ok);
            this.PresentViewController(alert, true, null);
        }

        public void DidFailWithError(NGeoPoint location, NMapError error)
        {
            Debug.Write($"Location({location.Longitude},{location.Latitude}) didFailWithError : {error.Description}");
        }
        #endregion

        #region private Methods Area
        void RequestAddressByCoordination(NGeoPoint location)
        {
            mapView.FindPlacemarkAtLocation(location);
            SetMarker(location);
        }

        void SetMarker(NGeoPoint location)
        {
            ClearOverlays();
            var mapOverlayManager = mapView.MapOverlayManager;
            var poiDataOverlay = mapOverlayManager.NewPOIdataOverlay();
            poiDataOverlay.InitPOIdata(1);
            var item = poiDataOverlay.AddPOIitemAtLocation(location, "마커 1", UserPOIflagType.Default, null);
            poiDataOverlay.EndPOIdata();
        }

        void ClearOverlays()
        {
            var mapOverlayManager = mapView.MapOverlayManager;
            mapOverlayManager.ClearOverlays();
        }
        #endregion
    }
}

