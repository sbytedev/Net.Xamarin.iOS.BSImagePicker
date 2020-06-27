// WARNING
//
// This file has been generated automatically by Rider IDE
//   to store outlets and actions made in Xcode.
// If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace SByteDev.Xamarin.iOS.BSImagePicker.Demo
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UIButton _customImagePickerButton { get; set; }

        [Outlet]
        UIKit.UIButton _imagePickerButton { get; set; }

        [Outlet]
        UIKit.UIButton _imagePickerWithSelectedAssetsButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (_imagePickerButton != null) {
                _imagePickerButton.Dispose ();
                _imagePickerButton = null;
            }

            if (_customImagePickerButton != null) {
                _customImagePickerButton.Dispose ();
                _customImagePickerButton = null;
            }

            if (_imagePickerWithSelectedAssetsButton != null) {
                _imagePickerWithSelectedAssetsButton.Dispose ();
                _imagePickerWithSelectedAssetsButton = null;
            }

        }
    }
}
