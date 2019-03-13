/// Fable bindings for the 'firebase-admin' npm package.
module rec Fable.FirebaseAdmin

open System
open Fable.Core
open Fable.Import.JS

// TODO bindings for these imports
//module _firestore = @google_cloud_firestore
//type Bucket = @google_cloud_storage.Bucket


// TODO does this need to be imported/required?
type Agent = Fable.Import.Node.Http.Agent

module Globals =

    /// Global import for the 'firebase-admin' module
    let [<Import("*","firebase-admin")>] admin: IExports = jsNative

//    let [<Import("credential","src/admin")>] credential: Credential.IExports = jsNative
//    let [<Import("database","src/admin")>] database: Database.IExports = jsNative


    type [<AllowNullLiteral>] IExports =
        abstract SDK_VERSION: string
        abstract apps: ResizeArray<Globals.App.App option>
        abstract app: ?name: string -> Globals.App.App
        abstract auth: ?app: Globals.App.App -> Globals.Auth.Auth
        abstract database: ?app: Globals.App.App -> Globals.Database.Database
        abstract messaging: ?app: Globals.App.App -> Globals.Messaging.Messaging
//        abstract storage: ?app: Globals.App.App -> Globals.Storage.Storage
//        abstract firestore: ?app: Globals.App.App -> Globals.Firestore.Firestore
        abstract instanceId: ?app: Globals.App.App -> Globals.InstanceId.InstanceId
        abstract projectManagement: ?app: Globals.App.App -> Globals.ProjectManagement.ProjectManagement
        abstract initializeApp: ?options: Globals.AppOptions * ?name: string -> Globals.App.App

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
        abstract credential: Globals.Credential.Credential option with get, set
        abstract databaseAuthVariableOverride: Object option with get, set
        abstract databaseURL: string option with get, set
        abstract serviceAccountId: string option with get, set
        abstract storageBucket: string option with get, set
        abstract projectId: string option with get, set
//        abstract httpAgent: Agent option with get, set

    module App =

        type [<AllowNullLiteral>] App =
            abstract name: string with get, set
            abstract options: Globals.AppOptions with get, set
            abstract auth: unit -> Globals.Auth.Auth
            abstract database: ?url: string -> Globals.Database.Database
//            abstract firestore: unit -> Globals.Firestore.Firestore
            abstract instanceId: unit -> Globals.InstanceId.InstanceId
            abstract messaging: unit -> Globals.Messaging.Messaging
            abstract projectManagement: unit -> Globals.ProjectManagement.ProjectManagement
//            abstract storage: unit -> Globals.Storage.Storage
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
            abstract metadata: Globals.Auth.UserMetadata with get, set
            abstract providerData: ResizeArray<Globals.Auth.UserInfo> with get, set
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
            abstract users: ResizeArray<Globals.Auth.UserRecord> with get, set
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
            abstract errors: ResizeArray<Globals.FirebaseArrayIndexError> with get, set

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
            abstract createUser: properties: Globals.Auth.CreateRequest -> Promise<Globals.Auth.UserRecord>
            abstract deleteUser: uid: string -> Promise<unit>
            abstract getUser: uid: string -> Promise<Globals.Auth.UserRecord>
            abstract getUserByEmail: email: string -> Promise<Globals.Auth.UserRecord>
            abstract getUserByPhoneNumber: phoneNumber: string -> Promise<Globals.Auth.UserRecord>
            abstract listUsers: ?maxResults: float * ?pageToken: string -> Promise<Globals.Auth.ListUsersResult>
            abstract updateUser: uid: string * properties: Globals.Auth.UpdateRequest -> Promise<Globals.Auth.UserRecord>
            abstract verifyIdToken: idToken: string * ?checkRevoked: bool -> Promise<Globals.Auth.DecodedIdToken>
            abstract setCustomUserClaims: uid: string * customUserClaims: Object -> Promise<unit>
            abstract revokeRefreshTokens: uid: string -> Promise<unit>
            abstract importUsers: users: ResizeArray<Globals.Auth.UserImportRecord> * ?options: Globals.Auth.UserImportOptions -> Promise<Globals.Auth.UserImportResult>
            abstract createSessionCookie: idToken: string * sessionCookieOptions: Globals.Auth.SessionCookieOptions -> Promise<string>
            abstract verifySessionCookie: sessionCookie: string * ?checkForRevocation: bool -> Promise<Globals.Auth.DecodedIdToken>
            abstract generatePasswordResetLink: email: string * ?actionCodeSettings: Globals.Auth.ActionCodeSettings -> Promise<string>
            abstract generateEmailVerificationLink: email: string * ?actionCodeSettings: Globals.Auth.ActionCodeSettings -> Promise<string>
            abstract generateSignInWithEmailLink: email: string * actionCodeSettings: Globals.Auth.ActionCodeSettings -> Promise<string>

        type [<AllowNullLiteral>] Auth =
            inherit Globals.Auth.BaseAuth
            abstract app: Globals.App.App with get, set

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
            abstract applicationDefault: ?httpAgent: Agent -> Globals.Credential.Credential
            abstract cert: serviceAccountPathOrObject: U2<string, Globals.ServiceAccount> * ?httpAgent: Agent -> Globals.Credential.Credential
            abstract refreshToken: refreshTokenPathOrObject: U2<string, Object> * ?httpAgent: Agent -> Globals.Credential.Credential

        type [<AllowNullLiteral>] Credential =
            abstract getAccessToken: unit -> Promise<Globals.GoogleOAuthAccessToken>

    module Database =
