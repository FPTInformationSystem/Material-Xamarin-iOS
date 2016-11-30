using System;
using System.Collections.Generic;
using Foundation;
using FPT.Framework.iOS.Material;
using UIKit;

namespace MaterialCollectionViewDemo
{
	public partial class ViewController : UIViewController
	{
		class ViewControllerDataSource : CollectionViewDataSource
		{
			private ViewController mParent;

			public ViewControllerDataSource(ViewController parent)
			{
				mParent = parent;
			}

			public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
			{
				CollectionViewCell cell = collectionView.DequeueReusableCell("CollectionViewCell", indexPath) as CollectionViewCell;

				var item = mParent.DataSourceItems[(int)indexPath.Item];
				cell.BackgroundColor = Color.White;

				return cell;
			}

			public override nint GetItemsCount(UICollectionView collectionView, nint section)
			{
				return mParent.DataSourceItems.Count;
			}

			public override List<CollectionDataSourceItem> Items()
			{
				return mParent.DataSourceItems;
			}
		}

		private List<CollectionDataSourceItem> DataSourceItems { get; set; }
		private CollectionView CollectionView { get; set; }

		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			prepareView();
			prepareItems();
			prepareCollectionView();
		}

		private void prepareView()
		{
			View.BackgroundColor = Color.Grey.Lighten3;
		}

		private void prepareItems()
		{
			DataSourceItems = new List<CollectionDataSourceItem>() {
				new CollectionDataSourceItem(data: new  {
					placeholder = "Field Placeholder",
					detailLabelHidden = false
				}, height: 80f),
				new CollectionDataSourceItem(data: new  {
					placeholder = "Field Placeholder",
					detailLabelHidden = false
				}, height: 80f),
				new CollectionDataSourceItem(data: new  {
					placeholder = "Field Placeholder",
					detailLabelHidden = false
				}, height: 80f)
			};
		}

		private void prepareCollectionView()
		{
			CollectionView = new CollectionView(frame: View.Bounds);
			CollectionView.RegisterClassForCell(typeof(CollectionViewCell), "CollectionViewCell");
			CollectionView.DataSource = new ViewControllerDataSource(this);
			var edgeInsets = CollectionView.ContentEdgeInsets;
			edgeInsets.Top = 100;
			CollectionView.ContentEdgeInsets = edgeInsets;
			CollectionView.InterimSpace = 16f;

			View.Layout(CollectionView).Edges();

		}
	}
}
