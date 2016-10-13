using System;
using UIKit;
using FPT.Framework.iOS.Material;
namespace SearchBarControllerDemo
{
	public class AppSearchBarController : SearchBarController
	{

		#region CONSTRUCTORS

		public AppSearchBarController(UIViewController rootViewController) : base(rootViewController)
		{
		}

		#endregion

		#region FUNCTIONS

		public override void PrepareView()
		{
			base.PrepareView();
			StatusBarStyle = UIStatusBarStyle.Default;
			prepareSearchBar();
		}

		private void prepareSearchBar()
		{
			var image = MaterialIcon.CM.ArrowBack;

			//Back button.
			var backButton = new IconButton();
			backButton.TintColor = MaterialColor.BlueGrey.Darken4;
			backButton.SetImage(image, UIControlState.Normal);
			backButton.SetImage(image, UIControlState.Highlighted);

			//More button.
			image = MaterialIcon.CM.MoreHorizontal;
			var moreButton = new IconButton();
			moreButton.TintColor = MaterialColor.BlueGrey.Darken4;
			moreButton.SetImage(image, UIControlState.Normal);
			moreButton.SetImage(image, UIControlState.Highlighted);

			SearchBar.TextField.Delegate = new AppSearchBarControllerTextFieldDelegate(this);
			SearchBar.LeftControls = new UIControl[] {
				backButton
			};

			SearchBar.RightControls = new UIControl[] {
				moreButton
			};
		}

		#endregion

		private class AppSearchBarControllerTextFieldDelegate : TextFieldDelegate
		{
			AppSearchBarController mParent;

			public AppSearchBarControllerTextFieldDelegate(AppSearchBarController parent)
			{
				mParent = parent;
			}

			public override void EditingStarted(UITextField textField)
			{
				mParent.RootViewController.View.Alpha = 0.5f;
				mParent.RootViewController.View.UserInteractionEnabled = false;
			}

			public override void EditingEnded(UITextField textField)
			{
				mParent.RootViewController.View.Alpha = 1;
				mParent.RootViewController.View.UserInteractionEnabled = true;
			}
		}
	}
}
