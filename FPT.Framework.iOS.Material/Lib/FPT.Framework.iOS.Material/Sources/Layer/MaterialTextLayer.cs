// MIT/X11 License
//
// MaterialTextLayer.cs
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
using CoreGraphics;
using UIKit;
using Foundation;
using System.Text;

namespace FPT.Framework.iOS.Material
{
	public class MaterialTextLayer : CATextLayer
	{
		#region VARIABLES

		private UIFont mFontType;
		private string mText;
		private nfloat mPointSize = 10f;
		private UIColor mTextColor;
		private UITextAlignment mTextAlignment = UITextAlignment.Left;
		private UILineBreakMode mLineBreakMode = UILineBreakMode.WordWrap;

		#endregion

		#region PROPERTIES

		public UIFont FontType
		{
			get
			{
				return mFontType;
			}

			set
			{
				mFontType = value;
				if (mFontType != null)
				{
					base.SetFont(CGFont.CreateWithFontName(mFontType.Name));


				}
			}
		}

		public string Text
		{
			get
			{
				return mText;
			}
			set
			{
				mText = value;
				this.String = Text;
			}
		}

		public nfloat PointSize
		{
			get
			{
				return mPointSize;
			}
			set
			{
				mPointSize = value;
				FontSize = mPointSize;
			}
		}

		public UIColor TextColor
		{
			get
			{
				return mTextColor;
			}
			set
			{
				mTextColor = value;
				ForegroundColor = TextColor.CGColor;
			}
		}

		public UITextAlignment TextAlignment
		{
			get
			{
				return mTextAlignment;
			}
			set
			{
				mTextAlignment = value;
				switch (mTextAlignment)
				{
					case UITextAlignment.Left:
						AlignmentMode = AlignmentLeft;
						break;
					case UITextAlignment.Center:
						AlignmentMode = AlignmentCenter;
						break;
					case UITextAlignment.Right:
						AlignmentMode = AlignmentRight;
						break;
					case UITextAlignment.Justified:
						AlignmentMode = AlignmentJustified;
						break;
					case UITextAlignment.Natural:
						AlignmentMode = AlignmentNatural;
						break;
					default:
						break;
				}
			}
		}

		public UILineBreakMode LineBreakMode
		{
			get
			{
				return mLineBreakMode;
			}
			set
			{
				mLineBreakMode = value;
				switch (mLineBreakMode)
				{
					case UILineBreakMode.WordWrap:
						TruncationMode = TruncationNone;
						break;
					case UILineBreakMode.CharacterWrap:
						TruncationMode = TruncationNone;
						break;
					case UILineBreakMode.Clip:
						TruncationMode = TruncationNone;
						break;
					case UILineBreakMode.HeadTruncation:
						TruncationMode = TruncantionStart;
						break;
					case UILineBreakMode.TailTruncation:
						TruncationMode = TruncantionEnd;
						break;
					case UILineBreakMode.MiddleTruncation:
						TruncationMode = TruncantionMiddle;
						break;
				}
			}
		}

		public nfloat X
		{
			get
			{
				return Frame.X;
			}
			set
			{
				var frame = Frame;
				frame.X = value;
				Frame = frame;
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
			}
		}

		public nfloat Height
		{
			get
			{
				return Frame.Height;
			}
			set
			{
				var frame = Frame;
				frame.Height = value;
				Frame = frame;
			}
		}

		#endregion

		#region CONSTRUCTORS

		public MaterialTextLayer() : base()
		{
		}

		public MaterialTextLayer(Foundation.NSCoder coder) : base(coder)
		{
			prepareLayer();
		}


		#endregion

		#region FUNCTIONS

		public CGSize StringSize(double width)
		{
			var v = FontType;
			if (v != null)
			{
				if (0 < Text.Length)
				{
					return v.StringSize(new NSString(Text), width);
				}
			}
			return CGSize.Empty;
		}

		internal void prepareLayer()
		{
			TextColor = MaterialColor.Black;
			TextAlignment = UITextAlignment.Left;
			Wrapped = true;
			ContentsScale = MaterialDevice.Scale;
			LineBreakMode = UILineBreakMode.WordWrap;
		}

		#endregion

	}
}
