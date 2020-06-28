using System;
using System.Diagnostics;
using System.Linq;
using Foundation;
using Photos;
using UIKit;

namespace SByteDev.Xamarin.iOS.BSImagePicker.Demo
{
    public partial class ViewController : UIViewController
    {
        private class Delegate : ImagePickerControllerDelegate
        {
            public override void DidCancelWithAssets(ImagePickerController imagePicker, PHAsset[] assets)
            {
                Debug.WriteLine($"Cancelled with selections {assets}");
            }

            public override void DidDeselectAsset(ImagePickerController imagePicker, PHAsset asset)
            {
                Debug.WriteLine($"Deselected {asset}");
            }

            public override void DidFinishWithAssets(ImagePickerController imagePicker, PHAsset[] assets)
            {
                Debug.WriteLine($"Finished with selections {assets}");
            }

            public override void DidReachSelectionLimit(ImagePickerController imagePicker, nint count)
            {
                Debug.WriteLine($"Reached selection limit with count {count}");
            }

            public override void DidSelectAsset(ImagePickerController imagePicker, PHAsset asset)
            {
                Debug.WriteLine($"Selected {asset}");
            }
        }

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            PHPhotoLibrary.RequestAuthorization(_ => { });

            _imagePickerButton.TouchUpInside += ImagePickerButtonOnTouchUpInside;
            _customImagePickerButton.TouchUpInside += CustomImagePickerButtonOnTouchUpInside;
            _imagePickerWithSelectedAssetsButton.TouchUpInside += ImagePickerWithSelectedAssetsButtonOnTouchUpInside;
        }

        private async void ImagePickerButtonOnTouchUpInside(object _, EventArgs __)
        {
            var imagePicker = new ImagePickerController(Array.Empty<PHAsset>())
            {
                ImagePickerDelegate = new Delegate()
            };

            imagePicker.Settings.Selection.Max = 5;
            imagePicker.Settings.Theme.SelectionStyle = SelectionStyle.Numbered;
            imagePicker.Settings.Fetch.Assets.AreImageTypesSupported = true;
            imagePicker.Settings.Fetch.Assets.AreVideoTypesSupported = true;
            imagePicker.Settings.Selection.ShouldUnselectOnReachingMax = true;

            await PresentViewControllerAsync(imagePicker, true).ConfigureAwait(false);
        }

        private async void CustomImagePickerButtonOnTouchUpInside(object _, EventArgs __)
        {
            var imagePicker = new ImagePickerController(Array.Empty<PHAsset>())
            {
                ImagePickerDelegate = new Delegate()
            };

            imagePicker.Settings.Selection.Max = 1;
            imagePicker.Settings.Selection.ShouldUnselectOnReachingMax = true;
            imagePicker.Settings.Fetch.Assets.AreImageTypesSupported = true;
            imagePicker.Settings.Fetch.Assets.AreVideoTypesSupported = true;
            imagePicker.AlbumButton.TintColor = UIColor.Green;
            imagePicker.CancelButton.TintColor = UIColor.Red;
            imagePicker.DoneButton.TintColor = UIColor.Purple;
            imagePicker.NavigationBar.BarTintColor = UIColor.Black;
            imagePicker.Settings.Theme.BackgroundColor = UIColor.Black;
            imagePicker.Settings.Theme.SelectionFillColor = UIColor.Gray;
            imagePicker.Settings.Theme.SelectionStrokeColor = UIColor.Yellow;
            imagePicker.Settings.Theme.SelectionShadowColor = UIColor.Red;
            imagePicker.Settings.Theme.PreviewTitleAttributes =
                new NSDictionary<NSString, NSObject>(
                    new[] {new NSString("NSFont"), new NSString("NSColor")},
                    new NSObject[] {UIFont.SystemFontOfSize(16), UIColor.White}
                );
            imagePicker.Settings.Theme.PreviewSubtitleAttributes =
                new NSDictionary<NSString, NSObject>(
                    new[] {new NSString("NSFont"), new NSString("NSColor")},
                    new NSObject[] {UIFont.SystemFontOfSize(12), UIColor.White}
                );
            imagePicker.Settings.Theme.AlbumTitleAttributes =
                new NSDictionary<NSString, NSObject>(
                    new[] {new NSString("NSFont"), new NSString("NSColor")},
                    new NSObject[] {UIFont.SystemFontOfSize(18), UIColor.White}
                );
            imagePicker.Settings.List.CellsPerRow = CellsPerRow;

            await PresentViewControllerAsync(imagePicker, true).ConfigureAwait(false);
        }

        private async void ImagePickerWithSelectedAssetsButtonOnTouchUpInside(object _, EventArgs __)
        {
            var assets = PHAsset
                .FetchAssets(PHAssetMediaType.Image, null)
                .Where((item, index) => index % 2 == 0)
                .OfType<PHAsset>()
                .ToArray();

            var imagePicker = new ImagePickerController(assets)
            {
                ImagePickerDelegate = new Delegate()
            };

            await PresentViewControllerAsync(imagePicker, true).ConfigureAwait(false);
        }

        private static nint CellsPerRow(UIUserInterfaceSizeClass verticalSize, UIUserInterfaceSizeClass horizontalSize)
        {
            switch (verticalSize)
            {
                // iPhone5-6 portrait
                case UIUserInterfaceSizeClass.Compact when horizontalSize == UIUserInterfaceSizeClass.Regular:
                    return 2;
                // iPhone5-6 landscape
                case UIUserInterfaceSizeClass.Compact when horizontalSize == UIUserInterfaceSizeClass.Compact:
                    return 2;
                // iPad portrait/landscape
                case UIUserInterfaceSizeClass.Regular when horizontalSize == UIUserInterfaceSizeClass.Regular:
                    return 3;
                case UIUserInterfaceSizeClass.Unspecified:
                    return 2;
                default:
                    return 2;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                var imagePickerButton = _imagePickerButton;
                if (imagePickerButton != null)
                {
                    imagePickerButton.TouchUpInside -= ImagePickerButtonOnTouchUpInside;
                }

                var customImagePickerButton = _customImagePickerButton;
                if (customImagePickerButton != null)
                {
                    customImagePickerButton.TouchUpInside -= CustomImagePickerButtonOnTouchUpInside;
                }

                var imagePickerWithSelectedAssetsButton = _imagePickerWithSelectedAssetsButton;
                if (imagePickerWithSelectedAssetsButton != null)
                {
                    imagePickerWithSelectedAssetsButton.TouchUpInside -=
                        ImagePickerWithSelectedAssetsButtonOnTouchUpInside;
                }
            }

            base.Dispose(disposing);
        }
    }
}