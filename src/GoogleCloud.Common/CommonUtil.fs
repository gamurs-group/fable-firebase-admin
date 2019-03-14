namespace rec Fable.Import.GoogleCloud.Common

open Fable.Core
open Fable.Import.JS
open Fable.Import.Duplexify
//open Fable.Import.GoogleAuthLibrary

module R = Fable.Import.Request.Request
//type GoogleAuth = Google_auth_library.GoogleAuth
//type GoogleAuthOptions = Google_auth_library.GoogleAuthOptions
//type CredentialBody = Google_auth_library_build_src_auth_credentials.CredentialBody

//let [<Import("util","@google-cloud/common/build/src/util")>] util: Util = jsNative


type [<AllowNullLiteral>] ParsedHttpRespMessage =
    abstract resp: R.Response with get, set
    abstract err: ApiError option with get, set

// TODO
//type [<AllowNullLiteral>] MakeAuthenticatedRequest =
//    [<Emit "$0($1...)">] abstract Invoke: reqOpts: DecorateRequestOptions -> Duplexify.Duplexify<'a, 'b>
//    [<Emit "$0($1...)">] abstract Invoke: reqOpts: DecorateRequestOptions * ?options: MakeAuthenticatedRequestOptions -> U2<unit, Abortable>
//    [<Emit "$0($1...)">] abstract Invoke: reqOpts: DecorateRequestOptions * ?callback: BodyResponseCallback -> U2<unit, Abortable>
//    [<Emit "$0($1...)">] abstract Invoke: reqOpts: DecorateRequestOptions * ?optionsOrCallback: U2<MakeAuthenticatedRequestOptions, BodyResponseCallback> -> U3<unit, Abortable, Duplexify.Duplexify<'a, 'b>>
//    abstract getCredentials: ((Error -> CredentialBody -> unit) -> unit) with get, set
//    abstract authClient: GoogleAuth with get, set

type [<AllowNullLiteral>] Abortable =
    abstract abort: unit -> unit

type [<AllowNullLiteral>] AbortableDuplex =
    interface end

type [<AllowNullLiteral>] PackageJson =
    abstract name: string with get, set
    abstract version: string with get, set

// TODO
//type [<AllowNullLiteral>] MakeAuthenticatedRequestFactoryConfig =
//    inherit GoogleAuthOptions
//    /// Automatically retry requests if the response is related to rate limits or
//    /// certain intermittent server errors. We will exponentially backoff
//    /// subsequent requests by default. (default: true)
//    abstract autoRetry: bool option with get, set
//    /// If true, just return the provided request options. Default: false.
//    abstract customEndpoint: bool option with get, set
//    /// Account email address, required for PEM/P12 usage.
//    abstract email: string option with get, set
//    /// Maximum number of automatic retries attempted before returning the error.
//    /// (default: 3)
//    abstract maxRetries: float option with get, set
//    abstract stream: Duplexify.Duplexify<'a, 'b> option with get, set
//    abstract request: obj with get, set
//    /// A pre-instantiated GoogleAuth client that should be used.
//    /// A new will be created if this is not set.
//    abstract authClient: GoogleAuth option with get, set

type [<AllowNullLiteral>] MakeAuthenticatedRequestOptions =
    abstract onAuthenticated: OnAuthenticatedCallback with get, set

type [<AllowNullLiteral>] OnAuthenticatedCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * ?reqOpts: DecorateRequestOptions -> unit

type [<AllowNullLiteral>] DecorateRequestOptions =
    inherit R.CoreOptions
    abstract autoPaginate: bool option with get, set
    abstract autoPaginateVal: bool option with get, set
    abstract objectMode: bool option with get, set
    abstract maxRetries: float option with get, set
    abstract uri: string with get, set
    abstract interceptors_: ResizeArray<Interceptor> option with get, set
    abstract shouldReturnStream: bool option with get, set

type [<AllowNullLiteral>] Interceptor =
    abstract request: opts: R.Options -> DecorateRequestOptions

type ResponseBody =
    obj option

type [<AllowNullLiteral>] BodyResponseCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * ?body: ResponseBody * ?res: R.Response -> unit

type [<AllowNullLiteral>] GoogleErrorBody =
    abstract code: float with get, set
    abstract errors: ResizeArray<GoogleInnerError> option with get, set
    abstract response: R.Response with get, set
    abstract message: string option with get, set

type [<AllowNullLiteral>] GoogleInnerError =
    abstract reason: string option with get, set
    abstract message: string option with get, set

type [<AllowNullLiteral>] MakeWritableStreamOptions =
    /// A connection instance used to get a token with and send the request
    /// through.
    abstract connection: Util.TypeLiteral_01 option with get, set
    /// Metadata to send at the head of the request.
    abstract metadata: Util.TypeLiteral_02 option with get, set
    /// Request object, in the format of a standard Node.js http.request() object.
    abstract request: R.Options option with get, set
    /// Dependency for HTTP calls.
    abstract requestModule: obj with get, set
    abstract makeAuthenticatedRequest: reqOpts: R.OptionsWithUri * fnobj: MakeWritableStreamOptionsMakeAuthenticatedRequestFnobj -> unit

type [<AllowNullLiteral>] MakeWritableStreamOptionsMakeAuthenticatedRequestFnobj =
    abstract onAuthenticated: err: Error option * ?authenticatedReqOpts: R.Options -> unit

type [<AllowNullLiteral>] ParsedHttpResponseBody =
    abstract body: ResponseBody with get, set
    abstract err: Error option with get, set

