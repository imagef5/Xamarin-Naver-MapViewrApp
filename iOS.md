# Xamarin Project with Naver Map iOS Framework

## SDK API 문서 및 다운 로드
- API 문서 : [문서 참조및 API 신청](https://developers.naver.com/docs/map/ios/) 
- SDK 다운로드 : [최신(v2.1.3)][0] , [v2.1.1][1] - **NMapViewerSDK.framework**
> 2017.3.30 : v2.1.3 버전으로 변경<br/>
> ~~iOS용 최신버전SDK(v2.1.3)의 경우 Native Binding을 통하여 App 을 생성할 경우 런타임시 dll 로딩이 안되는 형상이 발생하여<br/>
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
 - (sharpie 를 실행하면 다음과 같은 화면이 보이더라도 당황화지 마세요!!)<br/>
 
    - ApiDefinitions.cs , StructsAndEnums.cs 파일이 생성확인
      
    - Binding Analysis 내용 확인 <- 코드 수정에 대한 가이드
 
  ![sharpie result](https://dongsasubstorage.blob.core.windows.net/images/uploads/sharpie_result_screen.png)
 
2. Native Binding 프로젝트 생성
- New Solution -> iOS 라이브러리 -> 바인딩 라이브러리 생성
3. 네이티브 참조 -> 오른쪽 마우스 클릭 -> NMapViewerSDK.framework, ApiGatewayMac.framework 참조

![xamarin ios framework](https://github.com/imagef5/Xamarin-Naver-MapViewrApp/blob/master/screenshot/binging_project.png)

4. sharpie 로 생성하 ApiDefinitions.cs , StructsAndEnums.cs 파일 내용 복사 또는 Drag and Drop로 프로젝트에 파일 추가
- sharpie로 생성된 파일은 최종 결과 파일이 아니고, [Binging objective-c libraries][5] 등을 참조하여 내용에 맞게 수정해 주어야 함

5. NMapViewerSDK.framework.linkwith.cs(파일명은 상관없음) 파일 추가.<br/> 참조 : [Binging objective-c libraries][5] , [ObjCRuntime.LinkWithAttribute Class][4] 


  ```
using ObjCRuntime;

[assembly: LinkWith("NMapViewerSDK.framework",
                    Frameworks = "ApiGatewayMac",
                    ForceLoad = true,
                    LinkerFlags = "-ObjC -lxml2")]

[assembly: LinkWith("ApiGatewayMac.framework",
                    SmartLink = true,
                    ForceLoad = true,
                    LinkerFlags = "-ObjC -lxml2")]
  ```
     
 6. 경우에 따라 추가코드 생성 (예 : Extension.cs)
 7. iOS 용 App 프로젝트 생성 ->  Native Binding 프로젝트 참조 
 
 - 네이버 API 신청시 등록된 iOS Bundle ID 와 Client ID 를 동일하게 설정해 주어야 지도 서비스가 제대로 동작합니다.
 
 info.plist -> Bundle ID
 
 ![번들아이디 등록](https://dongsasubstorage.blob.core.windows.net/images/uploads/bundle_id.png)
 
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
  
## Screenshot
![스크린샷1](https://dongsasubstorage.blob.core.windows.net/images/uploads/naver_map_ios_1.png)
![스크린샷2](https://dongsasubstorage.blob.core.windows.net/images/uploads/naver_map_ios_2.png)
![스크린샷3](https://dongsasubstorage.blob.core.windows.net/images/uploads/naver_map_ios_3.png)
![스크린샷4](https://dongsasubstorage.blob.core.windows.net/images/uploads/naver_map_ios_4.png)
![스크린샷5](https://dongsasubstorage.blob.core.windows.net/images/uploads/naver_map_ios_5.png)

- 말풍선의 경우 화면 좌측으로 붙어서 표시되는 Bug 가 있음(해결하신분 공유부탁드려요~~)

![오류](https://dongsasubstorage.blob.core.windows.net/images/uploads/naver_map_ios_error.png)

- ~~MapView 내의 CGRect 객체를 반환하는 값들에 대해 동일한 오류 증상이 보임(변환과정의 오류인지 , Mono 상의 오류인지 잘 모르겠네요. 이부분도 해결해 하신분 공유 Please)~~
- unmanaged struct 를 반환하는 Property 및 Method 의 경우 위와 같은 오류가 발생할 수 있음.<br/>
      - 자동으로 generated 된 Messaging.cs 파일에서 호출하는 함수외에 별도의 추가 Messagins.cs 파일을 만들어 줌<br/>
      - 참조 : [네이티브 라이브러리와의 상호 운영성:모노](http://www.mono-project.com/docs/advanced/pinvoke)
```
자동 gendrated Messaging.cs 파일 위치 -> [native bindng 프로젝트폴더]/obj/ios/ObjCRuntime/Messaging.cs

예 :
CGRect 를 반환하는 Method 를 호출하는 경우 다음과 같은 Method를 호출하게 됨.
이때 CGRect 객체가 struct 타입이기 때문에 위 그림과 같은 오류가 발생

[DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
public extern static CGRect CGRect_objc_msgSend(IntPtr receiver, IntPtr selector);

수정하기
1. Messaging.cs 파일 프로젝트에 추가

namespace NMapViewerSDK.iOS
{
    internal static class Messaging
    {
        const string LIBOBJC_DYLIB = "/usr/lib/libobjc.dylib";

        ....

                  [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
Attribute 추가 ->  [return:MarshalAs(UnmanagedType.Struct)]
                  public extern static CGRect CGRect_objc_msgSend(IntPtr receiver, IntPtr selector);

        ....
    }
}

2. Extensions.cs 파일 추가

    public partial class NMapViewQuartz
    {
        public virtual CGRect ViewFrame
        {
            [Export("viewFrame")]
            get
            {
                CGRect ret;
                if (IsDirectBinding)
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSend(this.Handle, Selector.GetHandle("viewFrame"));  <- 위 Messaging.cs 파일에 추가하 Method 를 호출
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("viewFrame"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("viewFrame"));
                    }
                    else
                    {
                        global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("viewFrame"));
                    }
                }
                else
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("viewFrame"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("viewFrame"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("viewFrame"));
                    }
                    else
                    {
                        global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("viewFrame"));
                    }
                }
                return ret;
            }

        }

        ....
    }

3. ApiDefinitions.cs 에 정의되어 있는 ViewFrame Property 를 주석 처리

    [BaseType(typeof(UIView))]
    interface NMapViewQuartz
    {
      ....
      
        //[Export("viewFrame")]
        //CGRect ViewFrame { get; }

      ....
    }

```
![struct반환](https://dongsasubstorage.blob.core.windows.net/images/uploads/naver_map_ios_struct_success.png)
- 제대로된 값을 반환함

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
