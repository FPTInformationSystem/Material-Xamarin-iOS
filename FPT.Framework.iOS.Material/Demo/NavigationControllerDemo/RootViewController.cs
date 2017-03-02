using System;
using System.Collections.Generic;
using UIKit;
using FPT.Framework.iOS.Material;
using ObjCRuntime;
using Foundation;

namespace NavigationControllerDemo
{
	public class RootViewController : UIViewController
	{
		#region PROPERTIES

		private IconButton menuButton { get; set; }
		private IconButton starButton { get; set; }
		private IconButton searchButton { get; set; }

		private FlatButton nextButton { get; set; }

		#endregion

		#region CONSTRUCTORS

		protected RootViewController(IntPtr handle) { }

		public RootViewController() : base() { }

		#endregion

		#region FUNCTIONS

		public override CoreGraphics.CGSize PreferredContentSize
		{
			get
			{
				
				return new CoreGraphics.CGSize(730, 768);
			}
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			this.NavigationController.NavigationBar.LayoutSubviews();
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			View.BackgroundColor = Color.Grey.Lighten5;

			prepareMenuButton();
			prepareStarButton();
			prepareSearchButton();
			prepareNavigationItem();
			prepareNextButton();
		}

		[Export("handleNextButton")]
		internal void handleNextButton()
		{
			//navigationController?.pushViewController(NextViewController(), animated: true)
			if (NavigationController != null)
			{
				NavigationController.PushViewController(new NextViewController(), true);
			}

		}

		private void prepareMenuButton()
		{
			menuButton = new IconButton(image: Icon.CM.Menu);
			menuButton.TouchUpInside += (sender, e) =>
			{
				this.DismissViewController(true, null);
			};

		}

		private void prepareStarButton()
		{
			starButton = new IconButton(image: Icon.CM.Star);
		}

		private void prepareSearchButton()
		{
			searchButton = new IconButton(image: Icon.CM.Search);
			searchButton.TouchUpInside += (object sender, EventArgs e) =>
			{
				var newVC = new AppNavigationController(new RootViewController());
				newVC.ModalTransitionStyle = UIModalTransitionStyle.CoverVertical;
				newVC.ModalPresentationStyle = UIModalPresentationStyle.FormSheet;
				this.PresentViewController(newVC, true, () =>
				{
					
				});
			};
		}

		private void prepareNavigationItem()
		{
			NavigationItem.SetTitle("Material");
			NavigationItem.SetDetail("Build Beautiful Software"); ;
			NavigationItem.SetLeftViews(new List<UIView>()
			{
				menuButton
			});


			NavigationItem.SetRightViews(new List<UIView>()
			{
				starButton, searchButton
			});
		}

		private void prepareNextButton()
		{
			nextButton = new FlatButton(title: "Click To Open", titleColor: Color.Grey.Base);

			nextButton.PulseAnimation = PulseAnimation.None;

			nextButton.AddTarget(this, new Selector("handleNextButton"), UIControlEvent.TouchUpInside);
			View.Layout(nextButton).Edges();

		}

		#endregion
	}
}
