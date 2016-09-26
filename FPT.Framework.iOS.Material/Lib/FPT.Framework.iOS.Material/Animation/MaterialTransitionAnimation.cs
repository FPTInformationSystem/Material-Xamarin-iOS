using System;
using Foundation;
using CoreAnimation;
namespace FPT.Framework.iOS.Material
{
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

	public static class MaterialAnimationTransition
	{
		public static readonly MaterialAnimationTransitionType Fade = CATransition.TransitionFade;
		public static readonly MaterialAnimationTransitionType MoveIn = CATransition.TransitionMoveIn;
		public static readonly MaterialAnimationTransitionType Push = CATransition.TransitionPush;
		public static readonly MaterialAnimationTransitionType Reveal = CATransition.TransitionReveal;
	}


	public class MaterialTransitionAnimation
	{
		public MaterialTransitionAnimation()
		{
		}
	}
}
