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

using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Views.Animations;
using Android.Widget;
using Com.Nhn.Android.Maps;
using Com.Nhn.Android.Maps.Maplib;
using Com.Nhn.Android.Mapviewer.Overlay;
using static Com.Nhn.Android.Mapviewer.Overlay.NMapOverlayManager;

namespace NaverMapViewAndroidApp.Samples
{
    public class NMapCalloutOverlayView : FrameLayout, ICalloutOverlayViewInterface
    {
        #region private member fields area
        protected NMapOverlayItem mOverlayItem;
        protected Rect mItemBounds;
        protected NMapCalloutOverlay.IOnClickListener mOnClickListener;
        protected NMapOverlay mItemOverlay;

        const long SCALE_DURATION_MILLS = 200L;
        const float CALLOUT_MARGIN_X = 13.33F;
        readonly float mMarginX;

        protected readonly Point mTempPoint = new Point();
        protected readonly Rect mTempRect = new Rect();
        #endregion

        #region Constructor Area
        public NMapCalloutOverlayView(Context context, NMapOverlay itemOverlay, NMapOverlayItem item, Rect itemBounds) : base(context)
        {
            mOverlayItem = item;
            mItemBounds = itemBounds;
            mOnClickListener = null;
            mItemOverlay = itemOverlay;

            int px = 0;
            int py = (int)(mItemBounds.Height() * mOverlayItem.AnchorYRatio);
            NMapView.LayoutParams lp = new NMapView.LayoutParams(NMapView.LayoutParams.WrapContent,
                                                                 NMapView.LayoutParams.WrapContent,
                                                                 mOverlayItem.Point, px, -py,
                                                                 NMapView.LayoutParams.BottomCenter);
            this.LayoutParameters = lp;

            mMarginX = NMapResourceProvider.ToPixelFromDIP(CALLOUT_MARGIN_X);
        }
        #endregion

        #region Implement ICalloutOverlayViewInterface
        public void AdjustBounds(NMapView mapView, bool animate, bool adjustToCenter)
        {
            if (adjustToCenter)
            {
                NGeoPoint pt = mOverlayItem.Point;
                if (animate)
                {
                    mapView.MapController.AnimateTo(pt, true);
                }
                else
                {
                    mapView.MapController.MapCenter = pt;
                }

            }
            else
            {
                Rect boundsVisible = mapView.MapController.BoundsVisible;
                Rect bounds = GetBounds(mapView);

                int marginX = MarginX;

                if (!boundsVisible.Contains(bounds))
                {

                    int centerX = 0;
                    if (bounds.Width() >= boundsVisible.Width())
                    {
                        centerX = bounds.CenterX();
                    }
                    else
                    {
                        if (bounds.Left < boundsVisible.Left)
                        {
                            centerX = boundsVisible.Left - bounds.Left + marginX;
                        }
                        else if (bounds.Right > boundsVisible.Right)
                        {
                            centerX = boundsVisible.Right - bounds.Right - marginX;
                        }
                        centerX = boundsVisible.CenterX() - centerX;
                    }

                    int centerY = 0;
                    if (bounds.Top < boundsVisible.Top)
                    {
                        centerY = boundsVisible.Top - bounds.Top + marginX;
                    }
                    else if (bounds.Bottom > boundsVisible.Bottom)
                    {
                        centerY = boundsVisible.Bottom - bounds.Bottom - marginX;
                    }
                    centerY = boundsVisible.CenterY() - centerY;

                    NGeoPoint pt = mapView.MapProjection.FromPixels(centerX, centerY);
                    if (animate)
                    {
                        mapView.MapController.AnimateTo(pt, true);
                    }
                    else
                    {
                        mapView.MapController.MapCenter = pt;
                    }
                }
            }

            if (animate)
            {
                AnimateCallout();
            }
        }

        public bool IsCalloutViewInVisibleBounds(NMapView mapView)
        {
            if (this.Visibility == ViewStates.Visible)
            {
                Rect boundsVisible = mapView.MapController.BoundsVisible;
                Rect bounds = GetBounds(mapView);

                return Rect.Intersects(boundsVisible, bounds);
            }

            return false;
        }

        public void SetOnClickListener(NMapCalloutOverlay.IOnClickListener listener)
        {
            mOnClickListener = listener;
        }
        #endregion

        #region private method area
        private Rect GetBounds(NMapView mapView)
        {
            //  First determine the screen coordinates of the selected MapLocation
            mapView.MapProjection.ToPixels(mOverlayItem.PointInUtmk, mTempPoint);

            mTempRect.Left = this.Left;
            mTempRect.Top = this.Top;
            mTempRect.Right = this.Right;
            mTempRect.Bottom = this.Bottom;

            mTempRect.Union(mTempPoint.X, mTempPoint.Y);

            return mTempRect;
        }

        private void AnimateCallout()
        {

            // Create a scale animation
            ScaleAnimation animation = new ScaleAnimation(0.5f, 1.0f, 0.5f, 1.0f, Dimension.RelativeToSelf, 0.5f,
                                                          Dimension.RelativeToSelf, 1.0f);

            animation.Duration = SCALE_DURATION_MILLS;

            this.StartAnimation(animation);
        }

        private int MarginX => (int)mMarginX;
        #endregion
    }
}
