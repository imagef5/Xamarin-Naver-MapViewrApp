using System;
using CoreAnimation;
using CoreGraphics;
using CoreLocation;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace NMapViewerSDK.iOS
{
    // @interface NMapError : NSObject
    [BaseType(typeof(NSObject))]
    interface NMapError
    {
        // @property (assign, nonatomic) int code;
        [Export("code")]
        int Code { get; set; }

        // @property (retain, nonatomic) NSString * message;
        [Export("message", ArgumentSemantic.Retain)]
        string Message { get; set; }

        // -(id)initWithCode:(int)code message:(NSString *)message;
        [Export("initWithCode:message:")]
        IntPtr Constructor(int code, string message);
    }

    // @interface NMapPlacemark : NSObject
    [BaseType(typeof(NSObject))]
    interface NMapPlacemark
    {
        // @property (readonly, nonatomic) NGeoPoint location;
        [Export("location")]
        NGeoPoint Location { get; }

        // @property (readonly, nonatomic) NSString * address;
        [Export("address")]
        string Address { get; }

        // @property (readonly, nonatomic) NSString * doName;
        [Export("doName")]
        string DoName { get; }

        // @property (readonly, nonatomic) NSString * siName;
        [Export("siName")]
        string SiName { get; }

        // @property (readonly, nonatomic) NSString * dongName;
        [Export("dongName")]
        string DongName { get; }

        // -(id)initWithLocation:(NGeoPoint)location addressDictionary:(NSDictionary *)addressDictionary;
        [Export("initWithLocation:addressDictionary:")]
        IntPtr Constructor(NGeoPoint location, NSDictionary addressDictionary);
    }

    // @protocol MMapReverseGeocoderDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MMapReverseGeocoderDelegate
    {
        // @required -(void)location:(NGeoPoint)location didFindPlacemark:(NMapPlacemark *)placemark;
        [Abstract]
        [Export("location:didFindPlacemark:"), EventArgs("DidFindPlacemark")]
        void DidFindPlacemark(NGeoPoint location, NMapPlacemark placemark);

        // @required -(void)location:(NGeoPoint)location didFailWithError:(NMapError *)error;
        [Abstract]
        [Export("location:didFailWithError:"), EventArgs("DidFalWithError")]
        void DidFailWithError(NGeoPoint location, NMapError error);
    }

    //Empty Interface
    interface IMMapReverseGeocoderDelegate { }

    // @interface NMapPathLineStyle : NSObject
    [BaseType(typeof(NSObject))]
    interface NMapPathLineStyle
    {
        // @property (assign, nonatomic) float lineWidth;
        [Export("lineWidth")]
        float LineWidth { get; set; }

        // @property (retain, nonatomic) int * lineColor;
        [Export("lineColor", ArgumentSemantic.Retain)]
        UIColor LineColor { get; set; }

        // @property (retain, nonatomic) int * fillColor;
        [Export("fillColor", ArgumentSemantic.Retain)]
        UIColor FillColor { get; set; }

        // @property (assign, nonatomic) NMapPathDataType pathDataType;
        [Export("pathDataType", ArgumentSemantic.Assign)]
        NMapPathDataType PathDataType { get; set; }

        // -(void)setLineDash:(id)phase lengths:(const int)lengths count:(size_t)count;
        [Export("setLineDash:lengths:count:")]
        void SetLineDash(NSObject phase, int lengths, nuint count);

        // -(void)setLineWidth:(float)width;
        //[Export("setLineWidth:")]
        //void SetLineWidth(float width);

        // -(void)setLineColorWithRed:(float)red green:(float)green blue:(float)blue alpha:(float)alpha;
        [Export("setLineColorWithRed:green:blue:alpha:")]
        void SetLineColorWithRed(float red, float green, float blue, float alpha);

        // -(void)setFillColorWithRed:(float)red green:(float)green blue:(float)blue alpha:(float)alpha;
        [Export("setFillColorWithRed:green:blue:alpha:")]
        void SetFillColorWithRed(float red, float green, float blue, float alpha);

        // -(void)setLineStyleInContext:(id)context;
        [Export("setLineStyleInContext:")]
        void SetLineStyleInContext(NSObject context);

        // -(void)setLineTypeInContext:(id)context lineType:(NMapPathLineType)lineType;
        [Export("setLineTypeInContext:lineType:")]
        void SetLineTypeInContext(NSObject context, NMapPathLineType lineType);
    }

    // @interface NMapCircleStyle : NSObject
    [BaseType(typeof(NSObject))]
    interface NMapCircleStyle
    {
        // @property (assign, nonatomic) float strokeWidth;
        [Export("strokeWidth")]
        float StrokeWidth { get; set; }

        // @property (retain, nonatomic) int * strokeColor;
        [Export("strokeColor", ArgumentSemantic.Retain)]
        UIColor StrokeColor { get; set; }

        // @property (retain, nonatomic) int * fillColor;
        [Export("fillColor", ArgumentSemantic.Retain)]
        UIColor FillColor { get; set; }

        // -(id)initWithImage:(id)circleImage;
        [Export("initWithImage:")]
        IntPtr Constructor(NSObject circleImage);

        // -(void)setLineType:(NMapPathLineType)lineType;
        [Export("setLineType:")]
        void SetLineType(NMapPathLineType lineType);

        // -(void)setLineDash:(id)phase lengths:(const int)lengths count:(size_t)count;
        [Export("setLineDash:lengths:count:")]
        void SetLineDash(NSObject phase, int lengths, nuint count);

        // -(void)setStrokeWidth:(float)width;
        //[Export("setStrokeWidth:")]
        //void SetStrokeWidth(float width);

        // -(void)setStrokeColorWithRed:(float)red green:(float)green blue:(float)blue alpha:(float)alpha;
        [Export("setStrokeColorWithRed:green:blue:alpha:")]
        void SetStrokeColorWithRed(float red, float green, float blue, float alpha);

        // -(void)setFillColorWithRed:(float)red green:(float)green blue:(float)blue alpha:(float)alpha;
        [Export("setFillColorWithRed:green:blue:alpha:")]
        void SetFillColorWithRed(float red, float green, float blue, float alpha);

        // -(BOOL)hasCircleImage;
        [Export("hasCircleImage")]
        bool HasCircleImage { get; }

        // -(void)drawCircleInContext:(id)context center:(id)center radius:(float)radius;
        [Export("drawCircleInContext:center:radius:")]
        void DrawCircleInContext(NSObject context, NSObject center, float radius);
    }

    // @interface NMapCirclePoint : NSObject
    [BaseType(typeof(NSObject))]
    interface NMapCirclePoint
    {
        // @property (retain, nonatomic) NMapCircleStyle * circleStyle;
        [Export("circleStyle", ArgumentSemantic.Retain)]
        NMapCircleStyle CircleStyle { get; set; }

        // -(id)initWithPointInUtmk:(NPoint)utmk radius:(float)radius;
        [Export("initWithPointInUtmk:radius:")]
        IntPtr Constructor(NPoint utmk, float radius);

        // -(id)initWithPoint:(NGeoPoint)centerPoint radius:(float)radius;
        [Export("initWithPoint:radius:")]
        IntPtr Constructor(NGeoPoint centerPoint, float radius);

        // -(NGeoPoint)centerPoint;
        [Export("centerPoint")]
        NGeoPoint CenterPoint { get; }

        // -(NPoint)centerPointInUtmk;
        [Export("centerPointInUtmk")]
        NPoint CenterPointInUtmk { get; }

        // -(float)radius;
        [Export("radius")]
        float Radius { get; }

        // -(float)radius:(NMapView *)mapView;
        [Export("radius:")]
        float RadiusInPoint(NMapView mapView);

        // -(float)radiusInUtmk;
        [Export("radiusInUtmk")]
        float RadiusInUtmk { get; }

        // -(id)screenPosition:(NMapView *)mapView viewPortOrigin:(NGRect *)viewPortOrigin;
        [Export("screenPosition:viewPortOrigin:")]
        //unsafe NSObject ScreenPosition(NMapView mapView, NGRect viewPortOrigin);
        CGPoint ScreenPosition(NMapView mapView, NGRect viewPortOrigin);

        // -(void)layoutChanged;
        [Export("layoutChanged")]
        void LayoutChanged();
    }

    // @interface NMapCircleData : NSObject
    [BaseType(typeof(NSObject))]
    interface NMapCircleData
    {
        // @property (retain, nonatomic) NSObject * object;
        [Export("object", ArgumentSemantic.Retain)]
        NSObject Object { get; set; }

        // @property (assign, nonatomic) BOOL hidden;
        [Export("hidden")]
        bool Hidden { get; set; }

        // @property (getter = isRendered, assign, nonatomic) BOOL rendered;
        [Export("rendered")]
        bool Rendered { [Bind("isRendered")] get; set; }

        // @property (readonly, nonatomic) NGRect viewPortOrigin;
        [Export("viewPortOrigin")]
        NGRect ViewPortOrigin { get; }

        // @property (retain, nonatomic) NMapCircleStyle * circleStyle;
        [Export("circleStyle", ArgumentSemantic.Retain)]
        NMapCircleStyle CircleStyle { get; set; }

        // @property (assign, nonatomic) NRect boundsInUtmk;
        [Export("boundsInUtmk", ArgumentSemantic.Assign)]
        NRect BoundsInUtmk { get; set; }

        // -(BOOL)isValidBounds;
        [Export("isValidBounds")]
        bool IsValidBounds { get; }

        // -(id)initWithCapacity:(int)capacity;
        [Export("initWithCapacity:")]
        IntPtr Constructor(int capacity);

        // -(int)count;
        [Export("count")]
        int Count { get; }

        // -(NMapCirclePoint *)circlePointAtIndex:(int)index;
        [Export("circlePointAtIndex:")]
        NMapCirclePoint CirclePointAtIndex(int index);

        // -(void)initCircleData;
        [Export("initCircleData")]
        void InitCircleData();

        // -(NMapCirclePoint *)addCirclePointUtmkX:(int)utmkX utmkY:(int)utmkY radius:(float)radius;
        [Export("addCirclePointUtmkX:utmkY:radius:")]
        NMapCirclePoint AddCirclePointUtmkX(int utmkX, int utmkY, float radius);

        // -(NMapCirclePoint *)addCirclePointLongitude:(double)longitude latitude:(double)latitude radius:(float)radius;
        [Export("addCirclePointLongitude:latitude:radius:")]
        //NMapCirclePoint AddCirclePointLongitude(double longitude, double latitude, float radius);
        NMapCirclePoint AddCirclePoint(double longitude, double latitude, float radius);


        // -(void)endCircleData;
        [Export("endCircleData")]
        void EndCircleData();

        // -(id)boundsOffset:(NMapView *)mapView;
        [Export("boundsOffset:")]
        NSObject BoundsOffset(NMapView mapView);

        // -(void)layoutChanged;
        [Export("layoutChanged")]
        void LayoutChanged();
    }

    // @interface NMapController (NMapView)
    [Category]
    [BaseType(typeof(NMapView))]
    interface NMapView_NMapController
    {
        // -(void)setMapEnlarged:(BOOL)mapEnlarged mapHD:(BOOL)mapHD;
        [Export("setMapEnlarged:mapHD:")]
        void SetMapEnlarged(bool mapEnlarged, bool mapHD);

        // @property (readonly, nonatomic) BOOL mapHD;
        [Export("mapHD")]
        bool MapHD();// { get; }

        // @property (nonatomic) BOOL mapEnlarged;
        [Export("mapEnlarged")]
        bool MapEnlarged();// { get; set; }

        [Export("setMapEnlarged:")]
        void SetMapEnlarged(bool mapEnlarged);

        // @property (nonatomic) int mapViewMode;
        //[Static, Export("mapViewMode")]
        //NMapViewMode MapViewMode { get; set; }
        [Export("mapViewMode")]
        NMapViewMode GetMapViewMode();

        [Export("setMapViewMode:")]
        void SetMapViewMode(NMapViewMode mapViewMode);

        // @property (nonatomic) BOOL mapViewTrafficMode;
        //[Static, Export("mapViewTrafficMode")]
        //bool MapViewTrafficMode { get; set; }
        [Export("mapViewTrafficMode")]
        bool GetMapViewTrafficMode();

        [Export("setMapViewTrafficMode:")]
        void SetMapViewTrafficMode(bool mapViewTrafficMode);

        // @property (nonatomic) BOOL mapViewPanoramaMode;
        //[Static, Export("mapViewPanoramaMode")]
        //bool MapViewPanoramaMode { get; set; }
        [Export("mapViewPanoramaMode")]
        bool GetMapViewPanoramaMode();// { get; set; }

        [Export("setMapViewPanoramaMode:")]
        void SetMapViewPanoramaMode(bool mapViewPanoramaMode);

        // @property (nonatomic) BOOL mapViewBicycleMode;
        //[Static, Export("mapViewBicycleMode")]
        //bool MapViewBicycleMode { get; set; }
        [Export("mapViewBicycleMode")]
        bool GetMapViewBicycleMode();

        [Export("setMapViewBicycleMode:")]
        void SetMapViewBicycleMode(bool mapViewBicycleMode);

        // @property (nonatomic) BOOL mapViewCadastralMode;
        //[Static, Export("mapViewCadastralMode")]
        //bool MapViewCadastralMode { get; set; }
        [Export("mapViewCadastralMode")]
        bool GetMapViewCadastralMode();

        [Export("setMapViewCadastralMode:")]
        void SetMapViewCadastralMode(bool mapViewCadastralMode);

        // @property (nonatomic) BOOL mapViewIndoorMode;
        //[Static, Export("mapViewIndoorMode")]
        //bool MapViewIndoorMode { get; set; }
        [Export("mapViewIndoorMode")]
        bool GetMapViewIndoorMode();

        [Export("setMapViewIndoorMode:")]
        void SetMapViewIndoorMode(bool mapViewIndoorMode);

        // -(void)setBoundsMin:(NPoint *)bboxMinUtmk max:(NPoint *)bboxMaxUtmk;
        [Export("setBoundsMin:max:")]
        //unsafe void SetBoundsMin(NPoint* bboxMinUtmk, NPoint* bboxMaxUtmk);
        void SetBoundsMin(NPoint bboxMinUtmk, NPoint bboxMaxUtmk);

        // @property (readonly, nonatomic) NGeoPoint mapCenter;
        [Export("mapCenter")]
        NGeoPoint MapCenter();// { get; }

        // -(NGeoPoint)mapBoundsCenter;
        //[Static, Export("mapBoundsCenter")]
        //NGeoPoint MapBoundsCenter { get; }
        [Export("mapBoundsCenter")]
        NGeoPoint MapBoundsCenter();

        // -(NPoint)mapBoundsCenterInUtmkX;
        //[Static, Export("mapBoundsCenterInUtmkX")]
        //NPoint MapBoundsCenterInUtmkX { get; }
        [Export("mapBoundsCenterInUtmkX")]
        NPoint MapBoundsCenterInUtmkX();

        // @property (readonly, nonatomic) NPoint mapCenterInUtmkX;
        //[Static, Export("mapCenterInUtmkX")]
        //NPoint MapCenterInUtmkX { get; }
        [Export("mapCenterInUtmkX")]
        NPoint MapCenterInUtmkX();

        // @property (nonatomic) CGRect boundsVisible;
        //[Static, Export("boundsVisible")]
        //CGRect BoundsVisible { get; set; }
        [Export("boundsVisible")]
        CGRect GetBoundsVisible();

        [Export("setBoundsVisible:")]
        void SetBoundsVisible(CGRect boundsVisible);

        // -(BOOL)hasVisibleBounds;
        //[Static, Export("hasVisibleBounds")]
        //bool HasVisibleBounds { get; }
        [Export("hasVisibleBounds")]
        bool HasVisibleBounds();

        // -(void)setMapCenter:(NGeoPoint)location atLevel:(int)level panToVisibleCenter:(BOOL)panToVisibleCenter;
        [Export("setMapCenter:atLevel:panToVisibleCenter:")]
        void SetMapCenter(NGeoPoint location, int level, bool panToVisibleCenter);

        // -(void)setMapCenter:(NGeoPoint)location atLevel:(int)level;
        [Export("setMapCenter:atLevel:")]
        void SetMapCenter(NGeoPoint location, int level);

        // -(void)setMapCenter:(NGeoPoint)location;
        [Export("setMapCenter:")]
        void SetMapCenter(NGeoPoint location);

        // -(void)setMapCenterWithUtmk:(NPoint)utmk atLevel:(int)level panToVisibleCenter:(BOOL)panToVisibleCenter;
        [Export("setMapCenterWithUtmk:atLevel:panToVisibleCenter:")]
        void SetMapCenterWithUtmk(NPoint utmk, int level, bool panToVisibleCenter);

        // -(void)setMapCenterWithUtmk:(NPoint)utmk atLevel:(int)level;
        [Export("setMapCenterWithUtmk:atLevel:")]
        void SetMapCenterWithUtmk(NPoint utmk, int level);

        // -(void)setMapCenterWithUtmk:(NPoint)utmk;
        [Export("setMapCenterWithUtmk:")]
        void SetMapCenterWithUtmk(NPoint utmk);

        // -(void)setMapVersionVector:(NSArray *)vectorVer satellite:(NSArray *)satelliteVer overlay:(NSArray *)overlayVer traffic:(NSArray *)trafficVer panorama:(NSArray *)panoramaVer bicycle:(NSArray *)bicycleVer;
        [Export("setMapVersionVector:satellite:overlay:traffic:panorama:bicycle:")]
        //[Verify(StronglyTypedNSArray), Verify(StronglyTypedNSArray), Verify(StronglyTypedNSArray), Verify(StronglyTypedNSArray), Verify(StronglyTypedNSArray), Verify(StronglyTypedNSArray)]
        void SetMapVersionVector(string[] vectorVer, string[] satelliteVer, string[] overlayVer, string[] trafficVer, string[] panoramaVer, string[] bicycleVer);

        // -(void)changeMapVersionVector:(NSArray *)vectorVer satellite:(NSArray *)satelliteVer overlay:(NSArray *)overlayVer traffic:(NSArray *)trafficVer panorama:(NSArray *)panoramaVer bicycle:(NSArray *)bicycleVer;
        [Export("changeMapVersionVector:satellite:overlay:traffic:panorama:bicycle:")]
        //[Verify(StronglyTypedNSArray), Verify(StronglyTypedNSArray), Verify(StronglyTypedNSArray), Verify(StronglyTypedNSArray), Verify(StronglyTypedNSArray), Verify(StronglyTypedNSArray)]
        void ChangeMapVersionVector(string[] vectorVer, string[] satelliteVer, string[] overlayVer, string[] trafficVer, string[] panoramaVer, string[] bicycleVer);

        // -(void)setMapVersionMerged:(NSArray *)mergedVer;
        [Export("setMapVersionMerged:")]
        //[Verify(StronglyTypedNSArray)]
        void SetMapVersionMerged(NSObject[] mergedVer);

        // -(void)setMapVersionMergedHD:(NSArray *)mergedHDVer;
        [Export("setMapVersionMergedHD:")]
        //[Verify(StronglyTypedNSArray)]
        void SetMapVersionMergedHD(NSObject[] mergedHDVer);

        // -(void)setZoomLevelMin:(int)minLevel max:(int)maxLevel;
        [Export("setZoomLevelMin:max:")]
        void SetZoomLevelMin(int minLevel, int maxLevel);

        // -(int)minZoomLevel;
        //[Static, Export("minZoomLevel")]
        //int MinZoomLevel { get; }
        [Export("minZoomLevel")]
        int MinZoomLevel();

        // -(int)maxZoomLevel;
        //[Static, Export("maxZoomLevel")]
        //int MaxZoomLevel { get; }
        [Export("maxZoomLevel")]
        int MaxZoomLevel();

        // -(void)setZoomEnabled:(BOOL)enabled;
        [Export("setZoomEnabled:")]
        void SetZoomEnabled(bool enabled);

        // -(void)setPanEnabled:(BOOL)enabled;
        [Export("setPanEnabled:")]
        void SetPanEnabled(bool enabled);

        // -(int)zoomLevel;
        //[Static, Export("zoomLevel")]
        //int ZoomLevel { get; }
        [Export("zoomLevel")]
        int ZoomLevel();

        // -(BOOL)setZoomLevel:(int)level;
        [Export("setZoomLevel:")]
        bool SetZoomLevel(int level);

        // -(NGRect)viewPort;
        //[Static, Export("viewPort")]
        //NGRect ViewPort { get; }
        [Export("viewPort")]
        NGRect ViewPort();

        // -(void)zoomIn;
        [Export("zoomIn")]
        void ZoomIn();

        // -(void)zoomIn:(id)pivot;
        [Export("zoomIn:")]
        void ZoomIn(CGPoint pivot);

        // -(void)zoomOut;
        [Export("zoomOut")]
        void ZoomOut();

        // -(void)zoomOut:(id)pivot;
        [Export("zoomOut:")]
        void ZoomOut(CGPoint pivot);

        // -(void)zoomToLevel:(int)level pivot:(id)pivot animate:(BOOL)animate;
        [Export("zoomToLevel:pivot:animate:")]
        void ZoomToLevel(int level, CGPoint pivot, bool animate);

        // -(void)zoomByFactor:(float)zoomFactor near:(id)center;
        [Export("zoomByFactor:near:")]
        void ZoomByFactor(float zoomFactor, CGPoint center);

        // -(void)moveByDx:(float)dX dY:(float)dY;
        [Export("moveByDx:dY:")]
        void MoveByDx(float dX, float dY);

        // -(void)animateTo:(NGeoPoint)location;
        [Export("animateTo:")]
        void AnimateTo(NGeoPoint location);

        // -(void)animateByDx:(float)dX dY:(float)dY;
        [Export("animateByDx:dY:")]
        void AnimateByDx(float dX, float dY);

        // -(void)animateToPOIitem:(id)poiItem;
        [Export("animateToPOIitem:")]
        void AnimateToPOIitem(NMapPOIitem poiItem);

        // -(void)animateToPOIitem:(id)poiItem afterDelay:(NSTimeInterval)delay;
        [Export("animateToPOIitem:afterDelay:")]
        void AnimateToPOIitem(NMapPOIitem poiItem, double delay);

        // -(int)zoomLevelToBounds:(NGeoRect)bounds;
        [Export("zoomLevelToBounds:")]
        int ZoomLevelToBounds(NGeoRect bounds);

        // -(void)zoomToBounds:(NGeoRect)bounds;
        [Export("zoomToBounds:")]
        void ZoomToBounds(NGeoRect bounds);

        // -(void)zoomToBounds:(NGeoRect)bounds atLevel:(int)level;
        [Export("zoomToBounds:atLevel:")]
        void ZoomToBounds(NGeoRect bounds, int level);

        // -(int)zoomLevelToBoundsInUtmk:(NRect)boundsInUtmk;
        [Export("zoomLevelToBoundsInUtmk:")]
        int ZoomLevelToBoundsInUtmk(NRect boundsInUtmk);

        // -(void)zoomToBoundsInUtmk:(NRect)boundsInUtmk;
        [Export("zoomToBoundsInUtmk:")]
        void ZoomToBoundsInUtmk(NRect boundsInUtmk);

        // -(void)zoomToBoundsInUtmk:(NRect)boundsInUtmk atLevel:(int)level;
        [Export("zoomToBoundsInUtmk:atLevel:")]
        void ZoomToBoundsInUtmk(NRect boundsInUtmk, int level);

        // -(NSArray *)retrieveTilesKeyListForOfflineMapWithRadius:(float)radius minLevel:(int)minLevel maxLevel:(int)maxLevel atCenter:(NGeoPoint)center;
        [Export("retrieveTilesKeyListForOfflineMapWithRadius:minLevel:maxLevel:atCenter:")]
        //[Verify(StronglyTypedNSArray)]
        string[] RetrieveTilesKeyListForOfflineMapWithRadius(float radius, int minLevel, int maxLevel, NGeoPoint center);

        // -(NSArray *)retrieveTilesKeyListForOfflineMapWithRadius:(float)radius minLevel:(int)minLevel maxLevel:(int)maxLevel atCenterUtmkX:(int)utmkX atCenterUtmkY:(int)utmkY;
        [Export("retrieveTilesKeyListForOfflineMapWithRadius:minLevel:maxLevel:atCenterUtmkX:atCenterUtmkY:")]
        //[Verify(StronglyTypedNSArray)]
        string[] RetrieveTilesKeyListForOfflineMapWithRadius(float radius, int minLevel, int maxLevel, int utmkX, int utmkY);

        // -(void)setOfflineViewMode:(id)viewMode offlineType:(int)offlineType offlineId:(int)offlineId;
        [Export("setOfflineViewMode:offlineType:offlineId:")]
        void SetOfflineViewMode(NSObject viewMode, int offlineType, int offlineId);
    }

    // @interface NMapLocationManager : NSObject <CLLocationManagerDelegate>
    [BaseType(typeof(NSObject))]
    interface NMapLocationManager : ICLLocationManagerDelegate
    {
        // @property (assign, nonatomic) BOOL keepUpdatingLocation;
        [Export("keepUpdatingLocation")]
        bool KeepUpdatingLocation { get; set; }

        // @property (assign, nonatomic) CLLocationAccuracy startAccuracy;
        [Export("startAccuracy")]
        double StartAccuracy { get; set; }

        // @property (assign, nonatomic) NSTimeInterval startTimeout;
        [Export("startTimeout")]
        double StartTimeout { get; set; }

        // @property (assign, nonatomic) CLLocationAccuracy desiredAccuracy;
        [Export("desiredAccuracy")]
        double DesiredAccuracy { get; set; }

        // @property (assign, nonatomic) CLLocationDistance distanceFilter;
        [Export("distanceFilter")]
        double DistanceFilter { get; set; }

        // @property (readonly, nonatomic) CLLocation * location;
        [Export("location")]
        CLLocation Location { get; }

        // @property (readonly, nonatomic) CLLocationManager * locationManager;
        [Export("locationManager")]
        CLLocationManager LocationManager { get; }

        // +(NMapLocationManager *)getSharedInstance;
        [Static]
        [Export("getSharedInstance")]
        NMapLocationManager SharedInstance { get; }

        // -(BOOL)locationServiceEnabled;
        [Export("locationServiceEnabled")]
        bool LocationServiceEnabled { get; }

        // -(void)startUpdatingLocation;
        [Export("startUpdatingLocation")]
        void StartUpdatingLocation();

        // -(void)stopUpdatingLocation;
        [Export("stopUpdatingLocation")]
        void StopUpdatingLocation();

        // -(void)setDelegate:(id<NMapLocationManagerDelegate>)delegate;
        [Export("setDelegate:")]
        void SetDelegate(INMapLocationManagerDelegate @delegate);

        // -(void)startContinuousLocationInfo;
        [Export("startContinuousLocationInfo")]
        void StartContinuousLocationInfo();

        // -(void)stopUpdateLocationInfo;
        [Export("stopUpdateLocationInfo")]
        void StopUpdateLocationInfo();

        // -(void)suspendUpdateLocationInfo;
        [Export("suspendUpdateLocationInfo")]
        void SuspendUpdateLocationInfo();

        // -(void)resumeUpdateLocationInfo;
        [Export("resumeUpdateLocationInfo")]
        void ResumeUpdateLocationInfo();

        // -(void)startCurrentLocationInfo;
        [Export("startCurrentLocationInfo")]
        void StartCurrentLocationInfo();

        // -(BOOL)isLocationFixed;
        [Export("isLocationFixed")]
        bool IsLocationFixed { get; }

        // -(BOOL)isUpdateLocationStarted;
        [Export("isUpdateLocationStarted")]
        bool IsUpdateLocationStarted { get; }

        // -(BOOL)isUpdateLocationSuspended;
        [Export("isUpdateLocationSuspended")]
        bool IsUpdateLocationSuspended { get; }

        // -(BOOL)isTrackingEnabled;
        [Export("isTrackingEnabled")]
        bool IsTrackingEnabled { get; }

        // -(BOOL)isTrackingStarted;
        [Export("isTrackingStarted")]
        bool IsTrackingStarted { get; }

        // -(BOOL)headingAvailable;
        [Export("headingAvailable")]
        bool HeadingAvailable { get; }

        // -(BOOL)isHeadingUpdateStarted;
        [Export("isHeadingUpdateStarted")]
        bool IsHeadingUpdateStarted { get; }

        // -(void)startUpdatingHeading;
        [Export("startUpdatingHeading")]
        void StartUpdatingHeading();

        // -(void)stopUpdatingHeading;
        [Export("stopUpdatingHeading")]
        void StopUpdatingHeading();
    }

    // @protocol NMapLocationManagerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface NMapLocationManagerDelegate
    {
        // @required -(void)locationManager:(NMapLocationManager *)locationManager didUpdateToLocation:(CLLocation *)location;
        [Abstract]
        [Export("locationManager:didUpdateToLocation:")]
        void DidUpdateToLocation(NMapLocationManager locationManager, CLLocation location);

        // @required -(void)locationManager:(NMapLocationManager *)locationManager didFailWithError:(NMapLocationManagerErrorType)errorType;
        [Abstract]
        [Export("locationManager:didFailWithError:")]
        void DidFailWithError(NMapLocationManager locationManager, NMapLocationManagerErrorType errorType);

        // @optional -(void)locationManager:(NMapLocationManager *)locationManager didUpdateHeading:(CLHeading *)heading;
        [Export("locationManager:didUpdateHeading:")]
        void DidUpdateHeading(NMapLocationManager locationManager, CLHeading heading);
    }

    //Empty Interface
    interface INMapLocationManagerDelegate { };

    // @interface NMapPOIitem : NSObject
    [BaseType(typeof(NSObject))]
    interface NMapPOIitem
    {
        // @property (assign, nonatomic) NGPoint position;
        [Export("position", ArgumentSemantic.Assign)]
        NGPoint Position { get; set; }

        // @property (assign, nonatomic) CGPoint screenLocation;
        [Export("screenLocation", ArgumentSemantic.Assign)]
        CGPoint ScreenLocation { get; set; }

        // @property (assign, nonatomic) CGPoint positionSpread;
        [Export("positionSpread", ArgumentSemantic.Assign)]
        CGPoint PositionSpread { get; set; }

        // @property (assign, nonatomic) int orderId;
        [Export("orderId")]
        int OrderId { get; set; }

        // @property (assign, nonatomic) BOOL isSpreadable;
        [Export("isSpreadable")]
        bool IsSpreadable { get; set; }

        // @property (retain, nonatomic) CALayer * imgLayer;
        [Export("imgLayer", ArgumentSemantic.Retain)]
        CALayer ImgLayer { get; set; }

        // @property (assign, nonatomic) CGPoint anchorPoint;
        [Export("anchorPoint", ArgumentSemantic.Assign)]
        CGPoint AnchorPoint { get; set; }

        // @property (retain, nonatomic) CALayer * infoLayer;
        [Export("infoLayer", ArgumentSemantic.Retain)]
        CALayer InfoLayer { get; set; }

        // @property (assign, nonatomic) CGPoint infoLayerOffset;
        [Export("infoLayerOffset", ArgumentSemantic.Assign)]
        CGPoint InfoLayerOffset { get; set; }

        // @property (readonly, nonatomic) CGRect frame;
        [Export("frame")]
        CGRect Frame { get; }

        // @property (getter = isHidden, assign, nonatomic) BOOL hidden;
        [Export("hidden")]
        bool Hidden { [Bind("isHidden")] get; set; }

        // @property (retain, nonatomic) NSString * title;
        [Export("title", ArgumentSemantic.Retain)]
        string Title { get; set; }

        // @property (retain, nonatomic) NSString * snippet;
        [Export("snippet", ArgumentSemantic.Retain)]
        string Snippet { get; set; }

        // @property (retain, nonatomic) NSString * head;
        [Export("head", ArgumentSemantic.Retain)]
        string Head { get; set; }

        // @property (retain, nonatomic) NSString * tail;
        [Export("tail", ArgumentSemantic.Retain)]
        string Tail { get; set; }

        // @property (assign, nonatomic) NGeoPoint location;
        [Export("location", ArgumentSemantic.Assign)]
        NGeoPoint Location { get; set; }

        // @property (assign, nonatomic) NPoint utmk;
        [Export("utmk", ArgumentSemantic.Assign)]
        NPoint Utmk { get; set; }

        // @property (assign, nonatomic) int poiFlagType;
        [Export("poiFlagType")]
        int PoiFlagType { get; set; }

        // @property (assign, nonatomic) int iconIndex;
        [Export("iconIndex")]
        int IconIndex { get; set; }

        // @property (assign, nonatomic) BOOL isFloating;
        [Export("isFloating")]
        bool IsFloating { get; set; }

        // @property (assign, nonatomic) BOOL hasTouchMode;
        [Export("hasTouchMode")]
        bool HasTouchMode { get; set; }

        // @property (assign, nonatomic) BOOL isDispatchable;
        [Export("isDispatchable")]
        bool IsDispatchable { get; set; }

        // @property (retain, nonatomic) id object;
        [Export("object", ArgumentSemantic.Retain)]
        NSObject Object { get; set; }

        // @property (assign, nonatomic) BOOL hasRightCalloutAccessory;
        [Export("hasRightCalloutAccessory")]
        bool HasRightCalloutAccessory { get; set; }

        // @property (assign, nonatomic) BOOL animationEnabled;
        [Export("animationEnabled")]
        bool AnimationEnabled { get; set; }

        // @property (assign, nonatomic) BOOL keepSelected;
        [Export("keepSelected")]
        bool KeepSelected { get; set; }

        // -(void)setPOIflagMode:(NMapPOIflagMode)mode;
        [Export("setPOIflagMode:")]
        void SetPOIflagMode(NMapPOIflagMode mode);

        // -(BOOL)isPOIflagModeFixed;
        [Export("isPOIflagModeFixed")]
        bool IsPOIflagModeFixed { get; }

        // -(BOOL)isTitleEmpty;
        [Export("isTitleEmpty")]
        bool IsTitleEmpty { get; }
    }

    // @interface infoLayer (NMapPOIitem)
    [Category]
    [BaseType(typeof(NMapPOIitem))]
    interface NMapPOIitem_infoLayer
    {
        // -(void)setInfoLayerPosition;
        [Export("setInfoLayerPosition")]
        void SetInfoLayerPosition();
    }

    // @protocol NMapOverlayDelegate
    [Protocol] //, Model
    interface NMapOverlayDelegate
    {
        // @required -(BOOL)isPersistent;
        [Abstract]
        [Export("isPersistent")]
        bool IsPersistent { get; }

        // @required -(BOOL)hasPathData;
        [Abstract]
        [Export("hasPathData")]
        bool HasPathData { get; }

        // @required -(void)drawToLayer:(CALayer *)theLayer frame:(CGRect)rect;
        [Abstract]
        [Export("drawToLayer:frame:")]
        void DrawToLayer(CALayer theLayer, CGRect rect);

        // @required -(void)clearOverlay;
        [Abstract]
        [Export("clearOverlay")]
        void ClearOverlay();

        // @required -(void)stopTimers;
        [Abstract]
        [Export("stopTimers")]
        void StopTimers();

        // @required -(void)layoutSublayers;
        [Abstract]
        [Export("layoutSublayers")]
        void LayoutSublayers();

        // @required -(void)moveByDx:(float)dX dY:(float)dY;
        [Abstract]
        [Export("moveByDx:dY:")]
        void MoveByDx(float dX, float dY);

        // @required -(void)initZoomByFactor:(float)zoomFactor near:(CGPoint)pivot;
        [Abstract]
        [Export("initZoomByFactor:near:")]
        void InitZoomByFactor(float zoomFactor, CGPoint pivot);

        // @required -(void)zoomByFactor:(float)zoomFactor near:(CGPoint)pivot;
        [Abstract]
        [Export("zoomByFactor:near:")]
        void ZoomByFactor(float zoomFactor, CGPoint pivot);
    }

    // @interface NMapOverlay : NSObject <NMapOverlayDelegate>
    [BaseType(typeof(NSObject))]
    interface NMapOverlay : NMapOverlayDelegate
    {
        // @property (assign, nonatomic) BOOL persistent;
        [Export("persistent")]
        bool Persistent { get; set; }

        // @property (assign, nonatomic) BOOL hidden;
        [Export("hidden")]
        bool Hidden { get; set; }

        // @property (assign, nonatomic) NMapOverlayZPosition zPosition;
        [Export("zPosition", ArgumentSemantic.Assign)]
        NMapOverlayZPosition ZPosition { get; set; }

        // -(int)layerZPosition:(int)zPosition;
        [Export("layerZPosition:")]
        int LayerZPosition(int zPosition);
    }

    // @interface NMapPOIdataOverlay : NMapOverlay
    [BaseType(typeof(NMapOverlay))]
    interface NMapPOIdataOverlay
    {
        // @property (readonly, nonatomic) int idxFocusedPOIitem;
        [Export("idxFocusedPOIitem")]
        int IdxFocusedPOIitem { get; }

        // @property (readonly, getter = isFocusedBySelectItem, nonatomic) BOOL focusedBySelectItem;
        [Export("focusedBySelectItem")]
        bool FocusedBySelectItem { [Bind("isFocusedBySelectItem")] get; }

        // @property (readonly, nonatomic) BOOL isSpreadable;
        [Export("isSpreadable")]
        bool IsSpreadable { get; }

        [Wrap("WeakDelegate")]
        INMapPOIdataOverlayDelegate Delegate { get; set; }

        // @property (assign, nonatomic) id<NMapPOIdataOverlayDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        INMapPOIdataOverlayDelegate WeakDelegate { get; set; }

        // @property (assign, nonatomic) CALayer * overlayLayer;
        [Export("overlayLayer", ArgumentSemantic.Assign)]
        CALayer OverlayLayer { get; set; }

        // @property (assign, nonatomic) NMapView * mapView;
        [Export("mapView", ArgumentSemantic.Assign)]
        NMapView MapView { get; set; }

        // @property (assign, nonatomic) NMapOverlayManager * mapOverlayManager;
        [Export("mapOverlayManager", ArgumentSemantic.Assign)]
        NMapOverlayManager MapOverlayManager { get; set; }

        // -(void)initPOIdata:(int)countOfPOIdata;
        [Export("initPOIdata:")]
        void InitPOIdata(int countOfPOIdata);

        // -(void)addPOIdata:(int)countOfPOIdata;
        [Export("addPOIdata:")]
        void AddPOIdata(int countOfPOIdata);

        // -(NMapPOIitem *)addPOIitemAtLocation:(NGeoPoint)location title:(NSString *)title type:(NMapPOIflagType)poiFlagType withObject:(id)object;
        [Export("addPOIitemAtLocation:title:type:withObject:")]
        NMapPOIitem AddPOIitemAtLocation(NGeoPoint location, string title, int poiFlagType, [NullAllowed]NSObject @object);

        // -(NMapPOIitem *)addPOIitemAtLocation:(NGeoPoint)location title:(NSString *)title type:(NMapPOIflagType)poiFlagType iconIndex:(int)iconIndex withObject:(id)object;
        [Export("addPOIitemAtLocation:title:type:iconIndex:withObject:")]
        NMapPOIitem AddPOIitemAtLocation(NGeoPoint location, string title, int poiFlagType, int iconIndex, [NullAllowed]NSObject @object);

        // -(NMapPOIitem *)addPOIitemAtLocationInUtmk:(NPoint)utmk title:(NSString *)title type:(NMapPOIflagType)poiFlagType withObject:(id)object;
        [Export("addPOIitemAtLocationInUtmk:title:type:withObject:")]
        NMapPOIitem AddPOIitemAtLocationInUtmk(NPoint utmk, string title, int poiFlagType, [NullAllowed]NSObject @object);

        // -(NMapPOIitem *)addPOIitemAtLocationInUtmk:(NPoint)utmk title:(NSString *)title type:(NMapPOIflagType)poiFlagType iconIndex:(int)iconIndex withObject:(id)object;
        [Export("addPOIitemAtLocationInUtmk:title:type:iconIndex:withObject:")]
        NMapPOIitem AddPOIitemAtLocationInUtmk(NPoint utmk, string title, int poiFlagType, int iconIndex, [NullAllowed]NSObject @object);

        // -(void)endPOIdata;
        [Export("endPOIdata")]
        void EndPOIdata();

        // -(void)selectPOIitemAtIndex:(int)index;
        [Export("selectPOIitemAtIndex:")]
        void SelectPOIitemAtIndex(int index);

        // -(void)selectPOIitemAtIndex:(int)index moveToCenter:(BOOL)moveToCenter;
        [Export("selectPOIitemAtIndex:moveToCenter:")]
        void SelectPOIitemAtIndex(int index, bool moveToCenter);

        // -(void)selectPOIitemAtIndex:(int)index moveToCenter:(BOOL)moveToCenter focusedBySelectItem:(BOOL)focusedBySelectItem;
        [Export("selectPOIitemAtIndex:moveToCenter:focusedBySelectItem:")]
        void SelectPOIitemAtIndex(int index, bool moveToCenter, bool focusedBySelectItem);

        // -(void)selectPOIitemAtIndex:(int)index closeOverlappedLayer:(BOOL)closeOverlappedLayer;
        [Export("selectPOIitemAtIndex:closeOverlappedLayer:")]
        //void SelectPOIitemAtIndex(int index, bool closeOverlappedLayer);
        void SelectPOIitemAtIndexCloseOverlappedLayer(int index, bool closeOverlappedLayer);

        // -(void)selectPOIitemWithType:(NMapPOIflagType)poiFlagType;
        [Export("selectPOIitemWithType:")]
        void SelectPOIitemWithType(int poiFlagType);

        // -(void)selectPOIitemWithType:(NMapPOIflagType)poiFlagType moveToCenter:(BOOL)moveToCenter;
        [Export("selectPOIitemWithType:moveToCenter:")]
        void SelectPOIitemWithType(int poiFlagType, bool moveToCenter);

        // -(void)selectPOIitemWithObject:(id)object;
        [Export("selectPOIitemWithObject:")]
        void SelectPOIitemWithObject(NSObject @object);

        // -(void)selectPOIitemWithObject:(id)object moveToCenter:(BOOL)moveToCenter;
        [Export("selectPOIitemWithObject:moveToCenter:")]
        void SelectPOIitemWithObject(NSObject @object, bool moveToCenter);

        // -(void)showAllPOIdataAtLevel:(int)zoomLevel;
        [Export("showAllPOIdataAtLevel:")]
        void ShowAllPOIdataAtLevel(int zoomLevel);

        // -(void)showAllPOIdata;
        [Export("showAllPOIdata")]
        void ShowAllPOIdata();

        // -(BOOL)adjustZoomLevelForPOIdataBounds;
        [Export("adjustZoomLevelForPOIdataBounds")]
        bool AdjustZoomLevelForPOIdataBounds { get; }

        // -(BOOL)adjustPOIdataBounds;
        [Export("adjustPOIdataBounds")]
        bool AdjustPOIdataBounds { get; }

        // -(int)indexForAdjacentLocation:(NGeoPoint)lonLat withinRadius:(float)radius;
        [Export("indexForAdjacentLocation:withinRadius:")]
        int IndexForAdjacentLocation(NGeoPoint lonLat, float radius);

        // -(BOOL)containsLocation:(NGeoPoint)location;
        [Export("containsLocation:")]
        bool ContainsLocation(NGeoPoint location);

        // -(int)indexForNearestLocation:(NGeoPoint)location;
        [Export("indexForNearestLocation:")]
        int IndexForNearestLocation(NGeoPoint location);

        // -(int)count;
        [Export("count")]
        int Count { get; }

        // -(NSArray *)poiData;
        [Export("poiData")]
        //[Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        //NSObject[] PoiData { get; }
        NMapPOIitem[] PoiData { get; }

        // -(NMapPOIitem *)findPOIitemWithObject:(id)object foundIndex:(int *)foundIndex;
        [Export("findPOIitemWithObject:foundIndex:")]
        //unsafe NMapPOIitem FindPOIitemWithObject(NSObject @object, int* foundIndex);
        NMapPOIitem FindPOIitemWithObject(NSObject @object, int foundIndex);

        // -(NMapPOIitem *)poiItemAtIndex:(int)index;
        [Export("poiItemAtIndex:")]
        NMapPOIitem PoiItemAtIndex(int index);

        // -(NMapPOIitem *)focusedPOIitem;
        [Export("focusedPOIitem")]
        NMapPOIitem FocusedPOIitem();// { get; }

        // -(CGRect)frameOfSelectedPOIitem;
        [Export("frameOfSelectedPOIitem")]
        CGRect FrameOfSelectedPOIitem();// { get; }

        // -(void)deselctFocusedPOIitem;
        [Export("deselctFocusedPOIitem")]
        void DeselctFocusedPOIitem();

        // -(void)showFocusedPOIitemOnly;
        [Export("showFocusedPOIitemOnly")]
        void ShowFocusedPOIitemOnly();

        // -(void)showAllPOIitems;
        [Export("showAllPOIitems")]
        void ShowAllPOIitems();

        // -(void)updateImageForPOIitem:(NMapPOIitem *)poiItem;
        [Export("updateImageForPOIitem:")]
        void UpdateImageForPOIitem(NMapPOIitem poiItem);

        // -(void)updateImageAtIndex:(int)index;
        [Export("updateImageAtIndex:")]
        void UpdateImageAtIndex(int index);

        // -(void)changeTitleOfPOIitemWithType:(NMapPOIflagType)poiFlagType title:(NSString *)title;
        [Export("changeTitleOfPOIitemWithType:title:")]
        void ChangeTitleOfPOIitemWithType(int poiFlagType, string title);

        // -(BOOL)hasCalloutOverlay;
        [Export("hasCalloutOverlay")]
        bool HasCalloutOverlay { get; }

        // -(BOOL)isCalloutInVisibleBounds;
        [Export("isCalloutInVisibleBounds")]
        bool IsCalloutInVisibleBounds { get; }

        // -(void)addOverlay;
        [Export("addOverlay")]
        void AddOverlay();

        // -(void)removeOverlay;
        [Export("removeOverlay")]
        void RemoveOverlay();

        // -(void)showInfoLayers:(BOOL)enable;
        [Export("showInfoLayers:")]
        void ShowInfoLayers(bool enable);

        // -(void)setHiddenExceptEndItems:(BOOL)hidden midItem:(int)midItemIndex;
        [Export("setHiddenExceptEndItems:midItem:")]
        void SetHiddenExceptEndItems(bool hidden, int midItemIndex);
    }

    // @protocol NMapPOIdataOverlayDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface NMapPOIdataOverlayDelegate
    {
        // @required -(UIImage *)onMapOverlay:(NMapPOIdataOverlay *)poiDataOverlay imageForOverlayItem:(NMapPOIitem *)poiItem selected:(BOOL)selected;
        [Abstract]
        [Export("onMapOverlay:imageForOverlayItem:selected:")]
        UIImage OnMapOverlay(NMapPOIdataOverlay poiDataOverlay, NMapPOIitem poiItem, bool selected);

        // @required -(CGPoint)onMapOverlay:(NMapPOIdataOverlay *)poiDataOverlay anchorPointWithType:(NMapPOIflagType)poiFlagType;
        [Abstract]
        [Export("onMapOverlay:anchorPointWithType:")]
        CGPoint OnMapOverlay(NMapPOIdataOverlay poiDataOverlay, int poiFlagType);

        // @required -(UIImage *)onMapOverlay:(NMapPOIdataOverlay *)poiDataOverlay imageForCalloutOverlayItem:(NMapPOIitem *)poiItem constraintSize:(CGSize)constraintSize selected:(BOOL)selected imageForCalloutRightAccessory:(UIImage *)imageForCalloutRightAccessory calloutPosition:(CGPoint *)calloutPosition calloutHitRect:(CGRect *)calloutHitRect;
        [Abstract]
        [Export("onMapOverlay:imageForCalloutOverlayItem:constraintSize:selected:imageForCalloutRightAccessory:calloutPosition:calloutHitRect:")]
        //unsafe UIImage OnMapOverlay(NMapPOIdataOverlay poiDataOverlay, NMapPOIitem poiItem, CGSize constraintSize, bool selected, UIImage imageForCalloutRightAccessory, CGPoint* calloutPosition, CGRect* calloutHitRect);
        UIImage OnMapOverlay(NMapPOIdataOverlay poiDataOverlay, NMapPOIitem poiItem, CGSize constraintSize, bool selected, UIImage imageForCalloutRightAccessory, CGPoint calloutPosition, CGRect calloutHitRect);

        // @required -(CGPoint)onMapOverlay:(NMapPOIdataOverlay *)poiDataOverlay calloutOffsetWithType:(NMapPOIflagType)poiFlagType;
        [Abstract]
        [Export("onMapOverlay:calloutOffsetWithType:")]
        //CGPoint OnMapOverlay(NMapPOIdataOverlay poiDataOverlay, int poiFlagType);
        CGPoint OnMapOverlayCalloutOffsetWithType(NMapPOIdataOverlay poiDataOverlay, int poiFlagType);

        // @optional -(UIView *)onMapOverlay:(NMapPOIdataOverlay *)poiDataOverlay viewForCalloutOverlayItem:(NMapPOIitem *)poiItem calloutPosition:(CGPoint *)calloutPosition;
        [Export("onMapOverlay:viewForCalloutOverlayItem:calloutPosition:")]
        //unsafe UIView OnMapOverlay(NMapPOIdataOverlay poiDataOverlay, NMapPOIitem poiItem, CGPoint* calloutPosition);
        UIView OnMapOverlay(NMapPOIdataOverlay poiDataOverlay, NMapPOIitem poiItem, CGPoint calloutPosition);

        // @optional -(UIImage *)onMapOverlay:(NMapPOIdataOverlay *)poiDataOverlay imageWithType:(int)poiFlagType iconIndex:(int)index selectedImage:(UIImage **)selectedImage;
        [Export("onMapOverlay:imageWithType:iconIndex:selectedImage:")]
        UIImage OnMapOverlay(NMapPOIdataOverlay poiDataOverlay, int poiFlagType, int index, out UIImage selectedImage);

        // @optional -(UIImage *)onMapOverlay:(NMapPOIdataOverlay *)poiDataOverlay imageForInfoLayerOverlayItem:(NMapPOIitem *)poiItem;
        [Export("onMapOverlay:imageForInfoLayerOverlayItem:")]
        UIImage OnMapOverlay(NMapPOIdataOverlay poiDataOverlay, NMapPOIitem poiItem);

        // @optional -(void)onMapOverlay:(NMapPOIdataOverlay *)poiDataOverlay didCleareInfoLayers:(BOOL)cleared;
        [Export("onMapOverlay:didCleareInfoLayers:")]
        void OnMapOverlay(NMapPOIdataOverlay poiDataOverlay, bool cleared);

        // @optional -(void)onMapOverlay:(NMapPOIdataOverlay *)poiDataOverlay willShowCalloutOverlayItem:(NMapPOIitem *)poiItem;
        [Export("onMapOverlay:willShowCalloutOverlayItem:")]
        //void OnMapOverlay(NMapPOIdataOverlay poiDataOverlay, NMapPOIitem poiItem);
        void OnMapOverlayWillShowCalloutOverlayItem(NMapPOIdataOverlay poiDataOverlay, NMapPOIitem poiItem);

        // @optional -(BOOL)onMapOverlay:(NMapPOIdataOverlay *)poiDataOverlay didChangeSelectedPOIitemAtIndex:(int)index withObject:(id)object;
        [Export("onMapOverlay:didChangeSelectedPOIitemAtIndex:withObject:")]
        bool OnMapOverlay(NMapPOIdataOverlay poiDataOverlay, int index, [NullAllowed]NSObject @object);

        // @optional -(BOOL)onMapOverlay:(NMapPOIdataOverlay *)poiDataOverlay didDeselectPOIitemAtIndex:(int)index withObject:(id)object;
        [Export("onMapOverlay:didDeselectPOIitemAtIndex:withObject:")]
        //bool OnMapOverlay(NMapPOIdataOverlay poiDataOverlay, int index, NSObject @object);
        bool OnMapOverlayDidDeselectPOIitemAtIndex(NMapPOIdataOverlay poiDataOverlay, int index, [NullAllowed]NSObject @object);

        // @optional -(BOOL)onMapOverlay:(NMapPOIdataOverlay *)poiDataOverlay didSelectCalloutOfPOIitemAtIndex:(int)index withObject:(id)object;
        [Export("onMapOverlay:didSelectCalloutOfPOIitemAtIndex:withObject:")]
        //bool OnMapOverlay(NMapPOIdataOverlay poiDataOverlay, int index, NSObject @object);
        bool OnMapOverlayDidSelectCalloutOfPOIitemAtIndex(NMapPOIdataOverlay poiDataOverlay, int index, [NullAllowed]NSObject @object);

        // @optional -(BOOL)onMapOverlay:(NMapPOIdataOverlay *)poiDataOverlay hasCalloutRightAccessoryAtIndex:(int)index withObject:(id)object;
        [Export("onMapOverlay:hasCalloutRightAccessoryAtIndex:withObject:")]
        //bool OnMapOverlay(NMapPOIdataOverlay poiDataOverlay, int index, NSObject @object);
        bool OnMapOverlayHasCalloutRightAccessoryAtIndex(NMapPOIdataOverlay poiDataOverlay, int index, [NullAllowed]NSObject @object);

        // @optional -(UIImage *)onMapOverlay:(NMapPOIdataOverlay *)poiDataOverlay imageForCalloutRightAccessoryAtIndex:(int)index selected:(BOOL)selected withObject:(id)object;
        [Export("onMapOverlay:imageForCalloutRightAccessoryAtIndex:selected:withObject:")]
        UIImage OnMapOverlay(NMapPOIdataOverlay poiDataOverlay, int index, bool selected, [NullAllowed]NSObject @object);

        // @optional -(void)onMapOverlay:(NMapPOIdataOverlay *)poiDataOverlay didChangePOIitemLocationTo:(NGeoPoint)location withType:(NMapPOIflagType)poiFlagType;
        [Export("onMapOverlay:didChangePOIitemLocationTo:withType:")]
        void OnMapOverlay(NMapPOIdataOverlay poiDataOverlay, NGeoPoint location, int poiFlagType);
    }

    //Empty NMapPOIdataOverlayDelegate Interface
    interface INMapPOIdataOverlayDelegate { }

    // @interface NMapMyLocationOverlay : NMapPOIdataOverlay
    [BaseType(typeof(NMapPOIdataOverlay))]
    interface NMapMyLocationOverlay
    {
        // @property (assign, nonatomic) NGeoPoint location;
        [Export("location", ArgumentSemantic.Assign)]
        NGeoPoint Location { get; set; }

        // @property (assign, nonatomic) float locationAccuracy;
        [Export("locationAccuracy")]
        float LocationAccuracy { get; set; }

        // @property (assign, nonatomic) float compassHeading;
        [Export("compassHeading")]
        float CompassHeading { get; set; }

        // -(void)didStopLocationUpdates;
        [Export("didStopLocationUpdates")]
        void DidStopLocationUpdates();

        // -(void)didStartLocationUpdates;
        [Export("didStartLocationUpdates")]
        void DidStartLocationUpdates();
    }

    // @interface NMapPathPoint : NSObject
    [BaseType(typeof(NSObject))]
    interface NMapPathPoint
    {
        // @property (getter = isHidden, assign, nonatomic) BOOL hidden;
        [Export("hidden")]
        bool Hidden { [Bind("isHidden")] get; set; }

        // -(id)initWithUtmkX:(int)utmkX utmkY:(int)utmkY;
        [Export("initWithUtmkX:utmkY:")]
        IntPtr Constructor(int utmkX, int utmkY);

        // -(CGPoint)screenPosition:(NMapView *)mapView viewPortOrigin:(NGRect *)viewPortOrigin;
        [Export("screenPosition:viewPortOrigin:")]
        //unsafe CGPoint ScreenPosition(NMapView mapView, NGRect viewPortOrigin);
        CGPoint ScreenPosition(NMapView mapView, NGRect viewPortOrigin);

        // -(void)layoutChanged;
        [Export("layoutChanged")]
        void LayoutChanged();
    }

    // @interface NMapPathSegment : NSObject
    [BaseType(typeof(NSObject))]
    interface NMapPathSegment
    {
        // @property (assign, nonatomic) NMapPathLineType lineType;
        [Export("lineType", ArgumentSemantic.Assign)]
        NMapPathLineType LineType { get; set; }

        // -(id)initWithLineType:(int)lineType capacity:(int)capacity;
        [Export("initWithLineType:capacity:")]
        IntPtr Constructor(int lineType, int capacity);

        // -(int)countOfPathPoints;
        [Export("countOfPathPoints")]
        //[Verify(MethodToProperty)]
        int CountOfPathPoints { get; }

        // -(NMapPathPoint *)pathPointAtIndex:(int)index;
        [Export("pathPointAtIndex:")]
        NMapPathPoint PathPointAtIndex(int index);

        // -(NMapPathPoint *)pathPointAtLast;
        [Export("pathPointAtLast")]
        //[Verify(MethodToProperty)]
        NMapPathPoint PathPointAtLast { get; }

        // -(void)addPathPointInUtmkX:(int)utmkX utmkY:(int)utmkY;
        [Export("addPathPointInUtmkX:utmkY:")]
        void AddPathPointInUtmkX(int utmkX, int utmkY);

        // -(void)simplifyWith:(float)epsilon mapView:(NMapView *)mapView viewPortOrigin:(NGRect *)viewPortOrigin;
        [Export("simplifyWith:mapView:viewPortOrigin:")]
        //unsafe void SimplifyWith(float epsilon, NMapView mapView, NGRect* viewPortOrigin);
        void SimplifyWith(float epsilon, NMapView mapView, NGRect viewPortOrigin);

        // -(void)layoutChanged;
        [Export("layoutChanged")]
        void LayoutChanged();
    }

    // @interface NMapPathData : NSObject
    [BaseType(typeof(NSObject))]
    interface NMapPathData
    {
        // @property (retain, nonatomic) NSObject * object;
        [Export("object", ArgumentSemantic.Retain)]
        NSObject Object { get; set; }

        // @property (assign, nonatomic) BOOL hidden;
        [Export("hidden")]
        bool Hidden { get; set; }

        // @property (getter = isRendered, assign, nonatomic) BOOL rendered;
        [Export("rendered")]
        bool Rendered { [Bind("isRendered")] get; set; }

        // @property (readonly, nonatomic) NGRect viewPortOrigin;
        [Export("viewPortOrigin")]
        NGRect ViewPortOrigin { get; }

        // @property (retain, nonatomic) NMapPathLineStyle * pathLineStyle;
        [Export("pathLineStyle", ArgumentSemantic.Retain)]
        NMapPathLineStyle PathLineStyle { get; set; }

        // @property (assign, nonatomic) NRect boundsInUtmk;
        [Export("boundsInUtmk", ArgumentSemantic.Assign)]
        NRect BoundsInUtmk { get; set; }

        // -(BOOL)isValidBounds;
        [Export("isValidBounds")]
        //[Verify(MethodToProperty)]
        bool IsValidBounds { get; }

        // -(id)initWithCapacity:(int)capacity;
        [Export("initWithCapacity:")]
        IntPtr Constructor(int capacity);

        // -(int)countOfPathSegments;
        [Export("countOfPathSegments")]
        //[Verify(MethodToProperty)]
        int CountOfPathSegments { get; }

        // -(NMapPathSegment *)pathSegmentAtIndex:(int)index;
        [Export("pathSegmentAtIndex:")]
        NMapPathSegment PathSegmentAtIndex(int index);

        // -(void)initPathData:(int)count;
        [Export("initPathData:")]
        void InitPathData(int count);

        // -(void)initPathData;
        [Export("initPathData")]
        void InitPathData();

        // -(void)addPathPointUtmkX:(int)utmkX utmkY:(int)utmkY lineType:(NMapPathLineType)lineType controlPoint:(BOOL)controlPoint;
        [Export("addPathPointUtmkX:utmkY:lineType:controlPoint:")]
        void AddPathPointUtmkX(int utmkX, int utmkY, NMapPathLineType lineType, bool controlPoint);

        // -(void)addPathPointUtmkX:(int)utmkX utmkY:(int)utmkY lineType:(NMapPathLineType)lineType;
        [Export("addPathPointUtmkX:utmkY:lineType:")]
        void AddPathPointUtmkX(int utmkX, int utmkY, NMapPathLineType lineType);

        // -(void)addPathPointLongitude:(double)longitude latitude:(double)latitude lineType:(NMapPathLineType)lineType controlPoint:(BOOL)controlPoint;
        [Export("addPathPointLongitude:latitude:lineType:controlPoint:")]
        //void AddPathPointLongitude(double longitude, double latitude, NMapPathLineType lineType, bool controlPoint);
        void AddPathPoint(double longitude, double latitude, NMapPathLineType lineType, bool controlPoint);

        // -(void)addPathPointLongitude:(double)longitude latitude:(double)latitude lineType:(NMapPathLineType)lineType;
        [Export("addPathPointLongitude:latitude:lineType:")]
        //void AddPathPointLongitude(double longitude, double latitude, NMapPathLineType lineType);
        void AddPathPoint(double longitude, double latitude, NMapPathLineType lineType);

        // -(void)endPathData;
        [Export("endPathData")]
        void EndPathData();

        // -(void)endPathDataWithBounds:(NRect)boundsInUtmk;
        [Export("endPathDataWithBounds:")]
        void EndPathDataWithBounds(NRect boundsInUtmk);

        // -(CGPoint)boundsOffset:(NMapView *)mapView;
        [Export("boundsOffset:")]
        CGPoint BoundsOffset(NMapView mapView);

        // -(void)layoutChanged;
        [Export("layoutChanged")]
        void LayoutChanged();
    }

    // @interface NMapPathDataOverlay : NMapOverlay
    [BaseType(typeof(NMapOverlay))]
    interface NMapPathDataOverlay
    {
        // @property (assign, nonatomic) NMapView * mapView;
        [Export("mapView", ArgumentSemantic.Assign)]
        NMapView MapView { get; set; }

        // @property (assign, nonatomic) NMapOverlayManager * mapOverlayManager;
        [Export("mapOverlayManager", ArgumentSemantic.Assign)]
        NMapOverlayManager MapOverlayManager { get; set; }

        [Wrap("WeakPathDataDelegate")]
        NMapPathDataDelegate PathDataDelegate { get; set; }

        // @property (assign, nonatomic) id<NMapPathDataDelegate> pathDataDelegate;
        [NullAllowed, Export("pathDataDelegate", ArgumentSemantic.Assign)]
        NSObject WeakPathDataDelegate { get; set; }

        // @property (getter = isRendered, assign, nonatomic) BOOL rendered;
        [Export("rendered")]
        bool Rendered { [Bind("isRendered")] get; set; }

        // -(id)initWithPathData:(NMapPathData *)pathData;
        [Export("initWithPathData:")]
        IntPtr Constructor(NMapPathData pathData);

        // -(id)initWithPathDataArray:(NSArray *)pathDataArray;
        [Export("initWithPathDataArray:")]
        //[Verify(StronglyTypedNSArray)]
        //IntPtr Constructor(NSObject[] pathDataArray);
        IntPtr Constructor(NMapPathData[] pathDataArray);

        // -(void)setLineWidth:(float)width;
        [Export("setLineWidth:")]
        void SetLineWidth(float width);

        // -(void)setLineColorWithRed:(float)red green:(float)green blue:(float)blue alpha:(float)alpha;
        [Export("setLineColorWithRed:green:blue:alpha:")]
        void SetLineColorWithRed(float red, float green, float blue, float alpha);

        // -(void)addPathData:(NMapPathData *)pathData;
        [Export("addPathData:")]
        void AddPathData(NMapPathData pathData);

        // -(void)addCircleData:(NMapCircleData *)circleData;
        [Export("addCircleData:")]
        void AddCircleData(NMapCircleData circleData);

        // -(void)showAllPathDataAtLevel:(int)zoomLevel;
        [Export("showAllPathDataAtLevel:")]
        void ShowAllPathDataAtLevel(int zoomLevel);

        // -(void)showAllPathData;
        [Export("showAllPathData")]
        void ShowAllPathData();

        // -(BOOL)containsLocation:(NGeoPoint)location;
        [Export("containsLocation:")]
        bool ContainsLocation(NGeoPoint location);
    }

    // @protocol NMapPathDataDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface NMapPathDataDelegate
    {
        // @optional -(void)loadPathData:(NMapPathData *)pathData;
        [Export("loadPathData:")]
        void LoadPathData(NMapPathData pathData);

        // @optional -(void)loadCircleData:(NMapCircleData *)circleData;
        [Export("loadCircleData:")]
        void LoadCircleData(NMapCircleData circleData);
    }

    // @interface NMapRadiusSettingOverlay : NMapOverlay
    [BaseType(typeof(NMapOverlay))]
    interface NMapRadiusSettingOverlay
    {
        // @property (assign, nonatomic) NGeoPoint location;
        [Export("location", ArgumentSemantic.Assign)]
        NGeoPoint Location { get; set; }

        // @property (assign, nonatomic) float radius;
        [Export("radius")]
        float Radius { get; set; }

        // @property (assign, nonatomic) NMapView * mapView;
        [Export("mapView", ArgumentSemantic.Assign)]
        NMapView MapView { get; set; }
    }

    // @interface NMapOverlayManager : NMapOverlay
    //[BaseType(typeof(NMapOverlay))]
    [BaseType(typeof(NMapOverlay),
    Delegates = new string[] { "WeakDelegate" },
    Events = new Type[] { typeof(NMapViewNPOIdataOverlayDelegate) })]
    interface NMapOverlayManager
    {
        // @property (readonly, nonatomic) NMapMyLocationOverlay * myLocationOverlay;
        [Export("myLocationOverlay")]
        NMapMyLocationOverlay MyLocationOverlay { get; }

        // @property (assign, nonatomic) BOOL movePinObject;
        [Export("movePinObject")]
        bool MovePinObject { get; set; }

        // @property (assign, nonatomic) BOOL preventForwordEvent;
        [Export("preventForwordEvent")]
        bool PreventForwordEvent { get; set; }

        // @property (assign, nonatomic) BOOL pinDataMoved;
        [Export("pinDataMoved")]
        bool PinDataMoved { get; set; }

        // @property (assign, nonatomic) BOOL focusedPOIitemMoveToCenter;
        [Export("focusedPOIitemMoveToCenter")]
        bool FocusedPOIitemMoveToCenter { get; set; }

        // @property (assign, nonatomic) BOOL focusedPOIitemHideCallout;
        [Export("focusedPOIitemHideCallout")]
        bool FocusedPOIitemHideCallout { get; set; }

        [NullAllowed, Wrap("WeakDelegate")]
        //NSObject<NMapViewDelegate, NMapPOIdataOverlayDelegate> Delegate { get; set; }
        INMapViewNPOIdataOverlayDelegate Delegate { get; set; }

        // @property (assign, nonatomic) id<NMapViewDelegate,NMapPOIdataOverlayDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        INMapViewNPOIdataOverlayDelegate WeakDelegate { get; set; }

        // @property (assign, nonatomic) CALayer * overlayLayer;
        [Export("overlayLayer", ArgumentSemantic.Assign)]
        CALayer OverlayLayer { get; set; }

        // @property (assign, nonatomic) NMapView * mapView;
        [Export("mapView", ArgumentSemantic.Assign)]
        NMapView MapView { get; set; }

        // -(BOOL)isFocusedPOIitemVisibleExclusively;
        [Export("isFocusedPOIitemVisibleExclusively")]
        bool IsFocusedPOIitemVisibleExclusively { get; }

        // -(void)setFocusedPOIitemVisibleExclusively:(BOOL)enabled;
        [Export("setFocusedPOIitemVisibleExclusively:")]
        void SetFocusedPOIitemVisibleExclusively(bool enabled);

        // -(void)setOverlayVisibleExclusively:(NMapOverlay *)anOverlay enabled:(BOOL)enabled;
        [Export("setOverlayVisibleExclusively:enabled:")]
        void SetOverlayVisibleExclusively(NMapOverlay anOverlay, bool enabled);

        // -(void)addOverlay:(NMapOverlay *)overlay;
        [Export("addOverlay:")]
        void AddOverlay(NMapOverlay overlay);

        // -(void)removeOverlay:(NMapOverlay *)overlay;
        [Export("removeOverlay:")]
        void RemoveOverlay(NMapOverlay overlay);

        // -(void)releaseOverlay:(NMapOverlay *)overlay;
        [Export("releaseOverlay:")]
        void ReleaseOverlay(NMapOverlay overlay);

        // -(BOOL)hasOverlay:(NMapOverlay *)overlay;
        [Export("hasOverlay:")]
        bool HasOverlay(NMapOverlay overlay);

        // -(void)removePOIdataOverlay:(NMapPOIdataOverlay *)overlay;
        [Export("removePOIdataOverlay:")]
        void RemovePOIdataOverlay(NMapPOIdataOverlay overlay);

        // -(void)addPOIdataOverlay:(NMapPOIdataOverlay *)overlay;
        [Export("addPOIdataOverlay:")]
        void AddPOIdataOverlay(NMapPOIdataOverlay overlay);

        // -(void)removePathDataOverlay:(NMapPathDataOverlay *)overlay;
        [Export("removePathDataOverlay:")]
        void RemovePathDataOverlay(NMapPathDataOverlay overlay);

        // -(void)addPathDataOverlayOnly:(NMapPathDataOverlay *)overlay;
        [Export("addPathDataOverlayOnly:")]
        void AddPathDataOverlayOnly(NMapPathDataOverlay overlay);

        // -(NMapPOIdataOverlay *)newPOIdataOverlay;
        [Export("newPOIdataOverlay")]
        NMapPOIdataOverlay NewPOIdataOverlay();// { get; }

        // -(NMapPOIdataOverlay *)newPOIdataOverlay:(BOOL)spreadable;
        [Export("newPOIdataOverlay:")]
        NMapPOIdataOverlay NewPOIdataOverlay(bool spreadable);

        // -(NMapPOIdataOverlay *)newPOIdataOverlay:(BOOL)spreadable zPosition:(NMapOverlayZPosition)zPosition;
        [Export("newPOIdataOverlay:zPosition:")]
        NMapPOIdataOverlay NewPOIdataOverlay(bool spreadable, NMapOverlayZPosition zPosition);

        // -(NMapPathDataOverlay *)newPathDataOverlay:(NMapPathData *)pathData;
        [Export("newPathDataOverlay:")]
        NMapPathDataOverlay NewPathDataOverlay(NMapPathData pathData);

        // -(NMapPathDataOverlay *)newPathDataOverlay:(NMapPathData *)pathData zPosition:(NMapOverlayZPosition)zPosition;
        [Export("newPathDataOverlay:zPosition:")]
        NMapPathDataOverlay NewPathDataOverlay(NMapPathData pathData, NMapOverlayZPosition zPosition);

        // -(NMapPathDataOverlay *)addPathDataOverlay:(NMapPathData *)pathData;
        [Export("addPathDataOverlay:")]
        NMapPathDataOverlay AddPathDataOverlay(NMapPathData pathData);

        // -(NMapPathDataOverlay *)newPathDataArrayOverlay:(NSArray *)pathDataArray;
        [Export("newPathDataArrayOverlay:")]
        //[Verify(StronglyTypedNSArray)]
        NMapPathDataOverlay NewPathDataArrayOverlay(NMapPathData[] pathDataArray);

        // -(NMapPathDataOverlay *)newPathDataArrayOverlay:(NSArray *)pathDataArray zPosition:(NMapOverlayZPosition)zPosition;
        [Export("newPathDataArrayOverlay:zPosition:")]
        //[Verify(StronglyTypedNSArray)]
        NMapPathDataOverlay NewPathDataArrayOverlay(NMapPathData[] pathDataArray, NMapOverlayZPosition zPosition);

        // -(NMapPathDataOverlay *)addPathDataArrayOverlay:(NSArray *)pathDataArray;
        [Export("addPathDataArrayOverlay:")]
        //[Verify(StronglyTypedNSArray)]
        NMapPathDataOverlay AddPathDataArrayOverlay(NMapPathData[] pathDataArray);

        // -(NMapRadiusSettingOverlay *)newRadiusSettingOverlay;
        [Export("newRadiusSettingOverlay")]
        NMapRadiusSettingOverlay NewRadiusSettingOverlay { get; }

        // -(NMapPOIdataOverlay *)createPOIdataOverlay __attribute__((deprecated("use newPOIdataOverlay instead.")));
        [Export("createPOIdataOverlay")]
        //[Verify(MethodToProperty)]
        NMapPOIdataOverlay CreatePOIdataOverlay();// { get; }

        // -(NMapPOIdataOverlay *)createPOIdataOverlay:(BOOL)spreadable __attribute__((deprecated("use newPOIdataOverlay instead.")));
        [Export("createPOIdataOverlay:")]
        NMapPOIdataOverlay CreatePOIdataOverlay(bool spreadable);

        // -(NMapPOIdataOverlay *)createPOIdataOverlay:(BOOL)spreadable zPosition:(NMapOverlayZPosition)zPosition __attribute__((deprecated("use newPOIdataOverlay instead.")));
        [Export("createPOIdataOverlay:zPosition:")]
        NMapPOIdataOverlay CreatePOIdataOverlay(bool spreadable, NMapOverlayZPosition zPosition);

        // -(NMapPathDataOverlay *)createPathDataOverlay:(NMapPathData *)pathData __attribute__((deprecated("use newPathDataOverlay instead.")));
        [Export("createPathDataOverlay:")]
        NMapPathDataOverlay CreatePathDataOverlay(NMapPathData pathData);

        // -(NMapPathDataOverlay *)createPathDataOverlay:(NMapPathData *)pathData zPosition:(NMapOverlayZPosition)zPosition __attribute__((deprecated("use newPathDataOverlay instead.")));
        [Export("createPathDataOverlay:zPosition:")]
        NMapPathDataOverlay CreatePathDataOverlay(NMapPathData pathData, NMapOverlayZPosition zPosition);

        // -(NMapRadiusSettingOverlay *)createRadiusSettingOverlay __attribute__((deprecated("use newRadiusSettingOverlay instead.")));
        [Export("createRadiusSettingOverlay")]
        NMapRadiusSettingOverlay CreateRadiusSettingOverlay { get; }

        // -(NSArray *)overlays;
        [Export("overlays")]
        //[Verify(MethodToProperty), Verify(StronglyTypedNSArray)]
        NMapOverlay[] Overlays { get; }

        // -(void)clearOverlays;
        [Export("clearOverlays")]
        void ClearOverlays();

        // -(void)clearMyLocationOverlay;
        [Export("clearMyLocationOverlay")]
        void ClearMyLocationOverlay();

        // -(void)clearCalloutOverlay;
        [Export("clearCalloutOverlay")]
        void ClearCalloutOverlay();

        // -(NMapPOIdataOverlay *)findFocusedPOIdataOverlay;
        [Export("findFocusedPOIdataOverlay")]
        NMapPOIdataOverlay FindFocusedPOIdataOverlay { get; }

        // -(UIView *)viewForCalloutOverlay;
        [Export("viewForCalloutOverlay")]
        UIView ViewForCalloutOverlay { get; }

        // -(void)setMyLocation:(NGeoPoint)location locationAccuracy:(float)locationAccuracy;
        [Export("setMyLocation:locationAccuracy:")]
        void SetMyLocation(NGeoPoint location, float locationAccuracy);

        // -(BOOL)hasMyLocationOverlay;
        [Export("hasMyLocationOverlay")]
        bool HasMyLocationOverlay { get; }

        // -(BOOL)canRefreshOverlayData;
        [Export("canRefreshOverlayData")]
        bool CanRefreshOverlayData();// { get; }

        // -(BOOL)canRefreshOverlayData:(BOOL)checkCallout;
        [Export("canRefreshOverlayData:")]
        bool CanRefreshOverlayData(bool checkCallout);

        // -(BOOL)hasCalloutOverlay:(NMapPOIdataOverlay *)poiDataOverlay;
        [Export("hasCalloutOverlay:")]
        bool HasCalloutOverlay(NMapPOIdataOverlay poiDataOverlay);

        // -(BOOL)hasCalloutOverlay;
        [Export("hasCalloutOverlay")]
        bool HasCalloutOverlay();// { get; }

        // -(void)beginTransaction;
        [Export("beginTransaction")]
        void BeginTransaction();

        // -(void)endTransaction;
        [Export("endTransaction")]
        void EndTransaction();
    }

    // @interface NMapProjection (NMapView)
    [Category]
    [BaseType(typeof(NMapView))]
    interface NMapView_NMapProjection
    {
        // -(NGeoPoint)fromPoint:(CGPoint)pt;
        [Export("fromPoint:")]
        NGeoPoint FromPoint(CGPoint pt);

        // -(NPoint)fromPointInUtmk:(CGPoint)pt;
        [Export("fromPointInUtmk:")]
        NPoint FromPointInUtmk(CGPoint pt);

        // -(int)metersToPoints:(float)meters;
        [Export("metersToPoints:")]
        int MetersToPoints(float meters);

        // -(int)metersToPoints:(float)meters atLocation:(NGeoPoint)location;
        [Export("metersToPoints:atLocation:")]
        int MetersToPoints(float meters, NGeoPoint location);

        // -(CGPoint)toPointFromLocation:(NGeoPoint)location;
        [Export("toPointFromLocation:")]
        CGPoint ToPointFromLocation(NGeoPoint location);

        // -(CGPoint)toPointFromUtmk:(NPoint)utmk;
        [Export("toPointFromUtmk:")]
        CGPoint ToPointFromUtmk(NPoint utmk);

        // -(NGPoint)toMapPointFromLocation:(NGeoPoint)location;
        [Export("toMapPointFromLocation:")]
        NGPoint ToMapPointFromLocation(NGeoPoint location);

        // -(NGPoint)toMapPointFromUtmk:(NPoint)utmk;
        [Export("toMapPointFromUtmk:")]
        NGPoint ToMapPointFromUtmk(NPoint utmk);

        // -(BOOL)isVisibleLocation:(NGeoPoint)location;
        [Export("isVisibleLocation:")]
        bool IsVisibleLocation(NGeoPoint location);

        // -(NRect)toBoundsInUtmk:(NGeoRect)bounds;
        [Export("toBoundsInUtmk:")]
        NRect ToBoundsInUtmk(NGeoRect bounds);

        // -(NGeoRect)screenBounds;
        //[Static, Export("screenBounds")]
        //NGeoRect ScreenBounds { get; }
        [Export("screenBounds")]
        NGeoRect ScreenBounds();

        // -(NRect)screenBoundsInUtmk;
        //[Static, Export("screenBoundsInUtmk")]
        //NRect ScreenBoundsInUtmk { get; }
        [Export("screenBoundsInUtmk")]
        NRect ScreenBoundsInUtmk();

        // -(NGeoRect)screenBoundsBy:(double)areaRatio;
        [Export("screenBoundsBy:")]
        NGeoRect ScreenBoundsBy(double areaRatio);

        // -(void)setViewPortSize:(CGSize)size;
        [Export("setViewPortSize:")]
        void SetViewPortSize(CGSize size);

        // -(NSize)toSizeInViewPort:(NSize)size;
        [Export("toSizeInViewPort:")]
        NSize ToSizeInViewPort(NSize size);

        // -(BOOL)isProjectionScaled;
        //[Static, Export("isProjectionScaled")]
        //bool IsProjectionScaled { get; }
        [Export("isProjectionScaled")]
        bool IsProjectionScaled();

        // -(CGPoint)toMapPointFromViewPortOffset:(CGPoint)offset;
        [Export("toMapPointFromViewPortOffset:")]
        CGPoint ToMapPointFromViewPortOffset(CGPoint offset);

        // -(NGPoint)toMapPointFromUtmk:(NPoint)utmk atLevel:(int)level viewPort:(NGRect)viewPort;
        [Export("toMapPointFromUtmk:atLevel:viewPort:")]
        NGPoint ToMapPointFromUtmk(NPoint utmk, int level, NGRect viewPort);
    }

    // @interface NMapViewQuartz : UIView
    [BaseType(typeof(UIView))]
    interface NMapViewQuartz
    {
        // @property (readonly, nonatomic) CGFloat scaleFactor;
        [Export("scaleFactor")]
        nfloat ScaleFactor { get; }

        // @property (assign, nonatomic) BOOL isVisibleState;
        [Export("isVisibleState")]
        bool IsVisibleState { get; set; }

        // @property (readonly, nonatomic) CGRect viewFrame;
        [Export("viewFrame")]
        CGRect ViewFrame { get; }

        // @property (readonly, nonatomic) CGRect viewBounds;
        [Export("viewBounds")]
        CGRect ViewBounds { get; }

        // @property (assign, nonatomic) BOOL isAnimating;
        [Export("isAnimating")]
        bool IsAnimating { get; set; }

        // @property (assign, nonatomic) BOOL isPanning;
        [Export("isPanning")]
        bool IsPanning { get; set; }

        // @property (assign, nonatomic) BOOL isPanAnimating;
        [Export("isPanAnimating")]
        bool IsPanAnimating { get; set; }

        // @property (assign, nonatomic) BOOL mapViewAlphaLayerMode;
        [Export("mapViewAlphaLayerMode")]
        bool MapViewAlphaLayerMode { get; set; }

        // -(void)setMapViewAlphaLayerMode:(BOOL)mode withColor:(UIColor * _Nonnull)color;
        [Export("setMapViewAlphaLayerMode:withColor:")]
        void SetMapViewAlphaLayerModeWithColor(bool mode, UIColor color);
    }


    // @interface NMapView : NMapViewQuartz <CAAnimationDelegate>
    [BaseType(typeof(NMapViewQuartz),
              Delegates = new string[] { "WeakDelegate", "WeakReverseGeocoderDelegate" },
              Events = new Type[] { typeof(NMapViewNPOIdataOverlayDelegate), typeof(MMapReverseGeocoderDelegate) })]
    //[BaseType(typeof(NMapViewQuartz))]
    interface NMapView
    {
        //add Constructor : initWithFrame
        [Export("initWithFrame:")]
        IntPtr Constructor(CGRect frame);

        [NullAllowed, Wrap("WeakDelegate")]
        //NSObject<NMapViewDelegate, NMapPOIdataOverlayDelegate> Delegate { get; set; }
        INMapViewNPOIdataOverlayDelegate Delegate { get; set; }

        // @property (assign, nonatomic) id<NMapViewDelegate,NMapPOIdataOverlayDelegate> delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        INMapViewNPOIdataOverlayDelegate WeakDelegate { get; set; }

        [NullAllowed, Wrap("WeakReverseGeocoderDelegate")]
        IMMapReverseGeocoderDelegate ReverseGeocoderDelegate { get; set; }

        // @property (assign, nonatomic) id<MMapReverseGeocoderDelegate> reverseGeocoderDelegate;
        [NullAllowed, Export("reverseGeocoderDelegate", ArgumentSemantic.Assign)]
        IMMapReverseGeocoderDelegate WeakReverseGeocoderDelegate { get; set; }

        // @property (readonly, nonatomic) NMapOverlayManager * mapOverlayManager;
        [Export("mapOverlayManager")]
        NMapOverlayManager MapOverlayManager { get; }

        // @property (readonly, nonatomic) CGRect viewFrameVisible;
        [Export("viewFrameVisible")]
        CGRect ViewFrameVisible { get; }

        // @property (assign, nonatomic) BOOL needsNotifyMapCenterPosition;
        [Export("needsNotifyMapCenterPosition")]
        bool NeedsNotifyMapCenterPosition { get; set; }

        // @property (assign, nonatomic) BOOL zoomToFixingPoint;
        [Export("zoomToFixingPoint")]
        bool ZoomToFixingPoint { get; set; }

        // @property (assign, nonatomic) BOOL panWithTouchMoveEventEnabled;
        [Export("panWithTouchMoveEventEnabled")]
        bool PanWithTouchMoveEventEnabled { get; set; }

        // -(void)setMapCenterAfterInitFinished:(id)ignore;
        [Export("setMapCenterAfterInitFinished:")]
        void SetMapCenterAfterInitFinished(NSObject ignore);

        // +(BOOL)isValidLongitude:(double)lon latitude:(double)lat;
        //[Static]
        [Export("isValidLongitude:latitude:")]
        bool IsValidLongitude(double lon, double lat);

        // +(double)distanceFromLocation:(NGeoPoint)fromLocation toLocation:(NGeoPoint)toLocation;
        //[Static]
        [Export("distanceFromLocation:toLocation:")]
        double DistanceFromLocation(NGeoPoint fromLocation, NGeoPoint toLocation);

        // -(void)setApiKey:(NSString *)apiKey __attribute__((deprecated("open API has been changed. plz, visit developers.naver.com")));
        [Export("setApiKey:")]
        void SetApiKey(string apiKey);

        // -(void)setClientId:(NSString *)clientId;
        [Export("setClientId:")]
        void SetClientId(string clientId);

        // -(void)setAppName:(NSString *)appName;
        [Export("setAppName:")]
        void SetAppName(string appName);

        // -(void)setLogoImageOffsetX:(CGFloat)offsetX offsetY:(CGFloat)offsetY;
        [Export("setLogoImageOffsetX:offsetY:")]
        void SetLogoImageOffsetX(nfloat offsetX, nfloat offsetY);

        // -(void)setBuiltInAppControl:(BOOL)enabled;
        [Export("setBuiltInAppControl:")]
        void SetBuiltInAppControl(bool enabled);

        // -(void)executeNaverMap;
        [Export("executeNaverMap")]
        void ExecuteNaverMap();

        // -(void)reload;
        [Export("reload")]
        void Reload();

        // -(void)invalidate;
        [Export("invalidate")]
        void Invalidate();

        // -(void)viewWillAppear;
        [Export("viewWillAppear")]
        void ViewWillAppear();

        // -(void)viewDidAppear;
        [Export("viewDidAppear")]
        void ViewDidAppear();

        // -(void)viewWillDisappear;
        [Export("viewWillDisappear")]
        void ViewWillDisappear();

        // -(void)viewDidDisappear;
        [Export("viewDidDisappear")]
        void ViewDidDisappear();

        // -(void)didReceiveMemoryWarning;
        [Export("didReceiveMemoryWarning")]
        void DidReceiveMemoryWarning();

        // -(void)notifyMapCenterPosition;
        [Export("notifyMapCenterPosition")]
        void NotifyMapCenterPosition();

        // -(BOOL)hasTouchEvents;
        [Export("hasTouchEvents")]
        bool HasTouchEvents { get; }

        // -(void)viewDidBecomeActive;
        [Export("viewDidBecomeActive")]
        void ViewDidBecomeActive();

        // -(void)viewWillResignActive;
        [Export("viewWillResignActive")]
        void ViewWillResignActive();

        // @interface NMapViewRotation (NMapView)
        // @property (getter = isAutoRotateEnabled, nonatomic) BOOL autoRotateEnabled;
        [Export("autoRotateEnabled")]
        bool AutoRotateEnabled { [Bind("isAutoRotateEnabled")]get; set; }
    }

    // @interface NMapViewRotation (NMapView)
    [Category]
    [BaseType(typeof(NMapView))]
    interface NMapView_NMapViewRotation
    {
        // @property (getter = isAutoRotateEnabled, nonatomic) BOOL autoRotateEnabled;
        //[Static, Export("autoRotateEnabled")]
        //bool AutoRotateEnabled { [Bind("isAutoRotateEnabled")] get; set; }
        //[Export("isAutoRotateEnabled")]
        //bool IsAutoRotateEnabled();

        //[Internal]
        //[Export("setAutoRotateEnabled:")]
        //void _SetAutoRotateEnabled(bool isAutoRotateEnabled);

        // @property (nonatomic) CGFloat rotateAngle;
        //[Static, Export("rotateAngle")]
        //nfloat RotateAngle { get; set; }
        [Export("rotateAngle")]
        nfloat RotateAngle();

        [Export("setRotateAngle:")]
        void SetRotateAngle(nfloat degree);

        // -(void)setAutoRotateEnabled:(BOOL)enabled animate:(BOOL)animate;
        [Export("setAutoRotateEnabled:animate:")]
        void SetAutoRotateEnabled(bool enabled, bool animate);

        // -(void)setRotateAngle:(float)degree animate:(BOOL)animate;
        [Export("setRotateAngle:animate:")]
        void SetRotateAngle(float degree, bool animate);
    }

    // @interface MMapReverseGeocoder (NMapView)
    [Category]
    [BaseType(typeof(NMapView))]
    interface NMapView_MMapReverseGeocoder
    {
        // -(void)findPlacemarkAtLocation:(NGeoPoint)location;
        [Export("findPlacemarkAtLocation:")]
        void FindPlacemarkAtLocation(NGeoPoint location);
    }

    // @protocol NMapViewDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface NMapViewDelegate
    {
        // @required -(void)onMapView:(NMapView *)mapView initHandler:(NMapError *)error;
        [Abstract]
        [Export("onMapView:initHandler:")]
        void OnMapView(NMapView mapView, NMapError error);

        // @optional -(void)onMapView:(NMapView *)mapView willChangeMapLevel:(int)toLevel;
        [Export("onMapView:willChangeMapLevel:")]
        //void OnMapView(NMapView mapView, int toLevel);
        void OnMapViewWillChangeMapLevel(NMapView mapView, int toLevel);

        // @optional -(void)onMapView:(NMapView *)mapView didChangeMapLevel:(int)level;
        [Export("onMapView:didChangeMapLevel:")]
        //void OnMapView(NMapView mapView, int level);
        void OnMapViewDidChangeMapLevel(NMapView mapView, int level);

        // @optional -(void)onMapView:(NMapView *)mapView didChangeViewStatus:(NMapViewStatus)status;
        [Export("onMapView:didChangeViewStatus:")]
        //void OnMapView(NMapView mapView, NMapViewStatus status);
        void OnMapViewDidBhangeViewStatus(NMapView mapView, NMapViewStatus status);

        // @optional -(void)onMapView:(NMapView *)mapView didChangeMapCenter:(NGeoPoint)location;
        [Export("onMapView:didChangeMapCenter:")]
        //void OnMapView(NMapView mapView, NGeoPoint location);
        void OnMapViewDidChangeMapCenter(NMapView mapView, NGeoPoint location);

        // @optional -(void)onMapView:(NMapView *)mapView didChangeMapCenterFine:(NGeoPoint)location;
        [Export("onMapView:didChangeMapCenterFine:")]
        //void OnMapView(NMapView mapView, NGeoPoint location);
        void OnMapViewDidChangeMapCenterFine(NMapView mapView, NGeoPoint location);

        // @optional -(void)onMapView:(NMapView *)mapView touchesBegan:(NSSet *)touches withEvent:(UIEvent *)event;
        [Export("onMapView:touchesBegan:withEvent:")]
        void OnMapViewTouchesBegan(NMapView mapView, NSSet touches, UIEvent @event);
        //void OnMapView(NMapView mapView, NSSet touches, UIEvent @event);

        // @optional -(void)onMapView:(NMapView *)mapView touchesMoved:(NSSet *)touches withEvent:(UIEvent *)event;
        [Export("onMapView:touchesMoved:withEvent:")]
        void OnMapViewTouchesMoved(NMapView mapView, NSSet touches, UIEvent @event);
        //void OnMapView(NMapView mapView, NSSet touches, UIEvent @event);

        // @optional -(void)onMapView:(NMapView *)mapView touchesEnded:(NSSet *)touches withEvent:(UIEvent *)event;
        [Export("onMapView:touchesEnded:withEvent:")]
        void OnMapViewTouchesEnded(NMapView mapView, NSSet touches, UIEvent @event);
        //void OnMapView(NMapView mapView, NSSet touches, UIEvent @event);

        // @optional -(void)onMapViewTouchesCanceled:(NMapView *)mapView;
        [Export("onMapViewTouchesCanceled:")]
        void OnMapViewTouchesCanceled(NMapView mapView);

        // @optional -(BOOL)onMapView:(NMapView *)mapView dispatchTouchesBeganPoint:(CGPoint)touchPoint withFrame:(CGRect)frame;
        [Export("onMapView:dispatchTouchesBeganPoint:withFrame:")]
        bool OnMapViewDispatchTouchesBeganPoint(NMapView mapView, CGPoint touchPoint, CGRect frame);
        //bool OnMapView(NMapView mapView, CGPoint touchPoint, CGRect frame);

        // @optional -(BOOL)onMapView:(NMapView *)mapView dispatchTouchesBeganPoint:(CGPoint)touchPoint;
        [Export("onMapView:dispatchTouchesBeganPoint:")]
        //bool OnMapView(NMapView mapView, CGPoint touchPoint);
        bool OnMapViewDispatchTouchesBeganPoint(NMapView mapView, CGPoint touchPoint);

        // @optional -(void)onMapView:(NMapView *)mapView dispatchTouchesMovedPoint:(CGPoint)touchPoint;
        [Export("onMapView:dispatchTouchesMovedPoint:")]
        //void OnMapView(NMapView mapView, CGPoint touchPoint);
        void OnMapViewDispatchTouchesMovedPoint(NMapView mapView, CGPoint touchPoint);

        // @optional -(void)onMapView:(NMapView *)mapView dispatchTouchesEndedPoint:(CGPoint)touchPoint;
        [Export("onMapView:dispatchTouchesEndedPoint:")]
        //void OnMapView(NMapView mapView, CGPoint touchPoint);
        void OnMapViewDispatchTouchesEndedPoint(NMapView mapView, CGPoint touchPoint);

        // @optional -(void)onMapViewDispatchTouchesCancelled:(NMapView *)mapView;
        [Export("onMapViewDispatchTouchesCancelled:")]
        void OnMapViewDispatchTouchesCancelled(NMapView mapView);

        // @optional -(void)onMapView:(NMapView *)mapView forwardTouchesBegan:(NSSet *)touches withEvent:(UIEvent *)event;
        [Export("onMapView:forwardTouchesBegan:withEvent:")]
        //void OnMapView(NMapView mapView, NSSet touches, UIEvent @event);
        void OnMapViewForwardTouchesBegan(NMapView mapView, NSSet touches, UIEvent @event);

        // @optional -(void)onMapView:(NMapView *)mapView forwardTouchesEnded:(NSSet *)touches withEvent:(UIEvent *)event;
        [Export("onMapView:forwardTouchesEnded:withEvent:")]
        //void OnMapView(NMapView mapView, NSSet touches, UIEvent @event);
        void OnMapViewForwardTouchesEnded(NMapView mapView, NSSet touches, UIEvent @event);

        // @optional -(void)onMapView:(NMapView *)mapView handleLongPressGesture:(UIGestureRecognizer *)recogniser;
        [Export("onMapView:handleLongPressGesture:")]
        //void OnMapView(NMapView mapView, UIGestureRecognizer recogniser);
        void OnMapViewHandleLongPressGesture(NMapView mapView, UIGestureRecognizer recogniser);

        // @optional -(void)onMapView:(NMapView *)mapView handleSingleTapGesture:(UIGestureRecognizer *)recogniser;
        [Export("onMapView:handleSingleTapGesture:")]
        //void OnMapView(NMapView mapView, UIGestureRecognizer recogniser);
        void OnMapViewHandleSingleTapGesture(NMapView mapView, UIGestureRecognizer recogniser);

        // @optional -(void)onMapView:(NMapView *)mapView didHandleSingleTapGesture:(UIGestureRecognizer *)recogniser;
        [Export("onMapView:didHandleSingleTapGesture:")]
        //void OnMapView(NMapView mapView, UIGestureRecognizer recogniser);
        void OnMapViewDidHandleSingleTapGesture(NMapView mapView, UIGestureRecognizer recogniser);

        // @optional -(BOOL)onMapViewIsGPSTracking:(NMapView *)mapView;
        [Export("onMapViewIsGPSTracking:")]
        bool OnMapViewIsGPSTracking(NMapView mapView);

        // @optional -(void)onMapView:(NMapView *)mapView willAppearSpreadPinsAtPage:(int)pageIdx pinCountPerPage:(int)pagingCount totalPinCount:(int)totalCount;
        [Export("onMapView:willAppearSpreadPinsAtPage:pinCountPerPage:totalPinCount:")]
        //void OnMapView(NMapView mapView, int pageIdx, int pagingCount, int totalCount);
        void OnMapViewWillAppearSpreadPinsAtPage(NMapView mapView, int pageIdx, int pagingCount, int totalCount);
        // @optional -(void)onMapView:(NMapView *)mapView willDisappearSpreadPinsAtPage:(int)pageIdx;
        [Export("onMapView:willDisappearSpreadPinsAtPage:")]
        //void OnMapView(NMapView mapView, int pageIdx);
        void OnMapViewWillDisappearSpreadPinsAtPage(NMapView mapView, int pageIdx);

        // @optional -(void)onMapView:(NMapView *)mapView networkActivityIndicatorVisible:(BOOL)visible;
        [Export("onMapView:networkActivityIndicatorVisible:")]
        //void OnMapView(NMapView mapView, bool visible);
        void OnMapViewNetworkActivityIndicatorVisible(NMapView mapView, bool visible);

        // @optional -(void)onMapViewDidChangeTrafficVersion:(NMapView *)mapView;
        [Export("onMapViewDidChangeTrafficVersion:")]
        void OnMapViewDidChangeTrafficVersion(NMapView mapView);
    }

    //Empty NMapViewDelete Interface
    interface INMapViewDelegate { }

    [Protocol, Model, Preserve]
    [BaseType(typeof(NSObject))]
    interface NMapViewNPOIdataOverlayDelegate : NMapViewDelegate, NMapPOIdataOverlayDelegate
    {

    }

    //Empty NMapViewNPOIdataOverlayDelegate Interface
    interface INMapViewNPOIdataOverlayDelegate { }
}