/// Custom error type for API errors.
type [<AllowNullLiteral>] ApiError =
    inherit Error
    abstract code: float option with get, set
    abstract errors: ResizeArray<GoogleInnerError> option with get, set
    abstract response: R.Response option with get, set

/// Custom error type for API errors.
type [<AllowNullLiteral>] ApiErrorStatic =
    [<Emit "new $0($1...)">] abstract Create: errorMessage: string -> ApiError
    [<Emit "new $0($1...)">] abstract Create: errorBody: GoogleErrorBody -> ApiError

/// Custom error type for partial errors returned from the API.
type [<AllowNullLiteral>] PartialFailureError =
    inherit Error
    abstract errors: ResizeArray<GoogleInnerError> option with get, set
    abstract response: R.Response option with get, set

/// Custom error type for partial errors returned from the API.
type [<AllowNullLiteral>] PartialFailureErrorStatic =
    [<Emit "new $0($1...)">] abstract Create: b: GoogleErrorBody -> PartialFailureError

type [<AllowNullLiteral>] MakeRequestConfig =
    /// Automatically retry requests if the response is related to rate limits or
    /// certain intermittent server errors. We will exponentially backoff
    /// subsequent requests by default. (default: true)
    abstract autoRetry: bool option with get, set
    /// Maximum number of automatic retries attempted before returning the error.
    /// (default: 3)
    abstract maxRetries: float option with get, set
    abstract retries: float option with get, set
    abstract stream: Duplexify.Duplexify<'a, 'b> option with get, set
    abstract request: obj option with get, set
    abstract shouldRetryFn: (R.Response -> bool) option with get, set

type [<AllowNullLiteral>] Util =
    abstract ApiError: obj with get, set
    abstract PartialFailureError: obj with get, set
    /// No op.
    abstract noop: unit -> unit
    /// <summary>Uniformly process an API response.</summary>
    /// <param name="err">- Error value.</param>
    /// <param name="resp">- Response value.</param>
    /// <param name="body">- Body value.</param>
    /// <param name="callback">- The callback function.</param>
    abstract handleResp: err: Error option * ?resp: R.Response * ?body: ResponseBody * ?callback: BodyResponseCallback -> unit
    /// <summary>Sniff an incoming HTTP response message for errors.</summary>
    /// <param name="httpRespMessage">- An incoming HTTP response message from `request`.</param>
    abstract parseHttpRespMessage: httpRespMessage: R.Response -> ParsedHttpRespMessage
    /// <summary>Parse the response body from an HTTP request.</summary>
    /// <param name="body">- The response body.</param>
    abstract parseHttpRespBody: body: ResponseBody -> ParsedHttpResponseBody
    /// <summary>Take a Duplexify stream, fetch an authenticated connection header, and
    /// create an outgoing writable stream.</summary>
    /// <param name="dup">- Duplexify stream.</param>
    /// <param name="options">- Configuration object.</param>
    /// <param name="onComplete">- Callback, executed after the writable Request stream has completed.</param>
    abstract makeWritableStream: dup: Duplexify.Duplexify<'a, 'b> * options: MakeWritableStreamOptions * ?onComplete: Function -> unit
    /// <summary>Returns true if the API request should be retried, given the error that was
    /// given the first time the request was attempted. This is used for rate limit
    /// related errors as well as intermittent server errors.</summary>
    /// <param name="err">- The API error to check if it is appropriate to retry.</param>
    abstract shouldRetryRequest: ?err: ApiError -> bool
    /// <summary>Get a function for making authenticated requests.</summary>
    /// <param name="config">- Array of scopes required for the API.</param>
    // TODO
    // abstract makeAuthenticatedRequestFactory: config: MakeAuthenticatedRequestFactoryConfig -> MakeAuthenticatedRequest
    /// <summary>Make a request through the `retryRequest` module with built-in error
    /// handling and exponential back off.</summary>
    /// <param name="reqOpts">- Request options in the format `request` expects.</param>
    /// <param name="config">- Configuration object.</param>
    /// <param name="callback">- The callback function.</param>
    abstract makeRequest: reqOpts: DecorateRequestOptions * config: MakeRequestConfig * callback: BodyResponseCallback -> U2<unit, Abortable>
    /// <summary>Decorate the options about to be made in a request.</summary>
    /// <param name="reqOpts">- The options to be passed to `request`.</param>
    /// <param name="projectId">- The project ID.</param>
    abstract decorateRequest: reqOpts: DecorateRequestOptions * projectId: string -> DecorateRequestOptions
    abstract isCustomType: unknown: obj option * ``module``: string -> bool
    /// <summary>Create a properly-formatted User-Agent string from a package.json file.</summary>
    /// <param name="packageJson">- A module's package.json file.</param>
    abstract getUserAgentFromPackageJson: packageJson: PackageJson -> string
    /// <summary>Given two parameters, figure out if this is either:
    ///   - Just a callback function
    ///   - An options object, and then a callback function</summary>
    /// <param name="optionsOrCallback">An options object or callback.</param>
    /// <param name="cb">A potentially undefined callback.</param>
    abstract maybeOptionsOrCallback: ?optionsOrCallback: U2<'T, 'C> * ?cb: 'C -> 'T * 'C

type [<AllowNullLiteral>] UtilStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> Util

[<RequireQualifiedAccess>]
module Util =
    type [<AllowNullLiteral>] IExports =
        abstract ApiError: ApiErrorStatic
        abstract PartialFailureError: PartialFailureErrorStatic
        abstract Util: UtilStatic

    type [<AllowNullLiteral>] TypeLiteral_01 =
        interface end

    type [<AllowNullLiteral>] TypeLiteral_02 =
        abstract contentType: string option with get, set
