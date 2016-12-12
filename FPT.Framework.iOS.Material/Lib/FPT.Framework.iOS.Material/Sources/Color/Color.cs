using System;
using UIKit;

namespace FPT.Framework.iOS.Material
{
	public static class Color
	{
		public static UIColor Clear { get { return UIColor.Clear; } }

		public static UIColor White { get { return UIColor.White; } }

		public static UIColor Black { get { return UIColor.Black; } }

		public static class DarkText
		{
			public static UIColor Primary { get { return Color.Black.ColorWithAlpha(0.87f); } }
			public static UIColor Secondary { get { return Color.Black.ColorWithAlpha(0.54f); } }  
			public static UIColor Others { get { return Color.Black.ColorWithAlpha(0.38f); } }  
			public static UIColor Dividers { get { return Color.Black.ColorWithAlpha(0.12f); } }
		}

		public static class LightText
		{
			public static UIColor Primary { get { return Color.White; } }  
			public static UIColor Secondary { get { return Color.White.ColorWithAlpha(0.7f); } }  
			public static UIColor Others { get { return Color.White.ColorWithAlpha(0.5f); } }  
			public static UIColor Dividers { get { return Color.White.ColorWithAlpha(0.12f); } }
		}

		public static class Red
		{
			public static UIColor Lighten5 { get { return new UIColor(red: 255f / 255f, green: 235f / 255f, blue: 238f / 255f, alpha: 1); } }
			public static UIColor Lighten4 { get { return new UIColor(red: 255f / 255f, green: 205f / 255f, blue: 210f / 255f, alpha: 1); } }
			public static UIColor Lighten3 { get { return new UIColor(red: 239f / 255f, green: 154f / 255f, blue: 154f / 255f, alpha: 1); } }
			public static UIColor Lighten2 { get { return new UIColor(red: 229f / 255f, green: 115f / 255f, blue: 115f / 255f, alpha: 1); } }
			public static UIColor Lighten1 { get { return new UIColor(red: 229f / 255f, green: 83f / 255f, blue: 80f / 255f, alpha: 1); } }
			public static UIColor Base { get { return new UIColor(red: 244f / 255f, green: 67f / 255f, blue: 54f / 255f, alpha: 1); } }
			public static UIColor Darken1 { get { return new UIColor(red: 229f / 255f, green: 57f / 255f, blue: 53f / 255f, alpha: 1); } }
			public static UIColor Darken2 { get { return new UIColor(red: 211f / 255f, green: 47f / 255f, blue: 47f / 255f, alpha: 1); } }
			public static UIColor Darken3 { get { return new UIColor(red: 198f / 255f, green: 40f / 255f, blue: 40f / 255f, alpha: 1); } }
			public static UIColor Darken4 { get { return new UIColor(red: 183f / 255f, green: 28f / 255f, blue: 28f / 255f, alpha: 1); } }
			public static UIColor Accent1 { get { return new UIColor(red: 255f / 255f, green: 138f / 255f, blue: 128f / 255f, alpha: 1); } }
			public static UIColor Accent2 { get { return new UIColor(red: 255f / 255f, green: 82f / 255f, blue: 82f / 255f, alpha: 1); } }
			public static UIColor Accent3 { get { return new UIColor(red: 255f / 255f, green: 23f / 255f, blue: 68f / 255f, alpha: 1); } }
			public static UIColor Accent4 { get { return new UIColor(red: 213f / 255f, green: 0f / 255f, blue: 0f / 255f, alpha: 1); } }
		}

		public static class Pink
		{
			public static UIColor Lighten5 { get { return new UIColor(red: 252f / 255f, green: 228f / 255f, blue: 236f / 255f, alpha: 1); } }
			public static UIColor Lighten4 { get { return new UIColor(red: 248f / 255f, green: 187f / 255f, blue: 208f / 255f, alpha: 1); } }
			public static UIColor Lighten3 { get { return new UIColor(red: 244f / 255f, green: 143f / 255f, blue: 177f / 255f, alpha: 1); } }
			public static UIColor Lighten2 { get { return new UIColor(red: 240f / 255f, green: 98f / 255f, blue: 146f / 255f, alpha: 1); } }
			public static UIColor Lighten1 { get { return new UIColor(red: 236f / 255f, green: 64f / 255f, blue: 122f / 255f, alpha: 1); } }
			public static UIColor Base { get { return new UIColor(red: 233f / 255f, green: 30f / 255f, blue: 99f / 255f, alpha: 1); } }
			public static UIColor Darken1 { get { return new UIColor(red: 216f / 255f, green: 27f / 255f, blue: 96f / 255f, alpha: 1); } }
			public static UIColor Darken2 { get { return new UIColor(red: 194f / 255f, green: 24f / 255f, blue: 91f / 255f, alpha: 1); } }
			public static UIColor Darken3 { get { return new UIColor(red: 173f / 255f, green: 20f / 255f, blue: 87f / 255f, alpha: 1); } }
			public static UIColor Darken4 { get { return new UIColor(red: 136f / 255f, green: 14f / 255f, blue: 79f / 255f, alpha: 1); } }
			public static UIColor Accent1 { get { return new UIColor(red: 255f / 255f, green: 128f / 255f, blue: 171f / 255f, alpha: 1); } }
			public static UIColor Accent2 { get { return new UIColor(red: 255f / 255f, green: 64f / 255f, blue: 129f / 255f, alpha: 1); } }
			public static UIColor Accent3 { get { return new UIColor(red: 245f / 255f, green: 0f / 255f, blue: 87f / 255f, alpha: 1); } }
			public static UIColor Accent4 { get { return new UIColor(red: 197f / 255f, green: 17f / 255f, blue: 98f / 255f, alpha: 1); } }
		}

