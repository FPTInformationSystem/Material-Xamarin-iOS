using System;
using UIKit;
using CoreGraphics;
using FPT.Framework.iOS.Material;

namespace MaterialDemo
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
			prepareFlatButtonExample();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public void prepareFlatButtonExample()
		{
			nfloat w = 200;
			var button = new FlatButton(new CGRect((View.Bounds.Width - w)/2, 100, w, 48));
			button.SetTitle("Flat", UIControlState.Normal);
			button.SetTitleColor(MaterialColor.Blue.Base, UIControlState.Normal);
			button.PulseColor = MaterialColor.Blue.Base;
			//button.TitleLabel.Font 
			View.AddSubview(button);
		}
	}
}
