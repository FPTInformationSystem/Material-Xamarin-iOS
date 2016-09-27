using System;
using Foundation;
using CoreAnimation;
namespace FPT.Framework.iOS.Material
{
	//optional func materialAnimationDidStart(animation: CAAnimation)

	//optional func materialAnimationDidStop(animation: CAAnimation, finished flag: Bool)

	public partial class Convert
	{
		public static MaterialAnimationFillModeType MaterialAnimationFillModeToValue(MaterialAnimationFillMode mode)
		{
			switch (mode)
			{
				case MaterialAnimationFillMode.Forwards:
					return CAFillMode.Forwards;
				case MaterialAnimationFillMode.Backwards:
					return CAFillMode.Backwards;
				case MaterialAnimationFillMode.Both:
					return CAFillMode.Both;
				case MaterialAnimationFillMode.Removed:
					return CAFillMode.Removed;
				default:
					return default(MaterialAnimationFillModeType);
			}
		}
	}

	public abstract class MaterialAnimationDelegate : MaterialDelegate
	{
		public virtual void materialAnimationDidStart(CAAnimation animation) { }
		public virtual void materialAnimationDidStop(CAAnimation animation, bool finished) { }
	}

	public class MaterialAnimationFillModeType
	{
		private NSString Value = NSString.Empty;
		public static implicit operator NSString(MaterialAnimationFillModeType ts)
		{
			return ((ts == null) ? null : ts.Value);
		}
		public static implicit operator MaterialAnimationFillModeType(NSString val)
		{
			return new MaterialAnimationFillModeType { Value = val };
		}

		public static implicit operator string(MaterialAnimationFillModeType ts)
		{
			return ((ts == null) ? null : ts.ToString());
		}
	}

	public enum MaterialAnimationFillMode
	{
		Forwards, Backwards, Both, Removed
	}

	public delegate void MaterialAnimationDelayCancelBlock(bool cancel);

	public static partial class MaterialAnimation
	{
		public static void Delay(double time, Action completion)
		{
			
		}

		public static void DelayCancel(MaterialAnimationDelayCancelBlock completion)
		{
			if (completion != null)
				completion(true);
		}

		public static void AnimationDisabled(Action animations)
		{
			AnimateWithDuration(0, animations);
		}

		public static void AnimateWithDuration(double duration, Action animations, Action completion = null)
		{
			CATransaction.Begin();
			CATransaction.AnimationDuration = duration;
			CATransaction.CompletionBlock = completion;
			CATransaction.AnimationTimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut);
			animations();
			CATransaction.Commit();
		}

		public static CAAnimationGroup AnimationGroup(CAAnimation[] animations, double? duration = 0.5)
		{
			var group = new CAAnimationGroup();
			group.FillMode = Convert.MaterialAnimationFillModeToValue(MaterialAnimationFillMode.Forwards);
			group.RemovedOnCompletion = false;
			group.Animations = animations;
			if (duration != null)
			{
				group.Duration = duration.Value;
			}
			group.TimingFunction = CAMediaTimingFunction.FromName(CAMediaTimingFunction.EaseInEaseOut);
			return group;
		}

		public static void AnimateWithDelay(double delay, double duration, Action animations, Action completion)
		{
			Delay(delay, () =>
			{
				AnimateWithDuration(duration, animations, completion);
			});
		}
	}
}
