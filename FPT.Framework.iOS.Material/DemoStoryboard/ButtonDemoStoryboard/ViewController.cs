using System;
using FPT.Framework.iOS.Material;
using UIKit;

namespace ButtonDemoStoryboard
{
	public partial class ViewController : UIViewController
	{
		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			RaisedButton.SetTitle(title: "Button Raised", forState: UIControlState.Normal);
			RaisedButton.SetTitleColor(color: Color.White, forState: UIControlState.Normal);
			RaisedButton.PulseColor = Color.White;
			RaisedButton.TitleLabel.Font = RobotoFont.RegularWithSize(24f);
			RaisedButton.BackgroundColor = Color.Blue.Base;
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}