//        let [<Import("ServerValue","src/admin/database")>] serverValue: ServerValue.IExports = jsNative

        type [<AllowNullLiteral>] IExports =
            abstract enableLogging: ?logger: U2<bool, (string -> obj option)> * ?persistent: bool -> obj option

        type [<AllowNullLiteral>] Database =
            abstract app: Globals.App.App with get, set
            abstract goOffline: unit -> unit
            abstract goOnline: unit -> unit
            abstract ref: ?path: U2<string, Globals.Database.Reference> -> Globals.Database.Reference
            abstract refFromURL: url: string -> Globals.Database.Reference

        type [<AllowNullLiteral>] DataSnapshot =
            abstract key: string option with get, set
            abstract ref: Globals.Database.Reference with get, set
            abstract child: path: string -> Globals.Database.DataSnapshot
            abstract exists: unit -> bool
            abstract exportVal: unit -> obj option
            abstract forEach: action: (Globals.Database.DataSnapshot -> U2<bool, unit>) -> bool
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
            abstract ref: Globals.Database.Reference with get, set
            abstract endAt: value: U3<float, string, bool> option * ?key: string -> Globals.Database.Query
            abstract equalTo: value: U3<float, string, bool> option * ?key: string -> Globals.Database.Query
            abstract isEqual: other: Globals.Database.Query option -> bool
            abstract limitToFirst: limit: float -> Globals.Database.Query
            abstract limitToLast: limit: float -> Globals.Database.Query
            abstract off: ?eventType: Globals.Database.EventType * ?callback: (Globals.Database.DataSnapshot -> string -> obj option) * ?context: Object -> unit
            abstract on: eventType: Globals.Database.EventType * callback: (Globals.Database.DataSnapshot option -> string -> obj option) * ?cancelCallbackOrContext: Object * ?context: Object -> (Globals.Database.DataSnapshot option -> string -> obj option)
            abstract once: eventType: Globals.Database.EventType * ?successCallback: (Globals.Database.DataSnapshot -> string -> obj option) * ?failureCallbackOrContext: Object * ?context: Object -> Promise<Globals.Database.DataSnapshot>
            abstract orderByChild: path: string -> Globals.Database.Query
            abstract orderByKey: unit -> Globals.Database.Query
            abstract orderByPriority: unit -> Globals.Database.Query
            abstract orderByValue: unit -> Globals.Database.Query
            abstract startAt: value: U3<float, string, bool> option * ?key: string -> Globals.Database.Query
            abstract toJSON: unit -> Object
            abstract toString: unit -> string

        type [<AllowNullLiteral>] Reference =
            inherit Globals.Database.Query
            abstract key: string option with get, set
            abstract parent: Globals.Database.Reference option with get, set
            abstract root: Globals.Database.Reference with get, set
            abstract path: string with get, set
            abstract child: path: string -> Globals.Database.Reference
            abstract onDisconnect: unit -> Globals.Database.OnDisconnect
            abstract push: ?value: obj * ?onComplete: (Error option -> obj option) -> Globals.Database.ThenableReference
            abstract remove: ?onComplete: (Error option -> obj option) -> Promise<unit>
            abstract set: value: obj option * ?onComplete: (Error option -> obj option) -> Promise<unit>
            abstract setPriority: priority: U2<string, float> option * onComplete: (Error option -> obj option) -> Promise<unit>
            abstract setWithPriority: newVal: obj option * newPriority: U2<string, float> option * ?onComplete: (Error option -> obj option) -> Promise<unit>
            abstract transaction: transactionUpdate: (obj option -> obj option) * ?onComplete: (Error option -> bool -> Globals.Database.DataSnapshot option -> obj option) * ?applyLocally: bool -> Promise<TypeLiteral_08>
            abstract update: values: Object * ?onComplete: (Error option -> obj option) -> Promise<unit>

        type [<AllowNullLiteral>] ThenableReference =
            inherit Globals.Database.Reference
            inherit PromiseLike<obj option>

        module ServerValue =

            type [<AllowNullLiteral>] IExports =
                abstract TIMESTAMP: float

        type [<AllowNullLiteral>] TypeLiteral_08 =
            abstract committed: bool with get, set
            abstract snapshot: Globals.Database.DataSnapshot option with get, set

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
            abstract data: Globals.Messaging.DataMessagePayload option with get, set
            abstract notification: Globals.Messaging.NotificationMessagePayload option with get, set

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
            abstract error: Globals.FirebaseError option with get, set
            abstract messageId: string option with get, set
            abstract canonicalRegistrationToken: string option with get, set

        type [<AllowNullLiteral>] MessagingDevicesResponse =
            abstract canonicalRegistrationTokenCount: float with get, set
            abstract failureCount: float with get, set
            abstract multicastId: float with get, set
            abstract results: ResizeArray<Globals.Messaging.MessagingDeviceResult> with get, set
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
            abstract errors: ResizeArray<Globals.FirebaseArrayIndexError> with get, set

        type [<AllowNullLiteral>] Messaging =
            abstract app: Globals.App.App with get, set
            abstract send: message: Globals.Messaging.Message * ?dryRun: bool -> Promise<string>
            abstract sendToDevice: registrationToken: U2<string, ResizeArray<string>> * payload: Globals.Messaging.MessagingPayload * ?options: Globals.Messaging.MessagingOptions -> Promise<Globals.Messaging.MessagingDevicesResponse>
            abstract sendToDeviceGroup: notificationKey: string * payload: Globals.Messaging.MessagingPayload * ?options: Globals.Messaging.MessagingOptions -> Promise<Globals.Messaging.MessagingDeviceGroupResponse>
            abstract sendToTopic: topic: string * payload: Globals.Messaging.MessagingPayload * ?options: Globals.Messaging.MessagingOptions -> Promise<Globals.Messaging.MessagingTopicResponse>
            abstract sendToCondition: condition: string * payload: Globals.Messaging.MessagingPayload * ?options: Globals.Messaging.MessagingOptions -> Promise<Globals.Messaging.MessagingConditionResponse>
            abstract subscribeToTopic: registrationToken: string * topic: string -> Promise<Globals.Messaging.MessagingTopicManagementResponse>
            abstract subscribeToTopic: registrationTokens: ResizeArray<string> * topic: string -> Promise<Globals.Messaging.MessagingTopicManagementResponse>
            abstract unsubscribeFromTopic: registrationToken: string * topic: string -> Promise<Globals.Messaging.MessagingTopicManagementResponse>
            abstract unsubscribeFromTopic: registrationTokens: ResizeArray<string> * topic: string -> Promise<Globals.Messaging.MessagingTopicManagementResponse>

        type [<AllowNullLiteral>] TypeLiteral_10 =
            abstract action: string with get, set
            abstract icon: string option with get, set
            abstract title: string with get, set

        type [<AllowNullLiteral>] TypeLiteral_09 =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set

