namespace rec Fable.Import.GoogleCloud.Common

open Fable.Core
open Fable.Import.JS
//open Fable.Import.GoogleAuthLibrary

module R = Fable.Import.Request.Request
//type GoogleAuth = Google_auth_library.GoogleAuth
//type GoogleAuthOptions = Google_auth_library.GoogleAuthOptions

type [<AllowNullLiteral>] StreamRequestOptions =
    inherit DecorateRequestOptions
    abstract shouldReturnStream: obj with get, set

type [<AllowNullLiteral>] ServiceConfig =
    /// The base URL to make API requests to.
    abstract baseUrl: string with get, set
    /// The scopes required for the request.
    abstract scopes: ResizeArray<string> with get, set
    abstract projectIdRequired: bool option with get, set
    abstract packageJson: PackageJson with get, set
    abstract requestModule: obj with get, set
    /// Reuse an existing GoogleAuth client instead of creating a new one.
    // TODO
    // abstract authClient: GoogleAuth option with get, set

type [<AllowNullLiteral>] ServiceOptions =
    // TODO
    // inherit GoogleAuthOptions
    abstract interceptors_: ResizeArray<Interceptor> option with get, set
    abstract promise: PromiseConstructor option with get, set
    abstract email: string option with get, set
    abstract token: string option with get, set

type [<AllowNullLiteral>] Service =
    abstract baseUrl: string with get, set
    abstract projectId: string with get, set
    abstract Promise: PromiseConstructor with get, set
    // TODO
//    abstract makeAuthenticatedRequest: MakeAuthenticatedRequest with get, set
//    abstract authClient: GoogleAuth with get, set
    abstract requestModule: obj with get, set
    /// Get and update the Service's project ID.
    abstract getProjectId: unit -> Promise<string>
    abstract getProjectId: callback: (Error option -> string -> unit) -> unit
    abstract getProjectIdAsync: unit -> Promise<string>
    /// <summary>Make an authenticated API request.</summary>
    /// <param name="reqOpts">- A URI relative to the baseUrl.</param>
    /// <param name="callback">- The callback function passed to `request`.</param>
    abstract request: reqOpts: DecorateRequestOptions * callback: BodyResponseCallback -> unit
    /// <summary>Make an authenticated API request.</summary>
    /// <param name="reqOpts">- A URI relative to the baseUrl.</param>
    abstract requestStream: reqOpts: DecorateRequestOptions -> R.Request

type [<AllowNullLiteral>] ServiceStatic =
    /// <summary>Service is a base class, meant to be inherited from by a "service," like
    /// BigQuery or Storage.
    ///
    /// This handles making authenticated requests by exposing a `makeReq_`
    /// function.</summary>
    /// <param name="config">- The scopes required for the request.</param>
    /// <param name="options">- [Configuration object](#/docs).</param>
    [<Emit "new $0($1...)">] abstract Create: config: ServiceConfig * ?options: ServiceOptions -> Service

/// Types that require extra qualification
[<RequireQualifiedAccess>]
module Service =
    type [<AllowNullLiteral>] IExports =
        abstract Service: ServiceStatic
