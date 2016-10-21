using System;
using FPT.Framework.iOS.Material;
using UIKit;

namespace MaterialSwitchDemo
{
	public partial class ViewController : UIViewController, SwitchDelegate
	{

		private View topView { get; set; } = new View();
		private View bottomView { get; set; } = new View();

		protected ViewController(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			prepareView();
			prepareLightContentMaterialSwitch();
			prepareDefaultMaterialSwitch();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		void prepareView()
		{
			View.BackgroundColor = Color.White;

			bottomView.BackgroundColor = Color.Grey.Darken4;

			View.Layout().Horizontally(topView);
			View.Layout().Horizontally(bottomView);
			View.Layout().Vertically(new UIView[] {
				topView, bottomView
			});
		}

		void prepareLightContentMaterialSwitch()
		{
			var c1 = new Switch(state: SwitchState.Off, style: SwitchStyle.LightContent, size: SwitchSize.Small);
			c1.Delegate = this;

			var c2 = new Switch(state: SwitchState.On, style: SwitchStyle.LightContent);
			c2.Delegate = this;

			var c3 = new Switch(state: SwitchState.Off, style: SwitchStyle.LightContent, size: SwitchSize.Large);
			c3.Delegate = this;

			topView.Layout().Horizontally(c1);
			topView.Layout().Horizontally(c2);
			topView.Layout().Horizontally(c3);
			topView.Layout().Vertically(new UIView[]
			{
				c1,c2,c3
			});
		}

		void prepareDefaultMaterialSwitch()
		{
			var c1 = new Switch(state: SwitchState.Off, style: SwitchStyle.Default, size: SwitchSize.Small);
			c1.Delegate = this;

			var c2 = new Switch(state: SwitchState.On, style: SwitchStyle.Default);
			c2.Delegate = this;

			var c3 = new Switch(state: SwitchState.Off, style: SwitchStyle.Default, size: SwitchSize.Large);
			c3.Delegate = this;

			bottomView.Layout().Horizontally(c1);
			bottomView.Layout().Horizontally(c2);
			bottomView.Layout().Horizontally(c3);
			bottomView.Layout().Vertically(new UIView[]
			{
				c1,c2,c3
			});
		}

		public void SwitchStateChanged(Switch control)
		{
			var str = String.Format("MaterialSwitch - Style: {0}, Size: {1}, State: {2}, On: {3}, Selected: {4},  Highlighted: {5}",
									control.SwitchStyle, control.SwitchSize, control.SwitchState, control.On, control.Selected, control.Highlighted
								   );
			Console.WriteLine(str);
		}
	}
}
