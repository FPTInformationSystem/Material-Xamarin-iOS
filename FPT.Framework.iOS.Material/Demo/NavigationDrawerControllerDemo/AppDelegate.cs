using Foundation;
using UIKit;
using FPT.Framework.iOS.Material;

namespace NavigationDrawerControllerDemo
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
	[Register("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations

		public override UIWindow Window
		{
			get;
			set;
		}

		public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
		{
			// Override point for customization after application launch.
			// If not required for your application you can safely delete this method
			var appToolbarController = new AppToolbarController(new RootViewController());
			var leftViewController = new LeftViewController();
			var rightViewController = new RightViewController();

			Window = new UIWindow(Device.Bounds);
			Window.RootViewController = new AppNavigationDrawerController(appToolbarController, leftViewController, rightViewController);
			Window.MakeKeyAndVisible();

			return true;
		}
	}
}

