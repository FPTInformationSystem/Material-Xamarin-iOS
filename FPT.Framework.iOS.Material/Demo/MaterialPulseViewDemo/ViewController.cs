using System;
using CoreGraphics;
using FPT.Framework.iOS.Material;
using UIKit;
using CoreAnimation;

namespace MaterialPulseViewDemo
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
			prepareView();
			prepareMaterialPulseView();
		}

		private void prepareView()
		{
			View.BackgroundColor = MaterialColor.White;
		}

		private void prepareMaterialPulseView()
		{
			nfloat diamter = 150f;
			nfloat point = (MaterialDevice.Width - diamter) / 2;

			var pulseView = new MaterialPulseView(new CGRect(point, point, diamter, diamter));
			pulseView.Image = UIImage.FromBundle("Graph");
			pulseView.Shape = MaterialShape.Square;
			pulseView.Depth = MaterialDepth.Depth1;
			pulseView.CornerRadiusPreset = MaterialRadius.Radius3;
			pulseView.PulseAnimation = PulseAnimation.CenterRadialBeyondBounds;

			View.AddSubview(pulseView);

			MaterialAnimation.Delay(4, () =>
			{
				pulseView.pulse(new CGPoint(30, 30));
			});

			pulseView.Animate(MaterialAnimation.AnimationGroup(new CAAnimation[] {
				MaterialAnimation.Rotate(rotation:0.5f),
				MaterialAnimation.RotateX(rotation: 2.0f),
				MaterialAnimation.TranslateY(200f)
			}, 4));
		}
	}
}
