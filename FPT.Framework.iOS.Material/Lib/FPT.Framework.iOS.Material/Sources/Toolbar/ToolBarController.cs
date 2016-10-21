// MIT/X11 License
//
// ToolBarController.cs
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
using CoreFoundation;
using CoreGraphics;
using Foundation;
using UIKit;

namespace FPT.Framework.iOS.Material
{

	public static partial class Extensions
	{
		public static ToolbarController ToolBarController(this UIViewController viewController)
		{
			while (viewController != null)
			{
				if (viewController is ToolbarController)
				{
					return viewController as ToolbarController;
				}
				viewController = viewController.ParentViewController;
			}

			return null;
		}
	}

	public abstract class ToolbarControllerDelegate
	{
		public virtual void ToolbarControllerWillOpenFloatingViewController(ToolbarController toolbarController) { }
		public virtual void ToolbarControllerWillCloseFloatingViewController(ToolbarController toolbarController) { }
		public virtual void ToolbarControllerDidOpenFloatingViewController(ToolbarController toolbarController) { }
		public virtual void ToolbarControllerDidCloseFloatingViewController(ToolbarController toolbarController) { }
	}

	public class ToolbarController : StatusBarController
	{

		#region PROPERTIES

		private Display mDisplay = Display.Partial;
		public Display Display
		{
			get
			{
				return mDisplay;
			}
			set
			{
				mDisplay = value;
				LayoutSubviews();
			}
		}

		/// Reference to the Toolbar.
		public Toolbar Toolbar { get; private set; } = new Toolbar();

		/// Internal reference to the floatingViewController.
		private UIViewController internalFloatingViewController { get; set; }

		/// Delegation handler.
		public ToolbarControllerDelegate Delegate { get; set;}

		/// A floating UIViewController.
		public UIViewController FloatingViewController
		{
			get
			{
				return this.internalFloatingViewController;
			}
			set
			{
				var v = internalFloatingViewController;
				if (v != null)
				{
					v.View.Layer.RasterizationScale = Device.Scale;
					v.View.Layer.ShouldRasterize = true;
					if (Delegate != null)
					{
						Delegate.ToolbarControllerWillOpenFloatingViewController(this);
					}
					internalFloatingViewController = null;
					UIView.Animate(duration: 0.5,
						animation: () =>
						{
							var s = this;
							CGPoint point = v.View.Center;
							point.Y = 2 * s.View.Bounds.Height;
							v.View.Center = point;
							s.Toolbar.Alpha = 1;
							s.RootViewController.View.Alpha = 1;
						},
						completion: () =>
						{
							var s = this;
							v.WillMoveToParentViewController(null);
							v.View.RemoveFromSuperview();
							v.RemoveFromParentViewController();
							v.View.Layer.ShouldRasterize = false;
							s.UserInteractionEnabled = true;
							s.Toolbar.UserInteractionEnabled = true;
							DispatchQueue.MainQueue.DispatchAsync(() =>
							{
								if (this.Delegate != null)
								{
									this.Delegate.ToolbarControllerDidCloseFloatingViewController(s);
								}
							});
						});
				}

				v = value;
				if (v != null)
				{
					// Add the noteViewController! to the view.
					AddChildViewController(v);
					v.View.Frame = View.Bounds;
					var point = v.View.Center;
					point.Y = 2 * View.Bounds.Height;
					v.View.Center = point;
					v.View.Hidden = true;
					View.InsertSubviewAbove(v.View, Toolbar);
					v.View.Layer.ZPosition = 1500;
					v.DidMoveToParentViewController(this);

					// Animate the noteButton out and the noteViewController! in.
					v.View.Hidden = false;
					v.View.Layer.RasterizationScale = Device.Scale;
					v.View.Layer.ShouldRasterize = true;
					View.Layer.RasterizationScale = Device.Scale;
					View.Layer.ShouldRasterize = true;
					internalFloatingViewController = v;
					UserInteractionEnabled = false;
					Toolbar.UserInteractionEnabled = false;
					if (Delegate != null)
					{
						Delegate.ToolbarControllerWillOpenFloatingViewController(this);
					}
					UIView.Animate(duration:0.5,
						animation: () =>
						{
							var s = this;
							point = v.View.Center;
							point.Y = s.View.Bounds.Height / 2;
							v.View.Center = point;
							s.Toolbar.Alpha = 0.5f;
						},
						completion: () =>
						{
							var s = this;
							v.View.Layer.ShouldRasterize = false;
							s.View.Layer.ShouldRasterize = false;
							DispatchQueue.MainQueue.DispatchSync(() =>
							{
								if (this.Delegate != null)
								{
									this.Delegate.ToolbarControllerDidOpenFloatingViewController(this);
								}
							});
						});
				}
			}
		}

		#endregion

		#region CONSTRUCTORS

		public ToolbarController(NSCoder coder) : base(coder)
		{
		}

		public ToolbarController(UIViewController rootViewContrller) : base (rootViewContrller)
		{
		}

		#endregion

		#region FUNCTIONS

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			StatusBar.LayoutIfNeeded();

			var y = StatusBar.Hidden ? 0 : StatusBar.Height();
			var p = y + Toolbar.Height();

			Toolbar.SetY(y);
			Toolbar.SetWidth(View.Width());

			switch (Display)
			{
				case Display.Partial:
					{
						RootViewController.View.SetY(p);
						RootViewController.View.SetHeight(View.Height() - p);
					}
					break;
				case Display.Full:
					{
						RootViewController.View.Frame = View.Bounds;
					}
					break;
			}
		}

		public override void Prepare()
		{
			base.Prepare();
			prepareToolbar();
		}

		private void prepareToolbar()
		{
			Toolbar.SetDepthPreset(DepthPreset.Depth1);
			Toolbar.SetZPosition(1000);
			View.AddSubview(Toolbar);
		}

		#endregion
	}
}
