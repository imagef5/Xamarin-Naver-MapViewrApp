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
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;
using Android.Util;
using Android.Widget;
using Com.Nhn.Android.Maps;
using Com.Nhn.Android.Maps.Overlay;
using Com.Nhn.Android.Mapviewer.Overlay;

namespace NaverMapViewAndroidApp.Samples
{
    public class NMapViewerResourceProvider : NMapResourceProvider, IResourceProvider
    {
        #region private member fields area
        const string LOG_TAG = "NMapViewerResourceProvider";
        const bool DEBUG = false;

        Bitmap.Config BITMAP_CONFIG_DEFAULT = Bitmap.Config.Argb8888;

        const string POI_FONT_COLOR_NUMBER = "#FF909090";
        const float POI_FONT_SIZE_NUMBER = 10.0F;

        const string POI_FONT_COLOR_ALPHABET = "#FFFFFFFF";
        const float POI_FONT_OFFSET_ALPHABET = 6.0F;
        const Typeface POI_FONT_TYPEFACE = null;//Typeface.DEFAULT_BOLD;

        const string CALLOUT_TEXT_COLOR_NORMAL = "#FFFFFFFF";
        const string CALLOUT_TEXT_COLOR_PRESSED = "#FF9CA1AA";
        const string CALLOUT_TEXT_COLOR_SELECTED = "#FFFFFFFF";
        const string CALLOUT_TEXT_COLOR_FOCUSED = "#FFFFFFFF";

        readonly Rect mTempRect = new Rect();
        readonly Paint mTextPaint = new Paint();
        readonly ResourceIdsOnMap[] mResourceIdsForMarkerOnMap = {
            // Spot, Pin icons
            new ResourceIdsOnMap(NMapPOIflagType.PIN, Resource.Drawable.ic_pin_01, Resource.Drawable.ic_pin_02),
            new ResourceIdsOnMap(NMapPOIflagType.SPOT, Resource.Drawable.ic_pin_01, Resource.Drawable.ic_pin_02),

            // Direction POI icons: From, To
            new ResourceIdsOnMap(NMapPOIflagType.FROM, Resource.Drawable.ic_map_start, Resource.Drawable.ic_map_start_over),
            new ResourceIdsOnMap(NMapPOIflagType.TO, Resource.Drawable.ic_map_arrive, Resource.Drawable.ic_map_arrive_over),
        };
        #endregion

        public NMapViewerResourceProvider(Context context) : base(context)
        {
            mTextPaint.AntiAlias = true;
        }

        #region Public Method Area
        public Drawable getDrawable(int markerId, bool focused, NMapOverlayItem item)
        {
            Drawable marker = null;

            int resourceId = FindResourceIdForMarker(markerId, focused);
            if (resourceId > 0)
            {
                marker = ContextCompat.GetDrawable(MContext, resourceId);//MContext.Resources.GetDrawable(resourceId);
            }
            else
            {
                resourceId = 4 * markerId;
                if (focused)
                {
                    resourceId += 1;
                }

                marker = GetDrawableForMarker(markerId, focused, item);
            }

            // set bounds
            if (marker != null)
            {
                SetBounds(marker, markerId, item);
            }

            return marker;
        }

        public Bitmap GetBitmap(int markerId, bool focused, NMapOverlayItem item)
        {
            Bitmap bitmap = null;

            Drawable marker = getDrawable(markerId, focused, item);
            if (marker != null)
            {
                bitmap = GetBitmap(marker);
            }

            return bitmap;
        }

        public Bitmap GetBitmap(Drawable marker)
        {
            Bitmap bitmap = null;

            if (marker != null)
            {
                int width = marker.IntrinsicWidth;
                int height = marker.IntrinsicHeight;
                bitmap = Bitmap.CreateBitmap(width, height, BITMAP_CONFIG_DEFAULT);

                marker.SetBounds(0, 0, width, height);

                Canvas canvas = new Canvas(bitmap);
                canvas.DrawColor(Color.ParseColor("#00000000"));

                marker.Draw(canvas);
            }

            return bitmap;
        }

