using TodoApi.Domains.UserInfo;

namespace TodoApi.Domains.UserInfo.Entities;

public class UserFriendEntity
{
    public long Seq {get; set;}

    public required string FriendId {get; set;}

    public bool IsUserYn {get; set;}

    public required string CreateUser {get; set;}

    public DateTime CreateDAte {get; set;}

    public string? UpdateUser {get; set;}

    public DateTime? UpdateDate {get; set;}

    public required string UserId {get; set;}

    public required UserInfoEntity UserInfo {get; set;}
}