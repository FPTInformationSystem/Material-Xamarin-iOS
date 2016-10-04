using System;
using System.Collections.Generic;
using Foundation;
using FPT.Framework.iOS.Material;
using UIKit;

namespace MaterialCollectionViewDemo
{
	public partial class ViewController : UIViewController
	{
		class ViewControllerDataSource : MaterialCollectionViewDataSource
		{
			private ViewController mParent;

			public ViewControllerDataSource(ViewController parent)
			{
				mParent = parent;
			}

			public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
			{
				throw new NotImplementedException();
			}

			public override nint GetItemsCount(UICollectionView collectionView, nint section)
			{
				throw new NotImplementedException();
			}

			public override List<MaterialDataSourceItem> Items()
			{
				return mParent.DataSourceItems;
			}
		}

		private List<MaterialDataSourceItem> DataSourceItems { get; set; }
		private MaterialCollectionView CollectionView { get; set; }

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
			View.BackgroundColor = MaterialColor.Grey.Lighten3;
		}

		private void prepareItems()
		{
			DataSourceItems = new List<MaterialDataSourceItem>() {
				new MaterialDataSourceItem(data: new object {
				}, height: 80f)
			};
		}

		private void prepareCollectionView()
		{
			CollectionView = new MaterialCollectionView(frame: View.Bounds);
			CollectionView.RegisterClassForCell(typeof(MaterialCollectionViewCell), "MaterialCollectionViewCell");
			CollectionView.DataSource = new ViewControllerDataSource(this);
			CollectionView.ContentInset.Top = 100;
			CollectionView.Spacing = 16f;



		}
	}
}
