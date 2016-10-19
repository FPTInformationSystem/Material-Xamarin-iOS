using System;
using CoreAnimation;
namespace FPT.Framework.iOS.Material
{
	public enum Gravity
	{
		Center, Top, Bottom, Left, Right, TopLeft, TopRight, BottomLeft, BottomRight, Resize, ResizeAspect, ResizeAspectFill
	}

	public static partial class Convert
	{
		public static string GravityToValue(Gravity gravity)
		{
			switch (gravity)
			{
				case Gravity.Center:
					return CALayer.GravityCenter;
				case Gravity.Top:
					return CALayer.GravityTop;
				case Gravity.Bottom:
					return CALayer.GravityBottom;
				case Gravity.Left:
					return CALayer.GravityLeft;
				case Gravity.Right:
					return CALayer.GravityRight;
				case Gravity.TopLeft:
					return CALayer.GravityTopLeft;
				case Gravity.TopRight:
					return CALayer.GravityTopRight;
				case Gravity.BottomLeft:
					return CALayer.GravityBottomLeft;
				case Gravity.BottomRight:
					return CALayer.GravityBottomRight;
				case Gravity.Resize:
					return CALayer.GravityResize;
				case Gravity.ResizeAspect:
					return CALayer.GravityResizeAspect;
				case Gravity.ResizeAspectFill:
					return CALayer.GravityResizeAspectFill;
				default:
					return default(string);
			}
		}	
	}
}
