using System;
using System.Collections.Generic;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace FPT.Framework.iOS.Material
{
	public interface MaterialFontType { }

	public class MaterialFont : MaterialFontType
	{
		public static readonly nfloat PointSize = 16;

		public static UIFont SystemFontWithSize(nfloat size)
		{
			return UIFont.SystemFontOfSize(size);
		}

		public static UIFont BoldSystemFontWithSize(nfloat size)
		{
			return UIFont.BoldSystemFontOfSize(size);
		}

		public static UIFont ItalicSystemFontWithSize(nfloat size)
		{
			return UIFont.ItalicSystemFontOfSize(size);
		}

		public static void loadFontIfNeeded(string fontName)
		{
			MaterialFontLoader.loadFontIfNeeded(fontName);
		}
	}

	internal class MaterialFontLoader
	{
		private static Dictionary<string, string> mLoadedFonts = new Dictionary<string, string>();

		private static Dictionary<string, string> LoadedFonts
		{
			get
			{
				return mLoadedFonts;
			}
		}

		internal static void loadFontIfNeeded(string fontName)
		{
			var loeadedFont = MaterialFontLoader.LoadedFonts[fontName];
			if ((LoadedFonts == null) && (UIFont.FromName(name: fontName, size: 1) == null))
			{
				MaterialFontLoader.LoadedFonts[fontName] = fontName;
				var bundle = NSBundle.FromClass(new Class(typeof(MaterialFontLoader)));
				var identifier = bundle.BundleIdentifier;

			}
		}
	}
}
