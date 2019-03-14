namespace rec Fable.Import.GoogleCloud.Common

open System
open Fable.Core
open Fable.Import.JS
open Fable.Import.Node.Events

module R = Fable.Import.Request.Request

type RequestResponse =
    Metadata * R.Response

type [<AllowNullLiteral>] ServiceObjectParent =
    abstract Promise: PromiseConstructor option with get, set
    abstract requestModule: obj option with get, set
    abstract requestStream: reqOpts: DecorateRequestOptions -> R.Request
    abstract request: reqOpts: DecorateRequestOptions * callback: BodyResponseCallback -> unit

type GetMetadataOptions =
    obj

type Metadata =
    obj option

type MetadataResponse =
    Metadata * R.Response

type [<AllowNullLiteral>] MetadataCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * ?metadata: Metadata * ?apiResponse: R.Response -> unit

type ExistsOptions =
    obj

type [<AllowNullLiteral>] ExistsCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * ?exists: bool -> unit

type [<AllowNullLiteral>] ServiceObjectConfig =
    /// The base URL to make API requests to.
    abstract baseUrl: string option with get, set
    /// The method which creates this object.
    abstract createMethod: Function option with get, set
    /// The identifier of the object. For example, the name of a Storage bucket or
    /// Pub/Sub topic.
    abstract id: string option with get, set
    /// A map of each method name that should be inherited.
    abstract methods: Methods option with get, set
    /// The parent service instance. For example, an instance of Storage if the
    /// object is Bucket.
    abstract parent: ServiceObjectParent with get, set
    /// Dependency for HTTP calls.
    abstract requestModule: obj option with get, set

type [<AllowNullLiteral>] Methods =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: methodName: string -> U2<ServiceObject.TypeLiteral_01, bool> with get, set

type [<AllowNullLiteral>] InstanceResponseCallback<'T> =
    [<Emit "$0($1...)">] abstract Invoke: err: ApiError option * ?instance: 'T * ?apiResponse: R.Response -> unit

type [<AllowNullLiteral>] CreateOptions =
    interface end

type CreateResponse =
    ResizeArray<obj option>

type [<AllowNullLiteral>] CreateCallback<'T> =
    [<Emit "$0($1...)">] abstract Invoke: err: ApiError option * ?instance: 'T * [<ParamArray>] args: ResizeArray<obj option> -> unit

type DeleteOptions =
    obj

type [<AllowNullLiteral>] DeleteCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * ?apiResponse: R.Response -> unit

type [<AllowNullLiteral>] GetConfig =
    /// Create the object if it doesn't already exist.
    abstract autoCreate: bool option with get, set

type [<AllowNullLiteral>] GetOrCreateOptions =
    interface end

type GetResponse<'T> =
    'T * R.Response

type [<AllowNullLiteral>] ResponseCallback =
    [<Emit "$0($1...)">] abstract Invoke: ?err: Error * ?apiResponse: R.Response -> unit

type SetMetadataResponse =
    Metadata

type SetMetadataOptions =
    obj

type ServiceObject =
    ServiceObject<obj>

/// ServiceObject is a base class, meant to be inherited from by a "service
/// object," like a BigQuery dataset or Storage bucket.
///
/// Most of the time, these objects share common functionality; they can be
/// created or deleted, and you can get or set their metadata.
///
/// By inheriting from this class, a service object will be extended with these
/// shared behaviors. Note that any method can be overridden when the service
/// object requires specific behavior.
type [<AllowNullLiteral>] ServiceObject<'T> =
    inherit EventEmitter
    abstract metadata: Metadata with get, set
    abstract baseUrl: string option with get, set
    abstract parent: ServiceObjectParent with get, set
    abstract id: string option with get, set
    abstract methods: Methods with get, set
    abstract interceptors: ResizeArray<Interceptor> with get, set
    abstract Promise: PromiseConstructor option with get, set
    abstract requestModule: obj with get, set
    /// <summary>Create the object.</summary>
    /// <param name="options">- Configuration object.</param>
    abstract create: ?options: CreateOptions -> Promise<CreateResponse>
    abstract create: options: CreateOptions * callback: CreateCallback<'T> -> unit
    abstract create: callback: CreateCallback<'T> -> unit
    /// Delete the object.
    abstract delete: ?options: DeleteOptions -> Promise<R.Response>
    abstract delete: options: DeleteOptions * callback: DeleteCallback -> unit
    abstract delete: callback: DeleteCallback -> unit
    /// Check if the object exists.
    abstract exists: ?options: ExistsOptions -> Promise<bool>
    abstract exists: options: ExistsOptions * callback: ExistsCallback -> unit
    abstract exists: callback: ExistsCallback -> unit
    /// <summary>Get the object if it exists. Optionally have the object created if an
    /// options object is provided with `autoCreate: true`.</summary>
    /// <param name="options">- The configuration object that will be used to
    /// create the object if necessary.</param>
    abstract get: ?options: GetOrCreateOptions -> Promise<GetResponse<'T>>
    abstract get: callback: InstanceResponseCallback<'T> -> unit
    abstract get: options: GetOrCreateOptions * callback: InstanceResponseCallback<'T> -> unit
    /// Get the metadata of this object.
    abstract getMetadata: ?options: GetMetadataOptions -> Promise<MetadataResponse>
    abstract getMetadata: options: GetMetadataOptions * callback: MetadataCallback -> unit
    abstract getMetadata: callback: MetadataCallback -> unit
    /// <summary>Set the metadata for this object.</summary>
    /// <param name="metadata">- The metadata to set on this object.</param>
    /// <param name="options">- Configuration options.</param>
    abstract setMetadata: metadata: Metadata * ?options: SetMetadataOptions -> Promise<SetMetadataResponse>
    abstract setMetadata: metadata: Metadata * callback: MetadataCallback -> unit
    abstract setMetadata: metadata: Metadata * options: SetMetadataOptions * callback: MetadataCallback -> unit
    /// <summary>Make an authenticated API request.</summary>
    /// <param name="reqOpts">- A URI relative to the baseUrl.</param>
    abstract request: reqOpts: DecorateRequestOptions -> Promise<RequestResponse>
    abstract request: reqOpts: DecorateRequestOptions * callback: BodyResponseCallback -> unit
    /// <summary>Make an authenticated API request.</summary>
    /// <param name="reqOpts">- A URI relative to the baseUrl.</param>
    abstract requestStream: reqOpts: DecorateRequestOptions -> R.Request

/// ServiceObject is a base class, meant to be inherited from by a "service
/// object," like a BigQuery dataset or Storage bucket.
///
/// Most of the time, these objects share common functionality; they can be
/// created or deleted, and you can get or set their metadata.
///
/// By inheriting from this class, a service object will be extended with these
/// shared behaviors. Note that any method can be overridden when the service
/// object requires specific behavior.
type [<AllowNullLiteral>] ServiceObjectStatic =
    [<Emit "new $0($1...)">] abstract Create: config: ServiceObjectConfig -> ServiceObject<'T>

/// Types that require extra qualification
[<RequireQualifiedAccess>]
module ServiceObject =
    type [<AllowNullLiteral>] IExports =
        abstract ServiceObject: ServiceObjectStatic

    type [<AllowNullLiteral>] TypeLiteral_01 =
        abstract reqOpts: R.CoreOptions option with get, set