        public Bitmap GetBitmap(int resourceId)
        {
            Bitmap bitmap = null;

            Drawable marker = null;
            if (resourceId > 0)
            {
                marker = ContextCompat.GetDrawable(MContext, resourceId);//MContext.Resources.GetDrawable(resourceId);
            }

            if (marker != null)
            {
                bitmap = GetBitmap(marker);
            }

            return bitmap;
        }

        public Bitmap GetBitmapWithNumber(int resourceId, string strNumber, float offsetY, int fontColor, float fontSize)
        {
            Bitmap bitmap = null;

            Drawable marker = GetDrawableWithNumber(resourceId, strNumber, offsetY, fontColor, fontSize);

            if (marker != null)
            {
                bitmap = GetBitmap(marker);
            }

            return bitmap;
        }

        public Drawable GetDrawableWithNumber(int resourceId, string strNumber, float offsetY, int fontColor, float fontSize)
        {

            Bitmap textBitmap = GetBitmapWithText(resourceId, strNumber, fontColor, fontSize, offsetY);

            //Log.i(LOG_TAG, "getDrawableWithNumber: width=" + textBitmap.getWidth() + ", height=" + textBitmap.getHeight() + ", density=" + textBitmap.getDensity());

            // set bounds
            Drawable marker = new BitmapDrawable(MContext.Resources, textBitmap);
            if (marker != null)
            {
                NMapOverlayItem.BoundCenter(marker);
            }

            //Log.i(LOG_TAG, "getDrawableWithNumber: width=" + marker.getIntrinsicWidth() + ", height=" + marker.getIntrinsicHeight());

            return marker;
        }

        public Drawable getDrawableWithAlphabet(int resourceId, string strAlphabet, int fontColor, float fontSize)
        {

            Bitmap textBitmap = GetBitmapWithText(resourceId, strAlphabet, fontColor, fontSize, POI_FONT_OFFSET_ALPHABET);

            // set bounds
            Drawable marker = new BitmapDrawable(MContext.Resources, textBitmap);
            if (marker != null)
            {
                NMapOverlayItem.BoundCenterBottom(marker);
            }

            return marker;
        }
        #endregion

        #region Implement Abstract class
        public override Drawable DirectionArrow
        {
            get
            {
                Drawable drawable = ContextCompat.GetDrawable(MContext, Resource.Drawable.ic_angle);//mContext.getResources().getDrawable(R.drawable.ic_angle);

                if (drawable != null)
                {
                    int w = drawable.IntrinsicWidth / 2;
                    int h = drawable.IntrinsicHeight / 2;

                    drawable.SetBounds(-w, -h, w, h);
                }

                return drawable;
            }
        }

        public override int LayoutIdForOverlappedListView => 0;

        public override int ListItemDividerId => 0;

        public override int ListItemImageViewId => 0;

        public override int ListItemLayoutIdForOverlappedListView => 0;

        public override int ListItemTailTextViewId => 0;

        public override int ListItemTextViewId => 0;

        public override int OverlappedListViewId => 0;

        public override int ParentLayoutIdForOverlappedListView => 0;

        public override Drawable GetCalloutBackground(NMapOverlayItem item)
        {
            if (item is NMapPOIitem poiItem) 
            {
                if (poiItem.ShowRightButton())
                {
                    //Drawable drawable = ContextCompat.GetDrawable(MContext, Resource.Drawable.bg_speech);//mContext.getResources().getDrawable(R.drawable.bg_speech);
                    return ContextCompat.GetDrawable(MContext, Resource.Drawable.bg_speech);
                }
            }

            //Drawable drawable = mContext.getResources().getDrawable(R.drawable.pin_ballon_bg);
            return ContextCompat.GetDrawable(MContext, Resource.Drawable.pin_ballon_bg);
        }

        public override Drawable[] GetCalloutRightAccessory(NMapOverlayItem item)
        {
            if (item is NMapPOIitem poiItem) 
            {
                if (poiItem.HasRightAccessory && (poiItem.RightAccessoryId > 0))
                {
                    Drawable[] drawable = new Drawable[3];

                    switch (poiItem.RightAccessoryId)
                    {
                        case NMapPOIflagType.CLICKABLE_ARROW:
                            drawable[0] = ContextCompat.GetDrawable(MContext, Resource.Drawable.pin_ballon_arrow);
                            drawable[1] = ContextCompat.GetDrawable(MContext, Resource.Drawable.pin_ballon_on_arrow);
                            drawable[2] = ContextCompat.GetDrawable(MContext, Resource.Drawable.pin_ballon_on_arrow);
                            break;
                    }

                    return drawable;
                }
            }

            return null;
        }

