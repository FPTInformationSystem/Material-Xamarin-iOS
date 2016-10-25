using System;
using FPT.Framework.iOS.Material;
using UIKit;

namespace PageTabBarControllerDemo
{
	public partial class AppPageTabBarController : PageTabBarController
	{
		public AppPageTabBarController(UIViewController[] viewControllers, int selectedIndex) : base(viewControllers, selectedIndex)
		{
			
		}

		public override void Prepare()
		{
			base.Prepare();

			Delegate = new AppPageTabBarController_PageTabBarControllerDelegate();
		}

		private void preparePageTabBar()
		{
			PageTabBar.LineColor = Color.BlueGrey.Base;
			PageTabBar.SetDividerColor(Color.BlueGrey.Lighten5);
		}

		private class AppPageTabBarController_PageTabBarControllerDelegate : PageTabBarControllerDelegate
		{
			public override void DidTransitionTo(PageTabBarController pageTabBarController, UIViewController viewController)
			{
				base.DidTransitionTo(pageTabBarController, viewController);
				System.Diagnostics.Debug.WriteLine(String.Format("pageTabBarController {0} didTransitionTo viewController:\" {1}", pageTabBarController, viewController));
			}
		}
	}
}

