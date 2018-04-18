using System;
using Foundation;
using ObjCRuntime;

namespace NMapViewerSDK.iOS
{
    public partial class NMapRadiusSettingOverlay
    {
        public virtual NGeoPoint Location
        {
            [Export("location", ArgumentSemantic.UnsafeUnretained)]
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

            [Export("setLocation:", ArgumentSemantic.UnsafeUnretained)]
            set
            {
                if (IsDirectBinding)
                {
                    global::NMapViewerSDK.iOS.Messaging.void_objc_msgSend_NGeoPoint(this.Handle, Selector.GetHandle("setLocation:"), value);
                }
                else
                {
                    global::NMapViewerSDK.iOS.Messaging.void_objc_msgSendSuper_NGeoPoint(this.SuperHandle, Selector.GetHandle("setLocation:"), value);
                }
            }
        }
    }
}
