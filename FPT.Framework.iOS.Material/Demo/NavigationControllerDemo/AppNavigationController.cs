using System;
using UIKit;
using FPT.Framework.iOS.Material;

namespace NavigationControllerDemo
{
	public class AppNavigationController : NavigationController
	{
		public AppNavigationController(UIViewController rootViewController) : base(rootViewController) { }

		public override void Prepare()
		{
			base.Prepare();
			if (NavigationBar != null && NavigationBar is NavigationBar)
			{
				NavigationBar.SetDepthPreset(DepthPreset.None);
				NavigationBar.SetDividerColor(Color.Grey.Lighten3);
			}
		}
	}
}
