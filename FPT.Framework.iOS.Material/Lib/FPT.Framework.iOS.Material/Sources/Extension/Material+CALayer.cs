// MIT/X11 License
//
// Material+CALayer.cs
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
using CoreAnimation;
using Foundation;
using UIKit;

namespace FPT.Framework.iOS.Material
{

	internal class MaterialLayer : NSObject
	{

		internal CALayer Layer { get; set;}

		private HeightPreset mHeightPreset = HeightPreset.Default;
		internal HeightPreset HeightPreset
		{
			get
			{
				return mHeightPreset;
			}
			set
			{
				mHeightPreset = value;
				if (this.Layer != null)
				{
					this.Layer.SetHeight((nfloat)((int)HeightPreset));
				}
			}
		}

		private CornerRadiusPreset mCornerRadiusPreset = CornerRadiusPreset.None;
		internal CornerRadiusPreset CornerRadiusPreset
		{
			get
			{
				return mCornerRadiusPreset;
			}
			set
			{
				mCornerRadiusPreset = value;
				if (Layer != null)
				{
					Layer.CornerRadius = Convert.CornerRadiusPresetToValue(value);
				}
			}
		}

		private BorderWidthPreset mBorderWidthPreset;
		internal BorderWidthPreset BorderWidthPreset
		{
			get
			{
				return mBorderWidthPreset;
			}
			set
			{
				mBorderWidthPreset = value;
				if (Layer != null)
				{
					Layer.BorderWidth = Convert.BorderWidthPresetToValue(value);
				}
			}
		}

		internal ShapePreset ShapePreset { get; set; } = ShapePreset.None;

		internal DepthPreset DepthPreset
		{
			get
			{
				return Depth.Preset;
			}
			set
			{
				Depth.Preset = value;
			}
		}

		private Depth mDepth = Depth.Zero;
		public Depth Depth
		{
			get
			{
				return mDepth;
			}
			set
			{
				mDepth = value;
				var v = Layer;
				if (v == null) return;

				v.ShadowOffset = Depth.Offset.AsSize();
				v.ShadowOpacity = Depth.Opacity;
				v.ShadowRadius = Depth.Radius;
				v.LayoutShadowPath();
			}
		}

		internal bool IsShadowPathAutoSizing { get; set; } = false;

		internal MaterialLayer(CALayer layer)
		{
			this.Layer = layer;
		}
	}

	public partial class Extensions
	{

		static NSObject sMaterialLayerKey = new NSObject();
		internal static MaterialLayer MaterialLayer(this CALayer layer)
		{
			var v = MaterialObjC.MaterialAssociatedObject(layer.Handle, sMaterialLayerKey.Handle, () =>
			{
				return new MaterialLayer(layer).Handle;
			});

			return ObjCRuntime.Runtime.GetNSObject(v) as MaterialLayer;

		}

		internal static void SetMaterialLayer(this CALayer layer, MaterialLayer value)
		{
			MaterialObjC.MaterialAssociatedObject(layer.Handle, sMaterialLayerKey.Handle, value.Handle);

		}

		public static nfloat X(this CALayer layer)
		{
			return layer.Frame.X;
		}
		public static void SetX(this CALayer layer, nfloat value)
		{
			var frame = layer.Frame;
			frame.X = value;
			layer.Frame = frame;

			layer.LayoutShadowPath();
		}

		public static nfloat Y(this CALayer layer)
		{
			return layer.Frame.Y;
		}
		public static void SetY(this CALayer layer, nfloat value)
		{
			var frame = layer.Frame;
			frame.Y = value;
			layer.Frame = frame;

			layer.LayoutShadowPath();
		}

		public static nfloat Width(this CALayer layer)
		{
			return layer.Frame.Width;
		}
		public static void SetWidth(this CALayer layer, nfloat value)
		{
			var frame = layer.Frame;
			frame.Width = value;
			layer.Frame = frame;
			if (layer.ShapePreset() != Material.ShapePreset.None)
			{
				frame.Height = value;
				layer.Frame = frame;
				layer.LayoutShape();
			}

			layer.LayoutShadowPath();
		}

		public static nfloat Height(this CALayer layer)
		{
			return layer.Frame.Width;
		}
		public static void SetHeight(this CALayer layer, nfloat value)
		{
			var frame = layer.Frame;
			frame.Height = value;
			layer.Frame = frame;
			if (layer.ShapePreset() != Material.ShapePreset.None)
			{
				frame.Height = value;
				layer.Frame = frame;
				layer.LayoutShape();
			}

			layer.LayoutShadowPath();
		}

		public static HeightPreset HeightPreset(this CALayer layer)
		{
			return layer.MaterialLayer().HeightPreset;
		}

