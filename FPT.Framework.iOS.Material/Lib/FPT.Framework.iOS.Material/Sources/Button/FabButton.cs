using System;
using CoreGraphics;

namespace FPT.Framework.iOS.Material
{
	public class FabButton : MaterialButton
	{
		public FabButton(CGRect frame) : base(frame) { }

		public override void prepareView()
		{
			base.prepareView();
			Depth = MaterialDepth.Depth1;
			Shape = MaterialShape.Circle;
			PulseAnimation = PulseAnimation.CenterWithBacking;
			PulseColor = MaterialColor.White;
			BackgroundColor = MaterialColor.Red.Base;
		}
	}
}
