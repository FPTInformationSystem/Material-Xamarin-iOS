// MIT/X11 License
//
// BottomNavigationController.cs
//
// Author:
//       Pham Quan <QuanP@fpt.com.vn, mr.pquan@gmail.com> at FPT Software Service Center.
//
// Copyright (c) 2016 FPT Information System.
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using UIKit;
using CoreFoundation;
using CoreGraphics;
using CoreAnimation;
using Foundation;
using ObjCRuntime;

namespace FPT.Framework.iOS.Material
{

	public class BottomNavigationFadeAnimatedTransitioning : NSObject, IUIViewControllerAnimatedTransitioning
	{
		public BottomNavigationFadeAnimatedTransitioning()
		{
		}

		public void AnimateTransition(IUIViewControllerContextTransitioning transitionContext)
		{
			var fromView = transitionContext.GetViewFor(UITransitionContext.FromViewKey);
			var toView = transitionContext.GetViewFor(UITransitionContext.ToViewKey);

			toView.Alpha = 0;

			transitionContext.ContainerView.AddSubview(fromView);
			transitionContext.ContainerView.AddSubview(toView);

			UIView.Animate(TransitionDuration(transitionContext), () =>
			{
				toView.Alpha = 1;
				fromView.Alpha = 0;
			}, () =>
			{
				transitionContext.CompleteTransition(true);
			});
		}

		public double TransitionDuration(IUIViewControllerContextTransitioning transitionContext)
		{
			return 0.35;
		}
	}

	public enum BottomNavigationTransitionAnimation
	{
		None, Fade
	}

	public class BottomNavigationController : UITabBarController
	{

		#region PROPERTIES

		public BottomNavigationTransitionAnimation TransitionAnimation { get; set; } = BottomNavigationTransitionAnimation.Fade;

		#endregion

		#region CONSTRUCTORS

		public BottomNavigationController(NSCoder coder) : base(coder) { }

		public BottomNavigationController(string nibName, NSBundle bundle) : base(nibName, bundle) { }

		public BottomNavigationController() : base() { }

		public BottomNavigationController(UIViewController[] viewControllers) : base()
		{
			this.ViewControllers = viewControllers;
		}

		#endregion

		#region FUNCTIONS

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			Prepare();
		}

		public override void ViewWillLayoutSubviews()
		{
			base.ViewWillLayoutSubviews();
			LayoutSubviews();
		}

		void LayoutSubviews()
		{
			if (TabBar.Items != null)
			{
				foreach (var item in TabBar.Items)
				{
					if (Device.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
					{
						if (item.Title == null)
						{
							nfloat inset = 7f;
							item.ImageInsets = new UIEdgeInsets(inset, 0, -inset, 0);
						}
						else
						{
							nfloat inset = 6f;
							item.ImageInsets = new UIEdgeInsets(inset, 0, -inset, 0);
							var offset = item.TitlePositionAdjustment;
							offset.Vertical = -inset;
							item.TitlePositionAdjustment = offset;
						}
					}
					else if (item.Title == null)
					{
						nfloat inset = 9f;
						item.ImageInsets = new UIEdgeInsets(inset, 0, -inset, 0);
					}
					else
					{
						nfloat inset = 3f;
						item.ImageInsets = new UIEdgeInsets(inset, 0, -inset, 0);
						var offset = item.TitlePositionAdjustment;
						offset.Vertical = -inset;
						item.TitlePositionAdjustment = offset;
					}
				}
			}

			TabBar.Divider().Reload();
		}

		public virtual void Prepare()
		{
			View.ClipsToBounds = true;
			View.ContentScaleFactor = Device.Scale;
			View.BackgroundColor = Color.White;

			this.GetAnimationControllerForTransition += Handle_GetAnimationControllerForTransition;

			prepareTabBar();
		}

		IUIViewControllerAnimatedTransitioning Handle_GetAnimationControllerForTransition(UITabBarController tabBarController, UIViewController fromVC, UIViewController toVC)
		{
			if (fromVC == null || toVC == null) return null;

			return TransitionAnimation == BottomNavigationTransitionAnimation.Fade ? new BottomNavigationFadeAnimatedTransitioning() : null;
		}

		private void prepareTabBar()
		{
			TabBar.SetHeightPreset(HeightPreset.Normal);
			TabBar.SetDepthPreset(DepthPreset.Depth1);
			TabBar.SetDividerAlignment(DividerAlignment.Top);
			var image = Extensions.ImageWithColor(Color.Clear, new CGSize(1, 1));
			TabBar.ShadowImage = image;
			TabBar.BackgroundImage = image;
			TabBar.BackgroundColor = Color.White;
		}

		#endregion
	}
}
