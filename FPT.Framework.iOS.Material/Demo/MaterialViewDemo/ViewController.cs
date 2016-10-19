using System;
using CoreGraphics;
using FPT.Framework.iOS.Material;
using UIKit;

namespace MaterialViewDemo
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
			prepareMaterialView();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		void prepareView()
		{
			View.BackgroundColor = Color.White;
		}

		private void prepareMaterialView()
		{
			nfloat width = 200f;
			nfloat height = 200f;

			var materialView = new PulseView(new CGRect(0, 0, width, height));
			materialView.Image = UIImage.FromBundle("CosmicMindInverted");
			materialView.SetShapePreset(ShapePreset.Circle);
			materialView.SetDepthPreset(DepthPreset.Depth2);
			materialView.Center = View.Center;

			View.AddSubview(materialView);
		}
	}
}
