using System;
using CoreGraphics;

namespace FPT.Framework.iOS.Material
{
	public class RaisedButton : MaterialButton
	{
		public RaisedButton(CGRect frame) : base(frame) { }

		public override void prepareView()
		{
			base.prepareView();
			Depth = MaterialDepth.Depth1;
			CornerRadiusPreset = MaterialRadius.Radius1;
			ContentEdgeInsetsPreset = MaterialEdgeInset.WideRectangle3;
			BackgroundColor = MaterialColor.White;
		}
	}
}
