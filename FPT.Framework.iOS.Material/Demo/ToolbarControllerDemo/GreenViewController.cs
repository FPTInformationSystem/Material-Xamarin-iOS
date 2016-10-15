using System;
using UIKit;
using FPT.Framework.iOS.Material;
namespace ToolbarControllerDemo
{
	public class GreenViewController : UIViewController
	{

		protected GreenViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public GreenViewController()
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			prepareView();
		}

		private void prepareView()
		{
			View.BackgroundColor = MaterialColor.Green.Base;
		}
	}
}