		public static class Purple
		{
			public static UIColor Lighten5 { get { return new UIColor(red: 243f / 255f, green: 229f / 255f, blue: 245f / 255f, alpha: 1); } }
			public static UIColor Lighten4 { get { return new UIColor(red: 225f / 255f, green: 190f / 255f, blue: 231f / 255f, alpha: 1); } }
			public static UIColor Lighten3 { get { return new UIColor(red: 206f / 255f, green: 147f / 255f, blue: 216f / 255f, alpha: 1); } }
			public static UIColor Lighten2 { get { return new UIColor(red: 186f / 255f, green: 104f / 255f, blue: 200f / 255f, alpha: 1); } }
			public static UIColor Lighten1 { get { return new UIColor(red: 171f / 255f, green: 71f / 255f, blue: 188f / 255f, alpha: 1); } }
			public static UIColor Base { get { return new UIColor(red: 156f / 255f, green: 39f / 255f, blue: 176f / 255f, alpha: 1); } }
			public static UIColor Darken1 { get { return new UIColor(red: 142f / 255f, green: 36f / 255f, blue: 170f / 255f, alpha: 1); } }
			public static UIColor Darken2 { get { return new UIColor(red: 123f / 255f, green: 31f / 255f, blue: 162f / 255f, alpha: 1); } }
			public static UIColor Darken3 { get { return new UIColor(red: 106f / 255f, green: 27f / 255f, blue: 154f / 255f, alpha: 1); } }
			public static UIColor Darken4 { get { return new UIColor(red: 74f / 255f, green: 20f / 255f, blue: 140f / 255f, alpha: 1); } }
			public static UIColor Accent1 { get { return new UIColor(red: 234f / 255f, green: 128f / 255f, blue: 252f / 255f, alpha: 1); } }
			public static UIColor Accent2 { get { return new UIColor(red: 224f / 255f, green: 64f / 255f, blue: 251f / 255f, alpha: 1); } }
			public static UIColor Accent3 { get { return new UIColor(red: 213f / 255f, green: 0f / 255f, blue: 249f / 255f, alpha: 1); } }
			public static UIColor Accent4 { get { return new UIColor(red: 170f / 255f, green: 0f / 255f, blue: 255f / 255f, alpha: 1); } }
		}

		public static class DeepPurple
		{
			public static UIColor Lighten5 { get { return new UIColor(red: 237f / 255f, green: 231f / 255f, blue: 246f / 255f, alpha: 1); } }
			public static UIColor Lighten4 { get { return new UIColor(red: 209f / 255f, green: 196f / 255f, blue: 233f / 255f, alpha: 1); } }
			public static UIColor Lighten3 { get { return new UIColor(red: 179f / 255f, green: 157f / 255f, blue: 219f / 255f, alpha: 1); } }
			public static UIColor Lighten2 { get { return new UIColor(red: 149f / 255f, green: 117f / 255f, blue: 205f / 255f, alpha: 1); } }
			public static UIColor Lighten1 { get { return new UIColor(red: 126f / 255f, green: 87f / 255f, blue: 194f / 255f, alpha: 1); } }
			public static UIColor Base { get { return new UIColor(red: 103f / 255f, green: 58f / 255f, blue: 183f / 255f, alpha: 1); } }
			public static UIColor Darken1 { get { return new UIColor(red: 94f / 255f, green: 53f / 255f, blue: 177f / 255f, alpha: 1); } }
			public static UIColor Darken2 { get { return new UIColor(red: 81f / 255f, green: 45f / 255f, blue: 168f / 255f, alpha: 1); } }
			public static UIColor Darken3 { get { return new UIColor(red: 69f / 255f, green: 39f / 255f, blue: 160f / 255f, alpha: 1); } }
			public static UIColor Darken4 { get { return new UIColor(red: 49f / 255f, green: 27f / 255f, blue: 146f / 255f, alpha: 1); } }
			public static UIColor Accent1 { get { return new UIColor(red: 179f / 255f, green: 136f / 255f, blue: 255f / 255f, alpha: 1); } }
			public static UIColor Accent2 { get { return new UIColor(red: 124f / 255f, green: 77f / 255f, blue: 255f / 255f, alpha: 1); } }
			public static UIColor Accent3 { get { return new UIColor(red: 101f / 255f, green: 31f / 255f, blue: 255f / 255f, alpha: 1); } }
			public static UIColor Accent4 { get { return new UIColor(red: 98f / 255f, green: 0f / 255f, blue: 234f / 255f, alpha: 1); } }
		}

