//using System;
//using CoreGraphics;
//using Foundation;
//using FPT.Framework.iOS.Material;
//using ObjCRuntime;
//using UIKit;

//namespace MenuDemo
//{
//	public partial class ViewController : UIViewController
//	{

//		#region PROPERTIES

//		private Menu fabMenu { get; set; }

//		private Menu flatMenu { get; set; }

//		private Menu flashMenu { get; set; }

//		private CGSize baseSize = new CGSize(56, 56);
//		private nfloat bottomInset = 24f;
//		private nfloat rightInset = 24f;

//		nfloat spacing = 16f;
//		nfloat diameter = 56f;
//		nfloat height = 36f;

//		#endregion

//		protected ViewController(IntPtr handle) : base(handle)
//		{
//			// Note: this .ctor should not contain any initialization logic.
//		}

//		public override void ViewDidLoad()
//		{
//			base.ViewDidLoad();
//			// Perform any additional setup after loading the view, typically from a nib.
//			prepareView();
//			prepareFabMenuExample();
//			prepareFlatbMenuExample();
//			prepareFlashMenuExample();
//		}

//		public override void ViewWillTransitionToSize(CoreGraphics.CGSize toSize, IUIViewControllerTransitionCoordinator coordinator)
//		{
//			base.ViewWillTransitionToSize(toSize, coordinator);

//			// Handle orientation change.
//			fabMenu.SetPosition(new CGPoint(View.Bounds.Height - diameter - spacing, View.Bounds.Width - diameter - spacing));
//			flatMenu.SetPosition( new CGPoint(spacing, View.Bounds.Height - height - spacing));
//		}

//		[Export("handleFabMenu")]
//		void handleFabMenu()
//		{
//			UIImage image;
//			if (fabMenu.IsOpened)
//			{
//				fabMenu.Close();
//				image = Icon.CM.Add;
//			}
//			else
//			{
//				fabMenu.Open(completion: (UIView v) =>
//				{
//					(v as Button).pulse();
//				});
//				image = Icon.CM.Close;
//			}

//			var first = fabMenu.Views[0] as Button;
//			first.Animate(Animation.Rotate(rotation: 1));
//			first.SetImage(image, UIControlState.Normal);
//			first.SetImage(image, UIControlState.Highlighted);
//		}

//		[Export("handleFlatMenu")]
//		void handleFlatMenu()
//		{
//			if (flatMenu.IsEnabled)
//			{
//				if (flatMenu.IsOpened)
//				{
//					flatMenu.Close();
//				}
//				else
//				{
//					flatMenu.Open();
//				}
//			}
//		}

//		[Export("handleFlashMenu")]
//		void handleFlashMenu()
//		{
//			if (flashMenu.IsEnabled)
//			{
//				if (flashMenu.IsOpened)
//				{
//					flashMenu.Close();
//				}
//				else
//				{
//					flashMenu.Open();
//				}
//			}
//		}

//		void prepareView()
//		{
//			View.BackgroundColor = Color.White;
//		}

//		void prepareFabMenuExample()
//		{
//			var image = UIImage.FromBundle("ic_add_white");
//			var btn1 = new FabButton();
//			btn1.SetImage(image, UIControlState.Normal);
//			btn1.SetImage(image, UIControlState.Highlighted);
//			btn1.AddTarget(this, new Selector("handleFabMenu"), UIControlEvent.TouchUpInside);
//			View.AddSubview(btn1);

//			image = UIImage.FromBundle("ic_add_white");
//			var btn2 = new FabButton();
//			btn2.SetImage(image, UIControlState.Normal);
//			btn2.SetImage(image, UIControlState.Highlighted);
//			View.AddSubview(btn2);

//			image = UIImage.FromBundle("ic_add_white");
//			var btn3 = new FabButton();
//			btn3.SetImage(image, UIControlState.Normal);
//			btn3.SetImage(image, UIControlState.Highlighted);
//			View.AddSubview(btn3);

//			image = UIImage.FromBundle("ic_add_white");
//			var btn4 = new FabButton();
//			btn4.SetImage(image, UIControlState.Normal);
//			btn4.SetImage(image, UIControlState.Highlighted);
//			View.AddSubview(btn4);

