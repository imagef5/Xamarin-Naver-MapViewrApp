// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace NaveriOSMapViewApp
{
    [Register ("MapViewController")]
    partial class MapViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIStepper levelSetpper { get; set; }

        [Action ("changeMapMode:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void changeMapMode (UIKit.UISegmentedControl sender);

        [Action ("levelStepperValeChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void levelStepperValeChanged (UIKit.UIStepper sender);

        [Action ("showOverlayLayers:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void showOverlayLayers (UIKit.UIBarButtonItem sender);

        void ReleaseDesignerOutlets ()
        {
            if (levelSetpper != null) {
                levelSetpper.Dispose ();
                levelSetpper = null;
            }
        }
    }
}