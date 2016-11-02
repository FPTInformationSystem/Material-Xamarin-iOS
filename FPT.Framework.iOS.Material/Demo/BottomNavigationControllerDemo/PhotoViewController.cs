using System;
using UIKit;
using FPT.Framework.iOS.Material;

namespace BottomNavigationControllerDemo
{
	public class PhotoViewController : UIViewController
	{
		public PhotoViewController() : base()
		{
			prepareTabBarItem();
		}

		private void prepareTabBarItem()
		{
			TabBarItem.Image = Icon.CM.PhotoCamera.TintWithColor(Color.BlueGrey.Base);
			TabBarItem.SelectedImage = Icon.CM.PhotoCamera.TintWithColor(Color.Blue.Base);
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			View.BackgroundColor = Color.Red.Base;
		}
	}
}
