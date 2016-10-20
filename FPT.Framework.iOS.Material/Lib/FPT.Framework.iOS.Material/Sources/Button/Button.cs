// MIT/X11 License
//
// Butto.cs
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
using CoreGraphics;
using CoreAnimation;
using Foundation;

namespace FPT.Framework.iOS.Material
{
	public class Button : UIButton
	{

		#region PROPERTIES

		public CAShapeLayer VisualLayer { get; private set; } = new CAShapeLayer();

		internal Pulse Pulse { get; private set; } = new Pulse();

		public PulseAnimation PulseAnimation
		{
			get
			{
				return Pulse.Animation;
			}
			set
			{
				Pulse.Animation = value;
			}
		}

		public UIColor PulseColor
		{
			get
			{
				return Pulse.Color;
			}
			set
			{
				Pulse.Color = value;
			}
		}

		public nfloat PulseOpacity
		{
			get
			{
				return Pulse.Opacity;
			}
			set
			{
				Pulse.Opacity = value;
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
					this.Layer.BackgroundColor = value.CGColor;
				}
			}
		}

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
				var Value = Convert.EdgeInsetsPresetToValue(mContentEdgeInsetsPreset);
				ContentEdgeInsets = new UIEdgeInsets(Value.Top, Value.Left, Value.Bottom, Value.Right);
			}
		}

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
				SetImage(value, UIControlState.Normal);
				SetImage(value, UIControlState.Highlighted);
			}
		}

		private String mTitle;
		public new String Title
		{
			get
			{
				return mTitle;
			}
			set
			{
				mTitle = value;
				SetTitle(value, UIControlState.Normal);
				SetTitle(value, UIControlState.Highlighted);
			}
		}

		private UIColor mTitleColor;
		public new UIColor TitleColor
		{
			get
			{
				return mTitleColor;
			}
			set
			{
				mTitleColor = value;
				SetTitleColor(value, UIControlState.Normal);
				SetTitleColor(value, UIControlState.Highlighted);
			}
		}

		#endregion

		#region CONSTRUCTORS

		public Button(Foundation.NSCoder coder) : base(coder)
		{
			Prepare();
		}

		public Button(CGRect frame) : base(frame)
		{
			Prepare();
		}

		public Button() : this(CGRect.Empty)
		{
		}

		public Button(UIImage image, UIColor tintColor = null) : this()
		{
			if (tintColor == null)
				tintColor = Color.Blue.Base;

			prepare(image, tintColor);
			Prepare();
		}

		public Button(String title, UIColor tintColor = null) : this()
		{
			if (tintColor == null)
				tintColor = Color.Blue.Base;

			prepare(title, tintColor);
			Prepare();
		}

		#endregion


		#region FUNCTIONS
		public override void LayoutSublayersOfLayer(CALayer layer)
		{
			base.LayoutSublayersOfLayer(layer);

			if (this.Layer != layer) return;

			this.LayoutShape();
			LayoutVisualLayer();
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			this.LayoutShadowPath();
		}

		public void pulse(CGPoint? point = null)
		{
			var p = point == null ? new CGPoint(this.Width() / 2, this.Height() / 2) : point.Value;
			Animation.pulseExpandAnimation(layer: Layer, visualLayer: VisualLayer, point: p, width: this.Width(), height: this.Height(), pulse: Pulse);
			Animation.Delay(0.35f, () =>
			{
				Animation.pulseContractAnimation(layer: Layer, visualLayer: VisualLayer, pulse: Pulse);
			});

			BringImageViewToFront();
		}

		public override void TouchesBegan(NSSet touches, UIEvent evt)
		{
			base.TouchesBegan(touches, evt);
			UITouch touch = touches.AnyObject as UITouch;
			Animation.pulseExpandAnimation(layer: Layer, visualLayer: VisualLayer, point: Layer.ConvertPointToLayer(point: touch.LocationInView(this), layer: Layer), width: this.Width(), height: this.Height(), pulse: Pulse);
			BringImageViewToFront();
		}

		public override void TouchesEnded(NSSet touches, UIEvent evt)
		{
			base.TouchesEnded(touches, evt);
			Animation.pulseContractAnimation(layer: Layer, visualLayer: VisualLayer, pulse: Pulse);
		}

		public override void TouchesCancelled(NSSet touches, UIEvent evt)
		{
			base.TouchesCancelled(touches, evt);
			Animation.pulseContractAnimation(layer: Layer, visualLayer: VisualLayer, pulse: Pulse);
		}

		public void BringImageViewToFront()
		{
			if (ImageView == null)
				return;

			BringSubviewToFront(ImageView);
		}

		public virtual void Prepare()
		{
			ContentScaleFactor = MaterialDevice.Scale;
			ContentEdgeInsetsPreset = EdgeInsetsPreset.None;
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

		private void prepare(UIImage image, UIColor tintColor)
		{
			this.Image = image;
			this.TintColor = tintColor;
		}

		private void prepare(string title, UIColor titleColor)
		{
			this.Title = title;
			this.TitleColor = titleColor;
		}

		#endregion
	}
}
