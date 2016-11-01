// MIT/X11 License
//
// Layout.cs
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
using CoreGraphics;
using Foundation;
using UIKit;


namespace FPT.Framework.iOS.Material
{
	public class Layout : NSObject
	{

		#region PROPERTIES

		internal UIView Parent { get; set; }

		internal UIView Child { get; set; }

		#endregion

		#region CONSTRUCTORS

		public Layout(UIView parent)
		{
			this.Parent = parent;
		}

		public Layout(UIView parent, UIView child)
		{
			this.Parent = parent;
			this.Child = child;
		}

		protected Layout(IntPtr ptr) : base()
		{
		}

		#endregion

		#region FUNCTIONS

		internal Layout debugParentNotAvailableMessage(string function = "#function")
		{
			System.Diagnostics.Debug.WriteLine(function);
			return this;
		}

		internal Layout debugChildNotAvailableMessage(string function = "#function")
		{
			System.Diagnostics.Debug.WriteLine(function);
			return this;
		}

		#endregion

		#region FUNCTIONS

		public Layout Width(UIView child, nfloat width)
		{
			var v = Parent;
			if (v == null)
			{
				return debugParentNotAvailableMessage();
			}
			this.Child = child;
			Layout.Width(Parent, Child, width);
			return this;
		}

		public Layout Width(nfloat width)
		{
			var v = Child;
			if (v == null)
			{
				return debugChildNotAvailableMessage();
			}
			return this.Width(v, width);
		}

		public Layout Height(UIView child, nfloat height)
		{
			var v = Parent;
			if (v == null)
			{
				return debugParentNotAvailableMessage();
			}
			this.Child = child;
			Layout.Height(Parent, Child, height);
			return this;
		}

		public Layout Height(nfloat height)
		{
			var v = Child;
			if (v == null)
			{
				return debugChildNotAvailableMessage();
			}
			return this.Height(v, height);
		}

		public Layout Size(UIView child, CGSize size)
		{
			var v = Parent;
			if (v == null)
			{
				return debugParentNotAvailableMessage();
			}
			this.Child = child;
			Layout.Size(Parent, Child, size);
			return this;
		}

		public Layout Size(CGSize? size = null)
		{
			var v = Child;
			if (v == null)
			{
				return debugChildNotAvailableMessage();
			}
			if (size == null)
			{
				size = CGSize.Empty;
			}
			return this.Size(v, size.Value);
		}

		public Layout Horizontally(UIView[] children, nfloat left = default(nfloat), nfloat right = default(nfloat), nfloat spacing = default(nfloat))
		{
			var v = Parent;
			if (v == null)
			{
				return debugParentNotAvailableMessage();
			}
			Layout.Horizontally(Parent, children, left, right, spacing);
			return this;
		}

		public Layout Vertically(UIView[] children, nfloat top = default(nfloat), nfloat bottom = default(nfloat), nfloat spacing = default(nfloat))
		{
			var v = Parent;
			if (v == null)
			{
				return debugParentNotAvailableMessage();
			}
			Layout.Vertically(Parent, children, top, bottom, spacing);
			return this;
		}

		/// <summary>A child view is aligned at the center horizontally with an optional offset value.</summary>
		/// <param name="child">A child UIView to layout.</param>
		/// <param name="left">A CGFloat value for padding the left side.</param>
		/// <param name="right">A CGFloat value for padding the right side.</param>
		/// <returns>The current Layout instance.</returns>
		public Layout Horizontally(UIView child, nfloat left = default(nfloat), nfloat right = default(nfloat))
		{
			var v = Parent;
			if (v == null)
			{
				return debugParentNotAvailableMessage();
			}
			this.Child = child;
			Layout.Horizontally(Parent, child, left, right);
			return this;
		}

		public Layout Horizontally(nfloat left = default(nfloat), nfloat right = default(nfloat))
		{
			var v = Child;
			if (v == null)
			{
				return debugChildNotAvailableMessage();
			}
			return this.Horizontally(v, left, right);
		}

		public Layout Vertically(UIView child, nfloat top = default(nfloat), nfloat bottom = default(nfloat))
		{
			var v = Parent;
			if (v == null)
			{
				return debugParentNotAvailableMessage();
			}
			this.Child = child;
			Layout.Vertically(Parent, child, top, bottom);
			return this;
		}

		public Layout Vertically(nfloat top = default(nfloat), nfloat bottom = default(nfloat))
		{
			var v = Child;
			if (v == null)
			{
				return debugChildNotAvailableMessage();
			}
			return this.Vertically(v, top, bottom);
		}

