// MIT/X11 License
//
// NavigationBar.cs
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
using UIKit;

namespace FPT.Framework.iOS.Material
{

	public enum NavigationBarStyle
	{
		Tiny, Default, Medium
	}

	public static partial class Extensions
	{
		public static UIStatusBarStyle StatusBarStyle(this UINavigationBar navigationBar)
		{
			return MaterialDevice.StatusBarStyle;
		}

		public static void SetStatusBarStyle(this UINavigationBar navigationBar, UIStatusBarStyle value)
		{
			MaterialDevice.StatusBarStyle = value;
		}
	}

	public class NavigationBar : UINavigationBar
	{

		#region PROPERTIES

		/// NavigationBarStyle value.
		public NavigationBarStyle NavigationBarStyle { get; set; } = NavigationBarStyle.Default;

		internal bool Animating { get; set; } = false;

		public bool WillRenderView
		{
			get
			{
				return 0 < Width && 0 < Height; 
			}
		}

		/// A preset wrapper around contentInset.
		private MaterialEdgeInset mContentInsetPreset = MaterialEdgeInset.None;
		public MaterialEdgeInset ContentInsetPreset
		{
			get
			{
				return mContentInsetPreset;
			}
			set
			{
				mContentInsetPreset = value;
				ContentInset = Convert.MaterialEdgeInsetToValue(mContentInsetPreset);
			}
		}

		/// A wrapper around contentInset.
		private UIEdgeInsets mContentInset = UIEdgeInsets.Zero;
		public UIEdgeInsets ContentInset
		{
			get
			{
				return mContentInset;
			}
			set
			{
				mContentInset = value;
				LayoutSubviews();
			}
		}

		/// A preset wrapper around spacing.
		private MaterialSpacing mSpacingPreset = MaterialSpacing.None;
		public MaterialSpacing SpacingPreset
		{
			get
			{
				return mSpacingPreset;
			}
			set
			{
				mSpacingPreset = value;
				this.Spacing = Convert.MaterialSpacingToValue(SpacingPreset);
			}
		}

		/// A wrapper around grid.spacing.
		private nfloat mSpacing = 0;
		public nfloat Spacing
		{
			get
			{
				return mSpacing;
			}
			set
			{
				mSpacing = value;
				LayoutSubviews();
			}
		}

		/// Grid cell factor.
		private nfloat mGridFactor = 24f;
		public nfloat GridFactor
		{
			get
			{
				return mGridFactor;
			}
			set
			{
				mGridFactor = value;
				System.Diagnostics.Debug.Assert(0 < GridFactor, "[Material Error: gridFactor must be greater than 0.]");
				LayoutSubviews();
			}
		}

		/**
		The back button image writes to the backIndicatorImage property and
		backIndicatorTransitionMaskImage property.
		*/
		public UIImage BackButtonImage
		{
			get
			{
				return BackIndicatorImage;
			}
			set
			{
				BackIndicatorImage = value;
				BackIndicatorTransitionMaskImage = value;
			}
		}

		public nfloat X
		{
			get
			{
				return Layer.Frame.X;
			}
			set
			{
				var frame = Layer.Frame;
				frame.X = value;
				Layer.Frame = frame;
			}
		}

		public nfloat Y
		{
			get
			{
				return Layer.Frame.Y;
			}
			set
			{
				var frame = Layer.Frame;
				frame.Y = value;
				Layer.Frame = frame;
			}
		}

		public nfloat Width
		{
			get
			{
				return Layer.Frame.Width;
			}
			set
			{
				var frame = Layer.Frame;
				frame.Width = value;
				Layer.Frame = frame;
			}
		}

		public nfloat Height
		{
			get
			{
				return Layer.Frame.Height;
			}
			set
			{
				var frame = Layer.Frame;
				frame.Height = value;
				Layer.Frame = frame;
			}
		}

		private UIColor mShadowColor;
		public UIColor ShadowColor
		{
			get
			{
				return mShadowColor;
			}
			set
			{
				mShadowColor = value;
				if (value != null)
				{
					Layer.ShadowColor = value.CGColor;
				}
			}
		}

		public CGSize ShadowOffset
		{
			get
			{
				return Layer.ShadowOffset;
			}
			set
			{
				Layer.ShadowOffset = value;
			}
		}

