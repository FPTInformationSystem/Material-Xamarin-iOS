using System;
using UIKit;
using FPT.Framework.iOS.Material;

namespace StatusBarControllerDemo
{
	public class RootViewController : UIViewController
	{

		public RootViewController()
		{
		}

		protected RootViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			View.BackgroundColor = Color.Grey.Lighten1;
		}
	}
}
