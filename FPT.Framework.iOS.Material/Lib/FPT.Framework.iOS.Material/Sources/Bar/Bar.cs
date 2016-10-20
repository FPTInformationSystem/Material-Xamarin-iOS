// MIT/X11 License
//
// Bar.cs
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

	public enum ContentViewAlignment
	{
		Any, Center
	}

	public class Bar : View
	{

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

		private ContentViewAlignment mContentViewAlignment = ContentViewAlignment.Any;
		public ContentViewAlignment ContentViewAlignment
		{
			get
			{
				return mContentViewAlignment;
			}
			set
			{
				mContentViewAlignment = value;
				LayoutSubviews();
			}
		}

		public EdgeInsetsPreset ContentEdgeInsetsPreset
		{
			get
			{
				return this.Grid().ContentEdgeInsetPreset;
			}
			set
			{
				this.Grid().ContentEdgeInsetPreset = value;
			}
		}

		public UIEdgeInsets ContentEdgeInsets
		{
			get
			{
				return this.Grid().ContentEdgeInset;
			}
			set
			{
				this.Grid().ContentEdgeInset = value;
			}
		}

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
				InterimSpace = Convert.InterimSpacePresetToValue(value);
			}
		}

		public nfloat InterimSpace
		{
			get
			{
				return this.Grid().InterimSpace;
			}
			set
			{
				this.Grid().InterimSpace = value;
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
				System.Diagnostics.Debug.Assert(0 < value, "[Material Error: gridFactor must be greater than 0.]");
				LayoutSubviews();
			}
		}

		public UIView ContentView { get; private set; } = new View();

		private List<UIView> mLeftViews = new List<UIView>();
		public List<UIView> LeftViews
		{
			get
			{
				return mLeftViews;
			}
			set
			{
				if (LeftViews != null)
				{
					foreach (var b in LeftViews)
					{
						b.RemoveFromSuperview();
					}
				}

				mLeftViews = value;

				LayoutSubviews();
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
				if (RightViews != null)
				{
					foreach (var b in RightViews)
					{
						b.RemoveFromSuperview();
					}
				}

				mRightViews = value;

				LayoutSubviews();
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
				if (CenterViews != null)
				{
					foreach (var b in CenterViews)
					{
						b.RemoveFromSuperview();
					}
				}

				LayoutSubviews();
			}
		}

		/**
		An initializer that initializes the object with a NSCoder object.
		- Parameter aDecoder: A NSCoder instance.
		*/
		public Bar(NSCoder coder) : base(coder) { }

		/**
		An initializer that initializes the object with a CGRect object.
		If AutoLayout is used, it is better to initilize the instance
		using the init() initializer.
		- Parameter frame: A CGRect instance.
		*/
		public Bar(CGRect frame) : base(frame) { }

		/// Basic initializer.
		public Bar() : base(CGRect.Empty)
		{
			var frame = Frame;
			frame.Size = IntrinsicContentSize;
			Frame = frame;
		}

		public Bar(List<UIView> leftViews = null, List<UIView> rightViews = null, List<UIView> centerViews = null) : base (CGRect.Empty)
		{
			this.LeftViews = leftViews ?? new List<UIView>();
			this.RightViews = rightViews ?? new List<UIView>();
			this.CenterViews = centerViews ?? new List<UIView>();
			var frame = Frame;
			frame.Size = IntrinsicContentSize;
			Frame = frame;
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			if (!WillLayout) return;

			Reload();
		}

		public void Reload()
		{
			var lc = 0;
			var rc = 0;
			var l = LeftViews.Count * InterimSpace;
			var r = RightViews.Count * InterimSpace;
			var p = this.Width() - l - r - ContentEdgeInsets.Left - ContentEdgeInsets.Right;
			var columns = (int)System.NMath.Ceiling(p / GridFactor);

			this.Grid().Begin();
			this.Grid().Views.Clear();
			this.Grid().Axis.Columns = columns;

			foreach (var v in LeftViews)
			{
				if (v is UIButton)
				{
					(v as UIButton).ContentEdgeInsets = UIEdgeInsets.Zero;
					(v as UIButton).TitleEdgeInsets = UIEdgeInsets.Zero;
				}

				v.SetWidth(v.IntrinsicContentSize.Width);
				v.SizeToFit();
				v.Grid().Columns = ((int)NMath.Ceiling(v.Width()/GridFactor)) + 2;

				lc += v.Grid().Columns;

				this.Grid().Views.Add(v);
			}

			this.Grid().Views.Add(ContentView);

			foreach (var v in RightViews)
			{
				if (v is UIButton)
				{
					(v as UIButton).ContentEdgeInsets = UIEdgeInsets.Zero;
					(v as UIButton).TitleEdgeInsets = UIEdgeInsets.Zero;
				}

				v.SetWidth(v.IntrinsicContentSize.Width);
				v.SizeToFit();
				v.Grid().Columns = ((int)NMath.Ceiling(v.Width() / GridFactor)) + 2;

				rc += v.Grid().Columns;

				this.Grid().Views.Add(v);
			}

			ContentView.Grid().Begin();
			ContentView.Grid().Views = CenterViews;

			if (ContentViewAlignment == ContentViewAlignment.Center)
			{
				if (lc < rc)
				{
					ContentView.Grid().Columns = columns - 2 * rc;
					ContentView.Grid().Offset.Columns = rc - lc;
				}
				else
				{
					ContentView.Grid().Columns = columns - 2 * lc;
					ContentView.Grid().Offset.Columns = 0;
					if (RightViews[0] != null)
					{
						RightViews[0].Grid().Offset.Columns = lc - rc;
					}
				}
			}
			else
			{
				ContentView.Grid().Columns = columns - lc - rc;
			}

			this.Grid().Commit();
			ContentView.Grid().Commit();


		}

		public override void Prepare()
		{
			base.Prepare();
			this.SetHeightPreset(HeightPreset.Default);
			AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
			InterimSpacePreset = InterimSpacePreset.InterimSpacing3;
			this.ContentEdgeInsetsPreset = EdgeInsetsPreset.Square1;
			prepareContentView();
		}

		/// Prepares the contentView.
		private void prepareContentView()
		{
			ContentView.BackgroundColor = null;
		}
	}
}
