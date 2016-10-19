using System;
using UIKit;

namespace FPT.Framework.iOS.Material
{
	public static class Color
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
					return Color.Black.ColorWithAlpha(0.87f);
				}
			}

			public static UIColor Secondary
			{
				get
				{
					return Color.Black.ColorWithAlpha(0.54f);
				}
			}

			public static UIColor Others
			{
				get
				{
					return Color.Black.ColorWithAlpha(0.38f);
				}
			}

			public static UIColor Dividers
			{
				get
				{
					return Color.Black.ColorWithAlpha(0.12f);
				}
			}
		}

		public static class LightText
		{
			public static UIColor Primary
			{
				get
				{
					return Color.White;
				}
			}

			public static UIColor Secondary
			{
				get
				{
					return Color.White.ColorWithAlpha(0.7f);
				}
			}

			public static UIColor Others
			{
				get
				{
					return Color.White.ColorWithAlpha(0.5f);
				}
			}

			public static UIColor Dividers
			{
				get
				{
					return Color.White.ColorWithAlpha(0.12f);
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
			public static UIColor Base
			{
				get
				{
					return new UIColor(red: 233f / 255f, green: 30f / 255f, blue: 99f / 255f, alpha: 1);
				}
			}
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

			public static UIColor Lighten4
			{
				get
				{
					return new UIColor(red: 187f / 255f, green: 222f / 255f, blue: 251f / 255f, alpha: 1);
				}
			}

			public static UIColor Lighten3
			{
				get
				{
					return new UIColor(red: 144f / 255f, green: 202f / 255f, blue: 251f / 255f, alpha: 1);
				}
			}

			public static UIColor Lighten2
			{
				get
				{
					return new UIColor(red: 100f / 255f, green: 181f / 255f, blue: 246f / 255f, alpha: 1);
				}
			}

			public static UIColor Lighten1
			{
				get
				{
					return new UIColor(red: 66f / 255f, green: 165f / 255f, blue: 245f / 255f, alpha: 1);
				}
			}

			public static UIColor Base
			{
				get
				{
					return new UIColor(red: 32f / 255f, green: 150f / 255f, blue: 243f / 255f, alpha: 1);
				}
			}

			public static UIColor Darken2
			{
				get
				{
					return new UIColor(red: 25f / 255f, green: 118f / 255f, blue: 210f / 255f, alpha: 1);
				}
			}

			public static UIColor Darken3
			{
				get
				{
					return new UIColor(red: 21f / 255f, green: 101f / 255f, blue: 192f / 255f, alpha: 1);
				}
			}

			public static UIColor Darken4
			{
				get
				{
					return new UIColor(red: 13f / 255f, green: 71f / 255f, blue: 161f / 255f, alpha: 1);
				}
			}

			public static UIColor Accent1
			{
				get
				{
					return new UIColor(red: 130f / 255f, green: 177f / 255f, blue: 255f / 255f, alpha: 1);
				}
			}

			public static UIColor Accent3
			{
				get
				{
					return new UIColor(red: 41f / 255f, green: 121f / 255f, blue: 255f / 255f, alpha: 1);
				}
			}
		}

		public static class LightBlue
		{
		}

		public static class Cyan
		{
			public static UIColor Base
			{
				get
				{
					return new UIColor(red: 0f / 255f, green: 188f / 255f, blue: 212f / 255f, alpha: 1);
				}
			}
		}

		public static class Teal
		{
			public static UIColor Base
			{
				get
				{
					return new UIColor(red: 0f / 255f, green: 150f / 255f, blue: 136f / 255f, alpha: 1);
				}
			}

			public static UIColor Accent3
			{
				get
				{
					return new UIColor(red: 29f / 255f, green: 233f / 255f, blue: 182f / 255f, alpha: 1);
				}
			}
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
			public static UIColor Darken4
			{
				get
				{
					return new UIColor(red: 255f / 255f, green: 111f / 255f, blue: 0f / 255f, alpha: 1);
				}
			}
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

			public static UIColor Lighten5
			{
				get
				{
					return new UIColor(red: 250f / 255f, green: 250f / 255f, blue: 250f / 255f, alpha: 1);
				}
			}

			public static UIColor Lighten3
			{
				get
				{
					return new UIColor(red: 238f / 255f, green: 238f / 255f, blue: 238f / 255f, alpha: 1);
				}
			}

			public static UIColor Lighten2
			{
				get
				{
					return new UIColor(red: 224f / 255f, green: 224f / 255f, blue: 224f / 255f, alpha: 1);
				}
			}

			public static UIColor Lighten1
			{
				get
				{
					return new UIColor(red: 189f / 255f, green: 189f / 255f, blue: 189f / 255f, alpha: 1);
				}
			}

			public static UIColor Base
			{
				get
				{
					return new UIColor(red: 158f / 255f, green: 158f / 255f, blue: 158f / 255f, alpha: 1);
				}
			}

			public static UIColor Darken1
			{
				get
				{
					return new UIColor(red: 117f / 255f, green: 117f / 255f, blue: 117f / 255f, alpha: 1);
				}
			}

			public static UIColor Darken3
			{
				get
				{
					return new UIColor(red: 66f / 255f, green: 66f / 255f, blue: 66f / 255f, alpha: 1);
				}
			}

			public static UIColor Darken4
			{
				get
				{
					return new UIColor(red: 33f / 255f, green: 33f / 255f, blue: 33f / 255f, alpha: 1);
				}
			}
		}

		public static class BlueGrey
		{

			public static UIColor Lighten4
			{
				get
				{
					return new UIColor(red: 207f / 255f, green: 216f / 255f, blue: 220f / 255f, alpha: 1);
				}
			}

			public static UIColor Lighten3
			{
				get
				{
					return new UIColor(red: 176f / 255f, green: 190f / 255f, blue: 197f / 255f, alpha: 1);
				}
			}

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
