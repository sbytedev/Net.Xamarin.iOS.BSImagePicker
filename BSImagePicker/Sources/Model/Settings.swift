// The MIT License (MIT)
//
// Copyright (c) 2015 Joakim Gyllström
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

import UIKit
import Photos

@objc(BSImagePickerSettings) // Fix for ObjC header name conflicting.
@objcMembers public class Settings : NSObject {
    @objc public static let shared = Settings()

    // Move all theme related stuff to UIAppearance
    @objc(BSImagePickerTheme) // Fix for ObjC header name conflicting.
    @objcMembers public class Theme : NSObject {
        /// Main background color
        @objc public lazy var backgroundColor: UIColor = .systemBackgroundColor
        
        /// Color for backgroun of drop downs
        @objc public lazy var dropDownBackgroundColor: UIColor = .clear
        
        /// What color to fill the circle with
        @objc public lazy var selectionFillColor: UIColor = UIView().tintColor
        
        /// Color for the actual checkmark
        @objc public lazy var selectionStrokeColor: UIColor = .white
        
        /// Shadow color for the circle
        @objc public lazy var selectionShadowColor: UIColor = .systemShadowColor
        
        @objc(BSImagePickerSelectionStyle)
        public enum SelectionStyle : Int {
            case checked
            case numbered
        }
        
        /// The icon to display inside the selection oval
        @objc public lazy var selectionStyle: SelectionStyle = .checked
        
        @objc public lazy var previewTitleAttributes : [NSAttributedString.Key: Any] = [
            NSAttributedString.Key.font: UIFont.systemFont(ofSize: 16),
            NSAttributedString.Key.foregroundColor: UIColor.systemPrimaryTextColor
        ]
        
        @objc public lazy var previewSubtitleAttributes: [NSAttributedString.Key: Any] = [
            NSAttributedString.Key.font: UIFont.systemFont(ofSize: 12),
            NSAttributedString.Key.foregroundColor: UIColor.systemSecondaryTextColor
        ]
        
        @objc public lazy var albumTitleAttributes: [NSAttributedString.Key: Any] = [
            NSAttributedString.Key.font: UIFont.systemFont(ofSize: 18),
            NSAttributedString.Key.foregroundColor: UIColor.systemPrimaryTextColor
        ]
    }
    
    @objc(BSImagePickerSelection)
    @objcMembers public class Selection : NSObject {
        /// Max number of selections allowed
        @objc public lazy var max: Int = Int.max
        
        /// Min number of selections you have to make
        @objc public lazy var min: Int = 1
        
        /// If it reaches the max limit, unselect the first selection, and allow the new selection
        @objc public lazy var unselectOnReachingMax : Bool = false
    }

    @objc(BSImagePickerList)
    @objcMembers public class List : NSObject {
        /// How much spacing between cells
        @objc public lazy var spacing: CGFloat = 2
        
        /// How many cells per row
        @objc public lazy var cellsPerRow: (_ verticalSize: UIUserInterfaceSizeClass, _ horizontalSize: UIUserInterfaceSizeClass) -> Int = {(verticalSize: UIUserInterfaceSizeClass, horizontalSize: UIUserInterfaceSizeClass) -> Int in
            switch (verticalSize, horizontalSize) {
            case (.compact, .regular): // iPhone5-6 portrait
                return 3
            case (.compact, .compact): // iPhone5-6 landscape
                return 5
            case (.regular, .regular): // iPad portrait/landscape
                return 7
            default:
                return 3
            }
        }
    }

    @objc(BSImagePickerPreview)
    @objcMembers public class Preview : NSObject {
        /// Is preview enabled?
        @objc public lazy var enabled: Bool = true
    }

    @objc(BSImagePickerFetch)
    @objcMembers public class Fetch : NSObject {
        @objc(BSImagePickerAlbum)
        @objcMembers public class Album : NSObject {
            /// Fetch options for albums/collections
            @objc public lazy var options: PHFetchOptions = {
                let fetchOptions = PHFetchOptions()
                return fetchOptions
            }()