		public static class Indigo
		{
			public static UIColor Lighten5 { get { return new UIColor(red: 232f / 255f, green: 234f / 255f, blue: 246f / 255f, alpha: 1); } }
			public static UIColor Lighten4 { get { return new UIColor(red: 197f / 255f, green: 202f / 255f, blue: 233f / 255f, alpha: 1); } }
			public static UIColor Lighten3 { get { return new UIColor(red: 159f / 255f, green: 168f / 255f, blue: 218f / 255f, alpha: 1); } }
			public static UIColor Lighten2 { get { return new UIColor(red: 121f / 255f, green: 134f / 255f, blue: 203f / 255f, alpha: 1); } }
			public static UIColor Lighten1 { get { return new UIColor(red: 92f / 255f, green: 107f / 255f, blue: 192f / 255f, alpha: 1); } }
			public static UIColor Base { get { return new UIColor(red: 63f / 255f, green: 81f / 255f, blue: 181f / 255f, alpha: 1); } }
			public static UIColor Darken1 { get { return new UIColor(red: 57f / 255f, green: 73f / 255f, blue: 171f / 255f, alpha: 1); } }
			public static UIColor Darken2 { get { return new UIColor(red: 48f / 255f, green: 63f / 255f, blue: 159f / 255f, alpha: 1); } }
			public static UIColor Darken3 { get { return new UIColor(red: 40f / 255f, green: 53f / 255f, blue: 147f / 255f, alpha: 1); } }
			public static UIColor Darken4 { get { return new UIColor(red: 26f / 255f, green: 35f / 255f, blue: 126f / 255f, alpha: 1); } }
			public static UIColor Accent1 { get { return new UIColor(red: 140f / 255f, green: 158f / 255f, blue: 255f / 255f, alpha: 1); } }
			public static UIColor Accent2 { get { return new UIColor(red: 83f / 255f, green: 109f / 255f, blue: 254f / 255f, alpha: 1); } }
			public static UIColor Accent3 { get { return new UIColor(red: 61f / 255f, green: 90f / 255f, blue: 254f / 255f, alpha: 1); } }
			public static UIColor Accent4 { get { return new UIColor(red: 49f / 255f, green: 79f / 255f, blue: 254f / 255f, alpha: 1); } }
		}

		public static class Blue
		{
			public static UIColor Lighten5 { get { return new UIColor(red: 227f / 255f, green: 242f / 255f, blue: 253f / 255f, alpha: 1); } }
			public static UIColor Lighten4 { get { return new UIColor(red: 187f / 255f, green: 222f / 255f, blue: 251f / 255f, alpha: 1); } }
			public static UIColor Lighten3 { get { return new UIColor(red: 144f / 255f, green: 202f / 255f, blue: 249f / 255f, alpha: 1); } }
			public static UIColor Lighten2 { get { return new UIColor(red: 100f / 255f, green: 181f / 255f, blue: 246f / 255f, alpha: 1); } }
			public static UIColor Lighten1 { get { return new UIColor(red: 66f / 255f, green: 165f / 255f, blue: 245f / 255f, alpha: 1); } }
			public static UIColor Base { get { return new UIColor(red: 32f / 255f, green: 150f / 255f, blue: 243f / 255f, alpha: 1); } }
			public static UIColor Darken1 { get { return new UIColor(red: 30f / 255f, green: 136f / 255f, blue: 229f / 255f, alpha: 1); } }
			public static UIColor Darken2 { get { return new UIColor(red: 25f / 255f, green: 118f / 255f, blue: 210f / 255f, alpha: 1); } }
			public static UIColor Darken3 { get { return new UIColor(red: 21f / 255f, green: 101f / 255f, blue: 192f / 255f, alpha: 1); } }
			public static UIColor Darken4 { get { return new UIColor(red: 13f / 255f, green: 71f / 255f, blue: 161f / 255f, alpha: 1); } }
			public static UIColor Accent1 { get { return new UIColor(red: 130f / 255f, green: 177f / 255f, blue: 255f / 255f, alpha: 1); } }
			public static UIColor Accent2 { get { return new UIColor(red: 68f / 255f, green: 138f / 255f, blue: 255f / 255f, alpha: 1); } }
			public static UIColor Accent3 { get { return new UIColor(red: 41f / 255f, green: 121f / 255f, blue: 255f / 255f, alpha: 1); } }
			public static UIColor Accent4 { get { return new UIColor(red: 41f / 255f, green: 98f / 255f, blue: 255f / 255f, alpha: 1); } }
		}

