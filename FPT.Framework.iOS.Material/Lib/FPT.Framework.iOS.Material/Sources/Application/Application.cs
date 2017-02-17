// MIT/X11 License
//
// Application.cs
//
// Author:
//       Pham Quan <QuanP@fpt.com.vn, mr.pquan@gmail.com> at FPT Software Service Center.
//
// Copyright (c) 2017 FPT Information System.
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

namespace FPT.Framework.iOS.Material
{
	public struct Application
	{
		public static UIWindow KeyWindow
		{
			get
			{
				return UIApplication.SharedApplication.KeyWindow;
			}
		}

		public static bool IsLandscape
		{
			get
			{
				return UIApplication.SharedApplication.StatusBarOrientation.IsLandscape();
			}
		}

		public bool IsPortrait
		{
			get
			{
				return !IsLandscape;
			}
		}

		public static UIInterfaceOrientation Orientation
		{
			get
			{
				return UIApplication.SharedApplication.StatusBarOrientation;
			}
		}

		public static UIStatusBarStyle statusBarStyle
		{
			get
			{
				return UIApplication.SharedApplication.StatusBarStyle;
			}

			set
			{
				UIApplication.SharedApplication.StatusBarStyle = value;
			}
		}

		public static bool IsStatusBarHidden
		{
			get
			{
				return UIApplication.SharedApplication.StatusBarHidden;
			}
			set
			{
				UIApplication.SharedApplication.StatusBarHidden = value;
			}
		}

		public static bool ShouldStatusBarBeHidden
		{
			get
			{
				return IsLandscape && UIUserInterfaceIdiom.Phone == Device.UserInterfaceIdiom;
			}
		}

		public static UIUserInterfaceLayoutDirection userInterfaceLayoutDirection
		{
			get
			{
				return UIApplication.SharedApplication.UserInterfaceLayoutDirection;
			}
		}


	}
}
