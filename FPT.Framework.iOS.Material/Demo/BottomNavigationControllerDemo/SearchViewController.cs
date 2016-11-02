using System;
using UIKit;
using FPT.Framework.iOS.Material;

namespace BottomNavigationControllerDemo
{
	public class SearchViewController : UIViewController
	{
		public SearchViewController() : base()
		{
			prepareTabBarItem();
		}

		private void prepareTabBarItem()
		{
			TabBarItem.Image = Icon.CM.Search.TintWithColor(Color.BlueGrey.Base);
			TabBarItem.SelectedImage = Icon.CM.Search.TintWithColor(Color.Blue.Base);
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			View.BackgroundColor = Color.BlueGrey.Base;
		}
	}
}
