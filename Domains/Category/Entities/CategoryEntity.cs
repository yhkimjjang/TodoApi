using TodoApi.Domains.UserInfo.Entities;

namespace TodoApi.Domains.Category.Entities;

public partial class CategoryEntity
{
    public CategoryEntity()
    {
        CategoryId = CreateId();
    }

    public long Seq {get; set;}

    public required string CategoryId {get; set;}

    public required string CategoryName {get; set;}

    public bool IsUseYn {get; set;}

    public required string CreateUser {get; set;}

    public DateTime CreateDate {get; set;}

    public string? UpdateUser {get; set;}

    public DateTime? UpdateDate {get; set;}

    public required string CaregoryOwner {get; set;}

    public required UserInfoEntity UserInfo {get; set;}

    public ICollection<CategoryTodoEntity>? CategoryTodos {get; set;}
}