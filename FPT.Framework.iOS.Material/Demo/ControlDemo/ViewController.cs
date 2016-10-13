using System;
using System.Collections.Generic;
using CoreGraphics;
using FPT.Framework.iOS.Material;
using UIKit;

namespace ControlDemo
{
	public partial class ViewController : UIViewController
	{

		private ControlView controlView { get; set;}

		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			prepareView();
			prepareControlView();
		}

		public void prepareView()
		{
			View.BackgroundColor = MaterialColor.White;
		}

		public void prepareControlView()
		{
			controlView = new ControlView(new CGRect(0, View.Bounds.Height - 56, View.Bounds.Width, 56));

			var undoButton = new FlatButton();
			undoButton.PulseColor = MaterialColor.White;
			undoButton.SetTitle("UNDO", UIControlState.Normal);
			undoButton.SetTitleColor(MaterialColor.Teal.Accent3, UIControlState.Normal);

			var undoButton2 = new FlatButton();
			undoButton2.PulseColor = MaterialColor.White;
			undoButton2.SetTitle("UNDO", UIControlState.Normal);
			undoButton2.SetTitleColor(MaterialColor.Teal.Accent3, UIControlState.Normal);

			var label = new UILabel();
			label.Text = "Archived";
			label.TextColor = MaterialColor.White;

			controlView.BackgroundColor = MaterialColor.Grey.Darken4;
			controlView.ContentView.AddSubview(label);
			controlView.RightControls = new UIControl[] {
				undoButton, undoButton2
			};
			controlView.ContentInsetPreset = MaterialEdgeInset.WideRectangle3;

			View.AddSubview(controlView);
			controlView.ContentView.Grid().Views = new List<UIView>()
			{
				label
			};
		}
	}
}