        public override Drawable[] GetCalloutRightButton(NMapOverlayItem item)
        {
            if (item is NMapPOIitem poiItem) {
                if (poiItem.ShowRightButton())
                {
                    Drawable[] drawable = new Drawable[3];

                    drawable[0] = ContextCompat.GetDrawable(MContext, Resource.Drawable.btn_green_normal);
                    drawable[1] = ContextCompat.GetDrawable(MContext, Resource.Drawable.btn_green_pressed);
                    drawable[2] = ContextCompat.GetDrawable(MContext, Resource.Drawable.btn_green_highlight);

                    return drawable;
                }
            }

            return null;
        }

        public override string GetCalloutRightButtonText(NMapOverlayItem item)
        {
            if (item is NMapPOIitem poiItem) {
                if (poiItem.ShowRightButton())
                {
                    return MContext.Resources.GetString(Resource.String.str_done);
                }
            }

            return null;
        }

        public override int[] GetCalloutTextColors(NMapOverlayItem p0)
        {
            int[] colors = new int[4];
            colors[0] = Color.ParseColor(CALLOUT_TEXT_COLOR_NORMAL).ToArgb();
            colors[1] = Color.ParseColor(CALLOUT_TEXT_COLOR_PRESSED).ToArgb();
            colors[2] = Color.ParseColor(CALLOUT_TEXT_COLOR_SELECTED).ToArgb();
            colors[3] = Color.ParseColor(CALLOUT_TEXT_COLOR_FOCUSED).ToArgb();
            return colors;
        }

        public override Drawable[] GetLocationDot()
        {
            Drawable[] drawable = new Drawable[2];

            drawable[0] = ContextCompat.GetDrawable(MContext, Resource.Drawable.pubtrans_ic_mylocation_off);
            drawable[1] = ContextCompat.GetDrawable(MContext, Resource.Drawable.pubtrans_ic_mylocation_on);

            for (int i = 0; i < drawable.Length; i++)
            {
                int w = drawable[i].IntrinsicWidth / 2;
                int h = drawable[i].IntrinsicHeight / 2;

                drawable[i].SetBounds(-w, -h, w, h);
            }

            return drawable;
        }

        public override void SetOverlappedItemResource(NMapPOIitem p0, ImageView p1)
        {
            
        }

        public override void SetOverlappedListViewLayout(ListView p0, int p1, int p2, int p3)
        {
            
        }

        protected override int FindResourceIdForMarker(int markerId, bool focused)
        {
            int resourceId = 0;

            if (DEBUG)
            {
                Log.Info(LOG_TAG, "getResourceIdForMarker: markerId=" + markerId + ", focused=" + focused);
            }

            if (markerId < NMapPOIflagType.SINGLE_MARKER_END)
            {
                resourceId = GetResourceIdOnMapView(markerId, focused, mResourceIdsForMarkerOnMap);
                if (resourceId > 0)
                {
                    return resourceId;
                }
            }

            if (markerId >= NMapPOIflagType.NUMBER_BASE && markerId < NMapPOIflagType.NUMBER_END)
            { // Direction Number icons

            }
            else if (markerId >= NMapPOIflagType.CUSTOM_BASE && markerId < NMapPOIflagType.CUSTOM_END)
            { // Custom POI icons

            }

            return resourceId;
        }

        protected override Drawable GetDrawableForMarker(int markerId, bool focused, NMapOverlayItem item)
        {
            Drawable drawable = null;

            if (markerId >= NMapPOIflagType.NUMBER_BASE && markerId < NMapPOIflagType.NUMBER_END)
            { // Direction Number icons
                int resourceId = (focused) ? Resource.Drawable.ic_map_no_02 : Resource.Drawable.ic_map_no_01;
                int fontColor = (focused) ? int.Parse(POI_FONT_COLOR_ALPHABET.Replace("#",string.Empty), System.Globalization.NumberStyles.HexNumber) 
                                               : int.Parse(POI_FONT_COLOR_NUMBER.Replace("#", string.Empty),System.Globalization.NumberStyles.HexNumber);

                string strNumber = (markerId - NMapPOIflagType.NUMBER_BASE).ToString();

                drawable = GetDrawableWithNumber(resourceId, strNumber, 0.0F, fontColor, POI_FONT_SIZE_NUMBER);
            }
            else if (markerId >= NMapPOIflagType.CUSTOM_BASE && markerId < NMapPOIflagType.CUSTOM_END)
            { // Custom POI icons

            }

            return drawable;
        }

