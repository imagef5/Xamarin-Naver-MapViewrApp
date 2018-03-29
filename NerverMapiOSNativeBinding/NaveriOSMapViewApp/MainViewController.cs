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
using Foundation;
using System;
using UIKit;

namespace NaveriOSMapViewApp
{
    public partial class MainViewController : UITableViewController
    {
        public MainViewController (IntPtr handle) : base (handle)
        {
        }

		public override void ViewDidLoad()
		{
            base.ViewDidLoad();
		}

		public override void DidReceiveMemoryWarning()
		{
            base.DidReceiveMemoryWarning();
		}

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
            //base.RowSelected(tableView, indexPath);
            switch(indexPath.Row)
            {
                case 1 :
                    {
                        var viewController = new LocationMapViewController
                        {
                            Title = "내위치"
                        };
                        this.NavigationController.PushViewController(viewController, true);
                    }
                    break;
                case 2 :
                    {
                        var viewController = new ReverseGeocoderViewController
                        {
                            Title = "주소찾기"
                        };
                        this.NavigationController.PushViewController(viewController, true);
                    }
                    break;
                case 4 :
                    {
                        var viewController = new MovableMarkerViewController
                        {
                            Title = "마커 그리기"
                        };
                        this.NavigationController.PushViewController(viewController, true);
                    }
                    break;
                case 5 :
                    {
                        var viewController = new PolylinesViewController
                        {
                            Title = "선그리"
                        };
                        this.NavigationController.PushViewController(viewController, true);
                    }
                    break;
                case 6 :
                    {
                        var viewController = new PolygonsViewController
                        {
                            Title = "폴리곤 그리기"
                        };
                        this.NavigationController.PushViewController(viewController, true);
                    }
                    break;
                case 7 :
                    {
                        var viewController = new CirclesViewController
                        {
                            Title = "원그리"
                        };
                        this.NavigationController.PushViewController(viewController, true);
                    }
                    break;
                default:
                    break;
            }
		}
	}
}