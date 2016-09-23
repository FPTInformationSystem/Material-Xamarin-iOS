using System;
using CoreAnimation;

namespace FPT.Framework.iOS.Material
{
	public interface MaterialDelegate { }


	public class MaterialLayer : CAShapeLayer, CAAnimationDelegate
	{
		#region VARIABLES
		private CAShapeLayer mVisualLayer = new CAShapeLayer();
		#endregion


		public MaterialLayer()
		{
		}

		#region PROPERTIES
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
				Frame.Y = value;
			}

		}

		public nfloat Width
		{
			get
			{
				return Frame.Size.Width;
			}
			set
			{
				Frame.Size.Width = value;
				if ()
				{
					Frame.Size.Height = value;
				}
			}
		}

		/**
		A property that manages the overall shape for the object. If either the
		width or height property is set, the other will be automatically adjusted
		to maintain the shape of the object.
		*/
		public MaterialShape shape
		{
		}

		#endregion
	}
}
