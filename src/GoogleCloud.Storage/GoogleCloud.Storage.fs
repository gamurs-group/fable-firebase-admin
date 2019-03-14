/// Fable bindings for the '@google-cloud/storage' npm package.
namespace rec Fable.Import.GoogleCloud.Storage

open System
open Fable.Core
open Fable.Import.JS
open Fable.Import.Node
open Fable.Import.Request
open Fable.Import.Duplexify
//open Fable.Import.GoogleAuthLibrary
open Fable.Import.GoogleCloud.Common

// Module abbreviation - these are always private
module R = Fable.Import.Request.Request

///// Global imports for the '@google-cloud/storage' module
//module Globals =
//    // TODO test this and figure out how to do: const {Storage} = require('@google-cloud/storage');
//    let [<Import("Storage","@google-cloud/storage")>] storage : Storage.IExports = jsNative


//
// bucket.d.ts
//

//type Acl = __acl.Acl
//type Channel = __channel.Channel
//type File = __file.File
//type FileOptions = __file.FileOptions
//type CreateResumableUploadOptions = __file.CreateResumableUploadOptions
//type CreateWriteStreamOptions = __file.CreateWriteStreamOptions
//type Iam = __iam.Iam
//type Notification = __notification.Notification
//type Storage = __storage.Storage

[<RequireQualifiedAccess>]
module Bucket =
    type [<AllowNullLiteral>] IExports =
        abstract Bucket: BucketStatic

    type [<AllowNullLiteral>] TypeLiteral_01 =
        abstract ``type``: string with get, set
        abstract storageClass: string option with get, set

    type [<AllowNullLiteral>] TypeLiteral_03 =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set

    type [<AllowNullLiteral>] TypeLiteral_02 =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> U4<bool, DateTime, float, string> with get, set

// duplicate
//type [<AllowNullLiteral>] BucketOptions =
//    abstract userProject: string option with get, set

type [<AllowNullLiteral>] GetFilesCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * ?files: ResizeArray<File> * ?nextQuery: GetFilesCallbackInvokeNextQuery * ?apiResponse: Request.Response -> unit

type [<AllowNullLiteral>] GetFilesCallbackInvokeNextQuery =
    interface end

type [<AllowNullLiteral>] WatchAllOptions =
    abstract delimiter: string option with get, set
    abstract maxResults: float option with get, set
    abstract pageToken: string option with get, set
    abstract prefix: string option with get, set
    abstract projection: string option with get, set
    abstract userProject: string option with get, set
    abstract versions: bool option with get, set

type [<AllowNullLiteral>] AddLifecycleRuleOptions =
    abstract append: bool option with get, set

type [<AllowNullLiteral>] LifecycleRule =
    abstract action: U2<Bucket.TypeLiteral_01, string> with get, set
    abstract condition: Bucket.TypeLiteral_02 with get, set
    abstract storageClass: string option with get, set

type [<AllowNullLiteral>] GetFilesOptions =
    abstract autoPaginate: bool option with get, set
    abstract delimiter: string option with get, set
    abstract directory: string option with get, set
    abstract prefix: string option with get, set
    abstract maxApiCalls: float option with get, set
    abstract maxResults: float option with get, set
    abstract pageToken: string option with get, set
    abstract userProject: string option with get, set
    abstract versions: bool option with get, set

type [<AllowNullLiteral>] CombineOptions =
    abstract kmsKeyName: string option with get, set
    abstract userProject: string option with get, set

type [<AllowNullLiteral>] CombineCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * newFile: File option * apiResponse: Request.Response -> unit

type CombineResponse =
    File * Request.Response

type [<AllowNullLiteral>] CreateChannelConfig =
    inherit WatchAllOptions
    abstract address: string with get, set

type [<AllowNullLiteral>] CreateChannelOptions =
    abstract userProject: string option with get, set

type CreateChannelResponse =
    Channel * Request.Response

type [<AllowNullLiteral>] CreateChannelCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * channel: Channel option * apiResponse: Request.Response -> unit

type [<AllowNullLiteral>] CreateNotificationOptions =
    abstract customAttributes: Bucket.TypeLiteral_03 option with get, set
    abstract eventTypes: ResizeArray<string> option with get, set
    abstract objectNamePrefix: string option with get, set
    abstract payloadFormat: string option with get, set
    abstract userProject: string option with get, set

type [<AllowNullLiteral>] CreateNotificationCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * notification: Notification option * apiResponse: Request.Response -> unit

type CreateNotificationResponse =
    Notification * Request.Response

type [<AllowNullLiteral>] DeleteBucketOptions =
    abstract userProject: string option with get, set

type DeleteBucketResponse =
    Request.Response

type [<AllowNullLiteral>] DeleteBucketCallback =
    inherit DeleteCallback
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * apiResponse: Request.Response -> unit

type [<AllowNullLiteral>] DeleteFilesOptions =
    inherit GetFilesOptions
    abstract force: bool option with get, set

type [<AllowNullLiteral>] DeleteFilesCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: U2<Error, ResizeArray<Error>> option * ?apiResponse: obj -> unit

type DeleteLabelsResponse =
    Request.Response

type [<AllowNullLiteral>] DeleteLabelsCallback =
    inherit SetLabelsCallback

type DisableRequesterPaysResponse =
    Request.Response

type [<AllowNullLiteral>] DisableRequesterPaysCallback =
    [<Emit "$0($1...)">] abstract Invoke: ?err: Error * ?apiResponse: obj -> unit

type EnableRequesterPaysResponse =
    Request.Response

type [<AllowNullLiteral>] EnableRequesterPaysCallback =
    [<Emit "$0($1...)">] abstract Invoke: ?err: Error * ?apiResponse: Request.Response -> unit

type [<AllowNullLiteral>] BucketExistsOptions =
    inherit GetConfig
    abstract userProject: string option with get, set

type BucketExistsResponse =
    bool

type [<AllowNullLiteral>] BucketExistsCallback =
    inherit ExistsCallback

type [<AllowNullLiteral>] GetBucketOptions =
    inherit GetConfig
    abstract userProject: string option with get, set

type GetBucketResponse =
    Bucket * Request.Response

type [<AllowNullLiteral>] GetBucketCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: ApiError option * bucket: Bucket option * apiResponse: Request.Response -> unit

