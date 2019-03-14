// ts2fable 0.0.0
module rec Fable.Import.FormData

open Fable.Core
open Fable.Import.Node
open Fable.Import.JS

//let [<Import("*","form-data")>] formData: FormData.IExports = jsNative

type [<AllowNullLiteral>] IExports =
    abstract FormData: FormDataStatic

type [<AllowNullLiteral>] FormData<'a> =
    inherit Stream.Readable<'a>
    abstract append: key: string * value: obj option * ?options: U2<FormData.AppendOptions, string> -> unit
    abstract getHeaders: unit -> FormData.Headers
    abstract submit: ``params``: U2<string, FormData.SubmitOptions> * ?callback: (Error option -> Http.IncomingMessage -> unit) -> Http.ClientRequest<'a>
    abstract getBoundary: unit -> string
    abstract getLength: callback: (Error option -> float -> unit) -> unit
    abstract getLengthSync: unit -> float
    abstract hasKnownLength: unit -> bool

type [<AllowNullLiteral>] FormDataStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> FormData<'a>

module FormData =

    type [<AllowNullLiteral>] Headers =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] AppendOptions =
        abstract header: U2<string, Headers> option with get, set
        abstract knownLength: float option with get, set
        abstract filename: string option with get, set
        abstract filepath: string option with get, set
        abstract contentType: string option with get, set

    type [<AllowNullLiteral>] SubmitOptions =
        inherit Http.RequestOptions
        abstract protocol: U2<string, string> option with get, set
