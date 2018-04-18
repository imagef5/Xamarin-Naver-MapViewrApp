using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace NMapViewerSDK.iOS
{
    public partial class NMapPlacemark
    {
        public NGeoPoint Location
        {
            [Export("location")]
            get
            {
                NGeoPoint ret;
                if (IsDirectBinding)
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.NGeoPoint_objc_msgSend(this.Handle, Selector.GetHandle("location"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.NGeoPoint_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("location"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.NGeoPoint_objc_msgSend(this.Handle, Selector.GetHandle("location"));
                    }
                    else
                    {
                        global::NMapViewerSDK.iOS.Messaging.NGeoPoint_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("location"));
                    }
                }
                else
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.NGeoPoint_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("location"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.NGeoPoint_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("location"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.NGeoPoint_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("location"));
                    }
                    else
                    {
                        global::NMapViewerSDK.iOS.Messaging.NGeoPoint_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("location"));
                    }
                }
                return ret;
            }
        }
    }

}
