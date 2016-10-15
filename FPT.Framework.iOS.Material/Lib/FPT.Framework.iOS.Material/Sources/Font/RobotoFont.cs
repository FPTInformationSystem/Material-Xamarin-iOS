using System;
using UIKit;
namespace FPT.Framework.iOS.Material
{
	public class RobotoFont : MaterialFontType
	{
		public static nfloat PointSize
		{
			get {
				return MaterialFont.PointSize;
			}
		}

		public static UIFont Thin
		{
			get
			{
				return ThinWithSize(MaterialFont.PointSize);
			}
		}

		public static UIFont ThinWithSize(nfloat size)
		{
			MaterialFont.loadFontIfNeeded("Roboto-Thin");
			var f = UIFont.FromName(name: "Roboto-Thin", size: size);
			if (f != null)
			{
				return f;
			}
			return MaterialFont.SystemFontWithSize(size);
		}

		public static UIFont Light
		{
			get
			{
				return LightWithSize(MaterialFont.PointSize);
			}
		}

		public static UIFont LightWithSize(nfloat size)
		{
			MaterialFont.loadFontIfNeeded("Roboto-Light");
			var f = UIFont.FromName(name: "Roboto-Light", size: size);
			if (f != null)
			{
				return f;
			}
			return MaterialFont.SystemFontWithSize(size);
		}

		public static UIFont Regular
		{
			get
			{
				return RegularWithSize(MaterialFont.PointSize);
			}
		}

		public static UIFont RegularWithSize(nfloat size)
		{
			MaterialFont.loadFontIfNeeded("Roboto-Regular");
			var f = UIFont.FromName(name: "Roboto-Regular", size: size);
			if (f != null)
			{
				return f;
			}
			return MaterialFont.SystemFontWithSize(size);
		}

		public static UIFont Medium
		{
			get
			{
				return MediumWithSize(MaterialFont.PointSize);
			}
		}

		public static UIFont MediumWithSize(nfloat size)
		{
			MaterialFont.loadFontIfNeeded("Roboto-Medium");
			var f = UIFont.FromName(name: "Roboto-Medium", size: size);
			if (f != null)
			{
				return f;
			}
			return MaterialFont.BoldSystemFontWithSize(size);
		}

		public static UIFont Bold
		{
			get
			{
				return BoldWithSize(MaterialFont.PointSize);
			}
		}

		public static UIFont BoldWithSize(nfloat size)
		{
			MaterialFont.loadFontIfNeeded("Roboto-Bold");
			var f = UIFont.FromName(name: "Roboto-Bold", size: size);
			if (f != null)
			{
				return f;
			}
			return MaterialFont.BoldSystemFontWithSize(size);
		}
	}
}
