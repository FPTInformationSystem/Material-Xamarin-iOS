using System;
using UIKit;
using FPT.Framework.iOS.Material;

namespace NavigationControllerDemo
{
	public class NextViewController : UIViewController
	{
		public NextViewController() : base() { }

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			View.BackgroundColor = Color.Blue.Base;

			prepareNavigationItem();
		}

		private void prepareNavigationItem()
		{
			NavigationItem.SetTitle("Title");
			NavigationItem.SetDetail("Detail Description");
		}
	}
}
