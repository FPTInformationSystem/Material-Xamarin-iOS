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

	public class NavigationBar : UINavigationBar
	{

		#region PROPERTIES

		internal bool Animating { get; set; } = false;

		public bool WillLayout
		{
			get
			{
				return 0 < this.Width() && 0 < this.Height() && Superview != null;
			}
		}

		public override CGSize IntrinsicContentSize
		{
			get
			{
				return new CGSize(this.Width(), this.Height());
			}
		}

		/// A preset wrapper around contentInset.
		private EdgeInsetsPreset mContentEdgeInsetsPreset = EdgeInsetsPreset.None;
		public EdgeInsetsPreset ContentEdgeInsetsPreset
		{
			get
			{
				return mContentEdgeInsetsPreset;
			}
			set
			{
				mContentEdgeInsetsPreset = value;
				ContentEdgeInsets = Convert.EdgeInsetsPresetToValue(mContentEdgeInsetsPreset);
			}
		}

		/// A wrapper around contentInset.
		private UIEdgeInsets mContentInset = UIEdgeInsets.Zero;
		public UIEdgeInsets ContentEdgeInsets
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
		private InterimSpacePreset mInterimSpacePreset = InterimSpacePreset.None;
		public InterimSpacePreset InterimSpacePreset
		{
			get
			{
				return mInterimSpacePreset;
			}
			set
			{
				mInterimSpacePreset = value;
				this.InterimSpace  = Convert.InterimSpacePresetToValue(InterimSpacePreset);
			}
		}

		/// A wrapper around grid.spacing.
		private nfloat mInterimSpace = 0;
		public nfloat InterimSpace 
		{
			get
			{
				return mInterimSpace;
			}
			set
			{
				mInterimSpace = value;
				LayoutSubviews();
			}
		}

		/// Grid cell factor.
		private nfloat mGridFactor = 12f;
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

		protected internal NavigationBar(IntPtr handle) : base(handle)
		{
			Prepare();
		}

		public NavigationBar(NSCoder coder) : base(coder)
		{
			Prepare();
		} 

		public NavigationBar(CGRect frame) : base(frame)
		{
			Prepare();
		}

		public NavigationBar() : this (CGRect.Empty)
		{ 
		}

		#endregion

		#region FUNCTIONS

		public override CGSize SizeThatFits(CGSize size)
		{
			return IntrinsicContentSize;
		}

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

			if (TopItem != null)
			{
				layoutNavigationItem(TopItem);
			}

			if (BackItem != null)
			{
				layoutNavigationItem(BackItem);
			}

			this.Divider().Reload();
		}

		public override void PushNavigationItem(UINavigationItem item, bool animated)
		{
			base.PushNavigationItem(item, animated);
			layoutNavigationItem(item);
		}

		/**
		Lays out the UINavigationItem.
		- Parameter item: A UINavigationItem to layout.
		*/
		internal void layoutNavigationItem(UINavigationItem item)
		{
			if (WillLayout)
			{
				prepareItem(item);
				prepareTitleView(item);

				var frame = item.TitleView.Frame;
				frame.Location = CGPoint.Empty;
				frame.Size = IntrinsicContentSize;
				item.TitleView.Frame = frame;

				var lc = 0;
				var rc = 0;
				var l = ((nfloat)(item.LeftViews().Count) * InterimSpace);
				var r = ((nfloat)(item.RightViews().Count) * InterimSpace);
				var p = this.Width() - l - r - ContentEdgeInsets.Left - ContentEdgeInsets.Right;
				var columns = (int)(NMath.Ceiling(p / GridFactor));

				item.TitleView.Grid().Begin();
				item.TitleView.Grid().Views.Clear();
				item.TitleView.Grid().Axis.Columns = columns;

				foreach (var v in item.LeftViews())
				{
					if (v is UIButton)
					{
						((UIButton)v).ContentEdgeInsets = UIEdgeInsets.Zero;
						((UIButton)v).TitleEdgeInsets = UIEdgeInsets.Zero;
					}

					v.SetWidth(v.IntrinsicContentSize.Width);
					v.SizeToFit();
					v.Grid().Columns = ((int)NMath.Ceiling(v.Width() / GridFactor)) + 2;

					lc += v.Grid().Columns;

					item.TitleView.Grid().Views.Add(v);
				}

				item.TitleView.Grid().Views.Add(item.ContentView());

				foreach (var v in item.RightViews())
				{
					if (v is UIButton)
					{
						((UIButton)v).ContentEdgeInsets = UIEdgeInsets.Zero;
						((UIButton)v).TitleEdgeInsets = UIEdgeInsets.Zero;
					}

					v.SetWidth(v.IntrinsicContentSize.Width);
					v.SizeToFit();
					v.Grid().Columns = ((int)NMath.Ceiling(v.Width() / GridFactor)) + 2;

					rc += v.Grid().Columns;

					item.TitleView.Grid().Views.Add(v);
				}

				item.ContentView().Grid().Begin();

				if (item.ContentViewAlignment() == ContentViewAlignment.Center)
				{
					if (lc < rc)
					{
						item.ContentView().Grid().Columns = columns - 2 * rc;
						item.ContentView().Grid().Offset.Columns = rc - lc;
					}
					else
					{
						item.ContentView().Grid().Columns = columns - 2 * lc;
						item.ContentView().Grid().Offset.Columns = 0;
						if (item.RightViews().Count > 0)
						{
							item.RightViews()[0].Grid().Offset.Columns = lc - rc;
						}
					}
				}
				else
				{
					item.ContentView().Grid().Columns = columns - lc - rc;
				}

				item.TitleView.Grid().InterimSpace = InterimSpace;
				item.TitleView.Grid().ContentEdgeInsets = ContentEdgeInsets;
				item.TitleView.Grid().Commit();
				item.ContentView().Grid().Commit();

				// contentView alignment.
				if (!string.IsNullOrEmpty(item.Title()))
				{
					if (item.Titlelabel().Superview == null)
					{
						item.ContentView().AddSubview(item.Titlelabel());
					}
					item.Titlelabel().Frame = item.ContentView().Bounds;
				}
				else
				{
					item.Titlelabel().RemoveFromSuperview();
				}

				if (!string.IsNullOrEmpty(item.Detail()))
				{
					if (item.DetailLabel().Superview == null)
					{
						item.ContentView().AddSubview(item.DetailLabel());
					}

					if (item.Titlelabel().Superview == null)
					{
						item.DetailLabel().Frame = item.ContentView().Bounds;
					}
					else
					{
						item.Titlelabel().SizeToFit();
						item.DetailLabel().SizeToFit();

						nfloat diff = (item.ContentView().Frame.Height - item.Titlelabel().Frame.Height - item.DetailLabel().Frame.Height) / 2;

						item.Titlelabel().SetHeight(item.Titlelabel().Height() + diff);
						item.Titlelabel().SetWidth(item.ContentView().Width());

						item.DetailLabel().SetHeight(item.DetailLabel().Height() + diff);
						item.DetailLabel().SetWidth(item.ContentView().Width());
						item.DetailLabel().SetY(item.Titlelabel().Height());
					}
				}
				else
				{
					item.DetailLabel().RemoveFromSuperview();
				}
			}
		}

		/**
		Prepares the view instance when intialized. When subclassing,
		it is recommended to override the prepareView method
		to initialize property values and other setup operations.
		The super.prepareView method should always be called immediately
		when subclassing.
		*/
		public virtual void Prepare()
		{
			BarStyle = UIBarStyle.Black;
			Translucent = false;
			this.SetDepthPreset(DepthPreset.Depth1);
			this.InterimSpacePreset = InterimSpacePreset.InterimSpacing3;
			ContentEdgeInsetsPreset = EdgeInsetsPreset.Square1;
			ContentScaleFactor = Device.Scale;
			BackButtonImage = Icon.ArrowBack;
			var image = Extensions.ImageWithColor(Color.Clear, new CGSize(1, 1));
			ShadowImage = image;
			SetBackgroundImage(image, UIBarMetrics.Default);
			BackgroundColor = Color.White;
		}

		private void prepareItem(UINavigationItem item)
		{
			item.HidesBackButton = false;
			item.SetHidesBackButton(true, false);
		}

		/**
		Prepare the titleView.
		- Parameter item: A UINavigationItem to layout.
		*/
		private void prepareTitleView(UINavigationItem item)
		{
			if (item.TitleView == null)
			{
				item.TitleView = new UIView(CGRect.Empty);
			}
		}

		#endregion
	}
}
