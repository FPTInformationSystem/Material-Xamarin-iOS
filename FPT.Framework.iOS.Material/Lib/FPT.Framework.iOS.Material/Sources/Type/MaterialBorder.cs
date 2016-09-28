using System;
namespace FPT.Framework.iOS.Material
{
	public static partial class Convert
	{
		public static nfloat MaterialBorderToValue(MaterialBorder border)
		{
			switch (border)
			{
				case MaterialBorder.None:
					return 0;
				case MaterialBorder.Border1:
					return 0.5f;
				case MaterialBorder.Border2:
					return 1;
				case MaterialBorder.Border3:
					return 2;
				case MaterialBorder.Border4:
					return 3;
				case MaterialBorder.Border5:
					return 4;
				case MaterialBorder.Border6:
					return 5;
				case MaterialBorder.Border7:
					return 6;
				case MaterialBorder.Border8:
					return 7;
				case MaterialBorder.Border9:
					return 8;
				default:
					return default(nfloat);
			}
		}
	}

	public enum MaterialBorder
	{
		None, Border1, Border2, Border3, Border4, Border5, Border6, Border7, Border8, Border9
	}

	//public static class MaterialBorder
	//{
	//	public const float None = 0;
	//	public const float Border1 = 0.5f;
	//	public const float Border2 = 1;
	//	public const float Border3 = 2;
	//	public const float Border4 = 3;
	//	public const float Border5 = 4;
	//	public const float Border6 = 5;
	//	public const float Border7 = 6;
	//	public const float Border8 = 7;
	//	public const float Border9 = 8;
	//}
}
