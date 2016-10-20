using System;
using FPT.Framework.iOS.Material;
using UIKit;

namespace StatusBarControllerDemo
{
	public class AppStatusBarController : StatusBarController
	{
		public AppStatusBarController(UIViewController rootViewController) : base(rootViewController) { }

		public override void Prepare()
		{
			base.Prepare();

			prepareStatusBar();
		}

		private void prepareStatusBar()
		{
			StatusBarStyle = UIStatusBarStyle.LightContent;
			StatusBar.BackgroundColor = Color.Blue.Base;
		}
	}
}