		public Layout Edges(UIView child, nfloat top = default(nfloat), nfloat left = default(nfloat), nfloat bottom = default(nfloat), nfloat right = default(nfloat))
		{
			var v = Parent;
			if (v == null)
			{
				return debugParentNotAvailableMessage();
			}
			this.Child = child;
			Layout.Edges(v, child, top, left, bottom, right);
			return this;
		}

		public Layout Edges(nfloat top = default(nfloat), nfloat left = default(nfloat), nfloat bottom = default(nfloat), nfloat right = default(nfloat))
		{
			var v = Child;
			if (v == null)
			{
				return debugChildNotAvailableMessage();
			}
			return this.Edges(v, top, left, bottom, right);
		}

		public Layout Top(UIView child, nfloat top = default(nfloat)) 
		{
			var v = Parent;
			if (v == null)
			{
				return debugParentNotAvailableMessage();
			}
			this.Child = child;
			Layout.Top(v, child, top);
			return this;
		}

		public Layout Top(nfloat top = default(nfloat))
		{
			var v = Child;
			if (v == null)
			{
				return debugChildNotAvailableMessage();
			}
			return this.Top(v, top);
		}

		public Layout Left(UIView child, nfloat left = default(nfloat))
		{
			var v = Parent;
			if (v == null)
			{
				return debugParentNotAvailableMessage();
			}
			this.Child = child;
			Layout.Left(v, child, left);
			return this;
		}

		public Layout Left(nfloat left = default(nfloat))
		{
			var v = Child;
			if (v == null)
			{
				return debugChildNotAvailableMessage();
			}
			return this.Left(v, left);
		}

		public Layout Bottom(UIView child, nfloat bottom = default(nfloat))
		{
			var v = Parent;
			if (v == null)
			{
				return debugParentNotAvailableMessage();
			}
			this.Child = child;
			Layout.Bottom(v, child, bottom);
			return this;
		}

		public Layout Bottom(nfloat bottom = default(nfloat))
		{
			var v = Child;
			if (v == null)
			{
				return debugChildNotAvailableMessage();
			}
			return this.Bottom(v, bottom);
		}

		public Layout Right(UIView child, nfloat right = default(nfloat))
		{
			var v = Parent;
			if (v == null)
			{
				return debugParentNotAvailableMessage();
			}
			this.Child = child;
			Layout.Right(v, child, right);
			return this;
		}

		public Layout Right(nfloat right = default(nfloat))
		{
			var v = Child;
			if (v == null)
			{
				return debugChildNotAvailableMessage();
			}
			return this.Right(v, right);
		}

		public Layout TopLeft(UIView child, nfloat top = default(nfloat), nfloat left = default(nfloat))
		{
			var v = Parent;
			if (v == null)
			{
				return debugParentNotAvailableMessage();
			}
			this.Child = child;
			Layout.TopLeft(v, child, top, left);
			return this;
		}

		public Layout TopLeft(nfloat top = default(nfloat), nfloat left = default(nfloat))
		{
			var v = Child;
			if (v == null)
			{
				return debugChildNotAvailableMessage();
			}
			return this.TopLeft(v, top, left);
		}

		public Layout TopRight(UIView child, nfloat top = default(nfloat), nfloat right = default(nfloat))
		{
			var v = Parent;
			if (v == null)
			{
				return debugParentNotAvailableMessage();
			}
			this.Child = child;
			Layout.TopRight(v, child, top, right);
			return this;
		}

		public Layout TopRight(nfloat top = default(nfloat), nfloat right = default(nfloat))
		{
			var v = Child;
			if (v == null)
			{
				return debugChildNotAvailableMessage();
			}
			return this.TopRight(v, top, right);
		}

		public Layout BottomLeft(UIView child, nfloat bottom = default(nfloat), nfloat left = default(nfloat))
		{
			var v = Parent;
			if (v == null)
			{
				return debugParentNotAvailableMessage();
			}
			this.Child = child;
			Layout.BottomLeft(v, child, bottom, left);
			return this;
		}

		public Layout BottomLeft(nfloat bottom = default(nfloat), nfloat left = default(nfloat))
		{
			var v = Child;
			if (v == null)
			{
				return debugChildNotAvailableMessage();
			}
			return this.BottomLeft(v, bottom, left);
		}

