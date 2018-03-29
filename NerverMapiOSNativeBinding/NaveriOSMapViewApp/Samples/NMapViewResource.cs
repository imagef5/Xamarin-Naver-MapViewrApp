/*
 * 소스 참조 : https://developers.naver.com/docs/map/android/
 *           https://github.com/navermaps/maps.android
 * 네이버 지도에 서비스 저작권에 대한 자세한 내용은 Naver Developer 페이지를 참조하시기 바랍니다.
 * (https://github.com/navermaps/maps.android#license)
 * 
 * Copyright 2016 NAVER Corp.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
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
