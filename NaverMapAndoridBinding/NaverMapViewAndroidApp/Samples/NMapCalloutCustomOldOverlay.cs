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
using Android.Text;
using Android.Util;
using Com.Nhn.Android.Maps;
using Com.Nhn.Android.Mapviewer.Overlay;
using Java.Lang;

namespace NaverMapViewAndroidApp.Samples
{
    public class NMapCalloutCustomOldOverlay : NMapCalloutOverlay
    {
        #region private member fields area
        const string LOG_TAG = "NMapCalloutCustomOverlay";
        const bool DEBUG = false;

        const string CALLOUT_TEXT_COLOR = "#FFFFFFFF";
        const float CALLOUT_TEXT_SIZE = 16.0F;
        const Typeface CALLOUT_TEXT_TYPEFACE = null;//Typeface.DEFAULT_BOLD;

        const float CALLOUT_RIGHT_BUTTON_WIDTH = 50.67F;
        const float CALLOUT_RIGHT_BUTTON_HEIGHT = 34.67F;

        const float CALLOUT_MARGIN_X = 9.33F;
        const float CALLOUT_PADDING_X = 9.33F;
        const float CALLOUT_PADDING_OFFSET = 0.45F;
        const float CALLOUT_PADDING_Y = 17.33F;
        const float CALLOUT_MIMIMUM_WIDTH = 63.33F;
        const float CALLOUT_TOTAL_HEIGHT = 64.0F;
        const float CALLOUT_BACKGROUND_HEIGHT = CALLOUT_PADDING_Y + CALLOUT_TEXT_SIZE + CALLOUT_PADDING_Y;
        const float CALLOUT_ITEM_GAP_Y = 0.0F;
        const float CALLOUT_TAIL_GAP_X = 6.67F;
        const float CALLOUT_TITLE_OFFSET_Y = -2.0F;

        readonly TextPaint mTextPaint = new TextPaint();
        float mOffsetX, mOffsetY;

        readonly float mMarginX;
        readonly float mPaddingX, mPaddingY, mPaddingOffset;
        readonly float mMinimumWidth;
        readonly float mTotalHeight;
        readonly float mBackgroundHeight;
        readonly float mItemGapY;
        readonly float mTailGapX;
        readonly float mTitleOffsetY;

        readonly Drawable mBackgroundDrawable;
        protected readonly Rect mTemp2Rect = new Rect();
        readonly Rect mRightButtonRect;
        readonly string mRightButtonText;
        readonly int mCalloutRightButtonWidth;
        readonly int mCalloutRightButtonHeight;
        Drawable[] mDrawableRightButton;
        readonly int mCalloutButtonCount = 1;

        string mTitleTruncated;
        int mWidthTitleTruncated;

        readonly string mTailText;
        float mTailTextWidth;
        #endregion

        public NMapCalloutCustomOldOverlay(NMapOverlay itemOverlay, NMapOverlayItem item, Rect itemBounds,
                                           IResourceProvider resourceProvider) : base(itemOverlay, item, itemBounds)
        {
            mTextPaint.AntiAlias = true;
            // set font style
            mTextPaint.Color = Color.ParseColor(CALLOUT_TEXT_COLOR);
            // set font size
            mTextPaint.TextSize = CALLOUT_TEXT_SIZE * NMapResourceProvider.ScaleFactor;
            // set font type
            if (CALLOUT_TEXT_TYPEFACE != null)
            {
                mTextPaint.SetTypeface(CALLOUT_TEXT_TYPEFACE);
            }

            mMarginX = NMapResourceProvider.ToPixelFromDIP(CALLOUT_MARGIN_X);
            mPaddingX = NMapResourceProvider.ToPixelFromDIP(CALLOUT_PADDING_X);
            mPaddingOffset = NMapResourceProvider.ToPixelFromDIP(CALLOUT_PADDING_OFFSET);
            mPaddingY = NMapResourceProvider.ToPixelFromDIP(CALLOUT_PADDING_Y);
            mMinimumWidth = NMapResourceProvider.ToPixelFromDIP(CALLOUT_MIMIMUM_WIDTH);
            mTotalHeight = NMapResourceProvider.ToPixelFromDIP(CALLOUT_TOTAL_HEIGHT);
            mBackgroundHeight = NMapResourceProvider.ToPixelFromDIP(CALLOUT_BACKGROUND_HEIGHT);
            mItemGapY = NMapResourceProvider.ToPixelFromDIP(CALLOUT_ITEM_GAP_Y);

            mTailGapX = NMapResourceProvider.ToPixelFromDIP(CALLOUT_TAIL_GAP_X);
            mTailText = item.TailText;

            mTitleOffsetY = NMapResourceProvider.ToPixelFromDIP(CALLOUT_TITLE_OFFSET_Y);

            if (resourceProvider == null)
            {
                throw new IllegalArgumentException(
                    "NMapCalloutCustomOverlay.ResourceProvider should be provided on creation of NMapCalloutCustomOverlay.");
            }

            mBackgroundDrawable = resourceProvider.GetCalloutBackground(item);

            bool hasRightAccessory = false;
            mDrawableRightButton = resourceProvider.GetCalloutRightAccessory(item);
            if (mDrawableRightButton != null && mDrawableRightButton.Length > 0)
            {
                hasRightAccessory = true;

                mRightButtonText = null;
            }
            else
            {
                mDrawableRightButton = resourceProvider.GetCalloutRightButton(item);
                mRightButtonText = resourceProvider.GetCalloutRightButtonText(item);
            }

            if (mDrawableRightButton != null)
            {
                if (hasRightAccessory)
                {
                    mCalloutRightButtonWidth = mDrawableRightButton[0].IntrinsicWidth;
                    mCalloutRightButtonHeight = mDrawableRightButton[0].IntrinsicHeight;
                }
                else
                {
                    mCalloutRightButtonWidth = NMapResourceProvider.ToPixelFromDIP(CALLOUT_RIGHT_BUTTON_WIDTH);
                    mCalloutRightButtonHeight = NMapResourceProvider.ToPixelFromDIP(CALLOUT_RIGHT_BUTTON_HEIGHT);
                }

                mRightButtonRect = new Rect();

                base.ItemCount = mCalloutButtonCount;
            }
            else
            {
                mCalloutRightButtonWidth = 0;
                mCalloutRightButtonHeight = 0;
                mRightButtonRect = null;
            }

            mTitleTruncated = null;
            mWidthTitleTruncated = 0;
        }

