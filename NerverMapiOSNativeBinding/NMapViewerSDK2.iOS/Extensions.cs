using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;

namespace NMapViewerSDK.iOS
{
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
}
