using System;
using UIKit;
using FPT.Framework.iOS.Material;

namespace BottomNavigationControllerDemo
{
	public class AudioViewController : UIViewController
	{
		public AudioViewController() : base()
		{
			prepareTabBarItem();
		}

		private void prepareTabBarItem()
		{
			TabBarItem.Image = Icon.CM.AudioLibrary.TintWithColor(Color.BlueGrey.Base);
			TabBarItem.SelectedImage = Icon.CM.AudioLibrary.TintWithColor(Color.Blue.Base);
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			View.BackgroundColor = Color.Blue.Base;
		}
	}
}
