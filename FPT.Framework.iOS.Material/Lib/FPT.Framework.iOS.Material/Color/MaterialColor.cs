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
					return new UIColor(red: 158f / 255f, green: 158f / 255f, blue: 158f / 255f, alpha: 1);
				}
			}
		}

		public static class Blue
		{
			public static UIColor Base
			{
				get
				{
					return new UIColor(red: 32f / 255f, green: 150f / 255f, blue: 243f / 255f, alpha: 1);
				}
			}
		}
	}
}
