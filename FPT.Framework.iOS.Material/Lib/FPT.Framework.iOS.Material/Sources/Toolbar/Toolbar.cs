// MIT/X11 License
//
// Toolbar.cs
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
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;
namespace FPT.Framework.iOS.Material
{
	public class Toolbar : Bar
	{
		private static NSObject sToolbarContext = new NSObject();
		#region PROPERTIES

		public string Title
		{
			get
			{
				return TitleLabel.Text;
			}
			set
			{
				TitleLabel.Text = value;
				LayoutSubviews();
			}
		}

		public UILabel TitleLabel {
			[Export("titleLabel", ArgumentSemantic.Retain)]
			get;
			[Export("setTitleLabel:", ArgumentSemantic.Retain)]
			private set;
		}

		public string Detail
		{
			get
			{
				return DetailLabel.Text;
			}
			set
			{
				DetailLabel.Text = value;
				LayoutSubviews();
			}
		}

		public UILabel DetailLabel { get; private set; }

		#endregion

		#region CONSTRUCTORS

		public Toolbar(NSCoder coder) : base(coder) { }

		public Toolbar(CGRect frame) : base(frame) { }

		public Toolbar(List<UIView> leftViews = null, List<UIView> rightViews = null, List<UIView> centerViews = null) : base(leftViews, rightViews, centerViews) { }

		#endregion

		#region FUNCTIONS

		public override void ObserveValue(NSString keyPath, NSObject ofObject, NSDictionary change, IntPtr context)
		{
			if (keyPath.ToString() == "titleLabel.textAlignment")
			{
				ContentViewAlignment = TitleLabel.TextAlignment == UITextAlignment.Center ? ContentViewAlignment.Center : ContentViewAlignment.Any;
			}
			else
			{
				base.ObserveValue(keyPath, ofObject, change, context);
				return;
			}
		}

		public override void Reload()
		{
			base.Reload();

			if (!string.IsNullOrEmpty(Title))
			{
				if (TitleLabel.Superview == null)
				{
					ContentView.AddSubview(TitleLabel);
				}
				TitleLabel.Frame = ContentView.Bounds;
			}
			else
			{
				TitleLabel.RemoveFromSuperview();
			}

			if (!string.IsNullOrEmpty(Detail))
			{
				if (DetailLabel.Superview == null)
				{
					ContentView.AddSubview(DetailLabel);
				}

				if (TitleLabel.Superview == null)
				{
					DetailLabel.Frame = ContentView.Bounds;
				}
				else
				{
					TitleLabel.SizeToFit();
					DetailLabel.SizeToFit();

					nfloat diff = (ContentView.Frame.Height - TitleLabel.Frame.Height - DetailLabel.Frame.Height) / 2f;

					var frame = TitleLabel.Frame;
					frame.Height += diff;
					frame.Width = ContentView.Frame.Width;
					TitleLabel.Frame = frame;

					frame = DetailLabel.Frame;
					frame.Height += diff;
					frame.Width = ContentView.Frame.Width;
					frame.Y = TitleLabel.Frame.Height;
					DetailLabel.Frame = frame;
				}
			}
			else
			{
				DetailLabel.RemoveFromSuperview();
			}
		}

		public override void Prepare()
		{
			base.Prepare();
			this.SetHeightPreset(HeightPreset.Normal);
			ContentViewAlignment = ContentViewAlignment.Center;
			prepareTitleLabel();
			prepareDetailLabel();
		}

		private void prepareTitleLabel()
		{
			TitleLabel = new UILabel();
			TitleLabel.ContentScaleFactor = Device.Scale;
			TitleLabel.Font = RobotoFont.RegularWithSize(17);
			TitleLabel.TextAlignment = UITextAlignment.Left;
			AddObserver(this, "titleLabel.textAlignment", default(NSKeyValueObservingOptions), sToolbarContext.Handle);
		}

		private void prepareDetailLabel()
		{
			DetailLabel = new UILabel();
			DetailLabel.ContentScaleFactor = Device.Scale;
			DetailLabel.Font = RobotoFont.RegularWithSize(12);
			DetailLabel.TextAlignment = UITextAlignment.Left;
		}

		~Toolbar()
		{
			RemoveObserver(this, "titleLabel.textAlignment");
		}

		#endregion
	}
}
