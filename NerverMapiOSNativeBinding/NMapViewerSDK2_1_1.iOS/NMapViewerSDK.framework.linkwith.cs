using ObjCRuntime;

[assembly: LinkWith("NMapViewerSDK.framework",
                    //Frameworks = "Foundation CoreGraphics CoreLocation QuartzCore UIKit",
                    SmartLink = true,
                    ForceLoad = true,
                    LinkerFlags = "-ObjC -lxml2")]