		public Layout BottomRight(UIView child, nfloat bottom = default(nfloat), nfloat right = default(nfloat))
		{
			var v = Parent;
			if (v == null)
			{
				return debugParentNotAvailableMessage();
			}
			this.Child = child;
			Layout.BottomRight(v, child, bottom, right);
			return this;
		}

		public Layout BottomRight(nfloat bottom = default(nfloat), nfloat right = default(nfloat))
		{
			var v = Child;
			if (v == null)
			{
				return debugChildNotAvailableMessage();
			}
			return this.BottomRight(v, bottom, right);
		}

		public Layout Center(UIView child, nfloat offsetX = default(nfloat), nfloat offsetY = default(nfloat))
		{
			var v = Parent;
			if (v == null)
			{
				return debugParentNotAvailableMessage();
			}
			this.Child = child;
			Layout.Center(v, child, offsetX, offsetY);
			return this;
		}

		public Layout Center(nfloat offsetX = default(nfloat), nfloat offsetY = default(nfloat))
		{
			var v = Child;
			if (v == null)
			{
				return debugChildNotAvailableMessage();
			}
			return this.Center(v, offsetX, offsetY);
		}

		public Layout CenterHorizontally(UIView child, nfloat offset = default(nfloat))
		{
			var v = Parent;
			if (v == null)
			{
				return debugParentNotAvailableMessage();
			}
			this.Child = child;
			Layout.CenterHorizontally(v, child, offset);
			return this;
		}

		public Layout CenterHorizontally(nfloat offset = default(nfloat))
		{
			var v = Child;
			if (v == null)
			{
				return debugChildNotAvailableMessage();
			}
			return this.CenterHorizontally(v, offset);
		}

		public Layout CenterVertically(UIView child, nfloat offset = default(nfloat))
		{
			var v = Parent;
			if (v == null)
			{
				return debugParentNotAvailableMessage();
			}
			this.Child = child;
			Layout.CenterVertically(v, child, offset);
			return this;
		}

		public Layout CenterVertically(nfloat offset = default(nfloat))
		{
			var v = Child;
			if (v == null)
			{
				return debugChildNotAvailableMessage();
			}
			return this.CenterVertically(v, offset);
		}

		#endregion

		#region STATIC FUNCTIONS

		public static void Width(UIView parent, UIView child, nfloat width = default(nfloat))
		{
			prepareForConstraint(parent, child);
			parent.AddConstraint(NSLayoutConstraint.Create(
				view1: child,
				attribute1: NSLayoutAttribute.Width,
				relation: NSLayoutRelation.Equal,
				//view2: null,
				//attribute2: NSLayoutAttribute.Width,
				multiplier: 1,
				constant: width));

		}

		public static void Height(UIView parent, UIView child, nfloat height = default(nfloat))
		{
			prepareForConstraint(parent, child);
			parent.AddConstraint(NSLayoutConstraint.Create(
				view1: child,
				attribute1: NSLayoutAttribute.Height,
				relation: NSLayoutRelation.Equal,
				multiplier: 1,
				constant: height));
		}

		public static void Size(UIView parent, UIView child, CGSize? size)
		{
			Layout.Width(parent, child, size.Value.Width);
			Layout.Height(parent, child, size.Value.Height);
		}

		public static void Horizontally(UIView parent, UIView[] children, nfloat left = default(nfloat), nfloat right = default(nfloat), nfloat spacing = default(nfloat))
		{
			prepareForConstraint(parent, children);
			if (0 < children.Length)
			{
				parent.AddConstraint(NSLayoutConstraint.Create(
					view1: children[0],
					attribute1: NSLayoutAttribute.Left,
					relation: NSLayoutRelation.Equal,
					view2: parent,
					attribute2: NSLayoutAttribute.Left,
					multiplier: 1,
					constant: left));

				for (var i = 1; i < children.Length; i++)
				{
					parent.AddConstraint(NSLayoutConstraint.Create(
						view1: children[i],
						attribute1: NSLayoutAttribute.Left,
						relation: NSLayoutRelation.Equal,
						view2: children[i - 1],
						attribute2: NSLayoutAttribute.Right,
						multiplier: 1,
						constant: spacing));

					parent.AddConstraint(NSLayoutConstraint.Create(
						view1: children[i],
						attribute1: NSLayoutAttribute.Width,
						relation: NSLayoutRelation.Equal,
						view2: children[0],
						attribute2: NSLayoutAttribute.Width,
						multiplier: 1,
						constant: 0));
				}

				parent.AddConstraint(NSLayoutConstraint.Create(
					view1: children[children.Length - 1],
					attribute1: NSLayoutAttribute.Right,
					relation: NSLayoutRelation.Equal,
					view2: parent,
					attribute2: NSLayoutAttribute.Right,
					multiplier: 1,
					constant: -right));
			}
		}

