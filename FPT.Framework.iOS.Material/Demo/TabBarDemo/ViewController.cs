using System;
using CoreGraphics;
using FPT.Framework.iOS.Material;
using UIKit;
using System.Collections.Generic;

namespace TabBarDemo
{
	public partial class ViewController : UIViewController
	{

		private List<UIButton> buttons { get; set; } = new List<UIButton>();
		private TabBar tabBar;

		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			View.BackgroundColor = Color.White;
			prepareButtons();
			prepareTabBar();
		}

		private void prepareButtons()
		{
			var btn1 = new FlatButton("Library", Color.BlueGrey.Base);
			btn1.PulseAnimation = PulseAnimation.None;
			buttons.Add(btn1);

			var btn2 = new FlatButton("Photo", Color.BlueGrey.Base);
			btn2.PulseAnimation = PulseAnimation.None;
			buttons.Add(btn2);

			var btn3 = new FlatButton("Video", Color.BlueGrey.Base);
			btn3.PulseAnimation = PulseAnimation.None;
			buttons.Add(btn3);

			var btn4 = new FlatButton("Video", Color.BlueGrey.Base);
			btn4.PulseAnimation = PulseAnimation.None;
			buttons.Add(btn4);

			var btn5 = new FlatButton("Video 1", Color.BlueGrey.Base);
			btn5.PulseAnimation = PulseAnimation.None;
			buttons.Add(btn5);
		}

		private void prepareTabBar()
		{
			tabBar = new TabBar();
			tabBar.Delegate = new ViewControllerTabBarDelegate(this);

			tabBar.SetDividerColor(Color.Grey.Lighten3);
			tabBar.SetDividerAlignment(DividerAlignment.Top);

			tabBar.LineColor = Color.Blue.Base;
			tabBar.LineAlignment = TabBarLineAlignment.Top;

			tabBar.BackgroundColor = Color.Grey.Lighten5;
			tabBar.Buttons = buttons;

			View.Layout(tabBar).Horizontally().Bottom();
		}

		private class ViewControllerTabBarDelegate : TabBarDelegate
		{
			ViewController mParent;

			public ViewControllerTabBarDelegate(ViewController parent)
			{
				mParent = parent;
			}

			public override void WillSelect(TabBar tabBar, UIButton button)
			{
				base.WillSelect(tabBar, button);
				System.Diagnostics.Debug.WriteLine("WillSelect");
			}

			public override void DidSelect(TabBar tabBar, UIButton button)
			{
				base.DidSelect(tabBar, button);
				System.Diagnostics.Debug.WriteLine("Did Select");
			}
		}
	}
}
