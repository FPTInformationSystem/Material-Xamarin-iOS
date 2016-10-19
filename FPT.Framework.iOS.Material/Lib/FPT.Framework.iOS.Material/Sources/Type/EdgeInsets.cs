using System;
using UIKit;
namespace FPT.Framework.iOS.Material
{
	public enum EdgeInsetsPreset
	{
		None,
		Square1, Square2, Square3, Square4, Square5, Square6, Square7, Square8, Square9,
		WideRectangle1, WideRectangle2, WideRectangle3, WideRectangle4, WideRectangle5, WideRectangle6, WideRectangle7, WideRectangle8, WideRectangle9,
		TallRectangle1, TallRectangle2, TallRectangle3, TallRectangle4, TallRectangle5, TallRectangle6, TallRectangle7, TallRectangle8, TallRectangle9
	}

	public static partial class Convert
	{
		public static UIEdgeInsets MaterialEdgeInsetToValue(EdgeInsetsPreset inset)
		{
			switch (inset)
			{
				case EdgeInsetsPreset.None:
					return UIEdgeInsets.Zero;

				//TallRectangle
				case EdgeInsetsPreset.Square1:
					return new UIEdgeInsets(2, 4, 2, 4);
				case EdgeInsetsPreset.Square2:
					return new UIEdgeInsets(8, 8, 8, 8);
				case EdgeInsetsPreset.Square3:
					return new UIEdgeInsets(16, 16, 16, 16);
				case EdgeInsetsPreset.Square4:
					return new UIEdgeInsets(24, 24, 24, 24);
				case EdgeInsetsPreset.Square5:
					return new UIEdgeInsets(32, 32, 32, 32);
				case EdgeInsetsPreset.Square6:
					return new UIEdgeInsets(40, 40, 40, 40);
				case EdgeInsetsPreset.Square7:
					return new UIEdgeInsets(48, 48, 48, 48);
				case EdgeInsetsPreset.Square8:
					return new UIEdgeInsets(56, 56, 56, 56);
				case EdgeInsetsPreset.Square9:
					return new UIEdgeInsets(64, 64, 64, 64);

					//rectangle
				case EdgeInsetsPreset.WideRectangle1:
					return new UIEdgeInsets(2, 4, 2, 4);
				case EdgeInsetsPreset.WideRectangle2:
					return new UIEdgeInsets(4, 8, 4, 8);
				case EdgeInsetsPreset.WideRectangle3:
					return new UIEdgeInsets(8, 16, 8, 16);
				case EdgeInsetsPreset.WideRectangle4:
					return new UIEdgeInsets(12, 24, 12, 24);
				case EdgeInsetsPreset.WideRectangle5:
					return new UIEdgeInsets(16, 32, 16, 32);
				case EdgeInsetsPreset.WideRectangle6:
					return new UIEdgeInsets(20, 40, 20, 40);
				case EdgeInsetsPreset.WideRectangle7:
					return new UIEdgeInsets(24, 48, 24, 48);
				case EdgeInsetsPreset.WideRectangle8:
					return new UIEdgeInsets(28, 56, 28, 56);
				case EdgeInsetsPreset.WideRectangle9:
					return new UIEdgeInsets(32, 64, 32, 64);

					//flipped rectangle
				case EdgeInsetsPreset.TallRectangle1:
					return new UIEdgeInsets(4, 2, 4, 2);
				case EdgeInsetsPreset.TallRectangle2:
					return new UIEdgeInsets(8, 4, 8, 4);
				case EdgeInsetsPreset.TallRectangle3:
					return new UIEdgeInsets(16, 8, 16, 8);
				case EdgeInsetsPreset.TallRectangle4:
					return new UIEdgeInsets(24, 12, 24, 12);
				case EdgeInsetsPreset.TallRectangle5:
					return new UIEdgeInsets(32, 16, 32, 16);
				case EdgeInsetsPreset.TallRectangle6:
					return new UIEdgeInsets(40, 20, 40, 20);
				case EdgeInsetsPreset.TallRectangle7:
					return new UIEdgeInsets(48, 24, 48, 24);
				case EdgeInsetsPreset.TallRectangle8:
					return new UIEdgeInsets(56, 28, 56, 28);
				case EdgeInsetsPreset.TallRectangle9:
					return new UIEdgeInsets(64, 32, 64, 32);

				default:
					return default(UIEdgeInsets);
			}
		}
	}
}
