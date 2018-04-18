using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace NMapViewerSDK.iOS
{
    public partial class NMapView
    {
        public virtual CGRect ViewFrameVisible
        {
            [Export("viewFrameVisible")]
            get
            {
                CGRect ret;
                if (IsDirectBinding)
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSend(this.Handle, Selector.GetHandle("viewFrameVisible"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("viewFrameVisible"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("viewFrameVisible"));
                    }
                    else
                    {
                        global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("viewFrameVisible"));
                    }
                }
                else
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("viewFrameVisible"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("viewFrameVisible"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("viewFrameVisible"));
                    }
                    else
                    {
                        global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("viewFrameVisible"));
                    }
                }
                return ret;
            }

        }
    }
}
