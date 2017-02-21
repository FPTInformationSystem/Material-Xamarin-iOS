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
using CoreFoundation;
using CoreGraphics;
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

		public virtual void NavigationDrawerDidBeginPanAt(NavigationDrawerController navigationDrawerController, CGPoint point, NavigationDrawerPosition position) { }

		public virtual void NavigationDrawerDidChangePanAt(NavigationDrawerController navigationDrawerController, CGPoint point, NavigationDrawerPosition position) { }

		public virtual void NavigationDrawerDidEndPanAt(NavigationDrawerController navigationDrawerController, CGPoint point, NavigationDrawerPosition position) { }

		public virtual void NavigationDrawerDidTapPanAt(NavigationDrawerController navigationDrawerController, CGPoint point, NavigationDrawerPosition position) { }

		public virtual void NavigationDrawerStatusBar(NavigationDrawerController navigationDrawerController, bool statusBar) { }

	}

	public partial class NavigationDrawerController : RootController, IUIGestureRecognizerDelegate
	{

		#region PROPERTIES

		internal nfloat OriginalX = 0f;

		internal UIPanGestureRecognizer LeftPanGesture { get; private set; }

		internal UIPanGestureRecognizer RightPanGesture { get; private set; }

		internal UITapGestureRecognizer LeftTapGesture { get; private set; }

		internal UITapGestureRecognizer RightTapGesture { get; private set; }

		public NavigationDrawerControllerDelegate Delegate { get; set; }

		public nfloat LeftThreshold { get; set; } = 64f;
		private nfloat leftViewThreshold { get; set; }

		public nfloat RightThreshold { get; set; } = 64f;
		private nfloat rightViewThreshold { get; set; }

		public double animationDuration { get; set; } = 0.25;


		public bool IsEnabled
		{
			get
			{
				return IsLeftViewEnabled || IsRightViewEnabled;
			}
			set
			{
				if (LeftView != null)
				{
					IsLeftViewEnabled = value;
				}

				if (RightView != null)
				{
					IsRightViewEnabled = value;
				}
			}
		}

		public bool IsOpend
		{
			get
			{
				return IsLeftViewOpened || IsRightViewOpened;
			}
		}

		public DepthPreset depthPreset = DepthPreset.Depth1;

		private UIView LeftView { get; set; }
		private UIView RightView { get; set; }

		public bool IsLeftViewOpened
		{
			get
			{
				if (LeftView == null) return false;
				return LeftView.X() != -LeftViewWidth;
			}

		}

		public bool IsRightViewOpened
		{
			get
			{
				if (RightView == null) return false;
				return RightView.X() != Screen.Width;
			}

		}

		private UIViewController LeftViewController { get; set; }

		private UIViewController RightViewController { get; set; }

		private UIViewController ContentViewController { get; set; } = new UIViewController();

		private nfloat LeftViewWidth { get; set; }

		private nfloat RightViewWidth { get; set; }

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

		public bool IsHiddenStatusBarEnabled = true;

		#endregion

		#region CONSTRUCTORS

		public NavigationDrawerController(NSCoder coder) : base(coder)
		{
			
			Prepare();
		}

		public NavigationDrawerController(UIViewController rootViewContrller) : base(rootViewContrller)
		{
			Prepare();
		}

		public NavigationDrawerController(UIViewController rootViewContrller, UIViewController leftViewController = null, UIViewController rightViewController = null) : base(rootViewContrller)
		{
			//this.RootViewController = rootViewContrller;
			this.LeftViewController = leftViewController;
			this.RightViewController = rightViewController;
			Prepare();
		}

		#endregion

		#region FUNCTION

		#region OVERRIDE FUNCTION

		public override void Transition(UIViewController fromViewController, UIViewController toViewController, double duration, UIViewAnimationOptions options, Action animations, UICompletionHandler completionHandler)
		{
			base.Transition(fromViewController, toViewController, duration, options, animations, (finished) =>
			{
				var s = this;
				if (s == null) return;

				s.View.SendSubviewToBack(s.ContentViewController.View);
				if (completionHandler != null) completionHandler(finished);
			});
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			//ToggleStatusBar();

			var vl = LeftView;
			if (vl != null)
			{
				vl.SetWidth(LeftViewWidth);
				vl.SetHeight(View.Bounds.Height);
				leftViewThreshold = LeftViewWidth / 2;
				var vc = LeftViewController;
				if (vc != null)
				{
					vc.View.SetWidth(vl.Width());
					vc.View.SetHeight(vl.Height());
					vc.View.Center = new CGPoint(x:vl.Width() / 2,y:vl.Height() / 2);

				}
			}

			var v = RightView;
			if (v != null)
			{
				v.SetWidth(RightViewWidth);
				v.SetHeight(View.Bounds.Height);
				rightViewThreshold = View.Bounds.Width - RightViewWidth / 2;
				var vc = RightViewController;
				if (vc != null)
				{
					vc.View.SetWidth(v.Width());
					vc.View.SetHeight(v.Height());
					vc.View.Center = new CGPoint(v.Width() / 2, v.Height() / 2);

				}
			}
		}

		public override void ViewWillTransitionToSize(CGSize size, IUIViewControllerTransitionCoordinator coordinator)
		{
			base.ViewWillTransitionToSize(size, coordinator);
			var v = RightView;
			if (v == null) return;
			var position = v.Position();
			position.X = size.Width + (IsRightViewOpened ? -v.Width() : v.Width()) / 2;
			v.SetPosition(position);
		}

		public override void Prepare()
		{
			base.Prepare();
			PrepareContentViewController();
			PrepareLeftView();
			PrepareRightView();
			
		}

		#endregion

		#region OTHER FUNCTION

		public void SetLeftViewWidth(nfloat width, bool isHidden, bool animated, double duration = 0.5)
		{
			var v = LeftView;
			if (v == null) return;
			LeftViewWidth = width;
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
						 var position = v.Position();
						 position.X = -width / 2;
						 v.SetPosition(position);
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
						 var position = v.Position();
						 position.X = width / 2;
						 v.SetPosition(position);
						 s.RootViewController.View.Alpha = 0.5f;
					 }, () =>
					  {
						  var s = this;
						  v.SetIsShadowPathAutoSizing(true);
						  s.LayoutSubviews();
						s.ShowView(v);
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
					var position = v.Position();
					position.X = -v.Width() / 2;
					v.SetPosition(position);
					RootViewController.View.Alpha = 1;
				}
				else
				{
					v.SetIsShadowPathAutoSizing(false);
					ShowView(v);
					var position = v.Position();
					position.X = v.Width() / 2;
					v.SetPosition(position);
					RootViewController.View.Alpha = 0.5f;
					v.SetIsShadowPathAutoSizing(true);
				}
				LayoutSubviews();
			}

		}

		public void SetRightViewWidth(nfloat width, bool isHidden, bool animated, double duration = 0.5)
		{
			var v = RightView;
			if (v == null) return;
			RightViewWidth = width;
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
						 var position = v.Position();
						 position.X = s.View.Bounds.Width + width / 2;
						 v.SetPosition(position);
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
						var position = v.Position();
						position.X = s.View.Bounds.Width - width / 2;
						v.SetPosition(position);
						s.RootViewController.View.Alpha = 0.5f;
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
					var position = v.Position();
					position.X = View.Bounds.Width + v.Width() / 2;
					v.SetPosition(position);
					RootViewController.View.Alpha = 1;
				}
				else
				{
					v.SetIsShadowPathAutoSizing(false);
					ShowView(v);
					var position = v.Position();
					position.X = View.Bounds.Width - width / 2;
					v.SetPosition(position);
					RootViewController.View.Alpha = 0.5f;
					v.SetIsShadowPathAutoSizing(true);
				}
				LayoutSubviews();
			}
		}

		public void ToggleLeftView(nfloat velocity = default(nfloat))
		{
			if (IsLeftViewOpened)
				CloseLeftView(velocity);
			else
				OpenLeftView(velocity);
		}

		public void ToggleRightView(nfloat velocity = default(nfloat))
		{
			if (IsRightViewOpened)
				CloseRightView(velocity);
			else
				OpenRightView(velocity);
		}

		public void OpenLeftView(nfloat velocity = default(nfloat))
		{
			if (!IsLeftViewEnabled) return;
			var v = LeftView;
			if (v == null) return;
			//HideStatusBar();
			ShowView(v);
			UserInteractionEnabled = false;
			if (Delegate != null)
			{
				Delegate.NavigationDrawerWillOpen(this, NavigationDrawerPosition.Left);
			}
			double withDuration = (0 == velocity ? animationDuration : NMath.Max(0.1f, NMath.Min(1, (v.X() / velocity))));
			UIView.Animate(withDuration, () =>
			{
				var s = this;
				var position = v.Position();
				position.X = v.Width() / 2;
				v.SetPosition(position);
				s.RootViewController.View.Alpha = 0.5f;
			}, () =>
			{
				var s = this;
				if (Delegate != null)
				{
					s.Delegate.NavigationDrawerDidOpen(this, NavigationDrawerPosition.Left);
				}
			});
		}

		public void OpenRightView(nfloat velocity = default(nfloat))
		{
			if (!IsRightViewEnabled) return;
			var v = RightView;
			if (v == null) return;
			//HideStatusBar();
			ShowView(v);
			UserInteractionEnabled = false;
			if (Delegate != null)
			{
				Delegate.NavigationDrawerWillOpen(this, NavigationDrawerPosition.Right);
			}
			double withDuration = (0 == velocity ? animationDuration : NMath.Max(0.1f, NMath.Min(1, (v.X() / velocity))));
			UIView.Animate(withDuration, () =>
			{
				var s = this;
				var position = v.Position();
				position.X = s.View.Bounds.Width - v.Width() / 2;
				v.SetPosition(position);
				s.RootViewController.View.Alpha = 0.5f;
			}, () =>
			{
				var s = this;
				if (Delegate != null)
				{
					s.Delegate.NavigationDrawerDidOpen(this, NavigationDrawerPosition.Right);
				}
			});
		}

		public void CloseLeftView(nfloat velocity = default(nfloat))
		{
			if (!IsLeftViewEnabled) return;
			var v = LeftView;
			if (v == null) return;

			UserInteractionEnabled = false;
			if (Delegate != null)
			{
				Delegate.NavigationDrawerWillClose(this, NavigationDrawerPosition.Left);
			}
			double withDuration = (0 == velocity ? animationDuration : NMath.Max(0.1f, NMath.Min(1, (v.X() / velocity))));
			UIView.Animate(withDuration, () =>
			{
				var s = this;
				var position = v.Position();
				position.X = -v.Width() / 2;
				v.SetPosition(position);
				s.RootViewController.View.Alpha = 1;
			}, () =>
			{
				var s = this;
				s.HideView(v);
				s.ToggleStatusBar();
				if (Delegate != null)
				{
					s.Delegate.NavigationDrawerDidClose(this, NavigationDrawerPosition.Left);
				}
			});
		}

		public void CloseRightView(nfloat velocity = default(nfloat))
		{
			if (!IsRightViewEnabled) return;
			var v = RightView;
			if (v == null) return;

			UserInteractionEnabled = false;
			if (Delegate != null)
			{
				Delegate.NavigationDrawerWillClose(this, NavigationDrawerPosition.Right);
			}
			double withDuration = (0 == velocity ? animationDuration : NMath.Max(0.1f, NMath.Min(1, (v.X() / velocity))));
			UIView.Animate(withDuration, () =>
			{
				var s = this;
				var position = v.Position();
				position.X = s.View.Bounds.Width + v.Width() / 2;
				v.SetPosition(position);
				s.RootViewController.View.Alpha = 1;
			}, () =>
			{
				var s = this;
				if (Delegate != null)
				{
					s.Delegate.NavigationDrawerDidClose(this, NavigationDrawerPosition.Right);
				}
			});
		}

		internal void RemoveLeftPanGesture()
		{
			var v = LeftPanGesture;
			if (v == null) return;
			View.RemoveGestureRecognizer(v);
			LeftPanGesture = null;
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

		internal void RemoveRightTapGesture()
		{
			var v = RightTapGesture;
			if (v == null) return;
			View.RemoveGestureRecognizer(v);
			RightTapGesture = null;
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

		internal void ShowStatusBar()
		{
			var s = this;
			DispatchQueue.MainQueue.DispatchSync(() =>
			{
				var v = Application.KeyWindow;
				if (v == null) return;
				v.WindowLevel = UIWindowLevel.Normal;
				if (s.Delegate != null)
				{
					s.Delegate.NavigationDrawerStatusBar(navigationDrawerController: s, statusBar: false);
				}
			});
		}

		internal void HideStatusBar()
		{
			if (!IsHiddenStatusBarEnabled) return;

			var s = this;
			DispatchQueue.MainQueue.DispatchSync(() =>
			{
				var v = Application.KeyWindow;
				if (v == null) return;
				v.WindowLevel = UIWindowLevel.StatusBar + 1;
				if (s.Delegate != null)
				{
					s.Delegate.NavigationDrawerStatusBar(navigationDrawerController: s, statusBar: true);
				}
			});
		}

		internal void ToggleStatusBar()
		{
			if (IsOpend) HideStatusBar();
			else ShowStatusBar();
		}


		internal bool IsPointContainedWithinLeftThreshold(CGPoint point)
		{
			return point.X <= LeftThreshold;
		}

		internal bool IsPointContainedWithinRightThreshold(CGPoint point)
		{
			return point.X >= View.Bounds.Width - RightThreshold;
		}

		internal bool IsPointContainedWithinView(UIView container, CGPoint point)
		{
			return container.Bounds.Contains(point);
		}

		internal void ShowView(UIView container)
		{
			container.SetDepthPreset(depthPreset);
			container.Hidden = false;
		}

		internal void HideView(UIView container)
		{
			container.SetDepthPreset(DepthPreset.None);
			container.Hidden = true;
		}

		#endregion
		#endregion
	}

	public partial class NavigationDrawerController : RootController, IUIGestureRecognizerDelegate
	{
		private void PrepareLeftPanGesture()
		{
			if (LeftPanGesture != null) return;
			LeftPanGesture = new UIPanGestureRecognizer(this, new Selector("HandleLeftViewPanGesture:"));
			LeftPanGesture.Delegate = this;
			View.AddGestureRecognizer(LeftPanGesture);
		}
		private void PrepareLeftTapGesture()
		{
			if (LeftTapGesture != null) return;
			LeftTapGesture = new UITapGestureRecognizer(this, new Selector("HandleRightViewPanGesture:"));
			LeftTapGesture.Delegate = this;
			View.AddGestureRecognizer(LeftPanGesture);
		}
		private void PrepareRightTapGesture()
		{
			if (RightTapGesture != null) return;
			RightTapGesture = new UITapGestureRecognizer(this, new Selector("HandleLeftViewPanGesture:"));
			RightTapGesture.Delegate = this;
			View.AddGestureRecognizer(RightTapGesture);
		}
		private void PrepareRightPanGesture()
		{
			if (RightPanGesture != null) return;
			RightPanGesture = new UIPanGestureRecognizer(this, new Selector("HandleRightViewPanGesture:"));
			RightPanGesture.Delegate = this;
			View.AddGestureRecognizer(RightPanGesture);
		}

		private void PrepareContentViewController()
		{
			ContentViewController.View.BackgroundColor = Color.Black;
			PrepareViewControllerWithinContainer(ContentViewController, View);
			View.SendSubviewToBack(ContentViewController.View);
		}

		private void PrepareLeftViewController()
		{
			var v = LeftView;
			if (v == null) return;
			PrepareViewControllerWithinContainer(LeftViewController, v);
		}

		private void PrepareRightViewController()
		{
			var v = RightView;
			if (v == null) return;
			PrepareViewControllerWithinContainer(RightViewController, v);
		}

		private void PrepareLeftView()
		{
			var v = LeftViewController;
			if (v == null) return;
			IsLeftViewEnabled = true;
			LeftViewWidth = UIUserInterfaceIdiom.Phone == Device.UserInterfaceIdiom ? 280 : 320;
			LeftView = new UIView();
			LeftView.Frame = new CGRect(x: 0, y: 0, width: LeftViewWidth, height: View.Height());
			LeftView.BackgroundColor = null;
			View.AddSubview(LeftView);

			LeftView.Hidden = true;
			var position = LeftView.Position();
			position.X = -LeftViewWidth / 2;
			LeftView.SetPosition(position);
			LeftView.SetZPosition(2000);
			PrepareLeftViewController();
		}

		private void PrepareRightView()
		{
			var v = RightViewController;
			if (v == null) return;
			IsRightViewEnabled = true;
			RightViewWidth = UIUserInterfaceIdiom.Phone == Device.UserInterfaceIdiom ? 280 : 320;
			RightView = new UIView();
			RightView.Frame = new CGRect(x: View.Width(), y: 0, width: RightViewWidth, height: View.Height());
			RightView.BackgroundColor = null;
			View.AddSubview(RightView);

			RightView.Hidden = true;
			var position = RightView.Position();
			position.X = View.Bounds.Width + RightViewWidth / 2;
			RightView.SetPosition(position);
			RightView.SetZPosition(2000);
			PrepareRightViewController();
		}

	}

	public partial class NavigationDrawerController : RootController, IUIGestureRecognizerDelegate
	{

		public bool GestureRecognizer(UIGestureRecognizer gestureRecognizer, UITouch touch)
		{
			if (!IsRightViewOpened && gestureRecognizer == LeftPanGesture && (IsLeftViewOpened|| IsPointContainedWithinLeftThreshold(touch.LocationInView(View))))
				return true;
			if (!IsLeftViewOpened && gestureRecognizer == RightPanGesture && (IsRightViewOpened|| IsPointContainedWithinRightThreshold(touch.LocationInView(View))))
				return true;
			if (IsLeftViewOpened && gestureRecognizer == LeftTapGesture)
				return true;
			if (IsRightViewOpened && gestureRecognizer == RightTapGesture)
				return true;
			return false;
		}

		[Export("HandleLeftViewPanGesture:")]
		internal void HandleLeftViewPanGesture(UIPanGestureRecognizer recognizer)
		{
			if (IsLeftViewEnabled && (IsLeftViewOpened || !IsRightViewOpened && IsPointContainedWithinLeftThreshold(recognizer.LocationInView(View))))
			{
				var v = LeftView;
				var point = recognizer.LocationInView(View);

				//Animate the panel
				switch (recognizer.State)
				{
					case UIGestureRecognizerState.Began:
						{
							OriginalX = v.Position().X;
							ShowView(v);
							if (Delegate != null)
							{
								Delegate.NavigationDrawerDidBeginPanAt(this, point, NavigationDrawerPosition.Left);
							}
							break;
						}
					case UIGestureRecognizerState.Changed:
						{
							var w = v.Width();
							var transactionX = recognizer.TranslationInView(v).X;
							var position = v.Position();
							position.X = OriginalX + transactionX > (w / 2) ? (w / 2) : OriginalX + transactionX;
							v.SetPosition(position);
							var a = 1 - v.Position().X / v.Width();
							RootViewController.View.Alpha = 0.5f < a && v.Position().X <= v.Width() / 2 ? a : 0.5f;

							if (transactionX >= LeftThreshold) HideStatusBar();
							if (this.Delegate != null)
							{
								Delegate.NavigationDrawerDidChangePanAt(this, point, NavigationDrawerPosition.Left);
							}
							break;
						}
					case UIGestureRecognizerState.Ended:
					case UIGestureRecognizerState.Cancelled:
					case UIGestureRecognizerState.Failed:
						{
							var p = recognizer.VelocityInView(View);
							var x = p.X >= 1000 || p.X <= -1000 ? p.X : 0;
							if (this.Delegate != null)
							{
								Delegate.NavigationDrawerDidEndPanAt(this, point, NavigationDrawerPosition.Left);
								if (v.X() <= -LeftViewWidth + leftViewThreshold || x < -1000)
								{
									CloseLeftView(x);
								}
								else
								{
									OpenLeftView(x);
								}
							}
							break;
						}
					case UIGestureRecognizerState.Possible: break;

				}
			}
		}

		[Export("HandleRightViewPanGesture:")]
		internal void HandleRightViewPanGesture(UIPanGestureRecognizer recognizer)
		{
			if (IsRightViewOpened && (IsRightViewOpened || !IsLeftViewOpened && IsPointContainedWithinLeftThreshold(recognizer.LocationInView(View))))
			{
				var v = RightView;
				var point = recognizer.LocationInView(View);

				//Animate the panel
				switch (recognizer.State)
				{
					case UIGestureRecognizerState.Began:
						{
							OriginalX = v.Position().X;
							ShowView(v);
							if (Delegate != null)
							{
								Delegate.NavigationDrawerDidBeginPanAt(this, point, NavigationDrawerPosition.Right);
							}
							break;
						}
					case UIGestureRecognizerState.Changed:
						{
							var w = v.Width();
							var transactionX = recognizer.TranslationInView(v).X;
							var position = v.Position();
							position.X = OriginalX + transactionX > View.Bounds.Width - (w / 2) ? View.Bounds.Width - (w / 2) : OriginalX + transactionX;
							v.SetPosition(position);
							var a = 1 - (View.Bounds.Width - v.Position().X) / v.Width();
							RootViewController.View.Alpha = 0.5f < a && v.Position().X <= v.Width() / 2 ? a : 0.5f;

							if (transactionX >= LeftThreshold) HideStatusBar();
							if (this.Delegate != null)
							{
								Delegate.NavigationDrawerDidChangePanAt(this, point, NavigationDrawerPosition.Right);
							}
							break;
						}
					case UIGestureRecognizerState.Ended:
					case UIGestureRecognizerState.Cancelled:
					case UIGestureRecognizerState.Failed:
						{
							var p = recognizer.VelocityInView(View);
							var x = p.X >= 1000 || p.X <= -1000 ? p.X : 0;
							if (this.Delegate != null)
							{
								Delegate.NavigationDrawerDidEndPanAt(this, point, NavigationDrawerPosition.Right);
								if (v.X() >= rightViewThreshold || x > 1000)
								{
									CloseRightView(x);
								}
								else
								{
									OpenRightView(x);
								}
							}
							break;
						}
					case UIGestureRecognizerState.Possible: break;

				}
			}
		}

		private void HandleLeftViewTapGesture(UITapGestureRecognizer recognizer)
		{
			if (!IsLeftViewOpened) return;
			var v = LeftView;
			if (v == null) return;
			if (this.Delegate != null)
			{
				this.Delegate.NavigationDrawerDidTapPanAt(this, recognizer.LocationInView(View), NavigationDrawerPosition.Left);
			}
			if (IsLeftViewEnabled && IsLeftViewOpened && !IsPointContainedWithinView(v, recognizer.LocationInView(v)))
			{
				CloseLeftView();
			}
		}

		private void HandleRightViewTapGesture(UITapGestureRecognizer recognizer)
		{
			if (!IsRightViewOpened) return;
			var v = RightView;
			if (v == null) return;
			if (this.Delegate != null)
			{
				this.Delegate.NavigationDrawerDidTapPanAt(this, recognizer.LocationInView(View), NavigationDrawerPosition.Right);
			}
			if (IsRightViewEnabled && IsRightViewOpened && !IsPointContainedWithinView(v, recognizer.LocationInView(v)))
			{
				CloseRightView();
			}
		}
	}
}
