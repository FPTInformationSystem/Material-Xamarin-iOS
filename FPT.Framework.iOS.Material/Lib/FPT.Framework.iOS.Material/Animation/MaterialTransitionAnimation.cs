using System;
using Foundation;
using CoreAnimation;
namespace FPT.Framework.iOS.Material
{
	public static partial class Convert
	{
		public static MaterialAnimationTransitionType MaterialAnimationTransitionToValue(MaterialAnimationTransition transition)
		{
			switch (transition) {
				case MaterialAnimationTransition.Fade:
					return CATransition.TransitionFade;
				case MaterialAnimationTransition.MoveIn:
					return CATransition.TransitionMoveIn;
				case MaterialAnimationTransition.Push:
					return CATransition.TransitionPush;
				case MaterialAnimationTransition.Reveal:
					return CATransition.TransitionReveal;
				default:
					return default(MaterialAnimationTransitionType);
			}
		}

		public static MaterialAnimationTransitionSubTypeType MaterialAnimationTransitionSubTypeToValue(MaterialAnimationTransitionSubType direction)
		{
			switch (direction)
			{
				case MaterialAnimationTransitionSubType.Right:
					return CATransition.TransitionFromRight;
				case MaterialAnimationTransitionSubType.Left:
					return CATransition.TransitionFromLeft;
				case MaterialAnimationTransitionSubType.Top:
					return CATransition.TransitionFromTop;
				case MaterialAnimationTransitionSubType.Bottom:
					return CATransition.TransitionFromBottom;
				default:
					return default(MaterialAnimationTransitionSubTypeType);
			}
		}
	}

	public class MaterialAnimationTransitionType
	{
		private NSString Value = NSString.Empty;
		public static implicit operator NSString(MaterialAnimationTransitionType ts)
		{
			return ((ts == null) ? null : ts.Value);
		}
		public static implicit operator MaterialAnimationTransitionType(NSString val)
		{
			return new MaterialAnimationTransitionType { Value = val };
		}

		public static implicit operator string(MaterialAnimationTransitionType ts)
		{
			return ((ts == null) ? null : ts.ToString());
		}
	}

	public class MaterialAnimationTransitionSubTypeType
	{
		private NSString Value = NSString.Empty;
		public static implicit operator NSString(MaterialAnimationTransitionSubTypeType ts)
		{
			return ((ts == null) ? null : ts.Value);
		}
		public static implicit operator MaterialAnimationTransitionSubTypeType(NSString val)
		{
			return new MaterialAnimationTransitionSubTypeType { Value = val };
		}

		public static implicit operator string(MaterialAnimationTransitionSubTypeType ts)
		{
			return ((ts == null) ? null : ts.ToString());
		}
	}

	public enum MaterialAnimationTransition
	{
		Fade, MoveIn, Push, Reveal
	}

	public enum MaterialAnimationTransitionSubType
	{
		Right, Left, Top, Bottom
	}


	public partial class MaterialAnimation
	{
		public static CATransition Transition(MaterialAnimationTransition type, MaterialAnimationTransitionSubType? direction = null, double? duration = null)
		{
			var animation = new CATransition();
			animation.Type = Convert.MaterialAnimationTransitionToValue(type);
			if (direction != null)
			{
				animation.Subtype = Convert.MaterialAnimationTransitionSubTypeToValue(direction.Value);
			}
			if (duration != null)
			{
				animation.Duration = duration.Value;
			}
			return animation;
		}
	}
}