        #region override methods area
        protected override bool HitTest(int p0, int p1)
        {
            return base.HitTest(p0, p1);
        }

        protected override bool IsTitleTruncated => mTitleTruncated != MOverlayItem.Title;

        protected override int MarginX => (int)mMarginX;

        protected override PointF SclaingPivot
        {
            get
            {
                PointF pivot = new PointF();
                pivot.X = MTempRectF.CenterX();
                pivot.Y = MTempRectF.Top + mTotalHeight;

                return pivot;
            }
        }

        protected override void DrawCallout(Canvas canvas, NMapView mapView, bool shadow, long when)
        {
            AdjustTextBounds(mapView);

            StepAnimations(canvas, mapView, when);

            DrawBackground(canvas);

            float left, top;

            // draw title
            mOffsetX = MTempPoint.X - MTempRect.Width() / 2;
            mOffsetX -= mPaddingOffset;
            mOffsetY = MTempRectF.Top + mPaddingY + mTextPaint.TextSize + mTitleOffsetY;
            canvas.DrawText(mTitleTruncated, mOffsetX, mOffsetY, mTextPaint);

            // draw right button
            if (mDrawableRightButton != null)
            {
                left = MTempRectF.Right - mPaddingX - mCalloutRightButtonWidth;
                top = MTempRectF.Top + (mBackgroundHeight - mCalloutRightButtonHeight) / 2;

                // Use background drawables depends on current state
                mRightButtonRect.Left = (int)(left + 0.5F);
                mRightButtonRect.Top = (int)(top + 0.5F);
                mRightButtonRect.Right = (int)(left + mCalloutRightButtonWidth + 0.5F);
                mRightButtonRect.Bottom = (int)(top + mCalloutRightButtonHeight + 0.5F);

                int itemState = base.GetItemState(0);
                Drawable drawable = GetDrawable(0, itemState);
                if (drawable != null)
                {
                    drawable.Bounds = mRightButtonRect;
                    drawable.Draw(canvas);
                }

                if (mRightButtonText != null)
                {
                    mTextPaint.GetTextBounds(mRightButtonText, 0, mRightButtonText.Length, MTempRect);

                    left = mRightButtonRect.Left + (mCalloutRightButtonWidth - MTempRect.Width()) / 2;
                    top = mRightButtonRect.Top + (mCalloutRightButtonHeight - MTempRect.Height()) / 2 + MTempRect.Height() + mTitleOffsetY;
                    canvas.DrawText(mRightButtonText, left, top, mTextPaint);
                }
            }

            // draw tail text
            if (mTailText != null)
            {
                if (mRightButtonRect != null)
                {
                    left = mRightButtonRect.Left;
                }
                else
                {
                    left = MTempRectF.Right;
                }
                left -= mPaddingX + mTailTextWidth;
                top = mOffsetY;

                canvas.DrawText(mTailText, left, top, mTextPaint);
            }
        }

