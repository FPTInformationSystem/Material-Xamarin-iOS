// MIT/X11 License
//
// PageTabBarController.cs
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
using System.Collections.Generic;
using CoreAnimation;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace FPT.Framework.iOS.Material
{

	public class PageTabBarItem : FlatButton
	{
		public override void Prepare()
		{
			base.Prepare();
			PulseAnimation = PulseAnimation.None;
		}
	}

	public class PageTabBar : TabBar
	{
		public override void Prepare()
		{
			base.Prepare();
			IsLineAnimated = false;
			LineAlignment = TabBarLineAlignment.Top;
		}
	}

	public enum PageTabBarAlignment
	{
		Top, Bottom
	}

	public partial class Extensions
	{

		static NSObject sPageTabBarItemKey = new NSObject();
		public static PageTabBarItem PageTabBarItem(this UIViewController viewController)
		{
			var v = MaterialObjC.AssociatedObject(viewController.Handle, sPageTabBarItemKey.Handle, () =>
			{
				return new PageTabBarItem().Handle;
			});

			return ObjCRuntime.Runtime.GetNSObject(v) as PageTabBarItem;

		}

		public static void SetPageTabBarItem(this CALayer layer, PageTabBarItem value)
		{
			MaterialObjC.MaterialAssociatedObject(layer.Handle, sPageTabBarItemKey.Handle, value.Handle);

		}
	}

	public static partial class Extensions
	{
		public static PageTabBarController PageTabBarController(this UIViewController viewController)
		{
			while (viewController != null)
			{
				if (viewController is PageTabBarController)
				{
					return viewController as PageTabBarController;
				}
				viewController = viewController.ParentViewController;
			}

			return null;
		}
	}

	public class PageTabBarControllerDelegate
	{
		public virtual void DidTransitionTo(PageTabBarController pageTabBarController, UIViewController viewController) { }
	}

	public class PageTabBarController : RootController, IUIPageViewControllerDelegate, IUIPageViewControllerDataSource, IUIScrollViewDelegate
	{

		#region PROPERTOES

		public PageTabBar PageTabBar { get; private set; } = new PageTabBar();

		public bool IsTabSelectedAnimation { get; set; } = false;

		public int SelectedIndex { get; set; } = 0;

		public PageTabBarAlignment PageTabBarAlignment { get; set; } = PageTabBarAlignment.Bottom;

		public PageTabBarControllerDelegate Delegate;

		public UIPageViewController PageViewController
		{
			get
			{
				return RootViewController as UIPageViewController;
			}
		}

		public List<UIViewController> ViewControllers = new List<UIViewController>();

		#endregion

		public PageTabBarController(NSCoder coder) : base(coder)
		{
			Prepare();
		}

		#region CONSTRUCTORS

		public PageTabBarController(UIViewController rootViewController)			: base(new UIPageViewController(UIPageViewControllerTransitionStyle.Scroll, UIPageViewControllerNavigationOrientation.Horizontal))
		{
			ViewControllers.Add(rootViewController);
			SetViewControllers(ViewControllers.ToArray(), UIPageViewControllerNavigationDirection.Forward, true);
			Prepare();
		}

		public PageTabBarController(UIViewController[] viewControllers, int selectedIndex)
			: base(new UIPageViewController(UIPageViewControllerTransitionStyle.Scroll, UIPageViewControllerNavigationOrientation.Horizontal))
		{
			this.SelectedIndex = selectedIndex;
			ViewControllers.AddRange(viewControllers);
			SetViewControllers(new UIViewController[] { this.ViewControllers[selectedIndex]}, UIPageViewControllerNavigationDirection.Forward, true);
			Prepare();
		}

		#endregion

		#region FUNCTIONS

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			var p = PageTabBar.IntrinsicContentSize.Height + PageTabBar.LayoutEdgeInsets().Top + PageTabBar.LayoutEdgeInsets().Bottom;
			var y = View.Height() - p;

			PageTabBar.SetHeight(p);
			PageTabBar.SetWidth(View.Width() + PageTabBar.LayoutEdgeInsets().Left + PageTabBar.LayoutEdgeInsets().Right);

			RootViewController.View.SetHeight(y);

			switch (PageTabBarAlignment)
			{
				case PageTabBarAlignment.Top:
					{
						PageTabBar.SetY(0);
						RootViewController.View.SetY(p);
					}
					break;
				case PageTabBarAlignment.Bottom:
					{
						PageTabBar.SetY(y);
						RootViewController.View.SetY(0);
					}
					break;
			}
		}

		public void SetViewControllers(UIViewController[] viewControllers, UIPageViewControllerNavigationDirection direction, bool animated, UICompletionHandler completion = null)
		{
			if (PageViewController != null)
			{
				PageViewController.SetViewControllers(viewControllers, direction, animated, completion);
			}
			Prepare();
		}

		public override void Prepare()
		{
			base.Prepare();
			preparePageTabBar();
			PreparePageTabBarItems();
		}

		internal override void PrepareRootViewController()
		{
			base.PrepareRootViewController();

			var v = PageViewController;

			if (v == null) return;

			v.Delegate = this;
			v.DataSource = this;
			v.DoubleSided = false;

			foreach (var view in v.View.Subviews)
			{
				if (view is UIScrollView)
				{
					((UIScrollView)view).Delegate = this;
				}
			}
		}

		public void PreparePageTabBarItems()
		{
			//C# does not need to clear
			//PageTabBar.Buttons.Clear();
			var buttons = new List<UIButton>();
			foreach (var x in ViewControllers)
			{
				var button = x.PageTabBarItem() as UIButton;
				buttons.Add(button);
				button.RemoveTarget(this, new Selector("handleButton:"), UIControlEvent.TouchUpInside);
				button.RemoveTarget(this, new Selector("handlePageTabBarButton:"), UIControlEvent.TouchUpInside);
				button.AddTarget(this, new Selector("handlePageTabBarButton:"), UIControlEvent.TouchUpInside);
			}

			PageTabBar.Buttons = buttons;
		}

		[Export("handlePageTabBarButton:")]
		internal void HandlePageTabBarButton(UIButton button)
		{
			var index = PageTabBar.Buttons.IndexOf(button);

			if (index < 0 || index == SelectedIndex) return;

			var direction = index < SelectedIndex ? UIPageViewControllerNavigationDirection.Reverse : UIPageViewControllerNavigationDirection.Forward;

			IsTabSelectedAnimation = true;
			SelectedIndex = index;

			PageTabBar.Select(SelectedIndex);

			SetViewControllers(new UIViewController[] { ViewControllers[index] }, direction, true, (finished) =>
			{
				var s = this;
				s.IsTabSelectedAnimation = false;
				if (s.Delegate != null)
				{
					s.Delegate.DidTransitionTo(s, s.ViewControllers[s.SelectedIndex]);
				}
			});
		}

		private void preparePageTabBar()
		{
			PageTabBar.SetZPosition(1000);
			PageTabBar.SetDividerColor(Color.Grey.Lighten3);
			View.AddSubview(PageTabBar);
			PageTabBar.Select(SelectedIndex);
		}

		[Export("pageViewController:didFinishAnimating:previousViewControllers:transitionCompleted:")]
		public void DidFinishAnimating(UIPageViewController pageViewController, bool finished, UIViewController[] previousViewControllers, bool completed)
		{
			try
			{
				UIViewController v = pageViewController.ViewControllers[0];
				var index = ViewControllers.IndexOf(v);

				if (index < 0) return;
				SelectedIndex = index;
				PageTabBar.Select(SelectedIndex);

				if (finished && completed)
				{
					if (Delegate != null)
					{
						Delegate.DidTransitionTo(this, v);
					}
				}
			}
			catch (Exception)
			{
				return;
			}
		}

		public UIViewController GetPreviousViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
		{
			var current = ViewControllers.IndexOf(referenceViewController);

			if (current < 0) return null;

			var previous = current - 1;

			if (previous >= 0)
			{
				return ViewControllers[previous];
			}
			else
			{
				return null;
			}
		}

		public UIViewController GetNextViewController(UIPageViewController pageViewController, UIViewController referenceViewController)
		{
			var current = ViewControllers.IndexOf(referenceViewController);

			if (current < 0) return null;

			var next = current + 1;

			if (ViewControllers.Count > next)
			{
				return ViewControllers[next];
			}
			else
			{
				return null;
			}
		}

		[Export("scrollViewDidScroll:")]
		public void Scrolled(UIScrollView scrollView)
		{
			if (PageTabBar.IsAnimating || IsTabSelectedAnimation || PageTabBar.Selected == null || 0 < View.Width())
			{
				return;
			}

			var x = (scrollView.ContentOffset.X - View.Width()) / scrollView.ContentSize.Width * View.Width();

			var point = PageTabBar.Line.Center;
			point.X = PageTabBar.Selected.Center.X + x;
			PageTabBar.Line.Center = point;
		}

		#endregion
	}
}
