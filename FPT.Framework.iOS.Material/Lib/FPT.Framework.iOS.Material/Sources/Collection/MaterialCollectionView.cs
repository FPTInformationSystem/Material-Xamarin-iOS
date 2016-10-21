// MIT/X11 License
//
// MaterialCollectionView.cs
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
using UIKit;

namespace FPT.Framework.iOS.Material
{
	public class MaterialCollectionView : UICollectionView
	{

		#region PROPERTIES

		public nfloat X
		{
			get
			{
				return Layer.Frame.X;
			}
			set
			{
				var frame = Layer.Frame;
				frame.X = value;
				Frame = frame;
			}
		}

		public nfloat Y
		{
			get
			{
				return Layer.Frame.Y;
			}
			set
			{
				var frame = Layer.Frame;
				frame.Y = value;
				Frame = frame;
			}
		}

		public nfloat Width
		{
			get
			{
				return Layer.Frame.Width;
			}
			set
			{
				var frame = Layer.Frame;
				frame.Width = value;
				Frame = frame;
			}
		}

		public nfloat Height
		{
			get
			{
				return Layer.Frame.Height;
			}
			set
			{
				var frame = Layer.Frame;
				frame.Height = value;
				Frame = frame;
			}
		}

		public EdgeInsetsPreset ContentInsetPreset
		{
			get
			{
				return (CollectionViewLayout as MaterialCollectionViewLayout).ContentInsetPreset;
			}
			set
			{
				(CollectionViewLayout as MaterialCollectionViewLayout).ContentInsetPreset = value;
			}
		}

		public override UIEdgeInsets ContentInset
		{
			get
			{
				return (CollectionViewLayout as MaterialCollectionViewLayout).ContentInset;
			}
			set
			{
				(CollectionViewLayout as MaterialCollectionViewLayout).ContentInset = value;
			}
		}

		public UICollectionViewScrollDirection ScrollDirection
		{
			get
			{
				return (CollectionViewLayout as MaterialCollectionViewLayout).ScrollDirection;
			}
			set
			{
				(CollectionViewLayout as MaterialCollectionViewLayout).ScrollDirection = value;
			}
		}

		public InterimSpacePreset SpacingPreset
		{
			get
			{
				return (CollectionViewLayout as MaterialCollectionViewLayout).SpacingPreset;
			}
			set
			{
				(CollectionViewLayout as MaterialCollectionViewLayout).SpacingPreset = value;
			}
		}

		public nfloat Spacing
		{
			get
			{
				return (CollectionViewLayout as MaterialCollectionViewLayout).Spacing;
			}
			set
			{
				(CollectionViewLayout as MaterialCollectionViewLayout).Spacing = value;
			}
		}

		#endregion

		public MaterialCollectionView(Foundation.NSCoder coder) : base(coder)
		{
			this.prepareView();
		}

		public MaterialCollectionView(CGRect frame, UICollectionViewLayout layout) : base(frame, layout)
		{
			this.prepareView();
		}

		public MaterialCollectionView(CGRect frame) : base(frame, new MaterialCollectionViewLayout())
		{
			this.prepareView();
		}


		public MaterialCollectionView() : this (CGRect.Empty)
		{
		}

		#region FUNCTIONS

		public virtual void prepareView()
		{
			ContentScaleFactor = Device.Scale;
			BackgroundColor = Color.Clear;
			ContentInset = UIEdgeInsets.Zero;
		}

		#endregion
	}
}
