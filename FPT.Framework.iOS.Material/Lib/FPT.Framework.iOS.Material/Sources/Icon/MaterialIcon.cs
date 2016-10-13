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

		public static UIImage Visibility
		{
			get
			{
				return MaterialIcon.Icon("ic_visibility_white");
			}
		}

		public static class CM {
			public static UIImage Add
			{
				get
				{
					return MaterialIcon.Icon("cm_add_white");
				}
			}
			public static UIImage Clear
			{
				get
				{
					return MaterialIcon.Icon("cm_close_white");
				}
			}

			public static UIImage Close
			{
				get
				{
					return MaterialIcon.Icon("cm_close_white");
				}
			}

			public static UIImage MoreVertical
			{
				get
				{
					return MaterialIcon.Icon("ic_more_vert_white");
				}
			}

			public static UIImage Search
			{
				get
				{
					return MaterialIcon.Icon("cm_search_white");
				}
			}

			public static UIImage Settings
			{
				get
				{
					return MaterialIcon.Icon("cm_settings_white");
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
