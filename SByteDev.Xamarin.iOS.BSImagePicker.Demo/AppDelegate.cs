using Foundation;
using UIKit;

namespace SByteDev.Xamarin.iOS.BSImagePicker.Demo
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : UIResponder, IUIApplicationDelegate
    {
        [Export("window")] public UIWindow Window { get; set; }

        private static void Main(string[] args)
        {
            UIApplication.Main(args, null, nameof(AppDelegate));
        }

        [Export("application:didFinishLaunchingWithOptions:")]
        public bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            return true;
        }

        [Export("application:configurationForConnectingSceneSession:options:")]
        public UISceneConfiguration GetConfiguration(
            UIApplication application,
            UISceneSession connectingSceneSession,
            UISceneConnectionOptions options
        )
        {
            return UISceneConfiguration.Create("Default Configuration", connectingSceneSession.Role);
        }

        [Export("application:didDiscardSceneSessions:")]
        public void DidDiscardSceneSessions(UIApplication application, NSSet<UISceneSession> sceneSessions)
        {
        }
    }
}