type [<AllowNullLiteral>] GetLabelsOptions =
    abstract userProject: string option with get, set

type GetLabelsResponse =
    Request.Response

type [<AllowNullLiteral>] GetLabelsCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * labels: obj option -> unit

type GetBucketMetadataResponse =
    Metadata * Request.Response

type [<AllowNullLiteral>] GetBucketMetadataCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: ApiError option * metadata: Metadata option * apiResponse: Request.Response -> unit

type [<AllowNullLiteral>] GetBucketMetadataOptions =
    abstract userProject: string option with get, set

type [<AllowNullLiteral>] GetNotificationsOptions =
    abstract userProject: string option with get, set

type [<AllowNullLiteral>] GetNotificationsCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * notifications: ResizeArray<Notification> option * apiResponse: Request.Response -> unit

type GetNotificationsResponse =
    ResizeArray<Notification> * Request.Response

type [<AllowNullLiteral>] MakeBucketPrivateOptions =
    abstract includeFiles: bool option with get, set
    abstract force: bool option with get, set
    abstract userProject: string option with get, set

type MakeBucketPrivateResponse =
    ResizeArray<File>

type [<AllowNullLiteral>] MakeBucketPrivateCallback =
    [<Emit "$0($1...)">] abstract Invoke: ?err: Error * ?files: ResizeArray<File> -> unit

type [<AllowNullLiteral>] MakeBucketPublicOptions =
    abstract includeFiles: bool option with get, set
    abstract force: bool option with get, set

type [<AllowNullLiteral>] MakeBucketPublicCallback =
    [<Emit "$0($1...)">] abstract Invoke: ?err: Error * ?files: ResizeArray<File> -> unit

type MakeBucketPublicResponse =
    ResizeArray<File>

type [<AllowNullLiteral>] SetBucketMetadataOptions =
    abstract userProject: string option with get, set

type SetBucketMetadataResponse =
    Request.Response

type [<AllowNullLiteral>] SetBucketMetadataCallback =
    [<Emit "$0($1...)">] abstract Invoke: ?err: Error * ?metadata: Metadata -> unit

type [<AllowNullLiteral>] BucketLockCallback =
    [<Emit "$0($1...)">] abstract Invoke: ?err: Error * ?apiResponse: Request.Response -> unit

type BucketLockResponse =
    Request.Response

type [<AllowNullLiteral>] Labels =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set

type [<AllowNullLiteral>] SetLabelsOptions =
    abstract userProject: string option with get, set

type SetLabelsResponse =
    Request.Response

type [<AllowNullLiteral>] SetLabelsCallback =
    [<Emit "$0($1...)">] abstract Invoke: ?err: Error * ?metadata: Metadata -> unit

type [<AllowNullLiteral>] SetBucketStorageClassOptions =
    abstract userProject: string option with get, set

type [<AllowNullLiteral>] SetBucketStorageClassCallback =
    [<Emit "$0($1...)">] abstract Invoke: ?err: Error -> unit

type UploadResponse =
    File * Request.Response

type [<AllowNullLiteral>] UploadCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * ?file: File * ?apiResponse: Request.Response -> unit

type [<AllowNullLiteral>] UploadOptions =
    inherit CreateResumableUploadOptions
    inherit CreateWriteStreamOptions
    abstract destination: U2<string, File> option with get, set
    abstract encryptionKey: U2<string, Buffer> option with get, set
    abstract kmsKeyName: string option with get, set
    abstract resumable: bool option with get, set

type [<AllowNullLiteral>] MakeAllFilesPublicPrivateOptions =
    abstract force: bool option with get, set
    abstract ``private``: bool option with get, set
    abstract ``public``: bool option with get, set
    abstract userProject: string option with get, set

type [<AllowNullLiteral>] MakeAllFilesPublicPrivateCallback =
    [<Emit "$0($1...)">] abstract Invoke: ?err: U2<Error, ResizeArray<Error>> * ?files: ResizeArray<File> -> unit

type MakeAllFilesPublicPrivateResponse =
    ResizeArray<File>

