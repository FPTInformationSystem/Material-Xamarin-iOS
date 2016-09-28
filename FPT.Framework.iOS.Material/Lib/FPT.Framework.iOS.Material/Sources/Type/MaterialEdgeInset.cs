using System;
using UIKit;
namespace FPT.Framework.iOS.Material
{
	public enum MaterialEdgeInset
	{
		None,
		Square1, Square2, Square3, Square4, Square5, Square6, Square7, Square8, Square9,
		WideRectangle1, WideRectangle2, WideRectangle3, WideRectangle4, WideRectangle5, WideRectangle6, WideRectangle7, WideRectangle8, WideRectangle9,
		TallRectangle1, TallRectangle2, TallRectangle3, TallRectangle4, TallRectangle5, TallRectangle6, TallRectangle7, TallRectangle8, TallRectangle9
	}

	public static partial class Convert
	{
		public static UIEdgeInsets MaterialEdgeInsetToValue(MaterialEdgeInset inset)
		{
			switch (inset)
			{
				case MaterialEdgeInset.None:
					return UIEdgeInsets.Zero;

				//TallRectangle
				case MaterialEdgeInset.Square1:
					return new UIEdgeInsets(2, 4, 2, 4);
				case MaterialEdgeInset.Square2:
					return new UIEdgeInsets(8, 8, 8, 8);
				case MaterialEdgeInset.Square3:
					return new UIEdgeInsets(16, 16, 16, 16);
				case MaterialEdgeInset.Square4:
					return new UIEdgeInsets(24, 24, 24, 24);
				case MaterialEdgeInset.Square5:
					return new UIEdgeInsets(32, 32, 32, 32);
				case MaterialEdgeInset.Square6:
					return new UIEdgeInsets(40, 40, 40, 40);
				case MaterialEdgeInset.Square7:
					return new UIEdgeInsets(48, 48, 48, 48);
				case MaterialEdgeInset.Square8:
					return new UIEdgeInsets(56, 56, 56, 56);
				case MaterialEdgeInset.Square9:
					return new UIEdgeInsets(64, 64, 64, 64);

					//rectangle
				case MaterialEdgeInset.WideRectangle1:
					return new UIEdgeInsets(4, 4, 4, 4);
				case MaterialEdgeInset.WideRectangle2:
					return new UIEdgeInsets(4, 8, 4, 8);
				case MaterialEdgeInset.WideRectangle3:
					return new UIEdgeInsets(8, 16, 8, 16);
				case MaterialEdgeInset.WideRectangle4:
					return new UIEdgeInsets(12, 24, 12, 24);
				case MaterialEdgeInset.WideRectangle5:
					return new UIEdgeInsets(16, 32, 16, 32);
				case MaterialEdgeInset.WideRectangle6:
					return new UIEdgeInsets(20, 40, 20, 40);
				case MaterialEdgeInset.WideRectangle7:
					return new UIEdgeInsets(24, 48, 24, 48);
				case MaterialEdgeInset.WideRectangle8:
					return new UIEdgeInsets(28, 56, 28, 56);
				case MaterialEdgeInset.WideRectangle9:
					return new UIEdgeInsets(32, 64, 32, 64);

					//flipped rectangle
				case MaterialEdgeInset.TallRectangle1:
					return new UIEdgeInsets(4, 2, 4, 2);
				case MaterialEdgeInset.TallRectangle2:
					return new UIEdgeInsets(8, 4, 8, 4);
				case MaterialEdgeInset.TallRectangle3:
					return new UIEdgeInsets(16, 8, 16, 8);
				case MaterialEdgeInset.TallRectangle4:
					return new UIEdgeInsets(24, 12, 24, 12);
				case MaterialEdgeInset.TallRectangle5:
					return new UIEdgeInsets(32, 16, 32, 16);
				case MaterialEdgeInset.TallRectangle6:
					return new UIEdgeInsets(40, 20, 40, 20);
				case MaterialEdgeInset.TallRectangle7:
					return new UIEdgeInsets(48, 24, 48, 24);
				case MaterialEdgeInset.TallRectangle8:
					return new UIEdgeInsets(56, 28, 56, 28);
				case MaterialEdgeInset.TallRectangle9:
					return new UIEdgeInsets(64, 32, 64, 32);

				default:
					return default(UIEdgeInsets);
			}
		}
	}
}
