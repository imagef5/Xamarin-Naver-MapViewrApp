using System;
using Foundation;
using ObjCRuntime;

namespace NMapViewerSDK.iOS
{
    //public partial class NMapView
    //{
    //    //static readonly IntPtr class_ptr = Class.GetHandle("NMapView");
    //    //public bool IsProjectionScaled
    //    //{
    //    //    get
    //    //    {
    //    //        return Message.bool_objc_msgSend(Class.GetHandle("NMapView_NMapProjection") , Selector.GetHandle("isProjectionScaled"));
    //    //    } 
    //    //}
    //    //public bool AutoRotateEnabled
    //    //{
    //    //    [Export("isAutoRotateEnabled")]
    //    //    get
    //    //    {
    //    //        var ret = global::NMapViewerSDK.iOS.Messaging.bool_objc_msgSend(Class.GetHandle("NMapView_NMapViewRotation"), Selector.GetHandle("isAutoRotateEnabled"));
    //    //        return ret; 
    //    //    }
    //    //}
    //}

    public partial class NMapPOIflagType
    {
        public const int Unknown = 0;
        public const int Location = 10; // show pin object with "Location" icon
        public const int LocationOff = 11; // show pin object with "Location Off" icon
        public const int Compass = 12;
        public const int Reserved = 0x100;
    }

    public partial class UserPOIflagType
    {
        public const int Default = NMapPOIflagType.Reserved + 1;
        public const int Invisible = NMapPOIflagType.Reserved + 2;
    }

    //public enum NMapPOIFlagType
    //{
    //    Unknown = 0,
    //    Location = 10,
    //    LocationOff = 11,
    //    Compass = 12,
    //    Reserved = 0x100,
    //}

    //public enum UserPOIflagType
    //{
    //    Default = NMapPOIFlagType.Reserved + 1,
    //    Invisible = NMapPOIFlagType.Reserved + 2,
    //}

    //public static class Extension
    //{
    //    public static int ToInt(this NMapPOIFlagType flagType)
    //    {
    //        return (int)flagType;
    //    }

    //    public static int ToInt(this UserPOIflagType flagType)
    //    {
    //        return (int)flagType;
    //    }
    //}
}
