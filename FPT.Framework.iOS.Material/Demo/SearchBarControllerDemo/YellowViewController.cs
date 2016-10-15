using System;
using UIKit;
using FPT.Framework.iOS.Material;
namespace SearchBarControllerDemo
{
	public class YellowViewController : UIViewController
	{
		public YellowViewController()
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			prepareView();
		}

		private void prepareView()
		{
			View.BackgroundColor = MaterialColor.Yellow.Base;
		}
	}
}