/// Create a Bucket object to interact with a Cloud Storage bucket.
type [<AllowNullLiteral>] Bucket =
    inherit ServiceObject
    /// The bucket's name.
    abstract name: string with get, set
    /// A reference to the {@link Storage} associated with this {@link Bucket}
    /// instance.
    abstract storage: Storage with get, set
    /// A user project to apply to each request from this bucket.
    abstract userProject: string option with get, set
    /// Cloud Storage uses access control lists (ACLs) to manage object and
    /// bucket access. ACLs are the mechanism you use to share objects with other
    /// users and allow other users to access your buckets and objects.
    ///
    /// An ACL consists of one or more entries, where each entry grants permissions
    /// to an entity. Permissions define the actions that can be performed against
    /// an object or bucket (for example, `READ` or `WRITE`); the entity defines
    /// who the permission applies to (for example, a specific user or group of
    /// users).
    ///
    /// The `acl` object on a Bucket instance provides methods to get you a list of
    /// the ACLs defined on your bucket, as well as set, update, and delete them.
    ///
    /// Buckets also have
    /// [default
    /// ACLs](https://cloud.google.com/storage/docs/access-control/lists#default)
    /// for all created files. Default ACLs specify permissions that all new
    /// objects added to the bucket will inherit by default. You can add, delete,
    /// get, and update entities and permissions for these as well with
    /// {@link Bucket#acl.default}.
    abstract acl: Acl with get, set
    /// Get and set IAM policies for your bucket.
    abstract iam: Iam with get, set
    /// Get {@link File} objects for the files currently in the bucket as a
    /// readable object stream.
    abstract getFilesStream: Function with get, set
    abstract addLifecycleRule: rule: LifecycleRule * ?options: AddLifecycleRuleOptions -> Promise<SetBucketMetadataResponse>
    abstract addLifecycleRule: rule: LifecycleRule * options: AddLifecycleRuleOptions * callback: SetBucketMetadataCallback -> unit
    abstract addLifecycleRule: rule: LifecycleRule * callback: SetBucketMetadataCallback -> unit
    abstract combine: sources: U2<ResizeArray<string>, ResizeArray<File>> * destination: U2<string, File> * options: CombineOptions -> Promise<CombineResponse>
    abstract combine: sources: U2<ResizeArray<string>, ResizeArray<File>> * destination: U2<string, File> * options: CombineOptions * callback: CombineCallback -> unit
    abstract combine: sources: U2<ResizeArray<string>, ResizeArray<File>> * destination: U2<string, File> * callback: CombineCallback -> unit
    abstract createChannel: id: string * config: CreateChannelConfig * ?options: CreateChannelOptions -> Promise<CreateChannelResponse>
    abstract createChannel: id: string * config: CreateChannelConfig * callback: CreateChannelCallback -> unit
    abstract createChannel: id: string * config: CreateChannelConfig * options: CreateChannelOptions * callback: CreateChannelCallback -> unit
    abstract createNotification: topic: string * ?options: CreateNotificationOptions -> Promise<CreateNotificationResponse>
    abstract createNotification: topic: string * options: CreateNotificationOptions * callback: CreateNotificationCallback -> unit
    abstract createNotification: topic: string * callback: CreateNotificationCallback -> unit
    abstract deleteFiles: ?query: DeleteFilesOptions -> Promise<unit>
    abstract deleteFiles: callback: DeleteFilesCallback -> unit
    abstract deleteFiles: query: DeleteFilesOptions * callback: DeleteFilesCallback -> unit
    abstract deleteLabels: ?labels: U2<string, ResizeArray<string>> -> Promise<DeleteLabelsResponse>
    abstract deleteLabels: callback: DeleteLabelsCallback -> unit
    abstract deleteLabels: labels: U2<string, ResizeArray<string>> * callback: DeleteLabelsCallback -> unit
    abstract disableRequesterPays: unit -> Promise<DisableRequesterPaysResponse>
    abstract disableRequesterPays: callback: DisableRequesterPaysCallback -> unit
    abstract enableRequesterPays: unit -> Promise<EnableRequesterPaysResponse>
    abstract enableRequesterPays: callback: EnableRequesterPaysCallback -> unit
    /// <summary>Create a {@link File} object. See {@link File} to see how to handle
    /// the different use cases you may have.</summary>
    /// <param name="name">The name of the file in this bucket.</param>
    /// <param name="options">The name of the Cloud KMS key that will
    /// be used to encrypt the object. Must be in the format:
    /// `projects/my-project/locations/location/keyRings/my-kr/cryptoKeys/my-key`.
    /// KMS key ring must use the same location as the bucket.</param>
    abstract file: name: string * ?options: FileOptions -> File
    abstract getFiles: ?query: GetFilesOptions -> Promise<ResizeArray<File>>
    abstract getFiles: query: GetFilesOptions * callback: GetFilesCallback -> unit
    abstract getFiles: callback: GetFilesCallback -> unit
    abstract getLabels: options: GetLabelsOptions -> Promise<GetLabelsResponse>
    abstract getLabels: callback: GetLabelsCallback -> unit
    abstract getLabels: options: GetLabelsOptions * callback: GetLabelsCallback -> unit
    abstract getNotifications: ?options: GetNotificationsOptions -> Promise<GetNotificationsResponse>
    abstract getNotifications: callback: GetNotificationsCallback -> unit
    abstract getNotifications: options: GetNotificationsOptions * callback: GetNotificationsCallback -> unit
    abstract lock: metageneration: U2<float, string> -> Promise<BucketLockResponse>
    abstract lock: metageneration: U2<float, string> * callback: BucketLockCallback -> unit
    abstract makePrivate: ?options: MakeBucketPrivateOptions -> Promise<MakeBucketPrivateResponse>
    abstract makePrivate: callback: MakeBucketPrivateCallback -> unit
    abstract makePrivate: options: MakeBucketPrivateOptions * callback: MakeBucketPrivateCallback -> unit
    abstract makePublic: ?options: MakeBucketPublicOptions -> Promise<MakeBucketPublicResponse>
    abstract makePublic: callback: MakeBucketPublicCallback -> unit
    abstract makePublic: options: MakeBucketPublicOptions * callback: MakeBucketPublicCallback -> unit
    /// <summary>Get a reference to a Cloud Pub/Sub Notification.</summary>
    /// <param name="id">ID of notification.</param>
    abstract notification: id: string -> Notification
    abstract removeRetentionPeriod: unit -> Promise<SetBucketMetadataResponse>
    abstract removeRetentionPeriod: callback: SetBucketMetadataCallback -> unit
    abstract request: reqOpts: DecorateRequestOptions -> Promise<ResponseBody * Request.Response>
    abstract request: reqOpts: DecorateRequestOptions * callback: BodyResponseCallback -> unit
    abstract setLabels: labels: Labels * options: SetLabelsOptions -> Promise<SetLabelsResponse>
    abstract setLabels: labels: Labels * callback: SetLabelsCallback -> unit
    abstract setLabels: labels: Labels * options: SetLabelsOptions * callback: SetLabelsCallback -> unit
    abstract setRetentionPeriod: duration: float -> Promise<SetBucketMetadataResponse>
    abstract setRetentionPeriod: duration: float * callback: SetBucketMetadataCallback -> unit
    abstract setStorageClass: storageClass: string * options: SetBucketStorageClassOptions -> Promise<SetBucketMetadataResponse>
    abstract setStorageClass: storageClass: string * callback: SetBucketStorageClassCallback -> unit
    abstract setStorageClass: storageClass: string * options: SetBucketStorageClassOptions * callback: SetBucketStorageClassCallback -> unit
    /// <summary>Set a user project to be billed for all requests made from this Bucket
    /// object and any files referenced from this Bucket object.</summary>
    /// <param name="userProject">The user project.</param>
    abstract setUserProject: userProject: string -> unit
    abstract upload: pathString: string * ?options: UploadOptions -> Promise<UploadResponse>
    abstract upload: pathString: string * options: UploadOptions * callback: UploadCallback -> unit
    abstract upload: pathString: string * callback: UploadCallback -> unit
    abstract makeAllFilesPublicPrivate_: ?options: MakeAllFilesPublicPrivateOptions -> Promise<MakeAllFilesPublicPrivateResponse>
    abstract makeAllFilesPublicPrivate_: callback: MakeAllFilesPublicPrivateCallback -> unit
    abstract makeAllFilesPublicPrivate_: options: MakeAllFilesPublicPrivateOptions * callback: MakeAllFilesPublicPrivateCallback -> unit
    abstract getId: unit -> string

