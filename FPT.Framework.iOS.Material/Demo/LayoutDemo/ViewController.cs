using System;
using FPT.Framework.iOS.Material;
using UILabel = UIKit.UILabel;
using UIView = UIKit.UIView;
using UIKit;

namespace LayoutDemo
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
			prepareAlignToParentHorizontallyAndVerticallyExample();
			prepareCenterExample();
		}

		private void prepareView()
		{
			View.BackgroundColor = MaterialColor.White;
		}

		private void prepareAlignToParentHorizontallyAndVerticallyExample()
		{
			var label1 = new UILabel();
			label1.BackgroundColor = MaterialColor.Red.Base;
			label1.Text = "A";
			label1.TextAlignment = UITextAlignment.Center;

			var label2 = new UILabel();
			label2.BackgroundColor = MaterialColor.Green.Base;
			label2.Text = "B";
			label2.TextAlignment = UITextAlignment.Center;

			var label3 = new UILabel();
			label3.BackgroundColor = MaterialColor.Blue.Base;
			label3.Text = "C";
			label3.TextAlignment = UITextAlignment.Center;

			var label4 = new UILabel();
			label4.BackgroundColor = MaterialColor.Yellow.Base;
			label4.Text = "D";
			label4.TextAlignment = UITextAlignment.Center;

			UIView[] children = { label1, label2, label3, label4 };

			View.Layout().Horizontally(children, 30f, 30f, 30f).Vertically(children, 100f, 100f);

			foreach (var v in children)
			{
				v.LayoutIfNeeded();
			}
		}

		private void prepareCenterExample()
		{
			nfloat length = 100f;

			var labelCX = new UILabel();
			labelCX.BackgroundColor = MaterialColor.Grey.Base;
			labelCX.Text = "CenterX";
			labelCX.TextAlignment = UITextAlignment.Center;
			labelCX.Layer.CornerRadius = length / 2.0f;
			labelCX.ClipsToBounds = true;

			View.Layout(labelCX).Width(length).Height(length).CenterHorizontally();

			var labelCY = new UILabel();
			labelCY.BackgroundColor = MaterialColor.Grey.Base;
			labelCY.Text = "CenterY";
			labelCY.TextAlignment = UITextAlignment.Center;
			labelCY.Layer.CornerRadius = length / 2.0f;
			labelCY.ClipsToBounds = true;

			View.Layout(labelCY).Width(length).Height(length).CenterVertically();

			var labelCXY = new UILabel();
			labelCXY.BackgroundColor = MaterialColor.Grey.Base;
			labelCXY.Text = "CenterXY";
			labelCXY.TextAlignment = UITextAlignment.Center;
			labelCXY.Layer.CornerRadius = length / 2.0f;
			labelCXY.ClipsToBounds = true;

			View.Layout(labelCXY).Width(length).Height(2*length).Center();
		}
	}
}
