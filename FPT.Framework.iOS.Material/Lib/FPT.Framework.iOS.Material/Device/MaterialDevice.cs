using System;
using UIKit;

namespace FPT.Framework.iOS.Material
{
	public static class MaterialDevice
	{
		public static nfloat Scale
		{
			get
			{
				return UIScreen.MainScreen.Scale;
			}
		}
	}
}
