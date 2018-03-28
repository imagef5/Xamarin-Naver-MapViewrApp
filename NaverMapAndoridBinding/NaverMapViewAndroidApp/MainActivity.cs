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
using Android.App;
using Android.Widget;
using Android.OS;
using Com.Nhn.Android.Maps;

namespace NaverMapViewAndroidApp
{
    [Activity(Label = "NaverMapViewAndroidApp", Icon = "@mipmap/icon")]
    public class MainActivity : NMapActivity //Activity
    {
        private NMapView mMapView;// 지도 화면 View

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            mMapView = new NMapView(this);
            SetContentView(mMapView);
            mMapView.SetClientId(AppSetting.CLIENT_ID); // 클라이언트 아이디 값 설정
            mMapView.Clickable = true;
            mMapView.Enabled = true;
            mMapView.Focusable = true; 
            mMapView.FocusableInTouchMode = true;
            mMapView.RequestFocus();
            //var controller = mMapView.MapController;
            //controller.SetZoomLevel(13);
        }
    }
}

