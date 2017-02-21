using System;
using Foundation;
using FPT.Framework.iOS.Material;
using ObjCRuntime;
using UIKit;

namespace NavigationDrawerControllerDemo
{
	public class RightViewController : UIViewController
	{
		public RightViewController() : base()
		{
			
		}

		private FlatButton rootButton;

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			View.BackgroundColor = Color.Red.Base;

			PrepareTransitionButton();
		}


		private void PrepareTransitionButton()
		{
			rootButton = new FlatButton(title: "Root VC", titleColor: Color.White);
			rootButton.PulseColor = Color.White;
			rootButton.AddTarget(this, new Selector("HandleTransitionButton"), UIControlEvent.TouchUpInside);

			View.Layout(rootButton).Horizontally().Center();
		}

		[Export("HandleTransitionButton")]
		private void HandleTransitionButton()
		{
			var v = this.NavigationDrawerController();
			(v.RootViewController as ToolbarController).TransitionFromRootViewController(
				toViewController: new TransitionedViewController(), completion: null);
		}

		private bool CloseNavigationDrawer()
		{
			this.NavigationDrawerController().CloseRightView();
			return true;
		}
	}
}
