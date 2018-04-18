using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace NMapViewerSDK.iOS
{
    public partial class NMapPOIitem
    {
        public NGPoint Position
        {
            [Export("position", ArgumentSemantic.UnsafeUnretained)]
            get
            {
                NGPoint ret;
                if (IsDirectBinding)
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.NGPoint_objc_msgSend(this.Handle, Selector.GetHandle("position"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.NGPoint_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("position"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.NGPoint_objc_msgSend(this.Handle, Selector.GetHandle("position"));
                    }
                    else
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.NGPoint_objc_msgSend(this.Handle, Selector.GetHandle("position"));
                    }
                }
                else
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.NGPoint_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("position"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.NGPoint_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("position"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.NGPoint_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("position"));
                    }
                    else
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.NGPoint_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("position"));
                    }
                }
                return ret;
            }

            [Export("setPosition:", ArgumentSemantic.UnsafeUnretained)]
            set
            {
                if (IsDirectBinding)
                {
                    global::NMapViewerSDK.iOS.Messaging.void_objc_msgSend_NGPoint(this.Handle, Selector.GetHandle("setPosition:"), value);
                }
                else
                {
                    global::NMapViewerSDK.iOS.Messaging.void_objc_msgSendSuper_NGPoint(this.SuperHandle, Selector.GetHandle("setPosition:"), value);
                }
            }
        }

        public NGeoPoint Location
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

        public NPoint Utmk
        {
            [Export("utmk", ArgumentSemantic.UnsafeUnretained)]
            get
            {
                NPoint ret;
                if (IsDirectBinding)
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.NPoint_objc_msgSend(this.Handle, Selector.GetHandle("utmk"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.NPoint_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("utmk"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.NPoint_objc_msgSend(this.Handle, Selector.GetHandle("utmk"));
                    }
                    else
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.NPoint_objc_msgSend(this.Handle, Selector.GetHandle("utmk"));
                    }
                }
                else
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.NPoint_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("utmk"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.NPoint_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("utmk"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.NPoint_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("utmk"));
                    }
                    else
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.NPoint_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("utmk"));
                    }
                }
                return ret;
            }

            [Export("setUtmk:", ArgumentSemantic.UnsafeUnretained)]
            set
            {
                if (IsDirectBinding)
                {
                    global::NMapViewerSDK.iOS.Messaging.void_objc_msgSend_NPoint(this.Handle, Selector.GetHandle("setUtmk:"), value);
                }
                else
                {
                    global::NMapViewerSDK.iOS.Messaging.void_objc_msgSendSuper_NPoint(this.SuperHandle, Selector.GetHandle("setUtmk:"), value);
                }
            }
        }

        public CGPoint ScreenLocation
        {
            [Export("screenLocation", ArgumentSemantic.UnsafeUnretained)]
            get
            {
                CGPoint ret;
                if (IsDirectBinding)
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend(this.Handle, Selector.GetHandle("screenLocation"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("screenLocation"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend(this.Handle, Selector.GetHandle("screenLocation"));
                    }
                    else
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend(this.Handle, Selector.GetHandle("screenLocation"));
                    }
                }
                else
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("screenLocation"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("screenLocation"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("screenLocation"));
                    }
                    else
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("screenLocation"));
                    }
                }
                return ret;
            }

            [Export("setScreenLocation:", ArgumentSemantic.UnsafeUnretained)]
            set
            {
                if (IsDirectBinding)
                {
                    global::NMapViewerSDK.iOS.Messaging.void_objc_msgSend_CGPoint(this.Handle, Selector.GetHandle("setScreenLocation:"), value);
                }
                else
                {
                    global::NMapViewerSDK.iOS.Messaging.void_objc_msgSendSuper_CGPoint(this.SuperHandle, Selector.GetHandle("setScreenLocation:"), value);
                }
            }
        }

        public CGPoint PositionSpread
        {
            [Export("positionSpread", ArgumentSemantic.UnsafeUnretained)]
            get
            {
                CGPoint ret;
                if (IsDirectBinding)
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend(this.Handle, Selector.GetHandle("positionSpread"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("positionSpread"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend(this.Handle, Selector.GetHandle("positionSpread"));
                    }
                    else
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend(this.Handle, Selector.GetHandle("positionSpread"));
                    }
                }
                else
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("positionSpread"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("positionSpread"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("positionSpread"));
                    }
                    else
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("positionSpread"));
                    }
                }
                return ret;
            }

            [Export("setPositionSpread:", ArgumentSemantic.UnsafeUnretained)]
            set
            {
                if (IsDirectBinding)
                {
                    global::NMapViewerSDK.iOS.Messaging.void_objc_msgSend_CGPoint(this.Handle, Selector.GetHandle("setPositionSpread:"), value);
                }
                else
                {
                    global::NMapViewerSDK.iOS.Messaging.void_objc_msgSendSuper_CGPoint(this.SuperHandle, Selector.GetHandle("setPositionSpread:"), value);
                }
            }
        }

        public CGPoint AnchorPoint
        {
            [Export("anchorPoint", ArgumentSemantic.UnsafeUnretained)]
            get
            {
                CGPoint ret;
                if (IsDirectBinding)
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend(this.Handle, Selector.GetHandle("anchorPoint"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("anchorPoint"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend(this.Handle, Selector.GetHandle("anchorPoint"));
                    }
                    else
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend(this.Handle, Selector.GetHandle("anchorPoint"));
                    }
                }
                else
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("anchorPoint"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("anchorPoint"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("anchorPoint"));
                    }
                    else
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("anchorPoint"));
                    }
                }
                return ret;
            }

            [Export("setAnchorPoint:", ArgumentSemantic.UnsafeUnretained)]
            set
            {
                if (IsDirectBinding)
                {
                    global::NMapViewerSDK.iOS.Messaging.void_objc_msgSend_CGPoint(this.Handle, Selector.GetHandle("setAnchorPoint:"), value);
                }
                else
                {
                    global::NMapViewerSDK.iOS.Messaging.void_objc_msgSendSuper_CGPoint(this.SuperHandle, Selector.GetHandle("setAnchorPoint:"), value);
                }
            }
        }

        public CGPoint InfoLayerOffset
        {
            [Export("infoLayerOffset", ArgumentSemantic.UnsafeUnretained)]
            get
            {
                CGPoint ret;
                if (IsDirectBinding)
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend(this.Handle, Selector.GetHandle("infoLayerOffset"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("infoLayerOffset"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend(this.Handle, Selector.GetHandle("infoLayerOffset"));
                    }
                    else
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSend(this.Handle, Selector.GetHandle("infoLayerOffset"));
                    }
                }
                else
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("infoLayerOffset"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("infoLayerOffset"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("infoLayerOffset"));
                    }
                    else
                    {
                        ret = global::NMapViewerSDK.iOS.Messaging.CGPoint_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("infoLayerOffset"));
                    }
                }
                return ret;
            }

            [Export("setInfoLayerOffset:", ArgumentSemantic.UnsafeUnretained)]
            set
            {
                if (IsDirectBinding)
                {
                    global::NMapViewerSDK.iOS.Messaging.void_objc_msgSend_CGPoint(this.Handle, Selector.GetHandle("setInfoLayerOffset:"), value);
                }
                else
                {
                    global::NMapViewerSDK.iOS.Messaging.void_objc_msgSendSuper_CGPoint(this.SuperHandle, Selector.GetHandle("setInfoLayerOffset:"), value);
                }
            }
        }

        public CGRect Frame
        {
            [Export("frame")]
            get
            {
                CGRect ret;
                if (IsDirectBinding)
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSend(this.Handle, Selector.GetHandle("frame"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("frame"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("frame"));
                    }
                    else
                    {
                        global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSend_stret(out ret, this.Handle, Selector.GetHandle("frame"));
                    }
                }
                else
                {
                    if (Runtime.Arch == Arch.DEVICE)
                    {
                        if (IntPtr.Size == 8)
                        {
                            ret = global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSendSuper(this.SuperHandle, Selector.GetHandle("frame"));
                        }
                        else
                        {
                            global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("frame"));
                        }
                    }
                    else if (IntPtr.Size == 8)
                    {
                        global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("frame"));
                    }
                    else
                    {
                        global::NMapViewerSDK.iOS.Messaging.CGRect_objc_msgSendSuper_stret(out ret, this.SuperHandle, Selector.GetHandle("frame"));
                    }
                }
                return ret;
            }

        }
    }
}
