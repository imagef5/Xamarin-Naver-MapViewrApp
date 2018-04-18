using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace NMapViewerSDK.iOS
{
    public partial class NMapView_NMapProjection
    {
        [Export("fromPoint:")]
        public static NGeoPoint FromPoint(this NMapView This, CGPoint pt)
        {
            NGeoPoint ret;
            if (Runtime.Arch == Arch.DEVICE)
            {
                if (IntPtr.Size == 8)
                {
                    ret = global::NMapViewerSDK.iOS.Messaging.NGeoPoint_objc_msgSend_CGPoint(This.Handle, Selector.GetHandle("fromPoint:"), pt);
                }
                else
                {
                    global::NMapViewerSDK.iOS.Messaging.NGeoPoint_objc_msgSend_stret_CGPoint(out ret, This.Handle, Selector.GetHandle("fromPoint:"), pt);
                }
            }
            else if (IntPtr.Size == 8)
            {
                ret = global::NMapViewerSDK.iOS.Messaging.NGeoPoint_objc_msgSend_CGPoint(This.Handle, Selector.GetHandle("fromPoint:"), pt);
            }
            else
            {
                global::NMapViewerSDK.iOS.Messaging.NGeoPoint_objc_msgSend_stret_CGPoint(out ret, This.Handle, Selector.GetHandle("fromPoint:"), pt);
            }
            return ret;
        }

        [Export("fromPointInUtmk:")]
        public static NPoint FromPointInUtmk(this NMapView This, CGPoint pt)
        {
            NPoint ret;
            if (Runtime.Arch == Arch.DEVICE)
            {
                if (IntPtr.Size == 8)
                {
                    ret = global::NMapViewerSDK.iOS.Messaging.NPoint_objc_msgSend_CGPoint(This.Handle, Selector.GetHandle("fromPointInUtmk:"), pt);
                }
                else
                {
                    global::NMapViewerSDK.iOS.Messaging.NPoint_objc_msgSend_stret_CGPoint(out ret, This.Handle, Selector.GetHandle("fromPointInUtmk:"), pt);
                }
            }
            else if (IntPtr.Size == 8)
            {
                ret = global::NMapViewerSDK.iOS.Messaging.NPoint_objc_msgSend_CGPoint(This.Handle, Selector.GetHandle("fromPointInUtmk:"), pt);
            }
            else
            {
                ret = global::NMapViewerSDK.iOS.Messaging.NPoint_objc_msgSend_CGPoint(This.Handle, Selector.GetHandle("fromPointInUtmk:"), pt);
            }
            return ret;
        }

        [Export("toPointFromLocation:")]
        public static CGPoint ToPointFromLocation(this NMapView This, NGeoPoint location)
        {
            CGPoint ret;
            if (Runtime.Arch == Arch.DEVICE)
            {
                if (IntPtr.Size == 8)
                {
                    ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend_NGeoPoint(This.Handle, Selector.GetHandle("toPointFromLocation:"), location);
                }
                else
                {
                    global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend_stret_NGeoPoint(out ret, This.Handle, Selector.GetHandle("toPointFromLocation:"), location);
                }
            }
            else if (IntPtr.Size == 8)
            {
                ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend_NGeoPoint(This.Handle, Selector.GetHandle("toPointFromLocation:"), location);
            }
            else
            {
                ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend_NGeoPoint(This.Handle, Selector.GetHandle("toPointFromLocation:"), location);
            }
            return ret;
        }

        [Export("toPointFromUtmk:")]
        public static CGPoint ToPointFromUtmk(this NMapView This, NPoint utmk)
        {
            CGPoint ret;
            if (Runtime.Arch == Arch.DEVICE)
            {
                if (IntPtr.Size == 8)
                {
                    ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend_NPoint(This.Handle, Selector.GetHandle("toPointFromUtmk:"), utmk);
                }
                else
                {
                    global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend_stret_NPoint(out ret, This.Handle, Selector.GetHandle("toPointFromUtmk:"), utmk);
                }
            }
            else if (IntPtr.Size == 8)
            {
                ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend_NPoint(This.Handle, Selector.GetHandle("toPointFromUtmk:"), utmk);
            }
            else
            {
                ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend_NPoint(This.Handle, Selector.GetHandle("toPointFromUtmk:"), utmk);
            }
            return ret;
        }

        [Export("toMapPointFromLocation:")]
        public static NGPoint ToMapPointFromLocation(this NMapView This, NGeoPoint location)
        {
            NGPoint ret;
            if (Runtime.Arch == Arch.DEVICE)
            {
                if (IntPtr.Size == 8)
                {
                    ret = global::NMapViewerSDK.iOS.Messaging.NGPoint_objc_msgSend_NGeoPoint(This.Handle, Selector.GetHandle("toMapPointFromLocation:"), location);
                }
                else
                {
                    global::NMapViewerSDK.iOS.Messaging.NGPoint_objc_msgSend_stret_NGeoPoint(out ret, This.Handle, Selector.GetHandle("toMapPointFromLocation:"), location);
                }
            }
            else if (IntPtr.Size == 8)
            {
                ret = global::NMapViewerSDK.iOS.Messaging.NGPoint_objc_msgSend_NGeoPoint(This.Handle, Selector.GetHandle("toMapPointFromLocation:"), location);
            }
            else
            {
                ret = global::NMapViewerSDK.iOS.Messaging.NGPoint_objc_msgSend_NGeoPoint(This.Handle, Selector.GetHandle("toMapPointFromLocation:"), location);
            }
            return ret;
        }

        [Export("toMapPointFromUtmk:")]
        public static NGPoint ToMapPointFromUtmk(this NMapView This, NPoint utmk)
        {
            NGPoint ret;
            if (Runtime.Arch == Arch.DEVICE)
            {
                if (IntPtr.Size == 8)
                {
                    ret = global::NMapViewerSDK.iOS.Messaging.NGPoint_objc_msgSend_NPoint(This.Handle, Selector.GetHandle("toMapPointFromUtmk:"), utmk);
                }
                else
                {
                    global::NMapViewerSDK.iOS.Messaging.NGPoint_objc_msgSend_stret_NPoint(out ret, This.Handle, Selector.GetHandle("toMapPointFromUtmk:"), utmk);
                }
            }
            else if (IntPtr.Size == 8)
            {
                ret = global::NMapViewerSDK.iOS.Messaging.NGPoint_objc_msgSend_NPoint(This.Handle, Selector.GetHandle("toMapPointFromUtmk:"), utmk);
            }
            else
            {
                ret = global::NMapViewerSDK.iOS.Messaging.NGPoint_objc_msgSend_NPoint(This.Handle, Selector.GetHandle("toMapPointFromUtmk:"), utmk);
            }
            return ret;
        }

        [Export("toBoundsInUtmk:")]
        public static NRect ToBoundsInUtmk(this NMapView This, NGeoRect bounds)
        {
            NRect ret;
            if (Runtime.Arch == Arch.DEVICE)
            {
                if (IntPtr.Size == 8)
                {
                    ret = global::NMapViewerSDK.iOS.Messaging.NRect_objc_msgSend_NGeoRect(This.Handle, Selector.GetHandle("toBoundsInUtmk:"), bounds);
                }
                else
                {
                    global::NMapViewerSDK.iOS.Messaging.NRect_objc_msgSend_stret_NGeoRect(out ret, This.Handle, Selector.GetHandle("toBoundsInUtmk:"), bounds);
                }
            }
            else if (IntPtr.Size == 8)
            {
                ret = global::NMapViewerSDK.iOS.Messaging.NRect_objc_msgSend_NGeoRect(This.Handle, Selector.GetHandle("toBoundsInUtmk:"), bounds);
            }
            else
            {
                global::NMapViewerSDK.iOS.Messaging.NRect_objc_msgSend_stret_NGeoRect(out ret, This.Handle, Selector.GetHandle("toBoundsInUtmk:"), bounds);
            }
            return ret;
        }

        [Export("screenBounds")]
        public static NGeoRect ScreenBounds(this NMapView This)
        {
            NGeoRect ret;
            if (Runtime.Arch == Arch.DEVICE)
            {
                if (IntPtr.Size == 8)
                {
                    ret = global::NMapViewerSDK.iOS.Messaging.NGeoRect_objc_msgSend(This.Handle, Selector.GetHandle("screenBounds"));
                }
                else
                {
                    global::NMapViewerSDK.iOS.Messaging.NGeoRect_objc_msgSend_stret(out ret, This.Handle, Selector.GetHandle("screenBounds"));
                }
            }
            else if (IntPtr.Size == 8)
            {
                global::NMapViewerSDK.iOS.Messaging.NGeoRect_objc_msgSend_stret(out ret, This.Handle, Selector.GetHandle("screenBounds"));
            }
            else
            {
                global::NMapViewerSDK.iOS.Messaging.NGeoRect_objc_msgSend_stret(out ret, This.Handle, Selector.GetHandle("screenBounds"));
            }
            return ret;
        }

        [Export("screenBoundsInUtmk")]
        public static NRect ScreenBoundsInUtmk(this NMapView This)
        {
            NRect ret;
            if (Runtime.Arch == Arch.DEVICE)
            {
                if (IntPtr.Size == 8)
                {
                    ret = global::NMapViewerSDK.iOS.Messaging.NRect_objc_msgSend(This.Handle, Selector.GetHandle("screenBoundsInUtmk"));
                }
                else
                {
                    global::NMapViewerSDK.iOS.Messaging.NRect_objc_msgSend_stret(out ret, This.Handle, Selector.GetHandle("screenBoundsInUtmk"));
                }
            }
            else if (IntPtr.Size == 8)
            {
                ret = global::NMapViewerSDK.iOS.Messaging.NRect_objc_msgSend(This.Handle, Selector.GetHandle("screenBoundsInUtmk"));
            }
            else
            {
                global::NMapViewerSDK.iOS.Messaging.NRect_objc_msgSend_stret(out ret, This.Handle, Selector.GetHandle("screenBoundsInUtmk"));
            }
            return ret;
        }

        [Export("screenBoundsBy:")]
        public static NGeoRect ScreenBoundsBy(this NMapView This, double areaRatio)
        {
            NGeoRect ret;
            if (Runtime.Arch == Arch.DEVICE)
            {
                if (IntPtr.Size == 8)
                {
                    ret = global::NMapViewerSDK.iOS.Messaging.NGeoRect_objc_msgSend_Double(This.Handle, Selector.GetHandle("screenBoundsBy:"), areaRatio);
                }
                else
                {
                    global::NMapViewerSDK.iOS.Messaging.NGeoRect_objc_msgSend_stret_Double(out ret, This.Handle, Selector.GetHandle("screenBoundsBy:"), areaRatio);
                }
            }
            else if (IntPtr.Size == 8)
            {
                global::NMapViewerSDK.iOS.Messaging.NGeoRect_objc_msgSend_stret_Double(out ret, This.Handle, Selector.GetHandle("screenBoundsBy:"), areaRatio);
            }
            else
            {
                global::NMapViewerSDK.iOS.Messaging.NGeoRect_objc_msgSend_stret_Double(out ret, This.Handle, Selector.GetHandle("screenBoundsBy:"), areaRatio);
            }
            return ret;
        }

        [Export("toSizeInViewPort:")]
        public static NSize ToSizeInViewPort(this NMapView This, NSize size)
        {
            NSize ret;
            if (Runtime.Arch == Arch.DEVICE)
            {
                if (IntPtr.Size == 8)
                {
                    ret = global::NMapViewerSDK.iOS.Messaging.NSize_objc_msgSend_NSize(This.Handle, Selector.GetHandle("toSizeInViewPort:"), size);
                }
                else
                {
                    global::NMapViewerSDK.iOS.Messaging.NSize_objc_msgSend_stret_NSize(out ret, This.Handle, Selector.GetHandle("toSizeInViewPort:"), size);
                }
            }
            else if (IntPtr.Size == 8)
            {
                ret = global::NMapViewerSDK.iOS.Messaging.NSize_objc_msgSend_NSize(This.Handle, Selector.GetHandle("toSizeInViewPort:"), size);
            }
            else
            {
                ret = global::NMapViewerSDK.iOS.Messaging.NSize_objc_msgSend_NSize(This.Handle, Selector.GetHandle("toSizeInViewPort:"), size);
            }
            return ret;
        }

        [Export("toMapPointFromViewPortOffset:")]
        public static CGPoint ToMapPointFromViewPortOffset(this NMapView This, CGPoint offset)
        {
            CGPoint ret;
            if (Runtime.Arch == Arch.DEVICE)
            {
                if (IntPtr.Size == 8)
                {
                    ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend_CGPoint(This.Handle, Selector.GetHandle("toMapPointFromViewPortOffset:"), offset);
                }
                else
                {
                    global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend_stret_CGPoint(out ret, This.Handle, Selector.GetHandle("toMapPointFromViewPortOffset:"), offset);
                }
            }
            else if (IntPtr.Size == 8)
            {
                ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend_CGPoint(This.Handle, Selector.GetHandle("toMapPointFromViewPortOffset:"), offset);
            }
            else
            {
                ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend_CGPoint(This.Handle, Selector.GetHandle("toMapPointFromViewPortOffset:"), offset);
            }
            return ret;
        }

        [Export("toMapPointFromUtmk:atLevel:viewPort:")]
        public static NGPoint ToMapPointFromUtmk(this NMapView This, NPoint utmk, int level, NGRect viewPort)
        {
            NGPoint ret;
            if (Runtime.Arch == Arch.DEVICE)
            {
                if (IntPtr.Size == 8)
                {
                    ret = global::NMapViewerSDK.iOS.Messaging.NGPoint_objc_msgSend_NPoint_int_NGRect(This.Handle, Selector.GetHandle("toMapPointFromUtmk:atLevel:viewPort:"), utmk, level, viewPort);
                }
                else
                {
                    global::NMapViewerSDK.iOS.Messaging.NGPoint_objc_msgSend_stret_NPoint_int_NGRect(out ret, This.Handle, Selector.GetHandle("toMapPointFromUtmk:atLevel:viewPort:"), utmk, level, viewPort);
                }
            }
            else if (IntPtr.Size == 8)
            {
                ret = global::NMapViewerSDK.iOS.Messaging.NGPoint_objc_msgSend_NPoint_int_NGRect(This.Handle, Selector.GetHandle("toMapPointFromUtmk:atLevel:viewPort:"), utmk, level, viewPort);
            }
            else
            {
                ret = global::NMapViewerSDK.iOS.Messaging.NGPoint_objc_msgSend_NPoint_int_NGRect(This.Handle, Selector.GetHandle("toMapPointFromUtmk:atLevel:viewPort:"), utmk, level, viewPort);
            }
            return ret;
        }
    }
}
