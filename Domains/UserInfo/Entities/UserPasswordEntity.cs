using TodoApi.Domains.UserInfo;

namespace TodoApi.Domains.UserInfo.Entities;

public class UserPasswordEntity
{
    public long Seq {get; set;}

    public required string Password {get; set;}

    public string? SaltValue {get; set;}

    public required string UserId {get; set;}

    public required UserInfoEntity UserInfo {get; set;}
}