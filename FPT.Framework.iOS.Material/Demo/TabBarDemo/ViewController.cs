using System;
using CoreGraphics;
using FPT.Framework.iOS.Material;
using UIKit;

namespace TabBarDemo
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
			prepareView();

			var tabBar = new TabBar(new CGRect(0, 100, View.Bounds.Width, 44));
			tabBar.BackgroundColor = MaterialColor.Blue.Base;
			View.AddSubview(tabBar);

			var btn1 = new FlatButton();
			btn1.PulseColor = MaterialColor.White;
			btn1.SetTitle("ONE", UIControlState.Normal);
			btn1.SetTitleColor(MaterialColor.White, UIControlState.Normal);

			var btn2 = new FlatButton();
			btn2.PulseColor = MaterialColor.White;
			btn2.SetTitle("TWO", UIControlState.Normal);
			btn2.SetTitleColor(MaterialColor.White, UIControlState.Normal);

			var btn3 = new FlatButton();
			btn3.PulseColor = MaterialColor.White;
			btn3.SetTitle("THREE", UIControlState.Normal);
			btn3.SetTitleColor(MaterialColor.White, UIControlState.Normal);

			var btn4 = new FlatButton();
			btn4.PulseColor = MaterialColor.White;
			btn4.SetTitle("FOUR", UIControlState.Normal);
			btn4.SetTitleColor(MaterialColor.White, UIControlState.Normal);

			tabBar.Buttons = new UIButton[] {
				btn1, btn2, btn3, btn4
			};
		}

		private void prepareView()
		{
			View.BackgroundColor = MaterialColor.White;
		}
	}
}