/// Create a Bucket object to interact with a Cloud Storage bucket.
type [<AllowNullLiteral>] BucketStatic =
    [<Emit "new $0($1...)">] abstract Create: storage: Storage * name: string * ?options: BucketOptions -> Bucket


//
// file.d.ts
//

//type BodyResponseCallback = @google_cloud_common.BodyResponseCallback
//type DecorateRequestOptions = @google_cloud_common.DecorateRequestOptions
//type GetConfig = @google_cloud_common.GetConfig
//type Metadata = @google_cloud_common.Metadata
//type ServiceObject = @google_cloud_common.ServiceObject
type Writable<'a> = Stream.Writable<'a>
type Readable<'a> = Stream.Readable<'a>
//type Storage = __storage.Storage
//type Bucket = __bucket.Bucket
//type Acl = __acl.Acl
//type ResponseBody = @google_cloud_common_build_src_util.ResponseBody

[<RequireQualifiedAccess>]
module File =
    type [<AllowNullLiteral>] IExports =
        abstract RequestError: RequestErrorStatic
        abstract File: FileStatic

    type [<AllowNullLiteral>] TypeLiteral_01 =
        abstract min: float option with get, set
        abstract max: float option with get, set


type GetExpirationDateResponse =
    DateTime

type [<AllowNullLiteral>] GetExpirationDateCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * ?expirationDate: DateTime * ?apiResponse: R.Response -> unit

type [<AllowNullLiteral>] GetSignedUrlConfig =
    abstract action: U4<string, string, string, string> with get, set
    abstract cname: string option with get, set
    abstract contentMd5: string option with get, set
    abstract contentType: string option with get, set
    abstract expires: U3<string, float, DateTime> with get, set
    // TODO
    // abstract extensionHeaders: Http.OutgoingHttpHeaders option with get, set
    abstract promptSaveAs: string option with get, set
    abstract responseDisposition: string option with get, set
    abstract responseType: string option with get, set

type GetSignedUrlResponse =
    string

type [<AllowNullLiteral>] GetSignedUrlCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * ?url: string -> unit

type [<AllowNullLiteral>] PolicyDocument =
    abstract expiration: string with get, set
    abstract conditions: Array<Array<U2<string, float>>> with get, set
    abstract string: string with get, set

type GetSignedPolicyResponse =
    PolicyDocument

type [<AllowNullLiteral>] GetSignedPolicyCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * ?policy: PolicyDocument -> unit

type [<AllowNullLiteral>] GetSignedPolicyOptions =
    abstract equals: U2<ResizeArray<string>, ResizeArray<ResizeArray<string>>> option with get, set
    abstract expires: U3<string, float, DateTime> with get, set
    abstract startsWith: U2<ResizeArray<string>, ResizeArray<ResizeArray<string>>> option with get, set
    abstract acl: string option with get, set
    abstract successRedirect: string option with get, set
    abstract successStatus: string option with get, set
    abstract contentLengthRange: File.TypeLiteral_01 option with get, set

type [<AllowNullLiteral>] GetFileMetadataOptions =
    abstract userProject: string option with get, set

type GetFileMetadataResponse =
    Metadata * R.Response

type [<AllowNullLiteral>] GetFileMetadataCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * ?metadata: Metadata * ?apiResponse: R.Response -> unit

type [<AllowNullLiteral>] GetFileOptions =
    inherit GetConfig
    abstract userProject: string option with get, set

type GetFileResponse =
    File * R.Response

type [<AllowNullLiteral>] GetFileCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * ?file: File * ?apiResponse: R.Response -> unit

type [<AllowNullLiteral>] FileExistsOptions =
    abstract userProject: string option with get, set

type FileExistsResponse =
    bool

type [<AllowNullLiteral>] FileExistsCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * ?exists: bool -> unit

type [<AllowNullLiteral>] DeleteFileOptions =
    abstract userProject: string option with get, set

type DeleteFileResponse =
    R.Response

type [<AllowNullLiteral>] DeleteFileCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * ?apiResponse: R.Response -> unit

type [<StringEnum>] [<RequireQualifiedAccess>] PredefinedAcl =
    | AuthenticatedRead
    | BucketOwnerFullControl
    | BucketOwnerRead
    | Private
    | ProjectPrivate
    | PublicRead

type [<AllowNullLiteral>] CreateResumableUploadOptions =
    abstract metadata: Metadata option with get, set
    abstract origin: string option with get, set
    abstract offset: float option with get, set
    abstract predefinedAcl: PredefinedAcl option with get, set
    abstract ``private``: bool option with get, set
    abstract ``public``: bool option with get, set
    abstract uri: string option with get, set
    abstract userProject: string option with get, set

type CreateResumableUploadResponse =
    string

type [<AllowNullLiteral>] CreateResumableUploadCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * ?uri: string -> unit

type [<AllowNullLiteral>] CreateWriteStreamOptions =
    inherit CreateResumableUploadOptions
    abstract contentType: string option with get, set
    abstract gzip: U2<string, bool> option with get, set
    abstract resumable: bool option with get, set
    abstract validation: U2<string, bool> option with get, set

type [<AllowNullLiteral>] MakeFilePrivateOptions =
    abstract strict: bool option with get, set
    abstract userProject: string option with get, set

type MakeFilePrivateResponse =
    R.Response

type [<AllowNullLiteral>] MakeFilePrivateCallback =
    inherit SetFileMetadataCallback

type MakeFilePublicResponse =
    R.Response

type [<AllowNullLiteral>] MakeFilePublicCallback =
    [<Emit "$0($1...)">] abstract Invoke: ?err: Error * ?apiResponse: R.Response -> unit

type MoveResponse =
    R.Response

type [<AllowNullLiteral>] MoveCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * ?destinationFile: File * ?apiResponse: R.Response -> unit

type [<AllowNullLiteral>] MoveOptions =
    abstract userProject: string option with get, set

type RotateEncryptionKeyOptions =
    U3<string, Buffer, EncryptionKeyOptions>

