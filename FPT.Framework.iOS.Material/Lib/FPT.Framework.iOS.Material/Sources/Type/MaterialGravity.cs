using System;
using CoreAnimation;
namespace FPT.Framework.iOS.Material
{
	public enum MaterialGravity
	{
		Center, Top, Bottom, Left, Right, TopLeft, TopRight, BottomLeft, BottomRight, Resize, ResizeAspect, ResizeAspectFill
	}

	public static partial class Convert
	{
		public static string MaterialGravityToValue(MaterialGravity gravity)
		{
			switch (gravity)
			{
				case MaterialGravity.Center:
					return CALayer.GravityCenter;
				case MaterialGravity.Top:
					return CALayer.GravityTop;
				case MaterialGravity.Bottom:
					return CALayer.GravityBottom;
				case MaterialGravity.Left:
					return CALayer.GravityLeft;
				case MaterialGravity.Right:
					return CALayer.GravityRight;
				case MaterialGravity.TopLeft:
					return CALayer.GravityTopLeft;
				case MaterialGravity.TopRight:
					return CALayer.GravityTopRight;
				case MaterialGravity.BottomLeft:
					return CALayer.GravityBottomLeft;
				case MaterialGravity.BottomRight:
					return CALayer.GravityBottomRight;
				case MaterialGravity.Resize:
					return CALayer.GravityResize;
				case MaterialGravity.ResizeAspect:
					return CALayer.GravityResizeAspect;
				case MaterialGravity.ResizeAspectFill:
					return CALayer.GravityResizeAspectFill;
				default:
					return default(string);
			}
		}	
	}
}
