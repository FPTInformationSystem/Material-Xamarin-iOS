using System;
using UIKit;
using FPT.Framework.iOS.Material;
using ObjCRuntime;
using Foundation;

namespace ToolbarControllerDemo
{
	public class AppToolbarController : ToolBarController
	{

		#region CONSTRUCTORS

		public AppToolbarController(UIViewController rootViewController) : base(rootViewController)
		{
		}

		#endregion

		#region FUNCTIONS

		public override void PrepareView()
		{
			base.PrepareView();
			StatusBarStyle = UIStatusBarStyle.LightContent;
			prepareToolbar();
		}

		[Export("handleMenuButton")]
		private void handleMenuButton()
		{

			//TransitionFromRootViewController(RootViewController is YellowViewController ? new GreenViewController() : new YellowViewController());
			if (RootViewController is YellowViewController)
			{
				TransitionFromRootViewController(new GreenViewController());
			}
			else
			{
				TransitionFromRootViewController(new YellowViewController());
			}

		}

		[Export("handleSearchButton")]
		private void handleSearchButton()
		{
			floatingViewController = new GreenViewController();
			MaterialAnimation.Delay(1.5, () =>
			{
				this.floatingViewController = null;
			});
		}

		private void prepareToolbar()
		{
			Toolbar.Title = "Material";
			Toolbar.TitleLabel.TextColor = MaterialColor.White;

			Toolbar.Detail = "Build Beautiful Software";
			Toolbar.DetailLabel.TextAlignment = UITextAlignment.Left;
			Toolbar.DetailLabel.TextColor = MaterialColor.White;

			var image = MaterialIcon.CM.Menu;

			var menuButton = new IconButton();
			menuButton.TintColor = MaterialColor.White;
			menuButton.PulseColor = MaterialColor.White;
			menuButton.SetImage(image, UIControlState.Normal);
			menuButton.SetImage(image, UIControlState.Highlighted);
			menuButton.AddTarget(this, new Selector("handleMenuButton"), UIControlEvent.TouchUpInside);

			var switchControl = new MaterialSwitch(MaterialSwitchState.Off, MaterialSwitchStyle.LightContent, MaterialSwitchSize.Small);

			image = MaterialIcon.CM.Search;
			var searchButton = new IconButton();
			searchButton.TintColor = MaterialColor.White;
			searchButton.PulseColor = MaterialColor.White;
			searchButton.SetImage(image, UIControlState.Normal);
			searchButton.SetImage(image, UIControlState.Highlighted);
			searchButton.AddTarget(this, new Selector("handleSearchButton"), UIControlEvent.TouchUpInside);

			Toolbar.BackgroundColor = MaterialColor.Blue.Base;
			Toolbar.LeftControls = new UIControl[] {
				menuButton
			};
			Toolbar.RightControls = new UIControl[] {
				switchControl, searchButton
			};
		}

		#endregion
	}
}
