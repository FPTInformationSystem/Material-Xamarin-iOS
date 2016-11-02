// MIT/X11 License
//
// BottomTabBar.cs
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
using UIKit;

namespace FPT.Framework.iOS.Material
{

	public partial class Extensions
	{
		public static void SetTitleColor(this UITabBarItem tabBarItem, UIColor color, UIControlState state)
		{
			tabBarItem.SetTitleTextAttributes(new UITextAttributes()
			{
				TextColor = color
			}, state);
		}
	}

	public class BottomTabBar : UITabBar
	{

		#region PROPERTIES

		public override CoreGraphics.CGSize IntrinsicContentSize
		{
			get
			{
				return base.IntrinsicContentSize;
			}
		}

		public bool IsAlignedToParentAutomatically { get; set; } = true;

		public override UIColor BackgroundColor
		{
			get
			{
				return base.BackgroundColor;
			}
			set
			{
				base.BackgroundColor = value;
				BarTintColor = value;
			}
		}

		#endregion

		#region CONSTRUCTORS

		public BottomTabBar(CGRect frame) : base(frame)
		{
			Prepare();
		}

		public BottomTabBar() : this(CGRect.Empty) { }

		public BottomTabBar(NSCoder coder) : base(coder)
		{
			Prepare();
		}

		#endregion

		#region FUNCTIONS

		public override void LayoutSublayersOfLayer(CoreAnimation.CALayer layer)
		{
			base.LayoutSublayersOfLayer(layer);
			if (this.Layer == layer)
			{
				this.LayoutShape();
			}
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			this.LayoutShadowPath();

			if (Items != null)
			{
				foreach (var item in Items)
				{
					if (Device.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone)
					{
						if (item.Title == null)
						{
							nfloat inset = 7f;
							item.ImageInsets = new UIEdgeInsets(inset, 0, -inset, 0);
						}
						else
						{
							nfloat inset = 6f;
							item.ImageInsets = new UIEdgeInsets(inset, 0, -inset, 0);
							var offset = item.TitlePositionAdjustment;
							offset.Vertical = -inset;
							item.TitlePositionAdjustment = offset;
						}
					}
					else if (item.Title == null)
					{
						nfloat inset = 9f;
						item.ImageInsets = new UIEdgeInsets(inset, 0, -inset, 0);
					}
					else
					{
						nfloat inset = 3f;
						item.ImageInsets = new UIEdgeInsets(inset, 0, -inset, 0);
						var offset = item.TitlePositionAdjustment;
						offset.Vertical = -inset;
						item.TitlePositionAdjustment = offset;
					}
				}
			}

			this.Divider().Reload();
		}

		public override void MovedToSuperview()
		{
			base.MovedToSuperview();
			if (IsAlignedToParentAutomatically)
			{
				if (Superview != null)
				{
					Superview.Layout(this).Bottom().Horizontally();
				}
			}
		}

		public virtual void Prepare()
		{
			this.SetHeightPreset(HeightPreset.Normal);
			this.SetDepthPreset(DepthPreset.Depth1);
			this.SetDividerAlignment(DividerAlignment.Top);
			ContentScaleFactor = Device.Scale;
			BackgroundColor = Color.White;
			var image = Extensions.ImageWithColor(Color.Clear, new CGSize(1,1));
			ShadowImage = image;
			BackgroundImage = image;
		}

		#endregion
	}
}
