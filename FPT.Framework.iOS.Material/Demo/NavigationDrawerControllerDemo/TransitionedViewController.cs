using System;
using UIKit;
using FPT.Framework.iOS.Material;

namespace NavigationDrawerControllerDemo
{
	public class TransitionedViewController :UIViewController
	{
		public TransitionedViewController()
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			View.BackgroundColor = Color.Purple.Base;
			PrepareToolbar();
		}

		private void PrepareToolbar()
		{
			var tc = new ToolbarController(new RootViewController());
			tc.Toolbar.Title = "Transitioned";
			tc.Toolbar.Detail = "View Controller";
		}
	}
}