		public static class LightBlue
		{
			public static UIColor Lighten5 { get { return new UIColor(red: 225f / 255f, green: 245f / 255f, blue: 254f / 255f, alpha: 1); } }
			public static UIColor Lighten4 { get { return new UIColor(red: 179f / 255f, green: 229f / 255f, blue: 252f / 255f, alpha: 1); } }
			public static UIColor Lighten3 { get { return new UIColor(red: 129f / 255f, green: 212f / 255f, blue: 250f / 255f, alpha: 1); } }
			public static UIColor Lighten2 { get { return new UIColor(red: 79f / 255f, green: 195f / 255f, blue: 247f / 255f, alpha: 1); } }
			public static UIColor Lighten1 { get { return new UIColor(red: 41f / 255f, green: 182f / 255f, blue: 246f / 255f, alpha: 1); } }
			public static UIColor Base { get { return new UIColor(red: 3f / 255f, green: 169f / 255f, blue: 244f / 255f, alpha: 1); } }
			public static UIColor Darken1 { get { return new UIColor(red: 3f / 255f, green: 155f / 255f, blue: 229f / 255f, alpha: 1); } }
			public static UIColor Darken2 { get { return new UIColor(red: 2f / 255f, green: 136f / 255f, blue: 209f / 255f, alpha: 1); } }
			public static UIColor Darken3 { get { return new UIColor(red: 2f / 255f, green: 119f / 255f, blue: 189f / 255f, alpha: 1); } }
			public static UIColor Darken4 { get { return new UIColor(red: 1f / 255f, green: 87f / 255f, blue: 155f / 255f, alpha: 1); } }
			public static UIColor Accent1 { get { return new UIColor(red: 128f / 255f, green: 216f / 255f, blue: 255f / 255f, alpha: 1); } }
			public static UIColor Accent2 { get { return new UIColor(red: 64f / 255f, green: 196f / 255f, blue: 255f / 255f, alpha: 1); } }
			public static UIColor Accent3 { get { return new UIColor(red: 0f / 255f, green: 176f / 255f, blue: 255f / 255f, alpha: 1); } }
			public static UIColor Accent4 { get { return new UIColor(red: 0f / 255f, green: 145f / 255f, blue: 234f / 255f, alpha: 1); } }
		}

		public static class Cyan
		{
			public static UIColor Lighten5 { get { return new UIColor(red: 224f / 255f, green: 247f / 255f, blue: 250f / 255f, alpha: 1); } }
			public static UIColor Lighten4 { get { return new UIColor(red: 178f / 255f, green: 235f / 255f, blue: 242f / 255f, alpha: 1); } }
			public static UIColor Lighten3 { get { return new UIColor(red: 128f / 255f, green: 222f / 255f, blue: 234f / 255f, alpha: 1); } }
			public static UIColor Lighten2 { get { return new UIColor(red: 77f / 255f, green: 208f / 255f, blue: 225f / 255f, alpha: 1); } }
			public static UIColor Lighten1 { get { return new UIColor(red: 38f / 255f, green: 198f / 255f, blue: 218f / 255f, alpha: 1); } }
			public static UIColor Base { get { return new UIColor(red: 0f / 255f, green: 188f / 255f, blue: 212f / 255f, alpha: 1); } }
			public static UIColor Darken1 { get { return new UIColor(red: 0f / 255f, green: 172f / 255f, blue: 193f / 255f, alpha: 1); } }
			public static UIColor Darken2 { get { return new UIColor(red: 0f / 255f, green: 151f / 255f, blue: 167f / 255f, alpha: 1); } }
			public static UIColor Darken3 { get { return new UIColor(red: 0f / 255f, green: 131f / 255f, blue: 143f / 255f, alpha: 1); } }
			public static UIColor Darken4 { get { return new UIColor(red: 0f / 255f, green: 96f / 255f, blue: 100f / 255f, alpha: 1); } }
			public static UIColor Accent1 { get { return new UIColor(red: 132f / 255f, green: 255f / 255f, blue: 255f / 255f, alpha: 1); } }
			public static UIColor Accent2 { get { return new UIColor(red: 24f / 255f, green: 255f / 255f, blue: 255f / 255f, alpha: 1); } }
			public static UIColor Accent3 { get { return new UIColor(red: 0f / 255f, green: 229f / 255f, blue: 255f / 255f, alpha: 1); } }
			public static UIColor Accent4 { get { return new UIColor(red: 0f / 255f, green: 184f / 255f, blue: 212f / 255f, alpha: 1); } }
		}

		public static class Teal
		{
			public static UIColor Lighten5 { get { return new UIColor(red: 224f / 255f, green: 242f / 255f, blue: 241f / 255f, alpha: 1); } }
			public static UIColor Lighten4 { get { return new UIColor(red: 178f / 255f, green: 223f / 255f, blue: 219f / 255f, alpha: 1); } }
			public static UIColor Lighten3 { get { return new UIColor(red: 128f / 255f, green: 203f / 255f, blue: 196f / 255f, alpha: 1); } }
			public static UIColor Lighten2 { get { return new UIColor(red: 77f / 255f, green: 182f / 255f, blue: 172f / 255f, alpha: 1); } }
			public static UIColor Lighten1 { get { return new UIColor(red: 38f / 255f, green: 166f / 255f, blue: 154f / 255f, alpha: 1); } }
			public static UIColor Base { get { return new UIColor(red: 0f / 255f, green: 150f / 255f, blue: 136f / 255f, alpha: 1); } }
			public static UIColor Darken1 { get { return new UIColor(red: 0f / 255f, green: 137f / 255f, blue: 123f / 255f, alpha: 1); } }
			public static UIColor Darken2 { get { return new UIColor(red: 0f / 255f, green: 121f / 255f, blue: 107f / 255f, alpha: 1); } }
			public static UIColor Darken3 { get { return new UIColor(red: 0f / 255f, green: 105f / 255f, blue: 92f / 255f, alpha: 1); } }
			public static UIColor Darken4 { get { return new UIColor(red: 0f / 255f, green: 77f / 255f, blue: 64f / 255f, alpha: 1); } }
			public static UIColor Accent1 { get { return new UIColor(red: 167f / 255f, green: 255f / 255f, blue: 235f / 255f, alpha: 1); } }
			public static UIColor Accent2 { get { return new UIColor(red: 100f / 255f, green: 255f / 255f, blue: 218f / 255f, alpha: 1); } }
			public static UIColor Accent3 { get { return new UIColor(red: 29f / 255f, green: 233f / 255f, blue: 182f / 255f, alpha: 1); } }
			public static UIColor Accent4 { get { return new UIColor(red: 0f / 255f, green: 191f / 255f, blue: 165f / 255f, alpha: 1); } }
		}

