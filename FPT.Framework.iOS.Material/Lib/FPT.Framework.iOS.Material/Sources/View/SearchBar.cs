// MIT/X11 License
//
// SearchBar.cs
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
	public class SearchBar : BarView
	{

		#region PROPERTIES

		public UITextField TextField { get; private set;}

		public IconButton ClearButton { get; private set;}


		private bool mClearButtonAutoHandleEnabled = true;
		public bool ClearButtonAutoHandleEnabled
		{
			get
			{
				return mClearButtonAutoHandleEnabled;
			}
			set
			{
				mClearButtonAutoHandleEnabled = value;
				ClearButton.RemoveTarget(this, new Selector("handleClearButton"), UIControlEvent.TouchUpInside);
				if (value)
				{
					ClearButton.AddTarget(this, new Selector("handleClearButton"), UIControlEvent.TouchUpInside);
				}
			}
		}

		public override UIColor TintColor
		{
			get
			{
				return TextField.TintColor;
			}
			set
			{
				TextField.TintColor = value;
			}
		}

		public UIColor TextColor
		{
			get
			{
				return TextField.TextColor;
			}
			set
			{
				TextField.TextColor = value;
			}
		}

		private string mPlaceholder;
		public string Placeholder
		{
			get
			{
				return mPlaceholder;
			}
			set
			{
				mPlaceholder = value;
				if (value != null)
				{
					TextField.AttributedPlaceholder = new NSAttributedString(value, new UIStringAttributes
					{
						ForegroundColor = PlaceholderColor
					});
				}
			}
		}

		private UIColor mPlaceholderColor = MaterialColor.DarkText.Others;
		public UIColor PlaceholderColor
		{
			get
			{
				return mPlaceholderColor;
			}
			set
			{
				mPlaceholderColor = value;
				if (Placeholder != null)
				{
					TextField.AttributedPlaceholder = new NSAttributedString(Placeholder, new UIStringAttributes
					{
						ForegroundColor = PlaceholderColor
					});
				}
			}
		}

		#endregion

		#region CONSTRUCTORS

		public SearchBar(NSCoder coder) : base(coder) { }

		public SearchBar(CGRect frame) : base(frame) { }

		public SearchBar(UIControl[] leftControls = null, UIControl[] rightControls = null) : base(leftControls, rightControls) { }

		#endregion

		#region FUNCTIONS

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			if (WillRenderView)
			{
				TextField.Frame = ContentView.Bounds;
				layoutClearButton();
			}
		}

		public override void PrepareView()
		{
			base.PrepareView();
			prepareTextField();
			prepareClearButton();
		}

		public void layoutClearButton()
		{
			nfloat h = TextField.Frame.Height;
			ClearButton.Frame = new CGRect(TextField.Frame.Width - h, 0, h, h);
		}

		[Export("handleClearButton")]
		internal void handleClearButton()
		{
			TextField.Text = null;
		}

		private void prepareTextField()
		{
			TextField = new UITextField();
			TextField.ContentScaleFactor = MaterialDevice.Scale;
			TextField.Font = RobotoFont.RegularWithSize(17);
			TextField.BackgroundColor = MaterialColor.Clear;
			TextField.ClearButtonMode = UITextFieldViewMode.WhileEditing;
			TintColor = PlaceholderColor;
			TextColor = MaterialColor.DarkText.Primary;
			Placeholder = "Search";
			ContentView.AddSubview(TextField);
		}

		private void prepareClearButton()
		{
			var image = MaterialIcon.CM.Close;
			ClearButton = new IconButton();
			ClearButton.ContentEdgeInsets = UIEdgeInsets.Zero;
			ClearButton.TintColor = PlaceholderColor;
			ClearButton.SetImage(image, UIControlState.Normal);
			ClearButton.SetImage(image, UIControlState.Highlighted);
			ClearButtonAutoHandleEnabled = true;
			TextField.ClearButtonMode = UITextFieldViewMode.Never;
			TextField.RightViewMode = UITextFieldViewMode.WhileEditing;
			TextField.RightView = ClearButton;
		}

		#endregion
	}
}
