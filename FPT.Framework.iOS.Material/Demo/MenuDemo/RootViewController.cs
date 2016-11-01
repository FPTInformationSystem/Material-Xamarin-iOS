using System;
using UIKit;
using FPT.Framework.iOS.Material;
using ObjCRuntime;
using Foundation;

namespace MenuDemo
{
	public class RootViewController : UIViewController
	{

		internal FabButton addButton { get; set;}
		internal MenuItem audioLibraryMenuItem { get; set; }
		internal MenuItem reminderMenuItem { get; set; }

		public RootViewController()
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			View.BackgroundColor = Color.Grey.Lighten5;

			prepareAddButton();
			prepareAudioLibraryButton();
			prepareBellButton();
		}

		public override void ViewDidAppear(bool animated)
		{
			base.ViewDidAppear(animated);
			prepareMenuController();
		}

		[Export("handleToggleMenu")]
		internal void handleToggleMenu()
		{
			var mc = this.MenuController() as AppMenuController;

			if (mc == null) return;

			if (mc.Menu.IsOpened)
			{
				mc.CloseMennu((UIView view) =>
				{
					(view as MenuItem).HideTitleLabel();
				});
			}
			else
			{
				mc.OpenMennu((UIView view) =>
				{
					(view as MenuItem).ShowTitleLabel();
				});
			}
		}

		private void prepareAddButton()
		{
			addButton = new FabButton(Icon.CM.Add);
			addButton.AddTarget(this, new Selector("handleToggleMenu"), UIControlEvent.TouchUpInside);
		}

		private void prepareAudioLibraryButton()
		{
			audioLibraryMenuItem = new MenuItem();
			audioLibraryMenuItem.Button.Image = Icon.CM.AudioLibrary;
			audioLibraryMenuItem.Button.BackgroundColor = Color.Green.Base;
			audioLibraryMenuItem.Button.SetDepthPreset(DepthPreset.Depth1);
			audioLibraryMenuItem.Title = "Audio Library";

			audioLibraryMenuItem.Button.TouchUpInside += (sender, e) =>
			{
				Console.WriteLine("FF");
			};
		}

		private void prepareBellButton()
		{
			reminderMenuItem = new MenuItem();
			reminderMenuItem.Button.Image = Icon.CM.Bell;
			reminderMenuItem.Button.BackgroundColor = Color.Green.Base;
			reminderMenuItem.Button.SetDepthPreset(DepthPreset.Depth1);
			reminderMenuItem.Title = "Audio Library";

			reminderMenuItem.Button.TouchUpInside += (sender, e) =>
			{
				Console.WriteLine("FF");
			};
		}

		private void prepareMenuController()
		{
			var mc = this.MenuController() as AppMenuController;
			if (mc != null)
			{
				mc.Menu.Delegate = new RootViewControllerMenuDelegate(this);
			}
			mc.Menu.Views = new UIView[] {
				addButton, audioLibraryMenuItem, reminderMenuItem
			};
		}

		private class RootViewControllerMenuDelegate : MenuDelegate
		{
			RootViewController mParent;
			public RootViewControllerMenuDelegate(RootViewController parent)
			{
				mParent = parent;
			}

			public override void TappedAt(Menu menu, CoreGraphics.CGPoint point, bool isOutside)
			{
				if (!isOutside) return;
				var mc = mParent.MenuController() as AppMenuController;

				if (mc != null)
				{
					mc.CloseMennu((UIView view) =>
					{
						(view as MenuItem).HideTitleLabel();
					});
				}
			}
		}
	}
}
