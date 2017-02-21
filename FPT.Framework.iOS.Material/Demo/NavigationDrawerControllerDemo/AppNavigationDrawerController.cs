using System;
using CoreGraphics;
using FPT.Framework.iOS.Material;
using UIKit;

namespace NavigationDrawerControllerDemo
{
	public partial class AppNavigationDrawerController : NavigationDrawerController
	{

		public AppNavigationDrawerController(UIViewController rootViewController) : base(rootViewController) { }

		public AppNavigationDrawerController(UIViewController rootViewContrller, UIViewController leftViewController = null, UIViewController rightViewController = null) : base(rootViewContrller,leftViewController,rightViewController)
		{
			
		}

		public override void Prepare()
		{
			base.Prepare();

			FPT.Framework.iOS.Material.Application.StatusBarStyle = UIStatusBarStyle.Default;

		}

		public  void NavigationDrawerWillOpen(NavigationDrawerController navigationDrawerController, NavigationDrawerPosition position)
		{
			Console.WriteLine("navigationDrawerController willOpen");
		}

		public  void NavigationDrawerDidOpen(NavigationDrawerController navigationDrawerController, NavigationDrawerPosition position)
		{
			Console.WriteLine("navigationDrawerController DidOpen");
		}

		public  void NavigationDrawerWillClose(NavigationDrawerController navigationDrawerController, NavigationDrawerPosition position)
		{
			Console.WriteLine("navigationDrawerController willClose");
		}

		public  void NavigationDrawerDidClose(NavigationDrawerController navigationDrawerController, NavigationDrawerPosition position)
		{
			Console.WriteLine("navigationDrawerController DillClose");
		}

		public  void NavigationDrawerDidBeginPanAt(NavigationDrawerController navigationDrawerController, CGPoint point, NavigationDrawerPosition position)
		{
			//Console.Write("navigationDrawerController didBeginPanAt: ", point.X(), "with position:", .Left == position ? "Left" : "Right");
		}

		public  void NavigationDrawerDidChangePanAt(NavigationDrawerController navigationDrawerController, CGPoint point, NavigationDrawerPosition position)
		{ }

		public  void NavigationDrawerDidEndPanAt(NavigationDrawerController navigationDrawerController, CGPoint point, NavigationDrawerPosition position)
		{ }

		public  void NavigationDrawerDidTapPanAt(NavigationDrawerController navigationDrawerController, CGPoint point, NavigationDrawerPosition position) 
		{ }

		public  void NavigationDrawerStatusBar(NavigationDrawerController navigationDrawerController, bool statusBar)
		{ }

	}
}
