using System;
using CoreAnimation;

namespace FPT.Framework.iOS.Material
{
	public interface MaterialDelegate { }


	public class MaterialLayer : CAShapeLayer//, ICAAnimationDelegate
	{
		#region VARIABLES
		private CAShapeLayer mVisualLayer = new CAShapeLayer();
		private MaterialShape mShape = MaterialShape.None;
		private MaterialDepth mDepth = MaterialDepth.None;
		private bool mShadowPathAutoSizeEnabled = true;
		#endregion


		public MaterialLayer()
		{
		}

		#region PROPERTIES
		public bool ShadowPathAutoSizeEnabled {
			get {
				return mShadowPathAutoSizeEnabled;
			}
			set {
				mShadowPathAutoSizeEnabled = value;
				if (mShadowPathAutoSizeEnabled) {
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

		public nfloat Y
		{
			get
			{
				return Frame.Y;
			}
			set
			{
				var frame = Frame;
				frame.Y = value;
				Frame = frame;
			}

		}

		public nfloat Width
		{
			get
			{
				return Frame.Width;
			}
			set
			{
				var frame = Frame;
				frame.Width = value;
				Frame = frame;
				if (Shape != MaterialShape.None)
				{
					frame.Height = value;
					Frame = frame;
				}
			}
		}

		public nfloat Height
		{
			get
			{
				return Frame.Width;
			}
			set
			{
				var frame = Frame;
				frame.Height = value;
				if (Shape != MaterialShape.None)
				{
					frame.Width = value;
				}
				Frame = frame;
			}
		}

		/**
		A property that manages the overall shape for the object. If either the
		width or height property is set, the other will be automatically adjusted
		to maintain the shape of the object.
		*/
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
				}
			}
		}
		#endregion

		internal void layoutShadowPath()
		{
			if (mShadowPathAutoSizeEnabled)
			{
				if (mDepth == MaterialDepth.None)
				{
					
				}
			}
		}
	}
}
