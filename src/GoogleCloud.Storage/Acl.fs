namespace rec Fable.Import.GoogleCloud.Storage

open Fable.Core
open Fable.Import.JS
open Fable.Import.GoogleCloud.Common

module R = Fable.Import.Request.Request
//type BodyResponseCallback = @google_cloud_common.BodyResponseCallback
//type DecorateRequestOptions = @google_cloud_common.DecorateRequestOptions


type [<AllowNullLiteral>] AclOptions =
    abstract pathPrefix: string with get, set
    abstract request: (DecorateRequestOptions -> BodyResponseCallback -> unit) with get, set

type GetAclResponse =
    U2<AccessControlObject, ResizeArray<AccessControlObject>> * R.Response

type [<AllowNullLiteral>] GetAclCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * ?acl: U2<AccessControlObject, ResizeArray<AccessControlObject>> * ?apiResponse: R.Response -> unit

type [<AllowNullLiteral>] GetAclOptions =
    abstract entity: string with get, set
    abstract generation: float option with get, set
    abstract userProject: string option with get, set

type [<AllowNullLiteral>] UpdateAclOptions =
    abstract entity: string with get, set
    abstract role: string with get, set
    abstract generation: float option with get, set
    abstract userProject: string option with get, set

type UpdateAclResponse =
    AccessControlObject * R.Response

type [<AllowNullLiteral>] UpdateAclCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * ?acl: AccessControlObject * ?apiResponse: R.Response -> unit

type [<AllowNullLiteral>] AddAclOptions =
    abstract entity: string with get, set
    abstract role: string with get, set
    abstract generation: float option with get, set
    abstract userProject: string option with get, set

type AddAclResponse =
    AccessControlObject * R.Response

type [<AllowNullLiteral>] AddAclCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * ?acl: AccessControlObject * ?apiResponse: R.Response -> unit

type RemoveAclResponse =
    R.Response

type [<AllowNullLiteral>] RemoveAclCallback =
    [<Emit "$0($1...)">] abstract Invoke: err: Error option * ?apiResponse: R.Response -> unit

type [<AllowNullLiteral>] RemoveAclOptions =
    abstract entity: string with get, set
    abstract generation: float option with get, set
    abstract userProject: string option with get, set

type [<AllowNullLiteral>] AccessControlObject =
    abstract entity: string with get, set
    abstract role: string with get, set
    abstract projectTeam: string with get, set

/// Attach functionality to a {@link Storage.acl} instance. This will add an
/// object for each role group (owners, readers, and writers), with each object
/// containing methods to add or delete a type of entity.
///
/// As an example, here are a few methods that are created.
///
///    myBucket.acl.readers.deleteGroup('groupId', function(err) {});
///
///    myBucket.acl.owners.addUser('email@example.com', function(err, acl) {});
///
///    myBucket.acl.writers.addDomain('example.com', function(err, acl) {});
type [<AllowNullLiteral>] AclRoleAccessorMethods =
    abstract owners: Acl.TypeLiteral_01 with get, set
    abstract readers: Acl.TypeLiteral_01 with get, set
    abstract writers: Acl.TypeLiteral_01 with get, set
    abstract _assignAccessMethods: role: string -> unit

/// Attach functionality to a {@link Storage.acl} instance. This will add an
/// object for each role group (owners, readers, and writers), with each object
/// containing methods to add or delete a type of entity.
///
/// As an example, here are a few methods that are created.
///
///    myBucket.acl.readers.deleteGroup('groupId', function(err) {});
///
///    myBucket.acl.owners.addUser('email@example.com', function(err, acl) {});
///
///    myBucket.acl.writers.addDomain('example.com', function(err, acl) {});
type [<AllowNullLiteral>] AclRoleAccessorMethodsStatic =
    [<Emit "new $0($1...)">] abstract Create: unit -> AclRoleAccessorMethods

