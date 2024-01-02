namespace TodoApi.Domains.UserInfo.Entities;

public class InvitationEntity
{
    public long Seq {get; set;}

    public required string RecieverEmail {get; set;}

    public required string InvitationKey {get; set;}

    public DateTime InvitationExpire {get; set;}

    public required string UserId {get; set;}

    public required UserInfoEntity UserInfo {get; set;}
}