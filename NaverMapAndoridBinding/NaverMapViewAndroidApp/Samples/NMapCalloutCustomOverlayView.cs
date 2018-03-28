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
using Android.Views;
using Android.Widget;
using Com.Nhn.Android.Maps;
using Com.Nhn.Android.Maps.Overlay;
using Com.Nhn.Android.Mapviewer.Overlay;
using static Android.Views.View;

namespace NaverMapViewAndroidApp.Samples
{
    public class NMapCalloutCustomOverlayView : NMapCalloutOverlayView, IOnClickListener
    {
        #region private member fields area
        View mCalloutView;
        TextView mCalloutText;
        View mRightArrow;
        #endregion

        public NMapCalloutCustomOverlayView(Context context, NMapOverlay itemOverlay, NMapOverlayItem item, Rect itemBounds) : base(context, itemOverlay, item, itemBounds)
        {
            string infService = Context.LayoutInflaterService;
            LayoutInflater li = (LayoutInflater)Context.GetSystemService(infService);
            li.Inflate(Resource.Layout.Callout_Overlay_View, this, true);

            mCalloutView = FindViewById(Resource.Id.callout_overlay);
            mCalloutText = mCalloutView.FindViewById<TextView>(Resource.Id.callout_text);
            mRightArrow = FindViewById(Resource.Id.callout_rightArrow);

            mCalloutView.SetOnClickListener(this);
            //mCalloutView.Click += OnClick;

            mCalloutText.Text = item.Title;

            if (item is NMapPOIitem mapItem)
            {
                if (!mapItem.HasRightAccessory)
                {
                    mRightArrow.Visibility = ViewStates.Gone;
                }
            }
        }

        #region Implement IOnClickListener
        public void OnClick(View v)
        {
            if (mOnClickListener != null)
            {
                mOnClickListener.OnClick(null, mItemOverlay, mOverlayItem);
            }
        }

        //mCalloutView.Click 이벤트 이용시
        //public void OnClick(object sender, EventArgs e)
        //{
        //    if (mOnClickListener != null)
        //    {
        //        mOnClickListener.OnClick(null, mItemOverlay, mOverlayItem);
        //    }
        //}
        #endregion
    }
}
