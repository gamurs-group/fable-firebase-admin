/// Fable bindings for the 'firebase-admin' npm package.
namespace rec Fable.FirebaseAdmin

open System
open Fable.Core
open Fable.Import.JS
open Fable.Import.GoogleCloud.Storage

module Globals =
    /// Global import for the 'firebase-admin' module
    let [<Import("*","firebase-admin")>] admin: FirebaseAdmin.IExports = jsNative

module FirebaseAdmin =

//    let [<Import("credential","src/admin")>] credential: Credential.IExports = jsNative
//    let [<Import("database","src/admin")>] database: Database.IExports = jsNative

    type Agent = Fable.Import.Node.Http.Agent

    type [<AllowNullLiteral>] IExports =
        abstract SDK_VERSION: string
        abstract apps: ResizeArray<FirebaseAdmin.App.App option>
        abstract app: ?name: string -> FirebaseAdmin.App.App
        abstract auth: ?app: FirebaseAdmin.App.App -> FirebaseAdmin.Auth.Auth
        abstract credential: FirebaseAdmin.Credential.IExports
        abstract database: ?app: FirebaseAdmin.App.App -> FirebaseAdmin.Database.Database
        abstract messaging: ?app: FirebaseAdmin.App.App -> FirebaseAdmin.Messaging.Messaging
        abstract storage: ?app: FirebaseAdmin.App.App -> FirebaseAdmin.Storage.Storage
        abstract firestore: ?app: FirebaseAdmin.App.App -> FirebaseAdmin.Firestore.Firestore
        abstract instanceId: ?app: FirebaseAdmin.App.App -> FirebaseAdmin.InstanceId.InstanceId
        abstract projectManagement: ?app: FirebaseAdmin.App.App -> FirebaseAdmin.ProjectManagement.ProjectManagement
        abstract initializeApp: ?options: FirebaseAdmin.AppOptions * ?name: string -> FirebaseAdmin.App.App

    type [<AllowNullLiteral>] FirebaseError =
        abstract code: string with get, set
        abstract message: string with get, set
        abstract stack: string with get, set
        abstract toJSON: unit -> Object

    type [<AllowNullLiteral>] FirebaseArrayIndexError =
        abstract index: float with get, set
        abstract error: FirebaseError with get, set

    type [<AllowNullLiteral>] ServiceAccount =
        abstract projectId: string option with get, set
        abstract clientEmail: string option with get, set
        abstract privateKey: string option with get, set

    type [<AllowNullLiteral>] GoogleOAuthAccessToken =
        abstract access_token: string with get, set
        abstract expires_in: float with get, set

    type [<AllowNullLiteral>] AppOptions =
        abstract credential: FirebaseAdmin.Credential.Credential option with get, set
        abstract databaseAuthVariableOverride: Object option with get, set
        abstract databaseURL: string option with get, set
        abstract serviceAccountId: string option with get, set
        abstract storageBucket: string option with get, set
        abstract projectId: string option with get, set
        abstract httpAgent: Agent option with get, set

    module App =

        type [<AllowNullLiteral>] App =
            abstract name: string with get, set
            abstract options: FirebaseAdmin.AppOptions with get, set
            abstract auth: unit -> FirebaseAdmin.Auth.Auth
            abstract database: ?url: string -> FirebaseAdmin.Database.Database
//            abstract firestore: unit -> FirebaseAdmin.Firestore.Firestore
            abstract instanceId: unit -> FirebaseAdmin.InstanceId.InstanceId
            abstract messaging: unit -> FirebaseAdmin.Messaging.Messaging
            abstract projectManagement: unit -> FirebaseAdmin.ProjectManagement.ProjectManagement
            abstract storage: unit -> FirebaseAdmin.Storage.Storage
            abstract delete: unit -> Promise<unit>

    module Auth =

        type [<AllowNullLiteral>] UserMetadata =
            abstract lastSignInTime: string with get, set
            abstract creationTime: string with get, set
            abstract toJSON: unit -> Object

        type [<AllowNullLiteral>] UserInfo =
            abstract uid: string with get, set
            abstract displayName: string with get, set
            abstract email: string with get, set
            abstract phoneNumber: string with get, set
            abstract photoURL: string with get, set
            abstract providerId: string with get, set
            abstract toJSON: unit -> Object

        type [<AllowNullLiteral>] UserRecord =
            abstract uid: string with get, set
            abstract email: string option with get, set
            abstract emailVerified: bool with get, set
            abstract displayName: string option with get, set
            abstract phoneNumber: string option with get, set
            abstract photoURL: string option with get, set
            abstract disabled: bool with get, set
            abstract metadata: FirebaseAdmin.Auth.UserMetadata with get, set
            abstract providerData: ResizeArray<FirebaseAdmin.Auth.UserInfo> with get, set
            abstract passwordHash: string option with get, set
            abstract passwordSalt: string option with get, set
            abstract customClaims: Object option with get, set
            abstract tokensValidAfterTime: string option with get, set
            abstract toJSON: unit -> Object

        type [<AllowNullLiteral>] UpdateRequest =
            abstract disabled: bool option with get, set
            abstract displayName: string option with get, set
            abstract email: string option with get, set
            abstract emailVerified: bool option with get, set
            abstract password: string option with get, set
            abstract phoneNumber: string option with get, set
            abstract photoURL: string option with get, set

        type [<AllowNullLiteral>] CreateRequest =
            inherit UpdateRequest
            abstract uid: string option with get, set

        type [<AllowNullLiteral>] DecodedIdToken =
            abstract aud: string with get, set
            abstract auth_time: float with get, set
            abstract exp: float with get, set
            abstract firebase: TypeLiteral_02 with get, set
            abstract iat: float with get, set
            abstract iss: string with get, set
            abstract sub: string with get, set
            abstract uid: string with get, set
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] ListUsersResult =
            abstract users: ResizeArray<FirebaseAdmin.Auth.UserRecord> with get, set
            abstract pageToken: string option with get, set

        type [<StringEnum>] [<RequireQualifiedAccess>] HashAlgorithmType =
            | [<CompiledName "SCRYPT">] SCRYPT
            | [<CompiledName "STANDARD_SCRYPT">] STANDARD_SCRYPT
            | [<CompiledName "HMAC_SHA512">] HMAC_SHA512
            | [<CompiledName "HMAC_SHA256">] HMAC_SHA256
            | [<CompiledName "HMAC_SHA1">] HMAC_SHA1
            | [<CompiledName "HMAC_MD5">] HMAC_MD5
            | [<CompiledName "MD5">] MD5
            | [<CompiledName "PBKDF_SHA1">] PBKDF_SHA1
            | [<CompiledName "BCRYPT">] BCRYPT
            | [<CompiledName "PBKDF2_SHA256">] PBKDF2_SHA256
            | [<CompiledName "SHA512">] SHA512
            | [<CompiledName "SHA256">] SHA256
            | [<CompiledName "SHA1">] SHA1

        type [<AllowNullLiteral>] UserImportOptions =
            abstract hash: TypeLiteral_03 with get, set

        type [<AllowNullLiteral>] UserImportResult =
            abstract failureCount: float with get, set
            abstract successCount: float with get, set
            abstract errors: ResizeArray<FirebaseAdmin.FirebaseArrayIndexError> with get, set

        type [<AllowNullLiteral>] UserImportRecord =
            abstract uid: string with get, set
            abstract email: string option with get, set
            abstract emailVerified: bool option with get, set
            abstract displayName: string option with get, set
            abstract phoneNumber: string option with get, set
            abstract photoURL: string option with get, set
            abstract disabled: bool option with get, set
            abstract metadata: TypeLiteral_04 option with get, set
            abstract providerData: ResizeArray<TypeLiteral_05> option with get, set
            abstract customClaims: Object option with get, set
            abstract passwordHash: Buffer option with get, set
            abstract passwordSalt: Buffer option with get, set

        type [<AllowNullLiteral>] SessionCookieOptions =
            abstract expiresIn: float with get, set

        type [<AllowNullLiteral>] ActionCodeSettings =
            abstract url: string with get, set
            abstract handleCodeInApp: bool option with get, set
            abstract iOS: TypeLiteral_06 option with get, set
            abstract android: TypeLiteral_07 option with get, set
            abstract dynamicLinkDomain: string option with get, set

        type [<AllowNullLiteral>] BaseAuth =
            abstract createCustomToken: uid: string * ?developerClaims: Object -> Promise<string>
            abstract createUser: properties: FirebaseAdmin.Auth.CreateRequest -> Promise<FirebaseAdmin.Auth.UserRecord>
            abstract deleteUser: uid: string -> Promise<unit>
            abstract getUser: uid: string -> Promise<FirebaseAdmin.Auth.UserRecord>
            abstract getUserByEmail: email: string -> Promise<FirebaseAdmin.Auth.UserRecord>
            abstract getUserByPhoneNumber: phoneNumber: string -> Promise<FirebaseAdmin.Auth.UserRecord>
            abstract listUsers: ?maxResults: float * ?pageToken: string -> Promise<FirebaseAdmin.Auth.ListUsersResult>
            abstract updateUser: uid: string * properties: FirebaseAdmin.Auth.UpdateRequest -> Promise<FirebaseAdmin.Auth.UserRecord>
            abstract verifyIdToken: idToken: string * ?checkRevoked: bool -> Promise<FirebaseAdmin.Auth.DecodedIdToken>
            abstract setCustomUserClaims: uid: string * customUserClaims: Object -> Promise<unit>
            abstract revokeRefreshTokens: uid: string -> Promise<unit>
            abstract importUsers: users: ResizeArray<FirebaseAdmin.Auth.UserImportRecord> * ?options: FirebaseAdmin.Auth.UserImportOptions -> Promise<FirebaseAdmin.Auth.UserImportResult>
            abstract createSessionCookie: idToken: string * sessionCookieOptions: FirebaseAdmin.Auth.SessionCookieOptions -> Promise<string>
            abstract verifySessionCookie: sessionCookie: string * ?checkForRevocation: bool -> Promise<FirebaseAdmin.Auth.DecodedIdToken>
            abstract generatePasswordResetLink: email: string * ?actionCodeSettings: FirebaseAdmin.Auth.ActionCodeSettings -> Promise<string>
            abstract generateEmailVerificationLink: email: string * ?actionCodeSettings: FirebaseAdmin.Auth.ActionCodeSettings -> Promise<string>
            abstract generateSignInWithEmailLink: email: string * actionCodeSettings: FirebaseAdmin.Auth.ActionCodeSettings -> Promise<string>

        type [<AllowNullLiteral>] Auth =
            inherit FirebaseAdmin.Auth.BaseAuth
            abstract app: FirebaseAdmin.App.App with get, set

        type [<AllowNullLiteral>] TypeLiteral_03 =
            abstract algorithm: HashAlgorithmType with get, set
            abstract key: Buffer option with get, set
            abstract saltSeparator: string option with get, set
            abstract rounds: float option with get, set
            abstract memoryCost: float option with get, set
            abstract parallelization: float option with get, set
            abstract blockSize: float option with get, set
            abstract derivedKeyLength: float option with get, set

        type [<AllowNullLiteral>] TypeLiteral_06 =
            abstract bundleId: string with get, set

        type [<AllowNullLiteral>] TypeLiteral_02 =
            abstract identities: TypeLiteral_01 with get, set
            abstract sign_in_provider: string with get, set
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] TypeLiteral_04 =
            abstract lastSignInTime: string option with get, set
            abstract creationTime: string option with get, set

        type [<AllowNullLiteral>] TypeLiteral_07 =
            abstract packageName: string with get, set
            abstract installApp: bool option with get, set
            abstract minimumVersion: string option with get, set

        type [<AllowNullLiteral>] TypeLiteral_05 =
            abstract uid: string with get, set
            abstract displayName: string option with get, set
            abstract email: string option with get, set
            abstract photoURL: string option with get, set
            abstract providerId: string with get, set

        type [<AllowNullLiteral>] TypeLiteral_01 =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    module Credential =

        type [<AllowNullLiteral>] IExports =
            abstract applicationDefault: ?httpAgent: Agent -> FirebaseAdmin.Credential.Credential
            abstract cert: serviceAccountPathOrObject: U2<string, FirebaseAdmin.ServiceAccount> * ?httpAgent: Agent -> FirebaseAdmin.Credential.Credential
            abstract refreshToken: refreshTokenPathOrObject: U2<string, Object> * ?httpAgent: Agent -> FirebaseAdmin.Credential.Credential

        type [<AllowNullLiteral>] Credential =
            abstract getAccessToken: unit -> Promise<FirebaseAdmin.GoogleOAuthAccessToken>

    module Database =