		public float ShadowOpacity
		{
			get
			{
				return Layer.ShadowOpacity;
			}
			set
			{
				Layer.ShadowOpacity = value;
			}
		}

		public nfloat ShadowRadius
		{
			get
			{
				return Layer.ShadowRadius;
			}
			set
			{
				Layer.ShadowRadius = value;
			}
		}

		private MaterialDepth mDepth;
		public MaterialDepth Depth
		{
			get
			{
				return mDepth;
			}
			set
			{
				mDepth = value;
				var depthValue = Convert.MaterialDepthToValue(value);
				ShadowOffset = depthValue.Offset;
				ShadowOpacity = depthValue.Opacity;
				ShadowRadius = depthValue.Radius;
			}
		}

		private MaterialBorder mBorderWidthPreset = MaterialBorder.None;
		public MaterialBorder BorderWidthPreset
		{
			get
			{
				return mBorderWidthPreset;
			}
			set
			{
				mBorderWidthPreset = value;
				BorderWidth = Convert.MaterialBorderToValue(BorderWidthPreset);
			}
		}

		public nfloat BorderWidth
		{
			get
			{
				return Layer.BorderWidth;
			}
			set
			{
				Layer.BorderWidth = value;
			}
		}

		public UIColor BorderColor
		{
			get
			{
				return Layer.BorderColor == null ? null : new UIColor(Layer.BorderColor);
			}
			set
			{
				if (value != null)
					Layer.BorderColor = value.CGColor;
			}
		}

		#endregion

		#region CONSTRUCTORS

		protected internal NavigationBar(IntPtr handle) : base(handle)
		{
		}

		public NavigationBar(NSCoder coder) : base(coder)
		{
			PrepareView();
		} 

		public NavigationBar(CGRect frame) : base(frame)
		{
			PrepareView();
		}

		public NavigationBar() : this (CGRect.Empty)
		{ 
		}

		#endregion

		#region FUNCTIONS

		public override CGSize IntrinsicContentSize
		{
			get
			{
				switch (NavigationBarStyle)
				{
					case NavigationBarStyle.Tiny:
							return new CGSize(MaterialDevice.Width, 32);
					case NavigationBarStyle.Default:
							return new CGSize(MaterialDevice.Width, 44);
					case NavigationBarStyle.Medium:
							return new CGSize(MaterialDevice.Width, 56);
					default:
						return default(CGSize);
				}
			}
		}

		public override CGSize SizeThatFits(CGSize size)
		{
			return IntrinsicContentSize;
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			if (TopItem != null)
			{
				layoutNavigationItem(TopItem);
			}

			if (BackItem != null)
			{
				layoutNavigationItem(BackItem);
			}
		}

