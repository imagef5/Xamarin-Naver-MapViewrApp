using System;
using System.Runtime.InteropServices;

namespace NMapViewerSDK.iOS
{
    internal static class Messaging
    {
        const string LIBOBJC_DYLIB = "/usr/lib/libobjc.dylib";

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        internal extern static bool bool_objc_msgSend(IntPtr receiver, IntPtr selector);
    }
}
