// MIT/X11 License
//
// UILabel.cs
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
using CoreGraphics;

namespace FPT.Framework.iOS.Material.Extension
{
	public class UILabel : UIKit.UILabel, IUIView
	{
		public UILabel() : base() { }

		public UILabel(Foundation.NSCoder coder) : base(coder)
		{
		}

		public UILabel(CGRect frame) : base(frame)
		{
		}

		private Grid mGrid;
		public Grid Grid
		{
			get
			{
				if (mGrid == null)
				{
					mGrid = new Grid();
				}
				return mGrid;
			}
			set
			{
				mGrid = value;
			}
		}

		private Layout mLayout;
		public Layout Layout
		{
			get
			{
				if (mLayout == null)
				{
					mLayout = new Layout(this);
				}
				return mLayout;
			}

			set
			{
				mLayout = value;
			}
		}
	}
}
