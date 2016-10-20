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

		private CGPoint mOffset = CGPoint.Empty;
		internal CGPoint Offset
		{
			get { return mOffset; }
			set
			{
				mOffset = value;
			}
		}

		internal CGSize ItemSize { get; set; } = CGSize.Empty;

		private EdgeInsetsPreset mContentInsetPreset = EdgeInsetsPreset.None;
		public EdgeInsetsPreset ContentInsetPreset
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

		private InterimSpacePreset mSpacingPreset = InterimSpacePreset.None;
		public InterimSpacePreset SpacingPreset 
		{
			get
			{
				return mSpacingPreset;
			}
			set
			{
				mSpacingPreset = value;
				Spacing = Convert.InterimSpacePresetToValue(mSpacingPreset);
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
			var attributes = UICollectionViewLayoutAttributes.CreateForCell(indexPath);
			var item = DataSourceItems[(int)indexPath.Item];

			if (0 < ItemSize.Width && 0 < ItemSize.Height)
			{
				attributes.Frame = new CGRect(Offset.X, Offset.Y, ItemSize.Width - ContentInset.Left - ContentInset.Right, ItemSize.Height - ContentInset.Top - ContentInset.Bottom);
			}
			else if (ScrollDirection == UICollectionViewScrollDirection.Vertical)
			{
				attributes.Frame = new CGRect(ContentInset.Left, Offset.Y, CollectionView.Bounds.Width - ContentInset.Left - ContentInset.Right, item.Height == null ? CollectionView.Bounds.Height : item.Height.Value);
			}
			else
			{
				attributes.Frame = new CGRect(Offset.X, ContentInset.Top, item.Width == null? CollectionView.Bounds.Width : item.Width.Value, CollectionView.Bounds.Height - ContentInset.Top - ContentInset.Bottom);
			}


			return attributes;
		}

		public override UICollectionViewLayoutAttributes[] LayoutAttributesForElementsInRect(CGRect rect)
		{
			var layoutAttributes = new List<UICollectionViewLayoutAttributes>();
			foreach (var item in LayoutItems)
			{
				if (rect.IntersectsWith(item.Item1.Frame))
				{
					layoutAttributes.Add(item.Item1);
				}
			}
			return layoutAttributes.ToArray();
		}

		public override bool ShouldInvalidateLayoutForBoundsChange(CGRect newBounds)
		{
			return ScrollDirection == UICollectionViewScrollDirection.Vertical ? newBounds.Width != CollectionView.Bounds.Width : newBounds.Height != CollectionView.Bounds.Height;
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
			if (dataSource != null && dataSource is MaterialCollectionViewDataSource)
			{
				prepareLayoutForItems((dataSource as MaterialCollectionViewDataSource).Items());
			}
		}

		public override CGPoint TargetContentOffsetForProposedContentOffset(CGPoint proposedContentOffset)
		{
			return proposedContentOffset;
		}

		private void prepareLayoutForItems(List<MaterialDataSourceItem> dataSourceItems)
		{
			LayoutItems.RemoveAll((obj) =>
			{
				return true;
			});

			mOffset.X = ContentInset.Left;
			mOffset.Y = ContentInset.Top;

			NSIndexPath indexPath;

			for (var i = 0; i < dataSourceItems.Count; i++)
			{
				var item = dataSourceItems[i];
				indexPath = NSIndexPath.FromItemSection(item: i, section: 0);
				LayoutItems.Add(new Tuple<UICollectionViewLayoutAttributes, NSIndexPath>(LayoutAttributesForItem(indexPath), indexPath));

				mOffset.X += Spacing;
				mOffset.X += item.Width == null ? ItemSize.Width : item.Width.Value;

				mOffset.Y += Spacing;
				mOffset.Y += item.Height == null ? ItemSize.Height : item.Height.Value;
			}

			mOffset.Y += ContentInset.Right - Spacing;
			mOffset.Y += ContentInset.Bottom - Spacing;

			if (0 < ItemSize.Width && 0 < ItemSize.Height)
			{
				ContentSize = new CGSize(Offset.X, Offset.Y);
			}
			else if (ScrollDirection == UICollectionViewScrollDirection.Vertical)
			{
				ContentSize = new CGSize(CollectionView.Bounds.Width, Offset.Y);
			}
			else
			{
				ContentSize = new CGSize(Offset.X, CollectionView.Bounds.Height);
			}
		}

		#endregion
	}
}
