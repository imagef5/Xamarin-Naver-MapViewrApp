using System;
using System.Runtime.InteropServices;
using CoreGraphics;

namespace NMapViewerSDK.iOS
{
    internal static class Messaging
    {
        const string LIBOBJC_DYLIB = "/usr/lib/libobjc.dylib";

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        internal extern static bool bool_objc_msgSend(IntPtr receiver, IntPtr selector);

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::NMapViewerSDK.iOS.NGeoPoint NGeoPoint_objc_msgSend(IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper", CallingConvention = CallingConvention.StdCall)]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::NMapViewerSDK.iOS.NGeoPoint NGeoPoint_objc_msgSendSuper(IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
        public extern static void NGeoPoint_objc_msgSend_stret(out global::NMapViewerSDK.iOS.NGeoPoint retval, IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper_stret")]
        public extern static void NGeoPoint_objc_msgSendSuper_stret(out global::NMapViewerSDK.iOS.NGeoPoint retval, IntPtr receiver, IntPtr selector);

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static CGRect CGRect_objc_msgSend(IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static CGRect CGRect_objc_msgSendSuper(IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
        public extern static void CGRect_objc_msgSend_stret(out CGRect retval, IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper_stret")]
        public extern static void CGRect_objc_msgSendSuper_stret(out CGRect retval, IntPtr receiver, IntPtr selector);

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::NMapViewerSDK.iOS.NPoint NPoint_objc_msgSend(IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::NMapViewerSDK.iOS.NPoint NPoint_objc_msgSendSuper(IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
        public extern static void NPoint_objc_msgSend_stret(out global::NMapViewerSDK.iOS.NPoint retval, IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper_stret")]
        public extern static void NPoint_objc_msgSendSuper_stret(out global::NMapViewerSDK.iOS.NPoint retval, IntPtr receiver, IntPtr selector);

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::NMapViewerSDK.iOS.NGRect NGRect_objc_msgSend(IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::NMapViewerSDK.iOS.NGRect NGRect_objc_msgSendSuper(IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
        public extern static void NGRect_objc_msgSend_stret(out global::NMapViewerSDK.iOS.NGRect retval, IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper_stret")]
        public extern static void NGRect_objc_msgSendSuper_stret(out global::NMapViewerSDK.iOS.NGRect retval, IntPtr receiver, IntPtr selector);

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::NMapViewerSDK.iOS.NRect NRect_objc_msgSend(IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::NMapViewerSDK.iOS.NRect NRect_objc_msgSendSuper(IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
        public extern static void NRect_objc_msgSend_stret(out global::NMapViewerSDK.iOS.NRect retval, IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper_stret")]
        public extern static void NRect_objc_msgSendSuper_stret(out global::NMapViewerSDK.iOS.NRect retval, IntPtr receiver, IntPtr selector);

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::NMapViewerSDK.iOS.NGPoint NGPoint_objc_msgSend(IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::NMapViewerSDK.iOS.NGPoint NGPoint_objc_msgSendSuper(IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
        public extern static void NGPoint_objc_msgSend_stret(out global::NMapViewerSDK.iOS.NGPoint retval, IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper_stret")]
        public extern static void NGPoint_objc_msgSendSuper_stret(out global::NMapViewerSDK.iOS.NGPoint retval, IntPtr receiver, IntPtr selector);

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static CGPoint CGPoint_objc_msgSend(IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static CGPoint CGPoint_objc_msgSendSuper(IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
        public extern static void CGPoint_objc_msgSend_stret(out CGPoint retval, IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper_stret")]
        public extern static void CGPoint_objc_msgSendSuper_stret(out CGPoint retval, IntPtr receiver, IntPtr selector);

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        public extern static void void_objc_msgSend_NGPoint(IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NGPoint arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        public extern static void void_objc_msgSendSuper_NGPoint(IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NGPoint arg1);

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        public extern static void void_objc_msgSend_NGeoPoint(IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NGeoPoint arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        public extern static void void_objc_msgSendSuper_NGeoPoint(IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NGeoPoint arg1);

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        public extern static void void_objc_msgSend_NPoint(IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NPoint arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        public extern static void void_objc_msgSendSuper_NPoint(IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NPoint arg1);

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        public extern static void void_objc_msgSend_CGPoint(IntPtr receiver, IntPtr selector, CGPoint arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        public extern static void void_objc_msgSendSuper_CGPoint(IntPtr receiver, IntPtr selector, CGPoint arg1);

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        public extern static void void_objc_msgSend_NRect(IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NRect arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        public extern static void void_objc_msgSendSuper_NRect(IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NRect arg1);

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::NMapViewerSDK.iOS.NGeoPoint NGeoPoint_objc_msgSend_CGPoint(IntPtr receiver, IntPtr selector, CGPoint arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::NMapViewerSDK.iOS.NGeoPoint NGeoPoint_objc_msgSendSuper_CGPoint(IntPtr receiver, IntPtr selector, CGPoint arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
        public extern static void NGeoPoint_objc_msgSend_stret_CGPoint(out global::NMapViewerSDK.iOS.NGeoPoint retval, IntPtr receiver, IntPtr selector, CGPoint arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper_stret")]
        public extern static void NGeoPoint_objc_msgSendSuper_stret_CGPoint(out global::NMapViewerSDK.iOS.NGeoPoint retval, IntPtr receiver, IntPtr selector, CGPoint arg1);

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::NMapViewerSDK.iOS.NPoint NPoint_objc_msgSend_CGPoint(IntPtr receiver, IntPtr selector, CGPoint arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::NMapViewerSDK.iOS.NPoint NPoint_objc_msgSendSuper_CGPoint(IntPtr receiver, IntPtr selector, CGPoint arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
        public extern static void NPoint_objc_msgSend_stret_CGPoint(out global::NMapViewerSDK.iOS.NPoint retval, IntPtr receiver, IntPtr selector, CGPoint arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper_stret")]
        public extern static void NPoint_objc_msgSendSuper_stret_CGPoint(out global::NMapViewerSDK.iOS.NPoint retval, IntPtr receiver, IntPtr selector, CGPoint arg1);

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static CGPoint CGPoint_objc_msgSend_NGeoPoint(IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NGeoPoint arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static CGPoint CGPoint_objc_msgSendSuper_NGeoPoint(IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NGeoPoint arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
        public extern static void CGPoint_objc_msgSend_stret_NGeoPoint(out CGPoint retval, IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NGeoPoint arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper_stret")]
        public extern static void CGPoint_objc_msgSendSuper_stret_NGeoPoint(out CGPoint retval, IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NGeoPoint arg1);

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static CGPoint CGPoint_objc_msgSend_NPoint(IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NPoint arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static CGPoint CGPoint_objc_msgSendSuper_NPoint(IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NPoint arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
        public extern static void CGPoint_objc_msgSend_stret_NPoint(out CGPoint retval, IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NPoint arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper_stret")]
        public extern static void CGPoint_objc_msgSendSuper_stret_NPoint(out CGPoint retval, IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NPoint arg1);

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::NMapViewerSDK.iOS.NGPoint NGPoint_objc_msgSend_NGeoPoint(IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NGeoPoint arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::NMapViewerSDK.iOS.NGPoint NGPoint_objc_msgSendSuper_NGeoPoint(IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NGeoPoint arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
        public extern static void NGPoint_objc_msgSend_stret_NGeoPoint(out global::NMapViewerSDK.iOS.NGPoint retval, IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NGeoPoint arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper_stret")]
        public extern static void NGPoint_objc_msgSendSuper_stret_NGeoPoint(out global::NMapViewerSDK.iOS.NGPoint retval, IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NGeoPoint arg1);

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::NMapViewerSDK.iOS.NGPoint NGPoint_objc_msgSend_NPoint(IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NPoint arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::NMapViewerSDK.iOS.NGPoint NGPoint_objc_msgSendSuper_NPoint(IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NPoint arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
        public extern static void NGPoint_objc_msgSend_stret_NPoint(out global::NMapViewerSDK.iOS.NGPoint retval, IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NPoint arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper_stret")]
        public extern static void NGPoint_objc_msgSendSuper_stret_NPoint(out global::NMapViewerSDK.iOS.NGPoint retval, IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NPoint arg1);

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::NMapViewerSDK.iOS.NRect NRect_objc_msgSend_NGeoRect(IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NGeoRect arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::NMapViewerSDK.iOS.NRect NRect_objc_msgSendSuper_NGeoRect(IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NGeoRect arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
        public extern static void NRect_objc_msgSend_stret_NGeoRect(out global::NMapViewerSDK.iOS.NRect retval, IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NGeoRect arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper_stret")]
        public extern static void NRect_objc_msgSendSuper_stret_NGeoRect(out global::NMapViewerSDK.iOS.NRect retval, IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NGeoRect arg1);

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::NMapViewerSDK.iOS.NGeoRect NGeoRect_objc_msgSend(IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::NMapViewerSDK.iOS.NGeoRect NGeoRect_objc_msgSendSuper(IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
        public extern static void NGeoRect_objc_msgSend_stret(out global::NMapViewerSDK.iOS.NGeoRect retval, IntPtr receiver, IntPtr selector);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper_stret")]
        public extern static void NGeoRect_objc_msgSendSuper_stret(out global::NMapViewerSDK.iOS.NGeoRect retval, IntPtr receiver, IntPtr selector);

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::NMapViewerSDK.iOS.NGeoRect NGeoRect_objc_msgSend_Double(IntPtr receiver, IntPtr selector, double arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::NMapViewerSDK.iOS.NGeoRect NGeoRect_objc_msgSendSuper_Double(IntPtr receiver, IntPtr selector, double arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
        public extern static void NGeoRect_objc_msgSend_stret_Double(out global::NMapViewerSDK.iOS.NGeoRect retval, IntPtr receiver, IntPtr selector, double arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper_stret")]
        public extern static void NGeoRect_objc_msgSendSuper_stret_Double(out global::NMapViewerSDK.iOS.NGeoRect retval, IntPtr receiver, IntPtr selector, double arg1);

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::NMapViewerSDK.iOS.NSize NSize_objc_msgSend_NSize(IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NSize arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::NMapViewerSDK.iOS.NSize NSize_objc_msgSendSuper_NSize(IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NSize arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
        public extern static void NSize_objc_msgSend_stret_NSize(out global::NMapViewerSDK.iOS.NSize retval, IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NSize arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper_stret")]
        public extern static void NSize_objc_msgSendSuper_stret_NSize(out global::NMapViewerSDK.iOS.NSize retval, IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NSize arg1);

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static CGPoint CGPoint_objc_msgSend_CGPoint(IntPtr receiver, IntPtr selector, CGPoint arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static CGPoint CGPoint_objc_msgSendSuper_CGPoint(IntPtr receiver, IntPtr selector, CGPoint arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
        public extern static void CGPoint_objc_msgSend_stret_CGPoint(out CGPoint retval, IntPtr receiver, IntPtr selector, CGPoint arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper_stret")]
        public extern static void CGPoint_objc_msgSendSuper_stret_CGPoint(out CGPoint retval, IntPtr receiver, IntPtr selector, CGPoint arg1);

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::NMapViewerSDK.iOS.NGPoint NGPoint_objc_msgSend_NPoint_int_NGRect(IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NPoint arg1, int arg2, global::NMapViewerSDK.iOS.NGRect arg3);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static global::NMapViewerSDK.iOS.NGPoint NGPoint_objc_msgSendSuper_NPoint_int_NGRect(IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NPoint arg1, int arg2, global::NMapViewerSDK.iOS.NGRect arg3);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
        public extern static void NGPoint_objc_msgSend_stret_NPoint_int_NGRect(out global::NMapViewerSDK.iOS.NGPoint retval, IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NPoint arg1, int arg2, global::NMapViewerSDK.iOS.NGRect arg3);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper_stret")]
        public extern static void NGPoint_objc_msgSendSuper_stret_NPoint_int_NGRect(out global::NMapViewerSDK.iOS.NGPoint retval, IntPtr receiver, IntPtr selector, global::NMapViewerSDK.iOS.NPoint arg1, int arg2, global::NMapViewerSDK.iOS.NGRect arg3);

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static CGPoint CGPoint_objc_msgSend_IntPtr_NGRect(IntPtr receiver, IntPtr selector, IntPtr arg1, global::NMapViewerSDK.iOS.NGRect arg2);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static CGPoint CGPoint_objc_msgSendSuper_IntPtr_NGRect(IntPtr receiver, IntPtr selector, IntPtr arg1, global::NMapViewerSDK.iOS.NGRect arg2);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
        public extern static void CGPoint_objc_msgSend_stret_IntPtr_NGRect(out CGPoint retval, IntPtr receiver, IntPtr selector, IntPtr arg1, global::NMapViewerSDK.iOS.NGRect arg2);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper_stret")]
        public extern static void CGPoint_objc_msgSendSuper_stret_IntPtr_NGRect(out CGPoint retval, IntPtr receiver, IntPtr selector, IntPtr arg1, global::NMapViewerSDK.iOS.NGRect arg2);

        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static CGPoint CGPoint_objc_msgSend_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper")]
        [return: MarshalAs(UnmanagedType.Struct)]
        public extern static CGPoint CGPoint_objc_msgSendSuper_IntPtr(IntPtr receiver, IntPtr selector, IntPtr arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSend_stret")]
        public extern static void CGPoint_objc_msgSend_stret_IntPtr(out CGPoint retval, IntPtr receiver, IntPtr selector, IntPtr arg1);
        [DllImport(LIBOBJC_DYLIB, EntryPoint = "objc_msgSendSuper_stret")]
        public extern static void CGPoint_objc_msgSendSuper_stret_IntPtr(out CGPoint retval, IntPtr receiver, IntPtr selector, IntPtr arg1);

    }
}