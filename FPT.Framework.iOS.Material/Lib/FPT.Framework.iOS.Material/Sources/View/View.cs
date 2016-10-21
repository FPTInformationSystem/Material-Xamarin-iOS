// MIT/X11 License
//
// View.cs
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
using UIKit;
using CoreAnimation;
using CoreGraphics;
using Foundation;

namespace FPT.Framework.iOS.Material
{
	public class View : UIView
	{

		#region PROPERTIES

		public CAShapeLayer VisualLayer { get; private set; } = new CAShapeLayer();

		private UIImage mImage;
		public UIImage Image
		{
			get
			{
				return mImage;
			}
			set
			{
				mImage = value;
				if (value != null)
				{
					VisualLayer.Contents = value.CGImage;
				}
			}
		}

		public CGRect ContentsRect
		{
			get
			{
				return VisualLayer.ContentsRect;
			}
			set
			{
				VisualLayer.ContentsRect = value;
			}
		}

		public nfloat ContentsScale
		{
			get
			{
				return VisualLayer.ContentsScale;
			}
			set
			{
				VisualLayer.ContentsScale = value;
			}
		}

		private Gravity mContentsGravityPreset;
		public Gravity ContentsGravityPreset
		{
			get
			{
				return mContentsGravityPreset;
			}
			set
			{
				mContentsGravityPreset = value;
				ContentsGravity = Convert.GravityToValue(value);
			}
		}

		public string ContentsGravity
		{
			get
			{
				return VisualLayer.ContentsGravity;
			}
			set
			{
				VisualLayer.ContentsGravity = value;
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
				if (value != null)
				{
					Layer.BackgroundColor = value.CGColor;
				}
			}
		}

		#endregion

		#region CONSTRUCTORS

		public View(NSCoder coder) : base(coder)
		{
			ContentsGravityPreset = Gravity.ResizeAspectFill;
			Prepare();
		}

		public View(CGRect frame) : base(frame)
		{
			ContentsGravityPreset = Gravity.ResizeAspectFill;
			Prepare();
		}

		public View() : this(CGRect.Empty) { }

		#endregion

		#region FUNCTIONS

		public override void LayoutSublayersOfLayer(CALayer layer)
		{
			base.LayoutSublayersOfLayer(layer);
			if (this.Layer == layer)
			{
				this.LayoutShape();
				this.LayoutVisualLayer();
			}
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			this.LayoutShadowPath();
		}

		public virtual void Prepare()
		{
			ContentScaleFactor = Device.Scale;
			BackgroundColor = Color.White;
			PrepareVisualLayer();
		}

		internal void PrepareVisualLayer()
		{
			VisualLayer.ZPosition = 0;
			VisualLayer.MasksToBounds = true;
			Layer.AddSublayer(VisualLayer);
		}

		internal void LayoutVisualLayer()
		{
			VisualLayer.Frame = Bounds;
			VisualLayer.CornerRadius = this.CornerRadius();
		}

		#endregion
	}
}
