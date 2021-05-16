# BSImagePicker binding for Xamarin.iOS
![GitHub](https://img.shields.io/github/license/SByteDev/Net.Xamarin.iOS.BSImagePicker.svg)
![Nuget](https://img.shields.io/nuget/v/SByteDev.Xamarin.iOS.BSImagePicker.svg)
[![CI](https://github.com/SByteDev/Net.Xamarin.iOS.BSImagePicker/actions/workflows/ci.yml/badge.svg)](https://github.com/SByteDev/Net.Xamarin.iOS.BSImagePicker/actions/workflows/ci.yml)
[![CD](https://github.com/SByteDev/Net.Xamarin.iOS.BSImagePicker/actions/workflows/cd.yml/badge.svg)](https://github.com/SByteDev/Net.Xamarin.iOS.BSImagePicker/actions/workflows/cd.yml)

[BSImagePicker](https://github.com/mikaoj/BSImagePicker) is a multiple image picker for iOS, that supports

- Multiple selection
- Fullscreen preview
- Switching albums
- Images, live photos and videos
- Customization

## Installation

Use [NuGet](https://www.nuget.org) package manager to install this library.

```bash
Install-Package SByteDev.Xamarin.iOS.BSImagePicker
```

## Usage

##### Info.plist
To be able to request permission to the users photo library you need to add this to your Info.plist
```
<key>NSPhotoLibraryUsageDescription</key>
<string>Why you want to access photo library</string>
```

```cs
using SByteDev.Xamarin.iOS.BSImagePicker;

// Custom delegate required to handle picker callbacks
var delegate = new CustomImagePickerControllerDelegate();

var imagePicker = new ImagePickerController(Array.Empty<PHAsset>())
{
    ImagePickerDelegate = delegate
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
imagePicker.Settings.List.CellsPerRow = 3;

await PresentViewControllerAsync(imagePicker, true).ConfigureAwait(false);
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update the tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
