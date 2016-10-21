using System;
using UIKit;
using CoreGraphics;

namespace FPT.Framework.iOS.Material
{

	public enum MaterialDeviceType
	{
		iPad, iPhone, TV, Unspecified
	}

	public static class Device
	{

		public static string Model
		{
			get
			{
				return UIDevice.CurrentDevice.Model;
			}
		}

		public static MaterialDeviceType Type
		{
			get
			{
				switch (UIDevice.CurrentDevice.UserInterfaceIdiom)
				{
					case UIUserInterfaceIdiom.Pad:
						return MaterialDeviceType.iPad;
					case UIUserInterfaceIdiom.Phone:
						return MaterialDeviceType.iPhone;
					case UIUserInterfaceIdiom.TV:
						return MaterialDeviceType.TV;
					default:
						return MaterialDeviceType.Unspecified;
				}
			}
		}

		public static UIUserInterfaceIdiom UserInterfaceIdiom
		{
			get
			{
				return UIDevice.CurrentDevice.UserInterfaceIdiom;
			}
		}

		public static bool IsLandscape
		{
			get
			{
				return UIApplication.SharedApplication.StatusBarOrientation.IsLandscape();
			}
		}

		public static bool IsPortrait
		{
			get
			{
				return UIApplication.SharedApplication.StatusBarOrientation.IsPortrait();
			}
		}

		public static UIInterfaceOrientation Orientation
		{
			get
			{
				return UIApplication.SharedApplication.StatusBarOrientation;
			}
		}

		public static UIStatusBarStyle StatusBarStyle
		{
			get
			{
				return UIApplication.SharedApplication.StatusBarStyle;
			}
			set
			{
				UIApplication.SharedApplication.StatusBarStyle = value;
			}
		}

		public static bool StatusBarHidden
		{
			get
			{
				return UIApplication.SharedApplication.StatusBarHidden;
			}
			set
			{
				UIApplication.SharedApplication.StatusBarHidden = value;
			}
		}

		public static CGRect Bounds
		{
			get
			{
				return UIScreen.MainScreen.Bounds;
			}
		}

		public static nfloat Width
		{
			get
			{
				return Bounds.Width;
			}
		}

		public static nfloat Height
		{
			get
			{
				return Bounds.Height;
			}
		}

		public static nfloat Scale
		{
			get
			{
				return UIScreen.MainScreen.Scale;
			}
		}
	}
}
