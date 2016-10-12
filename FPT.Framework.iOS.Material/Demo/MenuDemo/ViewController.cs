using System;
using CoreGraphics;
using Foundation;
using FPT.Framework.iOS.Material;
using ObjCRuntime;
using UIKit;

namespace MenuDemo
{
	public partial class ViewController : UIViewController
	{

		#region PROPERTIES

		private Menu fabMenu { get; set; }

		private Menu flatMenu { get; set; }

		private Menu flashMenu { get; set; }

		nfloat spacing = 16f;
		nfloat diameter = 56f;
		nfloat height = 36f;

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
			prepareFabMenuExample();
			prepareFlatbMenuExample();
			prepareFlashMenuExample();
		}

		public override void ViewWillTransitionToSize(CoreGraphics.CGSize toSize, IUIViewControllerTransitionCoordinator coordinator)
		{
			base.ViewWillTransitionToSize(toSize, coordinator);

			// Handle orientation change.
			fabMenu.Origin = new CGPoint(View.Bounds.Height - diameter - spacing, View.Bounds.Width - diameter - spacing);
			flatMenu.Origin = new CGPoint(spacing, View.Bounds.Height - height - spacing);
		}

		[Export("handleFabMenu")]
		void handleFabMenu()
		{
			UIImage image;
			if (fabMenu.Opened)
			{
				fabMenu.Close();
				image = MaterialIcon.CM.Add;
			}
			else
			{
				fabMenu.Open(completion: (UIView v) =>
				{
					(v as MaterialButton).pulse();
				});
				image = MaterialIcon.CM.Close;
			}

			var first = fabMenu.Views[0] as MaterialButton;
			first.Animate(MaterialAnimation.Rotate(rotation: 1));
			first.SetImage(image, UIControlState.Normal);
			first.SetImage(image, UIControlState.Highlighted);
		}

		[Export("handleFlatMenu")]
		void handleFlatMenu()
		{
			if (flatMenu.Enabled)
			{
				if (flatMenu.Opened)
				{
					flatMenu.Close();
				}
				else
				{
					flatMenu.Open();
				}
			}
		}

		[Export("handleFlashMenu")]
		void handleFlashMenu()
		{
			if (flashMenu.Enabled)
			{
				if (flashMenu.Opened)
				{
					flashMenu.Close();
				}
				else
				{
					flashMenu.Open();
				}
			}
		}

		void prepareView()
		{
			View.BackgroundColor = MaterialColor.White;
		}

		void prepareFabMenuExample()
		{
			var image = UIImage.FromBundle("ic_add_white");
			var btn1 = new FabButton();
			btn1.SetImage(image, UIControlState.Normal);
			btn1.SetImage(image, UIControlState.Highlighted);
			View.AddSubview(btn1);

			image = UIImage.FromBundle("ic_add_white");
			var btn2 = new FabButton();
			btn2.SetImage(image, UIControlState.Normal);
			btn2.SetImage(image, UIControlState.Highlighted);
			View.AddSubview(btn2);

			image = UIImage.FromBundle("ic_add_white");
			var btn3 = new FabButton();
			btn3.SetImage(image, UIControlState.Normal);
			btn3.SetImage(image, UIControlState.Highlighted);
			View.AddSubview(btn3);

			image = UIImage.FromBundle("ic_add_white");
			var btn4 = new FabButton();
			btn4.SetImage(image, UIControlState.Normal);
			btn4.SetImage(image, UIControlState.Highlighted);
			View.AddSubview(btn4);

			fabMenu = new Menu(new CGPoint(View.Bounds.Width - diameter - spacing, View.Bounds.Height - diameter - spacing));
			fabMenu.Direction = MenuDirection.Up;
			fabMenu.BaseSize = new CGSize(diameter, diameter);
			fabMenu.Views = new UIButton[] {
				btn1, btn2, btn3, btn4
			};
		}

		void prepareFlatbMenuExample()
		{
			var btn1 = new FlatButton();
			btn1.AddTarget(this, new Selector("handleFlatMenu"), UIControlEvent.TouchUpInside);
			btn1.SetTitleColor(MaterialColor.White, UIControlState.Normal);
			btn1.BackgroundColor = MaterialColor.Blue.Accent3;
			btn1.PulseColor = MaterialColor.White;
			btn1.SetTitle("Base", UIControlState.Normal);
			View.AddSubview(btn1);

			var btn2 = new FlatButton();
			btn2.SetTitleColor(MaterialColor.White, UIControlState.Normal);
			btn2.BackgroundColor = MaterialColor.Blue.Accent3;
			btn2.PulseColor = MaterialColor.White;
			btn2.SetTitle("Item", UIControlState.Normal);
			View.AddSubview(btn2);

			var btn3 = new FlatButton();
			btn3.SetTitleColor(MaterialColor.White, UIControlState.Normal);
			btn3.BackgroundColor = MaterialColor.Blue.Accent3;
			btn3.PulseColor = MaterialColor.White;
			btn3.SetTitle("Item", UIControlState.Normal);
			View.AddSubview(btn3);

			var btn4 = new FlatButton();
			btn4.SetTitleColor(MaterialColor.White, UIControlState.Normal);
			btn4.BackgroundColor = MaterialColor.Blue.Accent3;
			btn4.PulseColor = MaterialColor.White;
			btn4.SetTitle("Item", UIControlState.Normal);
			View.AddSubview(btn4);

			flatMenu = new Menu(new CGPoint(spacing, View.Bounds.Height - height - spacing));
			flatMenu.Direction = MenuDirection.Up;
			flatMenu.Spacing = 8;
			flatMenu.ItemSize = new CGSize(120, height);
			flatMenu.Views = new UIView[] {
				btn1, btn2, btn3, btn4
			};
		}

		void prepareFlashMenuExample()
		{
			var image = UIImage.FromBundle("ic_flash_auto_white").ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
			var btn1 = new FlatButton();
			btn1.PulseColor = MaterialColor.BlueGrey.Darken4;
			btn1.TintColor = MaterialColor.BlueGrey.Darken4;
			btn1.SetImage(image, UIControlState.Normal);
			btn1.SetImage(image, UIControlState.Highlighted);
			btn1.AddTarget(this, new Selector("handleFlashMenu"), UIControlEvent.TouchUpInside);
			View.AddSubview(btn1);

			image = UIImage.FromBundle("ic_flash_auto_white").ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
			var btn2 = new FlatButton();
			btn2.PulseColor = MaterialColor.BlueGrey.Darken4;
			btn2.TintColor = MaterialColor.BlueGrey.Darken4;
			btn2.SetImage(image, UIControlState.Normal);
			btn2.SetImage(image, UIControlState.Highlighted);
			View.AddSubview(btn2);

			image = UIImage.FromBundle("ic_flash_auto_white").ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
			var btn3 = new FlatButton();
			btn3.PulseColor = MaterialColor.BlueGrey.Darken4;
			btn3.TintColor = MaterialColor.BlueGrey.Darken4;
			btn3.SetImage(image, UIControlState.Normal);
			btn3.SetImage(image, UIControlState.Highlighted);
			View.AddSubview(btn3);

			flashMenu = new Menu(new CGPoint((View.Bounds.Width + btn1.Width) / 2f, 100));
			flashMenu.Direction = MenuDirection.Right;
			flashMenu.ItemSize = btn1.IntrinsicContentSize;
			flashMenu.Views = new UIView[] {
				btn1, btn2, btn3
			};
		}
	}
}