		/**
		Lays out the UINavigationItem.
		- Parameter item: A UINavigationItem to layout.
		*/
		internal void layoutNavigationItem(UINavigationItem item)
		{
			if (WillRenderView)
			{
				prepareItem(item);

				var titleView = prepareTitleView(item);
				var contentView = prepareContentView(item);
				int g = (int) (Width / GridFactor);
				var columns = g + 1;

				var frame = titleView.Frame;
				frame.Location = CGPoint.Empty;
				frame.Size = IntrinsicContentSize;
				titleView.Frame = frame;
				titleView.Grid().Views = new List<UIView>();
				titleView.Grid().Axis.Columns = columns;

				contentView.Grid().Columns = columns;

				// leftControls
				var v = item.LeftControls();
				if (v != null)
				{
					foreach (var c in v)
					{
						nfloat w = c.IntrinsicContentSize.Width;
						if (c is UIButton)
						{
							(c as UIButton).ContentEdgeInsets = UIEdgeInsets.Zero;
						}

						frame = c.Frame;
						frame.Height = titleView.Frame.Height - ContentInset.Top - ContentInset.Bottom;
						c.Frame = frame;

						int q = (int)(w/ GridFactor);
						c.Grid().Columns = q + 1;

						contentView.Grid().Columns -= c.Grid().Columns;

						titleView.AddSubview(c);
						titleView.Grid().Views.Add(c);
					}
				}

				titleView.AddSubview(contentView);
				titleView.Grid().Views.Add(contentView);

				// rightControls
				v = item.RightControls();
				if (v != null)
				{
					foreach (var c in v)
					{
						nfloat w = c.IntrinsicContentSize.Width;
						if (c is UIButton)
						{
							(c as UIButton).ContentEdgeInsets = UIEdgeInsets.Zero;
						}

						frame = c.Frame;
						frame.Height = titleView.Frame.Height - ContentInset.Top - ContentInset.Bottom;
						c.Frame = frame;

						int q = (int)(w / GridFactor);
						c.Grid().Columns = q + 1;

						contentView.Grid().Columns -= c.Grid().Columns;

						titleView.AddSubview(c);
						titleView.Grid().Views.Add(c);
					}
				}

				titleView.Grid().ContentInset = ContentInset;
				titleView.Grid().Spacing = Spacing;
				titleView.Grid().ReloadLayout();

				// contentView alignment.
				if (!string.IsNullOrEmpty(item.Title()))
				{
					if (item.Titlelabel().Superview == null)
					{
						contentView.AddSubview(item.Titlelabel());
					}
					item.Titlelabel().Frame = contentView.Bounds;
				}
				else
				{
					item.Titlelabel().RemoveFromSuperview();
				}

				if (!string.IsNullOrEmpty(item.Detail()))
				{
					if (item.Detaillabel().Superview == null)
					{
						contentView.AddSubview(item.Detaillabel());
					}

					if (item.Titlelabel().Superview == null)
					{
						item.Detaillabel().Frame = contentView.Bounds;
					}
					else
					{
						item.Titlelabel().SizeToFit();
						item.Detaillabel().SizeToFit();

						nfloat diff = (contentView.Frame.Height - item.Titlelabel().Frame.Height - item.Detaillabel().Frame.Height) / 2;

						frame = item.Titlelabel().Frame;
						frame.Height += diff;
						frame.Width = contentView.Frame.Width;
						item.Titlelabel().Frame = frame;

						frame = item.Detaillabel().Frame;
						frame.Height += diff;
						frame.Width = contentView.Frame.Width;
						frame.Y = item.Titlelabel().Frame.Height;
						item.Detaillabel().Frame = frame;
					}
				}
				else
				{
					item.Detaillabel().RemoveFromSuperview();
				}

				contentView.Grid().ReloadLayout();
			}
		}

		/**
		Prepares the view instance when intialized. When subclassing,
		it is recommended to override the prepareView method
		to initialize property values and other setup operations.
		The super.prepareView method should always be called immediately
		when subclassing.
		*/
		public void PrepareView()
		{
			BarStyle = UIBarStyle.Black;
			Translucent = false;
			Depth = MaterialDepth.Depth1;
			SpacingPreset = MaterialSpacing.Spacing1;
			ContentInsetPreset = MaterialEdgeInset.Square1;
			ContentScaleFactor = MaterialDevice.Scale;
			BackButtonImage = MaterialIcon.CM.ArrowBack;
			var image = Extensions.ImageWithColor(MaterialColor.Clear, new CGSize(1, 1));
			ShadowImage = image;
			SetBackgroundImage(image, UIBarMetrics.Default);
			BackgroundColor = MaterialColor.White;
		}

		private void prepareItem(UINavigationItem item)
		{
			item.HidesBackButton = false;
			item.SetHidesBackButton(true, false);
		}

		/**
		Prepare the titleView.
		- Parameter item: A UINavigationItem to layout.
		- Returns: A UIView, which is the item.titleView.
		*/
		private UIView prepareTitleView(UINavigationItem item)
		{
			if (item.TitleView == null)
			{
				item.TitleView = new UIView(CGRect.Empty);
			}
			return item.TitleView;
		}

		/**
		Prepare the contentView.
		- Parameter item: A UINavigationItem to layout.
		- Returns: A UIView, which is the item.contentView.
		*/
		private UIView prepareContentView(UINavigationItem item)
		{
			if (item.ContentView() == null)
			{
				item.SetContentView(new UIView(CGRect.Empty));
			}
			item.ContentView().Grid().Axis.Direction = GridAxisDirection.Vertical;
			return item.ContentView();
		}

		#endregion
	}
}
