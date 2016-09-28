using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using CoreFoundation;
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
			string loadedFont;
			MaterialFontLoader.LoadedFonts.TryGetValue(fontName, out loadedFont);
			if ((loadedFont == null) && (UIFont.FromName(name: fontName, size: 1) == null))
			{
				MaterialFontLoader.LoadedFonts[fontName] = fontName;
				var bundle = NSBundle.FromClass(new Class(typeof(MaterialFontLoader)));
				var identifier = bundle.BundleIdentifier;
				var fontURL = bundle.GetUrlForResource(name: fontName, fileExtension: "ttf", subdirectory:"Fonts/Roboto");
//				var fontURL = bundle.GetUrlForResource(name: fontName, fileExtension: "ttf");
				if (fontURL != null)
				{
					var data = NSData.FromUrl(fontURL);
					var provider = new CGDataProvider(data);
					var font = CGFont.CreateFromProvider(provider);

					NSError error;
					if (!CoreText.CTFontManager.RegisterGraphicsFont(font, out error))
					{
						var errerrorDescription = error.Description;
						throw new Exception(error.Description);
						//new NSException(name: NSException.con, reason: error.Description, userInfo: error.UserInfo);
					}
				}
			}
		}
	}
}
