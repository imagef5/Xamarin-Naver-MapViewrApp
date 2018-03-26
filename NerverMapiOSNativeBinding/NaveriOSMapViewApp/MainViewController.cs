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