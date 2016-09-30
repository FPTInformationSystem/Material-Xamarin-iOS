using System;
namespace FPT.Framework.iOS.Material
{

	public enum MaterialSpacing
	{
		None, Spacing1, Spacing2, Spacing3, Spacing4, Spacing5, Spacing6, Spacing7, Spacing8, Spacing9
	}

	public static partial class Convert
	{
		public static nfloat MaterialSpacingToValue(MaterialSpacing radius)
		{
			switch (radius)
			{
				case MaterialSpacing.None:
					return 0;
				case MaterialSpacing.Spacing1:
					return 4;
				case MaterialSpacing.Spacing2:
					return 8;
				case MaterialSpacing.Spacing3:
					return 16;
				case MaterialSpacing.Spacing4:
					return 24;
				case MaterialSpacing.Spacing5:
					return 32;
				case MaterialSpacing.Spacing6:
					return 40;
				case MaterialSpacing.Spacing7:
					return 48;
				case MaterialSpacing.Spacing8:
					return 56;
				case MaterialSpacing.Spacing9:
					return 64;	
				default:
					return default(nfloat);
			}
		}
	}

	//public static class MaterialSpacing
	//{
	//	public const float None = 0;
	//	public const float Spacing1 = 4;
	//	public const float Spacing2 = 8;
	//	public const float Spacing3 = 16;
	//	public const float Spacing4 = 24;
	//	public const float Spacing5 = 32;
	//	public const float Spacing6 = 40;
	//	public const float Spacing7 = 48;
	//	public const float Spacing8 = 56;
	//	public const float Spacing9 = 64;
	//}
}
