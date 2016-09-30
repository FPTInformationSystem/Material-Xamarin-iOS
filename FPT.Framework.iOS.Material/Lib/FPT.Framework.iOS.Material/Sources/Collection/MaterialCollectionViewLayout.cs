// MIT/X11 License
//
// MaterialCollectionViewLayout.cs
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
using System.Collections.Generic;
using CoreFoundation;
using Foundation;

namespace FPT.Framework.iOS.Material
{
	public class MaterialCollectionViewLayout : UICollectionViewLayout
	{
		#region PROPERTIES

		internal CGPoint Offset { get; set; } = CGPoint.Empty;

		internal CGPoint ItemSize { get; set; } = CGPoint.Empty;

		private MaterialEdgeInset mContentInsetPreset = MaterialEdgeInset.None;
		public MaterialEdgeInset ContentInsetPreset
		{
			get
			{
				return mContentInsetPreset;
			}
			set
			{
				mContentInsetPreset = value;
			}
		}

		public UIEdgeInsets ContentInset { get; set; } = UIEdgeInsets.Zero;

		public CGSize ContentSize { get; private set; } = CGSize.Empty;

		public List<Tuple<UICollectionViewLayoutAttributes, NSIndexPath>> LayoutItems { get; private set; } = new List<Tuple<UICollectionViewLayoutAttributes, NSIndexPath>>();

		public List<MaterialDataSourceItem> DataSourceItems { get; private set; } = new List<MaterialDataSourceItem>();

		public UICollectionViewScrollDirection ScrollDirection { get; set; } = UICollectionViewScrollDirection.Vertical;

		private MaterialSpacing mSpacingPreset = MaterialSpacing.None;
		public MaterialSpacing SpacingPreset 
		{
			get
			{
				return mSpacingPreset;
			}
			set
			{
				mSpacingPreset = value;
				Spacing = Convert.MaterialSpacingToValue(mSpacingPreset);
			}
		}

		public nfloat Spacing { get; set; } = 0;


		#endregion

		#region CONSTRUCTORS

		public MaterialCollectionViewLayout() : base()
		{
		}

		#endregion

		#region FUNCTIONS

		public List<NSIndexPath> IndexPathsOfItemsInRect(CGRect rect)
		{
			var paths = new List<NSIndexPath>();

			foreach (var item in LayoutItems)
			{
				if (rect.IntersectsWith(item.Item1.Frame))
				{
					paths.Add(item.Item2);
				}
			}

			return paths;
		}

		public override UICollectionViewLayoutAttributes LayoutAttributesForItem(NSIndexPath indexPath)
		{
			return base.LayoutAttributesForItem(indexPath);
		}

		public override UICollectionViewLayoutAttributes[] LayoutAttributesForElementsInRect(CGRect rect)
		{
			return base.LayoutAttributesForElementsInRect(rect);
		}

		public override bool ShouldInvalidateLayoutForBoundsChange(CGRect newBounds)
		{
			return base.ShouldInvalidateLayoutForBoundsChange(newBounds);
		}

		public override CGSize CollectionViewContentSize
		{
			get
			{
				return ContentSize;
			}
		}

		public override void PrepareLayout()
		{
			var dataSource = CollectionView.DataSource;
			//
		}

		public override CGPoint TargetContentOffsetForProposedContentOffset(CGPoint proposedContentOffset)
		{
			return proposedContentOffset;
		}

		private void prepareLayoutForItems(List<MaterialDataSourceItem> dataSourceItems)
		{
		}

		#endregion
	}
}