		public static class Green
		{
			public static UIColor Lighten5 { get { return new UIColor(red: 241f / 255f, green: 245f / 255f, blue: 233f / 255f, alpha: 1); } }
			public static UIColor Lighten4 { get { return new UIColor(red: 200f / 255f, green: 230f / 255f, blue: 201f / 255f, alpha: 1); } }
			public static UIColor Lighten3 { get { return new UIColor(red: 165f / 255f, green: 214f / 255f, blue: 167f / 255f, alpha: 1); } }
			public static UIColor Lighten2 { get { return new UIColor(red: 129f / 255f, green: 199f / 255f, blue: 132f / 255f, alpha: 1); } }
			public static UIColor Lighten1 { get { return new UIColor(red: 102f / 255f, green: 187f / 255f, blue: 106f / 255f, alpha: 1); } }
			public static UIColor Base { get { return new UIColor(red: 76f / 255f, green: 175f / 255f, blue: 80f / 255f, alpha: 1); } }
			public static UIColor Darken1 { get { return new UIColor(red: 67f / 255f, green: 160f / 255f, blue: 71f / 255f, alpha: 1); } }
			public static UIColor Darken2 { get { return new UIColor(red: 56f / 255f, green: 142f / 255f, blue: 60f / 255f, alpha: 1); } }
			public static UIColor Darken3 { get { return new UIColor(red: 46f / 255f, green: 125f / 255f, blue: 50f / 255f, alpha: 1); } }
			public static UIColor Darken4 { get { return new UIColor(red: 27f / 255f, green: 94f / 255f, blue: 32f / 255f, alpha: 1); } }
			public static UIColor Accent1 { get { return new UIColor(red: 185f / 255f, green: 246f / 255f, blue: 202f / 255f, alpha: 1); } }
			public static UIColor Accent2 { get { return new UIColor(red: 105f / 255f, green: 240f / 255f, blue: 174f / 255f, alpha: 1); } }
			public static UIColor Accent3 { get { return new UIColor(red: 0f / 255f, green: 230f / 255f, blue: 118f / 255f, alpha: 1); } }
			public static UIColor Accent4 { get { return new UIColor(red: 0f / 255f, green: 200f / 255f, blue: 83f / 255f, alpha: 1); } }
		}

		public static class LightGreen
		{
			public static UIColor Lighten5 { get { return new UIColor(red: 241f / 255f, green: 248f / 255f, blue: 233f / 255f, alpha: 1); } }
			public static UIColor Lighten4 { get { return new UIColor(red: 220f / 255f, green: 237f / 255f, blue: 200f / 255f, alpha: 1); } }
			public static UIColor Lighten3 { get { return new UIColor(red: 197f / 255f, green: 225f / 255f, blue: 165f / 255f, alpha: 1); } }
			public static UIColor Lighten2 { get { return new UIColor(red: 174f / 255f, green: 213f / 255f, blue: 129f / 255f, alpha: 1); } }
			public static UIColor Lighten1 { get { return new UIColor(red: 156f / 255f, green: 204f / 255f, blue: 101f / 255f, alpha: 1); } }
			public static UIColor Base { get { return new UIColor(red: 139f / 255f, green: 195f / 255f, blue: 74f / 255f, alpha: 1); } }
			public static UIColor Darken1 { get { return new UIColor(red: 124f / 255f, green: 179f / 255f, blue: 66f / 255f, alpha: 1); } }
			public static UIColor Darken2 { get { return new UIColor(red: 104f / 255f, green: 159f / 255f, blue: 56f / 255f, alpha: 1); } }
			public static UIColor Darken3 { get { return new UIColor(red: 85f / 255f, green: 139f / 255f, blue: 47f / 255f, alpha: 1); } }
			public static UIColor Darken4 { get { return new UIColor(red: 51f / 255f, green: 105f / 255f, blue: 30f / 255f, alpha: 1); } }
			public static UIColor Accent1 { get { return new UIColor(red: 204f / 255f, green: 255f / 255f, blue: 144f / 255f, alpha: 1); } }
			public static UIColor Accent2 { get { return new UIColor(red: 178f / 255f, green: 255f / 255f, blue: 89f / 255f, alpha: 1); } }
			public static UIColor Accent3 { get { return new UIColor(red: 118f / 255f, green: 255f / 255f, blue: 3f / 255f, alpha: 1); } }
			public static UIColor Accent4 { get { return new UIColor(red: 100f / 255f, green: 221f / 255f, blue: 23f / 255f, alpha: 1); } }
		}

