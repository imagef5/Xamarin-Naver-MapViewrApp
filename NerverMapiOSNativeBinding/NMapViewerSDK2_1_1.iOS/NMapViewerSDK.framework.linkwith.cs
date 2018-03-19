using ObjCRuntime;

[assembly: LinkWith("NMapViewerSDK.framework",
                    //Frameworks = "ApiGatewayMac",
                    ForceLoad = true,
                    LinkerFlags = "-ObjC -lxml2")]