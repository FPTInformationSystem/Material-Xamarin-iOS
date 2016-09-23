using System;
using CoreGraphics;
namespace FPT.Framework.iOS.Material
{
	public class MaterialDepth
	{
		public CGSize Offset { get; private set;}
		public float Opacity { get; private set;}
		public nfloat Radius { get; private set;}

		private MaterialDepth(CGSize offset, float opacity, nfloat radius)
		{
			Offset = offset;
			Opacity = opacity;
			Radius = radius;
		}

		public static readonly MaterialDepth None 	= new MaterialDepth(CGSize.Empty, 0, 0);
		public static readonly MaterialDepth Depth1 = new MaterialDepth(new CGSize(0, 1), 0.3f, 1);
		public static readonly MaterialDepth Depth2 = new MaterialDepth(new CGSize(0, 2), 0.3f, 2);
		public static readonly MaterialDepth Depth3 = new MaterialDepth(new CGSize(0, 3), 0.3f, 3);
		public static readonly MaterialDepth Depth4 = new MaterialDepth(new CGSize(0, 4), 0.3f, 4);
		public static readonly MaterialDepth Depth5 = new MaterialDepth(new CGSize(0, 5), 0.3f, 5);
	}

	//public struct MaterialDepth
	//{
	//	public static readonly MaterialDepthType None = new MaterialDepthType(CGSize.Empty, 0, 0);
	//	public static readonly MaterialDepthType Depth1 = new MaterialDepthType(new CGSize(0, 1), 0.3f, 1);
	//	public static readonly MaterialDepthType Depth2 = new MaterialDepthType(new CGSize(0, 2), 0.3f, 2);
	//	public static readonly MaterialDepthType Depth3 = new MaterialDepthType(new CGSize(0, 3), 0.3f, 3);
	//	public static readonly MaterialDepthType Depth4 = new MaterialDepthType(new CGSize(0, 4), 0.3f, 4);
	//	public static readonly MaterialDepthType Depth5 = new MaterialDepthType(new CGSize(0, 5), 0.3f, 5);
	//}
}
