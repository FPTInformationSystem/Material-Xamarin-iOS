using System;
using UIKit;
using FPT.Framework.iOS.Material;
namespace ToolbarControllerDemo
{
	public class YellowViewController : UIViewController
	{

		protected YellowViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

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