        protected override Rect GetBounds(NMapView mapView)
        {
            AdjustTextBounds(mapView);

            MTempRect.Set((int)MTempRectF.Left, (int)MTempRectF.Top, (int)MTempRectF.Right, (int)MTempRectF.Bottom);
            MTempRect.Union(MTempPoint.X, MTempPoint.Y);

            return MTempRect;
        }

        protected override Drawable GetDrawable(int rank, int itemState)
        {
            if (mDrawableRightButton != null && mDrawableRightButton.Length >= 3)
            {
                int idxDrawable = 0;
                if (NMapOverlayItem.IsPressedState(itemState))
                {
                    idxDrawable = 1;
                }
                else if (NMapOverlayItem.IsSelectedState(itemState))
                {
                    idxDrawable = 2;
                }
                else if (NMapOverlayItem.IsFocusedState(itemState))
                {
                    idxDrawable = 2;
                }
                Drawable drawable = mDrawableRightButton[idxDrawable];
                return drawable;
            }

            return null;
        }
        #endregion

        #region private method area
        void DrawBackground(Canvas canvas)
        {
            mTemp2Rect.Left = (int)(MTempRectF.Left + 0.5F);
            mTemp2Rect.Top = (int)(MTempRectF.Top + 0.5F);
            mTemp2Rect.Right = (int)(MTempRectF.Right + 0.5F);
            mTemp2Rect.Bottom = (int)(MTempRectF.Top + mTotalHeight + 0.5F);

            mBackgroundDrawable.Bounds = mTemp2Rect;
            mBackgroundDrawable.Draw(canvas);
        }

        void AdjustTextBounds(NMapView mapView)
        {

            //  First determine the screen coordinates of the selected MapLocation
            mapView.MapProjection.ToPixels(MOverlayItem.PointInUtmk, MTempPoint);

            int mapViewWidth = mapView.MapController.ViewFrameVisibleWidth;
            if (mTitleTruncated == null || mWidthTitleTruncated != mapViewWidth)
            {
                mWidthTitleTruncated = mapViewWidth;
                float maxWidth = mWidthTitleTruncated - 2 * mMarginX - 2 * mPaddingX;
                if (DEBUG)
                {
                    Log.Info(LOG_TAG, "adjustTextBounds: maxWidth=" + maxWidth + ", mMarginX=" + mMarginX + ", mPaddingX="
                        + mPaddingX);
                }

                if (mDrawableRightButton != null)
                {
                    maxWidth -= mPaddingX + mCalloutRightButtonWidth;
                }

                if (mTailText != null)
                {
                    mTextPaint.GetTextBounds(mTailText, 0, mTailText.Length, MTempRect);
                    mTailTextWidth = MTempRect.Width();

                    maxWidth -= mTailGapX + mTailTextWidth;
                }

                var title = TextUtils.Ellipsize(MOverlayItem.Title, mTextPaint, maxWidth,
                                                TextUtils.TruncateAt.End).ToString();

                mTitleTruncated = title;

                if (DEBUG)
                {
                    Log.Info(LOG_TAG, "adjustTextBounds: mTitleTruncated=" + mTitleTruncated + ", length="
                             + mTitleTruncated.Length);
                }
            }

            mTextPaint.GetTextBounds(mTitleTruncated, 0, mTitleTruncated.Length, MTempRect);

            if (mDrawableRightButton != null)
            {
                MTempRect.Right += (int)(mPaddingX + mCalloutRightButtonWidth);
            }

            if (mTailText != null)
            {
                MTempRect.Right += (int)(mTailGapX + mTailTextWidth);
            }

            if (DEBUG)
            {
                Log.Info(LOG_TAG, "adjustTextBounds: mTempRect.width=" + MTempRect.Width() + ", mTempRect.height="
                         + MTempRect.Height());
            }

            //  Setup the callout with the right size & location
            MTempRectF.Set(MTempRect);
            var dy = (mBackgroundHeight - MTempRect.Height()) / 2;
            MTempRectF.Inset(-mPaddingX, -dy);
            //mTempRectF.inset(-mPaddingX, -mPaddingY);

            // set minimum size
            if (MTempRectF.Width() < mMinimumWidth)
            {
                var dx = (mMinimumWidth - MTempRectF.Width()) / 2;
                MTempRectF.Inset(-dx, 0);
            }

            // set position
            float left = MTempPoint.X - (int)(MTempRectF.Width() * MOverlayItem.AnchorXRatio);
            float top = MTempPoint.Y - (int)(MItemBounds.Height() * MOverlayItem.AnchorYRatio) - mItemGapY - mTotalHeight;
            MTempRectF.Set(left, top, left + MTempRectF.Width(), top + MTempRectF.Height());
        }
        #endregion
    }
}
