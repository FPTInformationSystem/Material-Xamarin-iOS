// MIT/X11 License
//
// StatusBarController.cs
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

	public static partial class Extensions
	{
		public static StatusBarController StatusBarController(this UIViewController viewController)
		{
			while (viewController != null)
			{
				if (viewController is StatusBarController)
				{
					return viewController as StatusBarController;
				}
				viewController = viewController.ParentViewController;
			}

			return null;
		}
	}

	public class StatusBarController : RootController
	{

		public View StatusBar { get; private set; } = new View();

		#region CONSTRUCTORS

		/**
		An initializer that initializes the object with a NSCoder object.
		- Parameter aDecoder: A NSCoder instance.
		*/
		public StatusBarController(NSCoder coder) : base(coder)
		{
			//Prepare();
		}

		public StatusBarController(string nibName, NSBundle bundle) : base(nibName, bundle)
		{
			//Prepare();
		}

		public StatusBarController(UIViewController rootViewController) : base(rootViewController)
		{
			this.RootViewController = rootViewController;
			//Prepare();
		}

		#endregion

		#region FUNCTIONS

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			StatusBar.Hidden = MaterialDevice.IsLandscape && MaterialDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone;
			RootViewController.View.Frame = View.Bounds;
		}

		public override void Prepare()
		{
			base.Prepare();
			prepareStatusBar();
		}

		public void prepareStatusBar()
		{
			StatusBar.SetZPosition(3000);
			StatusBar.BackgroundColor = Color.White;
			View.Layout(StatusBar).Top().Horizontally().Height(20);
		}

		#endregion
	}
}