		public static void SetHeightPreset(this CALayer layer, HeightPreset value)
		{
			layer.MaterialLayer().HeightPreset = value;
		}

		public static ShapePreset ShapePreset(this CALayer layer)
		{
			return layer.MaterialLayer().ShapePreset;
		}

		public static void SetShapePreset(this CALayer layer, ShapePreset value)
		{
			layer.MaterialLayer().ShapePreset = value;
		}

		public static DepthPreset DepthPreset(this CALayer layer)
		{
			return layer.MaterialLayer().Depth.Preset;
		}

		public static void SetDepthPreset(this CALayer layer, DepthPreset value)
		{
			layer.MaterialLayer().Depth = Convert.DepthPresetToValue(value);
			layer.MaterialLayer().Depth.Preset = value;
		}

		public static Depth Depth(this CALayer layer)
		{
			return layer.MaterialLayer().Depth;
		}

		public static void SetDepth(this CALayer layer, Depth value)
		{
			layer.MaterialLayer().Depth = value;
		}

		public static bool IsShadowPathAutoSizing(this CALayer layer)
		{
			return layer.MaterialLayer().IsShadowPathAutoSizing;
		}

		public static void SetIsShadowPathAutoSizing(this CALayer layer, bool value)
		{
			layer.MaterialLayer().IsShadowPathAutoSizing = value;
		}

		public static CornerRadiusPreset CornerRadiusPreset(this CALayer layer)
		{
			return layer.MaterialLayer().CornerRadiusPreset;
		}

		public static void SetCornerRadiusPreset(this CALayer layer, CornerRadiusPreset value)
		{
			layer.MaterialLayer().CornerRadiusPreset = value;
		}

		public static BorderWidthPreset BorderWidthPreset(this CALayer layer)
		{
			return layer.MaterialLayer().BorderWidthPreset;
		}

		public static void SetBorderWidthPreset(this CALayer layer, BorderWidthPreset value)
		{
			layer.MaterialLayer().BorderWidthPreset = value;
		}

		public static void Animate(this CALayer layer, CAAnimation animation)
		{
			if (animation is CABasicAnimation)
			{
				((CABasicAnimation)animation).From = (layer.PresentationLayer == null ? layer : layer.PresentationLayer).ValueForKey(new NSString(((CABasicAnimation)animation).KeyPath));
			}
			if (animation is CAPropertyAnimation)
			{
				layer.AddAnimation(animation, ((CAPropertyAnimation)animation).KeyPath);
			}
			else if (animation is CAAnimationGroup)
			{
				layer.AddAnimation(animation, null);
			}
			else if (animation is CATransition)
			{
				layer.AddAnimation(animation, CALayer.Transition);
			}
		}

		public static void AnimationDidStop(this CALayer layer, CAAnimation animation, bool finished)
		{
			if (animation is CAPropertyAnimation)
			{
				if (animation is CABasicAnimation)
				{
					var v = ((CABasicAnimation)animation).To;
					var k = ((CABasicAnimation)animation).KeyPath;
					layer.SetValueForKey(v, new NSString(k));
					layer.RemoveAnimation(k);
				}
			}
			else if (animation is CAAnimationGroup)
			{
				foreach (var x in ((CAAnimationGroup)animation).Animations)
				{
					layer.AnimationDidStop(x, true);
				}
			}
		}

		/// Manages the layout for the shape of the view instance.
		public static void LayoutShape(this CALayer layer)
		{
			if (0 > layer.Width() || 0 > layer.Height())
			{
				return;
			}

			if (layer.ShapePreset() != Material.ShapePreset.None)
			{
				if (layer.Width() < layer.Height())
				{
					var frame = layer.Frame;
					frame.Width = layer.Height();
					layer.Frame = frame;
				}
				else if (layer.Width() > layer.Height())
				{
					var frame = layer.Frame;
					frame.Height = layer.Width();
					layer.Frame = frame;
				}
			}

			if (layer.ShapePreset() == Material.ShapePreset.Circle)
			{
				layer.CornerRadius = layer.Width() / 2f;
			}
		}

		/// Sets the shadow path.
		public static void LayoutShadowPath(this CALayer layer)
		{
			if (!layer.IsShadowPathAutoSizing())
			{
				return;
			}

			if (layer.DepthPreset() == Material.DepthPreset.None)
			{
				layer.ShadowPath = null;
			}
			else if (layer.ShadowPath == null)
			{
				layer.ShadowPath = UIBezierPath.FromRoundedRect(layer.Bounds, layer.CornerRadius).CGPath;
			}
			else
			{
				layer.Animate(Animation.ShadowPath(UIBezierPath.FromRoundedRect(layer.Bounds, layer.CornerRadius).CGPath, 0));
			}
		}
	}
}