        protected override void SetBounds(Drawable marker, int markerId, NMapOverlayItem item)
        {

            // check shape of the marker to set bounds correctly.
            if (NMapPOIflagType.IsBoundsCentered(markerId))
            {
                if (marker.Bounds.IsEmpty)
                {
                    NMapOverlayItem.BoundCenter(marker);
                }

                if (null != item)
                {
                    item.SetAnchorRatio(0.5f, 0.5f);
                }

            }
            else
            {
                if (marker.Bounds.IsEmpty)
                {
                    NMapOverlayItem.BoundCenterBottom(marker);
                }

                if (null != item)
                {
                    item.SetAnchorRatio(0.5f, 1.0f);
                }
            }
        }

		public override Drawable GetDrawableForInfoLayer(NMapOverlayItem p0)
		{
            return null;
		}
		#endregion

		#region private methods area
		int GetResourceIdOnMapView(int markerId, bool focused, ResourceIdsOnMap[] resourceIdsArray)
        {
            int resourceId = 0;

            foreach (var resourceIds in resourceIdsArray)
            {
                if (resourceIds.markerId == markerId)
                {
                    resourceId = (focused) ? resourceIds.resourceIdFocused : resourceIds.resourceId;
                    break;
                }
            }

            return resourceId;
        }

        Bitmap GetBitmapWithText(int resourceId, string strNumber, int fontColor, float fontSize, float offsetY)
        {
            Bitmap bitmapBackground = BitmapFactory.DecodeResource(MContext.Resources, resourceId);

            int width = bitmapBackground.Width;
            int height = bitmapBackground.Height;
            //Log.i(LOG_TAG, ": width=" + width + ", height=" + height + ", density=" + bitmapBackground.getDensity());

            Bitmap textBitmap = Bitmap.CreateBitmap(width, height, BITMAP_CONFIG_DEFAULT);

            Canvas canvas = new Canvas(textBitmap);

            canvas.DrawBitmap(bitmapBackground, 0, 0, null);

            // set font style
            mTextPaint.Color = new Color(fontColor);
            // set font size
            mTextPaint.TextSize = fontSize * MScaleFactor;
            // set font type
            if (POI_FONT_TYPEFACE != null)
            {
                mTextPaint.SetTypeface(POI_FONT_TYPEFACE);
            }

            // get text offset      
            mTextPaint.GetTextBounds(strNumber, 0, strNumber.Length, mTempRect);
            float offsetX = (width - mTempRect.Width() / 2 - mTempRect.Left);
            if (offsetY == 0.0F)
            {
                offsetY = (height - mTempRect.Height()) / 2 + mTempRect.Height();
            }
            else
            {
                offsetY = offsetY * MScaleFactor + mTempRect.Height();
            }

            //Log.i(LOG_TAG, "getBitmapWithText: number=" + number + ", focused=" + focused);
            //Log.i(LOG_TAG, "getBitmapWithText: offsetX=" + offsetX + ", offsetY=" + offsetY + ", boundsWidth=" + mTempRect.width() + ", boundsHeight=" + mTempRect.height());

            // draw text
            canvas.DrawText(strNumber, offsetX, offsetY, mTextPaint);

            return textBitmap;
        }
        #endregion

        #region private class area
        /**
         * Class to find resource Ids on map view
         */
        private class ResourceIdsOnMap
        {

            internal readonly int markerId;
            internal readonly int resourceId;
            internal readonly int resourceIdFocused;

            internal ResourceIdsOnMap(int markerId, int resourceId, int resourceIdFocused)
            {
                this.markerId = markerId;
                this.resourceId = resourceId;
                this.resourceIdFocused = resourceIdFocused;
            }
        }
        #endregion
    }
}
