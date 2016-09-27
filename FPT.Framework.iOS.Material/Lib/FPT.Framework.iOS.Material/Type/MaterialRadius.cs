using System;
namespace FPT.Framework.iOS.Material
{
	public static partial class Convert
	{
		public static nfloat MaterialRadiusToValue(MaterialRadius radius)
		{
			switch (radius)
			{
				case MaterialRadius.None:
					return 0;
				case MaterialRadius.Radius1:
					return 4;
				case MaterialRadius.Radius2:
					return 8;
				case MaterialRadius.Radius3:
					return 16;
				case MaterialRadius.Radius4:
					return 24;
				case MaterialRadius.Radius5:
					return 32;
				case MaterialRadius.Radius6:
					return 40;
				case MaterialRadius.Radius7:
					return 48;
				case MaterialRadius.Radius8:
					return 56;
				case MaterialRadius.Radius9:
					return 64;
				default:
					return default(nfloat);
			}
		}
	}

	public enum MaterialRadius
	{
		None, Radius1, Radius2, Radius3, Radius4, Radius5, Radius6, Radius7, Radius8, Radius9
	}
}
