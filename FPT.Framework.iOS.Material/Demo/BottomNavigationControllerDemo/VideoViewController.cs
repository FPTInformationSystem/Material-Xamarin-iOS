using System;
using UIKit;
using FPT.Framework.iOS.Material;

namespace BottomNavigationControllerDemo
{
	public class VideoViewController : UIViewController
	{
		public VideoViewController() : base()
		{
			prepareTabBarItem();
		}

		private void prepareTabBarItem()
		{
			TabBarItem.Image = Icon.CM.Videocam.TintWithColor(Color.BlueGrey.Base);
			TabBarItem.SelectedImage = Icon.CM.Videocam.TintWithColor(Color.Blue.Base);
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			View.BackgroundColor = Color.Green.Base;
		}
	}
}
