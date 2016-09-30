using System;
using Foundation;
using UIKit;
namespace FPT.Framework.iOS.Material
{
	public static class MaterialIcon
	{
		private static NSBundle sInternalBundle;

		public static NSBundle Bundle
		{
			get
			{
				if (sInternalBundle == null)
				{
					MaterialIcon.sInternalBundle = NSBundle.FromClass(new ObjCRuntime.Class(typeof(MaterialIcon)));	

				}

				return MaterialIcon.sInternalBundle;
			}
		}

		public static UIImage Icon(string name)
		{
			//return UIImage.FromBundle(name).ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
			return UIImage.FromBundle(name: name, bundle: Bundle, traitCollection: null).ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
		}

		public static class CM {
			public static UIImage AddWhite
			{
				get
				{
					return MaterialIcon.Icon("cm_add_white");
				}
			}
			//public static UIImage Pen {
			//	get
			//	{
			//		return MaterialIcon.Icon("cm_pen_white");
			//	}
			//}
		}
	}
}
