// MIT/X11 License
//
// MaterialLabel.cs
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
using FPT.Framework.iOS.Material;
using Foundation;
using ObjCRuntime;
using UIKit;
using CoreGraphics;

namespace FPT.Framework.iOS.Material
{
	public class MaterialLabel : UILabel
	{

		[Export("layerClass")]
		public static Class LayerClass()
		{
			return new Class(typeof(MaterialTextLayer));
		}

		#region PROPERTIES

		public MaterialTextLayer TextLayer
		{
			get
			{
				return Layer as MaterialTextLayer;
			}
		}

		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				TextLayer.Text = Text;
			}
		}

		public override UIColor TextColor
		{
			get
			{
				return base.TextColor;
			}
			set
			{
				base.TextColor = value;
				TextLayer.TextColor = TextColor;
			}
		}

		public override UIFont Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font = value;
				TextLayer.FontType = Font;
			}
		}

		public override UITextAlignment TextAlignment
		{
			get
			{
				return base.TextAlignment;
			}
			set
			{
				base.TextAlignment = value;
				TextLayer.TextAlignment = TextAlignment;
			}
		}

		private bool mWrapped;
		public bool Wrapped
		{
			get
			{
				return mWrapped;		
			}
			set
			{
				mWrapped = value;
				TextLayer.Wrapped = mWrapped;
			}
		}

		private nfloat mContentsScale;
		public nfloat ContentsScale
		{
			get
			{
				return mContentsScale;
			}
			set
			{
				mContentsScale = value;
				TextLayer.ContentsScale = mContentsScale;
			}
		}

		public override UILineBreakMode LineBreakMode
		{
			get
			{
				return base.LineBreakMode;
			}
			set
			{
				base.LineBreakMode = value;
				TextLayer.LineBreakMode = LineBreakMode;
			}
		}

		#endregion

		#region CONSTRUCTORS

		public MaterialLabel() : this(CGRect.Empty) { }

		public MaterialLabel(Foundation.NSCoder coder) : base(coder)
		{
			Wrapped = true;
			ContentsScale = MaterialDevice.Scale;
			prepareView();
		}

		public MaterialLabel(CGRect frame) : base(frame)
		{
			Wrapped = true;
			ContentsScale = Material.MaterialDevice.Scale;
			prepareView();
		}

		#endregion

		#region FUNCTIONS

		public CGSize StringSize(double width)
		{
			return TextLayer.StringSize(width);
		}

		public virtual void prepareView()
		{
			ContentScaleFactor = MaterialDevice.Scale;
			TextAlignment = UITextAlignment.Left;
		}

		#endregion
	}
}
