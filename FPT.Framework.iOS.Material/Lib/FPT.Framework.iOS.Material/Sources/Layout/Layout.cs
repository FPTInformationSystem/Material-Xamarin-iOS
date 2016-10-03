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
using Foundation;
using UIKit;


namespace FPT.Framework.iOS.Material
{
	public class Layout
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

		#endregion

		#region STATIC FUNCTIONS

		public static void Width(UIView parent, UIView child, nfloat width = default(nfloat))
		{
			prepareForConstraint(parent, child);
			parent.AddConstraint(NSLayoutConstraint.Create(
				view1: ObjCRuntime.Runtime.GetNSObject(child.Handle),
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
				view1: ObjCRuntime.Runtime.GetNSObject(child.Handle),
				attribute1: NSLayoutAttribute.Height,
				relation: NSLayoutRelation.Equal,
				multiplier: 1,
				constant: height));
		}

		public static void Size(UIView parent, UIView child, nfloat width = default(nfloat), nfloat height = default(nfloat))
		{
			Layout.Width(parent, child, width);
			Layout.Width(parent, child, height);
		}

		public static void Horizontally(UIView parent, UIView[] children, nfloat left = default(nfloat), nfloat right = default(nfloat), nfloat spacing = default(nfloat))
		{
			prepareForConstraint(parent, children);
			if (0 < children.Length)
			{
				parent.AddConstraint(NSLayoutConstraint.Create(
					view1: ObjCRuntime.Runtime.GetNSObject(children[0].Handle),
					attribute1: NSLayoutAttribute.Left,
					relation: NSLayoutRelation.Equal,
					view2: parent,
					attribute2: NSLayoutAttribute.Left,
					multiplier: 1,
					constant: left));

				for (var i = 1; i < children.Length; i++)
				{
					parent.AddConstraint(NSLayoutConstraint.Create(
						view1: ObjCRuntime.Runtime.GetNSObject(children[i].Handle),
						attribute1: NSLayoutAttribute.Left,
						relation: NSLayoutRelation.Equal,
						view2: ObjCRuntime.Runtime.GetNSObject(children[i - 1].Handle),
						attribute2: NSLayoutAttribute.Right,
						multiplier: 1,
						constant: spacing));

					parent.AddConstraint(NSLayoutConstraint.Create(
						view1: ObjCRuntime.Runtime.GetNSObject(children[i].Handle),
						attribute1: NSLayoutAttribute.Width,
						relation: NSLayoutRelation.Equal,
						view2: children[0],
						attribute2: NSLayoutAttribute.Width,
						multiplier: 1,
						constant: 0));
				}

				parent.AddConstraint(NSLayoutConstraint.Create(
					view1: ObjCRuntime.Runtime.GetNSObject(children[children.Length - 1].Handle),
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

		}

		public static void Top(UIView parent, UIView child, nfloat top = default(nfloat))
		{

		}

		public static void Left(UIView parent, UIView child, nfloat left = default(nfloat))
		{

		}

		public static void Bottom(UIView parent, UIView child, nfloat bottom = default(nfloat))
		{

		}

		public static void Right(UIView parent, UIView child, nfloat right = default(nfloat))
		{

		}

		public static void TopLeft(UIView parent, UIView child, nfloat top = default(nfloat), nfloat left = default(nfloat))
		{

		}

		public static void TopRight(UIView parent, UIView child, nfloat top = default(nfloat), nfloat right = default(nfloat))
		{

		}

		public static void BottomLeft(UIView parent, UIView child, nfloat bottom = default(nfloat), nfloat left = default(nfloat))
		{

		}

		public static void BottomRight(UIView parent, UIView child, nfloat bottom = default(nfloat), nfloat right = default(nfloat))
		{

		}

		public static void Center(UIView parent, UIView child, nfloat offsetX = default(nfloat), nfloat offsetY = default(nfloat))
		{

		}

		public static void CenterHorizontally(UIView parent, UIView child, nfloat offset = default(nfloat))
		{

		}

		public static void CenterVertically(UIView parent, UIView child, nfloat offset = default(nfloat))
		{

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

	public partial interface IUIView
	{
		Layout Layout { get; set; }
	}
}
