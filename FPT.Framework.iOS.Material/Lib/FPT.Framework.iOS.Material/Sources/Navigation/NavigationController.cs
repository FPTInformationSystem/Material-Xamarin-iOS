// MIT/X11 License
//
// NavigationController.cs
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
using Foundation;
using ObjCRuntime;
using UIKit;
namespace FPT.Framework.iOS.Material
{

	public static partial class Extensions
	{
		public static UIStatusBarStyle StatusBarStyle(this UINavigationController navigationController)
		{
			return Device.StatusBarStyle;;
		}

		public static void SetStatusBarStyle(UINavigationController navigationController, UIStatusBarStyle value)
		{
			Device.StatusBarStyle = value;
		}
	}

	public class NavigationController : UINavigationController, IUIGestureRecognizerDelegate, IUINavigationBarDelegate
	{
		#region CONSTRUCTORS

		public NavigationController(NSCoder coder) : base(coder)
		{
		}

		public NavigationController(string nibName, NSBundle bundle) : base(nibName, bundle)
		{
		}

		public NavigationController(UIViewController rootViewContrller) : base(typeof(NavigationBar), null)
		{
			
			SetViewControllers(new UIViewController[] {
				rootViewContrller
			}, false);
		}

		#endregion

		#region FUNCTIONS

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			var v = InteractivePopGestureRecognizer;
			if (v != null)
			{
				var x = this.NavigationDrawerController();
				if (x != null)
				{
					if (x.LeftPanGesture != null)
						x.LeftPanGesture.RequireGestureRecognizerToFail(v);
					if (x.RightPanGesture != null)
						x.RightPanGesture.RequireGestureRecognizerToFail(v);
				}
			}
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			PrepareView();
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			var v = NavigationBar as NavigationBar;
			if (v != null)
			{
				var item = v.TopItem;
				if (item != null)
				{
					v.layoutNavigationItem(item);
				}
			}
		}

		/**
		Detects the gesture recognizer being used. This is necessary when using 
		NavigationDrawerController. It eliminates the conflict in panning.
		- Parameter gestureRecognizer: A UIGestureRecognizer to detect.
		- Parameter touch: The UITouch event.
		- Returns: A Boolean of whether to continue the gesture or not, true yes, false no.
		*/
		[Export("gestureRecognizer:shouldReceiveTouch:")]
		public bool ShouldReceiveTouch(UIGestureRecognizer recognizer, UITouch touch)
		{
			return InteractivePopGestureRecognizer == recognizer && NavigationBar.BackItem != null;
		}

		/**
		Delegation method that is called when a new UINavigationItem is about to be pushed.
		This is used to prepare the transitions between UIViewControllers on the stack.
		- Parameter navigationBar: A UINavigationBar that is used in the NavigationController.
		- Parameter item: The UINavigationItem that will be pushed on the stack.
		- Returns: A Boolean value that indicates whether to push the item on to the stack or not. 
		True is yes, false is no.
		*/
		[Export("navigationBar:shouldPushItem:")]
		public bool ShouldPushItem(UINavigationBar navigationBar, UINavigationItem item)
		{
			var v = navigationBar as NavigationBar;
			if (v != null)
			{
				item.BackButton().AddTarget(this, new Selector("handleBackButton"), UIControlEvent.TouchUpInside);
				item.BackButton().Image = v.BackButtonImage;


				var c = item.LeftViews();
				if (c != null)
				{
					c.Add(item.BackButton());
					item.SetLeftViews(c);
				}
				else
				{
					item.SetLeftViews(new List<UIView>
					{
						item.BackButton()
					});
				}
				v.layoutNavigationItem(item);
			}

			return true;
		}

		/// Handler for the back button.
		[Export("handleBackButton")]
		internal void handleBackButton()
		{
			PopViewController(true);
		}

		/**
		Prepares the view instance when intialized. When subclassing,
		it is recommended to override the prepareView method
		to initialize property values and other setup operations.
		The super.prepareView method should always be called immediately
		when subclassing.
		*/
		public virtual void PrepareView()
		{
			NavigationBar.SetHeightPreset(HeightPreset.Normal);

			View.ClipsToBounds = true;
			View.BackgroundColor = Color.White;
			View.ContentScaleFactor = Device.Scale;

			// This ensures the panning gesture is available when going back between views.
			var v = InteractivePopGestureRecognizer;
			if (v != null)
			{
				v.Enabled = true;
				v.Delegate = this;
			}
		}

		#endregion
	}
}
