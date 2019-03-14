namespace rec Fable.Import.GoogleCloud.Storage

open Fable.Core

[<RequireQualifiedAccess>]
module Util =
    type [<AllowNullLiteral>] IExports =
        abstract normalize: ?optionsOrCallback: U2<'T, 'U> * ?cb: 'U -> NormalizeReturn

type [<AllowNullLiteral>] NormalizeReturn =
    abstract options: 'T with get, set
    abstract callback: 'U with get, set
