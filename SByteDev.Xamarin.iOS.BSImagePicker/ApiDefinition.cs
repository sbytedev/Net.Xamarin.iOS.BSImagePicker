using System;
using Foundation;
using ObjCRuntime;
using Photos;
using UIKit;

namespace SByteDev.Xamarin.iOS.BSImagePicker
{
	// @interface BSImagePickerController : UINavigationController
	[BaseType(typeof(UINavigationController))]
	interface BSImagePickerController
	{
        [Wrap("WeakImagePickerDelegate")]
        [NullAllowed]
        BSImagePickerControllerDelegate ImagePickerDelegate { get; set; }

        // @property (nonatomic, weak) id<BSImagePickerControllerDelegate> _Nullable imagePickerDelegate;
        [NullAllowed, Export("imagePickerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakImagePickerDelegate { get; set; }

		// @property (nonatomic, strong) BSImagePickerSettings * _Nonnull settings;
		[Export("settings", ArgumentSemantic.Strong)]
		BSImagePickerSettings Settings { get; set; }

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

		// @property (readonly, nonatomic, class) PHAuthorizationStatus currentAuthorization;
		[Static]
		[Export("currentAuthorization")]
		PHAuthorizationStatus CurrentAuthorization { get; }

		// -(instancetype _Nonnull)initWithSelectedAssets:(NSArray<PHAsset *> * _Nonnull)selectedAssets __attribute__((objc_designated_initializer));
		[Export("initWithSelectedAssets:")]
		[DesignatedInitializer]
		IntPtr Constructor(PHAsset[] selectedAssets);

		// -(void)deselectWithAsset:(PHAsset * _Nonnull)asset;
		[Export("deselectWithAsset:")]
		void DeselectWithAsset(PHAsset asset);
	}

	// @protocol BSImagePickerControllerDelegate
	[Model, BaseType(typeof(NSObject))]
	interface BSImagePickerControllerDelegate
	{
		// @required -(void)imagePicker:(BSImagePickerController * _Nonnull)imagePicker didSelectAsset:(PHAsset * _Nonnull)asset;
		[Abstract]
		[Export("imagePicker:didSelectAsset:")]
		void DidSelectAsset(BSImagePickerController imagePicker, PHAsset asset);

		// @required -(void)imagePicker:(BSImagePickerController * _Nonnull)imagePicker didDeselectAsset:(PHAsset * _Nonnull)asset;
		[Abstract]
		[Export("imagePicker:didDeselectAsset:")]
		void DidDeselectAsset(BSImagePickerController imagePicker, PHAsset asset);

		// @required -(void)imagePicker:(BSImagePickerController * _Nonnull)imagePicker didFinishWithAssets:(NSArray<PHAsset *> * _Nonnull)assets;
		[Abstract]
		[Export("imagePicker:didFinishWithAssets:")]
		void DidFinishWithAssets(BSImagePickerController imagePicker, PHAsset[] assets);

		// @required -(void)imagePicker:(BSImagePickerController * _Nonnull)imagePicker didCancelWithAssets:(NSArray<PHAsset *> * _Nonnull)assets;
		[Abstract]
		[Export("imagePicker:didCancelWithAssets:")]
		void DidCancelWithAssets(BSImagePickerController imagePicker, PHAsset[] assets);

		// @required -(void)imagePicker:(BSImagePickerController * _Nonnull)imagePicker didReachSelectionLimit:(NSInteger)count;
		[Abstract]
		[Export("imagePicker:didReachSelectionLimit:")]
		void DidReachSelectionLimit(BSImagePickerController imagePicker, nint count);
	}

	// @interface BSImagePickerSettings : NSObject
	[BaseType(typeof(NSObject))]
	interface BSImagePickerSettings
	{
		// @property (readonly, nonatomic, strong, class) BSImagePickerSettings * _Nonnull shared;
		[Static]
		[Export("shared", ArgumentSemantic.Strong)]
		BSImagePickerSettings Shared { get; }

		// @property (nonatomic, strong) BSImagePickerTheme * _Nonnull theme;
		[Export("theme", ArgumentSemantic.Strong)]
		BSImagePickerTheme Theme { get; set; }

		// @property (nonatomic, strong) BSImagePickerSelection * _Nonnull selection;
		[Export("selection", ArgumentSemantic.Strong)]
		BSImagePickerSelection Selection { get; set; }

		// @property (nonatomic, strong) BSImagePickerList * _Nonnull list;
		[Export("list", ArgumentSemantic.Strong)]
		BSImagePickerList List { get; set; }

		// @property (nonatomic, strong) BSImagePickerFetch * _Nonnull fetch;
		[Export("fetch", ArgumentSemantic.Strong)]
		BSImagePickerFetch Fetch { get; set; }

		// @property (nonatomic, strong) BSImagePickerDismiss * _Nonnull dismiss;
		[Export("dismiss", ArgumentSemantic.Strong)]
		BSImagePickerDismiss Dismiss { get; set; }

		// @property (nonatomic, strong) BSImagePickerPreview * _Nonnull preview;
		[Export("preview", ArgumentSemantic.Strong)]
		BSImagePickerPreview Preview { get; set; }
	}

	// @interface BSImagePickerTheme : NSObject
	[BaseType(typeof(NSObject))]
	interface BSImagePickerTheme
	{
		// @property (nonatomic, strong) UIColor * _Nonnull backgroundColor;
		[Export("backgroundColor", ArgumentSemantic.Strong)]
		UIColor BackgroundColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull dropDownBackgroundColor;
		[Export("dropDownBackgroundColor", ArgumentSemantic.Strong)]
		UIColor DropDownBackgroundColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull selectionFillColor;
		[Export("selectionFillColor", ArgumentSemantic.Strong)]
		UIColor SelectionFillColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull selectionStrokeColor;
		[Export("selectionStrokeColor", ArgumentSemantic.Strong)]
		UIColor SelectionStrokeColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull selectionShadowColor;
		[Export("selectionShadowColor", ArgumentSemantic.Strong)]
		UIColor SelectionShadowColor { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSAttributedStringKey,id> * _Nonnull previewTitleAttributes;
		[Export("previewTitleAttributes", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> PreviewTitleAttributes { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSAttributedStringKey,id> * _Nonnull previewSubtitleAttributes;
		[Export("previewSubtitleAttributes", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> PreviewSubtitleAttributes { get; set; }

		// @property (copy, nonatomic) NSDictionary<NSAttributedStringKey,id> * _Nonnull albumTitleAttributes;
		[Export("albumTitleAttributes", ArgumentSemantic.Copy)]
		NSDictionary<NSString, NSObject> AlbumTitleAttributes { get; set; }

        // @property (nonatomic) enum SelectionStyle selectionStyle;
        [Export("selectionStyle", ArgumentSemantic.Assign)]
        SelectionStyle SelectionStyle { get; set; }
    }

	// @interface BSImagePickerSelection : NSObject
	[BaseType(typeof(NSObject))]
	interface BSImagePickerSelection
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

	// @interface BSImagePickerList : NSObject
	[BaseType(typeof(NSObject))]
	interface BSImagePickerList
	{
		// @property (nonatomic) CGFloat spacing;
		[Export("spacing")]
		nfloat Spacing { get; set; }

		// @property (copy, nonatomic) NSInteger (^ _Nonnull)(UIUserInterfaceSizeClass, UIUserInterfaceSizeClass) cellsPerRow;
		[Export("cellsPerRow", ArgumentSemantic.Copy)]
		Func<UIUserInterfaceSizeClass, UIUserInterfaceSizeClass, nint> CellsPerRow { get; set; }
	}

	// @interface BSImagePickerPreview : NSObject
	[BaseType(typeof(NSObject))]
	interface BSImagePickerPreview
	{
		// @property (nonatomic) BOOL enabled;
		[Export("enabled")]
		bool Enabled { get; set; }
	}

	// @interface BSImagePickerFetch : NSObject
	[BaseType(typeof(NSObject))]
	interface BSImagePickerFetch
	{
		// @property (nonatomic, strong) BSImagePickerAlbum * _Nonnull album;
		[Export("album", ArgumentSemantic.Strong)]
		BSImagePickerAlbum Album { get; set; }

		// @property (nonatomic, strong) BSImagePickerAssets * _Nonnull assets;
		[Export("assets", ArgumentSemantic.Strong)]
		BSImagePickerAssets Assets { get; set; }

		// @property (nonatomic, strong) BSImagePickerFetchPreview * _Nonnull preview;
		[Export("preview", ArgumentSemantic.Strong)]
		BSImagePickerFetchPreview Preview { get; set; }
	}

	// @interface BSImagePickerAlbum : NSObject
	[BaseType(typeof(NSObject))]
	interface BSImagePickerAlbum
	{
		// @property (nonatomic, strong) PHFetchOptions * _Nonnull options;
		[Export("options", ArgumentSemantic.Strong)]
		PHFetchOptions Options { get; set; }

		// @property (copy, nonatomic) NSArray<PHFetchResult<PHAssetCollection *> *> * _Nonnull fetchResults;
		[Export("fetchResults", ArgumentSemantic.Copy)]
		PHFetchResult[] FetchResults { get; set; }
	}

	// @interface BSImagePickerAssets : NSObject
	[BaseType(typeof(NSObject))]
	interface BSImagePickerAssets
	{
		// @property (nonatomic) BOOL supportedImageMediaTypes;
		[Export("supportedImageMediaTypes")]
		bool AreImageMediaTypesSupported { get; set; }

		// @property (nonatomic) BOOL supportedVideoMediaTypes;
		[Export("supportedVideoMediaTypes")]
		bool AreVideoMediaTypesSupported { get; set; }

		// @property (nonatomic, strong) PHFetchOptions * _Nonnull options;
		[Export("options", ArgumentSemantic.Strong)]
		PHFetchOptions Options { get; set; }
	}

	// @interface BSImagePickerFetchPreview : NSObject
	[BaseType(typeof(NSObject))]
	interface BSImagePickerFetchPreview
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

	// @interface BSImagePickerDismiss : NSObject
	[BaseType(typeof(NSObject))]
	interface BSImagePickerDismiss
	{
		// @property (nonatomic) BOOL enabled;
		[Export("enabled")]
		bool IsEnabled { get; set; }

		// @property (nonatomic) BOOL allowSwipe;
		[Export("allowSwipe")]
		bool IsSwipeEnabled { get; set; }
	}
}