		public static class Lime
		{
			public static UIColor Lighten5 { get { return new UIColor(red: 249f / 255f, green: 251f / 255f, blue: 231f / 255f, alpha: 1); } }
			public static UIColor Lighten4 { get { return new UIColor(red: 240f / 255f, green: 244f / 255f, blue: 195f / 255f, alpha: 1); } }
			public static UIColor Lighten3 { get { return new UIColor(red: 230f / 255f, green: 238f / 255f, blue: 156f / 255f, alpha: 1); } }
			public static UIColor Lighten2 { get { return new UIColor(red: 220f / 255f, green: 231f / 255f, blue: 117f / 255f, alpha: 1); } }
			public static UIColor Lighten1 { get { return new UIColor(red: 212f / 255f, green: 225f / 255f, blue: 87f / 255f, alpha: 1); } }
			public static UIColor Base { get { return new UIColor(red: 205f / 255f, green: 220f / 255f, blue: 57f / 255f, alpha: 1); } }
			public static UIColor Darken1 { get { return new UIColor(red: 192f / 255f, green: 202f / 255f, blue: 51f / 255f, alpha: 1); } }
			public static UIColor Darken2 { get { return new UIColor(red: 175f / 255f, green: 180f / 255f, blue: 43f / 255f, alpha: 1); } }
			public static UIColor Darken3 { get { return new UIColor(red: 158f / 255f, green: 157f / 255f, blue: 36f / 255f, alpha: 1); } }
			public static UIColor Darken4 { get { return new UIColor(red: 130f / 255f, green: 119f / 255f, blue: 23f / 255f, alpha: 1); } }
			public static UIColor Accent1 { get { return new UIColor(red: 244f / 255f, green: 255f / 255f, blue: 129f / 255f, alpha: 1); } }
			public static UIColor Accent2 { get { return new UIColor(red: 238f / 255f, green: 255f / 255f, blue: 65f / 255f, alpha: 1); } }
			public static UIColor Accent3 { get { return new UIColor(red: 198f / 255f, green: 255f / 255f, blue: 0f / 255f, alpha: 1); } }
			public static UIColor Accent4 { get { return new UIColor(red: 174f / 255f, green: 234f / 255f, blue: 0f / 255f, alpha: 1); } }
		}

		public static class Yellow
		{
			public static UIColor Lighten5 { get { return new UIColor(red: 255f / 255f, green: 253f / 255f, blue: 231f / 255f, alpha: 1); } }
			public static UIColor Lighten4 { get { return new UIColor(red: 255f / 255f, green: 249f / 255f, blue: 196f / 255f, alpha: 1); } }
			public static UIColor Lighten3 { get { return new UIColor(red: 255f / 255f, green: 245f / 255f, blue: 157f / 255f, alpha: 1); } }
			public static UIColor Lighten2 { get { return new UIColor(red: 255f / 255f, green: 241f / 255f, blue: 118f / 255f, alpha: 1); } }
			public static UIColor Lighten1 { get { return new UIColor(red: 255f / 255f, green: 238f / 255f, blue: 88f / 255f, alpha: 1); } }
			public static UIColor Base { get { return new UIColor(red: 255f / 255f, green: 235f / 255f, blue: 59f / 255f, alpha: 1); } }
			public static UIColor Darken1 { get { return new UIColor(red: 253f / 255f, green: 216f / 255f, blue: 53f / 255f, alpha: 1); } }
			public static UIColor Darken2 { get { return new UIColor(red: 251f / 255f, green: 192f / 255f, blue: 45f / 255f, alpha: 1); } }
			public static UIColor Darken3 { get { return new UIColor(red: 249f / 255f, green: 168f / 255f, blue: 37f / 255f, alpha: 1); } }
			public static UIColor Darken4 { get { return new UIColor(red: 245f / 255f, green: 127f / 255f, blue: 23f / 255f, alpha: 1); } }
			public static UIColor Accent1 { get { return new UIColor(red: 255f / 255f, green: 255f / 255f, blue: 141f / 255f, alpha: 1); } }
			public static UIColor Accent2 { get { return new UIColor(red: 255f / 255f, green: 255f / 255f, blue: 0f / 255f, alpha: 1); } }
			public static UIColor Accent3 { get { return new UIColor(red: 255f / 255f, green: 234f / 255f, blue: 0f / 255f, alpha: 1); } }
			public static UIColor Accent4 { get { return new UIColor(red: 255f / 255f, green: 214f / 255f, blue: 0f / 255f, alpha: 1); } }
		}

