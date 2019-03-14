// ts2fable 0.0.0
module rec Fable.Import.Duplexify

open Fable.Core
open Fable.Import.Node

module Globals =
    let [<Import("*","duplexify")>] duplexify: DuplexifyConstructor = jsNative

type [<AllowNullLiteral>] IExports =
    abstract DuplexifyConstructor: DuplexifyConstructorStatic

type [<AllowNullLiteral>] DuplexifyConstructor =
    [<Emit "$0($1...)">] abstract Invoke: ?writable: Stream.Writable<'a> * ?readable: Stream.Readable<'b> * ?streamOptions: Stream.DuplexOptions<'a> -> Duplexify.Duplexify<'a, 'b>
    abstract obj: ?writable: Stream.Writable<'a> * ?readable: Stream.Readable<'b> * ?streamOptions: Stream.DuplexOptions<'a> -> Duplexify.Duplexify<'a, 'b>

type [<AllowNullLiteral>] DuplexifyConstructorStatic =
    [<Emit "new $0($1...)">] abstract Create: ?writable: Stream.Writable<'a> * ?readable: Stream.Readable<'b> * ?streamOptions: Stream.DuplexOptions<'a> -> DuplexifyConstructor

module Duplexify =

    type [<AllowNullLiteral>] Duplexify<'a, 'b> =
        inherit Stream.Duplex<'a, 'b>
        abstract cork: unit -> unit
        abstract uncork: unit -> unit
        abstract setWritable: writable: Stream.Writable<'a> -> unit
        abstract setReadable: readable: Stream.Readable<'b> -> unit
