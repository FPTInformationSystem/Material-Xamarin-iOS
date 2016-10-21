using System;
using FPT.Framework.iOS.Material;
using UIKit;

namespace ToolbarControllerDemo
{
	public partial class RootViewController : UIViewController
	{

		public RootViewController() : base()
		{
		}

		protected RootViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			View.BackgroundColor = UIColor.White;
			prepareToolbar();
		}

		private void prepareToolbar()
		{
			if (this.ToolBarController() != null)
			{
				var toolbar = this.ToolBarController().Toolbar;
				if (toolbar != null)
				{
					toolbar.Title = "Material";
					toolbar.TitleLabel.TextColor = Color.White;
					toolbar.TitleLabel.TextAlignment = UITextAlignment.Left;

					toolbar.Detail = "Build Beautiful Software";
					toolbar.DetailLabel.TextColor = Color.White;
					toolbar.DetailLabel.TextAlignment = UITextAlignment.Left;
				}
			}
		}
	}
}