		public static void Vertically(UIView parent, UIView[] children, nfloat top = default(nfloat), nfloat bottom = default(nfloat), nfloat spacing = default(nfloat))
		{
			prepareForConstraint(parent, children);
			if (0 < children.Length)
			{
				parent.AddConstraint(NSLayoutConstraint.Create(
					view1: children[0],
					attribute1: NSLayoutAttribute.Top,
					relation: NSLayoutRelation.Equal,
					view2: parent,
					attribute2: NSLayoutAttribute.Top,
					multiplier: 1,
					constant: top));

				for (var i = 1; i < children.Length; i++)
				{
					parent.AddConstraint(NSLayoutConstraint.Create(
						view1: children[i],
						attribute1: NSLayoutAttribute.Top,
						relation: NSLayoutRelation.Equal,
						view2: children[i - 1],
						attribute2: NSLayoutAttribute.Bottom,
						multiplier: 1,
						constant: spacing));

					parent.AddConstraint(NSLayoutConstraint.Create(
						view1: children[i],
						attribute1: NSLayoutAttribute.Height,
						relation: NSLayoutRelation.Equal,
						view2: children[0],
						attribute2: NSLayoutAttribute.Height,
						multiplier: 1,
						constant: 0));
				}

				parent.AddConstraint(NSLayoutConstraint.Create(
					view1: children[children.Length - 1],
					attribute1: NSLayoutAttribute.Bottom,
					relation: NSLayoutRelation.Equal,
					view2: parent,
					attribute2: NSLayoutAttribute.Bottom,
					multiplier: 1,
					constant: -bottom));
			}
		}

		public static void Horizontally(UIView parent, UIView child, nfloat left = default(nfloat), nfloat right = default(nfloat))
		{
			prepareForConstraint(parent, child);
			parent.AddConstraint(NSLayoutConstraint.Create(
				view1: child,
				attribute1: NSLayoutAttribute.Left,
				relation: NSLayoutRelation.Equal,
				view2: parent,
				attribute2: NSLayoutAttribute.Left,
				multiplier: 1,
				constant: left));
			parent.AddConstraint(NSLayoutConstraint.Create(
				view1: child,
				attribute1: NSLayoutAttribute.Right,
				relation: NSLayoutRelation.Equal,
				view2: parent,
				attribute2: NSLayoutAttribute.Right,
				multiplier: 1,
				constant: -right));
		}

		public static void Vertically(UIView parent, UIView child, nfloat top = default(nfloat), nfloat bottom = default(nfloat))
		{
			prepareForConstraint(parent, child);
			parent.AddConstraint(NSLayoutConstraint.Create(
				view1: child,
				attribute1: NSLayoutAttribute.Top,
				relation: NSLayoutRelation.Equal,
				view2: parent,
				attribute2: NSLayoutAttribute.Top,
				multiplier: 1,
				constant: top));
			parent.AddConstraint(NSLayoutConstraint.Create(
				view1: child,
				attribute1: NSLayoutAttribute.Bottom,
				relation: NSLayoutRelation.Equal,
				view2: parent,
				attribute2: NSLayoutAttribute.Bottom,
				multiplier: 1,
				constant: -bottom));
		}

		public static void Edges(UIView parent, UIView child, nfloat top = default(nfloat), nfloat left = default(nfloat), nfloat bottom = default(nfloat), nfloat right = default(nfloat))
		{
			Horizontally(parent, child, left, right);
			Vertically(parent, child, top, bottom);
		}

		public static void Top(UIView parent, UIView child, nfloat top = default(nfloat))
		{
			prepareForConstraint(parent, child);
			parent.AddConstraint(NSLayoutConstraint.Create(
				view1: child,
				attribute1: NSLayoutAttribute.Top,
				relation: NSLayoutRelation.Equal,
				view2: parent,
				attribute2: NSLayoutAttribute.Top,
				multiplier: 1,
				constant: top));
		}

		public static void Left(UIView parent, UIView child, nfloat left = default(nfloat))
		{
			prepareForConstraint(parent, child);
			parent.AddConstraint(NSLayoutConstraint.Create(
				view1: child,
				attribute1: NSLayoutAttribute.Left,
				relation: NSLayoutRelation.Equal,
				view2: parent,
				attribute2: NSLayoutAttribute.Left,
				multiplier: 1,
				constant: left));
		}

