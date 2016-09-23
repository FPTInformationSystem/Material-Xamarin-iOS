using System;
using CoreGraphics;
namespace FPT.Framework.iOS.Material
{
	public struct MaterialDepthType
	{
		public CGSize Offset { get; set;}
		public float Opacity { get; set;}
		public nfloat Radius { get; set;}

		public MaterialDepthType(CGSize offset, float opacity, nfloat radius)
		{
			Offset = offset;
			Opacity = opacity;
			Radius = radius;
		}
	}

	public static class MaterialDepth
	{
		public static readonly MaterialDepthType Depth1 = new MaterialDepthType(new CGSize(0, 1), 0.3f, 1);
		public static readonly MaterialDepthType Depth2 = new MaterialDepthType(new CGSize(0, 2), 0.3f, 2);
		public static readonly MaterialDepthType Depth3 = new MaterialDepthType(new CGSize(0, 3), 0.3f, 3);
		public static readonly MaterialDepthType Depth4 = new MaterialDepthType(new CGSize(0, 4), 0.3f, 4);
		public static readonly MaterialDepthType Depth5 = new MaterialDepthType(new CGSize(0, 5), 0.3f, 5);
	}
}
