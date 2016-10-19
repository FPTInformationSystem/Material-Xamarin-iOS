using System;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;

namespace FPT.Framework.iOS.Material
{
	public static partial class Animation
	{
		public static CABasicAnimation BackgroundColor(UIColor color, double? duration = null)
		{
			var animation = CABasicAnimation.FromKeyPath("backgroundColor");
			animation.To = ObjCRuntime.Runtime.GetNSObject(color.CGColor.Handle);
			animation.FillMode = Convert.MaterialAnimationFillModeToValue(MaterialAnimationFillMode.Forwards);
			animation.RemovedOnCompletion = false;
			animation.TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut);
			if (duration != null)
			{
				animation.Duration = duration.Value;
			}
			return animation;
		}

		public static CABasicAnimation CornerRadius(float radius, double? duration = null)
		{
			var animation = CABasicAnimation.FromKeyPath("cornerRadius");
			animation.To = NSNumber.FromFloat(radius);
			animation.FillMode = Convert.MaterialAnimationFillModeToValue(MaterialAnimationFillMode.Forwards);
			animation.RemovedOnCompletion = false;
			animation.TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut);
			if (duration != null)
			{
				animation.Duration = duration.Value;
			}
			return animation;
		}

		public static CABasicAnimation Transform(CATransform3D transform, double? duration = null)
		{
			var animation = CABasicAnimation.FromKeyPath("transform");
			animation.To = NSValue.FromCATransform3D(transform);
			animation.FillMode = Convert.MaterialAnimationFillModeToValue(MaterialAnimationFillMode.Forwards);
			animation.RemovedOnCompletion = false;
			animation.TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut);
			if (duration != null)
			{
				animation.Duration = duration.Value;
			}
			return animation;
		}

		public static CABasicAnimation Rotate(nfloat? angle = null, nfloat? rotation = null, double? duration = null)
		{
			var animation = CABasicAnimation.FromKeyPath("transform.rotation");
			if (angle != null)
			{
				animation.To = NSNumber.FromDouble(Math.PI * angle.Value / 180.0);
			}
			else if (rotation != null) {
				animation.To = NSNumber.FromDouble(Math.PI * 2 * rotation.Value);
			}

			animation.FillMode = Convert.MaterialAnimationFillModeToValue(MaterialAnimationFillMode.Forwards);
			animation.RemovedOnCompletion = false;
			animation.TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut);
			if (duration != null)
				animation.Duration = duration.Value;
			return animation;
		}

		public static CABasicAnimation RotateX(nfloat? angle = null, nfloat? rotation = null, double? duration = null)
		{
			var animation = CABasicAnimation.FromKeyPath("transform.rotation.x");
			if (angle != null)
			{
				animation.To = NSNumber.FromDouble(Math.PI * angle.Value / 180.0);
			}
			else if (rotation != null)
			{
				animation.To = NSNumber.FromDouble(Math.PI * 2 * rotation.Value);
			}

			animation.FillMode = Convert.MaterialAnimationFillModeToValue(MaterialAnimationFillMode.Forwards);
			animation.RemovedOnCompletion = false;
			animation.TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut);
			if (duration != null)
				animation.Duration = duration.Value;
			return animation;
		}

		public static CABasicAnimation RotateY(nfloat? angle = null, nfloat? rotation = null, double? duration = null)
		{
			var animation = CABasicAnimation.FromKeyPath("transform.rotation.y");
			if (angle != null)
			{
				animation.To = NSNumber.FromDouble(Math.PI * angle.Value / 180.0);
			}
			else if (rotation != null)
			{
				animation.To = NSNumber.FromDouble(Math.PI * 2 * rotation.Value);
			}

			animation.FillMode = Convert.MaterialAnimationFillModeToValue(MaterialAnimationFillMode.Forwards);
			animation.RemovedOnCompletion = false;
			animation.TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut);
			if (duration != null)
				animation.Duration = duration.Value;
			return animation;
		}

		public static CABasicAnimation RotateZ(nfloat? angle = null, nfloat? rotation = null, double? duration = null)
		{
			var animation = CABasicAnimation.FromKeyPath("transform.rotation.z");
			if (angle != null)
			{
				animation.To = NSNumber.FromDouble(Math.PI * angle.Value / 180.0);
			}
			else if (rotation != null)
			{
				animation.To = NSNumber.FromDouble(Math.PI * 2 * rotation.Value);
			}

			animation.FillMode = Convert.MaterialAnimationFillModeToValue(MaterialAnimationFillMode.Forwards);
			animation.RemovedOnCompletion = false;
			animation.TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut);
			if (duration != null)
				animation.Duration = duration.Value;
			return animation;
		}

		public static CABasicAnimation Scale(nfloat? scale = null, double? duration = null)
		{
			var animation = CABasicAnimation.FromKeyPath("transform.scale");
			if (scale != null)
			{
				animation.To = NSNumber.FromNFloat(scale.Value);
			}

			animation.FillMode = Convert.MaterialAnimationFillModeToValue(MaterialAnimationFillMode.Forwards);
			animation.RemovedOnCompletion = false;
			animation.TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut);
			if (duration != null)
				animation.Duration = duration.Value;
			return animation;
		}

		public static CABasicAnimation ScaleX(nfloat? scale = null, double? duration = null)
		{
			var animation = CABasicAnimation.FromKeyPath("transform.scale.x");
			if (scale != null)
			{
				animation.To = NSNumber.FromNFloat(scale.Value);
			}

			animation.FillMode = Convert.MaterialAnimationFillModeToValue(MaterialAnimationFillMode.Forwards);
			animation.RemovedOnCompletion = false;
			animation.TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut);
			if (duration != null)
				animation.Duration = duration.Value;
			return animation;
		}

		public static CABasicAnimation ScaleY(nfloat? scale = null, double? duration = null)
		{
			var animation = CABasicAnimation.FromKeyPath("transform.scale.y");
			if (scale != null)
			{
				animation.To = NSNumber.FromNFloat(scale.Value);
			}

			animation.FillMode = Convert.MaterialAnimationFillModeToValue(MaterialAnimationFillMode.Forwards);
			animation.RemovedOnCompletion = false;
			animation.TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut);
			if (duration != null)
				animation.Duration = duration.Value;
			return animation;
		}

		public static CABasicAnimation ScaleZ(nfloat? scale = null, double? duration = null)
		{
			var animation = CABasicAnimation.FromKeyPath("transform.scale.z");
			if (scale != null)
			{
				animation.To = NSNumber.FromNFloat(scale.Value);
			}

			animation.FillMode = Convert.MaterialAnimationFillModeToValue(MaterialAnimationFillMode.Forwards);
			animation.RemovedOnCompletion = false;
			animation.TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut);
			if (duration != null)
				animation.Duration = duration.Value;
			return animation;
		}

		public static CABasicAnimation Translate(CGSize translation, double? duration = null)
		{
			var animation = CABasicAnimation.FromKeyPath("transform.translation");
			animation.To = NSValue.FromCGSize(translation);

			animation.FillMode = Convert.MaterialAnimationFillModeToValue(MaterialAnimationFillMode.Forwards);
			animation.RemovedOnCompletion = false;
			animation.TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut);
			if (duration != null)
				animation.Duration = duration.Value;
			return animation;
		}

		public static CABasicAnimation TranslateX(nfloat translation, double? duration = null)
		{
			var animation = CABasicAnimation.FromKeyPath("transform.translation.x");
			animation.To = NSNumber.FromNFloat(translation);

			animation.FillMode = Convert.MaterialAnimationFillModeToValue(MaterialAnimationFillMode.Forwards);
			animation.RemovedOnCompletion = false;
			animation.TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut);
			if (duration != null)
				animation.Duration = duration.Value;
			return animation;
		}

		public static CABasicAnimation TranslateY(nfloat translation, double? duration = null)
		{
			var animation = CABasicAnimation.FromKeyPath("transform.translation.y");
			animation.To = NSNumber.FromNFloat(translation);

			animation.FillMode = Convert.MaterialAnimationFillModeToValue(MaterialAnimationFillMode.Forwards);
			animation.RemovedOnCompletion = false;
			animation.TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut);
			if (duration != null)
				animation.Duration = duration.Value;
			return animation;
		}

		public static CABasicAnimation TranslateZ(nfloat translation, double? duration = null)
		{
			var animation = CABasicAnimation.FromKeyPath("transform.translation.z");
			animation.To = NSNumber.FromNFloat(translation);

			animation.FillMode = Convert.MaterialAnimationFillModeToValue(MaterialAnimationFillMode.Forwards);
			animation.RemovedOnCompletion = false;
			animation.TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut);
			if (duration != null)
				animation.Duration = duration.Value;
			return animation;
		}

		public static CABasicAnimation Position(CGPoint point, double? duration = null)
		{
			var animation = CABasicAnimation.FromKeyPath("position");
			animation.To = NSValue.FromCGPoint(point);

			animation.FillMode = Convert.MaterialAnimationFillModeToValue(MaterialAnimationFillMode.Forwards);
			animation.RemovedOnCompletion = false;
			animation.TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut);
			if (duration != null)
				animation.Duration = duration.Value;
			return animation;
		}

		public static CABasicAnimation ShadowPath(CGPath path, double? duration = null)
		{
			var animation = CABasicAnimation.FromKeyPath("shadowPath");
			animation.To = ObjCRuntime.Runtime.GetNSObject(path.Handle);

			animation.FillMode = Convert.MaterialAnimationFillModeToValue(MaterialAnimationFillMode.Forwards);
			animation.RemovedOnCompletion = false;
			animation.TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut);
			if (duration != null)
				animation.Duration = duration.Value;
			return animation;
		}
	}
}
