using System;
using CoreGraphics;
using FPT.Framework.iOS.Material;
using UIKit;

namespace MenuDemo
{
	public class AppMenuController : MenuController
	{

		private CGSize baseSize = new CGSize(56, 56);
		private nfloat bottomInset = 24f;
		private nfloat rightInset = 24f;

		public AppMenuController(UIViewController viewController) : base(viewController)
		{
		}

		public override void Prepare()
		{
			base.Prepare();
			View.BackgroundColor = Color.Grey.Lighten5;

			prepareMenu();
		}

		public override void OpenMennu(Action<UIView> completion = null)
		{
			base.OpenMennu(completion);
			Menu.Views[0].Animate(Animation.Rotate(angle: 45f));
		}

		public override void CloseMennu(Action<UIView> completion = null)
		{
			base.CloseMennu(completion);
			Menu.Views[0].Animate(Animation.Rotate(angle: 0f));
		}

		private void prepareMenu()
		{
			Menu.BaseSize = baseSize;

			View.Layout(Menu).Size(baseSize).Bottom(bottomInset).Right(rightInset);
		}
	}
}
