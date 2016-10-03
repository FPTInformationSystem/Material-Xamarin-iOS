// MIT/X11 License
//
// MaterialCollectionViewCell.cs
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
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;
using UIView = FPT.Framework.iOS.Material.Extension.UIView;

namespace FPT.Framework.iOS.Material
{
	public class MaterialCollectionViewCellAnimationDelegate : CAAnimationDelegate
	{
		MaterialCollectionViewCell mParent;

		public MaterialCollectionViewCellAnimationDelegate(MaterialCollectionViewCell parent)
		{
			mParent = parent;
		}

		public override void AnimationStarted(CAAnimation anim)
		{
			if (mParent.Delegate is MaterialAnimationDelegate)
			{
				(mParent.Delegate as MaterialAnimationDelegate).materialAnimationDidStart(anim);
			}
		}

		public override void AnimationStopped(CAAnimation anim, bool finished)
		{
			if (anim is CAPropertyAnimation)
			{
				if (anim is CABasicAnimation)
				{
					var b = (CABasicAnimation)anim;
					var v = b.To;
					if (v != null)
					{
						var k = b.KeyPath;
						if (k != null)
						{
							mParent.Layer.SetValueForKey(v, new NSString(k));
							mParent.Layer.RemoveAnimation(k);
						}
					}
				}
			}
			else if (anim is CAAnimationGroup)
			{
				foreach (var x in ((CAAnimationGroup)anim).Animations)
				{
					AnimationStopped(anim: x, finished: true);
				}
			}
		}
	}

	public class MaterialCollectionViewCell : UICollectionViewCell
	{

		#region VARIABLES

		private Queue<CAShapeLayer> mPulseLayers = new Queue<CAShapeLayer>();

		#endregion

		#region PROPERTIES

		private UIView mContentView;
		public override UIKit.UIView ContentView
		{
			get
			{
				return mContentView;
			}
		}

		public MaterialCollectionViewCellAnimationDelegate AnimationDelegate { get; set; }

		private CAShapeLayer VisualLayer { get; set; } = new CAShapeLayer();

		public MaterialDelegate Delegate { get; set; }

		private Queue<CAShapeLayer> PulseLayer
		{
			get
			{
				return mPulseLayers;
			}
			set
			{
				mPulseLayers = value;
			}
		}

		public nfloat PulseOpacity { get; set; } = 0.25f;

		public UIColor PulseColor { get; set; } = MaterialColor.Grey.Base;

