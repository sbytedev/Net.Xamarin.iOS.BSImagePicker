using System;
using Foundation;
using ObjCRuntime;
using Photos;
using UIKit;

namespace SByteDev.Xamarin.iOS.BSImagePicker
{
    // @interface ImagePickerController : UINavigationController
    [BaseType(typeof(UINavigationController))]
    [DisableDefaultCtor]
    interface ImagePickerController
    {
        [Wrap("WeakImagePickerDelegate")]
        [NullAllowed]
        ImagePickerControllerDelegate ImagePickerDelegate { get; set; }

        // @property (nonatomic, weak) id<ImagePickerControllerDelegate> _Nullable imagePickerDelegate;
        [NullAllowed, Export("imagePickerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakImagePickerDelegate { get; set; }

        // @property (nonatomic, strong) Settings * _Nonnull settings;
        [Export("settings", ArgumentSemantic.Strong)]
        Settings Settings { get; set; }

        // @property (nonatomic, strong) UIBarButtonItem * _Nonnull doneButton;
        [Export("doneButton", ArgumentSemantic.Strong)]
        UIBarButtonItem DoneButton { get; set; }

        // @property (nonatomic, strong) UIBarButtonItem * _Nonnull cancelButton;
        [Export("cancelButton", ArgumentSemantic.Strong)]
        UIBarButtonItem CancelButton { get; set; }

        // @property (nonatomic, strong) UIButton * _Nonnull albumButton;
        [Export("albumButton", ArgumentSemantic.Strong)]
        UIButton AlbumButton { get; set; }

        // @property (readonly, copy, nonatomic) NSArray<PHAsset *> * _Nonnull selectedAssets;
        [Export("selectedAssets", ArgumentSemantic.Copy)]
        PHAsset[] SelectedAssets { get; }

        // @property (copy, nonatomic) NSString * _Nonnull doneButtonTitle;
        [Export("doneButtonTitle")]
        string DoneButtonTitle { get; set; }

        // -(instancetype _Nonnull)initWithSelectedAssets:(NSArray<PHAsset *> * _Nonnull)selectedAssets __attribute__((objc_designated_initializer));
        [Export("initWithSelectedAssets:")]
        [DesignatedInitializer]
        IntPtr Constructor(PHAsset[] selectedAssets);
    }

    // @protocol ImagePickerControllerDelegate
    [Model, BaseType(typeof(NSObject))]
    interface ImagePickerControllerDelegate
    {
        // @required -(void)imagePicker:(ImagePickerController * _Nonnull)imagePicker didSelectAsset:(PHAsset * _Nonnull)asset;
        [Abstract]
        [Export("imagePicker:didSelectAsset:")]
        void DidSelectAsset(ImagePickerController imagePicker, PHAsset asset);

        // @required -(void)imagePicker:(ImagePickerController * _Nonnull)imagePicker didDeselectAsset:(PHAsset * _Nonnull)asset;
        [Abstract]
        [Export("imagePicker:didDeselectAsset:")]
        void DidDeselectAsset(ImagePickerController imagePicker, PHAsset asset);

        // @required -(void)imagePicker:(ImagePickerController * _Nonnull)imagePicker didFinishWithAssets:(NSArray<PHAsset *> * _Nonnull)assets;
        [Abstract]
        [Export("imagePicker:didFinishWithAssets:")]
        void DidFinishWithAssets(ImagePickerController imagePicker, PHAsset[] assets);

        // @required -(void)imagePicker:(ImagePickerController * _Nonnull)imagePicker didCancelWithAssets:(NSArray<PHAsset *> * _Nonnull)assets;
        [Abstract]
        [Export("imagePicker:didCancelWithAssets:")]
        void DidCancelWithAssets(ImagePickerController imagePicker, PHAsset[] assets);

        // @required -(void)imagePicker:(ImagePickerController * _Nonnull)imagePicker didReachSelectionLimit:(NSInteger)count;
        [Abstract]
        [Export("imagePicker:didReachSelectionLimit:")]
        void DidReachSelectionLimit(ImagePickerController imagePicker, nint count);
    }

    // @interface Settings : NSObject
    [BaseType(typeof(NSObject))]
    interface Settings
    {
        // @property (nonatomic, strong) Theme * _Nonnull theme;
        [Export("theme", ArgumentSemantic.Strong)]
        Theme Theme { get; set; }

        // @property (nonatomic, strong) Selection * _Nonnull selection;
        [Export("selection", ArgumentSemantic.Strong)]
        Selection Selection { get; set; }

        // @property (nonatomic, strong) List * _Nonnull list;
        [Export("list", ArgumentSemantic.Strong)]
        List List { get; set; }

        // @property (nonatomic, strong) Fetch * _Nonnull fetch;
        [Export("fetch", ArgumentSemantic.Strong)]
        Fetch Fetch { get; set; }

        // @property (nonatomic, strong) Dismiss * _Nonnull dismiss;
        [Export("dismiss", ArgumentSemantic.Strong)]
        Dismiss Dismiss { get; set; }

        // @property (nonatomic) BOOL previewEnabled;
        [Export("previewEnabled")]
        bool IsPreviewEnabled { get; set; }
    }

    // @interface Theme : NSObject
    [BaseType(typeof(NSObject))]
    interface Theme
    {
        // @property (nonatomic, strong) UIColor * _Nonnull backgroundColor;
        [Export("backgroundColor", ArgumentSemantic.Strong)]
        UIColor BackgroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull selectionFillColor;
        [Export("selectionFillColor", ArgumentSemantic.Strong)]
        UIColor SelectionFillColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull selectionStrokeColor;
        [Export("selectionStrokeColor", ArgumentSemantic.Strong)]
        UIColor SelectionStrokeColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull selectionShadowColor;
        [Export("selectionShadowColor", ArgumentSemantic.Strong)]
        UIColor SelectionShadowColor { get; set; }

        // @property (nonatomic) enum SelectionStyle selectionStyle;
        [Export("selectionStyle", ArgumentSemantic.Assign)]
        SelectionStyle SelectionStyle { get; set; }

        // @property (copy, nonatomic) NSDictionary<NSAttributedStringKey,id> * _Nonnull previewTitleAttributes;
        [Export("previewTitleAttributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> PreviewTitleAttributes { get; set; }

        // @property (copy, nonatomic) NSDictionary<NSAttributedStringKey,id> * _Nonnull previewSubtitleAttributes;
        [Export("previewSubtitleAttributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> PreviewSubtitleAttributes { get; set; }

        // @property (copy, nonatomic) NSDictionary<NSAttributedStringKey,id> * _Nonnull albumTitleAttributes;
        [Export("albumTitleAttributes", ArgumentSemantic.Copy)]
        NSDictionary<NSString, NSObject> AlbumTitleAttributes { get; set; }
    }

    // @interface Selection : NSObject
    [BaseType(typeof(NSObject))]
    interface Selection
    {
        // @property (nonatomic) NSInteger max;
        [Export("max")]
        nint Max { get; set; }

        // @property (nonatomic) NSInteger min;
        [Export("min")]
        nint Min { get; set; }

        // @property (nonatomic) BOOL unselectOnReachingMax;
        [Export("unselectOnReachingMax")]
        bool ShouldUnselectOnReachingMax { get; set; }
    }

    // @interface List : NSObject
    [BaseType(typeof(NSObject))]
    interface List
    {
        // @property (nonatomic) CGFloat spacing;
        [Export("spacing")]
        nfloat Spacing { get; set; }

        // @property (copy, nonatomic) NSInteger (^ _Nonnull)(UIUserInterfaceSizeClass, UIUserInterfaceSizeClass) cellsPerRow;
        [Export("cellsPerRow", ArgumentSemantic.Copy)]
        Func<UIUserInterfaceSizeClass, UIUserInterfaceSizeClass, nint> CellsPerRow { get; set; }
    }

    // @interface Fetch : NSObject
    [BaseType(typeof(NSObject))]
    interface Fetch
    {
        // @property (nonatomic, strong) Album * _Nonnull album;
        [Export("album", ArgumentSemantic.Strong)]
        Album Album { get; set; }

        // @property (nonatomic, strong) Assets * _Nonnull assets;
        [Export("assets", ArgumentSemantic.Strong)]
        Assets Assets { get; set; }

        // @property (nonatomic, strong) Preview * _Nonnull preview;
        [Export("preview", ArgumentSemantic.Strong)]
        Preview Preview { get; set; }
    }

    // @interface Album : NSObject
    [BaseType(typeof(NSObject))]
    interface Album
    {
        // @property (nonatomic, strong) PHFetchOptions * _Nonnull options;
        [Export("options", ArgumentSemantic.Strong)]
        PHFetchOptions Options { get; set; }

        // @property (copy, nonatomic) NSArray<PHFetchResult<PHAssetCollection *> *> * _Nonnull fetchResults;
        [Export("fetchResults", ArgumentSemantic.Copy)]
        PHFetchResult[] FetchResults { get; set; }
    }

    // @interface Assets : NSObject
    [BaseType(typeof(NSObject))]
    interface Assets
    {
        // @property (nonatomic) BOOL imageTypesSupported;
        [Export("imageTypesSupported")]
        bool AreImageTypesSupported { get; set; }

        // @property (nonatomic) BOOL videoTypesSupported;
        [Export("videoTypesSupported")]
        bool AreVideoTypesSupported { get; set; }

        // @property (nonatomic, strong) PHFetchOptions * _Nonnull options;
        [Export("options", ArgumentSemantic.Strong)]
        PHFetchOptions Options { get; set; }
    }

    // @interface Preview : NSObject
    [BaseType(typeof(NSObject))]
    interface Preview
    {
        // @property (nonatomic, strong) PHImageRequestOptions * _Nonnull photoOptions;
        [Export("photoOptions", ArgumentSemantic.Strong)]
        PHImageRequestOptions PhotoOptions { get; set; }

        // @property (nonatomic, strong) PHLivePhotoRequestOptions * _Nonnull livePhotoOptions;
        [Export("livePhotoOptions", ArgumentSemantic.Strong)]
        PHLivePhotoRequestOptions LivePhotoOptions { get; set; }

        // @property (nonatomic, strong) PHVideoRequestOptions * _Nonnull videoOptions;
        [Export("videoOptions", ArgumentSemantic.Strong)]
        PHVideoRequestOptions VideoOptions { get; set; }
    }

    // @interface Dismiss : NSObject
    [BaseType(typeof(NSObject))]
    interface Dismiss
    {
        // @property (nonatomic) BOOL enabled;
        [Export("enabled")]
        bool IsEnabled { get; set; }
    }
}
