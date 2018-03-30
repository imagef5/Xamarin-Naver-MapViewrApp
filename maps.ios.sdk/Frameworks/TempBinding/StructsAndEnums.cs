using System;
using System.Runtime.InteropServices;
using NMapViewerSDK;
using ObjCRuntime;

namespace NMapViewerSDK
{
	[StructLayout (LayoutKind.Sequential)]
	public struct NGPoint
	{
		public float x;

		public float y;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct NGSize
	{
		public float width;

		public float height;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct NGRect
	{
		public NGPoint origin;

		public NGSize size;
	}

	static class CFunctions
	{
		// extern NGRect NGRectInsect (NGRect rect, float dx, float dy);
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern NGRect NGRectInsect (NGRect rect, float dx, float dy);

		// extern int NGRectContainsPoint (NGRect rect, NGPoint pt);
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern int NGRectContainsPoint (NGRect rect, NGPoint pt);

		// extern int NGeoPointIsEquals (NGeoPoint pt1, NGeoPoint pt2);
		[DllImport ("__Internal")]
		[Verify (PlatformInvoke)]
		static extern int NGeoPointIsEquals (NGeoPoint pt1, NGeoPoint pt2);
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct NGeoPoint
	{
		public double longitude;

		public double latitude;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct NGeoRect
	{
		public double left;

		public double top;

		public double right;

		public double bottom;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct NPoint
	{
		public int x;

		public int y;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct NSize
	{
		public int width;

		public int height;
	}

	[StructLayout (LayoutKind.Sequential)]
	public struct NRect
	{
		public int left;

		public int top;

		public int right;

		public int bottom;
	}

	[Native]
	public enum NMapPathLineType : nint
	{
		None = 0,
		Solid = 1,
		Dash
	}

	[Native]
	public enum NMapPathDataType : nint
	{
		line,
		gon
	}

	[Native]
	public enum NMapLocationManagerErrorType : nint
	{
		Timeout,
		UnavailableArea,
		Canceled,
		Denied,
		Unknown,
		Heading
	}

	[Native]
	public enum NMapPOIflagMode : nint
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
	public enum NMapViewStatus : nint
	{
		Unknown,
		BeginAnimation,
		EndAnimation
	}

	[Native]
	public enum NMapViewMode : nint
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
