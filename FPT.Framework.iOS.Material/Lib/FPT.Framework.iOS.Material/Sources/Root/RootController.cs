// MIT/X11 License
//
// RootController.cs
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
using Foundation;
using UIKit;
namespace FPT.Framework.iOS.Material
{
	public class RootController : UIViewController
	{

		#region PROPERTIES

		/// Device status bar style.
		public UIStatusBarStyle StatusBarStyle
		{
			get
			{
				return Device.StatusBarStyle;
			}
			set
			{
				Device.StatusBarStyle = value;
			}
		}

		/**
		A Boolean property used to enable and disable interactivity
		with the rootViewController.
		*/
		public bool UserInteractionEnabled
		{
			get
			{
				return RootViewController.View.UserInteractionEnabled;
			}
			set
			{
				RootViewController.View.UserInteractionEnabled = value;
			}
		}

		public UIViewController RootViewController { get; internal set; }

		#endregion

		#region VARIABLES



		#endregion

		#region CONSTRUCTORS

		/**
		An initializer that initializes the object with a NSCoder object.
		- Parameter aDecoder: A NSCoder instance.
		*/

		public RootController(IntPtr handle) : base(handle)
		{
			Prepare();
		}

		public RootController(NSCoder coder) : base(coder)
		{
			Prepare();
		}

		public RootController(string nibName, NSBundle bundle) : base(nibName, bundle)
		{
			Prepare();
		}

		public RootController(UIViewController rootViewController) : base()
		{
			this.RootViewController = rootViewController;
			Prepare();
		}

		#endregion

		#region FUNCTIONS

		public override void ViewWillLayoutSubviews()
		{
			base.ViewWillLayoutSubviews();
			LayoutSubviews();
		}

		/**
		A method to swap rootViewController objects.
		- Parameter toViewController: The UIViewController to swap
		with the active rootViewController.
		- Parameter duration: A NSTimeInterval that sets the
		animation duration of the transition.
		- Parameter options: UIViewAnimationOptions thst are used
		when animating the transition from the active rootViewController
		to the toViewController.
		- Parameter animations: An animation block that is executed during
		the transition from the active rootViewController
		to the toViewController.
		- Parameter completion: A completion block that is execited after
		the transition animation from the active rootViewController
		to the toViewController has completed.
		*/
		public void TransitionFromRootViewController(UIViewController toViewController, double duration = 0.5, UIViewAnimationOptions options = default(UIViewAnimationOptions), Action animations = null, Action<bool> completion = null)
		{
			RootViewController.WillMoveToParentViewController(null);
			AddChildViewController(toViewController);
			toViewController.View.Frame = RootViewController.View.Frame;
			Transition(fromViewController: RootViewController,
				toViewController: toViewController,
				duration: duration,
				options: options,
				animations: animations==null? ()=>{ } : animations,
				completionHandler: (finished) =>
				{
					var s = this;
					toViewController.DidMoveToParentViewController(s);
					s.RootViewController.RemoveFromParentViewController();
					s.RootViewController = toViewController;
					s.RootViewController.View.ClipsToBounds = true;
					s.RootViewController.View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
					s.RootViewController.View.ContentScaleFactor = Device.Scale;
					if (completion != null)
					{
						completion(finished);
					}
				});
		}

		public virtual void LayoutSubviews() { }

		/**
		Prepares the view instance when intialized. When subclassing,
		it is recommended to override the prepareView method
		to initialize property values and other setup operations.
		The super.prepareView method should always be called immediately
		when subclassing.
		*/
		public virtual void Prepare()
		{
			View.ClipsToBounds = true;
			View.ContentScaleFactor = Device.Scale;
			PrepareRootViewController();
		}

		/// A method that prepares the rootViewController.
		internal virtual void PrepareRootViewController()
		{
			PrepareViewControllerWithinContainer(RootViewController, View);
		}

		/**
		A method that adds the passed in controller as a child of
		the BarController within the passed in
		container view.
		- Parameter viewController: A UIViewController to add as a child.
		- Parameter container: A UIView that is the parent of the
		passed in controller view within the view hierarchy.
		*/
		internal void PrepareViewControllerWithinContainer(UIViewController viewController, UIView container)
		{
			var v = viewController;
			if (v != null)
			{
				AddChildViewController(v);
				container.AddSubview(v.View);
				v.DidMoveToParentViewController(this);
				v.View.Frame = container.Bounds;
				v.View.ClipsToBounds = true;
				v.View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
				v.View.ContentScaleFactor = Screen.Scale;
			}
		}

		#endregion

	}
}
