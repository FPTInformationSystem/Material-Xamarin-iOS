using System;
using UIKit;
using FPT.Framework.iOS.Material;
using ObjCRuntime;
using Foundation;

namespace NavigationDrawerControllerDemo
{
	public class LeftViewController :UIViewController
	{

		private FlatButton TransitionButton;

		public LeftViewController() : base()
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			View.BackgroundColor = Color.Green.Base;

			PrepareTransitionButton();
		}


		private void PrepareTransitionButton()
		{
			TransitionButton = new FlatButton(title: "Transition VC", titleColor: Color.White);
			TransitionButton.PulseColor = Color.White;
			TransitionButton.AddTarget(this, new Selector("HandleTransitionButton"), UIControlEvent.TouchUpInside);

			View.Layout(TransitionButton).Horizontally().Center();
		}

		[Export("HandleTransitionButton")]
		private void HandleTransitionButton()
		{
			var v = this.NavigationDrawerController();
			(v.RootViewController as ToolbarController).TransitionFromRootViewController(
				toViewController: new TransitionedViewController(), completion:null);
		}

		private bool CloseNavigationDrawer()
		{
			this.NavigationDrawerController().CloseLeftView();
			return true;
		}
	}
}
