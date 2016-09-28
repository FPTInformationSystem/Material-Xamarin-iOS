using System;
using CoreAnimation;
namespace FPT.Framework.iOS.Material
{
	public static class MaterialGravity
	{
		public static readonly String Center 			= CALayer.GravityCenter;
		public static readonly String Top 				= CALayer.GravityTop;
		public static readonly String Bottom 			= CALayer.GravityBottom;
		public static readonly String Left 				= CALayer.GravityLeft;
		public static readonly String Right 			= CALayer.GravityRight;
		public static readonly String TopLeft			= CALayer.GravityTopLeft;
		public static readonly String TopRight 			= CALayer.GravityTopRight;
		public static readonly String BottomLeft 		= CALayer.GravityBottomLeft;
		public static readonly String BottomRight 		= CALayer.GravityBottomRight;
		public static readonly String Resize 			= CALayer.GravityResize;
		public static readonly String ResizeAspect 		= CALayer.GravityResizeAspect;
		public static readonly String ResizeAspectFill 	= CALayer.GravityResizeAspectFill;
	}
}
