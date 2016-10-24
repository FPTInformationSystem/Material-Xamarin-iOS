// MIT/X11 License
//
// Divider.cs
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
using Foundation;
using UIKit;
namespace FPT.Framework.iOS.Material
{

	public enum DividerAlignment
	{
		Top, Left, Bottom, Right
	}

	public class Divider : NSObject
	{

		internal UIView View { get; set;}

		internal UIView Line { get; set;}

		private nfloat mThickness;
		internal nfloat Thickness {
			get
			{
				return mThickness;
			}
			set
			{
				mThickness = value;
				Reload();
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
				ContentEdgeInsets = Convert.EdgeInsetsPresetToValue(value);
			}
		}

		private UIEdgeInsets mContentEdgeInsets = UIEdgeInsets.Zero;
		public UIEdgeInsets ContentEdgeInsets
		{
			get
			{
				return mContentEdgeInsets;
			}
			set
			{
				mContentEdgeInsets = value;
				Reload();
			}
		}

		public UIColor Color
		{
			get
			{
				if (Line != null) return Line.BackgroundColor;
				return null;
			}
			set
			{
				if (value == null)
				{
					if (Line != null) Line.RemoveFromSuperview();
					Line = null;
					return;
				}
				if (Line == null)
				{
					Line = new UIView();
					Line.SetZPosition(5000);
					View.AddSubview(Line);
					Reload();
				}
				Line.BackgroundColor = value;
			}
		}

		private DividerAlignment mAlignment = DividerAlignment.Bottom;
		public DividerAlignment Alignment
		{
			get
			{
				return mAlignment;
			}
			set
			{
				mAlignment = value;
				Reload();
			}
		}
		
		public Divider(UIView view, nfloat? thickness = null)
		{
			this.View = view;
			this.Thickness = thickness == null ? 1 : thickness.Value;
		}

		public void Reload()
		{
			var l = Line;
			var v = View;
			if (l == null || v == null) return;

			var c = ContentEdgeInsets;

			switch (Alignment)
			{
				case DividerAlignment.Top:
					{
						Line.Frame = new CGRect(c.Left, c.Top, v.Width() - c.Left - c.Right, Thickness);
					}
					break;
				case DividerAlignment.Bottom:
					{
						Line.Frame = new CGRect(c.Left, v.Height() - Thickness - c.Bottom, v.Width() - c.Left - c.Right, Thickness);
					}
					break;
				case DividerAlignment.Left:
					{
						Line.Frame = new CGRect(c.Left, c.Top, Thickness, v.Height() - c.Top - c.Bottom);
					}
					break;
				case DividerAlignment.Right:
					{
						Line.Frame = new CGRect(v.Width() - Thickness - c.Right, c.Top, Thickness, v.Height() - c.Top - c.Bottom);
					}
					break;
			}
		}
	}

	public partial class Extensions
	{

		static NSObject sDividerKey = new NSObject();
		public static Divider Divider(this UIView view)
		{
			var v = MaterialObjC.MaterialAssociatedObject(view.Handle, sDividerKey.Handle, () =>
			{
				return new Divider(view).Handle;
			});

			return ObjCRuntime.Runtime.GetNSObject(v) as Divider;

		}
		public static void SetDivider(this UIView view, Divider value)
		{
			MaterialObjC.MaterialAssociatedObject(view.Handle, sDividerKey.Handle, value.Handle);

		}

		public static UIColor DividerColor(this UIView view)
		{
			return view.Divider().Color;
		}
		public static void SetDividerColor(this UIView view, UIColor value)
		{
			view.Divider().Color = value;
		}

		public static DividerAlignment DividerAlignment(this UIView view)
		{
			return view.Divider().Alignment;
		}
		public static void SetDividerAlignment(this UIView view, DividerAlignment value)
		{
			view.Divider().Alignment = value;
		}

		public static nfloat DividerThickness(this UIView view)
		{
			return view.Divider().Thickness;
		}
		public static void SetDividerThickness(this UIView view, nfloat value)
		{
			view.Divider().Thickness = value;
		}
	}
}
