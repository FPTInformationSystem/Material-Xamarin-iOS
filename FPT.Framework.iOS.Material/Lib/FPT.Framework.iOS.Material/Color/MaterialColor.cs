using System;
using UIKit;

namespace FPT.Framework.iOS.Material
{
	public static class MaterialColor
	{
		public static class Grey
		{
			public static UIColor Base
			{
				get
				{
					return new UIColor(red: 158 / 255, green: 158 / 255, blue: 158 / 255, alpha: 1);
				}
			}
		}

		public static class Blue
		{
			public static UIColor Base
			{
				get
				{
					return new UIColor(red: 32 / 255, green: 150 / 255, blue: 243 / 255, alpha: 1);
				}
			}
		}
	}
}