		public static class Amber
		{
			public static UIColor Lighten5 { get { return new UIColor(red: 255f / 255f, green: 248f / 255f, blue: 225f / 255f, alpha: 1); } }
			public static UIColor Lighten4 { get { return new UIColor(red: 255f / 255f, green: 236f / 255f, blue: 179f / 255f, alpha: 1); } }
			public static UIColor Lighten3 { get { return new UIColor(red: 255f / 255f, green: 224f / 255f, blue: 130f / 255f, alpha: 1); } }
			public static UIColor Lighten2 { get { return new UIColor(red: 255f / 255f, green: 213f / 255f, blue: 79f / 255f, alpha: 1); } }
			public static UIColor Lighten1 { get { return new UIColor(red: 255f / 255f, green: 202f / 255f, blue: 40f / 255f, alpha: 1); } }
			public static UIColor Base { get { return new UIColor(red: 255f / 255f, green: 193f / 255f, blue: 7f / 255f, alpha: 1); } }
			public static UIColor Darken1 { get { return new UIColor(red: 255f / 255f, green: 179f / 255f, blue: 0f / 255f, alpha: 1); } }
			public static UIColor Darken2 { get { return new UIColor(red: 255f / 255f, green: 160f / 255f, blue: 0f / 255f, alpha: 1); } }
			public static UIColor Darken3 { get { return new UIColor(red: 255f / 255f, green: 143f / 255f, blue: 0f / 255f, alpha: 1); } }
			public static UIColor Darken4 { get { return new UIColor(red: 255f / 255f, green: 111f / 255f, blue: 0f / 255f, alpha: 1); } }
			public static UIColor Accent1 { get { return new UIColor(red: 255f / 255f, green: 229f / 255f, blue: 127f / 255f, alpha: 1); } }
			public static UIColor Accent2 { get { return new UIColor(red: 255f / 255f, green: 215f / 255f, blue: 64f / 255f, alpha: 1); } }
			public static UIColor Accent3 { get { return new UIColor(red: 255f / 255f, green: 196f / 255f, blue: 0f / 255f, alpha: 1); } }
			public static UIColor Accent4 { get { return new UIColor(red: 255f / 255f, green: 171f / 255f, blue: 0f / 255f, alpha: 1); } }
		}

		public static class Orange
		{
			public static UIColor Lighten5 { get { return new UIColor(red: 255f / 255f, green: 243f / 255f, blue: 224f / 255f, alpha: 1); } }
			public static UIColor Lighten4 { get { return new UIColor(red: 255f / 255f, green: 224f / 255f, blue: 178f / 255f, alpha: 1); } }
			public static UIColor Lighten3 { get { return new UIColor(red: 255f / 255f, green: 204f / 255f, blue: 128f / 255f, alpha: 1); } }
			public static UIColor Lighten2 { get { return new UIColor(red: 255f / 255f, green: 183f / 255f, blue: 77f / 255f, alpha: 1); } }
			public static UIColor Lighten1 { get { return new UIColor(red: 255f / 255f, green: 167f / 255f, blue: 38f / 255f, alpha: 1); } }
			public static UIColor Base { get { return new UIColor(red: 255f / 255f, green: 152f / 255f, blue: 0f / 255f, alpha: 1); } }
			public static UIColor Darken1 { get { return new UIColor(red: 251f / 255f, green: 140f / 255f, blue: 0f / 255f, alpha: 1); } }
			public static UIColor Darken2 { get { return new UIColor(red: 245f / 255f, green: 124f / 255f, blue: 0f / 255f, alpha: 1); } }
			public static UIColor Darken3 { get { return new UIColor(red: 239f / 255f, green: 108f / 255f, blue: 0f / 255f, alpha: 1); } }
			public static UIColor Darken4 { get { return new UIColor(red: 230f / 255f, green: 81f / 255f, blue: 0f / 255f, alpha: 1); } }
			public static UIColor Accent1 { get { return new UIColor(red: 255f / 255f, green: 209f / 255f, blue: 128f / 255f, alpha: 1); } }
			public static UIColor Accent2 { get { return new UIColor(red: 255f / 255f, green: 171f / 255f, blue: 64f / 255f, alpha: 1); } }
			public static UIColor Accent3 { get { return new UIColor(red: 255f / 255f, green: 145f / 255f, blue: 0f / 255f, alpha: 1); } }
			public static UIColor Accent4 { get { return new UIColor(red: 255f / 255f, green: 109f / 255f, blue: 0f / 255f, alpha: 1); } }
		}

		public static class DeepOrange
		{
			public static UIColor Lighten5 { get { return new UIColor(red: 251f / 255f, green: 233f / 255f, blue: 231f / 255f, alpha: 1); } }
			public static UIColor Lighten4 { get { return new UIColor(red: 255f / 255f, green: 204f / 255f, blue: 188f / 255f, alpha: 1); } }
			public static UIColor Lighten3 { get { return new UIColor(red: 255f / 255f, green: 171f / 255f, blue: 145f / 255f, alpha: 1); } }
			public static UIColor Lighten2 { get { return new UIColor(red: 255f / 255f, green: 138f / 255f, blue: 101f / 255f, alpha: 1); } }
			public static UIColor Lighten1 { get { return new UIColor(red: 255f / 255f, green: 112f / 255f, blue: 67f / 255f, alpha: 1); } }
			public static UIColor Base { get { return new UIColor(red: 255f / 255f, green: 87f / 255f, blue: 34f / 255f, alpha: 1); } }
			public static UIColor Darken1 { get { return new UIColor(red: 244f / 255f, green: 81f / 255f, blue: 30f / 255f, alpha: 1); } }
			public static UIColor Darken2 { get { return new UIColor(red: 230f / 255f, green: 74f / 255f, blue: 25f / 255f, alpha: 1); } }
			public static UIColor Darken3 { get { return new UIColor(red: 216f / 255f, green: 67f / 255f, blue: 21f / 255f, alpha: 1); } }
			public static UIColor Darken4 { get { return new UIColor(red: 191f / 255f, green: 54f / 255f, blue: 12f / 255f, alpha: 1); } }
			public static UIColor Accent1 { get { return new UIColor(red: 255f / 255f, green: 158f / 255f, blue: 128f / 255f, alpha: 1); } }
			public static UIColor Accent2 { get { return new UIColor(red: 255f / 255f, green: 110f / 255f, blue: 64f / 255f, alpha: 1); } }
			public static UIColor Accent3 { get { return new UIColor(red: 255f / 255f, green: 61f / 255f, blue: 0f / 255f, alpha: 1); } }
			public static UIColor Accent4 { get { return new UIColor(red: 221f / 255f, green: 44f / 255f, blue: 0f / 255f, alpha: 1); } }
		}

