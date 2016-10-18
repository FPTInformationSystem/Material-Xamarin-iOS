using System;
using System.Collections.Generic;
using FPT.Framework.iOS.Material;
using UIKit;

namespace NavigationControllerDemo
{
	public partial class ViewController : UIViewController
	{

		private IconButton menuButton { get; set; }
		private MaterialSwitch switchControl { get; set;}
		private IconButton searchButton { get; set; }

		public ViewController() : base()
		{
		}

		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			prepareView();
			prepareMenuButton();
			prepareSwitchControl();
			prepareSearchButton();
			prepareNavigationItem();
			prepareNavigationBar();
		}

		void prepareView()
		{
			View.BackgroundColor = MaterialColor.Grey.Lighten5;
		}

		void prepareMenuButton()
		{
			var image = MaterialIcon.CM.Menu;
			menuButton = new IconButton();
			menuButton.PulseColor = MaterialColor.White;
			menuButton.SetImage(image, UIControlState.Normal);
			menuButton.SetImage(image, UIControlState.Highlighted);
		}

		void prepareSwitchControl()
		{
			switchControl = new MaterialSwitch(MaterialSwitchState.Off, MaterialSwitchStyle.LightContent, MaterialSwitchSize.Small);
		}

		void prepareSearchButton()
		{
			var image = MaterialIcon.CM.Search;
			searchButton = new IconButton();
			searchButton.PulseColor = MaterialColor.White;
			searchButton.SetImage(image, UIControlState.Normal);
			searchButton.SetImage(image, UIControlState.Highlighted);
		}

		void prepareNavigationItem()
		{
			NavigationItem.SetTitle("Recipes");
			NavigationItem.Titlelabel().TextAlignment = UITextAlignment.Left;
			NavigationItem.Titlelabel().Font = RobotoFont.MediumWithSize(20);
			NavigationItem.SetLeftControls(new List<UIControl>() {
				menuButton	
			});
			NavigationItem.SetRightControls(new List<UIControl>() {
				switchControl, searchButton
			});
		}

		void prepareNavigationBar()
		{
			if (NavigationController != null)
			{
				NavigationController.NavigationBar.BarStyle = UIBarStyle.Default;
			}
		}
	}
}