//			fabMenu = new Menu(new CGPoint(View.Bounds.Width - diameter - spacing, View.Bounds.Height - diameter - spacing));
//			fabMenu.Direction = MenuDirection.Up;
//			fabMenu.BaseSize = new CGSize(diameter, diameter);
//			fabMenu.Views = new UIButton[] {
//				btn1, btn2, btn3, btn4
//			};
//		}

//		void prepareFlatbMenuExample()
//		{
//			var btn1 = new FlatButton();
//			btn1.AddTarget(this, new Selector("handleFlatMenu"), UIControlEvent.TouchUpInside);
//			btn1.SetTitleColor(Color.White, UIControlState.Normal);
//			btn1.BackgroundColor = Color.Blue.Accent3;
//			btn1.PulseColor = Color.White;
//			btn1.SetTitle("Base", UIControlState.Normal);
//			//View.AddSubview(btn1);

//			var btn2 = new FlatButton();
//			btn2.SetTitleColor(Color.White, UIControlState.Normal);
//			btn2.BackgroundColor = Color.Blue.Accent3;
//			btn2.PulseColor = Color.White;
//			btn2.SetTitle("Item", UIControlState.Normal);
//			//View.AddSubview(btn2);

//			var btn3 = new FlatButton();
//			btn3.SetTitleColor(Color.White, UIControlState.Normal);
//			btn3.BackgroundColor = Color.Blue.Accent3;
//			btn3.PulseColor = Color.White;
//			btn3.SetTitle("Item", UIControlState.Normal);
//			//View.AddSubview(btn3);

//			var btn4 = new FlatButton();
//			btn4.SetTitleColor(Color.White, UIControlState.Normal);
//			btn4.BackgroundColor = Color.Blue.Accent3;
//			btn4.PulseColor = Color.White;
//			btn4.SetTitle("Item", UIControlState.Normal);
//			//View.AddSubview(btn4);

//			//flatMenu = new Menu(new CGPoint(spacing, View.Bounds.Height - height - spacing));
//			flatMenu = new Menu();
//			flatMenu.Direction = MenuDirection.Up;
//			flatMenu.InterimSpace = 8;
//			flatMenu.ItemSize = new CGSize(120, height);
//			flatMenu.Views = new UIView[] {
//				btn1, btn2, btn3, btn4
//			};

//			flatMenu.BaseSize = baseSize;
//			View.Layout(flatMenu).Size(baseSize).Bottom(bottomInset).Right(rightInset);
//		}

//		void prepareFlashMenuExample()
//		{
//			var image = UIImage.FromBundle("ic_flash_auto_white").ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
//			var btn1 = new FlatButton();
//			btn1.PulseColor = Color.BlueGrey.Darken4;
//			btn1.TintColor = Color.BlueGrey.Darken4;
//			btn1.SetImage(image, UIControlState.Normal);
//			btn1.SetImage(image, UIControlState.Highlighted);
//			btn1.AddTarget(this, new Selector("handleFlashMenu"), UIControlEvent.TouchUpInside);
//			View.AddSubview(btn1);

//			image = UIImage.FromBundle("ic_flash_auto_white").ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
//			var btn2 = new FlatButton();
//			btn2.PulseColor = Color.BlueGrey.Darken4;
//			btn2.TintColor = Color.BlueGrey.Darken4;
//			btn2.SetImage(image, UIControlState.Normal);
//			btn2.SetImage(image, UIControlState.Highlighted);
//			View.AddSubview(btn2);

//			image = UIImage.FromBundle("ic_flash_auto_white").ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
//			var btn3 = new FlatButton();
//			btn3.PulseColor = Color.BlueGrey.Darken4;
//			btn3.TintColor = Color.BlueGrey.Darken4;
//			btn3.SetImage(image, UIControlState.Normal);
//			btn3.SetImage(image, UIControlState.Highlighted);
//			View.AddSubview(btn3);

//			flashMenu = new Menu(new CGPoint((View.Bounds.Width + btn1.Width()) / 2f, 100));
//			flashMenu.Direction = MenuDirection.Down;
//			flashMenu.ItemSize = btn1.IntrinsicContentSize;
//			flashMenu.Views = new UIView[] {
//				btn1, btn2, btn3
//			};
//		}
//	}
//}
