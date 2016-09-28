using System;
using CoreGraphics;

namespace FPT.Framework.iOS.Material
{
	public class FlatButton : MaterialButton
	{
		public FlatButton(CGRect frame) : base(frame) { }

		public override void prepareView()
		{
			base.prepareView();
			CornerRadiusPreset = MaterialRadius.Radius1;
			ContentEdgeInsetsPreset = MaterialEdgeInset.WideRectangle3;
		}
	}
}
