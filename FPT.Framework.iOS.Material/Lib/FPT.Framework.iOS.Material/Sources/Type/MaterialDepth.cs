using System;
using CoreGraphics;
namespace FPT.Framework.iOS.Material
{
	public static partial class Convert
	{
		public static MaterialDepthType MaterialDepthToValue(MaterialDepth depth)
		{
			switch (depth)
			{
				case MaterialDepth.None:
					return null;
				case MaterialDepth.Depth1:
					return new MaterialDepthType(new CGSize(0, 1), 0.3f, 1);
				case MaterialDepth.Depth2:
					return new MaterialDepthType(new CGSize(0, 2), 0.3f, 2);
				case MaterialDepth.Depth3:
					return new MaterialDepthType(new CGSize(0, 3), 0.3f, 3);
				case MaterialDepth.Depth4:
					return new MaterialDepthType(new CGSize(0, 4), 0.3f, 4);
				case MaterialDepth.Depth5:
					return new MaterialDepthType(new CGSize(0, 5), 0.3f, 5);
				default:
					return new MaterialDepthType(CGSize.Empty, 0, 0);
			}
		}
	}

	public class MaterialDepthType
	{
		public CGSize Offset { get; private set;}
		public float Opacity { get; private set;}
		public nfloat Radius { get; private set;}

		internal MaterialDepthType(CGSize offset, float opacity, nfloat radius)
		{
			Offset = offset;
			Opacity = opacity;
			Radius = radius;
		}
	}

	public enum MaterialDepth
	{
		None, Depth1, Depth2, Depth3, Depth4, Depth5
	}
}
