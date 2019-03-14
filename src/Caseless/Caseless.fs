// ts2fable 0.0.0
module rec Fable.Import.Caseless

open Fable.Core

//let [<Import("*","caseless")>] caseless: Caseless.IExports = jsNative

type [<AllowNullLiteral>] IExports =
    abstract caseless: ?dict: RawDict -> Caseless.Caseless

type KeyType =
    string

type ValueType =
    obj option

type RawDict =
    obj

module Caseless =

    type [<AllowNullLiteral>] IExports =
        abstract httpify: resp: obj * headers: RawDict -> Caseless

    type [<AllowNullLiteral>] Caseless =
        abstract set: name: KeyType * value: ValueType * ?clobber: bool -> U2<KeyType, obj>
        abstract set: dict: RawDict -> unit
        abstract has: name: KeyType -> U2<KeyType, obj>
        abstract get: name: KeyType -> ValueType option
        abstract swap: name: KeyType -> unit
        abstract del: name: KeyType -> bool

    type [<AllowNullLiteral>] Httpified =
        abstract headers: RawDict with get, set
        abstract setHeader: name: KeyType * value: ValueType * ?clobber: bool -> U2<KeyType, obj>
        abstract setHeader: dict: RawDict -> unit
        abstract hasHeader: name: KeyType -> U2<KeyType, obj>
        abstract getHeader: name: KeyType -> ValueType option
        abstract removeHeader: name: KeyType -> bool
