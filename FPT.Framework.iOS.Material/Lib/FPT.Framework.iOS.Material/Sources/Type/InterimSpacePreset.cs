using System;
namespace FPT.Framework.iOS.Material
{

	public enum InterimSpacePreset
	{
		None, InterimSpacing1, InterimSpacing2, InterimSpacing3, InterimSpacing4, InterimSpacing5, InterimSpacing6, InterimSpacing7, InterimSpacing8, InterimSpacing9
	}

	public static partial class Convert
	{
		public static nfloat InterimSpacePresetToValue(InterimSpacePreset radius)
		{
			switch (radius)
			{
				case InterimSpacePreset.None:
					return 0;
				case InterimSpacePreset.InterimSpacing1:
					return 1;
				case InterimSpacePreset.InterimSpacing2:
					return 2;
				case InterimSpacePreset.InterimSpacing3:
					return 4;
				case InterimSpacePreset.InterimSpacing4:
					return 8;
				case InterimSpacePreset.InterimSpacing5:
					return 12;
				case InterimSpacePreset.InterimSpacing6:
					return 16;
				case InterimSpacePreset.InterimSpacing7:
					return 20;
				case InterimSpacePreset.InterimSpacing8:
					return 24;
				case InterimSpacePreset.InterimSpacing9:
					return 28;	
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
