using System;
using UIKit;
using CoreGraphics;
using FPT.Framework.iOS.Material;

namespace MaterialButtonDemo
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
			prepareFabButtonExample();
			prepareRaisedButtonExample();

			//prepareMaterialView();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		public void prepareFlatButtonExample()
		{
			nfloat w = 200;
			var button = new FlatButton(new CGRect((View.Bounds.Width - w) / 2, 100, w, 48));
			button.SetTitle("Button Raised", UIControlState.Normal);
			button.SetTitleColor(MaterialColor.Blue.Base, UIControlState.Normal);
			button.PulseColor = MaterialColor.Blue.Base;
			button.TitleLabel.Font = MaterialFont.SystemFontWithSize(24f);
			View.AddSubview(button);
		}

		private void prepareFabButtonExample()
		{
			nfloat w = 64;
			//let img: UIImage ? = MaterialIcon.cm.pen
			var img = MaterialIcon.CM.AddWhite;
			var button = new FabButton(new CGRect((View.Bounds.Width - w) / 2, 300, w, w));
			button.SetImage(image: img, forState: UIControlState.Normal);
			button.SetImage(image: img, forState: UIControlState.Highlighted);
			//button.setImage(img, forState: .Normal)
			//button.setImage(img, forState: .Highlighted)

			// Add button to UIViewController.
			View.AddSubview(button);
		}

		private void prepareRaisedButtonExample()
		{
			nfloat w = 200;
			var button = new RaisedButton(new CGRect((View.Bounds.Width - w) / 2, 200, w, 48));
			button.SetTitle(title: "Button Raised", forState: UIControlState.Normal);
			button.SetTitleColor(color: MaterialColor.Blue.Base, forState: UIControlState.Normal);
			button.PulseColor = MaterialColor.Blue.Base;
			button.TitleLabel.Font = RobotoFont.RegularWithSize(24f);

			// Add button to UIViewController.
			View.AddSubview(button);
		}
	}
}
