// ts2fable 0.0.0
module rec Fable.Import.ToughCookie

open System
open Fable.Core
open Fable.Import.JS


type [<AllowNullLiteral>] IExports =
    /// Parse a cookie date string into a Date.
    /// Parses according to RFC6265 Section 5.1.1, not Date.parse().
    abstract parseDate: string: string -> DateTime
    /// Format a Date into a RFC1123 string (the RFC6265-recommended format).
    abstract formatDate: date: DateTime -> string
    /// Transforms a domain-name into a canonical domain-name.
    /// The canonical domain-name is a trimmed, lowercased, stripped-of-leading-dot
    /// and optionally punycode-encoded domain-name (Section 5.1.2 of RFC6265).
    /// For the most part, this function is idempotent (can be run again on its output without ill effects).
    abstract canonicalDomain: str: string -> string
    /// Answers "does this real domain match the domain in a cookie?".
    /// The str is the "current" domain-name and the domStr is the "cookie" domain-name.
    /// Matches according to RFC6265 Section 5.1.3, but it helps to think of it as a "suffix match".
    ///
    /// The canonicalize parameter will run the other two parameters through canonicalDomain or not.
    abstract domainMatch: str: string * domStr: string * ?canonicalize: bool -> bool
    /// Given a current request/response path, gives the Path apropriate for storing in a cookie.
    /// This is basically the "directory" of a "file" in the path, but is specified by Section 5.1.4 of the RFC.
    ///
    /// The path parameter MUST be only the pathname part of a URI (i.e. excludes the hostname, query, fragment, etc.).
    /// This is the .pathname property of node's uri.parse() output.
    abstract defaultPath: path: string -> string
    /// Answers "does the request-path path-match a given cookie-path?" as per RFC6265 Section 5.1.4.
    /// Returns a boolean.
    ///
    /// This is essentially a prefix-match where cookiePath is a prefix of reqPath.
    abstract pathMatch: reqPath: string * cookiePath: string -> bool
    /// alias for Cookie.fromJSON(string)
    abstract fromJSON: string: string -> Cookie
    abstract getPublicSuffix: hostname: string -> string option
    abstract cookieCompare: a: Cookie * b: Cookie -> float
    abstract permuteDomain: domain: string -> ResizeArray<string>
    abstract permutePath: path: string -> ResizeArray<string>
    abstract Cookie: CookieStatic
    abstract CookieJar: CookieJarStatic
    abstract Store: StoreStatic
    abstract MemoryCookieStore: MemoryCookieStoreStatic

type [<AllowNullLiteral>] Cookie =
    abstract key: string with get, set
    abstract value: string with get, set
    abstract expires: U2<DateTime, string> with get, set
    abstract maxAge: U3<float, string, string> with get, set
    abstract domain: string option with get, set
    abstract path: string option with get, set
    abstract secure: bool with get, set
    abstract httpOnly: bool with get, set
    abstract extensions: ResizeArray<string> option with get, set
    abstract creation: DateTime option with get, set
    abstract creationIndex: float with get, set
    abstract hostOnly: bool option with get, set
    abstract pathIsDefault: bool option with get, set
    abstract lastAccessed: DateTime option with get, set
    abstract toString: unit -> string
    abstract cookieString: unit -> string
    abstract setExpires: String: string -> unit
    abstract setMaxAge: number: float -> unit
    abstract expiryTime: ?now: float -> U2<float, obj>
    abstract expiryDate: ?now: float -> DateTime
    abstract TTL: ?now: DateTime -> U2<float, obj>
    abstract canonicalizedDomain: unit -> string
    abstract cdomain: unit -> string
    abstract toJSON: unit -> CookieToJSONReturn
    abstract clone: unit -> Cookie
    abstract validate: unit -> U2<bool, string>

type [<AllowNullLiteral>] CookieToJSONReturn =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

type [<AllowNullLiteral>] CookieStatic =
    abstract parse: cookieString: string * ?options: Cookie.ParseOptions -> Cookie option
    abstract fromJSON: strOrObj: U2<string, obj> -> Cookie option
    [<Emit "new $0($1...)">] abstract Create: ?properties: Cookie.Properties -> Cookie

module Cookie =

    type [<AllowNullLiteral>] ParseOptions =
        abstract loose: bool option with get, set

    type [<AllowNullLiteral>] Properties =
        abstract key: string option with get, set
        abstract value: string option with get, set
        abstract expires: DateTime option with get, set
        abstract maxAge: U3<float, string, string> option with get, set
        abstract domain: string option with get, set
        abstract path: string option with get, set
        abstract secure: bool option with get, set
        abstract httpOnly: bool option with get, set
        abstract extensions: ResizeArray<string> option with get, set
        abstract creation: DateTime option with get, set
        abstract creationIndex: float option with get, set
        abstract hostOnly: bool option with get, set
        abstract pathIsDefault: bool option with get, set
        abstract lastAccessed: DateTime option with get, set

    type [<AllowNullLiteral>] Serialized =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

