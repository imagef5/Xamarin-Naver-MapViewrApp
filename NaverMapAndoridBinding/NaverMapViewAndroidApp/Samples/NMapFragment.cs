/*
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
using Android.OS;
using Android.Views;
using Com.Nhn.Android.Maps;
using Java.Lang;

/*
 * 소스 참조 : https://developers.naver.com/docs/map/android/
 *           https://github.com/navermaps/maps.android
 * 네이버 지도에 서비스 저작권에 대한 자세한 내용은 Naver Developer 페이지를 참조하시기 바랍니다.
 * (https://github.com/navermaps/maps.android#license)
 * NMapFragment 클래스는 NMapActivity를 상속하지 않고 NMapView만 사용하고자 하는 경우에 NMapContext를 이용한 예제임.
 * NMapView 사용시 필요한 초기화 및 리스너 등록은 NMapActivity 사용시와 동일함.
 */
namespace NaverMapViewAndroidApp.Samples
{
    public class NMapFragment : Fragment
    {
        #region private member fields area
        NMapContext mMapContext;
        #endregion

        #region override methods area
        /* Fragment 라이프사이클에 따라서 NMapContext의 해당 API를 호출함 */

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
            mMapContext = new NMapContext(base.Activity);

            mMapContext.OnCreate();
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            throw new IllegalArgumentException("onCreateView should be implemented in the subclass of NMapFragment.");
        }


        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);

            // Fragment에 포함된 NMapView 객체 찾기
            NMapView mapView = FindMapView(base.View);
            if (mapView == null)
            {
                throw new IllegalArgumentException("NMapFragment dose not have an instance of NMapView.");
            }

            // NMapActivity를 상속하지 않는 경우에는 NMapView 객체 생성후 반드시 setupMapView()를 호출해야함.
            mMapContext.SetupMapView(mapView);
        }

        public override void OnStart()
        {
            base.OnStart();

            mMapContext.OnStart();
        }

        public override void OnResume()
        {
            base.OnResume();

            mMapContext.OnResume();
        }

        public override void OnPause()
        {
            base.OnPause();

            mMapContext.OnPause();
        }

        public override void OnStop()
        {

            mMapContext.OnStop();

            base.OnStop();
        }

        public override void OnDestroyView()
        {
            base.OnDestroyView();
        }

        public override void OnDestroy()
        {
            mMapContext.OnDestroy();

            base.OnDestroy();
        }
        #endregion

        #region private methods area
        /**
         * Fragment에 포함된 NMapView 객체를 반환함
         */
        private NMapView FindMapView(View v)
        {
            if (v is ViewGroup vg) 
            {
                if (vg is NMapView vm) 
                {
                    return vm;
                }

                for (int i = 0; i < vg.ChildCount; i++)
                {
                    View child = vg.GetChildAt(i);
                    if (!(child is ViewGroup))
                    {
                        continue;
                    }
                
                    NMapView mapView = FindMapView(child);
                    if (mapView != null)
                    {
                        return mapView;
                    }
                }
            }
            return null;
        }
        #endregion
    }
}
