// MIT/X11 License
//
// MaterialCollectionView.cs
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
using UIKit;
using CoreAnimation;

namespace FPT.Framework.iOS.Material
{
	public class CollectionViewCell : UICollectionViewCell
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

		public CGRect ContentsCenter
		{
			get
			{
				return VisualLayer.ContentsCenter;
			}
			set
			{
				VisualLayer.ContentsCenter = value;
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

		public EdgeInsetsPreset ContentEdgeInsetsPreset
		{
			get
			{
				return ContentView.Grid().ContentEdgeInsetPreset;
			}
			set
			{
				ContentView.Grid().ContentEdgeInsetPreset = value;
			}
		}

		public UIEdgeInsets ContentEdgeInsets
		{
			get
			{
				return ContentView.Grid().ContentEdgeInsets;
			}
			set
			{
				ContentView.Grid().ContentEdgeInsets = value;
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
				return ContentView.Grid().InterimSpace;
			}

			set
			{
				ContentView.Grid().InterimSpace = value;
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

		protected CollectionViewCell(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
			this.Prepare();
		}

		public CollectionViewCell(Foundation.NSCoder coder) : base(coder)
		{
			ContentsGravityPreset = Gravity.ResizeAspectFill;
			this.Prepare();
		}

		public CollectionViewCell(CGRect frame) : base(frame)
		{
			ContentsGravityPreset = Gravity.ResizeAspectFill;
			this.Prepare();
		}

		public CollectionViewCell() : this(CGRect.Empty) { }

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

		public void pulse(CGPoint? point = null)
		{
			var p = point == null ? new CGPoint(this.Width() / 2, this.Height() / 2) : point.Value;
			Animation.pulseExpandAnimation(layer: Layer, visualLayer: VisualLayer, point: p, width: this.Width(), height: this.Height(), pulse: Pulse);
			Animation.Delay(0.35f, () =>
			{
				Animation.pulseContractAnimation(layer: Layer, visualLayer: VisualLayer, pulse: Pulse);
			});
		}

		public override void TouchesBegan(Foundation.NSSet touches, UIEvent evt)
		{
			base.TouchesBegan(touches, evt);
			UITouch touch = touches.AnyObject as UITouch;
			Animation.pulseExpandAnimation(layer: Layer, visualLayer: VisualLayer, point: Layer.ConvertPointToLayer(point: touch.LocationInView(this), layer: Layer), width: this.Width(), height: this.Height(), pulse: Pulse);
		}

		public override void TouchesEnded(Foundation.NSSet touches, UIEvent evt)
		{
			base.TouchesEnded(touches, evt);
			Animation.pulseContractAnimation(layer: Layer, visualLayer: VisualLayer, pulse: Pulse);
		}

		public override void TouchesCancelled(Foundation.NSSet touches, UIEvent evt)
		{
			base.TouchesCancelled(touches, evt);
			Animation.pulseContractAnimation(layer: Layer, visualLayer: VisualLayer, pulse: Pulse);
		}

		public virtual void Prepare()
		{
			ContentScaleFactor = Device.Scale;
			PrepareVisualLayer();
		}

		internal void PrepareVisualLayer()
		{
			VisualLayer.ZPosition = 0;
			VisualLayer.MasksToBounds = true;
			Layer.AddSublayer(VisualLayer);
			CAShapeLayer test = new CAShapeLayer();
		}

		internal void LayoutVisualLayer()
		{
			VisualLayer.Frame = Bounds;
			VisualLayer.CornerRadius = this.CornerRadius();
		}

		#endregion
	}
}
