using System;
using UIKit;
using FPT.Framework.iOS.Material;

namespace PageTabBarControllerDemo
{
	public partial class GreenViewController : UIViewController
	{
		public GreenViewController() : base("GreenViewController", null)
		{
			preparePageTabBarItem();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			View.BackgroundColor = Color.Green.Base;
		}

		private void preparePageTabBarItem()
		{
			this.PageTabBarItem().Title = "Green";
			this.PageTabBarItem().TitleColor = Color.BlueGrey.Base;
		}
	}
}

