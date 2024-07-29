
using ErrorOr;

namespace BloggingPlatform.Application.Followers.Common;
public static class FollowerErrors
{
    public static readonly Error CannotFollowYourself = Error.Conflict(
        code: "Follower.CannotFollowYourself",
        description: "A user cannot follow themselves.");

    public static readonly Error AlreadyFollowing = Error.Conflict(
    code: "Follower.AlreadyFollowing",
    description: "The user is already following this user.");

    public static readonly Error FollowerNotFound = Error.NotFound(
     code: "Follower.FollowerNotFound",
     description: "Follower relationship not found.");

    public static readonly Error NotFollowing = Error.Validation(
 code: "Follower.NotFollowing",
 description: "You are not following this user.");

            public static readonly Error UserNotFound = Error.NotFound(
     code: "Follower.UserNotFound",
     description: "User Not Found .");
}
