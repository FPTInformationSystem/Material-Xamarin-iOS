// MIT/X11 License
//
// PageTabBarController.cs
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
using CoreAnimation;
using Foundation;

namespace FPT.Framework.iOS.Material
{

	public class PageTabBarItem : FlatButton
	{
	}

	public class PageTabBar : TabBar
	{
	}

	public partial class Extensions
	{

		static NSObject sPageTabBarItemKey = new NSObject();
		internal static PageTabBarItem PageTabBarItem(this CALayer layer)
		{
			var v = MaterialObjC.MaterialAssociatedObject(layer.Handle, sPageTabBarItemKey.Handle, () =>
			{
				return new MaterialLayer(layer).Handle;
			});

			return ObjCRuntime.Runtime.GetNSObject(v) as PageTabBarItem;

		}

		internal static void SetPageTabBarItem(this CALayer layer, PageTabBarItem value)
		{
			MaterialObjC.MaterialAssociatedObject(layer.Handle, sPageTabBarItemKey.Handle, value.Handle);

		}
	}

	public class PageTabBarController : RootController
	{

		#region PROPERTOES

		//PageTa

		#endregion

		public PageTabBarController(NSCoder coder) : base(coder)
		{
			Prepare();
		}

		#region FUNCTIONS

		public override void Prepare()
		{
			base.Prepare();
		}

		private void preparePageTabBar()
		{
		}

		#endregion
	}
}
