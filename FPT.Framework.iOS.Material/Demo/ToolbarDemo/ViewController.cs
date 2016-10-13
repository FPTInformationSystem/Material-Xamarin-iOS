using System;
using FPT.Framework.iOS.Material;
using UIKit;

namespace ToolbarDemo
{
	public partial class ViewController : UIViewController
	{

		#region PROPERTIES

		private UIView containerView { get; set; }

		private Toolbar toolbar { get; set; }

		#endregion

		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			prepareView();
			prepareContainerView();
			prepareToolbar();
		}

		void prepareView()
		{
			View.BackgroundColor = MaterialColor.White;
		}

		void prepareContainerView()
		{
			containerView = new UIView();
			View.Layout(containerView).Edges(top: 100, left: 20, right: 20);
		}

		void prepareToolbar()
		{
			toolbar = new Toolbar();
			containerView.AddSubview(toolbar);

			toolbar.Title = "Material";
			toolbar.TitleLabel.TextColor = MaterialColor.White;

			toolbar.Detail = "Build Beautiful Software";
			toolbar.DetailLabel.TextColor = MaterialColor.White;

			var image = MaterialIcon.CM.Menu;

			var menuButton = new IconButton();
			menuButton.PulseColor = MaterialColor.White;
			menuButton.TintColor = MaterialColor.White;
			menuButton.SetImage(image, UIControlState.Normal);
			menuButton.SetImage(image, UIControlState.Highlighted);

			var switchControl = new MaterialSwitch(state: MaterialSwitchState.Off, style: MaterialSwitchStyle.LightContent, size: MaterialSwitchSize.Small);

			image = MaterialIcon.CM.Search;
			var searchButton = new IconButton();
			searchButton.PulseColor = MaterialColor.White;
			searchButton.TintColor = MaterialColor.White;
			searchButton.SetImage(image, UIControlState.Normal);
			searchButton.SetImage(image, UIControlState.Highlighted);

			/*
			To lighten the status bar - add the
			"View controller-based status bar appearance = NO"
			to your info.plist file and set the following property.
			*/
			toolbar.BackgroundColor = MaterialColor.Blue.Base;
			toolbar.LeftControls = new UIControl[] {
				menuButton
			};
			toolbar.RightControls = new UIControl[] {
				switchControl, searchButton
			};
		}
	}
}
