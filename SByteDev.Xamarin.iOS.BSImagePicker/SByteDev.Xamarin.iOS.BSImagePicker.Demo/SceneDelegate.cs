using Foundation;
using UIKit;

namespace SByteDev.Xamarin.iOS.BSImagePicker.Demo
{
    [Register(nameof(SceneDelegate))]
    public class SceneDelegate : UIResponder, IUIWindowSceneDelegate
    {
        [Export("window")]
        public UIWindow Window { get; set; }

        [Export("scene:willConnectToSession:options:")]
        public void WillConnect(UIScene scene, UISceneSession session, UISceneConnectionOptions connectionOptions)
        {
        }

        [Export("sceneDidDisconnect:")]
        public void DidDisconnect(UIScene scene)
        {
        }

        [Export("sceneDidBecomeActive:")]
        public void DidBecomeActive(UIScene scene)
        {
        }

        [Export("sceneWillResignActive:")]
        public void WillResignActive(UIScene scene)
        {
        }

        [Export("sceneWillEnterForeground:")]
        public void WillEnterForeground(UIScene scene)
        {
        }

        [Export("sceneDidEnterBackground:")]
        public void DidEnterBackground(UIScene scene)
        {
        }
    }
}