using System;
using CoreGraphics;
using NMapViewerSDK.iOS;
using UIKit;

namespace NaveriOSMapViewApp
{
    public class NMapViewResource
    {
        public static UIImage ImageWithType(int poiFlagType, bool selected)
        {
            switch(poiFlagType)
            {
                case NMapPOIflagType.Location:
                    return UIImage.FromBundle("pubtrans_ic_mylocation_on");
                case NMapPOIflagType.LocationOff:
                    return UIImage.FromBundle("pubtrans_ic_mylocation_off");
                case NMapPOIflagType.Compass:
                    return UIImage.FromBundle("ic_angle");
                case UserPOIflagType.Default:
                    return UIImage.FromBundle("pubtrans_exact_default");
                case UserPOIflagType.Invisible:
                    return UIImage.FromBundle("1px_dot");
            }
            return null;
        }

        public static CGPoint AnchorPoint(int poiFlagType)
        {
            switch (poiFlagType)
            {
                case NMapPOIflagType.Location:
                    return new CGPoint(0.5, 0.5);
                case NMapPOIflagType.LocationOff:
                    return new CGPoint(0.5, 0.5);
                case NMapPOIflagType.Compass:
                    return new CGPoint(0.5, 0.5);
                case UserPOIflagType.Default:
                    return new CGPoint(0.5, 1.0);
                case UserPOIflagType.Invisible:
                    return new CGPoint(0.5, 0.5);
                default:
                    return new CGPoint(0.5, 0.5);
            }
        }

        public static NGeoPoint NGeoPointMake(double longititude, double latitude)
        {
            var location = new NGeoPoint
            {
                Longitude = longititude,
                Latitude = latitude,
            };
            return location;
        }
    }
}
