using System;
using UIKit;

namespace FPT.Framework.iOS.Material
{
	public static class MaterialColor
	{
		public static UIColor Clear
		{
			get
			{
				return UIColor.Clear;
			}
		}

		public static UIColor White
		{
			get
			{
				return UIColor.White;
			}
		}

		public static UIColor Black
		{
			get
			{
				return UIColor.Black;
			}
		}

		public static class DarkText
		{
			public static UIColor Primary
			{
				get
				{
					return MaterialColor.Black.ColorWithAlpha(0.87f);
				}
			}

			public static UIColor Secondary
			{
				get
				{
					return MaterialColor.Black.ColorWithAlpha(0.54f);
				}
			}

			public static UIColor Others
			{
				get
				{
					return MaterialColor.Black.ColorWithAlpha(0.38f);
				}
			}

			public static UIColor Dividers
			{
				get
				{
					return MaterialColor.Black.ColorWithAlpha(0.12f);
				}
			}
		}

		public static class LightText
		{
			public static UIColor Primary
			{
				get
				{
					return MaterialColor.White;
				}
			}

			public static UIColor Secondary
			{
				get
				{
					return MaterialColor.White.ColorWithAlpha(0.7f);
				}
			}

			public static UIColor Others
			{
				get
				{
					return MaterialColor.White.ColorWithAlpha(0.5f);
				}
			}

			public static UIColor Dividers
			{
				get
				{
					return MaterialColor.White.ColorWithAlpha(0.12f);
				}
			}
		}

		public static class Red
		{
			public static UIColor Base
			{
				get
				{
					return new UIColor(red: 244f / 255f, green: 67f / 255f, blue: 54f / 255f, alpha: 1);
				}
			}
		}

		public static class Pink
		{
		}

		public static class Purple
		{
		}

		public static class DeepPurple
		{
		}

		public static class Indigo
		{
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

		public static class LightBlue
		{
		}

		public static class Cyan
		{
		}

		public static class Teal
		{
		}

		public static class Green
		{
			public static UIColor Base
			{
				get
				{
					return new UIColor(red: 76f / 255f, green: 175f / 255f, blue: 80f / 255f, alpha: 1);
				}
			}
		}

		public static class LightGreen
		{
		}

		public static class Lime
		{
		}

		public static class Yellow
		{
			public static UIColor Base
			{
				get
				{
					return new UIColor(red: 255f / 255f, green: 235f / 255f, blue: 59f / 255f, alpha: 1);
				}
			}
		}

		public static class Amber
		{
		}

		public static class Orange
		{
		}

		public static class DeepOrange
		{
		}

		public static class Grown
		{
		}

		public static class Grey
		{
			public static UIColor Base
			{
				get
				{
					return new UIColor(red: 158f / 255f, green: 158f / 255f, blue: 158f / 255f, alpha: 1);
				}
			}

			public static UIColor Lighten3
			{
				get
				{
					return new UIColor(red: 238f / 255f, green: 238f / 255f, blue: 238f / 255f, alpha: 1);
				}
			}
		}

		public static class BlueGrey
		{
			public static UIColor Base
			{
				get
				{
					return new UIColor(red: 236f / 255f, green: 239f / 255f, blue: 241f / 255f, alpha: 1);
				}
			}

			public static UIColor Darken4
			{
				get
				{
					return new UIColor(red: 38f / 255f, green: 50f / 255f, blue: 56f / 255f, alpha: 1);
				}
			}
		}
	}
}
