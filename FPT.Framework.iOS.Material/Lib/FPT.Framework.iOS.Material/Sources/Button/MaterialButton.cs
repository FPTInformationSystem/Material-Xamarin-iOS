using System;
using System.Collections.Generic;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;

namespace FPT.Framework.iOS.Material
{
	public class MaterialButton : UIButton
	{
		public class MaterialButtonAnimationDelegate : CAAnimationDelegate
		{
			MaterialButton mParent;

			public MaterialButtonAnimationDelegate(MaterialButton parent)
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

		#region VARIABLES
		//private MaterialButtonAnimationDelegate mAnimationDelegate;

		private CAShapeLayer mVisualLayer = new CAShapeLayer();
		private MaterialDelegate mDelegate;
		private Queue<CAShapeLayer> mPulseLayers = new Queue<CAShapeLayer>();
		private nfloat mPulseOpacity = 0.25f;
		private UIColor mPulseColor = MaterialColor.Grey.Base;
		private PulseAnimation mPulseAnimation = PulseAnimation.AtPointWithBacking;
		private UIColor mShadowColor;
		private bool mShadowPathAutoSizeEnabled = true;
		private MaterialDepth mDepth = MaterialDepth.None;
		private MaterialRadius mCornerRadiusPreset = MaterialRadius.None;
		private MaterialShape mShape = MaterialShape.None;
		private MaterialBorder mBorderWidthPreset = MaterialBorder.None;
		private MaterialEdgeInset mContentEdgeInsetsPreset;
		#endregion

		#region PROPERTIES
		//public MaterialButtonAnimationDelegate AnimationDelegate
		//{
		//	get
		//	{
		//		return mAnimationDelegate;
		//	}
		//	set
		//	{
		//		mAnimationDelegate = value;
		//	}
		//}

		public CAShapeLayer VisualLayer
		{
			get
			{
				return mVisualLayer;
			}
			private set
			{
				mVisualLayer = value;
			}
		}

		public MaterialDelegate Delegate
		{
			get
			{
				return mDelegate;
			}
			private set
			{
				mDelegate = value;
			}
		}

		public Queue<CAShapeLayer> PulseLayers
		{
			get
			{
				return mPulseLayers;
			}
			private set
			{
				mPulseLayers = value;
			}
		}

		public nfloat PulseOpacity
		{
			get
			{
				return mPulseOpacity;
			}
			set
			{
				mPulseOpacity = value;
			}
		}

		public UIColor PulseColor
		{
			get
			{
				return mPulseColor;
			}
			set
			{
				mPulseColor = value;
			}
		}

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

		public bool MasksToBounds
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
				Layer.BackgroundColor = BackgroundColor.CGColor;
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

		public MaterialRadius CornerRadiusPreset
		{
			get
			{
				return mCornerRadiusPreset;
			}
			set
			{
				mCornerRadiusPreset = value;

			}
		}

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
				if (Shape != MaterialShape.Circle)
				{
					Shape = MaterialShape.None;
				}
			}
		}

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

		public MaterialEdgeInset ContentEdgeInsetsPreset
		{
			get
			{
				return mContentEdgeInsetsPreset;
			}
			set
			{
				mContentEdgeInsetsPreset = value;
				var Value = Convert.MaterialEdgeInsetToValue(mContentEdgeInsetsPreset);
				ContentEdgeInsets = new UIEdgeInsets(Value.Top, Value.Left, Value.Bottom, Value.Right);
			}
		}

		#endregion

		#region CONSTRUCTORS

		public MaterialButton() : this(CGRect.Empty)
		{
		}

		public MaterialButton(Foundation.NSCoder coder) : base(coder)
		{
			ContentEdgeInsetsPreset = MaterialEdgeInset.None;
			prepareView();
		}

		public MaterialButton(CGRect frame) : base(frame)
		{
			ContentEdgeInsetsPreset = MaterialEdgeInset.None;
			prepareView();
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

		public override UIEdgeInsets AlignmentRectInsets
		{
			get
			{
				return UIEdgeInsets.Zero;
			}
		}

		public void Animate(CAAnimation animation)
		{
			animation.WeakDelegate = new MaterialButtonAnimationDelegate(this);
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

		public override void TouchesBegan(Foundation.NSSet touches, UIEvent evt)
		{
			base.TouchesBegan(touches, evt);
			UITouch touch = touches.AnyObject as UITouch;
			MaterialAnimation.pulseExpandAnimation(layer: Layer, visualLayer: VisualLayer, pulseColor: PulseColor, pulseOpacity: PulseOpacity, point: Layer.ConvertPointToLayer(point: touch.LocationInView(this), layer: Layer), width: Width, height: Height, pulseLayers: ref mPulseLayers, pulseAnimation: PulseAnimation);
		}

		public override void TouchesEnded(Foundation.NSSet touches, UIEvent evt)
		{
			base.TouchesEnded(touches, evt);
			MaterialAnimation.pulseContractAnimation(layer: Layer, visualLayer: VisualLayer, pulseColor: PulseColor, pulseLayers: ref mPulseLayers, pulseAnimation: PulseAnimation);

		}

		public override void TouchesCancelled(Foundation.NSSet touches, UIEvent evt)
		{
			base.TouchesCancelled(touches, evt);
			MaterialAnimation.pulseContractAnimation(layer: Layer, visualLayer: VisualLayer, pulseColor: PulseColor, pulseLayers: ref mPulseLayers, pulseAnimation: PulseAnimation);
		}
		#endregion

		#region FUNCTIONS

		public virtual void prepareView()
		{
			ContentScaleFactor = MaterialDevice.Scale;
			prepareVisualLayer();
		}

		internal void prepareVisualLayer()
		{
			VisualLayer.ZPosition = 0;
			VisualLayer.MasksToBounds = true;
			Layer.AddSublayer(VisualLayer);
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
