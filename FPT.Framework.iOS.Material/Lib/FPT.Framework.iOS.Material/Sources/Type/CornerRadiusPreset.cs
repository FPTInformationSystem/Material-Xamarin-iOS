using System;
namespace FPT.Framework.iOS.Material
{
	public static partial class Convert
	{
		public static nfloat CornerRadiusPresetToValue(CornerRadiusPreset radius)
		{
			switch (radius)
			{
				case CornerRadiusPreset.None:
					return 0;
				case CornerRadiusPreset.Radius1:
					return 2;
				case CornerRadiusPreset.Radius2:
					return 4;
				case CornerRadiusPreset.Radius3:
					return 8;
				case CornerRadiusPreset.Radius4:
					return 12;
				case CornerRadiusPreset.Radius5:
					return 16;
				case CornerRadiusPreset.Radius6:
					return 20;
				case CornerRadiusPreset.Radius7:
					return 24;
				case CornerRadiusPreset.Radius8:
					return 28;
				case CornerRadiusPreset.Radius9:
					return 32;
				default:
					return default(nfloat);
			}
		}
	}

	public enum CornerRadiusPreset
	{
		None, Radius1, Radius2, Radius3, Radius4, Radius5, Radius6, Radius7, Radius8, Radius9
	}
}
