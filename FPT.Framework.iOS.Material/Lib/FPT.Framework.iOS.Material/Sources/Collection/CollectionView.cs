// MIT/X11 License
//
// CollectionView.cs
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
	public partial class CollectionView : UICollectionView
	{

		public EdgeInsetsPreset ContentEdgeInsetsPreset
		{
			get
			{
				if (CollectionViewLayout is CollectionViewLayout)
				{
					return ((CollectionViewLayout)CollectionViewLayout).ContentEdgeInsetsPreset;
				}
				else
				{
					return default(EdgeInsetsPreset);
				}
			}
			set
			{
				if (CollectionViewLayout is CollectionViewLayout)
				{
					((CollectionViewLayout)CollectionViewLayout).ContentEdgeInsetsPreset = value;
				}
			}
		}

		public UIEdgeInsets ContentEdgeInsets
		{
			get
			{
				if (CollectionViewLayout is CollectionViewLayout)
				{
					return ((CollectionViewLayout)CollectionViewLayout).ContentEdgeInsets;
				}
				else
				{
					return default(UIEdgeInsets);
				}
			}
			set
			{
				if (CollectionViewLayout is CollectionViewLayout)
				{
					((CollectionViewLayout)CollectionViewLayout).ContentEdgeInsets = value;
				}
			}
		}

		public UICollectionViewScrollDirection ScrollDirection
		{
			get
			{
				if (CollectionViewLayout is CollectionViewLayout)
				{
					return ((CollectionViewLayout)CollectionViewLayout).ScrollDirection;
				}
				else
				{
					return default(UICollectionViewScrollDirection);
				}
			}
			set
			{
				if (CollectionViewLayout is CollectionViewLayout)
				{
					((CollectionViewLayout)CollectionViewLayout).ScrollDirection = value;
				}
			}
		}

		public nfloat InterimSpace
		{
			get
			{
				if (CollectionViewLayout is CollectionViewLayout)
				{
					return ((CollectionViewLayout)CollectionViewLayout).InterimSpace;
				}
				else
				{
					return default(nfloat);
				}
			}
			set
			{
				if (CollectionViewLayout is CollectionViewLayout)
				{
					((CollectionViewLayout)CollectionViewLayout).InterimSpace = value;
				}
			}
		}

		public CollectionView(Foundation.NSCoder coder) : base(coder)
		{
			this.Prepare();
		}

		public CollectionView(CGRect frame, UICollectionViewLayout layout) : base(frame, layout)
		{
			this.Prepare();
		}

		public CollectionView(CGRect frame) : base(frame, new CollectionViewLayout())
		{
			this.Prepare();
		}

		public CollectionView() : this(CGRect.Empty)
		{
		}

		public virtual void Prepare()
		{
			this.ContentScaleFactor = Device.Scale;
			BackgroundColor = Color.Clear;
			this.ContentEdgeInsets = UIEdgeInsets.Zero; 
		}
	}
}

