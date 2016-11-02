using System;
using UIKit;
using FPT.Framework.iOS.Material;

namespace BottomNavigationControllerDemo
{
	public class RemindersViewController : UIViewController
	{
		public RemindersViewController() : base()
		{
			prepareTabBarItem();
		}

		private void prepareTabBarItem()
		{
			TabBarItem.Image = Icon.CM.Bell.TintWithColor(Color.BlueGrey.Base);
			TabBarItem.SelectedImage = Icon.CM.Bell.TintWithColor(Color.Blue.Base);
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			View.BackgroundColor = Color.Yellow.Base;
		}
	}
}
