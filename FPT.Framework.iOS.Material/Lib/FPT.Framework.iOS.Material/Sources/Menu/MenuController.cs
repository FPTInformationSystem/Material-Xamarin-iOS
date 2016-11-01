// MIT/X11 License
//
// MenuController.cs
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
using Foundation;
using ObjCRuntime;

namespace FPT.Framework.iOS.Material
{

	public static partial class Extensions
	{
		public static MenuController MenuController(this UIViewController viewController)
		{
			while (viewController != null)
			{
				if (viewController is MenuController)
				{
					return viewController as MenuController;
				}
				viewController = viewController.ParentViewController;
			}
			return null;
		}
	}

	public class MenuController : RootController
	{

		#region PROPERTIES


		public Menu Menu { get; private set; } = new Menu();

		#endregion

		#region CONSTRUCTORS

		public MenuController(NSCoder coder) : base(coder)
		{
		}

		public MenuController(UIViewController rootViewController) : base(rootViewController) { }

		#endregion

		#region FUNCTIONS

		public virtual void OpenMennu(Action<UIView> completion = null)
		{
			if (UserInteractionEnabled)
			{
				UserInteractionEnabled = false;
				UIView.Animate(0.15f, () =>
				{
					this.RootViewController.View.Alpha = 0.25f;
				});

				Menu.Open(completion: (UIView view) =>
				{
					if (completion != null)
					{
						completion(view);
					}
				});
			}
		}

		public virtual void CloseMennu(Action<UIView> completion = null)
		{
			if (!UserInteractionEnabled)
			{
				
				UIView.Animate(0.15f, () =>
				{
					this.RootViewController.View.Alpha = 1;
				});

				Menu.Close(completion: (UIView view) =>
				{
					if (completion != null)
					{
						completion(view);
					}

					if (this.Menu.Views[this.Menu.Views.Length - 1] == view)
					{
						UserInteractionEnabled = true;
					}
				});
			}
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			RootViewController.View.Frame = View.Bounds;
		}

		private static NSObject sToolbarContext = new NSObject();

		public override void Prepare()
		{
			base.Prepare();
			prepareMenuView();
		}

		private void prepareMenuView()
		{
			Menu.SetZPosition(1000);
			View.AddSubview(Menu);
		}

		#endregion
	}
}
