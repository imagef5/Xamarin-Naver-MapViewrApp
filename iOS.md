# Xamarin Project with Naver Map iOS Framework

## SDK API 문서 및 다운 로드
- API 문서 : [문서 참조및 API 신청](https://developers.naver.com/docs/map/ios/) 
- SDK 다운로드 : [최신(v2.1.3)][0] , [v2.1.1][1] - **NMapViewerSDK.framework**
> iOS용 최신버전SDK(v2.1.3)의 경우 Native Binding을 통하여 App 을 생성할 경우 런타임시 dll 로딩이 안되는 형상이 발생하여<br/>
> 부득이하게 v2.1.1 버전으로 작성함.(혹시 이부분 해결하신분 계시면 내용 공유 부탁드립니다.~~)

## 프로젝트 구성 
- Library : Xamarin.iOS Binding Library 용 **NMapViewerSDK.framework** Convert 프로젝트
- App : Xamarin iOS 용 네이버 지도 Sample 

## Native Binding 프로젝트
1. [sharpie][3] 를 이용하여 ApiDefinitions.cs 및 StructsAndEnums.cs 파일 생성하기 (on MacOS)
  (sharpie 사용법은 링크를 클릭해보시기 바랍니다. 여러 옵션이 있으나 NMapViewerSDK.framework 변환시 가장 무난하게 변경된 옵션만 표시하도록 하겠습니다.)
  ```
  sharpie bind -output TempBinding -namespace NMapViewerSDK -framework NMapViewerSDK.framework -sdk iphoneos10.2 -scope NMapViewerSDK.framework/Versions/A/Headers NMapViewerSDK.framework/Versions/A/Headers/*.h -c 
  ```
 - (sharpie 를 실행하면 다음과 같은 화면이 보이더라도 당황화지 마세요!!)
 
  ![sharpie result](https://github.com/imagef5/Xamarin-Naver-MapViewrApp/blob/master/screenshot/sharpie_result_screen.png)
 
2. Native Binding 프로젝트 생성
- New Solution -> iOS 라이브러리 -> 바인딩 라이브러리 생성
3. 네이티브 참조 -> 오른쪽 마우스 클릭 -> NMapViewerSDK.framework 참조

![xamarin ios framework](https://github.com/imagef5/Xamarin-Naver-MapViewrApp/blob/master/screenshot/binging_project.png)

4. sharpie 로 생성하 ApiDefinitions.cs , StructsAndEnums.cs 파일 내용 복사 또는 Drag and Drop로 프로젝트에 파일 추가
- sharpie로 생성된 파일은 최종 결과 파일이 아니고, [Binging objective-c libraries][5] 등을 참조하여 내용에 맞게 수정해 주어야 함

5. NMapViewerSDK.framework.linkwith.cs(파일명은 상관없음) 파일 추가.<br/> 참조 : [Binging objective-c libraries][5] , [ObjCRuntime.LinkWithAttribute Class][4]

  ```
  using ObjCRuntime;

  [assembly: LinkWith("NMapViewerSDK.framework",
                    //Frameworks = "Foundation CoreGraphics CoreLocation QuartzCore UIKit",
                    SmartLink = true,
                    ForceLoad = true,
                    LinkerFlags = "-ObjC -lxml2")]
  ```
     
 6. 경우에 따라 추가코드 생성 (예 : Extension.cs)
 7. iOS 용 App 프로젝트 생성 ->  Native Binding 프로젝트 참조 
  ``` 
  코드 예제
  AppSetting.cs 파일에 Client_ID 수정
   public class AppSetting
    {
        public const string CLIENT_ID = "YOUR_CLIENT_ID"; <- Naver API에서 신청후 생성된 Client ID 를 변경해 줌!
    }
  
  using NMapViewerSDK.iOS;
  ...
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
  
  ```

## Reference
* [Walkthrough: Binding an iOS Objective-C Library][2]
* [ObjCRuntime.LinkWithAttribute Class][4]
* [Binding Objective-C Libraries][5]
* [Binding Types Reference Guide][6]
* [Truobleshooting][7]

[0]:https://github.com/navermaps/maps.ios
[1]:https://github.com/navermaps/maps.ios/releases
[2]:https://developer.xamarin.com/guides/ios/advanced_topics/binding_objective-c/walkthrough/
[3]:https://developer.xamarin.com/guides/cross-platform/macios/binding/objective-sharpie/getting-started/
[4]:https://developer.xamarin.com/api/type/ObjCRuntime.LinkWithAttribute/
[5]:https://developer.xamarin.com/guides/cross-platform/macios/binding/objective-c-libraries/
[6]:https://developer.xamarin.com/guides/cross-platform/macios/binding/binding-types-reference/
[7]:https://docs.microsoft.com/en-us/xamarin/cross-platform/macios/binding/troubleshooting