/// Cloud Storage uses access control lists (ACLs) to manage object and
/// bucket access. ACLs are the mechanism you use to share objects with other
/// users and allow other users to access your buckets and objects.
///
/// An ACL consists of one or more entries, where each entry grants permissions
/// to an entity. Permissions define the actions that can be performed against an
/// object or bucket (for example, `READ` or `WRITE`); the entity defines who the
/// permission applies to (for example, a specific user or group of users).
///
/// Where an `entity` value is accepted, we follow the format the Cloud Storage
/// API expects.
///
/// Refer to
/// https://cloud.google.com/storage/docs/json_api/v1/defaultObjectAccessControls
/// for the most up-to-date values.
///
///    - `user-userId`
///    - `user-email`
///    - `group-groupId`
///    - `group-email`
///    - `domain-domain`
///    - `project-team-projectId`
///    - `allUsers`
///    - `allAuthenticatedUsers`
///
/// Examples:
///
///    - The user "liz@example.com" would be `user-liz@example.com`.
///    - The group "example@googlegroups.com" would be
///      `group-example@googlegroups.com`.
///    - To refer to all members of the Google Apps for Business domain
///      "example.com", the entity would be `domain-example.com`.
///
/// For more detailed information, see
/// [About Access Control Lists](http://goo.gl/6qBBPO).
type [<AllowNullLiteral>] Acl =
    inherit AclRoleAccessorMethods
    abstract ``default``: Acl with get, set
    abstract pathPrefix: string with get, set
    abstract request_: (DecorateRequestOptions -> BodyResponseCallback -> unit) with get, set
    abstract add: options: AddAclOptions -> Promise<AddAclResponse>
    abstract add: options: AddAclOptions * callback: AddAclCallback -> unit
    abstract delete: options: RemoveAclOptions -> Promise<RemoveAclResponse>
    abstract delete: options: RemoveAclOptions * callback: RemoveAclCallback -> unit
    abstract get: ?options: GetAclOptions -> Promise<GetAclResponse>
    abstract get: options: GetAclOptions * callback: GetAclCallback -> unit
    abstract get: callback: GetAclCallback -> unit
    abstract update: options: UpdateAclOptions -> Promise<UpdateAclResponse>
    abstract update: options: UpdateAclOptions * callback: UpdateAclCallback -> unit
    /// Transform API responses to a consistent object format.
    abstract makeAclObject_: accessControlObject: AccessControlObject -> AccessControlObject
    /// <summary>Patch requests up to the bucket's request object.</summary>
    /// <param name="callback">Callback function.</param>
    abstract request: reqOpts: DecorateRequestOptions * callback: BodyResponseCallback -> unit

/// Cloud Storage uses access control lists (ACLs) to manage object and
/// bucket access. ACLs are the mechanism you use to share objects with other
/// users and allow other users to access your buckets and objects.
///
/// An ACL consists of one or more entries, where each entry grants permissions
/// to an entity. Permissions define the actions that can be performed against an
/// object or bucket (for example, `READ` or `WRITE`); the entity defines who the
/// permission applies to (for example, a specific user or group of users).
///
/// Where an `entity` value is accepted, we follow the format the Cloud Storage
/// API expects.
///
/// Refer to
/// https://cloud.google.com/storage/docs/json_api/v1/defaultObjectAccessControls
/// for the most up-to-date values.
///
///    - `user-userId`
///    - `user-email`
///    - `group-groupId`
///    - `group-email`
///    - `domain-domain`
///    - `project-team-projectId`
///    - `allUsers`
///    - `allAuthenticatedUsers`
///
/// Examples:
///
///    - The user "liz@example.com" would be `user-liz@example.com`.
///    - The group "example@googlegroups.com" would be
///      `group-example@googlegroups.com`.
///    - To refer to all members of the Google Apps for Business domain
///      "example.com", the entity would be `domain-example.com`.
///
/// For more detailed information, see
/// [About Access Control Lists](http://goo.gl/6qBBPO).
type [<AllowNullLiteral>] AclStatic =
    [<Emit "new $0($1...)">] abstract Create: options: AclOptions -> Acl

[<RequireQualifiedAccess>]
module Acl =
    type [<AllowNullLiteral>] IExports =
        abstract AclRoleAccessorMethods: AclRoleAccessorMethodsStatic
        abstract Acl: AclStatic

    type [<AllowNullLiteral>] TypeLiteral_01 =
        interface end
