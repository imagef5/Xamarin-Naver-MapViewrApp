using System;
using System.Runtime.InteropServices;
using ObjCRuntime;

namespace NMapViewerSDK.iOS
{
    [StructLayout (LayoutKind.Sequential)]
    public struct NGPoint
    {
        public float X;

        public float Y;
    }

    [StructLayout (LayoutKind.Sequential)]
    public struct NGSize
    {
        public float Width;

        public float Height;
    }

    [StructLayout (LayoutKind.Sequential)]
    public struct NGRect
    {
        public NGPoint Origin;

        public NGSize Size;
    }

    //static class CFunctions
    //{
    //    // extern NGRect NGRectInsect (NGRect rect, float dx, float dy);
    //    [DllImport ("__Internal")]
    //    //[Verify (PlatformInvoke)]
    //    static extern NGRect NGRectInsect (NGRect rect, float dx, float dy);

    //    // extern int NGRectContainsPoint (NGRect rect, NGPoint pt);
    //    [DllImport ("__Internal")]
    //    //[Verify (PlatformInvoke)]
    //    static extern int NGRectContainsPoint (NGRect rect, NGPoint pt);

    //    // extern int NGeoPointIsEquals (NGeoPoint pt1, NGeoPoint pt2);
    //    [DllImport ("__Internal")]
    //    //[Verify (PlatformInvoke)]
    //    static extern int NGeoPointIsEquals (NGeoPoint pt1, NGeoPoint pt2);
    //}

    [StructLayout (LayoutKind.Sequential)]
    public struct NGeoPoint
    {
        public double Longitude;

        public double Latitude;
    }

    [StructLayout (LayoutKind.Sequential)]
    public struct NGeoRect
    {
        public double Left;

        public double Top;

        public double Right;

        public double Bottom;
    }

    [StructLayout (LayoutKind.Sequential)]
    public struct NPoint
    {
        public int X;

        public int Y;
    }

    [StructLayout (LayoutKind.Sequential)]
    public struct NSize
    {
        public int Width;

        public int Height;
    }

    [StructLayout (LayoutKind.Sequential)]
    public struct NRect
    {
        public int Left;

        public int Top;

        public int Right;

        public int Bottom;
    }

    [Native]
    public enum NMapPathLineType : ulong//: nint
    {
        None = 0,
        Solid = 1,
        Dash
    }

    [Native]
    public enum NMapPathDataType : ulong//: nint
    {
        Line,
        Polygon,
    }

    [Native]
    public enum NMapLocationManagerErrorType : ulong//: nint
    {
        Timeout,
        UnavailableArea,
        Canceled,
        Denied,
        Unknown,
        Heading
    }

    [Native]
    public enum NMapPOIflagMode : ulong//: nint
    {
        Touch,
        Drag,
        Fixed,
        Dispatch
    }

    public enum NMapOverlayZPosition : uint
    {
        Lowest = 1000,
        Low = 2000,
        Lower = 3000,
        Medium = 5000,
        High = 7000,
        Higher = 8000,
        Highest = 9000
    }

    [Native]
    public enum NMapViewStatus : ulong//: nint
    {
        Unknown,
        BeginAnimation,
        EndAnimation
    }

    [Native]
    public enum NMapViewMode : ulong//: nint
    {
        Vector = 0,
        Satellite,
        Hybrid,
        Traffic,
        Panorama,
        Bicycle,
        Max
    }
}
