// MIT/X11 License
//
// SearchBarController.cs
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
		public static SearchBarController SearchBarController(this UIViewController viewController)
		{
			while (viewController != null)
			{
				if (viewController is SearchBarController)
				{
					return viewController as SearchBarController;
				}
				viewController = viewController.ParentViewController;
			}

			return null;
		}
	}

	public class SearchBarController : RootController
	{

		#region PROPERTIES

		public SearchBar SearchBar { get; private set; }

		#endregion

		#region CONSTRUCTORS

		public SearchBarController(NSCoder coder) : base(coder)
		{
		}

		public SearchBarController(UIViewController rootViewController) : base (rootViewController)
		{
		}

		#endregion

		#region FUNCTIONS

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			var v = SearchBar;
			if (v != null)
			{
				var edgeInset = v.Grid().LayoutInset;
				edgeInset.Top = MaterialDevice.Type == MaterialDeviceType.iPhone && MaterialDevice.IsLandscape ? 0 : 20;
				v.Grid().LayoutInset = edgeInset;

				var h = MaterialDevice.Height;
				var w = MaterialDevice.Width;
				var p = v.IntrinsicContentSize.Height + v.Grid().LayoutInset.Top + v.Grid().LayoutInset.Bottom;

				v.Width = w + v.Grid().LayoutInset.Left + v.Grid().LayoutInset.Right;
				v.Height = p;

				var frame = RootViewController.View.Frame;
				frame.Y = p;
				frame.Height = h - p;
				RootViewController.View.Frame = frame;
			}
		}

		public override void PrepareView()
		{
			base.PrepareView();
			prepareSearchBar();
		}

		private void prepareSearchBar()
		{
			if (SearchBar == null)
			{
				SearchBar = new SearchBar();
				SearchBar.ZPosition = 1000;
				View.AddSubview(SearchBar);
			}
		}

		#endregion
	}
}
