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

namespace NaverMapViewAndroidApp.Samples
{
    
    /*
     * Wrapper class representing POI flag types on map view.
     */
    public class NMapPOIflagType
    {
        public const int UNKNOWN = 0x0000;

        // Single POI icons
        private const int SINGLE_POI_BASE = 0x0100;

        // Spot, Pin icons
        public const int SPOT = SINGLE_POI_BASE + 1;
        public const int PIN = SPOT + 1;

        // Direction POI icons: From, To
        private const int DIRECTION_POI_BASE = 0x0200;
        public const int FROM = DIRECTION_POI_BASE + 1;
        public const int TO = FROM + 1;

        // end of single marker icon
        public const int SINGLE_MARKER_END = 0x04FF;

        // Direction Number icons
        private const int MAX_NUMBER_COUNT = 1000;
        public const int NUMBER_BASE = 0x1000; // set NUMBER_BASE + 1 for '1' number
        public const int NUMBER_END = NUMBER_BASE + MAX_NUMBER_COUNT;

        // Custom POI icons
        private const int MAX_CUSTOM_COUNT = 1000;
        public const int CUSTOM_BASE = NUMBER_END;
        public const int CUSTOM_END = CUSTOM_BASE + MAX_CUSTOM_COUNT;

        // Clickable callout에 보여지는 화살표 
        public const int CLICKABLE_ARROW = CUSTOM_END + 1;

        public static bool IsBoundsCentered(int markerId)
        {
            bool boundsCentered = false;

            switch (markerId)
            {
                default:
                    if (markerId >= NMapPOIflagType.NUMBER_BASE && markerId < NMapPOIflagType.NUMBER_END)
                    {
                        boundsCentered = true;
                    }
                    break;
            }

            return boundsCentered;
        }

        public static int GetMarkerId(int poiFlagType, int iconIndex)
        {
            int markerId = poiFlagType + iconIndex;

            return markerId;
        }

        public static int GetPOIflagType(int markerId)
        {
            int poiFlagType = UNKNOWN;

            // Alphabet POI icons
            if (markerId >= NUMBER_BASE && markerId < NUMBER_END)
            { // Direction Number icons
                poiFlagType = NUMBER_BASE;
            }
            else if (markerId >= CUSTOM_BASE && markerId < CUSTOM_END)
            { // Custom POI icons
                poiFlagType = CUSTOM_BASE;
            }
            else if (markerId > SINGLE_POI_BASE)
            {
                poiFlagType = markerId;
            }

            return poiFlagType;
        }

        public static int GetPOIflagIconIndex(int markerId)
        {
            int iconIndex = 0;

            if (markerId >= NUMBER_BASE && markerId < NUMBER_END)
            { // Direction Number icons
                iconIndex = markerId - (NUMBER_BASE + 1);
            }
            else if (markerId >= CUSTOM_BASE && markerId < CUSTOM_END)
            { // Custom POI icons
                iconIndex = markerId - (CUSTOM_BASE + 1);
            }
            else if (markerId > SINGLE_POI_BASE)
            {
                iconIndex = 0;
            }

            return iconIndex;
        }
    }
}
