// MIT/X11 License
//
// Material+UIView.cs
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
namespace FPT.Framework.iOS.Material
{
	public partial class Extensions
	{

		public static nfloat X(this UIView view)
		{
			return view.Layer.X();
		}
		public static void SetX(this UIView view, nfloat value)
		{
			view.Layer.SetX(value);
		}

		public static nfloat Y(this UIView view)
		{
			return view.Layer.Y();
		}
		public static void SetY(this UIView view, nfloat value)
		{
			view.Layer.SetY(value);
		}

		public static nfloat Width(this UIView view)
		{
			return view.Layer.Width();
		}
		public static void SetWidth(this UIView view, nfloat value)
		{
			view.Layer.SetWidth(value);
		}

		public static nfloat Height(this UIView view)
		{
			return view.Layer.Height();
		}
		public static void SetHeight(this UIView view, nfloat value)
		{
			view.Layer.SetHeight(value);
		}

		public static HeightPreset HeightPreset(this UIView view)
		{
			return view.Layer.HeightPreset();
		}
		public static void SetHeightPreset(this UIView view, HeightPreset value)
		{
			view.Layer.SetHeightPreset(value);
		}

		public static ShapePreset ShapePreset(this UIView view)
		{
			return view.Layer.ShapePreset();
		}
		public static void SetShapePreset(this UIView view, ShapePreset value)
		{
			view.Layer.SetShapePreset(value);
		}

		public static DepthPreset DepthPreset(this UIView view)
		{
			return view.Layer.DepthPreset();
		}
		public static void SetDepthPreset(this UIView view, DepthPreset value)
		{
			view.Layer.SetDepthPreset(value);
		}

		public static Depth Depth(this UIView view)
		{
			return view.Layer.Depth();
		}
		public static void SetDepth(this UIView view, Depth value)
		{
			view.Layer.SetDepth(value);
		}

		public static UIColor ShadowColor(this UIView view)
		{
			if (view.Layer.ShadowColor == null)
				return null;
			return new UIColor(view.Layer.ShadowColor);
		}
		public static void SetShadowColor(this UIView view, UIColor value)
		{
			if (value != null)
				view.Layer.ShadowColor = value.CGColor;
		}

		public static CGSize ShadowOffset(this UIView view)
		{
			return view.Layer.ShadowOffset;
		}
		public static void SetShadowOffset(this UIView view, CGSize value)
		{
			view.Layer.ShadowOffset = value;
		}

		public static float ShadowOpacity(this UIView view)
		{
			return view.Layer.ShadowOpacity;
		}
		public static void SetShadowOpacity(this UIView view, float value)
		{
			view.Layer.ShadowOpacity = value;
		}

		public static nfloat ShadowRadius(this UIView view)
		{
			return view.Layer.ShadowRadius;
		}
		public static void SetShadowRadius(this UIView view, nfloat value)
		{
			view.Layer.ShadowRadius = value;
		}

		public static CGPath ShadowPath(this UIView view)
		{
			return view.Layer.ShadowPath;
		}
		public static void SetShadowPath(this UIView view, CGPath value)
		{
			view.Layer.ShadowPath = value;
		}

		public static bool IsShadowPathAutoSizing(this UIView view)
		{
			return view.Layer.IsShadowPathAutoSizing();
		}
		public static void SetIsShadowPathAutoSizing(this UIView view, bool value)
		{
			view.Layer.SetIsShadowPathAutoSizing(value);
		}

		public static CornerRadiusPreset CornerRadiusPreset(this UIView view)
		{
			return view.Layer.CornerRadiusPreset();
		}

		public static void SetCornerRadiusPreset(this UIView view, CornerRadiusPreset value)
		{
			view.Layer.SetCornerRadiusPreset(value);
		}

		public static nfloat CornerRadius(this UIView view)
		{
			return view.Layer.CornerRadius;
		}

		public static void SetCornerRadius(this UIView view, nfloat value)
		{
			view.Layer.CornerRadius = value;
		}

		public static BorderWidthPreset BorderWidthPreset(this UIView view)
		{
			return view.Layer.BorderWidthPreset();
		}

		public static void SetBorderWidthPreset(this UIView view, BorderWidthPreset value)
		{
			view.Layer.SetBorderWidthPreset(value);
		}

		public static nfloat BorderWith(this UIView view)
		{
			return view.Layer.BorderWidth;
		}

		public static void SetBorderWith(this UIView view, nfloat value)
		{
			view.Layer.BorderWidth = value;
		}

		public static UIColor BorderColor(this UIView view)
		{
			if (view.Layer.BorderColor == null)
				return null;
			return new UIColor(view.Layer.BorderColor);
		}

		public static void SetBorderColor(this UIView view, UIColor value)
		{
			if (value != null)
				view.Layer.BorderColor = value.CGColor;
		}

		public static CGPoint Position(this UIView view)
		{
			return view.Layer.Position;
		}

		public static void SetPosition(this UIView view, CGPoint value)
		{
			view.Layer.Position = value;
		}

		public static nfloat ZPosition(this UIView view)
		{
			return view.Layer.ZPosition;
		}

		public static void SetZPosition(this UIView view, nfloat value)
		{
			view.Layer.ZPosition = value;
		}

		public static void Animate(this UIView view, CAAnimation animation)
		{
			view.Layer.Animate(animation);
		}

		public static void Animate(this UIView view, CAAnimation animation, bool finished)
		{
			view.Layer.AnimationDidStop(animation, finished);
		}

		public static void LayoutShape(this UIView view)
		{
			view.Layer.LayoutShape();
		}

		public static void LayoutShadowPath(this UIView view)
		{
			view.Layer.LayoutShadowPath();
		}
	}
}
