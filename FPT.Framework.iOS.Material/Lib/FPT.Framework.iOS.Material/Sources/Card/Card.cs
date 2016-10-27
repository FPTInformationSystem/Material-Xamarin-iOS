// MIT/X11 License
//
// CardView.cs
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
using CoreGraphics;
using Foundation;
using UIKit;
namespace FPT.Framework.iOS.Material
{

	public static partial class Extensions
	{
		public static CornerRadiusPreset CornerRadiusPreset(this Card view)
		{
			return view.Layer.CornerRadiusPreset();
		}

		public static void SetCornerRadiusPreset(this Card view, CornerRadiusPreset value)
		{
			view.Layer.SetCornerRadiusPreset(value);

			view.Container.SetCornerRadiusPreset(value);
		}

		public static ShapePreset ShapePreset(this Card view)
		{
			return view.Layer.ShapePreset();
		}
		public static void SetShapePreset(this Card view, ShapePreset value)
		{
			view.Layer.SetShapePreset(value);
			view.Container.SetShapePreset(value);
		}
	}

	public class Card : PulseView
	{

		#region PROPERTIES

		/// Will layout the view.
		public bool WillLayout
		{
			get
			{
				return 0 < this.Width() && Superview != null;
			}
		}

		/// A container view for subviews.
		public UIView Container { get; private set; } = new UIView();

		public override UIColor BackgroundColor
		{
			get
			{
				return base.BackgroundColor;
			}
			set
			{
				base.BackgroundColor = value;

				Container.BackgroundColor = value;
			}
		}

		private Toolbar mToolbar;
		public Toolbar Toolbar
		{
			get
			{
				return mToolbar;
			}
			set
			{
				mToolbar = value;
				LayoutSubviews();
			}
		}

		private EdgeInsetsPreset mToolbarEdgeInsetsPreset = EdgeInsetsPreset.None;
		public EdgeInsetsPreset ToolbarEdgeInsetsPreset
		{
			get
			{
				return mToolbarEdgeInsetsPreset;
			}
			set
			{
				mToolbarEdgeInsetsPreset = value;
				ToolbarEdgeInsets = Convert.EdgeInsetsPresetToValue(value);
			}
		}

		private UIEdgeInsets mToolbarEdgeInsets = UIEdgeInsets.Zero;
		public UIEdgeInsets ToolbarEdgeInsets
		{
			get
			{
				return mToolbarEdgeInsets;
			}
			set
			{
				mToolbarEdgeInsets = value;
				LayoutSubviews();
			}
		}

		private UIView mContentView;
		public UIView ContentView
		{
			get
			{
				return mContentView;
			}
			set
			{
				mContentView = value;
				LayoutSubviews();
			}
		}

		private EdgeInsetsPreset mContentViewEdgeInsetPreset = EdgeInsetsPreset.None;
		public EdgeInsetsPreset ContentViewEdgeInsetPreset
		{
			get
			{
				return mContentViewEdgeInsetPreset;
			}
			set
			{
				mContentViewEdgeInsetPreset = value;
				ContentViewEdgeInsets = Convert.EdgeInsetsPresetToValue(mContentViewEdgeInsetPreset);
			}
		}

		private UIEdgeInsets mContentViewEdgeInsets = UIEdgeInsets.Zero;
		public UIEdgeInsets ContentViewEdgeInsets
		{
			get
			{
				return mContentViewEdgeInsets;
			}
			set
			{
				mContentViewEdgeInsets = value;
				Reload();
			}
		}



		private Bar mBottomBar;
		public Bar BottomBar
		{
			get
			{
				return mBottomBar;
			}
			set
			{
				mBottomBar = value;
				LayoutSubviews();
			}
		}

		private EdgeInsetsPreset mBottomBarEdgeInsetsPreset = EdgeInsetsPreset.None;
		public EdgeInsetsPreset BottomBarEdgeInsetsPreset
		{
			get
			{
				return mBottomBarEdgeInsetsPreset;
			}
			set
			{
				mBottomBarEdgeInsetsPreset = value;
				BottomBarEdgeInsets = Convert.EdgeInsetsPresetToValue(value);
			}
		}

		private UIEdgeInsets mBottomBarEdgeInsets = UIEdgeInsets.Zero;
		public UIEdgeInsets BottomBarEdgeInsets
		{
			get
			{
				return mBottomBarEdgeInsets;
			}
			set
			{
				mBottomBarEdgeInsets = value;
				LayoutSubviews();
			}
		}


		#endregion

		#region CONSTRUCTORS

		public Card(Foundation.NSCoder coder) : base(coder)
		{
		}

		public Card(CGRect frame) : base(frame)
		{
		}

		public Card() : this(CGRect.Empty)
		{
		}

		public Card(Toolbar toolbar, UIView contentView, Bar bottomBar) : this (CGRect.Empty)
		{
			PrepareProperties(toolbar, contentView, bottomBar);
		}

		#endregion

