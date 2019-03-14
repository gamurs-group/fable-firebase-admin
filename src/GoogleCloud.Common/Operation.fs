namespace rec Fable.Import.GoogleCloud.Common

open Fable.Core
open Fable.Import.JS

type Operation =
    Operation<obj>

type [<AllowNullLiteral>] Operation<'T> =
    inherit ServiceObject<'T>
    abstract completeListeners: float with get, set
    abstract hasActiveListeners: bool with get, set
    /// Wraps the `complete` and `error` events in a Promise.
    abstract promise: unit -> Promise<Operation.TypeLiteral_01>
    /// Begin listening for events on the operation. This method keeps track of how
    /// many "complete" listeners are registered and removed, making sure polling
    /// is handled automatically.
    ///
    /// As long as there is one active "complete" listener, the connection is open.
    /// When there are no more listeners, the polling stops.
    abstract listenForEvents_: unit -> unit
    /// Poll for a status update. Returns null for an incomplete
    /// status, and metadata for a complete status.
    abstract poll_: callback: MetadataCallback -> unit
    /// Poll `getMetadata` to check the operation's status. This runs a loop to
    /// ping the API on an interval.
    ///
    /// Note: This method is automatically called once a "complete" event handler
    /// is registered on the operation.
    abstract startPolling_: unit -> Promise<unit>

type [<AllowNullLiteral>] OperationStatic =
    /// <summary>An Operation object allows you to interact with APIs that take longer to
    /// process things.</summary>
    /// <param name="config">- Configuration object.</param>
    [<Emit "new $0($1...)">] abstract Create: config: ServiceObjectConfig -> Operation<'T>

/// Types that need extra qualification
[<RequireQualifiedAccess>]
module Operation =
    type [<AllowNullLiteral>] IExports =
        abstract Operation: OperationStatic

    type [<AllowNullLiteral>] TypeLiteral_01 =
        interface end