//    module Storage =
//
//        type [<AllowNullLiteral>] Storage =
//            abstract app: Globals.App.App with get, set
//            abstract bucket: ?name: string -> Bucket

    module InstanceId =

        type [<AllowNullLiteral>] InstanceId =
            abstract app: Globals.App.App with get, set
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
            abstract getMetadata: unit -> Promise<Globals.ProjectManagement.AndroidAppMetadata>
            abstract setDisplayName: newDisplayName: string -> Promise<unit>
            abstract getShaCertificates: unit -> Promise<ResizeArray<Globals.ProjectManagement.ShaCertificate>>
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
            abstract getMetadata: unit -> Promise<Globals.ProjectManagement.IosAppMetadata>
            abstract setDisplayName: newDisplayName: string -> Promise<unit>
            abstract getConfig: unit -> Promise<string>

        type [<AllowNullLiteral>] ProjectManagement =
            abstract app: Globals.App.App with get, set
            abstract listAndroidApps: unit -> Promise<ResizeArray<Globals.ProjectManagement.AndroidApp>>
            abstract listIosApps: unit -> Promise<ResizeArray<Globals.ProjectManagement.IosApp>>
            abstract androidApp: appId: string -> Globals.ProjectManagement.AndroidApp
            abstract iosApp: appId: string -> Globals.ProjectManagement.IosApp
            abstract shaCertificate: shaHash: string -> Globals.ProjectManagement.ShaCertificate
            abstract createAndroidApp: packageName: string * ?displayName: string -> Promise<Globals.ProjectManagement.AndroidApp>
            abstract createIosApp: bundleId: string * ?displayName: string -> Promise<Globals.ProjectManagement.IosApp>

type [<AllowNullLiteral>] BaseMessage =
    abstract data: TypeLiteral_11 option with get, set
    abstract notification: Globals.Messaging.Notification option with get, set
    abstract android: Globals.Messaging.AndroidConfig option with get, set
    abstract webpush: Globals.Messaging.WebpushConfig option with get, set
    abstract apns: Globals.Messaging.ApnsConfig option with get, set

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
