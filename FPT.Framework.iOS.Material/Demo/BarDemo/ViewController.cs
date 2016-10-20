using System;
using System.Collections.Generic;
using FPT.Framework.iOS.Material;
using UIKit;

namespace BarDemo
{
	public partial class ViewController : UIViewController
	{
		private Bar bar { get; set;}

		private IconButton menuButton { get; set;}

		private IconButton favoriteButton { get; set; }
		private IconButton shareButton { get; set; }

		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			View.BackgroundColor = Color.White;
			prepareMenuButton();
			prepareFavoriteButton();
			prepareShareButton();
			prepareBar();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		private void prepareMenuButton()
		{
			menuButton = new IconButton(Icon.CM.Menu, Color.White);
			menuButton.PulseColor = Color.White;
		}

		private void prepareFavoriteButton()
		{
			favoriteButton = new IconButton(Icon.Favorite, Color.White);
			favoriteButton.PulseColor = Color.White;
		}

		private void prepareShareButton()
		{
			shareButton = new IconButton(Icon.CM.Share, Color.White);
			shareButton.PulseColor = Color.White;
		}

		private void prepareBar()
		{
			bar = new Bar(new List<UIView>()
			{
				menuButton
			}, new List<UIView>()
			{
				favoriteButton, shareButton
			});
			bar.BackgroundColor = Color.Blue.Base;

			bar.ContentView.SetCornerRadiusPreset(CornerRadiusPreset.Radius1);
			bar.ContentView.BackgroundColor = Color.Blue.Lighten3;

			View.Layout(bar).Horizontally().Center();
		}
	}
}
