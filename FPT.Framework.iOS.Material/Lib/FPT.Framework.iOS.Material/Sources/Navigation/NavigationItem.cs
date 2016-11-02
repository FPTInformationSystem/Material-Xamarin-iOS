// MIT/X11 License
//
// NavigationItem.cs
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
using Foundation;
using ObjCRuntime;
using UIKit;

namespace FPT.Framework.iOS.Material
{

	public class NavigationItem : NSObject
	{

		#region PROPERTIES

		private ContentViewAlignment mContentViewAlignment = ContentViewAlignment.Center;
		public ContentViewAlignment ContentViewAlignment
		{
			get
			{
				return mContentViewAlignment;
			}
			set
			{
				mContentViewAlignment = value;
				if (NavigationBar != null)
				{
					NavigationBar.LayoutSubviews();
				}
			}
		}

		public IconButton BackButton { get; private set; } = new IconButton();

		public UIView ContentView { get; private set; } = new UIView();

		public UILabel TitleLabel {
			[Export("titleLabel", ArgumentSemantic.Retain)] get;

			[Export("setTitleLabel:", ArgumentSemantic.Retain)] private set;
		} = new UILabel();

		public UILabel DetailLabel { get; private set; } = new UILabel();

		private List<UIView> mLeftViews = new List<UIView>();
		public List<UIView> LeftViews
		{
			get
			{
				return mLeftViews;
			}
			set
			{
				foreach (var v in mLeftViews)
				{
					v.RemoveFromSuperview();
				}

				mLeftViews = value;

				if (NavigationBar != null)
				{
					NavigationBar.LayoutSubviews();
				}
			}
		}

		private List<UIView> mRightViews = new List<UIView>();
		public List<UIView> RightViews
		{
			get
			{
				return mRightViews;
			}
			set
			{
				foreach (var v in mRightViews)
				{
					v.RemoveFromSuperview();
				}

				mRightViews = value;

				if (NavigationBar != null)
				{
					NavigationBar.LayoutSubviews();
				}
			}
		}

		private List<UIView> mCenterViews = new List<UIView>();
		public List<UIView> CenterViews
		{
			get
			{
				return mCenterViews;
			}
			set
			{
				foreach (var v in mCenterViews)
				{
					v.RemoveFromSuperview();
				}

				mCenterViews = value;

				if (NavigationBar != null)
				{
					NavigationBar.LayoutSubviews();
				}
			}
		}

		public NavigationBar NavigationBar
		{
			get
			{
				if (ContentView.Superview != null)
				{
					return ContentView.Superview.Superview as NavigationBar;
				}
				return null;
			}
		}

		#endregion

		#region CONSTRUCTORS

		public NavigationItem()
		{
			prepareTitleLabel();
			prepareDetailLabel();
		}

		//protected override void Dispose(bool disposing)
		//{
		//	RemoveObserver(this, "titleLabel.textAlignment", sNavigationItemContext.Handle);
		//	//base.Dispose(disposing);
		//}

		//~NavigationItem()
		//{
		//	RemoveObserver(this, "titleLabel.textAlignment");
		//}

		#endregion

		#region FUNCTIONS

		//public override void ObserveValue(NSString keyPath, NSObject ofObject, NSDictionary change, IntPtr context)
		//{
		//	if (keyPath.ToString() == "titleLabel.textAlignment")
		//	{
		//		ContentViewAlignment = TitleLabel.TextAlignment == UITextAlignment.Center ? ContentViewAlignment.Center : ContentViewAlignment.Any;
		//	}
		//	base.ObserveValue(keyPath, ofObject, change, context);
		//}

		//static NSObject sNavigationItemContext = new NSObject();

		private void prepareTitleLabel()
		{
			TitleLabel.TextAlignment = UITextAlignment.Center;
			TitleLabel.ContentScaleFactor = Device.Scale;
			TitleLabel.Font = RobotoFont.MediumWithSize(17);
			TitleLabel.TextColor = Color.DarkText.Primary;
			//AddObserver(this, "titleLabel.textAlignment", default(NSKeyValueObservingOptions), sNavigationItemContext.Handle);
		}

		private void prepareDetailLabel()
		{
			DetailLabel.TextAlignment = UITextAlignment.Center;
			DetailLabel.ContentScaleFactor = Device.Scale;
			DetailLabel.Font = RobotoFont.RegularWithSize(12);
			DetailLabel.TextColor = Color.DarkText.Secondary;
		}

		#endregion
	}

	public static partial class Extensions
	{
		
		/// NavigationItem reference.
		static NSObject sMaterialAssociatedObjectNavigationItemKey = new NSObject();
		public static NavigationItem NavigationItem(this UINavigationItem view)
		{
			var v = MaterialObjC.AssociatedObject(view.Handle, sMaterialAssociatedObjectNavigationItemKey.Handle, () =>
			{
				return new NavigationItem().Handle;
			});

			return ObjCRuntime.Runtime.GetNSObject(v) as NavigationItem;

		}

		public static void SetNavigationItem(this UINavigationItem view, NavigationItem value)
		{
			MaterialObjC.MaterialAssociatedObject(view.Handle, sMaterialAssociatedObjectNavigationItemKey.Handle, value.Handle);

		}

		/// Should center the contentView.
		public static ContentViewAlignment ContentViewAlignment(this UINavigationItem view)
		{
			return view.NavigationItem().ContentViewAlignment;
		}

		/// ContentView
		public static UIView ContentView(this UINavigationItem view)
		{
			return view.NavigationItem().ContentView;
		}

		/// Back Button.
		public static IconButton BackButton(this UINavigationItem view)
		{
			return view.NavigationItem().BackButton;
		}

		/// Title
		public static string Title(this UINavigationItem view)
		{
			return view.NavigationItem().TitleLabel.Text;
		}

		public static void SetTitle(this UINavigationItem view, string title)
		{
			view.NavigationItem().TitleLabel.Text = title;
		}

		/// Title Label.
		public static UILabel Titlelabel(this UINavigationItem view)
		{
			return view.NavigationItem().TitleLabel;
		}

		/// Detail
		public static string Detail(this UINavigationItem view)
		{
			return view.NavigationItem().DetailLabel.Text;
		}

		public static void SetDetail(this UINavigationItem view, string title)
		{
			view.NavigationItem().DetailLabel.Text = title;
		}

		/// Detail Label.
		public static UILabel DetailLabel(this UINavigationItem view)
		{
			return view.NavigationItem().DetailLabel;
		}

		/// Left side UIControls.
		public static List<UIView> LeftViews(this UINavigationItem view)
		{
			return view.NavigationItem().LeftViews;
		}

		public static void SetLeftViews(this UINavigationItem view, List<UIView> leftControls)
		{
			view.NavigationItem().LeftViews = leftControls;
		}

		/// Right side UIControls.
		public static List<UIView> RightViews(this UINavigationItem view)
		{
			return view.NavigationItem().RightViews;
		}

		public static void SetRightViews(this UINavigationItem view, List<UIView> rightControls)
		{
			view.NavigationItem().RightViews = rightControls;
		}
	}
}
