// MIT/X11 License
//
// NavigationDrawerController.cs
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
using System.Drawing;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace FPT.Framework.iOS.Material
{

	public enum NavigationDrawerPosition
	{
		Left, Right
	}

	public static partial class Extensions
	{
		public static NavigationDrawerController NavigationDrawerController(this UIViewController viewController)
		{
			while (viewController != null)
			{
				if (viewController is NavigationDrawerController)
				{
					return viewController as NavigationDrawerController;
				}
				viewController = viewController.ParentViewController;
			}

			return null;
		}
	}

	public abstract class NavigationDrawerControllerDelegate
	{
		public virtual void NavigationDrawerWillOpen(NavigationDrawerController navigationDrawerController, NavigationDrawerPosition position) { }

		public virtual void NavigationDrawerDidOpen(NavigationDrawerController navigationDrawerController, NavigationDrawerPosition position) { }

		public virtual void NavigationDrawerWillClose(NavigationDrawerController navigationDrawerController, NavigationDrawerPosition position) { }

		public virtual void NavigationDrawerDidClose(NavigationDrawerController navigationDrawerController, NavigationDrawerPosition position) { }

		//public virtual void NavigationDrawerDidBeginPanAt(NavigationDrawerController navigationDrawerController,Point didBeginPanAt, NavigationDrawerPosition position) { }
		
	}

	public class NavigationDrawerController : RootController, IUIGestureRecognizerDelegate
	{

		#region PROPERTIES

		internal UIPanGestureRecognizer LeftPanGesture { get; private set;}

		internal UIPanGestureRecognizer RightPanGesture { get; private set; }

		internal UITapGestureRecognizer LeftTapGesture { get; private set; }

		internal UITapGestureRecognizer RightTapGesture { get; private set; }

		public NavigationDrawerControllerDelegate Delegate { get; set; }

		public nfloat LeftThreshold { get; set; } = 64f;
		private nfloat leftViewThreshold { get; set; }

		public nfloat RightThreshold { get; set; } = 64f;
		private nfloat rightViewThreshold { get; set; }

		public double animationDuration { get; set; } = 0.25;

		private nfloat LeftViewWidth { get; set; }
		private nfloat RightViewWidth { get; set; }

		public bool IsOpend
		{
			get
			{
				return IsLeftViewOpened || IsRightViewOpened;
			}
		}

		private UIView LeftView { get; set; }
		private UIView RightView { get; set; }

		public bool IsLeftViewOpened
		{
			get
			{
				if (LeftView != null) return false;
				return LeftView.X() != LeftViewWidth;
			}

		}

		public bool IsRightViewOpened
		{
			get
			{
				if (RightView != null) return false;
				return RightView.X() != RightViewWidth;
			}

		}

		private UIViewController leftViewController { get; set;}

		private UIViewController rightViewController { get; set;}

		private bool mIsLeftViewEnabled = false;
		public bool IsLeftViewEnabled
		{
			get
			{
				return mIsLeftViewEnabled;
			}

			set
			{
				mIsLeftViewEnabled = value;

				IsLeftPanGestureEnabled = value;
				IsLeftTapGestureEnabled = value;
			}
		}

		private bool mIsLeftPanGestureEnabled = false;
		public bool IsLeftPanGestureEnabled
		{
			get
			{
				return mIsLeftPanGestureEnabled;
			}
			set
			{
				mIsLeftPanGestureEnabled = value;
				if (value)
				{
					PrepareLeftPanGesture();
				}
				else
				{
					RemoveLeftPanGesture();
				}
			}
		}

		private bool mIsRightTapGestureEnabled = false;
		public bool IsRightTapGestureEnabled
		{
			get
			{
				return mIsRightTapGestureEnabled;
			}
			set
			{
				mIsRightTapGestureEnabled = value;
				if (value)
				{
					PrepareRightTapGesture();
				}
				else
				{
					RemoveRightTapGesture();
				}
			}
		}

		private bool mIsRightViewEnabled = false;
		public bool IsRightViewEnabled
		{
			get
			{
				return mIsRightViewEnabled;
			}

			set
			{
				mIsRightViewEnabled = value;

				IsRightPanGestureEnabled = value;
				IsRightTapGestureEnabled = value;
			}
		}

		private bool mIsRightPanGestureEnabled = false;
		public bool IsRightPanGestureEnabled
		{
			get
			{
				return mIsRightPanGestureEnabled;
			}
			set
			{
				mIsRightPanGestureEnabled = value;
				if (value)
				{
					PrepareRightPanGesture();
				}
				else
				{
					RemoveRightPanGesture();
				}
			}
		}

		private bool mIsLeftTapGestureEnabled = false;
		public bool IsLeftTapGestureEnabled
		{
			get
			{
				return mIsLeftTapGestureEnabled;
			}
			set
			{
				mIsLeftTapGestureEnabled = value;
				if (value)
				{
					PrepareLeftTapGesture();
				}
				else
				{
					RemoveLeftTapGesture();
				}
			}
		}

		#endregion

		#region CONSTRUCTORS

		public NavigationDrawerController(NSCoder coder) : base(coder)
		{
			
		}

		public NavigationDrawerController(UIViewController rootViewContrller) : base (rootViewContrller)
		{
		}

		public override void Transition(UIViewController fromViewController, UIViewController toViewController, double duration, UIViewAnimationOptions options, Action animations, UICompletionHandler completionHandler)
		{
			base.Transition(fromViewController, toViewController, duration, options, animations, completionHandler);
		}

		#endregion

		#region FUNCTION

		internal void PrepareLeftPanGesture()
		{
			if (LeftPanGesture != null) return;
			LeftPanGesture = new UIPanGestureRecognizer(this, new Selector("HandleLeftViewPanGesture:"));
			LeftPanGesture.Delegate = this;
			View.AddGestureRecognizer(LeftPanGesture);
		}

		internal void RemoveLeftPanGesture()
		{
			var v = LeftPanGesture;
			if (v == null) return;
			View.RemoveGestureRecognizer(v);
			LeftPanGesture = null;
		}

		internal void PrepareLeftTapGesture()
		{
			if (LeftTapGesture != null) return;
			LeftTapGesture = new UITapGestureRecognizer(this, new Selector("HandleLeftViewPanGesture:"));
			LeftTapGesture.Delegate = this;
			View.AddGestureRecognizer(LeftPanGesture);
		}

		internal void RemoveLeftTapGesture()
		{
			var v = LeftTapGesture;
			if (v == null) return;
			View.RemoveGestureRecognizer(v);
			LeftTapGesture = null;
		}

		internal void RemoveLeftViewGesture()
		{
			RemoveLeftPanGesture();
			RemoveLeftTapGesture();
		}

		internal void PrepareRightTapGesture()
		{
			if (RightTapGesture != null) return;
			RightTapGesture = new UITapGestureRecognizer(this, new Selector("HandleLeftViewPanGesture:"));
			RightTapGesture.Delegate = this;
			View.AddGestureRecognizer(RightTapGesture);
		}

		internal void RemoveRightTapGesture()
		{
			var v = RightTapGesture;
			if (v == null) return;
			View.RemoveGestureRecognizer(v);
			RightTapGesture = null;
		}

		internal void PrepareRightPanGesture()
		{
			if (RightPanGesture != null) return;
			RightPanGesture = new UIPanGestureRecognizer(this, new Selector("HandleLeftViewPanGesture:"));
			RightPanGesture.Delegate = this;
			View.AddGestureRecognizer(RightPanGesture);
		}

		internal void RemoveRightPanGesture()
		{
			var v = RightPanGesture;
			if (v == null) return;
			View.RemoveGestureRecognizer(v);
			RightPanGesture = null;
		}

		internal void RemoveRightGesture()
		{
			RemoveRightPanGesture();
			RemoveRightTapGesture();
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			var v = LeftView;
			if (v != null)
			{
				v.SetWidth(LeftViewWidth);
				v.SetHeight(View.Bounds.Height);
				leftViewThreshold = LeftViewWidth / 2;
				var vc = leftViewController;
				if (vc != null)
				{
					vc.View.SetWidth(v.Width());
					vc.View.SetHeight(v.Height());
					vc.View.Center = new Point(x: int.Parse((v.Width() / 2).ToString()), y: int.Parse((v.Height() / 2).ToString()));

				}
			}

			v = RightView;
			if (v != null)
			{
				v.SetWidth(RightViewWidth);
				v.SetHeight(View.Bounds.Height);
				rightViewThreshold = View.Bounds.Width - RightViewWidth / 2;
				var vc = rightViewController;
				if (vc != null)
				{
					vc.View.SetWidth(v.Width());
					vc.View.SetHeight(v.Height());
					vc.View.Center = new Point(x: int.Parse((v.Width() / 2).ToString()), y: int.Parse((v.Height() / 2).ToString()));

				}
			}

		}

		public override void ViewWillTransitionToSize(CoreGraphics.CGSize toSize, IUIViewControllerTransitionCoordinator coordinator)
		{
			base.ViewWillTransitionToSize(toSize, coordinator);
			var v = RightView;
			if (v != null) return;
			v.SetPosition(new Point(x:int.Parse((toSize.Width + (IsRightViewOpened ? -v.Width() : v.Width()) / 2).ToString()),y:0));
		}

		public void SetLeftViewWidth(nfloat width, bool isHidden, bool animated, double duration = 0.5)
		{
			var v = LeftView;
			if (v != null) return;
			LeftViewWidth = width;
			var hide = isHidden;
			if (IsLeftViewOpened) hide = true;
			if (animated)
			{
				v.SetIsShadowPathAutoSizing(false);
				if (hide)
				{
					UIView.Animate(duration, () =>
					 {
						 var s = this;
						 var rect = v.Bounds;
						 rect.Width = width;
						 v.Bounds = rect;
						 v.SetX(int.Parse((-width / 2).ToString()));
						 s.RootViewController.View.Alpha = 1;
					 }, () =>
					  {
						  var s = this;
						  v.SetIsShadowPathAutoSizing(true);
						  s.LayoutSubviews();
						  s.HideView(v);
					  });
				}
				else
				{
					UIView.Animate(duration, () =>
					 {
						 var s = this;
						 var rect = v.Bounds;
						 rect.Width = width;
						 v.Bounds = rect;
						 v.SetX(int.Parse((width / 2).ToString()));
						 s.RootViewController.View.Alpha = (System.nfloat)0.5;
					 }, () =>
					  {
						  var s = this;
						  v.SetIsShadowPathAutoSizing(true);
						  s.LayoutSubviews();
						  s.HideView(v);
					  });
				}
			}
			else
			{
				var rect = v.Bounds;
				rect.Width = width;
				v.Bounds = rect;
				if (hide)
				{
					HideView(v);
					v.SetX(int.Parse((-v.Width() / 2).ToString()));
					RootViewController.View.Alpha = 1;
				}
				else
				{
					v.SetIsShadowPathAutoSizing(false);
					ShowView(v);
					v.SetX(int.Parse((width / 2).ToString()));
					RootViewController.View.Alpha = (System.nfloat)0.5;
					v.SetIsShadowPathAutoSizing(true);
				}
				LayoutSubviews();
			}

		}

		public void SetRightViewWidth(nfloat width, bool isHidden, bool animated, double duration = 0.5)
		{
			var v = RightView;
			if (v != null) return;
			RightViewWidth = width;
			var hide = isHidden;
			if (IsRightViewOpened) hide = true;
			if (animated)
			{
				v.SetIsShadowPathAutoSizing(false);
				if (hide)
				{
					UIView.Animate(duration, () =>
					 {
						 var s = this;
						 var rect = v.Bounds;
						 rect.Width = width;
						 v.Bounds = rect;
						 v.SetX(int.Parse((View.Bounds.Width + width / 2).ToString()));
						 s.RootViewController.View.Alpha = 1;
					 }, () =>
					  {
						  var s = this;
						  v.SetIsShadowPathAutoSizing(true);
						  s.LayoutSubviews();
						  s.HideView(v);
					  });
				}
				else
				{
					UIView.Animate(duration, () =>
					 {
						 var s = this;
						 var rect = v.Bounds;
						 rect.Width = width;
						 v.Bounds = rect;
						 v.SetX(int.Parse((View.Bounds.Width - width / 2).ToString()));
						 s.RootViewController.View.Alpha = (System.nfloat)0.5;
					 }, () =>
					  {
						  var s = this;
						  v.SetIsShadowPathAutoSizing(true);
						  s.LayoutSubviews();
						  s.HideView(v);
					  });
				}
			}
			else
			{
				var rect = v.Bounds;
				rect.Width = width;
				v.Bounds = rect;
				if (hide)
				{
					HideView(v);
					v.SetX(int.Parse((View.Bounds.Width + v.Width() / 2).ToString()));
					RootViewController.View.Alpha = 1;
				}
				else
				{
					v.SetIsShadowPathAutoSizing(false);
					ShowView(v);
					v.SetX(int.Parse((View.Bounds.Width - width / 2).ToString()));
					RootViewController.View.Alpha = (System.nfloat)0.5;
					v.SetIsShadowPathAutoSizing(true);
				}
				LayoutSubviews();
			}
		}

		public void ToggleLeftView(nfloat velocity)
		{
			if (IsLeftViewOpened)
				CloseLeftView(velocity);
			else 
				OpenLeftView(velocity);
 		}

		public void ToggleRightView(nfloat velocity)
		{
			if (IsRightViewOpened)
				CloseRightView(velocity);
			else
				OpenRightView(velocity);
		}

		//TODO:
		public void OpenLeftView(nfloat velocity)
		{
			if (!IsLeftViewEnabled) return;
			var v = LeftView;
			if (v != null) return;
			HideStatusBar();
			ShowView(v);
			UserInteractionEnabled = false;
			if (Delegate != null)
			{
				Delegate.NavigationDrawerWillOpen(this, NavigationDrawerPosition.Left);
			}
			double withDuration = 0 == velocity ? animationDuration : NMath.Max(0.1, NMath.Min(1,(v.X() / velocity)));
			UIView.Animate(withDuration,)
		}

		//TODO:
		public void OpenRightView(nfloat velocity = 0)
		{

		}

		//TODO:
		public void CloseLeftView(nfloat velocity = 0)
		{
		}


		//TODO:
		public void CloseRightView(nfloat velocity = 0)
		{
		}

		//TODO:
		internal void ShowStatusBar()
		{
		}

		//TODO:
		internal void HideStatusBar()
		{
		}

		//TODO:
		internal void ToggleStatusBar()
		{
		}


		//TODO:
		internal bool IsPointContainedWithinLeftThreshold(Point point)
		{
			return true;
		}

		//TODO:
		internal bool IsPointContainedWithinRightThreshold(Point point)
		{
			return true;
		}

		//TODO:
		internal bool IsPointContainedWithinView(Point point)
		{
			return true;
		}

		//TODO:
		internal void ShowView(UIView container)
		{
		}

		//TODO:
		internal void HideView(UIView container)
		{
		}

		//TODO:
		[Export("HandleLeftViewPanGesture:")]
		internal void HandleLeftViewPanGesture(UIPanGestureRecognizer recognizer)
		{ 
				//if (IsLeftViewEnabled && (Isle))
		}
		//fileprivate func handleLeftViewPanGesture(recognizer: UIPanGestureRecognizer)
		//{
		//	if isLeftViewEnabled && (isLeftViewOpened || !isRightViewOpened && isPointContainedWithinLeftThreshold(point: recognizer.location(in: view))) {
		//		guard let v = leftView else {
		//			return
	
		//	}

		//		let point = recognizer.location(in: view)
            
  //          // Animate the panel.
  //          switch recognizer.state {
		//			case .began:
		//				originalX = v.position.x

		//		showView(container: v)


		//		delegate?.navigationDrawerController ? (navigationDrawerController: self, didBeginPanAt: point, position: .left)
  //          case .changed:
		//				let w = v.width

		//		let translationX = recognizer.translation(in: v).x


		//		v.position.x = originalX + translationX > (w / 2) ? (w / 2) : originalX + translationX


		//		let a = 1 - v.position.x / v.width

		//		rootViewController.view.alpha = 0.5 < a && v.position.x <= v.width / 2 ? a : 0.5


		//		if translationX >= leftThreshold {
		//					hideStatusBar()

		//		}

		//				delegate?.navigationDrawerController ? (navigationDrawerController: self, didChangePanAt: point, position: .left)
  //          case .ended, .cancelled, .failed:
		//				let p = recognizer.velocity(in: recognizer.view)
  //              let x = p.x >= 1000 || p.x <= -1000 ? p.x : 0


		//		delegate?.navigationDrawerController ? (navigationDrawerController: self, didEndPanAt: point, position: .left)
                
  //              if v.x <= -leftViewWidth + leftViewThreshold || x < -1000 {
		//					closeLeftView(velocity: x)

		//		}
		//				else {
		//					openLeftView(velocity: x)
	  
		//		}
		//			case .possible:
		//				break

		//	}
		//	}
		//}


		#endregion
	}
}
