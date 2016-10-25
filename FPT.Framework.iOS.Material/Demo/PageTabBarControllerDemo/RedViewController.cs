using System;
using UIKit;
using FPT.Framework.iOS.Material;

namespace PageTabBarControllerDemo
{
	public class RedViewController : UIViewController
	{
		
		public RedViewController() : base(null, null)
		{
			preparePageTabBarItem();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			View.BackgroundColor = Color.Red.Base;
		}

		private void preparePageTabBarItem()
		{
			this.PageTabBarItem().Title = "Red";
			this.PageTabBarItem().TitleColor = Color.BlueGrey.Base;
		}
	}
}
