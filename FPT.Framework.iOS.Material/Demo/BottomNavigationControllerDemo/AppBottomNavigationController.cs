using System;
using UIKit;
using FPT.Framework.iOS.Material;

namespace BottomNavigationControllerDemo
{
	public class AppBottomNavigationController : BottomNavigationController
	{
		public AppBottomNavigationController(UIViewController[] viewControllers) : base(viewControllers)
		{
		}

		public override void Prepare()
		{
			base.Prepare();
			prepareTabBar();
		}

		void prepareTabBar()
		{
			TabBar.SetDepthPreset(DepthPreset.None);
			TabBar.SetDividerColor(Color.Grey.Lighten3);
		}
	}
}
