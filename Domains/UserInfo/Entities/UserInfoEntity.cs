using TodoApi.Domains.Todo.Entities;

namespace TodoApi.Domains.UserInfo.Entities;

public partial class UserInfoEntity
{
    public UserInfoEntity()
    {
        UserId = CreateId();
    }

    public long Seq {get; set;}

    public string UserId {get; set;}

    public required string Email {get; set;}

    public bool SocialUseYn {get; set;}

    public bool IsUseYn {get;set;}

    public DateTime CreateDate {get; set;}

    public DateTime? UpdateDate {get; set;}

    public DateTime? DeleteDate {get; set;}

    public ICollection<TodoEntity>? Todos {get; set;}
    public ICollection<UserFriendEntity>? UserFriends {get; set;}
    public ICollection<InvitationEntity>? Invitations {get; set;}
    public ICollection<UserCategoryGroupEntity>? UserCategoryGroups {get; set;}
    public UserPasswordEntity? UserPassword {get; set;}
}