		#region FUNCTIONS

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			if (WillLayout)
			{
				Reload();
			}
		}

		public void Reload()
		{
			Container.RemoveConstraints(Container.Constraints);
			foreach (var v in Container.Subviews)
			{
				v.RemoveFromSuperview();
			}

			var format = "V:|";
			var views = new NSMutableDictionary();
			var metrics = new NSMutableDictionary();

			if (Toolbar != null)
			{
				metrics["toolbarTop"] = NSNumber.FromNFloat(ToolbarEdgeInsets.Top);
				metrics["toolbarBottom"] = NSNumber.FromNFloat(ToolbarEdgeInsets.Bottom);

				format += "-(toolbarTop)-[toolbar]-(toolbarBottom)";
				views["toolbar"] = Toolbar;
				Container.Layout(Toolbar).Horizontally(ToolbarEdgeInsets.Left, ToolbarEdgeInsets.Right);
			}

			if (ContentView != null)
			{
				metrics["contentViewBottom"] = NSNumber.FromNFloat(ContentViewEdgeInsets.Bottom);

				if (Toolbar != null)
				{
					metrics["toolbarBottom"] = NSNumber.FromNFloat((metrics["toolbarBottom"] as NSNumber).NFloatValue + ContentViewEdgeInsets.Top);
					format += "-[contentView]-(contentViewBottom)";
				}
				else
				{
					metrics["contentViewTop"] = NSNumber.FromNFloat(ContentViewEdgeInsets.Top);
					format += "-(contentViewTop)-[contentView]-(contentViewBottom)";
				}

				views["contentView"] = ContentView;
				Container.Layout(ContentView).Horizontally(ContentViewEdgeInsets.Left, ContentViewEdgeInsets.Right);

				ContentView.Grid().Reload();
				ContentView.Divider().Reload();
			}

			if (BottomBar != null)
			{
				metrics["bottomBarBottom"] = NSNumber.FromNFloat(BottomBarEdgeInsets.Bottom);

				if (ContentView != null)
				{
					metrics["contentViewBottom"] = NSNumber.FromNFloat((metrics["contentViewBottom"] as NSNumber).FloatValue + BottomBarEdgeInsets.Top);
					format += "-[bottomBar]-(bottomBarBottom)";
				}
				else if (Toolbar != null)
				{
					metrics["toolbarBottom"] = NSNumber.FromNFloat((metrics["toolbarBottom"] as NSNumber).FloatValue + BottomBarEdgeInsets.Top);
					format += "-[bottomBar]-(bottomBarBottom)";
				}
				else
				{
					metrics["bottomBarTop"] = NSNumber.FromNFloat(BottomBarEdgeInsets.Top);
					format += "-(bottomBarTop)-[bottomBar]-(bottomBarBottom)";
				}

				views["bottomBar"] = BottomBar;
				Container.Layout(BottomBar).Horizontally(BottomBarEdgeInsets.Left, BottomBarEdgeInsets.Right);
			}

			if (views.Count > 0)
			{
				Container.AddConstraints(Layout.Constraint(string.Format("{0}-|", format), 0, metrics, views));
			}

			//if (TitleLabel != null)
			//{
			//	verticalFormat += "-(insetTop)";
			//	metrics["insetTop"] = NSNumber.FromNFloat(ContentInset.Top + TitleLabelInset.Top);
			//}
			//else if (ContentView != null)
			//{
			//	verticalFormat += "-(insetTop)";
			//	metrics["insetTop"] = NSNumber.FromNFloat(ContentInset.Top + ContentViewEdgeInsets.Top);
			//}

			//if (TitleLabel != null)
			//{
			//	verticalFormat += "-[titleLabel]";
			//	views["titleLabel"] = TitleLabel;

			//	this.Layout(TitleLabel).Horizontally(left: ContentInset.Left + TitleLabelInset.Left, right: ContentInset.Right + TitleLabelInset.Right);
			//}

			//if (ContentView != null)
			//{
			//	if (TitleLabel == null)
			//	{
			//		metrics["insetTop"] = NSNumber.FromNFloat((metrics["insetTop"] as NSNumber).NFloatValue + ContentViewEdgeInsets.Top);
			//	}
			//	else
			//	{
			//		verticalFormat += "-(insetB)";
			//		metrics["insetB"] = NSNumber.FromNFloat(TitleLabelInset.Bottom + ContentViewEdgeInsets.Top);
			//	}
			//	verticalFormat += "-[contentView]";
			//	views["contentView"] = ContentView;

			//	this.Layout(ContentView).Horizontally(left: ContentInset.Left + ContentViewEdgeInsets.Left, right: ContentInset.Right + ContentViewEdgeInsets.Right);
			//}

			//if (LeftButtons != null && LeftButtons.Length > 0)
			//{
			//	var h = "H:|";
			//	var d = new NSMutableDictionary();
			//	var i = 0;
			//	foreach (var b in LeftButtons)
			//	{
			//		var k = String.Format("b{0}", i);
			//		d[k] = b;

			//		if (i == 0)
			//		{
			//			h += "-(left)-";
			//		}
			//		else
			//		{
			//			h += "-(left_right)-";
			//		}

			//		h += String.Format("[{0}]", k);

			//		this.Layout(b).Bottom(ContentInset.Bottom + LeftButtonsInset.Bottom);

			//		i += 1;
			//	}

			//	AddConstraints(Layout.Constraint(h, 0, NSDictionary.FromObjectsAndKeys(
			//		new object[] { ContentInset.Left + LeftButtonsInset.Left, LeftButtonsInset.Left + LeftButtonsInset.Right },
			//		new object[] { "left", "left_right" }
			//	), d));
			//}

			//if (RightButtons != null && RightButtons.Length > 0)
			//{
			//	var h = "H:|";
			//	var d = new NSMutableDictionary();
			//	var i = RightButtons.Length - 1;
			//	foreach (var b in LeftButtons)
			//	{
			//		var k = String.Format("b{0}", i);
			//		d[k] = b;

			//		if (i == 0)
			//		{
			//			h += "-(right)-";
			//		}
			//		else
			//		{
			//			h += "-(right_left)-";
			//		}

			//		h += String.Format("[{0}]", k);

			//		this.Layout(b).Bottom(ContentInset.Bottom + RightButtonsInset.Bottom);

			//		i -= 1;
			//	}

			//	AddConstraints(Layout.Constraint(h + "|", 0, NSDictionary.FromObjectsAndKeys(
			//		new object[] { ContentInset.Right + RightButtonsInset.Right, RightButtonsInset.Right + RightButtonsInset.Left },
			//		new object[] { "right", "right_left" }
			//	), d));
			//}

			//if (LeftButtons != null && LeftButtons.Length > 0)
			//{
			//	verticalFormat += "-(insetC)-[button]";
			//	views["button"] = LeftButtons[0];
			//	metrics["insetC"] = NSNumber.FromNFloat(LeftButtonsInset.Top);
			//	metrics["insetBottom"] = NSNumber.FromNFloat(ContentInset.Bottom + LeftButtonsInset.Bottom);
			//}
			//else if (RightButtons != null && RightButtons.Length > 0)
			//{
			//	verticalFormat += "-(insetC)-[button]";
			//	views["button"] = RightButtons[0];
			//	metrics["insetC"] = NSNumber.FromNFloat(RightButtonsInset.Top);
			//	metrics["insetBottom"] = NSNumber.FromNFloat(ContentInset.Bottom + RightButtonsInset.Bottom);
			//}

			//if (ContentView != null)
			//{
			//	if (metrics["insetC"] == null)
			//	{
			//		metrics["insetBottom"] = NSNumber.FromNFloat(ContentInset.Bottom + ContentViewEdgeInsets.Bottom + (Divider ? DividerInset.Top + DividerInset.Bottom : 0));
			//	}
			//	else
			//	{
			//		metrics["insetC"] = NSNumber.FromNFloat((metrics["insetC"] as NSNumber).NFloatValue + ContentViewEdgeInsets.Bottom + (Divider ? DividerInset.Top + DividerInset.Bottom : 0));
			//	}
			//}
			//else if (TitleLabel != null)
			//{
			//	if (metrics["insetC"] == null)
			//	{
			//		metrics["insetBottom"] = NSNumber.FromNFloat(ContentInset.Bottom + TitleLabelInset.Bottom + (Divider ? DividerInset.Top + DividerInset.Bottom : 0));
			//	}
			//	else
			//	{
			//		metrics["insetC"] = NSNumber.FromNFloat((metrics["insetC"] as NSNumber).NFloatValue + TitleLabelInset.Bottom + (Divider ? DividerInset.Top + DividerInset.Bottom : 0));
			//	}
			//}
			//else if (metrics["insetC"] != null)
			//{
			//	metrics["insetC"] = NSNumber.FromNFloat((metrics["insetC"] as NSNumber).NFloatValue + ContentInset.Bottom + (Divider ? DividerInset.Top + DividerInset.Bottom : 0));	
			//}

			//if (views.Count > 0)
			//{
			//	verticalFormat += "-(insetBottom)-|";

			//	AddConstraints(Layout.Constraint(verticalFormat, 0, metrics, views));
			//}
		}

		public override void Prepare()
		{
			base.Prepare();
			this.SetDepthPreset(DepthPreset.Depth1);
			PulseAnimation = PulseAnimation.None;
			this.SetCornerRadiusPreset(CornerRadiusPreset.Radius1);
			prepareContainer();
		}

		internal void PrepareProperties(Toolbar toolbar, UIView contentView, Bar bottomBar)
		{
			this.Toolbar = toolbar;
			this.ContentView = contentView;
			this.BottomBar = bottomBar;
		}

		private void prepareContainer()
		{
			Container.ClipsToBounds = true;
			this.Layout(Container).Edges();
		}

		#endregion
	}
}
