using System;
using Foundation;
using UIKit;
namespace FPT.Framework.iOS.Material
{
	public static class Icon
	{
		private static NSBundle sInternalBundle;

		public static NSBundle Bundle
		{
			get
			{
				if (sInternalBundle == null)
				{
					Material.Icon.sInternalBundle = NSBundle.FromClass(new ObjCRuntime.Class(typeof(Icon)));	

				}

				return Material.Icon.sInternalBundle;
			}
		}

		private static UIImage icon(string name)
		{
			//return UIImage.FromBundle(name).ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
			return UIImage.FromBundle(name: name, bundle: Bundle, traitCollection: null).ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
		}

		public static UIImage ArrowBack
		{
			get
			{
				return Material.Icon.icon("ic_arrow_back_white");
			}
		}

		public static UIImage Email
		{
			get
			{
				return Material.Icon.icon("ic_email_white");
			}
		}

		public static UIImage Favorite
		{
			get
			{
				return Material.Icon.icon("ic_favorite_white");
			}
		}

		public static UIImage MoreHorizontal
		{
			get
			{
				return Material.Icon.icon("ic_more_horiz_white");
			}
		}

		public static UIImage MoreVertical
		{
			get
			{
				return Material.Icon.icon("ic_more_vert_white");
			}
		}

		public static UIImage Phone
		{
			get
			{
				return Material.Icon.icon("ic_phone_white");
			}
		}

		public static UIImage Share
		{
			get
			{
				return Material.Icon.icon("cm_share_white");
			}
		}

		public static UIImage Visibility
		{
			get
			{
				return Material.Icon.icon("ic_visibility_white");
			}
		}

		public static class CM {
			public static UIImage Add
			{
				get
				{
					return Material.Icon.icon("cm_add_white");
				}
			}

			public static UIImage AudioLibrary
			{
				get
				{
					return Material.Icon.icon("cm_audio_library_white");
				}
			}

			public static UIImage Bell
			{
				get
				{
					return Material.Icon.icon("cm_bell_white");
				}
			}

			public static UIImage Clear
			{
				get
				{
					return Material.Icon.icon("cm_close_white");
				}
			}

			public static UIImage Close
			{
				get
				{
					return Material.Icon.icon("cm_close_white");
				}
			}

			public static UIImage Menu
			{
				get
				{
					return Material.Icon.icon("cm_menu_white");
				}
			}

			public static UIImage PhotoCamera
			{
				get
				{
					return Material.Icon.icon("cm_photo_camera_white");
				}
			}

			public static UIImage Star
			{
				get
				{
					return Material.Icon.icon("cm_star_white");
				}
			}

			public static UIImage Search
			{
				get
				{
					return Material.Icon.icon("cm_search_white");
				}
			}

			public static UIImage Settings
			{
				get
				{
					return Material.Icon.icon("cm_settings_white");
				}
			}

			public static UIImage Share
			{
				get
				{
					return Material.Icon.icon("cm_share_white");
				}
			}

			public static UIImage Videocam
			{
				get
				{
					return Material.Icon.icon("cm_videocam_white");
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