[<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module RotateEncryptionKeyOptions =
    let ofString v: RotateEncryptionKeyOptions = v |> U3.Case1
    let isString (v: RotateEncryptionKeyOptions) = match v with U3.Case1 _ -> true | _ -> false
    let asString (v: RotateEncryptionKeyOptions) = match v with U3.Case1 o -> Some o | _ -> None
    let ofBuffer v: RotateEncryptionKeyOptions = v |> U3.Case2
    let isBuffer (v: RotateEncryptionKeyOptions) = match v with U3.Case2 _ -> true | _ -> false
    let asBuffer (v: RotateEncryptionKeyOptions) = match v with U3.Case2 o -> Some o | _ -> None
    let ofEncryptionKeyOptions v: RotateEncryptionKeyOptions = v |> U3.Case3
    let isEncryptionKeyOptions (v: RotateEncryptionKeyOptions) = match v with U3.Case3 _ -> true | _ -> false
    let asEncryptionKeyOptions (v: RotateEncryptionKeyOptions) = match v with U3.Case3 o -> Some o | _ -> None

type [<AllowNullLiteral>] EncryptionKeyOptions =
    abstract encryptionKey: U2<string, Buffer> option with get, set
    abstract kmsKeyName: string option with get, set

type [<AllowNullLiteral>] RotateEncryptionKeyCallback =
    inherit CopyCallback

type RotateEncryptionKeyResponse =
    CopyResponse

type [<AllowNullLiteral>] FileOptions =
    abstract encryptionKey: U2<string, Buffer> option with get, set
    abstract generation: U2<float, string> option with get, set
    abstract kmsKeyName: string option with get, set
    abstract userProject: string option with get, set

type [<AllowNullLiteral>] CopyOptions =
    abstract destinationKmsKeyName: string option with get, set
    abstract keepAcl: string option with get, set
    abstract predefinedAcl: string option with get, set
    abstract token: string option with get, set
    abstract userProject: string option with get, set

type CopyResponse =
    File * R.Response

type [<AllowNullLiteral>] CopyCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * ?file: File * ?apiResponse: R.Response -> unit

type DownloadResponse =
    Buffer

type [<AllowNullLiteral>] DownloadCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: RequestError option * contents: Buffer -> unit

type [<AllowNullLiteral>] DownloadOptions =
    inherit CreateReadStreamOptions
    abstract destination: string option with get, set

type [<AllowNullLiteral>] CreateReadStreamOptions =
    abstract userProject: string option with get, set
    abstract validation: U3<string, string, obj> option with get, set
    abstract start: float option with get, set
    abstract ``end``: float option with get, set

type [<AllowNullLiteral>] SaveOptions =
    inherit CreateWriteStreamOptions

type [<AllowNullLiteral>] SaveCallback =
    [<Emit "$0($1...)">] abstract Invoke: ?err: Error -> unit

type [<AllowNullLiteral>] SetFileMetadataOptions =
    abstract userProject: string option with get, set

type [<AllowNullLiteral>] SetFileMetadataCallback =
    [<Emit "$0($1...)">] abstract Invoke: ?err: Error * ?apiResponse: R.Response -> unit

type SetFileMetadataResponse =
    R.Response

type SetStorageClassResponse =
    R.Response

type [<AllowNullLiteral>] SetStorageClassOptions =
    abstract userProject: string option with get, set

type [<AllowNullLiteral>] SetStorageClassCallback =
    [<Emit "$0($1...)">] abstract Invoke: ?err: Error * ?apiResponse: R.Response -> unit

type [<AllowNullLiteral>] RequestError =
    inherit Error
    abstract code: string option with get, set
    abstract errors: ResizeArray<Error> option with get, set

type [<AllowNullLiteral>] RequestErrorStatic =
    /// <summary>Constructs a file object.</summary>
    /// <param name="bucket">The Bucket instance this file is
    /// attached to.</param>
    /// <param name="name">The name of the remote file.</param>
    /// <param name="options">Configuration options.</param>
    [<Emit "new $0($1...)">] abstract Create: bucket: Bucket * name: string * ?options: FileOptions -> RequestError

/// A File object is created from your {@link Bucket} object using
/// {@link Bucket#file}.
type [<AllowNullLiteral>] File =
    inherit ServiceObject<File>
    /// Cloud Storage uses access control lists (ACLs) to manage object and
    /// bucket access. ACLs are the mechanism you use to share objects with other
    /// users and allow other users to access your buckets and objects.
    ///
    /// An ACL consists of one or more entries, where each entry grants permissions
    /// to an entity. Permissions define the actions that can be performed against
    /// an object or bucket (for example, `READ` or `WRITE`); the entity defines
    /// who the permission applies to (for example, a specific user or group of
    /// users).
    ///
    /// The `acl` object on a File instance provides methods to get you a list of
    /// the ACLs defined on your bucket, as well as set, update, and delete them.
    abstract acl: Acl with get, set
    abstract bucket: Bucket with get, set
    abstract storage: Storage with get, set
    abstract kmsKeyName: string option with get, set
    abstract userProject: string option with get, set
    abstract name: string with get, set
    abstract generation: float option with get, set
    abstract parent: Bucket with get, set
    abstract copy: destination: U3<string, Bucket, File> -> Promise<CopyResponse>
    abstract copy: destination: U3<string, Bucket, File> * callback: CopyCallback -> unit
    abstract copy: destination: U3<string, Bucket, File> * options: CopyOptions * callback: CopyCallback -> unit
    /// <summary>Create a readable stream to read the contents of the remote file. It can be
    /// piped to a writable stream or listened to for 'data' events to read a
    /// file's contents.
    ///
    /// In the unlikely event there is a mismatch between what you downloaded and
    /// the version in your Bucket, your error handler will receive an error with
    /// code "CONTENT_DOWNLOAD_MISMATCH". If you receive this error, the best
    /// recourse is to try downloading the file again.
    ///
    /// For faster crc32c computation, you must manually install
    /// [`fast-crc32c`](http://www.gitnpm.com/fast-crc32c):
    ///
    ///      $ npm install --save fast-crc32c
    ///
    /// NOTE: Readable streams will emit the `end` event when the file is fully
    /// downloaded.</summary>
    /// <param name="options">Configuration options.</param>
    abstract createReadStream: ?options: CreateReadStreamOptions -> Readable<'a>
    abstract createResumableUpload: ?options: CreateResumableUploadOptions -> Promise<CreateResumableUploadResponse>
    abstract createResumableUpload: options: CreateResumableUploadOptions * callback: CreateResumableUploadCallback -> unit
    abstract createResumableUpload: callback: CreateResumableUploadCallback -> unit
    /// <summary>Create a writable stream to overwrite the contents of the file in your
    /// bucket.
    ///
    /// A File object can also be used to create files for the first time.
    ///
    /// Resumable uploads are automatically enabled and must be shut off explicitly
    /// by setting `options.resumable` to `false`.
    ///
    /// Resumable uploads require write access to the $HOME directory. Through
    /// [`config-store`](http://www.gitnpm.com/configstore), some metadata is
    /// stored. By default, if the directory is not writable, we will fall back to
    /// a simple upload. However, if you explicitly request a resumable upload, and
    /// we cannot write to the config directory, we will return a
    /// `ResumableUploadError`.
    ///
    /// <p class="notice">
    ///    There is some overhead when using a resumable upload that can cause
    ///    noticeable performance degradation while uploading a series of small
    /// files. When uploading files less than 10MB, it is recommended that the
    /// resumable feature is disabled.
    /// </p>
    ///
    /// For faster crc32c computation, you must manually install
    /// [`fast-crc32c`](http://www.gitnpm.com/fast-crc32c):
    ///
    ///      $ npm install --save fast-crc32c
    ///
    /// NOTE: Writable streams will emit the `finish` event when the file is fully
    /// uploaded.</summary>
    /// <param name="options">Configuration options.</param>
    abstract createWriteStream: ?options: CreateWriteStreamOptions -> Writable<'a>
    abstract download: ?options: DownloadOptions -> Promise<DownloadResponse>
    abstract download: options: DownloadOptions * callback: DownloadCallback -> unit
    abstract download: callback: DownloadCallback -> unit
    /// <summary>The Storage API allows you to use a custom key for server-side encryption.</summary>
    /// <param name="encryptionKey">An AES-256 encryption key.</param>
    abstract setEncryptionKey: encryptionKey: U2<string, Buffer> -> File
    abstract getExpirationDate: unit -> Promise<GetExpirationDateResponse>
    abstract getExpirationDate: callback: GetExpirationDateCallback -> unit
    abstract getSignedPolicy: options: GetSignedPolicyOptions -> Promise<GetSignedPolicyResponse>
    abstract getSignedPolicy: options: GetSignedPolicyOptions * callback: GetSignedPolicyCallback -> unit
    abstract getSignedPolicy: callback: GetSignedPolicyCallback -> unit
    abstract getSignedUrl: cfg: GetSignedUrlConfig -> Promise<GetSignedUrlResponse>
    abstract getSignedUrl: cfg: GetSignedUrlConfig * callback: GetSignedUrlCallback -> unit
    abstract makePrivate: ?options: MakeFilePrivateOptions -> Promise<MakeFilePrivateResponse>
    abstract makePrivate: callback: MakeFilePrivateCallback -> unit
    abstract makePrivate: options: MakeFilePrivateOptions * callback: MakeFilePrivateCallback -> unit
    abstract makePublic: unit -> Promise<MakeFilePublicResponse>
    abstract makePublic: callback: MakeFilePublicCallback -> unit
    abstract move: destination: U3<string, Bucket, File> * ?options: MoveOptions -> Promise<MoveResponse>
    abstract move: destination: U3<string, Bucket, File> * callback: MoveCallback -> unit
    abstract move: destination: U3<string, Bucket, File> * options: MoveOptions * callback: MoveCallback -> unit
    abstract request: reqOpts: DecorateRequestOptions -> Promise<ResponseBody * R.Response>
    abstract request: reqOpts: DecorateRequestOptions * callback: BodyResponseCallback -> unit
    abstract rotateEncryptionKey: ?options: RotateEncryptionKeyOptions -> Promise<RotateEncryptionKeyResponse>
    abstract rotateEncryptionKey: callback: RotateEncryptionKeyCallback -> unit
    abstract rotateEncryptionKey: options: RotateEncryptionKeyOptions * callback: RotateEncryptionKeyCallback -> unit
    abstract save: data: obj option * ?options: SaveOptions -> Promise<unit>
    abstract save: data: obj option * callback: SaveCallback -> unit
    abstract save: data: obj option * options: SaveOptions * callback: SaveCallback -> unit
    abstract setStorageClass: storageClass: string * ?options: SetStorageClassOptions -> Promise<SetStorageClassResponse>
    abstract setStorageClass: storageClass: string * options: SetStorageClassOptions * callback: SetStorageClassCallback -> unit
    abstract setStorageClass: storageClass: string * ?callback: SetStorageClassCallback -> unit
    /// <summary>Set a user project to be billed for all requests made from this File
    /// object.</summary>
    /// <param name="userProject">The user project.</param>
    abstract setUserProject: userProject: string -> unit
    /// <summary>This creates a gcs-resumable-upload upload stream.</summary>
    /// <param name="options">- Configuration object.</param>
    abstract startResumableUpload_: dup: Duplexify.Duplexify<'a, 'b> * options: CreateResumableUploadOptions -> unit
    /// <summary>Takes a readable stream and pipes it to a remote file. Unlike
    /// `startResumableUpload_`, which uses the resumable upload technique, this
    /// method uses a simple upload (all or nothing).</summary>
    /// <param name="dup">- Duplexify stream of data to pipe to the file.</param>
    /// <param name="options">- Configuration object.</param>
    abstract startSimpleUpload_: dup: Duplexify.Duplexify<'a, 'b> * ?options: CreateResumableUploadOptions -> unit

/// A File object is created from your {@link Bucket} object using
/// {@link Bucket#file}.
type [<AllowNullLiteral>] FileStatic =
    /// <summary>Constructs a file object.</summary>
    /// <param name="bucket">The Bucket instance this file is
    /// attached to.</param>
    /// <param name="name">The name of the remote file.</param>
    /// <param name="options">Configuration options.</param>
    [<Emit "new $0($1...)">] abstract Create: bucket: Bucket * name: string * ?options: FileOptions -> File


//
// iam.d.ts
//

[<RequireQualifiedAccess>]
module Iam =
    type [<AllowNullLiteral>] IExports =
        abstract Iam: IamStatic

    type [<AllowNullLiteral>] TypeLiteral_01 =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> bool with get, set


type [<AllowNullLiteral>] GetPolicyOptions =
    abstract userProject: string option with get, set

type GetPolicyResponse =
    Policy * R.Response

type [<AllowNullLiteral>] GetPolicyCallback =
    [<Emit "$0($1...)">] abstract Invoke: ?err: Error * ?acl: Policy * ?apiResponse: R.Response -> unit

type [<AllowNullLiteral>] SetPolicyOptions =
    abstract userProject: string option with get, set

type SetPolicyResponse =
    Policy * R.Response

type [<AllowNullLiteral>] SetPolicyCallback =
    [<Emit "$0($1...)">] abstract Invoke: ?err: Error * ?acl: Policy * ?apiResponse: obj -> unit

type [<AllowNullLiteral>] Policy =
    abstract bindings: ResizeArray<PolicyBinding> with get, set
    abstract etag: string option with get, set

type [<AllowNullLiteral>] PolicyBinding =
    abstract role: string with get, set
    abstract members: ResizeArray<string> with get, set

type TestIamPermissionsResponse =
    Iam.TypeLiteral_01 * R.Response

type [<AllowNullLiteral>] TestIamPermissionsCallback =
    [<Emit "$0($1...)">] abstract Invoke: ?err: Error * ?acl: Iam.TypeLiteral_01 * ?apiResponse: R.Response -> unit

type [<AllowNullLiteral>] TestIamPermissionsOptions =
    abstract userProject: string option with get, set

/// Get and set IAM policies for your Cloud Storage bucket.
type [<AllowNullLiteral>] Iam =
    abstract getPolicy: ?options: GetPolicyOptions -> Promise<GetPolicyResponse>
    abstract getPolicy: options: GetPolicyOptions * callback: GetPolicyCallback -> unit
    abstract getPolicy: callback: GetPolicyCallback -> unit
    abstract setPolicy: policy: Policy * ?options: SetPolicyOptions -> Promise<SetPolicyResponse>
    abstract setPolicy: policy: Policy * callback: SetPolicyCallback -> unit
    abstract setPolicy: policy: Policy * options: SetPolicyOptions * callback: SetPolicyCallback -> unit
    abstract testPermissions: permissions: U2<string, ResizeArray<string>> * ?options: TestIamPermissionsOptions -> Promise<TestIamPermissionsResponse>
    abstract testPermissions: permissions: U2<string, ResizeArray<string>> * callback: TestIamPermissionsCallback -> unit
    abstract testPermissions: permissions: U2<string, ResizeArray<string>> * options: TestIamPermissionsOptions * callback: TestIamPermissionsCallback -> unit

/// Get and set IAM policies for your Cloud Storage bucket.
type [<AllowNullLiteral>] IamStatic =
    [<Emit "new $0($1...)">] abstract Create: bucket: Bucket -> Iam


//
// notification.d.ts
//

//type MetadataCallback = @google_cloud_common.MetadataCallback
//type ServiceObject = @google_cloud_common.ServiceObject
//type ResponseBody = @google_cloud_common_build_src_util.ResponseBody
//type Bucket = __bucket.Bucket

[<RequireQualifiedAccess>]
module Notification =
    type [<AllowNullLiteral>] IExports =
        abstract Notification: NotificationStatic


type [<AllowNullLiteral>] DeleteNotificationOptions =
    abstract userProject: string option with get, set

type [<AllowNullLiteral>] GetNotificationMetadataOptions =
    abstract userProject: string option with get, set

type GetNotificationMetadataResponse =
    ResponseBody * Request.Response

type [<AllowNullLiteral>] GetNotificationMetadataCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * ?metadata: ResponseBody * ?apiResponse: Request.Response -> unit

type GetNotificationResponse =
    Notification * Request.Response

type [<AllowNullLiteral>] GetNotificationOptions =
    /// Automatically create the object if it does not exist. Default: `false`.
    abstract autoCreate: bool option with get, set
    /// The ID of the project which will be billed for the request.
    abstract userProject: string option with get, set

type [<AllowNullLiteral>] GetNotificationCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * ?notification: Notification * ?apiResponse: Request.Response -> unit

type [<AllowNullLiteral>] DeleteNotificationCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * ?apiResponse: Request.Response -> unit

/// A Notification object is created from your {@link Bucket} object using
/// {@link Bucket#notification}. Use it to interact with Cloud Pub/Sub
/// notifications.
type [<AllowNullLiteral>] Notification =
    inherit ServiceObject
    abstract delete: ?options: DeleteNotificationOptions -> Promise<Request.Response>
    abstract delete: options: DeleteNotificationOptions * callback: DeleteNotificationCallback -> unit
    abstract delete: callback: DeleteNotificationCallback -> unit
    abstract get: ?options: GetNotificationOptions -> Promise<GetNotificationResponse>
    abstract get: options: GetNotificationOptions * callback: GetNotificationCallback -> unit
    abstract get: callback: GetNotificationCallback -> unit
    abstract getMetadata: ?options: GetNotificationMetadataOptions -> Promise<GetNotificationMetadataResponse>
    abstract getMetadata: options: GetNotificationMetadataOptions * callback: MetadataCallback -> unit
    abstract getMetadata: callback: MetadataCallback -> unit

/// A Notification object is created from your {@link Bucket} object using
/// {@link Bucket#notification}. Use it to interact with Cloud Pub/Sub
/// notifications.
type [<AllowNullLiteral>] NotificationStatic =
    [<Emit "new $0($1...)">] abstract Create: bucket: Bucket * id: string -> Notification


//
// storage.d.ts
//

//type GoogleAuthOptions = @google_cloud_common.GoogleAuthOptions
//type Service = @google_cloud_common.Service
//type Readable = Stream.Readable
//type Bucket = __bucket.Bucket
//type Channel = __channel.Channel
//type File = __file.File

/// Types that requuire extra qualification
[<RequireQualifiedAccess>]
module Storage =
    type [<AllowNullLiteral>] IExports =
        abstract Storage: StorageStatic

    [<RequireQualifiedAccess>]
    type [<AllowNullLiteral>] TypeLiteral_01 =
        abstract OWNER_ROLE: string with get, set
        abstract READER_ROLE: string with get, set
        abstract WRITER_ROLE: string with get, set



type [<AllowNullLiteral>] GetServiceAccountOptions =
    abstract userProject: string option with get, set

type [<AllowNullLiteral>] ServiceAccount =
    abstract emailAddress: string option with get, set

type GetServiceAccountResponse =
    ServiceAccount * R.Response

type [<AllowNullLiteral>] GetServiceAccountCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * ?serviceAccount: ServiceAccount * ?apiResponse: R.Response -> unit

type [<AllowNullLiteral>] CreateBucketQuery =
    abstract project: string with get, set
    abstract userProject: string with get, set

type [<AllowNullLiteral>] StorageOptions =
    // TODO
    // inherit GoogleAuthOptions
    abstract autoRetry: bool option with get, set
    abstract maxRetries: float option with get, set
    abstract promise: obj option with get, set

type [<AllowNullLiteral>] BucketOptions =
    abstract kmsKeyName: string option with get, set
    abstract userProject: string option with get, set

type [<AllowNullLiteral>] CreateBucketRequest =
    abstract coldline: bool option with get, set
    abstract dra: bool option with get, set
    abstract multiRegional: bool option with get, set
    abstract nearline: bool option with get, set
    abstract regional: bool option with get, set
    abstract requesterPays: bool option with get, set
    abstract retentionPolicy: obj option with get, set
    abstract userProject: string option with get, set
    abstract location: string option with get, set

type CreateBucketResponse =
    Bucket * R.Response

type [<AllowNullLiteral>] BucketCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * ?bucket: Bucket * ?apiResponse: R.Response -> unit

type GetBucketsResponse =
    ResizeArray<Bucket>

type [<AllowNullLiteral>] GetBucketsCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * buckets: ResizeArray<Bucket> -> unit

type [<AllowNullLiteral>] GetBucketsRequest =
    abstract prefix: string option with get, set
    abstract project: string option with get, set
    abstract autoPaginate: bool option with get, set
    abstract maxApiCalls: float option with get, set
    abstract maxResults: float option with get, set
    abstract pageToken: string option with get, set
    abstract userProject: string option with get, set

/// <h4>ACLs</h4>
/// Cloud Storage uses access control lists (ACLs) to manage object and
/// bucket access. ACLs are the mechanism you use to share files with other users
/// and allow other users to access your buckets and files.
///
/// To learn more about ACLs, read this overview on
/// [Access Control](https://cloud.google.com/storage/docs/access-control).
type [<AllowNullLiteral>] Storage =
    inherit Service
    /// Reference to {@link Storage.acl}.
    abstract acl: obj with get, set
    /// Get {@link Bucket} objects for all of the buckets in your project as
    /// a readable object stream.
    abstract getBucketsStream: (unit -> Readable<Bucket>) with get, set
    /// <summary>Get a reference to a Cloud Storage bucket.</summary>
    /// <param name="name">Name of the bucket.</param>
    /// <param name="options">User project to be billed for all
    /// requests made from this Bucket object.</param>
    abstract bucket: name: string * ?options: BucketOptions -> Bucket
    /// <summary>Reference a channel to receive notifications about changes to your bucket.</summary>
    /// <param name="id">The ID of the channel.</param>
    /// <param name="resourceId">The resource ID of the channel.</param>
    abstract channel: id: string * resourceId: string -> Channel
    abstract createBucket: name: string * ?metadata: CreateBucketRequest -> Promise<CreateBucketResponse>
    abstract createBucket: name: string * callback: BucketCallback -> unit
    abstract createBucket: name: string * metadata: CreateBucketRequest * callback: BucketCallback -> unit
    abstract getBuckets: ?options: GetBucketsRequest -> Promise<GetBucketsResponse>
    abstract getBuckets: options: GetBucketsRequest * callback: GetBucketsCallback -> unit
    abstract getBuckets: callback: GetBucketsCallback -> unit
    abstract getServiceAccount: ?options: GetServiceAccountOptions -> Promise<GetServiceAccountResponse>
    abstract getServiceAccount: options: GetServiceAccountOptions * callback: GetServiceAccountCallback -> unit
    abstract getServiceAccount: callback: GetServiceAccountCallback -> unit

/// <h4>ACLs</h4>
/// Cloud Storage uses access control lists (ACLs) to manage object and
/// bucket access. ACLs are the mechanism you use to share files with other users
/// and allow other users to access your buckets and files.
///
/// To learn more about ACLs, read this overview on
/// [Access Control](https://cloud.google.com/storage/docs/access-control).
type [<AllowNullLiteral>] StorageStatic =
    /// {@link Bucket} class.
    abstract Bucket: obj with get, set
    /// {@link Channel} class.
    abstract Channel: obj with get, set
    /// {@link File} class.
    abstract File: obj with get, set
    /// Cloud Storage uses access control lists (ACLs) to manage object and
    /// bucket access. ACLs are the mechanism you use to share objects with other
    /// users and allow other users to access your buckets and objects.
    ///
    /// This object provides constants to refer to the three permission levels that
    /// can be granted to an entity:
    ///
    ///    - `gcs.acl.OWNER_ROLE` - ("OWNER")
    ///    - `gcs.acl.READER_ROLE` - ("READER")
    ///    - `gcs.acl.WRITER_ROLE` - ("WRITER")
    abstract acl: Storage.TypeLiteral_01 with get, set
    /// <summary>Constructs the Storage client.</summary>
    /// <param name="options">Configuration options.</param>
    [<Emit "new $0($1...)">] abstract Create: ?options: StorageOptions -> Storage


//
// channel.d.ts
//

type Response = Request.Response
//type Storage = __storage.Storage

[<RequireQualifiedAccess>]
module Channel =
    type [<AllowNullLiteral>] IExports =
        abstract Channel: ChannelStatic

type [<AllowNullLiteral>] StopCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * ?apiResponse: Request.Response -> unit

/// Create a channel object to interact with a Cloud Storage channel.
type [<AllowNullLiteral>] Channel =
    inherit ServiceObject
    abstract stop: unit -> Promise<Response>
    abstract stop: callback: StopCallback -> unit

/// Create a channel object to interact with a Cloud Storage channel.
type [<AllowNullLiteral>] ChannelStatic =
    [<Emit "new $0($1...)">] abstract Create: storage: Storage * id: string * resourceId: string -> Channel
