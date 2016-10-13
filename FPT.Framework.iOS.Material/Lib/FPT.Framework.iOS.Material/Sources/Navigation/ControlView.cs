// MIT/X11 License
//
// ControlView.cs
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
	public class ControlView : MaterialView
	{

		#region PROPERTIES

		public bool WillRenderView
		{
			get
			{
				return 0 < Width && 0 < Height;
			}
		}

		public MaterialEdgeInset ContentInsetPreset
		{
			get
			{
				return this.Grid().ContentInsetPreset;
			}
			set
			{
				this.Grid().ContentInsetPreset = value;
			}
		}

		public UIEdgeInsets ContentInset
		{
			get
			{
				return this.Grid().ContentInset;
			}
			set
			{
				this.Grid().ContentInset = value;
			}
		}

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
				Spacing = Convert.MaterialSpacingToValue(value);
			}
		}

		public nfloat Spacing
		{
			get
			{
				return this.Grid().Spacing;
			}
			set
			{
				this.Grid().Spacing = value;
			}
		}

		private nfloat mGridFactor = 24;
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

		/// ContentView that holds the any desired subviews.
		public MaterialView ContentView { get; private set; }

		/// Left side UIControls.
		private UIControl[] mLeftControls;
		public UIControl[] LeftControls
		{
			get
			{
				return mLeftControls;
			}
			set
			{
				foreach (var b in LeftControls)
				{
					b.RemoveFromSuperview();
				}

				mLeftControls = value;

				foreach (var b in LeftControls)
				{
					AddSubview(b);
				}
			}
		}

		/// Right side UIControls.
		private UIControl[] mRightControls;
		public UIControl[] RightControls
		{
			get
			{
				return mRightControls;
			}
			set
			{
				if (RightControls != null)
				{
					foreach (var b in RightControls)
					{
						b.RemoveFromSuperview();
					}
				}

				mRightControls = value;

				if (LeftControls != null)
				{
					foreach (var b in RightControls)
					{
						AddSubview(b);
					}
				}
			}
		}

		#endregion

		#region CONSTRUCTORS

		public ControlView(NSCoder coder) : base(coder) { }

		public ControlView(CGRect frame) : base(frame) { }

		public ControlView() : base(CGRect.Empty)
		{
			var frame = Frame;
			frame.Size = IntrinsicContentSize;
			Frame = frame;
		}

		public ControlView(UIControl[] leftControls = null, UIControl[] rightControls = null) : this()
		{
			prepareProperties(leftControls, rightControls);
		}

		#endregion

		#region FUNCTIONS

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			if (WillRenderView)
			{
				LayoutIfNeeded();
				var g = (int)(Width / GridFactor);
				var columns = g + 1;

				this.Grid().Views = new List<UIView>();
				this.Grid().Axis.Columns = columns;

				ContentView.Grid().Columns = columns;

				var v = LeftControls;
				if (v != null)
				{
					foreach (var c in v)
					{
						nfloat w = c.IntrinsicContentSize.Width;
						if (c is UIButton)
						{
							(c as UIButton).ContentEdgeInsets = UIEdgeInsets.Zero;

							var frame = c.Frame;
							frame.Height = Frame.Size.Height - ContentInset.Top - ContentInset.Bottom;
							c.Frame = frame;

							var q = (int)(w / GridFactor);
							c.Grid().Columns = q + 1;

							ContentView.Grid().Columns -= c.Grid().Columns;

							AddSubview(c);
							this.Grid().Views.Add(c);
						}
					}
				}
				AddSubview(ContentView);
				this.Grid().Views.Add(ContentView);

				v = RightControls;
				if (v != null)
				{
					foreach (var c in v)
					{
						nfloat w = c.IntrinsicContentSize.Width;
						if (c is UIButton)
						{
							(c as UIButton).ContentEdgeInsets = UIEdgeInsets.Zero;

							var frame = c.Frame;
							frame.Height = Frame.Size.Height - ContentInset.Top - ContentInset.Bottom;
							c.Frame = frame;

							var q = (int)(w / GridFactor);
							c.Grid().Columns = q + 1;

							ContentView.Grid().Columns -= c.Grid().Columns;

							AddSubview(c);
							this.Grid().Views.Add(c);
						}
					}
				}

				this.Grid().ContentInset = ContentInset;
				this.Grid().Spacing = Spacing;
				this.Grid().ReloadLayout();
				ContentView.Grid().ReloadLayout();
			}
		}

		public override CGSize IntrinsicContentSize
		{
			get
			{
				return new CGSize(Width, 44);
			}
		}

		/**
		Prepares the view instance when intialized. When subclassing,
		it is recommended to override the prepareView method
		to initialize property values and other setup operations.
		The super.prepareView method should always be called immediately
		when subclassing.
		*/
		public override void PrepareView()
		{
			base.PrepareView();
			SpacingPreset = MaterialSpacing.Spacing1;
			ContentInsetPreset = MaterialEdgeInset.Square1;
			AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
			ShadowPathAutoSizeEnabled = false;
			prepareContentView();
		}

		/**
		Used to trigger property changes that initializers avoid.
		- Parameter leftControls: An Array of UIControls that go on the left side.
		- Parameter rightControls: An Array of UIControls that go on the right side.
		*/
		internal void prepareProperties(UIControl[] leftControls, UIControl[] rightControls)
		{
			this.LeftControls = leftControls;
			this.RightControls = rightControls;
		}

		/// Prepares the contentView.
		private void prepareContentView()
		{
			ContentView = new MaterialView();
			ContentView.BackgroundColor = null;
			AddSubview(ContentView);
		}

		#endregion
	}
}
