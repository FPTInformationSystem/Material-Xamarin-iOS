using System;
using FPT.Framework.iOS.Material;
using UIKit;

namespace SearchBarDemo
{
	public partial class ViewController : UIViewController
	{

		private UIView containerView { get; set; }

		private SearchBar searchBar { get; set; }

		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			ViewController.ViewDidLoad(base);
			// Perform any additional setup after loading the view, typically from a nib.
			prepareView();
			prepareContainerView();
			prepareSearchBar();
		}

		private void prepareView()
		{
			View.BackgroundColor = MaterialColor.White;
		}

		private void prepareContainerView()
		{
			containerView = new UIView();
			View.Layout(containerView).Edges(top: 100, left: 20, right: 20);
		}

		private void prepareSearchBar()
		{
			searchBar = new SearchBar();
			containerView.AddSubview(searchBar);

			var image = MaterialIcon.CM.MoreVertical;

			var moreButton = new IconButton();
			moreButton.PulseColor = MaterialColor.Grey.Base;
			moreButton.TintColor = MaterialColor.Grey.Darken4;
			moreButton.SetImage(image, UIControlState.Normal);
			moreButton.SetImage(image, UIControlState.Highlighted);

			searchBar.LeftControls = new UIControl[] {
				moreButton
			};
		}
	}
}
