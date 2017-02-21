using System;
using FPT.Framework.iOS.Material;
using UIKit;

namespace NavigationDrawerControllerDemo
{
	public partial class RootViewController : UIViewController
	{
		protected RootViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public RootViewController() : base()
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			View.BackgroundColor = Color.Grey.Lighten5;
			PrepareToolbar();
		}

		private void PrepareToolbar()
		{
			var tc = this.ToolBarController();
			tc.Toolbar.Title = "Material";
			tc.Toolbar.Detail = "Build Beautifull software";
		}
	}
}
