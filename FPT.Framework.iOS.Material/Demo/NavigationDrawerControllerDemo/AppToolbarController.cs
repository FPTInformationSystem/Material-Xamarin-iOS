using System;
using System.Collections.Generic;
using Foundation;
using FPT.Framework.iOS.Material;
using ObjCRuntime;
using UIKit;

namespace NavigationDrawerControllerDemo
{
	public class AppToolbarController : ToolbarController
	{
		#region PROPERTIES
		private IconButton menuButton;
		private IconButton moreButton;
		#endregion

		#region CONSTRUCTORS

		public AppToolbarController(UIViewController rootViewController) : base(rootViewController)
		{
			
		}

		#endregion

		#region FUNCTIONS

		public override void Prepare()
		{
			base.Prepare();
			prepareMenuButton();
			prepareMoreButton();
			PrepareStatusBar();
			prepareToolbar();
		}

		void prepareMenuButton()
		{
			menuButton = new IconButton(Icon.CM.Menu, Color.White);
			menuButton.PulseColor = Color.White;
			menuButton.AddTarget(this, new Selector("HandleMenuButton"), UIControlEvent.TouchUpInside);
		}

		void prepareMoreButton()
		{
			moreButton = new IconButton(Icon.CM.Search, Color.White);
			moreButton.PulseColor = Color.White;
			moreButton.AddTarget(this, new Selector("HandleMoreButton"), UIControlEvent.TouchUpInside);
			
		}

		private void PrepareStatusBar()
		{
			StatusBarStyle = UIStatusBarStyle.LightContent;
			//StatusBar.BackgroundColor = Color.Blue.Darken3;
		}

		private void prepareToolbar()
		{
			Toolbar.BackgroundColor = Color.Blue.Darken2;
			Toolbar.LeftViews = new List<UIView>() { menuButton };
			Toolbar.RightViews = new List<UIView>() { moreButton };
		}



		[Export("HandleMenuButton")]
		private void HandleMenuButton()
		{
			this.NavigationDrawerController().ToggleLeftView();
		}

		[Export("HandleMoreButton")]
		private void HandleMoreButton()
		{
			this.NavigationDrawerController().ToggleRightView();
		}

		#endregion
	}
}