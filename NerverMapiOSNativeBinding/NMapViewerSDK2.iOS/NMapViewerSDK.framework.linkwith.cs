using ObjCRuntime;

[assembly: LinkWith("NMapViewerSDK.framework",
                    Frameworks = "ApiGatewayMac",
                    ForceLoad = true,
                    LinkerFlags = "-ObjC -lxml2")]

[assembly: LinkWith("ApiGatewayMac.framework",
                    SmartLink = true,
                    ForceLoad = true,
                    LinkerFlags = "-ObjC -lxml2")]