using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace NMapViewerSDK.iOS
{
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
                            ret = global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSend(this.Handle, Selector.GetHandle("viewFrame"));
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

        public virtual CGRect ViewBounds
        {
            [Export("viewBounds")]
            get
            {
                CGRect ret;
                if (IsDirectBinding)
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSend(this.Handle, Selector.GetHandle("viewBounds"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("viewBounds"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("viewBounds"));
                    }
                    else
                    {
                        global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("viewBounds"));
                    }
                }
                else
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("viewBounds"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("viewBounds"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("viewBounds"));
                    }
                    else
                    {
                        global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("viewBounds"));
                    }
                }
                return ret;
            }

        }
    }
}
