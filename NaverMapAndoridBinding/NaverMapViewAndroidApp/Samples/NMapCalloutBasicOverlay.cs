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
using Android.Graphics;
using Android.Graphics.Drawables;
using Com.Nhn.Android.Maps;
using Com.Nhn.Android.Mapviewer.Overlay;

namespace NaverMapViewAndroidApp.Samples
{
    public class NMapCalloutBasicOverlay : NMapCalloutOverlay
    {
        #region private member fields area
        const int CALLOUT_TEXT_PADDING_X = 10;
        const int CALLOUT_TEXT_PADDING_Y = 10;
        const int CALLOUT_TAG_WIDTH = 10;
        const int CALLOUT_TAG_HEIGHT = 10;
        const int CALLOUT_ROUND_RADIUS_X = 5;
        const int CALLOUT_ROUND_RADIUS_Y = 5;

        readonly Paint mInnerPaint, mBorderPaint, mTextPaint;
        readonly Path mPath;
        float mOffsetX, mOffsetY;
        #endregion

        #region Constructor Area
        public NMapCalloutBasicOverlay(NMapOverlay itemOverlay, NMapOverlayItem item, Rect itemBounds) : base(itemOverlay, item, itemBounds)
        {
            mInnerPaint = new Paint();
            mInnerPaint.SetARGB(225, 75, 75, 75); //gray
            mInnerPaint.AntiAlias = true;

            mBorderPaint = new Paint();
            mBorderPaint.SetARGB(255, 255, 255, 255);
            mBorderPaint.AntiAlias = true;
            mBorderPaint.SetStyle(Paint.Style.Stroke);
            mBorderPaint.StrokeWidth = 2;

            mTextPaint = new Paint();
            mTextPaint.SetARGB(255, 255, 255, 255);
            mTextPaint.AntiAlias = true;

            mPath = new Path();
            mPath.SetFillType(Path.FillType.Winding);
        }
        #endregion

        #region override methods Area
        protected override bool IsTitleTruncated => false;

        protected override int MarginX => 10;

        protected override PointF SclaingPivot
        {
            get
            {
                PointF pivot = new PointF();
                pivot.X = MTempRectF.CenterX();
                pivot.Y = MTempRectF.Bottom + CALLOUT_TAG_HEIGHT;

                return pivot;
            }
        }

        protected override void DrawCallout(Canvas canvas, NMapView mapView, bool shadow, long when)
        {
            AdjustTextBounds(mapView);

            StepAnimations(canvas, mapView, when);

            // Draw inner info window
            canvas.DrawRoundRect(MTempRectF, CALLOUT_ROUND_RADIUS_X, CALLOUT_ROUND_RADIUS_Y, mInnerPaint);

            // Draw border for info window
            canvas.DrawRoundRect(MTempRectF, CALLOUT_ROUND_RADIUS_X, CALLOUT_ROUND_RADIUS_Y, mBorderPaint);

            // Draw bottom tag
            if (CALLOUT_TAG_WIDTH > 0 && CALLOUT_TAG_HEIGHT > 0)
            {
                float x = MTempRectF.CenterX();
                float y = MTempRectF.Bottom;

                Path path = mPath;
                path.Reset();

                path.MoveTo(x - CALLOUT_TAG_WIDTH, y);
                path.LineTo(x, y + CALLOUT_TAG_HEIGHT);
                path.LineTo(x + CALLOUT_TAG_WIDTH, y);
                path.Close();

                canvas.DrawPath(path, mInnerPaint);
                canvas.DrawPath(path, mBorderPaint);
            }

            //  Draw title
            canvas.DrawText(MOverlayItem.Title, mOffsetX, mOffsetY, mTextPaint);
        }

        protected override Rect GetBounds(NMapView mapView)
        {
            AdjustTextBounds(mapView);

            MTempRect.Set((int)MTempRectF.Left, (int)MTempRectF.Top, (int)MTempRectF.Right, (int)MTempRectF.Bottom);
            MTempRect.Union(MTempPoint.X, MTempPoint.Y);

            return MTempRect;
        }

        protected override Drawable GetDrawable(int p0, int p1)
        {
            return null;
        }
        #endregion

        #region private methods area
        void AdjustTextBounds(NMapView mapView)
        {
            //  Determine the screen coordinates of the selected MapLocation
            mapView.MapProjection.ToPixels(MOverlayItem.PointInUtmk, MTempPoint);

            var title = MOverlayItem.Title;
            mTextPaint.GetTextBounds(title, 0, title.Length, MTempRect);

            //  Setup the callout with the appropriate size & location
            MTempRectF.Set(MTempRect);
            MTempRectF.Inset(-CALLOUT_TEXT_PADDING_X, -CALLOUT_TEXT_PADDING_Y);
            mOffsetX = MTempPoint.X - MTempRect.Width() / 2;
            mOffsetY = MTempPoint.Y - MTempRect.Height() - MItemBounds.Height() - CALLOUT_TEXT_PADDING_Y;
            MTempRectF.Offset(mOffsetX, mOffsetY);
        }

        #endregion
    }
}
