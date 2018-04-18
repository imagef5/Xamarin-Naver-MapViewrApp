using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace NMapViewerSDK.iOS
{
    public partial class NMapView_NMapController
    {
        [Export("mapCenter")]
        public static NGeoPoint MapCenter(this NMapView This)
        {
            NGeoPoint ret;
            if (Runtime.Arch == Arch.DEVICE)
            {
                if (IntPtr.Size == 8)
                {
                    ret = global::NMapViewerSDK.iOS.Messaging.NGeoPoint_objc_msgSend(This.Handle, Selector.GetHandle("mapCenter"));
                }
                else
                {
                    global::NMapViewerSDK.iOS.Messaging.NGeoPoint_objc_msgSend_stret(out ret, This.Handle, Selector.GetHandle("mapCenter"));
                }
            }
            else if (IntPtr.Size == 8)
            {
                ret = global::NMapViewerSDK.iOS.Messaging.NGeoPoint_objc_msgSend(This.Handle, Selector.GetHandle("mapCenter"));
            }
            else
            {
                global::NMapViewerSDK.iOS.Messaging.NGeoPoint_objc_msgSend_stret(out ret, This.Handle, Selector.GetHandle("mapCenter"));
            }
            return ret;
        }

        [Export("mapBoundsCenter")]
        public static NGeoPoint MapBoundsCenter(this NMapView This)
        {
            NGeoPoint ret;
            if (Runtime.Arch == Arch.DEVICE)
            {
                if (IntPtr.Size == 8)
                {
                    ret = global::NMapViewerSDK.iOS.Messaging.NGeoPoint_objc_msgSend(This.Handle, Selector.GetHandle("mapBoundsCenter"));
                }
                else
                {
                    global::NMapViewerSDK.iOS.Messaging.NGeoPoint_objc_msgSend_stret(out ret, This.Handle, Selector.GetHandle("mapBoundsCenter"));
                }
            }
            else if (IntPtr.Size == 8)
            {
                ret = global::NMapViewerSDK.iOS.Messaging.NGeoPoint_objc_msgSend(This.Handle, Selector.GetHandle("mapBoundsCenter"));
            }
            else
            {
                global::NMapViewerSDK.iOS.Messaging.NGeoPoint_objc_msgSend_stret(out ret, This.Handle, Selector.GetHandle("mapBoundsCenter"));
            }
            return ret;
        }

        [Export("boundsVisible")]
        public static CGRect BoundsVisible(this NMapView This)
        {
            CGRect ret;
            if (Runtime.Arch == Arch.DEVICE)
            {
                if (IntPtr.Size == 8)
                {
                    ret = global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSend(This.Handle, Selector.GetHandle("boundsVisible"));
                }
                else
                {
                    global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSend_stret(out ret, This.Handle, Selector.GetHandle("boundsVisible"));
                }
            }
            else if (IntPtr.Size == 8)
            {
                global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSend_stret(out ret, This.Handle, Selector.GetHandle("boundsVisible"));
            }
            else
            {
                global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSend_stret(out ret, This.Handle, Selector.GetHandle("boundsVisible"));
            }
            return ret;
        }

        [Export("mapBoundsCenterInUtmkX")]
        public static NPoint MapBoundsCenterInUtmkX(this NMapView This)
        {
            NPoint ret;
            if (Runtime.Arch == Arch.DEVICE)
            {
                if (IntPtr.Size == 8)
                {
                    ret = global::NMapViewerSDK.iOS.Messaging.NPoint_objc_msgSend(This.Handle, Selector.GetHandle("mapBoundsCenterInUtmkX"));
                }
                else
                {
                    global::NMapViewerSDK.iOS.Messaging.NPoint_objc_msgSend_stret(out ret, This.Handle, Selector.GetHandle("mapBoundsCenterInUtmkX"));
                }
            }
            else if (IntPtr.Size == 8)
            {
                ret = global::NMapViewerSDK.iOS.Messaging.NPoint_objc_msgSend(This.Handle, Selector.GetHandle("mapBoundsCenterInUtmkX"));
            }
            else
            {
                ret = global::NMapViewerSDK.iOS.Messaging.NPoint_objc_msgSend(This.Handle, Selector.GetHandle("mapBoundsCenterInUtmkX"));
            }
            return ret;
        }

        [Export("mapCenterInUtmkX")]
        public static NPoint MapCenterInUtmkX(this NMapView This)
        {
            NPoint ret;
            if (Runtime.Arch == Arch.DEVICE)
            {
                if (IntPtr.Size == 8)
                {
                    ret = global::NMapViewerSDK.iOS.Messaging.NPoint_objc_msgSend(This.Handle, Selector.GetHandle("mapCenterInUtmkX"));
                }
                else
                {
                    global::NMapViewerSDK.iOS.Messaging.NPoint_objc_msgSend_stret(out ret, This.Handle, Selector.GetHandle("mapCenterInUtmkX"));
                }
            }
            else if (IntPtr.Size == 8)
            {
                ret = global::NMapViewerSDK.iOS.Messaging.NPoint_objc_msgSend(This.Handle, Selector.GetHandle("mapCenterInUtmkX"));
            }
            else
            {
                ret = global::NMapViewerSDK.iOS.Messaging.NPoint_objc_msgSend(This.Handle, Selector.GetHandle("mapCenterInUtmkX"));
            }
            return ret;
        }

        [Export("viewPort")]
        public static NGRect ViewPort(this NMapView This)
        {
            NGRect ret;
            if (Runtime.Arch == Arch.DEVICE)
            {
                if (IntPtr.Size == 8)
                {
                    ret = global::NMapViewerSDK.iOS.Messaging.NGRect_objc_msgSend(This.Handle, Selector.GetHandle("viewPort"));
                }
                else
                {
                    global::NMapViewerSDK.iOS.Messaging.NGRect_objc_msgSend_stret(out ret, This.Handle, Selector.GetHandle("viewPort"));
                }
            }
            else if (IntPtr.Size == 8)
            {
                ret = global::NMapViewerSDK.iOS.Messaging.NGRect_objc_msgSend(This.Handle, Selector.GetHandle("viewPort"));
            }
            else
            {
                global::NMapViewerSDK.iOS.Messaging.NGRect_objc_msgSend_stret(out ret, This.Handle, Selector.GetHandle("viewPort"));
            }
            return ret;
        }
    }
}
