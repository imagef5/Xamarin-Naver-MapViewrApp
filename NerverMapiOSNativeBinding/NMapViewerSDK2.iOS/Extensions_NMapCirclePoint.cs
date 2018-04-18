using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace NMapViewerSDK.iOS
{
    public partial class NMapCirclePoint
    {
        public NGeoPoint CenterPoint
        {
            [Export("centerPoint")]
            get
            {
                NGeoPoint ret;
                if (IsDirectBinding)
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.NGeoPoint_objc_msgSend(this.Handle, Selector.GetHandle("centerPoint"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.NGeoPoint_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("centerPoint"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.NGeoPoint_objc_msgSend(this.Handle, Selector.GetHandle("centerPoint"));
                    }
                    else
                    {
                        global::NMapViewerSDK.iOS.Messaging.NGeoPoint_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("centerPoint"));
                    }
                }
                else
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.NGeoPoint_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("centerPoint"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.NGeoPoint_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("centerPoint"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.NGeoPoint_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("centerPoint"));
                    }
                    else
                    {
                        global::NMapViewerSDK.iOS.Messaging.NGeoPoint_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("centerPoint"));
                    }
                }
                return ret;
            }

        }

        public NPoint CenterPointInUtmk
        {
            [Export("centerPointInUtmk")]
            get
            {
                NPoint ret;
                if (IsDirectBinding)
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.NPoint_objc_msgSend(this.Handle, Selector.GetHandle("centerPointInUtmk"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.NPoint_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("centerPointInUtmk"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.NPoint_objc_msgSend(this.Handle, Selector.GetHandle("centerPointInUtmk"));
                    }
                    else
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.NPoint_objc_msgSend(this.Handle, Selector.GetHandle("centerPointInUtmk"));
                    }
                }
                else
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.NPoint_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("centerPointInUtmk"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.NPoint_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("centerPointInUtmk"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.NPoint_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("centerPointInUtmk"));
                    }
                    else
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.NPoint_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("centerPointInUtmk"));
                    }
                }
                return ret;
            }

        }

        [Export("screenPosition:viewPortOrigin:")]
        public virtual CGPoint ScreenPosition(NMapView mapView, NGRect viewPortOrigin)
        {
            if (mapView == null)
                throw new ArgumentNullException("mapView");
            CGPoint ret;
            if (IsDirectBinding)
            {
                if (Runtime.Arch == Arch.DEVICE)
                {
                    if (IntPtr.Size == 8)
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend_IntPtr_NGRect(this.Handle, Selector.GetHandle("screenPosition:viewPortOrigin:"), mapView.Handle, viewPortOrigin);
                    }
                    else
                    {
                        global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend_stret_IntPtr_NGRect(out ret, this.Handle, Selector.GetHandle("screenPosition:viewPortOrigin:"), mapView.Handle, viewPortOrigin);
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend_IntPtr_NGRect(this.Handle, Selector.GetHandle("screenPosition:viewPortOrigin:"), mapView.Handle, viewPortOrigin);
                }
                else
                {
                    ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend_IntPtr_NGRect(this.Handle, Selector.GetHandle("screenPosition:viewPortOrigin:"), mapView.Handle, viewPortOrigin);
                }
            }
            else
            {
                if (Runtime.Arch == Arch.DEVICE)
                {
                    if (IntPtr.Size == 8)
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSendSuper_IntPtr_NGRect(this.SuperHandle, Selector.GetHandle("screenPosition:viewPortOrigin:"), mapView.Handle, viewPortOrigin);
                    }
                    else
                    {
                        global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSendSuper_stret_IntPtr_NGRect(out ret, this.SuperHandle, Selector.GetHandle("screenPosition:viewPortOrigin:"), mapView.Handle, viewPortOrigin);
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSendSuper_IntPtr_NGRect(this.SuperHandle, Selector.GetHandle("screenPosition:viewPortOrigin:"), mapView.Handle, viewPortOrigin);
                }
                else
                {
                    ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSendSuper_IntPtr_NGRect(this.SuperHandle, Selector.GetHandle("screenPosition:viewPortOrigin:"), mapView.Handle, viewPortOrigin);
                }
            }
            return ret;
        }
    }
}