		private PulseAnimation mPulseAnimation = PulseAnimation.AtPointWithBacking;
		public PulseAnimation PulseAnimation
		{
			get
			{
				return mPulseAnimation;
			}
			set
			{
				mPulseAnimation = value;
				VisualLayer.MasksToBounds = mPulseAnimation != PulseAnimation.CenterRadialBeyondBounds;
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
				if (mImage != null)
					VisualLayer.Contents = mImage.CGImage;
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

		private MaterialGravity mContentsGravityPreset;
		public MaterialGravity ContentsGravityPreset
		{
			get
			{
				return mContentsGravityPreset;
			}
			set
			{
				mContentsGravityPreset = value;
				ContentsGravity = Convert.MaterialGravityToValue(mContentsGravityPreset);
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

		public MaterialEdgeInset ContentInsetPreset
		{
			get
			{
				return mContentView.Grid.ContentInsetPreset;
			}
			set
			{
				mContentView.Grid.ContentInsetPreset = value;
			}
		}

		public UIEdgeInsets ContentInset
		{
			get
			{

				return mContentView.Grid.ContentInset;
			}
			set
			{
				mContentView.Grid.ContentInset = value;
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
				mContentView.Grid.Spacing = Convert.MaterialSpacingToValue(SpacingPreset);
			}
		}

		public nfloat Spacing
		{
			get
			{
				return mContentView.Grid.Spacing;
			}
			set
			{
				mContentView.Grid.Spacing = value;
			}
		}

		public bool mMasksToBounds
		{
			get
			{
				return Layer.MasksToBounds;
			}
			set
			{
				Layer.MasksToBounds = value;
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
				if (BackgroundColor != null)
				{
					Layer.BackgroundColor = BackgroundColor.CGColor;
				}
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
				if (Shape != MaterialShape.None)
				{
					frame.Height = value;
				}
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
				if (Shape != MaterialShape.None)
				{
					frame.Width = value;
				}
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

		public CGPath ShadowPath
		{
			get
			{
				return Layer.ShadowPath;
			}
			set
			{
				Layer.ShadowPath = value;
			}
		}

		private bool mShadowPathAutoSizeEnabled = true;
		public bool ShadowPathAutoSizeEnabled
		{
			get
			{
				return mShadowPathAutoSizeEnabled;
			}
			set
			{
				mShadowPathAutoSizeEnabled = value;
				if (mShadowPathAutoSizeEnabled)
				{
					layoutShadowPath();
				}
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
				layoutShadowPath();
			}
		}

		public MaterialRadius CornerRadiusPreset { get; set; }

		public nfloat CornerRadius
		{
			get
			{
				return Layer.CornerRadius;
			}
			set
			{
				Layer.CornerRadius = value;
				layoutShadowPath();
				if (Shape == MaterialShape.Circle)
				{
					Shape = MaterialShape.None;
				}
			}
		}

		private MaterialShape mShape;
		public MaterialShape Shape
		{
			get
			{
				return mShape;
			}
			set
			{
				mShape = value;
				if (mShape != MaterialShape.None)
				{
					var frame = Frame;
					if (Width < Height)
					{
						frame.Width = Height;
					}
					else
					{
						frame.Height = Width;
					}
					Frame = frame;
					layoutShadowPath();
				}
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

		public CGPoint Position
		{
			get
			{
				return Layer.Position;
			}
			set
			{
				Layer.Position = value;
			}
		}

		public nfloat ZPosition
		{
			get
			{
				return Layer.ZPosition;
			}
			set
			{
				Layer.ZPosition = value;
			}
		}

		#endregion

		#region CONSTRUCTORS

		public MaterialCollectionViewCell(Foundation.NSCoder coder) : base(coder)
		{
			Depth = MaterialDepth.None;
			CornerRadiusPreset = MaterialRadius.None;
			Shape = MaterialShape.None;
			ContentsGravityPreset = MaterialGravity.ResizeAspectFill;
			prepareView();
		}

		public MaterialCollectionViewCell(CGRect frame) : base(frame)
		{
			Depth = MaterialDepth.None;
			CornerRadiusPreset = MaterialRadius.None;
			Shape = MaterialShape.None;
			ContentsGravityPreset = MaterialGravity.ResizeAspectFill;
			prepareView();
		}

		public MaterialCollectionViewCell() : this(CGRect.Empty)
		{
		}

		#endregion

		#region OVERRIDE FUNCTIONS


		public override void LayoutSublayersOfLayer(CALayer layer)
		{
			base.LayoutSublayersOfLayer(layer);
			if (this.Layer == layer)
			{
				layoutShape();
				layoutVisualLayer();
			}
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			layoutShadowPath();
		}

		public void Animate(CAAnimation animation)
		{
			animation.WeakDelegate = new MaterialCollectionViewCellAnimationDelegate(this);
			if (animation is CABasicAnimation)
			{
				var a = (CABasicAnimation)animation;
				a.From = (Layer.PresentationLayer == null ? Layer : Layer.PresentationLayer).ValueForKey(new NSString(a.KeyPath));
			}
			if (animation is CAPropertyAnimation)
			{
				var a = (CAPropertyAnimation)animation;
				Layer.AddAnimation(a, a.KeyPath);
			}
			else if (animation is CAAnimationGroup)
			{
				var a = (CAAnimationGroup)animation;
				Layer.AddAnimation(a, null);
			}
			else if (animation is CATransition)
			{
				var a = (CATransition)animation;
				Layer.AddAnimation(a, CALayer.Transition);
			}

		}

		public void pulse(CGPoint? point = null)
		{
			var p = point == null ? new CGPoint(Width / 2, Height / 2) : point.Value;
			MaterialAnimation.pulseExpandAnimation(layer: Layer, visualLayer: VisualLayer, pulseColor: PulseColor, pulseOpacity: PulseOpacity, point: p, width: Width, height: Height, pulseLayers: ref mPulseLayers, pulseAnimation: PulseAnimation);
			MaterialAnimation.Delay(0.35f, () =>
			{
				MaterialAnimation.pulseContractAnimation(layer: Layer, visualLayer: VisualLayer, pulseColor: PulseColor, pulseLayers: ref mPulseLayers, pulseAnimation: PulseAnimation);
			});
		}

		#endregion

		#region FUNCTIONS

		public virtual void prepareView()
		{
			ContentScaleFactor = MaterialDevice.Scale;
			prepareVisualLayer();

			//This is a trick for add propery Grid to ContentView
			prepareContentView();
		}

		internal void prepareVisualLayer()
		{
			VisualLayer.ZPosition = 0;
			VisualLayer.MasksToBounds = true;
			Layer.AddSublayer(VisualLayer);
		}

		internal void prepareContentView()
		{
			mContentView = new UIView(base.ContentView.Bounds);
			mContentView.AutoresizingMask = UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight;
			base.ContentView.AddSubview(mContentView);
		}

		internal void layoutVisualLayer()
		{
			VisualLayer.Frame = Bounds;
			VisualLayer.CornerRadius = CornerRadius;
		}

		internal void layoutShape()
		{
			if (Shape == MaterialShape.Circle)
			{
				var w = Width / 2;
				if (w != CornerRadius)
				{
					CornerRadius = w;
				}
			}
		}

		internal void layoutShadowPath()
		{
			if (ShadowPathAutoSizeEnabled)
			{
				if (Depth == MaterialDepth.None)
				{
					ShadowPath = null;
				}
				else if (ShadowPath == null)
				{
					ShadowPath = UIBezierPath.FromRoundedRect(rect: Bounds, cornerRadius: CornerRadius).CGPath;
				}
				else
				{
					Animate(MaterialAnimation.ShadowPath(UIBezierPath.FromRoundedRect(rect: Bounds, cornerRadius: CornerRadius).CGPath, duration: 0));
				}
			}
		}

		#endregion
	}
}