		public static class Brown
		{
			public static UIColor Lighten5 { get { return new UIColor(red: 239f / 255f, green: 235f / 255f, blue: 233f / 255f, alpha: 1); } }
			public static UIColor Lighten4 { get { return new UIColor(red: 215f / 255f, green: 204f / 255f, blue: 200f / 255f, alpha: 1); } }
			public static UIColor Lighten3 { get { return new UIColor(red: 188f / 255f, green: 170f / 255f, blue: 164f / 255f, alpha: 1); } }
			public static UIColor Lighten2 { get { return new UIColor(red: 161f / 255f, green: 136f / 255f, blue: 127f / 255f, alpha: 1); } }
			public static UIColor Lighten1 { get { return new UIColor(red: 141f / 255f, green: 110f / 255f, blue: 99f / 255f, alpha: 1); } }
			public static UIColor Base { get { return new UIColor(red: 121f / 255f, green: 85f / 255f, blue: 72f / 255f, alpha: 1); } }
			public static UIColor Darken1 { get { return new UIColor(red: 109f / 255f, green: 76f / 255f, blue: 65f / 255f, alpha: 1); } }
			public static UIColor Darken2 { get { return new UIColor(red: 93f / 255f, green: 64f / 255f, blue: 55f / 255f, alpha: 1); } }
			public static UIColor Darken3 { get { return new UIColor(red: 78f / 255f, green: 52f / 255f, blue: 46f / 255f, alpha: 1); } }
			public static UIColor Darken4 { get { return new UIColor(red: 62f / 255f, green: 39f / 255f, blue: 35f / 255f, alpha: 1); } }
		}

		public static class Grey
		{
			public static UIColor Lighten5 { get { return new UIColor(red: 250f / 255f, green: 250f / 255f, blue: 250f / 255f, alpha: 1); } }
			public static UIColor Lighten4 { get { return new UIColor(red: 245f / 255f, green: 245f / 255f, blue: 245f / 255f, alpha: 1); } }
			public static UIColor Lighten3 { get { return new UIColor(red: 238f / 255f, green: 238f / 255f, blue: 238f / 255f, alpha: 1); } }
			public static UIColor Lighten2 { get { return new UIColor(red: 224f / 255f, green: 224f / 255f, blue: 224f / 255f, alpha: 1); } }  
			public static UIColor Lighten1 { get { return new UIColor(red: 189f / 255f, green: 189f / 255f, blue: 189f / 255f, alpha: 1); } }  
			public static UIColor Base { get { return new UIColor(red: 158f / 255f, green: 158f / 255f, blue: 158f / 255f, alpha: 1); } }
			public static UIColor Darken1 { get { return new UIColor(red: 117f / 255f, green: 117f / 255f, blue: 117f / 255f, alpha: 1); } }
			public static UIColor Darken2 { get { return new UIColor(red: 97f / 255f, green: 97f / 255f, blue: 97f / 255f, alpha: 1); } }
			public static UIColor Darken3 { get { return new UIColor(red: 66f / 255f, green: 66f / 255f, blue: 66f / 255f, alpha: 1); } }
			public static UIColor Darken4 { get { return new UIColor(red: 33f / 255f, green: 33f / 255f, blue: 33f / 255f, alpha: 1); } }
		}

		public static class BlueGrey
		{
			public static UIColor Lighten5 { get { return new UIColor(red: 236f / 255f, green: 239f / 255f, blue: 241f / 255f, alpha: 1); } }
			public static UIColor Lighten4 { get { return new UIColor(red: 207f / 255f, green: 216f / 255f, blue: 220f / 255f, alpha: 1); } }
			public static UIColor Lighten3 { get { return new UIColor(red: 176f / 255f, green: 190f / 255f, blue: 197f / 255f, alpha: 1); } }
			public static UIColor Lighten2 { get { return new UIColor(red: 144f / 255f, green: 164f / 255f, blue: 174f / 255f, alpha: 1); } }
			public static UIColor Lighten1 { get { return new UIColor(red: 120f / 255f, green: 144f / 255f, blue: 156f / 255f, alpha: 1); } }
			public static UIColor Base { get { return new UIColor(red: 96f / 255f, green: 125f / 255f, blue: 139f / 255f, alpha: 1); } }
			public static UIColor Darken1 { get { return new UIColor(red: 84f / 255f, green: 110f / 255f, blue: 122f / 255f, alpha: 1); } }
			public static UIColor Darken2 { get { return new UIColor(red: 69f / 255f, green: 90f / 255f, blue: 100f / 255f, alpha: 1); } }
			public static UIColor Darken3 { get { return new UIColor(red: 55f / 255f, green: 71f / 255f, blue: 79f / 255f, alpha: 1); } }
			public static UIColor Darken4 { get { return new UIColor(red: 38f / 255f, green: 50f / 255f, blue: 56f / 255f, alpha: 1); } }
		}
	}
}
