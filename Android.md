# Xamarin Project with Naver Map Android SDK 

바인딩 프로젝트 빌드시 오류가 발생하는데 Metadata.xml 파일 수정이나 Addition code를 통해 해결이 안되서 약간의 꼼수(?)가 필요함

(이부분 우아하게 해결하신 분 있으면 내용 공유 부탁드립니다)

## SDK API 문서 및 다운 로드
- API 문서 : [문서 참조및 API 신청](https://developers.naver.com/docs/map/android/) 
- SDK 다운로드 : [다운로드][0] - **naver-map-api-2.1.3.aar**

## 프로젝트 구성 
- Library : Xamarin.Android Binding Library 용 **naver-map-api-2.1.3.aar** Convert 프로젝트
- App : Xamarin Android 용 네이버 지도 Sample 

## Native Binding 프로젝트
1. [Android AAR 바인딩 참조][1] 
2. Native Binding 프로젝트 생성
- New Solution -> Android 라이브러리 -> 바인딩 라이브러리 생성
3. 바인딩 프로젝트 -> Jars 폴더 우측마우스 클릭 -> naver-map-api-2.1.3.aar 참조

![xamarin android aar](https://dongsasubstorage.blob.core.windows.net/images/uploads/android_binding_aar.png)
![xamarin android aar setting](https://dongsasubstorage.blob.core.windows.net/images/uploads/android_binding_aar_property.png)

4. [Java Binding Metadata][2]
- Transforms 폴더 -> Metadata.xml 파일 내용수정
  ```
  <?xml version="1.0" encoding="UTF-8"?>
  <metadata>
      <remove-node path="/api/package[@name='com.nhn.android.mapviewer.overlay']/interface[@name='NMapPOIdataOverlay.OnDragItemChangeListener']" />
      <attr path="/api/package[@name='com.nhn.android.maps']/class[@name='NMapView']/
              method[@name='setOnMapStateChangeListener' and count(parameter)=1 and parameter[1][@type='com.nhn.android.maps.NMapView.OnMapStateChangeSimpleListener']]"
              name="managedName">SetOnMapStateChangeSimpleListener</attr>
      <attr path="/api/package[@name='com.nhn.android.maps.nmapmodel']/class[@name='a']" name="obfuscated">false</attr>
      <attr path="/api/package[@name='com.nhn.android.maps.nmapmodel']/class[@name='b']" name="obfuscated">false</attr>
      <attr path="/api/package[@name='com.nhn.android.maps.nmapmodel']/class[@name='c']" name="obfuscated">false</attr>
      <attr path="/api/package[@name='com.nhn.android.maps.nmapmodel']/class[@name='d']" name="obfuscated">false</attr>
      <attr path="/api/package[@name='com.nhn.android.maps.overlay']/class[@name='a']" name="obfuscated">false</attr>
      <attr path="/api/package[@name='com.nhn.android.maps.overlay']/class[@name='b']" name="obfuscated">false</attr>
      <attr path="/api/package[@name='com.nhn.android.maps.overlay']/class[@name='c']" name="obfuscated">false</attr>
  </metadata>
  ```
  
    - Binding 목적에 따라서위 내용은 변경될 수 있음. 다른 내용으로 더 좋은 결과를 얻으신분들 내용 공유해요~~

5. 프로젝트 빌드 -> 다음과 같은 오류 내용을 확인 할 수 있음

![Build error](https://dongsasubstorage.blob.core.windows.net/images/uploads/naver_map_android_build_error.png)

- 오류 내용 Double Click -> 자동으로 생성된 해당 파일이 열림 (프로젝트폴더/obj/Debug/generated/src 폴더에 자동 생성된 파일 확인 가능)
- 여기서 약간의 꼼수(?) -> return type 에 global:: 키워드 추가
    
![Error](https://dongsasubstorage.blob.core.windows.net/images/uploads/naver_map_android_error_1.png) 
![Error](https://dongsasubstorage.blob.core.windows.net/images/uploads/naver_map_android_error_2.png)

 6. 프로젝트 Build ( **주의 : Rebuild 하는 경우 해당 파일을 다시 자동으로 generate 하기 때문에 동일한 오류가 발생함**)
 7. Andorid 용 App 프로젝트 생성 ->  Native Binding 프로젝트 참조 
 
 - 네이버 API 신청시 등록된 안드로이드 앱 패키지 이름 과 Client ID 를 동일하게 설정해 주어야 지도 서비스가 제대로 동작합니다.
 
    프로젝트 -> Properties 폴더 -> AndroidManifest.xml -> 패키지이름 

  ``` 
  코드 예제
  AppSetting.cs 파일에 Client_ID 수정
   public class AppSetting
    {
        public const string CLIENT_ID = "YOUR_CLIENT_ID"; <- Naver API에서 신청후 생성된 Client ID 를 변경해 줌!
    }
  
  기본 지도화면 보기 예:
  using Com.Nhn.Android.Maps;
  ...
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
                }
            }
  
  ```
  
## Screenshot
![스크린샷1](https://dongsasubstorage.blob.core.windows.net/images/uploads/naver_map_android_1.png)
![스크린샷2](https://dongsasubstorage.blob.core.windows.net/images/uploads/naver_map_android_2.png)
![스크린샷3](https://dongsasubstorage.blob.core.windows.net/images/uploads/naver_map_android_3.png)
![스크린샷4](https://dongsasubstorage.blob.core.windows.net/images/uploads/naver_map_android_4.png)
![스크린샷5](https://dongsasubstorage.blob.core.windows.net/images/uploads/naver_map_android_5.png)
![스크린샷6](https://dongsasubstorage.blob.core.windows.net/images/uploads/naver_map_android_6.png)

## Reference
* [Binding a Java Library][3]
* [Customizing Bindings][4]
* [Java Bindings Metadata][2]
* [Troubleshooting Bindings][5]

[0]:https://github.com/navermaps/maps.android
[1]:https://developer.xamarin.com/guides/android/advanced_topics/binding-a-java-library/binding-an-aar/
[2]:https://developer.xamarin.com/guides/android/advanced_topics/binding-a-java-library/customizing-bindings/java-bindings-metadata/
[3]:https://docs.microsoft.com/en-us/xamarin/android/platform/binding-java-library/
[4]:https://docs.microsoft.com/en-us/xamarin/android/platform/binding-java-library/customizing-bindings/
[5]:https://docs.microsoft.com/en-us/xamarin/android/platform/binding-java-library/troubleshooting-bindings
