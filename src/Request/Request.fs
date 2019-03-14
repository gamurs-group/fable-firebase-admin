/// Prue bindings for the npm 'request' package.
module rec Fable.Import.Request

open System
open Fable.Core
open Fable.Import
open Fable.Import.Caseless
open Fable.Import.Node
open Fable.Import.JS

type Url = Url
type SecureContextOptions = Tls.SecureContextOptions

module Request =

    type [<AllowNullLiteral>] RequestAPI<'TRequest, 'TOptions, 'TUriUrlOptions> =
        abstract defaults: options: 'TOptions -> RequestAPI<'TRequest, 'TOptions, RequiredUriUrl>
        abstract defaults: options: obj -> DefaultUriUrlRequestApi<'TRequest, 'TOptions, OptionalUriUrl>
        [<Emit "$0($1...)">] abstract Invoke: uri: string * ?options: 'TOptions * ?callback: RequestCallback -> 'TRequest
        [<Emit "$0($1...)">] abstract Invoke: uri: string * ?callback: RequestCallback -> 'TRequest
        [<Emit "$0($1...)">] abstract Invoke: options: obj * ?callback: RequestCallback -> 'TRequest
        abstract get: uri: string * ?options: 'TOptions * ?callback: RequestCallback -> 'TRequest
        abstract get: uri: string * ?callback: RequestCallback -> 'TRequest
        abstract get: options: obj * ?callback: RequestCallback -> 'TRequest
        abstract post: uri: string * ?options: 'TOptions * ?callback: RequestCallback -> 'TRequest
        abstract post: uri: string * ?callback: RequestCallback -> 'TRequest
        abstract post: options: obj * ?callback: RequestCallback -> 'TRequest
        abstract put: uri: string * ?options: 'TOptions * ?callback: RequestCallback -> 'TRequest
        abstract put: uri: string * ?callback: RequestCallback -> 'TRequest
        abstract put: options: obj * ?callback: RequestCallback -> 'TRequest
        abstract head: uri: string * ?options: 'TOptions * ?callback: RequestCallback -> 'TRequest
        abstract head: uri: string * ?callback: RequestCallback -> 'TRequest
        abstract head: options: obj * ?callback: RequestCallback -> 'TRequest
        abstract patch: uri: string * ?options: 'TOptions * ?callback: RequestCallback -> 'TRequest
        abstract patch: uri: string * ?callback: RequestCallback -> 'TRequest
        abstract patch: options: obj * ?callback: RequestCallback -> 'TRequest
        abstract del: uri: string * ?options: 'TOptions * ?callback: RequestCallback -> 'TRequest
        abstract del: uri: string * ?callback: RequestCallback -> 'TRequest
        abstract del: options: obj * ?callback: RequestCallback -> 'TRequest
        abstract delete: uri: string * ?options: 'TOptions * ?callback: RequestCallback -> 'TRequest
        abstract delete: uri: string * ?callback: RequestCallback -> 'TRequest
        abstract delete: options: obj * ?callback: RequestCallback -> 'TRequest
        abstract initParams: uri: string * ?options: 'TOptions * ?callback: RequestCallback -> obj
        abstract initParams: uriOrOpts: U2<string, obj> * ?callback: RequestCallback -> obj
        abstract forever: agentOptions: obj option * optionsArg: obj option -> 'TRequest
        abstract jar: ?store: obj -> CookieJar
        abstract cookie: str: string -> Cookie option
        abstract debug: bool with get, set

    type [<AllowNullLiteral>] DefaultUriUrlRequestApi<'TRequest, 'TOptions, 'TUriUrlOptions> =
        inherit RequestAPI<'TRequest, 'TOptions, 'TUriUrlOptions>
        abstract defaults: options: 'TOptions -> DefaultUriUrlRequestApi<'TRequest, 'TOptions, OptionalUriUrl>
        [<Emit "$0($1...)">] abstract Invoke: ?callback: RequestCallback -> 'TRequest
        abstract get: uri: string * ?options: 'TOptions * ?callback: RequestCallback -> 'TRequest
        abstract get: uri: string * ?callback: RequestCallback -> 'TRequest
        abstract get: options: obj * ?callback: RequestCallback -> 'TRequest
        abstract get: ?callback: RequestCallback -> 'TRequest
        abstract post: uri: string * ?options: 'TOptions * ?callback: RequestCallback -> 'TRequest
        abstract post: uri: string * ?callback: RequestCallback -> 'TRequest
        abstract post: options: obj * ?callback: RequestCallback -> 'TRequest
        abstract post: ?callback: RequestCallback -> 'TRequest
        abstract put: uri: string * ?options: 'TOptions * ?callback: RequestCallback -> 'TRequest
        abstract put: uri: string * ?callback: RequestCallback -> 'TRequest
        abstract put: options: obj * ?callback: RequestCallback -> 'TRequest
        abstract put: ?callback: RequestCallback -> 'TRequest
        abstract head: uri: string * ?options: 'TOptions * ?callback: RequestCallback -> 'TRequest
        abstract head: uri: string * ?callback: RequestCallback -> 'TRequest
        abstract head: options: obj * ?callback: RequestCallback -> 'TRequest
        abstract head: ?callback: RequestCallback -> 'TRequest
        abstract patch: uri: string * ?options: 'TOptions * ?callback: RequestCallback -> 'TRequest
        abstract patch: uri: string * ?callback: RequestCallback -> 'TRequest
        abstract patch: options: obj * ?callback: RequestCallback -> 'TRequest
        abstract patch: ?callback: RequestCallback -> 'TRequest
        abstract del: uri: string * ?options: 'TOptions * ?callback: RequestCallback -> 'TRequest
        abstract del: uri: string * ?callback: RequestCallback -> 'TRequest
        abstract del: options: obj * ?callback: RequestCallback -> 'TRequest
        abstract del: ?callback: RequestCallback -> 'TRequest
        abstract delete: uri: string * ?options: 'TOptions * ?callback: RequestCallback -> 'TRequest
        abstract delete: uri: string * ?callback: RequestCallback -> 'TRequest
        abstract delete: options: obj * ?callback: RequestCallback -> 'TRequest
        abstract delete: ?callback: RequestCallback -> 'TRequest

    type [<AllowNullLiteral>] CoreOptions =
        abstract baseUrl: string option with get, set
        abstract callback: RequestCallback option with get, set
        abstract jar: U2<CookieJar, bool> option with get, set
        abstract formData: TypeLiteral_01 option with get, set
        abstract form: U2<TypeLiteral_01, string> option with get, set
        abstract auth: AuthOptions option with get, set
        abstract oauth: OAuthOptions option with get, set
        abstract aws: AWSOptions option with get, set
        abstract hawk: HawkOptions option with get, set
        abstract qs: obj option with get, set
        abstract qsStringifyOptions: obj option with get, set
        abstract qsParseOptions: obj option with get, set
        abstract json: obj option with get, set
        abstract jsonReviver: (string -> obj option -> obj option) option with get, set
        abstract jsonReplacer: (string -> obj option -> obj option) option with get, set
        abstract multipart: U2<ResizeArray<RequestPart>, Multipart> option with get, set
        abstract agent: U2<Http.Agent, Https.Agent> option with get, set
        abstract agentOptions: U2<Http.AgentOptions, Https.AgentOptions> option with get, set
        abstract agentClass: obj option with get, set
        abstract forever: obj option with get, set
        abstract host: string option with get, set
        abstract port: float option with get, set
        abstract ``method``: string option with get, set
        abstract headers: Headers option with get, set
        abstract body: obj option with get, set
        abstract family: obj option with get, set
        abstract followRedirect: U2<bool, (Http.IncomingMessage -> bool)> option with get, set
        abstract followAllRedirects: bool option with get, set
        abstract followOriginalHttpMethod: bool option with get, set
        abstract maxRedirects: float option with get, set
        abstract removeRefererHeader: bool option with get, set
        abstract encoding: string option with get, set
        abstract pool: obj option with get, set
        abstract timeout: float option with get, set
        abstract localAddress: string option with get, set
        abstract proxy: obj option with get, set
        abstract tunnel: bool option with get, set
        abstract strictSSL: bool option with get, set
        abstract rejectUnauthorized: bool option with get, set
        abstract time: bool option with get, set
        abstract gzip: bool option with get, set
        abstract preambleCRLF: bool option with get, set
        abstract postambleCRLF: bool option with get, set
        abstract withCredentials: bool option with get, set
        abstract key: Buffer option with get, set
        abstract cert: Buffer option with get, set
        abstract passphrase: string option with get, set
        abstract ca: U4<string, Buffer, ResizeArray<string>, ResizeArray<Buffer>> option with get, set
        abstract har: HttpArchiveRequest option with get, set
        abstract useQuerystring: bool option with get, set

    type [<AllowNullLiteral>] UriOptions =
        abstract uri: U2<string, Url> with get, set

    type [<AllowNullLiteral>] UrlOptions =
        abstract url: U2<string, Url> with get, set

    type RequiredUriUrl =
        U2<UriOptions, UrlOptions>

    [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module RequiredUriUrl =
        let ofUriOptions v: RequiredUriUrl = v |> U2.Case1
        let isUriOptions (v: RequiredUriUrl) = match v with U2.Case1 _ -> true | _ -> false
        let asUriOptions (v: RequiredUriUrl) = match v with U2.Case1 o -> Some o | _ -> None
        let ofUrlOptions v: RequiredUriUrl = v |> U2.Case2
        let isUrlOptions (v: RequiredUriUrl) = match v with U2.Case2 _ -> true | _ -> false
        let asUrlOptions (v: RequiredUriUrl) = match v with U2.Case2 o -> Some o | _ -> None

    type OptionalUriUrl =
        RequiredUriUrl

    type [<AllowNullLiteral>] OptionsWithUri =
        interface end

    type [<AllowNullLiteral>] OptionsWithUrl =
        interface end

    type Options =
        U2<OptionsWithUri, OptionsWithUrl>

    [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module Options =
        let ofOptionsWithUri v: Options = v |> U2.Case1
        let isOptionsWithUri (v: Options) = match v with U2.Case1 _ -> true | _ -> false
        let asOptionsWithUri (v: Options) = match v with U2.Case1 o -> Some o | _ -> None
        let ofOptionsWithUrl v: Options = v |> U2.Case2
        let isOptionsWithUrl (v: Options) = match v with U2.Case2 _ -> true | _ -> false
        let asOptionsWithUrl (v: Options) = match v with U2.Case2 o -> Some o | _ -> None

    type [<AllowNullLiteral>] RequestCallback =
        [<Emit "$0($1...)">] abstract Invoke: error: obj option * response: Response * body: obj option -> unit

    type [<AllowNullLiteral>] HttpArchiveRequest =
        abstract url: string option with get, set
        abstract ``method``: string option with get, set
        abstract headers: ResizeArray<NameValuePair> option with get, set
        abstract postData: TypeLiteral_02 option with get, set

    type [<AllowNullLiteral>] NameValuePair =
        abstract name: string with get, set
        abstract value: string with get, set

    type [<AllowNullLiteral>] Multipart =
        abstract chunked: bool option with get, set
        abstract data: Array<TypeLiteral_03> option with get, set

    type [<AllowNullLiteral>] RequestPart =
        abstract headers: Headers option with get, set
        abstract body: obj option with get, set

    type [<AllowNullLiteral>] Request =
        inherit Caseless.Httpified
        inherit Stream.Stream
        abstract readable: bool with get, set
        abstract writable: bool with get, set
        abstract explicitMethod: obj option with get, set
        abstract debug: [<ParamArray>] args: ResizeArray<obj option> -> unit
        abstract pipeDest: dest: obj option -> unit
        abstract qs: q: obj * ?clobber: bool -> Request
        abstract form: unit -> FormData.FormData<'a>
        abstract form: form: obj option -> Request
        abstract multipart: multipart: ResizeArray<RequestPart> -> Request
        abstract json: ``val``: obj option -> Request
        abstract aws: opts: AWSOptions * ?now: bool -> Request
        abstract hawk: opts: HawkOptions -> unit
        abstract auth: username: string * password: string * ?sendImmediately: bool * ?bearer: string -> Request
        abstract oauth: oauth: OAuthOptions -> Request
        abstract jar: jar: CookieJar -> Request
        abstract on: ``event``: string * listener: (ResizeArray<obj option> -> unit) -> Request
        [<Emit "$0.on('request',$1)">] abstract on_request: listener: (Http.ClientRequest<'a> -> unit) -> Request
        [<Emit "$0.on('response',$1)">] abstract on_response: listener: (Response -> unit) -> Request
        [<Emit "$0.on('data',$1)">] abstract on_data: listener: (U2<Buffer, string> -> unit) -> Request
        [<Emit "$0.on('error',$1)">] abstract on_error: listener: (Error -> unit) -> Request
        [<Emit "$0.on('complete',$1)">] abstract on_complete: listener: (Response -> U2<string, Buffer> -> unit) -> Request
        [<Emit "$0.on('pipe',$1)">] abstract on_pipe: listener: (Stream.Readable<'a> -> unit) -> Request
        [<Emit "$0.on('socket',$1)">] abstract on_socket: listener: (Net.Socket -> unit) -> Request
        abstract write: buffer: U2<Buffer, string> * ?cb: (Error -> unit) -> bool
        abstract write: str: string * ?encoding: string * ?cb: (Error -> unit) -> bool
        abstract ``end``: ?cb: (unit -> unit) -> unit
        abstract ``end``: chunk: U2<string, Buffer> * ?cb: (unit -> unit) -> unit
        abstract ``end``: str: string * ?encoding: string * ?cb: (unit -> unit) -> unit
        abstract pause: unit -> unit
        abstract resume: unit -> unit
        abstract abort: unit -> unit
        abstract destroy: unit -> unit
        abstract toJSON: unit -> RequestAsJSON
        abstract host: string option with get, set
        abstract port: float option with get, set
        abstract followAllRedirects: bool option with get, set
        abstract followOriginalHttpMethod: bool option with get, set
        abstract maxRedirects: float option with get, set
        abstract removeRefererHeader: bool option with get, set
        abstract encoding: string option with get, set
        abstract timeout: float option with get, set
        abstract localAddress: string option with get, set
        abstract strictSSL: bool option with get, set
        abstract rejectUnauthorized: bool option with get, set
        abstract time: bool option with get, set
        abstract gzip: bool option with get, set
        abstract preambleCRLF: bool option with get, set
        abstract postambleCRLF: bool option with get, set
        abstract withCredentials: bool option with get, set
        abstract key: Buffer option with get, set
        abstract cert: Buffer option with get, set
        abstract passphrase: string option with get, set
        abstract ca: U4<string, Buffer, ResizeArray<string>, ResizeArray<Buffer>> option with get, set
        abstract har: HttpArchiveRequest option with get, set
        abstract headers: Headers with get, set
        abstract ``method``: string with get, set
        abstract pool: U2<obj, TypeLiteral_04> with get, set
        abstract dests: ResizeArray<Stream.Readable<'a>> with get, set
        abstract callback: RequestCallback option with get, set
        abstract uri: obj with get, set
        abstract proxy: U2<string, Url> option with get, set
        abstract tunnel: bool with get, set
        abstract setHost: bool with get, set
        abstract path: string with get, set
        abstract agent: U3<obj, Http.Agent, Https.Agent> with get, set
        abstract body: U5<Buffer, ResizeArray<Buffer>, string, ResizeArray<string>, Stream.Readable<'a>> with get, set
        abstract timing: bool option with get, set
        abstract src: Stream.Readable<'a> option with get, set
        abstract href: string with get, set
        abstract startTime: float option with get, set
        abstract startTimeNow: float option with get, set
        abstract timings: TypeLiteral_05 option with get, set
        abstract elapsedTime: float option with get, set
        abstract response: Response option with get, set

    type [<AllowNullLiteral>] Response =
        inherit Http.IncomingMessage
        abstract statusCode: float with get, set
        abstract statusMessage: string with get, set
        abstract request: Request with get, set
        abstract body: obj option with get, set
        abstract caseless: Caseless.Caseless with get, set
        abstract toJSON: unit -> ResponseAsJSON
        abstract timingStart: float option with get, set
        abstract elapsedTime: float option with get, set
        abstract timings: TypeLiteral_05 option with get, set
        abstract timingPhases: TypeLiteral_06 option with get, set

    type ResponseRequest =
        Request

    type RequestResponse =
        Response

    type [<AllowNullLiteral>] Headers =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] AuthOptions =
        abstract user: string option with get, set
        abstract username: string option with get, set
        abstract pass: string option with get, set
        abstract password: string option with get, set
        abstract sendImmediately: bool option with get, set
        abstract bearer: U2<string, (unit -> string)> option with get, set

    type [<AllowNullLiteral>] OAuthOptions =
        abstract callback: string option with get, set
        abstract consumer_key: string option with get, set
        abstract consumer_secret: string option with get, set
        abstract token: string option with get, set
        abstract token_secret: string option with get, set
        abstract transport_method: U3<string, string, string> option with get, set
        abstract verifier: string option with get, set
        abstract body_hash: U2<obj, string> option with get, set

    type [<AllowNullLiteral>] HawkOptions =
        abstract credentials: obj option with get, set

    type [<AllowNullLiteral>] AWSOptions =
        abstract secret: string with get, set
        abstract bucket: string option with get, set

    type [<AllowNullLiteral>] RequestAsJSON =
        abstract uri: Url with get, set
        abstract ``method``: string with get, set
        abstract headers: Headers with get, set

    type [<AllowNullLiteral>] ResponseAsJSON =
        abstract statusCode: float with get, set
        abstract body: obj option with get, set
        abstract headers: Headers with get, set
        abstract request: RequestAsJSON with get, set

    type Cookie =
        ToughCookie.Cookie

    type [<AllowNullLiteral>] CookieJar =
        abstract setCookie: cookieOrStr: U2<Cookie, string> * uri: U2<string, Url> * ?options: ToughCookie.CookieJar.SetCookieOptions -> unit
        abstract getCookieString: uri: U2<string, Url> -> string
        abstract getCookies: uri: U2<string, Url> -> ResizeArray<Cookie>

    type [<AllowNullLiteral>] TypeLiteral_03 =
        abstract ``content-type``: string option with get, set
        abstract body: string with get, set

    type [<AllowNullLiteral>] TypeLiteral_02 =
        abstract mimeType: string option with get, set
        abstract ``params``: ResizeArray<NameValuePair> option with get, set

    type [<AllowNullLiteral>] TypeLiteral_05 =
        abstract socket: float with get, set
        abstract lookup: float with get, set
        abstract connect: float with get, set
        abstract response: float with get, set
        abstract ``end``: float with get, set

    type [<AllowNullLiteral>] TypeLiteral_06 =
        abstract wait: float with get, set
        abstract dns: float with get, set
        abstract tcp: float with get, set
        abstract firstByte: float with get, set
        abstract download: float with get, set
        abstract total: float with get, set

    type [<AllowNullLiteral>] TypeLiteral_04 =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> U2<Http.Agent, Https.Agent> with get, set

    type [<AllowNullLiteral>] TypeLiteral_01 =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set
