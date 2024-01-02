using Visus.Cuid;

namespace TodoApi.Domains.Category.Entities;

public partial class CategoryEntity
{
    /// <summary>
    /// Category ID 생성
    /// </summary>
    /// <returns></returns>
    public string CreateId()
    {
        Cuid2 cuid = new Cuid2();
        return cuid.ToString();
    }
}