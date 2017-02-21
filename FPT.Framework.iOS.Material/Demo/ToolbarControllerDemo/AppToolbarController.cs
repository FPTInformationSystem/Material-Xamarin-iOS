using System;
using UIKit;
using FPT.Framework.iOS.Material;
using ObjCRuntime;
using Foundation;
using System.Collections.Generic;

namespace ToolbarControllerDemo
{
	public class AppToolbarController : ToolbarController
	{

		#region PROPERTIES
		private IconButton menuButton;
		private IconButton starButton;
		private IconButton searchButton;
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
			prepareStarButton();
			prepareSearchButton();
			prepareStatusBar();
			prepareToolbar();
		}

		void prepareMenuButton()
		{
			menuButton = new IconButton(Icon.CM.Menu, Color.White);
			menuButton.PulseColor = Color.White;
		}

		void prepareStarButton()
		{
			starButton = new IconButton(Icon.CM.Star, Color.White);
			starButton.PulseColor = Color.White;
		}

		void prepareSearchButton()
		{
			searchButton = new IconButton(Icon.CM.Search, Color.White);
			searchButton.PulseColor = Color.White;
		}

		void prepareStatusBar()
		{
			StatusBarStyle = UIStatusBarStyle.LightContent;
			StatusBar.BackgroundColor = Color.Blue.Darken3;
		}

		private void prepareToolbar()
		{
			Toolbar.BackgroundColor = Color.Blue.Darken2;
			Toolbar.LeftViews = new List<UIView>() { menuButton };
			Toolbar.RightViews = new List<UIView>() { starButton, searchButton };
		}



		#endregion
	}
}