		public static void Bottom(UIView parent, UIView child, nfloat bottom = default(nfloat))
		{
			prepareForConstraint(parent, child);
			parent.AddConstraint(NSLayoutConstraint.Create(
				view1: child,
				attribute1: NSLayoutAttribute.Bottom,
				relation: NSLayoutRelation.Equal,
				view2: parent,
				attribute2: NSLayoutAttribute.Bottom,
				multiplier: 1,
				constant: -bottom));
		}

		public static void Right(UIView parent, UIView child, nfloat right = default(nfloat))
		{
			prepareForConstraint(parent, child);
			parent.AddConstraint(NSLayoutConstraint.Create(
				view1: child,
				attribute1: NSLayoutAttribute.Right,
				relation: NSLayoutRelation.Equal,
				view2: parent,
				attribute2: NSLayoutAttribute.Right,
				multiplier: 1,
				constant: -right));
		}

		public static void TopLeft(UIView parent, UIView child, nfloat top = default(nfloat), nfloat left = default(nfloat))
		{
			Top(parent, child, top);
			Left(parent, child, left);
		}

		public static void TopRight(UIView parent, UIView child, nfloat top = default(nfloat), nfloat right = default(nfloat))
		{
			Top(parent, child, top);
			Right(parent, child, right);
		}

		public static void BottomLeft(UIView parent, UIView child, nfloat bottom = default(nfloat), nfloat left = default(nfloat))
		{
			Bottom(parent, child, bottom);
			Left(parent, child, left);
		}

		public static void BottomRight(UIView parent, UIView child, nfloat bottom = default(nfloat), nfloat right = default(nfloat))
		{
			Bottom(parent, child, bottom);
			Right(parent, child, right);
		}

		public static void Center(UIView parent, UIView child, nfloat offsetX = default(nfloat), nfloat offsetY = default(nfloat))
		{
			CenterHorizontally(parent, child, offsetX);
			CenterVertically(parent, child, offsetY);
		}

		public static void CenterHorizontally(UIView parent, UIView child, nfloat offset = default(nfloat))
		{
			prepareForConstraint(parent, child);
			parent.AddConstraint(NSLayoutConstraint.Create(
				view1: child,
				attribute1: NSLayoutAttribute.CenterX,
				relation: NSLayoutRelation.Equal,
				view2: parent,
				attribute2: NSLayoutAttribute.CenterX,
				multiplier: 1,
				constant: offset));
		}

		public static void CenterVertically(UIView parent, UIView child, nfloat offset = default(nfloat))
		{
			prepareForConstraint(parent, child);
			parent.AddConstraint(NSLayoutConstraint.Create(
				view1: child,
				attribute1: NSLayoutAttribute.CenterY,
				relation: NSLayoutRelation.Equal,
				view2: parent,
				attribute2: NSLayoutAttribute.CenterY,
				multiplier: 1,
				constant: offset));
		}

		public static NSLayoutConstraint[] Constraint(string format, NSLayoutFormatOptions options, NSDictionary metrics, NSDictionary views)
		{
			foreach (var entry in views)
			{
				var v = entry.Value as UIView;
				if (v != null)
				{
					v.TranslatesAutoresizingMaskIntoConstraints = false;
				}
			};

			return NSLayoutConstraint.FromVisualFormat(
				format: format,
				formatOptions: options,
				metrics: metrics,
				views: views
			);
		}

		private static void prepareForConstraint(UIView parent, UIView child)
		{
			if (parent != child.Superview)
			{
				child.RemoveFromSuperview();
				parent.AddSubview(child);
			}
			child.TranslatesAutoresizingMaskIntoConstraints = false;
		}

		private static void prepareForConstraint(UIView parent, UIView[] children)
		{
			foreach (var v in children)
			{
				prepareForConstraint(parent: parent, child: v);
			}
		}

		#endregion
	}

	public static partial class Extensions
	{
		static NSObject sLayoutKey = new NSObject();
		public static Layout Layout(this UIView view)
		{
			var v = MaterialObjC.AssociatedObject(view.Handle, sLayoutKey.Handle, () =>
			{
				return new Layout(view).Handle;
			});

			return ObjCRuntime.Runtime.GetNSObject(v) as Layout;

		}

		public static Layout Layout(this UIView view, UIView child)
		{
			return new Layout(view, child);
		}
	}
}
