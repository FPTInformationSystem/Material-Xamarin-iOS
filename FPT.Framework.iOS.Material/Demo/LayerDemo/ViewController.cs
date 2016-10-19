using System;
using FPT.Framework.iOS.Material;
using UIKit;
using CoreGraphics;

namespace LayerDemo
{
	public partial class ViewController : UIViewController
	{

		private Layer layer { get; set;}

		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			View.BackgroundColor = UIColor.White;
			prepareLayer();
		}

		private void prepareLayer()
		{
			var w = View.Width();
			var h = View.Height();
			nfloat d = 100f;

			layer = new Layer(new CGRect((w - d) / 2f, (h - d) / 2f, d, d));
			layer.SetDepthPreset(DepthPreset.Depth3);
			layer.SetShapePreset(ShapePreset.Circle);
			layer.BackgroundColor = Color.White.CGColor;
			layer.Image = UIImage.FromBundle("CosmicMind");

			View.Layer.AddSublayer(layer);
		}
	}
}
