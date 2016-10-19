using System;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using UIKit;

namespace FPT.Framework.iOS.Material
{

	public class Layer : CAShapeLayer
	{

		#region PROPERTIES

		/**
		A CAShapeLayer used to manage elements that would be affected by
		the clipToBounds property of the backing layer. For example, this
		allows the dropshadow effect on the backing layer, while clipping
		the image to a desired shape within the visualLayer.
		*/
		public CAShapeLayer VisualLayer { get; private set; } = new CAShapeLayer();

		/**
		A property that manages an image for the visualLayer's contents
		property. Images should not be set to the backing layer's contents
		property to avoid conflicts when using clipsToBounds.
		*/
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

		public override CGRect ContentsRect
		{
			get
			{
				return base.ContentsRect;
			}
			set
			{
				base.ContentsRect = value;
				VisualLayer.ContentsRect = value;
			}
		}

		public override CGRect ContentsCenter
		{
			get
			{
				return base.ContentsCenter;
			}
			set
			{
				base.ContentsCenter = value;
				VisualLayer.ContentsCenter = value;
			}
		}

		public override nfloat ContentsScale
		{
			get
			{
				return base.ContentsScale;
			}
			set
			{
				base.ContentsScale = value;
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

		public override string ContentsGravity
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

		public override nfloat CornerRadius
		{
			get
			{
				return base.CornerRadius;
			}
			set
			{
				base.CornerRadius = value;
				this.LayoutShadowPath();
				if (this.ShapePreset() == ShapePreset.Circle)
				{
					this.SetShapePreset(ShapePreset.None);
				}
			}
		}

		#endregion

		#region CONSTRUCTORS

		public Layer() : base()
		{
			ContentsGravityPreset = Gravity.ResizeAspectFill;
			PrepareVisualLayer();
		}

		public Layer(NSCoder coder) : base(coder)
		{
			ContentsGravityPreset = Gravity.ResizeAspectFill;
			PrepareVisualLayer();
		}

		public Layer(CGRect frame) : this()
		{
			this.Frame = frame;
		}

		public override void LayoutSublayers()
		{
			base.LayoutSublayers();
			this.LayoutShape();
			this.LayoutVisualLayer();
			this.LayoutShadowPath();
		}


		internal void PrepareVisualLayer()
		{
			VisualLayer.ZPosition = 0;
			VisualLayer.MasksToBounds = true;
			AddSublayer(VisualLayer);
		}

		internal void LayoutVisualLayer()
		{
			VisualLayer.Frame = Bounds;
			VisualLayer.CornerRadius = CornerRadius;
		}

		#endregion
	}

	//public interface MaterialDelegate { }


	//public class MaterialLayer : CAShapeLayer//, ICAAnimationDelegate
	//{
	//	#region VARIABLES
	//	private CAShapeLayer mVisualLayer = new CAShapeLayer();
	//	private MaterialShape mShape = MaterialShape.None;
	//	private MaterialDepth mDepth = MaterialDepth.None;
	//	private bool mShadowPathAutoSizeEnabled = true;
	//	#endregion


	//	public MaterialLayer()
	//	{
	//	}

	//	#region PROPERTIES
	//	public bool ShadowPathAutoSizeEnabled {
	//		get {
	//			return mShadowPathAutoSizeEnabled;
	//		}
	//		set {
	//			mShadowPathAutoSizeEnabled = value;
	//			if (mShadowPathAutoSizeEnabled) {
	//				layoutShadowPath();
	//			}
	//		}
	//	}

	//	public MaterialDepth Depth
	//	{
	//		get
	//		{
	//			return mDepth;
	//		}
	//		set
	//		{
	//			mDepth = value;
	//			var depthValue = Convert.MaterialDepthToValue(value);
	//			ShadowOffset = depthValue.Offset;
	//			ShadowOpacity = depthValue.Opacity;
	//			ShadowRadius = depthValue.Radius;
	//			layoutShadowPath();
	//		}
	//	}

	//	public CAShapeLayer VisualLayer
	//	{
	//		get
	//		{
	//			return mVisualLayer;
	//		}
	//		private set
	//		{
	//			mVisualLayer = value;
	//		}
	//	}

	//	public nfloat Y
	//	{
	//		get
	//		{
	//			return Frame.Y;
	//		}
	//		set
	//		{
	//			var frame = Frame;
	//			frame.Y = value;
	//			Frame = frame;
	//		}

	//	}

	//	public nfloat Width
	//	{
	//		get
	//		{
	//			return Frame.Width;
	//		}
	//		set
	//		{
	//			var frame = Frame;
	//			frame.Width = value;
	//			Frame = frame;
	//			if (Shape != MaterialShape.None)
	//			{
	//				frame.Height = value;
	//				Frame = frame;
	//			}
	//		}
	//	}

	//	public nfloat Height
	//	{
	//		get
	//		{
	//			return Frame.Width;
	//		}
	//		set
	//		{
	//			var frame = Frame;
	//			frame.Height = value;
	//			if (Shape != MaterialShape.None)
	//			{
	//				frame.Width = value;
	//			}
	//			Frame = frame;
	//		}
	//	}

	//	/**
	//	A property that manages the overall shape for the object. If either the
	//	width or height property is set, the other will be automatically adjusted
	//	to maintain the shape of the object.
	//	*/
	//	public MaterialShape Shape
	//	{
	//		get
	//		{
	//			return mShape;
	//		}
	//		set
	//		{
	//			mShape = value;
	//			if (mShape != MaterialShape.None)
	//			{
	//				var frame = Frame;
	//				if (Width < Height)
	//				{
	//					frame.Width = Height;
	//				}
	//				else
	//				{
	//					frame.Height = Width;
	//				}
	//				Frame = frame;
	//			}
	//		}
	//	}
	//	#endregion

	//	internal void layoutShadowPath(this CALayer layer)
	//	{
	//		if (mShadowPathAutoSizeEnabled)
	//		{
	//			if (mDepth == MaterialDepth.None)
	//			{
					
	//			}
	//		}
	//	}
	//}
}
