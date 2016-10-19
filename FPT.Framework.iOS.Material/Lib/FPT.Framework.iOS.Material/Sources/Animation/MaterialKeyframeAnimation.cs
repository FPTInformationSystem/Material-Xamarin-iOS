using System;
using Foundation;
using CoreAnimation;
using UIKit;

namespace FPT.Framework.iOS.Material
{
	public static partial class Convert
	{
		public static string MaterialAnimationRotationModeToValue(MaterialAnimationRotationMode mode)
		{
			switch (mode)
			{
				case MaterialAnimationRotationMode.None:
					return null;
				case MaterialAnimationRotationMode.Auto:
					return CAAnimation.RotateModeAuto;
				case MaterialAnimationRotationMode.AutoReverse:
					return CAAnimation.RotateModeAutoReverse;
				default:
					return null;
			}
		}
	}

	public enum MaterialAnimationRotationMode
	{
		None, Auto, AutoReverse
	}

	public static partial class Animation
	{
		public static CAKeyFrameAnimation Path(UIBezierPath bezierPath, MaterialAnimationRotationMode mode = MaterialAnimationRotationMode.Auto, double? duration = null)
		{
			var animation = CAKeyFrameAnimation.FromKeyPath("position");
			animation.Path = bezierPath.CGPath;

			animation.RotationMode = Convert.MaterialAnimationRotationModeToValue(mode);
			if (duration != null)
				animation.Duration = duration.Value;
			return animation;
		}
	}
}
