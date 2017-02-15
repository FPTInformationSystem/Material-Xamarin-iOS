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

		public static UIImage Add
		{
			get
			{
				return Material.Icon.icon("ic_add_white");
			}
		}

		public static UIImage AddCircle
		{
			get
			{
				return Material.Icon.icon("ic_add_circle_white");
			}
		}

		public static UIImage AddCircleOutline
		{
			get
			{
				return Material.Icon.icon("ic_add_circle_outline_white");
			}
		}

		public static UIImage ArrowBack
		{
			get
			{
				return Material.Icon.icon("ic_arrow_back_white");
			}
		}

		public static UIImage ArrowDownward
		{
			get
			{
				return Material.Icon.icon("ic_arrow_downward_white");
			}
		}

		public static UIImage Audio
		{
			get
			{
				return Material.Icon.icon("ic_audiotrack_white");
			}
		}

		public static UIImage Bell
		{
			get
			{
				return Material.Icon.icon("cm_bell_white");
			}
		}

		public static UIImage CameraFront
		{
			get
			{
				return Material.Icon.icon("ic_camera_front_white");
			}
		}

		public static UIImage CameraRear
		{
			get
			{
				return Material.Icon.icon("ic_camera_rear_white");
			}
		}

		public static UIImage Check
		{
			get
			{
				return Material.Icon.icon("ic_check_white");
			}
		}

		public static UIImage Clear
		{
			get
			{
				return Material.Icon.icon("ic_close_white");
			}
		}

		public static UIImage Close
		{
			get
			{
				return Material.Icon.icon("ic_close_white");
			}
		}

		public static UIImage Edit
		{
			get
			{
				return Material.Icon.icon("ic_edit_white");
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

		public static UIImage FavoriteBorder
		{
			get
			{
				return Material.Icon.icon("ic_favorite_border_white");
			}
		}

		public static UIImage FlashAuto
		{
			get
			{
				return Material.Icon.icon("ic_flash_auto_white");
			}
		}

		public static UIImage FlashOff
		{
			get
			{
				return Material.Icon.icon("ic_flash_off_white");
			}
		}

		public static UIImage FlashOn
		{
			get
			{
				return Material.Icon.icon("ic_flash_on_white");
			}
		}

		public static UIImage History
		{
			get
			{
				return Material.Icon.icon("ic_history_white");
			}
		}

		public static UIImage Home
		{
			get
			{
				return Material.Icon.icon("ic_home_white");
			}
		}

		public static UIImage Image
		{
			get
			{
				return Material.Icon.icon("ic_image_white");
			}
		}

		public static UIImage Menu
		{
			get
			{
				return Material.Icon.icon("ic_menu_white");
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

		public static UIImage Movie
		{
			get
			{
				return Material.Icon.icon("ic_movie_white");
			}
		}

		public static UIImage Pen
		{
			get
			{
				return Material.Icon.icon("ic_edit_white");
			}
		}

		public static UIImage Place
		{
			get
			{
				return Material.Icon.icon("ic_place_white");
			}
		}

		public static UIImage Phone
		{
			get
			{
				return Material.Icon.icon("ic_phone_white");
			}
		}

		public static UIImage PhotoCamera
		{
			get
			{
				return Material.Icon.icon("ic_phone_white");
			}
		}

		public static UIImage PhotoLibrary
		{
			get
			{
				return Material.Icon.icon("ic_phone_white");
			}
		}

		public static UIImage Search
		{
			get
			{
				return Material.Icon.icon("ic_phone_white");
			}
		}

		public static UIImage Settings
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

		public static UIImage Star
		{
			get
			{
				return Material.Icon.icon("cm_share_white");
			}
		}

		public static UIImage StarBorder
		{
			get
			{
				return Material.Icon.icon("cm_share_white");
			}
		}

		public static UIImage StarHalf
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

		public static UIImage Work
		{
			get
			{
				return Material.Icon.icon("cm_share_white");
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

			public static UIImage ArrowBack
			{
				get
				{
					return Material.Icon.icon("cm_arrow_back_white");
				}
			}

			public static UIImage ArrowDownward
			{
				get
				{
					return Material.Icon.icon("cm_arrow_downward_white");
				}
			}

			public static UIImage Audio
			{
				get
				{
					return Material.Icon.icon("cm_audio_white");
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

			public static UIImage Check
			{
				get
				{
					return Material.Icon.icon("cm_check_white");
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

			public static UIImage Edit
			{
				get
				{
					return Material.Icon.icon("cm_pen_white");
				}
			}

			public static UIImage Image
			{
				get
				{
					return Material.Icon.icon("cm_image_white");
				}
			}

			public static UIImage Menu
			{
				get
				{
					return Material.Icon.icon("cm_menu_white");
				}
			}

			public static UIImage Microphone
			{
				get
				{
					return Material.Icon.icon("cm_microphone_white");
				}
			}

			public static UIImage MoreHorizontal
			{
				get
				{
					return Material.Icon.icon("cm_more_horiz_white");
				}
			}

			public static UIImage MoreVertical
			{
				get
				{
					return Material.Icon.icon("cm_more_vert_white");
				}
			}

			public static UIImage Movie
			{
				get
				{
					return Material.Icon.icon("cm_movie_white");
				}
			}

			public static UIImage Pause
			{
				get
				{
					return Material.Icon.icon("cm_pause_white");
				}
			}

			public static UIImage Pen
			{
				get
				{
					return Material.Icon.icon("cm_pen_white");
				}
			}

			public static UIImage PhotoCamera
			{
				get
				{
					return Material.Icon.icon("cm_photo_camera_white");
				}
			}

			public static UIImage PhotoLibrary
			{
				get
				{
					return Material.Icon.icon("cm_photo_library_white");
				}
			}

			public static UIImage Play
			{
				get
				{
					return Material.Icon.icon("cm_play_white");
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

			public static UIImage Shuffle
			{
				get
				{
					return Material.Icon.icon("cm_shuffle_white");
				}
			}

			public static UIImage SkipBackward
			{
				get
				{
					return Material.Icon.icon("cm_skip_backward_white");
				}
			}

			public static UIImage SkipForward
			{
				get
				{
					return Material.Icon.icon("cm_skip_forward_white");
				}
			}

			public static UIImage Videocam
			{
				get
				{
					return Material.Icon.icon("cm_videocam_white");
				}
			}

			public static UIImage VolumeHigh
			{
				get
				{
					return Material.Icon.icon("cm_volume_high_white");
				}
			}

			public static UIImage VolumeMedium
			{
				get
				{
					return Material.Icon.icon("cm_volume_medium_white");
				}
			}

			public static UIImage VolumeOff
			{
				get
				{
					return Material.Icon.icon("cm_volume_off_white");
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
