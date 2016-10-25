using System;
using UIKit;
using FPT.Framework.iOS.Material;

namespace PageTabBarControllerDemo
{
	public partial class BlueViewController : UIViewController
	{
		public BlueViewController() : base(null, null)
		{
			preparePageTabBarItem();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			View.BackgroundColor = Color.Blue.Base;
		}

		private void preparePageTabBarItem()
		{
			this.PageTabBarItem().Title = "Blue";
			this.PageTabBarItem().TitleColor = Color.BlueGrey.Base;
		}
	}
}