type [<AllowNullLiteral>] CookieJar =
    abstract setCookie: cookieOrString: U2<Cookie, string> * currentUrl: string * options: CookieJar.SetCookieOptions * cb: (Error option -> Cookie -> unit) -> unit
    abstract setCookie: cookieOrString: U2<Cookie, string> * currentUrl: string * cb: (Error -> Cookie -> unit) -> unit
    abstract setCookieSync: cookieOrString: U2<Cookie, string> * currentUrl: string * ?options: CookieJar.SetCookieOptions -> unit
    abstract getCookies: currentUrl: string * options: CookieJar.GetCookiesOptions * cb: (Error option -> ResizeArray<Cookie> -> unit) -> unit
    abstract getCookies: currentUrl: string * cb: (Error option -> ResizeArray<Cookie> -> unit) -> unit
    abstract getCookiesSync: currentUrl: string * ?options: CookieJar.GetCookiesOptions -> ResizeArray<Cookie>
    abstract getCookieString: currentUrl: string * options: CookieJar.GetCookiesOptions * cb: (Error option -> string -> unit) -> unit
    abstract getCookieString: currentUrl: string * cb: (Error option -> string -> unit) -> unit
    abstract getCookieStringSync: currentUrl: string * ?options: CookieJar.GetCookiesOptions -> string
    abstract getSetCookieStrings: currentUrl: string * options: CookieJar.GetCookiesOptions * cb: (Error option -> string -> unit) -> unit
    abstract getSetCookieStrings: currentUrl: string * cb: (Error option -> string -> unit) -> unit
    abstract getSetCookieStringsSync: currentUrl: string * ?options: CookieJar.GetCookiesOptions -> string
    abstract serialize: cb: (Error option -> CookieJar.Serialized -> unit) -> unit
    abstract serializeSync: unit -> CookieJar.Serialized
    abstract toJSON: unit -> CookieJar.Serialized
    abstract clone: store: Store * cb: (Error option -> CookieJar -> unit) -> unit
    abstract clone: cb: (Error option -> CookieJar -> unit) -> unit
    abstract cloneSync: store: Store -> CookieJar

type [<AllowNullLiteral>] CookieJarStatic =
    abstract deserialize: serialized: U2<CookieJar.Serialized, string> * store: Store * cb: (Error option -> CookieJar -> unit) -> unit
    abstract deserialize: serialized: U2<CookieJar.Serialized, string> * cb: (Error option -> CookieJar -> unit) -> unit
    abstract deserializeSync: serialized: U2<CookieJar.Serialized, string> * ?store: Store -> CookieJar
    abstract fromJSON: string: string -> CookieJar
    [<Emit "new $0($1...)">] abstract Create: ?store: Store * ?options: CookieJar.Options -> CookieJar

module CookieJar =

    type [<AllowNullLiteral>] Options =
        abstract rejectPublicSuffixes: bool option with get, set
        abstract looseMode: bool option with get, set

    type [<AllowNullLiteral>] SetCookieOptions =
        abstract http: bool option with get, set
        abstract secure: bool option with get, set
        abstract now: DateTime option with get, set
        abstract ignoreError: bool option with get, set

    type [<AllowNullLiteral>] GetCookiesOptions =
        abstract http: bool option with get, set
        abstract secure: bool option with get, set
        abstract date: DateTime option with get, set
        abstract expire: bool option with get, set
        abstract allPoints: bool option with get, set

    type [<AllowNullLiteral>] Serialized =
        abstract version: string with get, set
        abstract storeType: string with get, set
        abstract rejectPublicSuffixes: bool with get, set
        abstract cookies: ResizeArray<Cookie.Serialized> with get, set

type [<AllowNullLiteral>] Store =
    abstract findCookie: domain: string * path: string * key: string * cb: (Error option -> Cookie option -> unit) -> unit
    abstract findCookies: domain: string * path: string * cb: (Error option -> ResizeArray<Cookie> -> unit) -> unit
    abstract putCookie: cookie: Cookie * cb: (Error option -> unit) -> unit
    abstract updateCookie: oldCookie: Cookie * newCookie: Cookie * cb: (Error option -> unit) -> unit
    abstract removeCookie: domain: string * path: string * key: string * cb: (Error option -> unit) -> unit
    abstract removeCookies: domain: string * path: string * cb: (Error option -> unit) -> unit
    abstract getAllCookies: cb: (Error option -> ResizeArray<Cookie> -> unit) -> unit

type [<AllowNullLiteral>] StoreStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> Store

type [<AllowNullLiteral>] MemoryCookieStore =
    inherit Store

type [<AllowNullLiteral>] MemoryCookieStoreStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> MemoryCookieStore
