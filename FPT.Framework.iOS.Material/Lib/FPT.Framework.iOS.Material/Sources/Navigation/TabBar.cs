
// MIT/X11 License
//
// TabBar.cs
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
using Foundation;
using ObjCRuntime;
using UIKit;

namespace FPT.Framework.iOS.Material
{

	public enum TabBarLineAlignment
	{
		Top, Bottom
	}

	public class TabBar : MaterialView
	{

		#region PROPERTIES

		public UIView Line
		{
			get; private set;
		}

		private TabBarLineAlignment mLineAlignment = TabBarLineAlignment.Bottom;
		public TabBarLineAlignment LineAlignment
		{
			get
			{
				return mLineAlignment;
			}
			set
			{
				mLineAlignment = value;
				LayoutSubviews();
			}
		}

		public bool WillRenderView
		{
			get
			{
				return 0 < Width;
			}
		}

		private UIButton[] mButtons;
		public UIButton[] Buttons
		{
			get
			{
				return mButtons;
			}
			set
			{
				if (mButtons != null && mButtons != value)
				{
					foreach (var b in mButtons)
					{
						b.RemoveFromSuperview();
					}
				}
				mButtons = value;
				if (mButtons != null)
				{
					foreach (var b in mButtons)
					{
						AddSubview(b);
				}
				}
			}
		}

		#endregion

		#region FUNCTIONS

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			if (WillRenderView)
			{
				var v = Buttons;
				if (v.Length > 0)
				{
					int columns = this.Grid().Axis.Columns / v.Length;
					foreach (var b in v)
					{
						b.Grid().Columns = columns;
						b.ContentEdgeInsets = UIEdgeInsets.Zero;
						b.Layer.CornerRadius = 0;
						b.TouchUpInside -= handleButton;
						b.TouchUpInside += handleButton;
						//b.RemoveTarget(this, new Selector(
					}
					this.Grid().Views = v;
					Line.Frame = new CGRect(0, LineAlignment == TabBarLineAlignment.Bottom ? Height - 3 : 0, v[0].Frame.Width, 3);
				}
			}
		}

		private void handleButton(object sender, EventArgs e)
		{
			UIButton button = sender as UIButton;
			UIView.Animate(0.25f, () =>
			{
				var frame = this.Line.Frame;
				frame.X = button.Frame.X;
				frame.Width = button.Frame.Width;
				this.Line.Frame = frame;
			});
		}

		public override void PrepareView()
		{
			base.PrepareView();
			AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
			ContentScaleFactor = MaterialDevice.Scale;
			prepareBottomLayer();
		}

		private void prepareBottomLayer()
		{
			Line = new UIView();
			Line.BackgroundColor = MaterialColor.Yellow.Base;
			AddSubview(Line);
		}

		#endregion

		#region CONSTRUCTORS

		public TabBar() : this(CGRect.Empty) { }

		public TabBar(Foundation.NSCoder coder) : base(coder) { }

		public TabBar(CGRect frame) : base(frame) { }

		#endregion
	}
}