            /// Fetch results for asset collections you want to present to the user
            /// Some other fetch results that you might wanna use:
            ///                PHAssetCollection.fetchAssetCollections(with: .smartAlbum, subtype: .smartAlbumFavorites, options: options),
            ///                PHAssetCollection.fetchAssetCollections(with: .album, subtype: .albumRegular, options: options),
            ///                PHAssetCollection.fetchAssetCollections(with: .smartAlbum, subtype: .smartAlbumSelfPortraits, options: options),
            ///                PHAssetCollection.fetchAssetCollections(with: .smartAlbum, subtype: .smartAlbumPanoramas, options: options),
            ///                PHAssetCollection.fetchAssetCollections(with: .smartAlbum, subtype: .smartAlbumVideos, options: options),
            @objc public lazy var fetchResults: [PHFetchResult<PHAssetCollection>] = [
                PHAssetCollection.fetchAssetCollections(with: .smartAlbum, subtype: .smartAlbumUserLibrary, options: options),
            ]
        }

        @objc(BSImagePickerAssets)
        @objcMembers public class Assets : NSObject {
            /// Fetch options for assets

            /// Simple wrapper around PHAssetMediaType to ensure we only expose the supported types.
            public enum MediaTypes {
                case image
                case video

                fileprivate var assetMediaType: PHAssetMediaType {
                    switch self {
                    case .image:
                        return .image
                    case .video:
                        return .video
                    }
                }
            }
            
            public lazy var supportedMediaTypes: Set<MediaTypes> = [.image]
                        
            @objc public var supportedImageMediaTypes: Bool {
                get { return supportedMediaTypes.contains(MediaTypes.image) }
                set (newVal) {
                    if newVal == supportedImageMediaTypes {
                        return;
                    } else if newVal {
                        supportedMediaTypes.insert(MediaTypes.image)
                    } else {
                        supportedMediaTypes.remove(MediaTypes.image)
                    }
                }
            }
            
            @objc public var supportedVideoMediaTypes: Bool {
                get { return supportedMediaTypes.contains(MediaTypes.video) }
                set (newVal) {
                    if newVal == supportedVideoMediaTypes {
                        return;
                    } else if newVal {
                        supportedMediaTypes.insert(MediaTypes.video)
                    } else {
                        supportedMediaTypes.remove(MediaTypes.video)
                    }
                }
            }

            @objc public lazy var options: PHFetchOptions = {
                let fetchOptions = PHFetchOptions()
                fetchOptions.sortDescriptors = [
                    NSSortDescriptor(key: "creationDate", ascending: false)
                ]

                let rawMediaTypes = supportedMediaTypes.map { $0.assetMediaType.rawValue }
                let predicate = NSPredicate(format: "mediaType IN %@", rawMediaTypes)
                fetchOptions.predicate = predicate

                return fetchOptions
            }()
        }

        @objc(BSImagePickerFetchPreview)
        @objcMembers public class Preview : NSObject {
            @objc public lazy var photoOptions: PHImageRequestOptions = {
                let options = PHImageRequestOptions()
                options.isNetworkAccessAllowed = true

                return options
            }()

            @objc public lazy var livePhotoOptions: PHLivePhotoRequestOptions = {
                let options = PHLivePhotoRequestOptions()
                options.isNetworkAccessAllowed = true
                return options
            }()

            @objc public lazy var videoOptions: PHVideoRequestOptions = {
                let options = PHVideoRequestOptions()
                options.isNetworkAccessAllowed = true
                return options
            }()
        }

        /// Album fetch settings
        @objc public lazy var album = Album()
        
        /// Asset fetch settings
        @objc public lazy var assets = Assets()

        /// Preview fetch settings
        @objc public lazy var preview = Preview()
    }
    
    @objc(BSImagePickerDismiss)
    @objcMembers public class Dismiss : NSObject {
        /// Should the image picker dismiss when done/cancelled
        public lazy var enabled = true

        /// Allow the user to dismiss the image picker by swiping down
        public lazy var allowSwipe = false
    }

    /// Theme settings
    public lazy var theme = Theme()
    
    /// Selection settings
    public lazy var selection = Selection()
    
    /// List settings
    public lazy var list = List()
    
    /// Fetch settings
    public lazy var fetch = Fetch()
    
    /// Dismiss settings
    public lazy var dismiss = Dismiss()

    /// Preview options
    public lazy var preview = Preview()
}
