using TodoApi.Domains.Category.Entities;

namespace TodoApi.Domains.UserInfo.Entities;

public class UserCategoryGroupEntity
{
    public long Seq {get; set;}

    public required string UserId {get; set;}

    public virtual required UserInfoEntity UserInfo {get; set;}

    public required string CategoryId {get; set;}

    public required CategoryEntity Category {get; set;}
}