//        let [<Import("ServerValue","src/admin/database")>] serverValue: ServerValue.IExports = jsNative

        type [<AllowNullLiteral>] IExports =
            abstract enableLogging: ?logger: U2<bool, (string -> obj option)> * ?persistent: bool -> obj option

        type [<AllowNullLiteral>] Database =
            abstract app: FirebaseAdmin.App.App with get, set
            abstract goOffline: unit -> unit
            abstract goOnline: unit -> unit
            abstract ref: ?path: U2<string, FirebaseAdmin.Database.Reference> -> FirebaseAdmin.Database.Reference
            abstract refFromURL: url: string -> FirebaseAdmin.Database.Reference

        type [<AllowNullLiteral>] DataSnapshot =
            abstract key: string option with get, set
            abstract ref: FirebaseAdmin.Database.Reference with get, set
            abstract child: path: string -> FirebaseAdmin.Database.DataSnapshot
            abstract exists: unit -> bool
            abstract exportVal: unit -> obj option
            abstract forEach: action: (FirebaseAdmin.Database.DataSnapshot -> U2<bool, unit>) -> bool
            abstract getPriority: unit -> U2<string, float> option
            abstract hasChild: path: string -> bool
            abstract hasChildren: unit -> bool
            abstract numChildren: unit -> float
            abstract toJSON: unit -> Object option
            abstract ``val``: unit -> obj option

        type [<AllowNullLiteral>] OnDisconnect =
            abstract cancel: ?onComplete: (Error option -> obj option) -> Promise<unit>
            abstract remove: ?onComplete: (Error option -> obj option) -> Promise<unit>
            abstract set: value: obj option * ?onComplete: (Error option -> obj option) -> Promise<unit>
            abstract setWithPriority: value: obj option * priority: U2<float, string> option * ?onComplete: (Error option -> obj option) -> Promise<unit>
            abstract update: values: Object * ?onComplete: (Error option -> obj option) -> Promise<unit>

        type [<StringEnum>] [<RequireQualifiedAccess>] EventType =
            | Value
            | Child_added
            | Child_changed
            | Child_moved
            | Child_removed

        type [<AllowNullLiteral>] Query =
            abstract ref: FirebaseAdmin.Database.Reference with get, set
            abstract endAt: value: U3<float, string, bool> option * ?key: string -> FirebaseAdmin.Database.Query
            abstract equalTo: value: U3<float, string, bool> option * ?key: string -> FirebaseAdmin.Database.Query
            abstract isEqual: other: FirebaseAdmin.Database.Query option -> bool
            abstract limitToFirst: limit: float -> FirebaseAdmin.Database.Query
            abstract limitToLast: limit: float -> FirebaseAdmin.Database.Query
            abstract off: ?eventType: FirebaseAdmin.Database.EventType * ?callback: (FirebaseAdmin.Database.DataSnapshot -> string -> obj option) * ?context: Object -> unit
            abstract on: eventType: FirebaseAdmin.Database.EventType * callback: (FirebaseAdmin.Database.DataSnapshot option -> string -> obj option) * ?cancelCallbackOrContext: Object * ?context: Object -> (FirebaseAdmin.Database.DataSnapshot option -> string -> obj option)
            abstract once: eventType: FirebaseAdmin.Database.EventType * ?successCallback: (FirebaseAdmin.Database.DataSnapshot -> string -> obj option) * ?failureCallbackOrContext: Object * ?context: Object -> Promise<FirebaseAdmin.Database.DataSnapshot>
            abstract orderByChild: path: string -> FirebaseAdmin.Database.Query
            abstract orderByKey: unit -> FirebaseAdmin.Database.Query
            abstract orderByPriority: unit -> FirebaseAdmin.Database.Query
            abstract orderByValue: unit -> FirebaseAdmin.Database.Query
            abstract startAt: value: U3<float, string, bool> option * ?key: string -> FirebaseAdmin.Database.Query
            abstract toJSON: unit -> Object
            abstract toString: unit -> string

        type [<AllowNullLiteral>] Reference =
            inherit FirebaseAdmin.Database.Query
            abstract key: string option with get, set
            abstract parent: FirebaseAdmin.Database.Reference option with get, set
            abstract root: FirebaseAdmin.Database.Reference with get, set
            abstract path: string with get, set
            abstract child: path: string -> FirebaseAdmin.Database.Reference
            abstract onDisconnect: unit -> FirebaseAdmin.Database.OnDisconnect
            abstract push: ?value: obj * ?onComplete: (Error option -> obj option) -> FirebaseAdmin.Database.ThenableReference
            abstract remove: ?onComplete: (Error option -> obj option) -> Promise<unit>
            abstract set: value: obj option * ?onComplete: (Error option -> obj option) -> Promise<unit>
            abstract setPriority: priority: U2<string, float> option * onComplete: (Error option -> obj option) -> Promise<unit>
            abstract setWithPriority: newVal: obj option * newPriority: U2<string, float> option * ?onComplete: (Error option -> obj option) -> Promise<unit>
            abstract transaction: transactionUpdate: (obj option -> obj option) * ?onComplete: (Error option -> bool -> FirebaseAdmin.Database.DataSnapshot option -> obj option) * ?applyLocally: bool -> Promise<TypeLiteral_08>
            abstract update: values: Object * ?onComplete: (Error option -> obj option) -> Promise<unit>

        type [<AllowNullLiteral>] ThenableReference =
            inherit FirebaseAdmin.Database.Reference
            inherit PromiseLike<obj option>

        module ServerValue =

            type [<AllowNullLiteral>] IExports =
                abstract TIMESTAMP: float

        type [<AllowNullLiteral>] TypeLiteral_08 =
            abstract committed: bool with get, set
            abstract snapshot: FirebaseAdmin.Database.DataSnapshot option with get, set

    module Firestore =

        type [<AllowNullLiteral>] DocumentData =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: field: string -> obj option with get, set

        type [<AllowNullLiteral>] UpdateData =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: fieldPath: string -> obj option with get, set

        /// Settings used to directly configure a `Firestore` instance.
        type [<AllowNullLiteral>] Settings =
            /// The project ID from the Google Developer's Console, e.g.
            /// 'grape-spaceship-123'. We will also check the environment variable
            /// GCLOUD_PROJECT for your project ID.  Can be omitted in environments that
            /// support {@link https://cloud.google.com/docs/authentication Application
            /// Default Credentials}
            abstract projectId: string option with get, set
            /// Local file containing the Service Account credentials as downloaded from
            /// the Google Developers Console. Can  be omitted in environments that
            /// support {@link https://cloud.google.com/docs/authentication Application
            /// Default Credentials}. To configure Firestore with custom credentials, use
            /// the `credentials` property to provide the `client_email` and
            /// `private_key` of your service account.
            abstract keyFilename: string option with get, set
            /// The 'client_email' and 'private_key' properties of the service account
            /// to use with your Firestore project. Can be omitted in environments that
            /// support {@link https://cloud.google.com/docs/authentication Application
            /// Default Credentials}. If your credentials are stored in a JSON file, you
            /// can specify a `keyFilename` instead.
            abstract credentials: TypeLiteral_02 option with get, set
            /// Specifies whether to use `Timestamp` objects for timestamp fields in
            /// `DocumentSnapshot`s. This is enabled by default and should not be disabled.
            ///
            /// Previously, Firestore returned timestamp fields as `Date` but `Date` only
            /// supports millisecond precision, which leads to truncation and causes
            /// unexpected behavior when using a timestamp from a snapshot as a part of a
            /// subsequent query.
            ///
            /// So now Firestore returns `Timestamp` values instead of `Date`, avoiding
            /// this kind of problem.
            ///
            /// To opt into the old behavior of returning `Date` objects, you can
            /// temporarily set `timestampsInSnapshots` to false.
            abstract timestampsInSnapshots: bool option with get, set
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        /// `Firestore` represents a Firestore Database and is the entry point for all
        /// Firestore operations.
        type [<AllowNullLiteral>] Firestore =
            /// <summary>Specifies custom settings to be used to configure the `Firestore`
            /// instance. Can only be invoked once and before any other Firestore
            /// method.
            ///
            /// If settings are provided via both `settings()` and the `Firestore`
            /// constructor, both settings objects are merged and any settings provided
            /// via `settings()` take precedence.</summary>
            /// <param name="settings">The settings to use for all Firestore
            /// operations.</param>
            abstract settings: settings: Settings -> unit
            /// <summary>Gets a `CollectionReference` instance that refers to the collection at
            /// the specified path.</summary>
            /// <param name="collectionPath">A slash-separated path to a collection.</param>
            abstract collection: collectionPath: string -> CollectionReference
            /// <summary>Gets a `DocumentReference` instance that refers to the document at the
            /// specified path.</summary>
            /// <param name="documentPath">A slash-separated path to a document.</param>
            abstract doc: documentPath: string -> DocumentReference
            /// <summary>Retrieves multiple documents from Firestore.
            ///
            /// The first argument is required and must be of type `DocumentReference`
            /// followed by any additional `DocumentReference` documents. If used, the
            /// optional `ReadOptions` must be the last argument.</summary>
            /// <param name="documentRefsOrReadOptions">The `DocumentReferences` to receive, followed by an optional field
            /// mask.</param>
            abstract getAll: [<ParamArray>] documentRefsOrReadOptions: Array<U2<DocumentReference, ReadOptions>> -> Promise<ResizeArray<DocumentSnapshot>>
            /// Fetches the root collections that are associated with this Firestore
            /// database.
            abstract getCollections: unit -> Promise<ResizeArray<CollectionReference>>
            /// Fetches the root collections that are associated with this Firestore
            /// database.
            abstract listCollections: unit -> Promise<ResizeArray<CollectionReference>>
            /// <summary>Executes the given updateFunction and commits the changes applied within
            /// the transaction.
            ///
            /// You can use the transaction object passed to 'updateFunction' to read and
            /// modify Firestore documents under lock. Transactions are committed once
            /// 'updateFunction' resolves and attempted up to five times on failure.</summary>
            /// <param name="updateFunction">The function to execute within the transaction
            /// context.</param>
            /// <param name="transactionOptions">Transaction options.</param>
            abstract runTransaction: updateFunction: (Transaction -> Promise<'T>) * ?transactionOptions: FirestoreRunTransactionTransactionOptions -> Promise<'T>
            /// Creates a write batch, used for performing multiple writes as a single
            /// atomic operation.
            abstract batch: unit -> WriteBatch

        type [<AllowNullLiteral>] FirestoreRunTransactionTransactionOptions =
            abstract maxAttempts: float option with get, set

        /// `Firestore` represents a Firestore Database and is the entry point for all
        /// Firestore operations.
        type [<AllowNullLiteral>] FirestoreStatic =
            /// <param name="settings">Configuration object. See [Firestore Documentation]
            /// {</param>
            [<Emit "new $0($1...)">] abstract Create: ?settings: Settings -> Firestore

        /// An immutable object representing a geo point in Firestore. The geo point
        /// is represented as latitude/longitude pair.
        ///
        /// Latitude values are in the range of [-90, 90].
        /// Longitude values are in the range of [-180, 180].
        type [<AllowNullLiteral>] GeoPoint =
            abstract latitude: float
            abstract longitude: float
            /// <summary>Returns true if this `GeoPoint` is equal to the provided one.</summary>
            /// <param name="other">The `GeoPoint` to compare against.</param>
            abstract isEqual: other: GeoPoint -> bool

        /// An immutable object representing a geo point in Firestore. The geo point
        /// is represented as latitude/longitude pair.
        ///
        /// Latitude values are in the range of [-90, 90].
        /// Longitude values are in the range of [-180, 180].
        type [<AllowNullLiteral>] GeoPointStatic =
            /// <summary>Creates a new immutable GeoPoint object with the provided latitude and
            /// longitude values.</summary>
            /// <param name="latitude">The latitude as number between -90 and 90.</param>
            /// <param name="longitude">The longitude as number between -180 and 180.</param>
            [<Emit "new $0($1...)">] abstract Create: latitude: float * longitude: float -> GeoPoint

        /// A reference to a transaction.
        /// The `Transaction` object passed to a transaction's updateFunction provides
        /// the methods to read and write data within the transaction context. See
        /// `Firestore.runTransaction()`.
        type [<AllowNullLiteral>] Transaction =
            /// <summary>Retrieves a query result. Holds a pessimistic lock on all returned
            /// documents.</summary>
            /// <param name="query">A query to execute.</param>
            abstract get: query: Query -> Promise<QuerySnapshot>
            /// <summary>Reads the document referenced by the provided `DocumentReference.`
            /// Holds a pessimistic lock on the returned document.</summary>
            /// <param name="documentRef">A reference to the document to be read.</param>
            abstract get: documentRef: DocumentReference -> Promise<DocumentSnapshot>
            /// <summary>Retrieves multiple documents from Firestore. Holds a pessimistic lock on
            /// all returned documents.
            ///
            /// The first argument is required and must be of type `DocumentReference`
            /// followed by any additional `DocumentReference` documents. If used, the
            /// optional `ReadOptions` must be the last argument.</summary>
            /// <param name="documentRefsOrReadOptions">The `DocumentReferences` to receive, followed by an optional field
            /// mask.</param>
            abstract getAll: [<ParamArray>] documentRefsOrReadOptions: Array<U2<DocumentReference, ReadOptions>> -> Promise<ResizeArray<DocumentSnapshot>>
            /// <summary>Create the document referred to by the provided `DocumentReference`.
            /// The operation will fail the transaction if a document exists at the
            /// specified location.</summary>
            /// <param name="documentRef">A reference to the document to be create.</param>
            /// <param name="data">The object data to serialize as the document.</param>
            abstract create: documentRef: DocumentReference * data: DocumentData -> Transaction
            /// <summary>Writes to the document referred to by the provided `DocumentReference`.
            /// If the document does not exist yet, it will be created. If you pass
            /// `SetOptions`, the provided data can be merged into the existing document.</summary>
            /// <param name="documentRef">A reference to the document to be set.</param>
            /// <param name="data">An object of the fields and values for the document.</param>
            /// <param name="options">An object to configure the set behavior.</param>
            abstract set: documentRef: DocumentReference * data: DocumentData * ?options: SetOptions -> Transaction
            /// <summary>Updates fields in the document referred to by the provided
            /// `DocumentReference`. The update will fail if applied to a document that
            /// does not exist.
            ///
            /// Nested fields can be updated by providing dot-separated field path
            /// strings.</summary>
            /// <param name="documentRef">A reference to the document to be updated.</param>
            /// <param name="data">An object containing the fields and values with which to
            /// update the document.</param>
            /// <param name="precondition">A Precondition to enforce on this update.</param>
            abstract update: documentRef: DocumentReference * data: UpdateData * ?precondition: Precondition -> Transaction
            /// <summary>Updates fields in the document referred to by the provided
            /// `DocumentReference`. The update will fail if applied to a document that
            /// does not exist.
            ///
            /// Nested fields can be updated by providing dot-separated field path
            /// strings or by providing FieldPath objects.
            ///
            /// A `Precondition` restricting this update can be specified as the last
            /// argument.</summary>
            /// <param name="documentRef">A reference to the document to be updated.</param>
            /// <param name="field">The first field to update.</param>
            /// <param name="value">The first value</param>
            /// <param name="fieldsOrPrecondition">An alternating list of field paths and values
            /// to update, optionally followed by a `Precondition` to enforce on this
            /// update.</param>
            abstract update: documentRef: DocumentReference * field: U2<string, FieldPath> * value: obj option * [<ParamArray>] fieldsOrPrecondition: ResizeArray<obj option> -> Transaction
            /// <summary>Deletes the document referred to by the provided `DocumentReference`.</summary>
            /// <param name="documentRef">A reference to the document to be deleted.</param>
            /// <param name="precondition">A Precondition to enforce for this delete.</param>
            abstract delete: documentRef: DocumentReference * ?precondition: Precondition -> Transaction

        /// A write batch, used to perform multiple writes as a single atomic unit.
        ///
        /// A `WriteBatch` object can be acquired by calling `Firestore.batch()`. It
        /// provides methods for adding writes to the write batch. None of the
        /// writes will be committed (or visible locally) until `WriteBatch.commit()`
        /// is called.
        ///
        /// Unlike transactions, write batches are persisted offline and therefore are
        /// preferable when you don't need to condition your writes on read data.
        type [<AllowNullLiteral>] WriteBatch =
            /// <summary>Create the document referred to by the provided `DocumentReference`. The
            /// operation will fail the batch if a document exists at the specified
            /// location.</summary>
            /// <param name="documentRef">A reference to the document to be created.</param>
            /// <param name="data">The object data to serialize as the document.</param>
            abstract create: documentRef: DocumentReference * data: DocumentData -> WriteBatch
            /// <summary>Write to the document referred to by the provided `DocumentReference`.
            /// If the document does not exist yet, it will be created. If you pass
            /// `SetOptions`, the provided data can be merged into the existing document.</summary>
            /// <param name="documentRef">A reference to the document to be set.</param>
            /// <param name="data">An object of the fields and values for the document.</param>
            /// <param name="options">An object to configure the set behavior.</param>
            abstract set: documentRef: DocumentReference * data: DocumentData * ?options: SetOptions -> WriteBatch
            /// <summary>Update fields of the document referred to by the provided
            /// `DocumentReference`. If the document doesn't yet exist, the update fails
            /// and the entire batch will be rejected.
            ///
            /// Nested fields can be updated by providing dot-separated field path
            /// strings.</summary>
            /// <param name="documentRef">A reference to the document to be updated.</param>
            /// <param name="data">An object containing the fields and values with which to
            /// update the document.</param>
            /// <param name="precondition">A Precondition to enforce on this update.</param>
            abstract update: documentRef: DocumentReference * data: UpdateData * ?precondition: Precondition -> WriteBatch
            /// <summary>Updates fields in the document referred to by the provided
            /// `DocumentReference`. The update will fail if applied to a document that
            /// does not exist.
            ///
            /// Nested fields can be updated by providing dot-separated field path
            /// strings or by providing FieldPath objects.
            ///
            /// A `Precondition` restricting this update can be specified as the last
            /// argument.</summary>
            /// <param name="documentRef">A reference to the document to be updated.</param>
            /// <param name="field">The first field to update.</param>
            /// <param name="value">The first value</param>
            /// <param name="fieldsOrPrecondition">An alternating list of field paths and values
            /// to update, optionally followed a `Precondition` to enforce on this update.</param>
            abstract update: documentRef: DocumentReference * field: U2<string, FieldPath> * value: obj option * [<ParamArray>] fieldsOrPrecondition: ResizeArray<obj option> -> WriteBatch
            /// <summary>Deletes the document referred to by the provided `DocumentReference`.</summary>
            /// <param name="documentRef">A reference to the document to be deleted.</param>
            /// <param name="precondition">A Precondition to enforce for this delete.</param>
            abstract delete: documentRef: DocumentReference * ?precondition: Precondition -> WriteBatch
            /// Commits all of the writes in this write batch as a single atomic unit.
            abstract commit: unit -> Promise<ResizeArray<WriteResult>>

        /// An options object that configures conditional behavior of `update()` and
        /// `delete()` calls in `DocumentReference`, `WriteBatch`, and `Transaction`.
        /// Using Preconditions, these calls can be restricted to only apply to
        /// documents that match the specified restrictions.
        type [<AllowNullLiteral>] Precondition =
            /// If set, the last update time to enforce.
            abstract lastUpdateTime: Timestamp option

        /// An options object that configures the behavior of `set()` calls in
        /// `DocumentReference`, `WriteBatch` and `Transaction`. These calls can be
        /// configured to perform granular merges instead of overwriting the target
        /// documents in their entirety.
        type [<AllowNullLiteral>] SetOptions =
            /// Changes the behavior of a set() call to only replace the values specified
            /// in its data argument. Fields omitted from the set() call remain
            /// untouched.
            abstract merge: bool option
            /// Changes the behavior of set() calls to only replace the specified field
            /// paths. Any field path that is not specified is ignored and remains
            /// untouched.
            ///
            /// It is an error to pass a SetOptions object to a set() call that is
            /// missing a value for any of the fields specified here.
            abstract mergeFields: ResizeArray<U2<string, FieldPath>> option

        /// An options object that can be used to configure the behavior of `getAll()`
        /// calls. By providing a `fieldMask`, these calls can be configured to only
        /// return a subset of fields.
        type [<AllowNullLiteral>] ReadOptions =
            /// Specifies the set of fields to return and reduces the amount of data
            /// transmitted by the backend.
            ///
            /// Adding a field mask does not filter results. Documents do not need to
            /// contain values for all the fields in the mask to be part of the result
            /// set.
            abstract fieldMask: ResizeArray<U2<string, FieldPath>> option

        /// A WriteResult wraps the write time set by the Firestore servers on `sets()`,
        /// `updates()`, and `creates()`.
        type [<AllowNullLiteral>] WriteResult =
            /// The write time as set by the Firestore servers.
            abstract writeTime: Timestamp
            /// <summary>Returns true if this `WriteResult` is equal to the provided one.</summary>
            /// <param name="other">The `WriteResult` to compare against.</param>
            abstract isEqual: other: WriteResult -> bool

        /// A `DocumentReference` refers to a document location in a Firestore database
        /// and can be used to write, read, or listen to the location. The document at
        /// the referenced location may or may not exist. A `DocumentReference` can
        /// also be used to create a `CollectionReference` to a subcollection.
        type [<AllowNullLiteral>] DocumentReference =
            /// The identifier of the document within its collection.
            abstract id: string
            /// The `Firestore` for the Firestore database (useful for performing
            /// transactions, etc.).
            abstract firestore: Firestore
            /// A reference to the Collection to which this DocumentReference belongs.
            abstract parent: CollectionReference
            /// A string representing the path of the referenced document (relative
            /// to the root of the database).
            abstract path: string
            /// <summary>Gets a `CollectionReference` instance that refers to the collection at
            /// the specified path.</summary>
            /// <param name="collectionPath">A slash-separated path to a collection.</param>
            abstract collection: collectionPath: string -> CollectionReference
            /// Fetches the subcollections that are direct children of this document.
            abstract getCollections: unit -> Promise<ResizeArray<CollectionReference>>
            /// Fetches the subcollections that are direct children of this document.
            abstract listCollections: unit -> Promise<ResizeArray<CollectionReference>>
            /// <summary>Creates a document referred to by this `DocumentReference` with the
            /// provided object values. The write fails if the document already exists</summary>
            /// <param name="data">The object data to serialize as the document.</param>
            abstract create: data: DocumentData -> Promise<WriteResult>
            /// <summary>Writes to the document referred to by this `DocumentReference`. If the
            /// document does not yet exist, it will be created. If you pass
            /// `SetOptions`, the provided data can be merged into an existing document.</summary>
            /// <param name="data">A map of the fields and values for the document.</param>
            /// <param name="options">An object to configure the set behavior.</param>
            abstract set: data: DocumentData * ?options: SetOptions -> Promise<WriteResult>
            /// <summary>Updates fields in the document referred to by this `DocumentReference`.
            /// The update will fail if applied to a document that does not exist.
            ///
            /// Nested fields can be updated by providing dot-separated field path
            /// strings.</summary>
            /// <param name="data">An object containing the fields and values with which to
            /// update the document.</param>
            /// <param name="precondition">A Precondition to enforce on this update.</param>
            abstract update: data: UpdateData * ?precondition: Precondition -> Promise<WriteResult>
            /// <summary>Updates fields in the document referred to by this `DocumentReference`.
            /// The update will fail if applied to a document that does not exist.
            ///
            /// Nested fields can be updated by providing dot-separated field path
            /// strings or by providing FieldPath objects.
            ///
            /// A `Precondition` restricting this update can be specified as the last
            /// argument.</summary>
            /// <param name="field">The first field to update.</param>
            /// <param name="value">The first value.</param>
            /// <param name="moreFieldsOrPrecondition">An alternating list of field paths and
            /// values to update, optionally followed by a `Precondition` to enforce on
            /// this update.</param>
            abstract update: field: U2<string, FieldPath> * value: obj option * [<ParamArray>] moreFieldsOrPrecondition: ResizeArray<obj option> -> Promise<WriteResult>
            /// <summary>Deletes the document referred to by this `DocumentReference`.</summary>
            /// <param name="precondition">A Precondition to enforce for this delete.</param>
            abstract delete: ?precondition: Precondition -> Promise<WriteResult>
            /// Reads the document referred to by this `DocumentReference`.
            abstract get: unit -> Promise<DocumentSnapshot>
            /// <summary>Attaches a listener for DocumentSnapshot events.</summary>
            /// <param name="onNext">A callback to be called every time a new `DocumentSnapshot`
            /// is available.</param>
            /// <param name="onError">A callback to be called if the listen fails or is
            /// cancelled. No further callbacks will occur.</param>
            abstract onSnapshot: onNext: (DocumentSnapshot -> unit) * ?onError: (Error -> unit) -> (unit -> unit)
            /// <summary>Returns true if this `DocumentReference` is equal to the provided one.</summary>
            /// <param name="other">The `DocumentReference` to compare against.</param>
            abstract isEqual: other: DocumentReference -> bool

        /// A `DocumentSnapshot` contains data read from a document in your Firestore
        /// database. The data can be extracted with `.data()` or `.get(<field>)` to
        /// get a specific field.
        ///
        /// For a `DocumentSnapshot` that points to a non-existing document, any data
        /// access will return 'undefined'. You can use the `exists` property to
        /// explicitly verify a document's existence.
        type [<AllowNullLiteral>] DocumentSnapshot =
            /// True if the document exists.
            abstract exists: bool
            /// A `DocumentReference` to the document location.
            abstract ref: DocumentReference
            /// The ID of the document for which this `DocumentSnapshot` contains data.
            abstract id: string
            /// The time the document was created. Not set for documents that don't
            /// exist.
            abstract createTime: Timestamp option
            /// The time the document was last updated (at the time the snapshot was
            /// generated). Not set for documents that don't exist.
            abstract updateTime: Timestamp option
            /// The time this snapshot was read.
            abstract readTime: Timestamp
            /// Retrieves all fields in the document as an Object. Returns 'undefined' if
            /// the document doesn't exist.
            abstract data: unit -> DocumentData option
            /// <summary>Retrieves the field specified by `fieldPath`.</summary>
            /// <param name="fieldPath">The path (e.g. 'foo' or 'foo.bar') to a specific field.</param>
            abstract get: fieldPath: U2<string, FieldPath> -> obj option
            /// <summary>Returns true if the document's data and path in this `DocumentSnapshot`
            /// is equal to the provided one.</summary>
            /// <param name="other">The `DocumentSnapshot` to compare against.</param>
            abstract isEqual: other: DocumentSnapshot -> bool

        /// A `DocumentSnapshot` contains data read from a document in your Firestore
        /// database. The data can be extracted with `.data()` or `.get(<field>)` to
        /// get a specific field.
        ///
        /// For a `DocumentSnapshot` that points to a non-existing document, any data
        /// access will return 'undefined'. You can use the `exists` property to
        /// explicitly verify a document's existence.
        type [<AllowNullLiteral>] DocumentSnapshotStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> DocumentSnapshot

        /// A `QueryDocumentSnapshot` contains data read from a document in your
        /// Firestore database as part of a query. The document is guaranteed to exist
        /// and its data can be extracted with `.data()` or `.get(<field>)` to get a
        /// specific field.
        ///
        /// A `QueryDocumentSnapshot` offers the same API surface as a
        /// `DocumentSnapshot`. Since query results contain only existing documents, the
        /// `exists` property will always be true and `data()` will never return
        /// 'undefined'.
        type [<AllowNullLiteral>] QueryDocumentSnapshot =
            inherit DocumentSnapshot
            /// The time the document was created.
            abstract createTime: Timestamp
            /// The time the document was last updated (at the time the snapshot was
            /// generated).
            abstract updateTime: Timestamp
            /// Retrieves all fields in the document as an Object.
            abstract data: unit -> DocumentData

        type [<StringEnum>] [<RequireQualifiedAccess>] OrderByDirection =
            | Desc
            | Asc

        type [<StringEnum>] [<RequireQualifiedAccess>] WhereFilterOp =
            | [<CompiledName("<")>] LessThan
            | [<CompiledName("<=")>] LessThanOrEqual
            | [<CompiledName("==")>] Equal
            | [<CompiledName(">=")>] GreaterThanOrEqual
            | [<CompiledName(">")>] GreaterThan
            | [<CompiledName "array-contains">] ArrayContains

        /// A `Query` refers to a Query which you can read or listen to. You can also
        /// construct refined `Query` objects by adding filters and ordering.
        type [<AllowNullLiteral>] Query =
            /// The `Firestore` for the Firestore database (useful for performing
            /// transactions, etc.).
            abstract firestore: Firestore
            /// <summary>Creates and returns a new Query with the additional filter that documents
            /// must contain the specified field and that its value should satisfy the
            /// relation constraint provided.
            ///
            /// This function returns a new (immutable) instance of the Query (rather
            /// than modify the existing instance) to impose the filter.</summary>
            /// <param name="fieldPath">The path to compare</param>
            /// <param name="opStr">The operation string (e.g "<", "<=", "==", ">", ">=").</param>
            /// <param name="value">The value for comparison</param>
            abstract where: fieldPath: U2<string, FieldPath> * opStr: WhereFilterOp * value: obj option -> Query
            /// <summary>Creates and returns a new Query that's additionally sorted by the
            /// specified field, optionally in descending order instead of ascending.
            ///
            /// This function returns a new (immutable) instance of the Query (rather
            /// than modify the existing instance) to impose the order.</summary>
            /// <param name="fieldPath">The field to sort by.</param>
            /// <param name="directionStr">Optional direction to sort by ('asc' or 'desc'). If
            /// not specified, order will be ascending.</param>
            abstract orderBy: fieldPath: U2<string, FieldPath> * ?directionStr: OrderByDirection -> Query
            /// <summary>Creates and returns a new Query that's additionally limited to only
            /// return up to the specified number of documents.
            ///
            /// This function returns a new (immutable) instance of the Query (rather
            /// than modify the existing instance) to impose the limit.</summary>
            /// <param name="limit">The maximum number of items to return.</param>
            abstract limit: limit: float -> Query
            /// <summary>Specifies the offset of the returned results.
            ///
            /// This function returns a new (immutable) instance of the Query (rather
            /// than modify the existing instance) to impose the offset.</summary>
            /// <param name="offset">The offset to apply to the Query results.</param>
            abstract offset: offset: float -> Query
            /// <summary>Creates and returns a new Query instance that applies a field mask to
            /// the result and returns only the specified subset of fields. You can
            /// specify a list of field paths to return, or use an empty list to only
            /// return the references of matching documents.
            ///
            /// This function returns a new (immutable) instance of the Query (rather
            /// than modify the existing instance) to impose the field mask.</summary>
            /// <param name="field">The field paths to return.</param>
            abstract select: [<ParamArray>] field: ResizeArray<U2<string, FieldPath>> -> Query
            /// <summary>Creates and returns a new Query that starts at the provided document
            /// (inclusive). The starting position is relative to the order of the query.
            /// The document must contain all of the fields provided in the orderBy of
            /// this query.</summary>
            /// <param name="snapshot">The snapshot of the document to start after.</param>
            abstract startAt: snapshot: DocumentSnapshot -> Query
            /// <summary>Creates and returns a new Query that starts at the provided fields
            /// relative to the order of the query. The order of the field values
            /// must match the order of the order by clauses of the query.</summary>
            /// <param name="fieldValues">The field values to start this query at, in order
            /// of the query's order by.</param>
            abstract startAt: [<ParamArray>] fieldValues: ResizeArray<obj option> -> Query
            /// <summary>Creates and returns a new Query that starts after the provided document
            /// (exclusive). The starting position is relative to the order of the query.
            /// The document must contain all of the fields provided in the orderBy of
            /// this query.</summary>
            /// <param name="snapshot">The snapshot of the document to start after.</param>
            abstract startAfter: snapshot: DocumentSnapshot -> Query
            /// <summary>Creates and returns a new Query that starts after the provided fields
            /// relative to the order of the query. The order of the field values
            /// must match the order of the order by clauses of the query.</summary>
            /// <param name="fieldValues">The field values to start this query after, in order
            /// of the query's order by.</param>
            abstract startAfter: [<ParamArray>] fieldValues: ResizeArray<obj option> -> Query
            /// <summary>Creates and returns a new Query that ends before the provided document
            /// (exclusive). The end position is relative to the order of the query. The
            /// document must contain all of the fields provided in the orderBy of this
            /// query.</summary>
            /// <param name="snapshot">The snapshot of the document to end before.</param>
            abstract endBefore: snapshot: DocumentSnapshot -> Query
            /// <summary>Creates and returns a new Query that ends before the provided fields
            /// relative to the order of the query. The order of the field values
            /// must match the order of the order by clauses of the query.</summary>
            /// <param name="fieldValues">The field values to end this query before, in order
            /// of the query's order by.</param>
            abstract endBefore: [<ParamArray>] fieldValues: ResizeArray<obj option> -> Query
            /// <summary>Creates and returns a new Query that ends at the provided document
            /// (inclusive). The end position is relative to the order of the query. The
            /// document must contain all of the fields provided in the orderBy of this
            /// query.</summary>
            /// <param name="snapshot">The snapshot of the document to end at.</param>
            abstract endAt: snapshot: DocumentSnapshot -> Query
            /// <summary>Creates and returns a new Query that ends at the provided fields
            /// relative to the order of the query. The order of the field values
            /// must match the order of the order by clauses of the query.</summary>
            /// <param name="fieldValues">The field values to end this query at, in order
            /// of the query's order by.</param>
            abstract endAt: [<ParamArray>] fieldValues: ResizeArray<obj option> -> Query
            /// Executes the query and returns the results as a `QuerySnapshot`.
            abstract get: unit -> Promise<QuerySnapshot>
            abstract stream: unit -> obj // NodeJS.ReadableStream
            /// <summary>Attaches a listener for `QuerySnapshot `events.</summary>
            /// <param name="onNext">A callback to be called every time a new `QuerySnapshot`
            /// is available.</param>
            /// <param name="onError">A callback to be called if the listen fails or is
            /// cancelled. No further callbacks will occur.</param>
            abstract onSnapshot: onNext: (QuerySnapshot -> unit) * ?onError: (Error -> unit) -> (unit -> unit)
            /// <summary>Returns true if this `Query` is equal to the provided one.</summary>
            /// <param name="other">The `Query` to compare against.</param>
            abstract isEqual: other: Query -> bool

        /// A `Query` refers to a Query which you can read or listen to. You can also
        /// construct refined `Query` objects by adding filters and ordering.
        type [<AllowNullLiteral>] QueryStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Query

        /// A `QuerySnapshot` contains zero or more `QueryDocumentSnapshot` objects
        /// representing the results of a query. The documents can be accessed as an
        /// array via the `docs` property or enumerated using the `forEach` method. The
        /// number of documents can be determined via the `empty` and `size`
        /// properties.
        type [<AllowNullLiteral>] QuerySnapshot =
            /// The query on which you called `get` or `onSnapshot` in order to get this
            /// `QuerySnapshot`.
            abstract query: Query
            /// An array of all the documents in the QuerySnapshot.
            abstract docs: ResizeArray<QueryDocumentSnapshot>
            /// The number of documents in the QuerySnapshot.
            abstract size: float
            /// True if there are no documents in the QuerySnapshot.
            abstract empty: bool
            /// The time this query snapshot was obtained.
            abstract readTime: Timestamp
            /// Returns an array of the documents changes since the last snapshot. If
            /// this is the first snapshot, all documents will be in the list as added
            /// changes.
            abstract docChanges: unit -> ResizeArray<DocumentChange>
            /// <summary>Enumerates all of the documents in the QuerySnapshot.</summary>
            /// <param name="callback">A callback to be called with a `DocumentSnapshot` for
            /// each document in the snapshot.</param>
            /// <param name="thisArg">The `this` binding for the callback.</param>
            abstract forEach: callback: (QueryDocumentSnapshot -> unit) * ?thisArg: obj -> unit
            /// <summary>Returns true if the document data in this `QuerySnapshot` is equal to the
            /// provided one.</summary>
            /// <param name="other">The `QuerySnapshot` to compare against.</param>
            abstract isEqual: other: QuerySnapshot -> bool

        type [<StringEnum>] [<RequireQualifiedAccess>] DocumentChangeType =
            | Added
            | Removed
            | Modified

        /// A `DocumentChange` represents a change to the documents matching a query.
        /// It contains the document affected and the type of change that occurred.
        type [<AllowNullLiteral>] DocumentChange =
            /// The type of change ('added', 'modified', or 'removed').
            abstract ``type``: DocumentChangeType
            /// The document affected by this change.
            abstract doc: QueryDocumentSnapshot
            /// The index of the changed document in the result set immediately prior to
            /// this DocumentChange (i.e. supposing that all prior DocumentChange objects
            /// have been applied). Is -1 for 'added' events.
            abstract oldIndex: float
            /// The index of the changed document in the result set immediately after
            /// this DocumentChange (i.e. supposing that all prior DocumentChange
            /// objects and the current DocumentChange object have been applied).
            /// Is -1 for 'removed' events.
            abstract newIndex: float
            /// <summary>Returns true if the data in this `DocumentChange` is equal to the
            /// provided one.</summary>
            /// <param name="other">The `DocumentChange` to compare against.</param>
            abstract isEqual: other: DocumentChange -> bool

        /// A `CollectionReference` object can be used for adding documents, getting
        /// document references, and querying for documents (using the methods
        /// inherited from `Query`).
        type [<AllowNullLiteral>] CollectionReference =
            inherit Query
            /// The identifier of the collection.
            abstract id: string
            /// A reference to the containing Document if this is a subcollection, else
            /// null.
            abstract parent: DocumentReference option
            /// A string representing the path of the referenced collection (relative
            /// to the root of the database).
            abstract path: string
            /// Retrieves the list of documents in this collection.
            ///
            /// The document references returned may include references to "missing
            /// documents", i.e. document locations that have no document present but
            /// which contain subcollections with documents. Attempting to read such a
            /// document reference (e.g. via `.get()` or `.onSnapshot()`) will return a
            /// `DocumentSnapshot` whose `.exists` property is false.
            abstract listDocuments: unit -> Promise<ResizeArray<DocumentReference>>
            /// <summary>Get a `DocumentReference` for the document within the collection at the
            /// specified path. If no path is specified, an automatically-generated
            /// unique ID will be used for the returned DocumentReference.</summary>
            /// <param name="documentPath">A slash-separated path to a document.</param>
            abstract doc: ?documentPath: string -> DocumentReference
            /// <summary>Add a new document to this collection with the specified data, assigning
            /// it a document ID automatically.</summary>
            /// <param name="data">An Object containing the data for the new document.</param>
            abstract add: data: DocumentData -> Promise<DocumentReference>
            /// <summary>Returns true if this `CollectionReference` is equal to the provided one.</summary>
            /// <param name="other">The `CollectionReference` to compare against.</param>
            abstract isEqual: other: CollectionReference -> bool

        /// Sentinel values that can be used when writing document fields with set(),
        /// create() or update().
        type [<AllowNullLiteral>] FieldValue =
            /// <summary>Returns true if this `FieldValue` is equal to the provided one.</summary>
            /// <param name="other">The `FieldValue` to compare against.</param>
            abstract isEqual: other: FieldValue -> bool

        /// Sentinel values that can be used when writing document fields with set(),
        /// create() or update().
        type [<AllowNullLiteral>] FieldValueStatic =
            /// Returns a sentinel used with set(), create() or update() to include a
            /// server-generated timestamp in the written data.
            abstract serverTimestamp: unit -> FieldValue
            /// Returns a sentinel for use with update() or set() with {merge:true} to
            /// mark a field for deletion.
            abstract delete: unit -> FieldValue
            /// <summary>Returns a special value that can be used with set(), create() or update()
            /// that tells the server to increment the field's current value by the given
            /// value.
            ///
            /// If either current field value or the operand uses floating point
            /// precision, both values will be interpreted as floating point numbers and
            /// all arithmetic will follow IEEE 754 semantics. Otherwise, integer
            /// precision is kept and the result is capped between -2^63 and 2^63-1.
            ///
            /// If the current field value is not of type 'number', or if the field does
            /// not yet exist, the transformation will set the field to the given value.</summary>
            /// <param name="n">The value to increment by.</param>
            abstract increment: n: float -> FieldValue
            /// <summary>Returns a special value that can be used with set(), create() or update()
            /// that tells the server to union the given elements with any array value
            /// that already exists on the server. Each specified element that doesn't
            /// already exist in the array will be added to the end. If the field being
            /// modified is not already an array it will be overwritten with an array
            /// containing exactly the specified elements.</summary>
            /// <param name="elements">The elements to union into the array.</param>
            abstract arrayUnion: [<ParamArray>] elements: ResizeArray<obj option> -> FieldValue
            /// <summary>Returns a special value that can be used with set(), create() or update()
            /// that tells the server to remove the given elements from any array value
            /// that already exists on the server. All instances of each element
            /// specified will be removed from the array. If the field being modified is
            /// not already an array it will be overwritten with an empty array.</summary>
            /// <param name="elements">The elements to remove from the array.</param>
            abstract arrayRemove: [<ParamArray>] elements: ResizeArray<obj option> -> FieldValue

        /// A FieldPath refers to a field in a document. The path may consist of a
        /// single field name (referring to a top-level field in the document), or a
        /// list of field names (referring to a nested field in the document).
        type [<AllowNullLiteral>] FieldPath =
            /// <summary>Returns true if this `FieldPath` is equal to the provided one.</summary>
            /// <param name="other">The `FieldPath` to compare against.</param>
            abstract isEqual: other: FieldPath -> bool

        /// A FieldPath refers to a field in a document. The path may consist of a
        /// single field name (referring to a top-level field in the document), or a
        /// list of field names (referring to a nested field in the document).
        type [<AllowNullLiteral>] FieldPathStatic =
            /// <summary>Creates a FieldPath from the provided field names. If more than one field
            /// name is provided, the path will point to a nested field in a document.</summary>
            /// <param name="fieldNames">A list of field names.</param>
            [<Emit "new $0($1...)">] abstract Create: [<ParamArray>] fieldNames: ResizeArray<string> -> FieldPath
            /// Returns a special sentinel FieldPath to refer to the ID of a document.
            /// It can be used in queries to sort or filter by the document ID.
            abstract documentId: unit -> FieldPath

        /// A Timestamp represents a point in time independent of any time zone or
        /// calendar, represented as seconds and fractions of seconds at nanosecond
        /// resolution in UTC Epoch time. It is encoded using the Proleptic Gregorian
        /// Calendar which extends the Gregorian calendar backwards to year one. It is
        /// encoded assuming all minutes are 60 seconds long, i.e. leap seconds are
        /// "smeared" so that no leap second table is needed for interpretation. Range
        /// is from 0001-01-01T00:00:00Z to 9999-12-31T23:59:59.999999999Z.
        type [<AllowNullLiteral>] Timestamp =
            /// The number of seconds of UTC time since Unix epoch 1970-01-01T00:00:00Z.
            abstract seconds: float
            /// The non-negative fractions of a second at nanosecond resolution.
            abstract nanoseconds: float
            /// Returns a new `Date` corresponding to this timestamp. This may lose
            /// precision.
            abstract toDate: unit -> DateTime
            /// Returns the number of milliseconds since Unix epoch 1970-01-01T00:00:00Z.
            abstract toMillis: unit -> float
            /// <summary>Returns true if this `Timestamp` is equal to the provided one.</summary>
            /// <param name="other">The `Timestamp` to compare against.</param>
            abstract isEqual: other: Timestamp -> bool

        /// A Timestamp represents a point in time independent of any time zone or
        /// calendar, represented as seconds and fractions of seconds at nanosecond
        /// resolution in UTC Epoch time. It is encoded using the Proleptic Gregorian
        /// Calendar which extends the Gregorian calendar backwards to year one. It is
        /// encoded assuming all minutes are 60 seconds long, i.e. leap seconds are
        /// "smeared" so that no leap second table is needed for interpretation. Range
        /// is from 0001-01-01T00:00:00Z to 9999-12-31T23:59:59.999999999Z.
        type [<AllowNullLiteral>] TimestampStatic =
            /// Creates a new timestamp with the current date, with millisecond precision.
            abstract now: unit -> Timestamp
            /// <summary>Creates a new timestamp from the given date.</summary>
            /// <param name="date">The date to initialize the `Timestamp` from.</param>
            abstract fromDate: date: DateTime -> Timestamp
            /// <summary>Creates a new timestamp from the given number of milliseconds.</summary>
            /// <param name="milliseconds">Number of milliseconds since Unix epoch
            /// 1970-01-01T00:00:00Z.</param>
            abstract fromMillis: milliseconds: float -> Timestamp
            /// <summary>Creates a new timestamp.</summary>
            /// <param name="seconds">The number of seconds of UTC time since Unix epoch
            /// 1970-01-01T00:00:00Z. Must be from 0001-01-01T00:00:00Z to
            /// 9999-12-31T23:59:59Z inclusive.</param>
            /// <param name="nanoseconds">The non-negative fractions of a second at nanosecond
            /// resolution. Negative second values with fractions must still have
            /// non-negative nanoseconds values that count forward in time. Must be from
            /// 0 to 999,999,999 inclusive.</param>
            [<Emit "new $0($1...)">] abstract Create: seconds: float * nanoseconds: float -> Timestamp

        type [<AllowNullLiteral>] TypeLiteral_01 =
            abstract FirestoreClient: obj option with get, set
            abstract FirestoreAdminClient: obj option with get, set

        type [<AllowNullLiteral>] TypeLiteral_02 =
            abstract client_email: string option with get, set
            abstract private_key: string option with get, set

    module Messaging =

        type Message =
            U3<TokenMessage, TopicMessage, ConditionMessage>

        [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
        module Message =
            let ofTokenMessage v: Message = v |> U3.Case1
            let isTokenMessage (v: Message) = match v with U3.Case1 _ -> true | _ -> false
            let asTokenMessage (v: Message) = match v with U3.Case1 o -> Some o | _ -> None
            let ofTopicMessage v: Message = v |> U3.Case2
            let isTopicMessage (v: Message) = match v with U3.Case2 _ -> true | _ -> false
            let asTopicMessage (v: Message) = match v with U3.Case2 o -> Some o | _ -> None
            let ofConditionMessage v: Message = v |> U3.Case3
            let isConditionMessage (v: Message) = match v with U3.Case3 _ -> true | _ -> false
            let asConditionMessage (v: Message) = match v with U3.Case3 o -> Some o | _ -> None

        type [<AllowNullLiteral>] AndroidConfig =
            abstract collapseKey: string option with get, set
            abstract priority: U2<string, string> option with get, set
            abstract ttl: float option with get, set
            abstract restrictedPackageName: string option with get, set
            abstract data: TypeLiteral_09 option with get, set
            abstract notification: AndroidNotification option with get, set

        type [<AllowNullLiteral>] AndroidNotification =
            abstract title: string option with get, set
            abstract body: string option with get, set
            abstract icon: string option with get, set
            abstract color: string option with get, set
            abstract sound: string option with get, set
            abstract tag: string option with get, set
            abstract clickAction: string option with get, set
            abstract bodyLocKey: string option with get, set
            abstract bodyLocArgs: ResizeArray<string> option with get, set
            abstract titleLocKey: string option with get, set
            abstract titleLocArgs: ResizeArray<string> option with get, set
            abstract channelId: string option with get, set

        type [<AllowNullLiteral>] ApnsConfig =
            abstract headers: TypeLiteral_09 option with get, set
            abstract payload: ApnsPayload option with get, set

        type [<AllowNullLiteral>] ApnsPayload =
            abstract aps: Aps with get, set
            [<Emit "$0[$1]{{=$2}}">] abstract Item: customData: string -> obj with get, set

        type [<AllowNullLiteral>] Aps =
            abstract alert: U2<string, ApsAlert> option with get, set
            abstract badge: float option with get, set
            abstract sound: U2<string, CriticalSound> option with get, set
            abstract contentAvailable: bool option with get, set
            abstract mutableContent: bool option with get, set
            abstract category: string option with get, set
            abstract threadId: string option with get, set
            [<Emit "$0[$1]{{=$2}}">] abstract Item: customData: string -> obj option with get, set

        type [<AllowNullLiteral>] ApsAlert =
            abstract title: string option with get, set
            abstract subtitle: string option with get, set
            abstract body: string option with get, set
            abstract locKey: string option with get, set
            abstract locArgs: ResizeArray<string> option with get, set
            abstract titleLocKey: string option with get, set
            abstract titleLocArgs: ResizeArray<string> option with get, set
            abstract subtitleLocKey: string option with get, set
            abstract subtitleLocArgs: ResizeArray<string> option with get, set
            abstract actionLocKey: string option with get, set
            abstract launchImage: string option with get, set

        type [<AllowNullLiteral>] CriticalSound =
            abstract critical: bool option with get, set
            abstract name: string with get, set
            abstract volume: float option with get, set

        type [<AllowNullLiteral>] Notification =
            abstract title: string option with get, set
            abstract body: string option with get, set

        type [<AllowNullLiteral>] WebpushConfig =
            abstract headers: TypeLiteral_09 option with get, set
            abstract data: TypeLiteral_09 option with get, set
            abstract notification: WebpushNotification option with get, set
            abstract fcmOptions: WebpushFcmOptions option with get, set

        type [<AllowNullLiteral>] WebpushFcmOptions =
            abstract link: string option with get, set

        type [<AllowNullLiteral>] WebpushNotification =
            abstract title: string option with get, set
            abstract actions: Array<TypeLiteral_10> option with get, set
            abstract badge: string option with get, set
            abstract body: string option with get, set
            abstract data: obj option with get, set
            abstract dir: U3<string, string, string> option with get, set
            abstract icon: string option with get, set
            abstract image: string option with get, set
            abstract lang: string option with get, set
            abstract renotify: bool option with get, set
            abstract requireInteraction: bool option with get, set
            abstract silent: bool option with get, set
            abstract tag: string option with get, set
            abstract timestamp: float option with get, set
            abstract vibrate: U2<float, ResizeArray<float>> option with get, set
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] DataMessagePayload =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set

        type [<AllowNullLiteral>] NotificationMessagePayload =
            abstract tag: string option with get, set
            abstract body: string option with get, set
            abstract icon: string option with get, set
            abstract badge: string option with get, set
            abstract color: string option with get, set
            abstract sound: string option with get, set
            abstract title: string option with get, set
            abstract bodyLocKey: string option with get, set
            abstract bodyLocArgs: string option with get, set
            abstract clickAction: string option with get, set
            abstract titleLocKey: string option with get, set
            abstract titleLocArgs: string option with get, set
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string option with get, set

        type [<AllowNullLiteral>] MessagingPayload =
            abstract data: FirebaseAdmin.Messaging.DataMessagePayload option with get, set
            abstract notification: FirebaseAdmin.Messaging.NotificationMessagePayload option with get, set

        type [<AllowNullLiteral>] MessagingOptions =
            abstract dryRun: bool option with get, set
            abstract priority: string option with get, set
            abstract timeToLive: float option with get, set
            abstract collapseKey: string option with get, set
            abstract mutableContent: bool option with get, set
            abstract contentAvailable: bool option with get, set
            abstract restrictedPackageName: string option with get, set
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option option with get, set

        type [<AllowNullLiteral>] MessagingDeviceResult =
            abstract error: FirebaseAdmin.FirebaseError option with get, set
            abstract messageId: string option with get, set
            abstract canonicalRegistrationToken: string option with get, set

        type [<AllowNullLiteral>] MessagingDevicesResponse =
            abstract canonicalRegistrationTokenCount: float with get, set
            abstract failureCount: float with get, set
            abstract multicastId: float with get, set
            abstract results: ResizeArray<FirebaseAdmin.Messaging.MessagingDeviceResult> with get, set
            abstract successCount: float with get, set

        type [<AllowNullLiteral>] MessagingDeviceGroupResponse =
            abstract successCount: float with get, set
            abstract failureCount: float with get, set
            abstract failedRegistrationTokens: ResizeArray<string> with get, set

        type [<AllowNullLiteral>] MessagingTopicResponse =
            abstract messageId: float with get, set

        type [<AllowNullLiteral>] MessagingConditionResponse =
            abstract messageId: float with get, set

        type [<AllowNullLiteral>] MessagingTopicManagementResponse =
            abstract failureCount: float with get, set
            abstract successCount: float with get, set
            abstract errors: ResizeArray<FirebaseAdmin.FirebaseArrayIndexError> with get, set

        type [<AllowNullLiteral>] Messaging =
            abstract app: FirebaseAdmin.App.App with get, set
            abstract send: message: FirebaseAdmin.Messaging.Message * ?dryRun: bool -> Promise<string>
            abstract sendToDevice: registrationToken: U2<string, ResizeArray<string>> * payload: FirebaseAdmin.Messaging.MessagingPayload * ?options: FirebaseAdmin.Messaging.MessagingOptions -> Promise<FirebaseAdmin.Messaging.MessagingDevicesResponse>
            abstract sendToDeviceGroup: notificationKey: string * payload: FirebaseAdmin.Messaging.MessagingPayload * ?options: FirebaseAdmin.Messaging.MessagingOptions -> Promise<FirebaseAdmin.Messaging.MessagingDeviceGroupResponse>
            abstract sendToTopic: topic: string * payload: FirebaseAdmin.Messaging.MessagingPayload * ?options: FirebaseAdmin.Messaging.MessagingOptions -> Promise<FirebaseAdmin.Messaging.MessagingTopicResponse>
            abstract sendToCondition: condition: string * payload: FirebaseAdmin.Messaging.MessagingPayload * ?options: FirebaseAdmin.Messaging.MessagingOptions -> Promise<FirebaseAdmin.Messaging.MessagingConditionResponse>
            abstract subscribeToTopic: registrationToken: string * topic: string -> Promise<FirebaseAdmin.Messaging.MessagingTopicManagementResponse>
            abstract subscribeToTopic: registrationTokens: ResizeArray<string> * topic: string -> Promise<FirebaseAdmin.Messaging.MessagingTopicManagementResponse>
            abstract unsubscribeFromTopic: registrationToken: string * topic: string -> Promise<FirebaseAdmin.Messaging.MessagingTopicManagementResponse>
            abstract unsubscribeFromTopic: registrationTokens: ResizeArray<string> * topic: string -> Promise<FirebaseAdmin.Messaging.MessagingTopicManagementResponse>

        type [<AllowNullLiteral>] TypeLiteral_10 =
            abstract action: string with get, set
            abstract icon: string option with get, set
            abstract title: string with get, set

        type [<AllowNullLiteral>] TypeLiteral_09 =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set

    module Storage =

        type [<AllowNullLiteral>] Storage =
            abstract app: FirebaseAdmin.App.App with get, set
            abstract bucket: ?name: string -> Bucket

    module InstanceId =

        type [<AllowNullLiteral>] InstanceId =
            abstract app: FirebaseAdmin.App.App with get, set
            abstract deleteInstanceId: instanceId: string -> Promise<unit>

    module ProjectManagement =

        type [<AllowNullLiteral>] ShaCertificate =
            abstract certType: U2<string, string> with get, set
            abstract shaHash: string with get, set
            abstract resourceName: string option with get, set

        type [<AllowNullLiteral>] AndroidAppMetadata =
            abstract resourceName: string with get, set
            abstract appId: string with get, set
            abstract displayName: string option with get, set
            abstract projectId: string with get, set
            abstract packageName: string with get, set

        type [<AllowNullLiteral>] AndroidApp =
            abstract appId: string with get, set
            abstract getMetadata: unit -> Promise<FirebaseAdmin.ProjectManagement.AndroidAppMetadata>
            abstract setDisplayName: newDisplayName: string -> Promise<unit>
            abstract getShaCertificates: unit -> Promise<ResizeArray<FirebaseAdmin.ProjectManagement.ShaCertificate>>
            abstract addShaCertificate: certificateToAdd: ShaCertificate -> Promise<unit>
            abstract deleteShaCertificate: certificateToRemove: ShaCertificate -> Promise<unit>
            abstract getConfig: unit -> Promise<string>

        type [<AllowNullLiteral>] IosAppMetadata =
            abstract resourceName: string with get, set
            abstract appId: string with get, set
            abstract displayName: string with get, set
            abstract projectId: string with get, set
            abstract bundleId: string with get, set

        type [<AllowNullLiteral>] IosApp =
            abstract appId: string with get, set
            abstract getMetadata: unit -> Promise<FirebaseAdmin.ProjectManagement.IosAppMetadata>
            abstract setDisplayName: newDisplayName: string -> Promise<unit>
            abstract getConfig: unit -> Promise<string>

        type [<AllowNullLiteral>] ProjectManagement =
            abstract app: FirebaseAdmin.App.App with get, set
            abstract listAndroidApps: unit -> Promise<ResizeArray<FirebaseAdmin.ProjectManagement.AndroidApp>>
            abstract listIosApps: unit -> Promise<ResizeArray<FirebaseAdmin.ProjectManagement.IosApp>>
            abstract androidApp: appId: string -> FirebaseAdmin.ProjectManagement.AndroidApp
            abstract iosApp: appId: string -> FirebaseAdmin.ProjectManagement.IosApp
            abstract shaCertificate: shaHash: string -> FirebaseAdmin.ProjectManagement.ShaCertificate
            abstract createAndroidApp: packageName: string * ?displayName: string -> Promise<FirebaseAdmin.ProjectManagement.AndroidApp>
            abstract createIosApp: bundleId: string * ?displayName: string -> Promise<FirebaseAdmin.ProjectManagement.IosApp>

    type [<AllowNullLiteral>] BaseMessage =
        abstract data: TypeLiteral_11 option with get, set
        abstract notification: FirebaseAdmin.Messaging.Notification option with get, set
        abstract android: FirebaseAdmin.Messaging.AndroidConfig option with get, set
        abstract webpush: FirebaseAdmin.Messaging.WebpushConfig option with get, set
        abstract apns: FirebaseAdmin.Messaging.ApnsConfig option with get, set

    type [<AllowNullLiteral>] TokenMessage =
        inherit BaseMessage
        abstract token: string with get, set

    type [<AllowNullLiteral>] TopicMessage =
        inherit BaseMessage
        abstract topic: string with get, set

    type [<AllowNullLiteral>] ConditionMessage =
        inherit BaseMessage
        abstract condition: string with get, set

    type [<AllowNullLiteral>] TypeLiteral_11 =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set
