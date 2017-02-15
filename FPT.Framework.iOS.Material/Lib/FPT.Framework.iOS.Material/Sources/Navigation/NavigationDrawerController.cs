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
using Foundation;
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
	}

	public class NavigationDrawerController : RootController, IUIGestureRecognizerDelegate
	{

		#region PROPERTIES

		internal UIPanGestureRecognizer LeftPanGesture { get; private set;}

		internal UIPanGestureRecognizer RightPanGesture { get; private set; }

		internal UITapGestureRecognizer LeftTapGesture { get; private set; }

		internal UITapGestureRecognizer RightTapGesture { get; private set; }

		public nfloat LeftThreshold { get; set; } = 64f;
		private nfloat leftViewThreshold { get; set; }

		public nfloat RightThreshold { get; set; } = 64f;
		private nfloat rightViewThreshold { get; set; }

		#endregion

		#region CONSTRUCTORS

		public NavigationDrawerController(NSCoder coder) : base(coder)
		{
		}

		public NavigationDrawerController(UIViewController rootViewContrller) : base (rootViewContrller)
		{
		}

		#endregion
	}
}
