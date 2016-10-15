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
using Foundation;
using UIKit;

namespace FPT.Framework.iOS.Material
{

	public class MaterialAssociatedObjectNavigationItem : NSObject
	{

		#region PROPERTIES

		/**
		A boolean indicating whether keys are being observed
		on the UINavigationItem.
		*/
		internal bool observed { get; set; } = false;

		public IconButton BackButton { get; set;}

		public UIView ContentView { get; set;}

		public UILabel TitleLabel { get; internal set; }

		public UILabel DetailLabel { get; private set; }

		public UIControl[] LeftControls { get; set; }

		public UIControl[] RightControls { get; set; }

		#endregion

		#region CONSTRUCTORS

		public MaterialAssociatedObjectNavigationItem()
		{
			prepareTitleLabel();
			prepareDetailLabel();
		}

		#endregion

		#region FUNCTIONS

		private void prepareTitleLabel()
		{
			TitleLabel = new UILabel();
			TitleLabel.Font = RobotoFont.MediumWithSize(17);
			TitleLabel.TextAlignment = UITextAlignment.Center;
		}

		private void prepareDetailLabel()
		{
			DetailLabel = new UILabel();
			DetailLabel.Font = RobotoFont.RegularWithSize(12);
			DetailLabel.TextAlignment = UITextAlignment.Center;
		}

		#endregion
	}

	public static partial class Extensions
	{
		
		/// NavigationItem reference.
		static NSObject sMaterialAssociatedObjectNavigationItemKey = new NSObject();
		public static MaterialAssociatedObjectNavigationItem Item(this UINavigationItem view)
		{
			var v = MaterialObjC.MaterialAssociatedObject(view.Handle, sMaterialAssociatedObjectNavigationItemKey.Handle, () =>
			{
				return new MaterialAssociatedObjectNavigationItem().Handle;
			});

			return ObjCRuntime.Runtime.GetNSObject(v) as MaterialAssociatedObjectNavigationItem;

		}

		public static void SetItem(this UINavigationItem view, MaterialAssociatedObjectNavigationItem value)
		{
			MaterialObjC.MaterialAssociatedObject(view.Handle, sMaterialAssociatedObjectNavigationItemKey.Handle, value.Handle);

		}

		/// Back Button.
		public static IconButton BackButton(this UINavigationItem view)
		{
			return view.Item().BackButton;
		}

		public static void SetBackButton(this UINavigationItem view, IconButton backButton)
		{
			view.Item().BackButton = backButton;
		}

		/// ContentView
		public static UIView ContentView(this UINavigationItem view)
		{
			return view.Item().ContentView;
		}

		public static void SetContentView(this UINavigationItem view, UIView contentView)
		{
			view.Item().ContentView = contentView;
		}

		/// Title
		public static string Title(this UINavigationItem view)
		{
			return view.Item().TitleLabel.Text;
		}

		public static void SetTitle(this UINavigationItem view, string title)
		{
			view.Item().TitleLabel.Text = title;
		}

		/// Title Label.
		public static UILabel Titlelabel(this UINavigationItem view)
		{
			return view.Item().TitleLabel;
		}

		public static void SetTitlelabel(this UINavigationItem view, UILabel titleLabel)
		{
			view.Item().TitleLabel = titleLabel;
		}

		/// Detail
		public static string Detail(this UINavigationItem view)
		{
			return view.Item().DetailLabel.Text;
		}

		public static void SetDetailTitle(this UINavigationItem view, string title)
		{
			view.Item().DetailLabel.Text = title;
		}

		/// Detail Label.
		public static UILabel Detaillabel(this UINavigationItem view)
		{
			return view.Item().DetailLabel;
		}

		public static void SetDetaillabel(this UINavigationItem view, UILabel titleLabel)
		{
			view.Item().TitleLabel = titleLabel;
		}

		/// Left side UIControls.
		public static UIControl[] LeftControls(this UINavigationItem view)
		{
			return view.Item().LeftControls;
		}

		public static void SetLeftControls(this UINavigationItem view, UIControl[] leftControls)
		{
			view.Item().LeftControls = leftControls;
		}

		/// Right side UIControls.
		public static UIControl[] RightControls(this UINavigationItem view)
		{
			return view.Item().RightControls;
		}

		public static void SetRightControls(this UINavigationItem view, UIControl[] rightControls)
		{
			view.Item().RightControls = rightControls;
		}
	}
}
