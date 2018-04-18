using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace NMapViewerSDK.iOS
{
    public partial class NMapPathData
    {
        public NGRect ViewPortOrigin
        {
            [Export("viewPortOrigin")]
            get
            {
                NGRect ret;
                if (IsDirectBinding)
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.NGRect_objc_msgSend(this.Handle, Selector.GetHandle("viewPortOrigin"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.NGRect_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("viewPortOrigin"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.NGRect_objc_msgSend(this.Handle, Selector.GetHandle("viewPortOrigin"));
                    }
                    else
                    {
                        global::NMapViewerSDK.iOS.Messaging.NGRect_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("viewPortOrigin"));
                    }
                }
                else
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.NGRect_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("viewPortOrigin"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.NGRect_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("viewPortOrigin"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.NGRect_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("viewPortOrigin"));
                    }
                    else
                    {
                        global::NMapViewerSDK.iOS.Messaging.NGRect_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("viewPortOrigin"));
                    }
                }
                return ret;
            }

        }

        public NRect BoundsInUtmk
        {
            [Export("boundsInUtmk", ArgumentSemantic.UnsafeUnretained)]
            get
            {
                NRect ret;
                if (IsDirectBinding)
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.NRect_objc_msgSend(this.Handle, Selector.GetHandle("boundsInUtmk"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.NRect_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("boundsInUtmk"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.NRect_objc_msgSend(this.Handle, Selector.GetHandle("boundsInUtmk"));
                    }
                    else
                    {
                        global::NMapViewerSDK.iOS.Messaging.NRect_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("boundsInUtmk"));
                    }
                }
                else
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.NRect_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("boundsInUtmk"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.NRect_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("boundsInUtmk"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.NRect_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("boundsInUtmk"));
                    }
                    else
                    {
                        global::NMapViewerSDK.iOS.Messaging.NRect_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("boundsInUtmk"));
                    }
                }
                return ret;
            }

            [Export("setBoundsInUtmk:", ArgumentSemantic.UnsafeUnretained)]
            set
            {
                if (IsDirectBinding)
                {
                    global::NMapViewerSDK.iOS.Messaging.void_objc_msgSend_NRect(this.Handle, Selector.GetHandle("setBoundsInUtmk:"), value);
                }
                else
                {
                    global::NMapViewerSDK.iOS.Messaging.void_objc_msgSendSuper_NRect(this.SuperHandle, Selector.GetHandle("setBoundsInUtmk:"), value);
                }
            }
        }

        [Export("boundsOffset:")]
        public virtual CGPoint BoundsOffset(NMapView mapView)
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
                        ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend_IntPtr(this.Handle, Selector.GetHandle("boundsOffset:"), mapView.Handle);
                    }
                    else
                    {
                        global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend_stret_IntPtr(out ret, this.Handle, Selector.GetHandle("boundsOffset:"), mapView.Handle);
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend_IntPtr(this.Handle, Selector.GetHandle("boundsOffset:"), mapView.Handle);
                }
                else
                {
                    ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend_IntPtr(this.Handle, Selector.GetHandle("boundsOffset:"), mapView.Handle);
                }
            }
            else
            {
                if (Runtime.Arch == Arch.DEVICE)
                {
                    if (IntPtr.Size == 8)
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSendSuper_IntPtr(this.SuperHandle, Selector.GetHandle("boundsOffset:"), mapView.Handle);
                    }
                    else
                    {
                        global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSendSuper_stret_IntPtr(out ret, this.SuperHandle, Selector.GetHandle("boundsOffset:"), mapView.Handle);
                    }
                }
                else if (IntPtr.Size == 8)
                {
                    ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSendSuper_IntPtr(this.SuperHandle, Selector.GetHandle("boundsOffset:"), mapView.Handle);
                }
                else
                {
                    ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSendSuper_IntPtr(this.SuperHandle, Selector.GetHandle("boundsOffset:"), mapView.Handle);
                }
            }
            return ret;
        }
    }
}
