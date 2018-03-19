using Android.App;
using Android.Widget;
using Android.OS;
using Com.Nhn.Android.Maps;

namespace NaverMapViewAndroidApp
{
    [Activity(Label = "NaverMapViewAndroidApp", MainLauncher = true, Icon = "@mipmap/icon")]
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

