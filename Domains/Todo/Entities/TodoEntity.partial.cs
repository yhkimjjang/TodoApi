using Visus.Cuid;

namespace TodoApi.Domains.Todo.Entities;

public partial class TodoEntity
{
    /// <summary>
    /// User Id 생성
    /// </summary>
    /// <returns></returns>
    public string CreateId()
    {
        Cuid2 cuid = new Cuid2();
        return cuid.ToString();
    }

    /// <summary>
    /// Todo 내용 유효성 검사
    /// </summary>
    /// <returns>정상이라면 String.Empty, 아니라면 비정상 필드 내용</returns>
    public string ValidateTodo()
    {
        if(String.IsNullOrEmpty(Title) || String.IsNullOrWhiteSpace(Title))
        {
            return "Title은 입력 필수";
        }

        if(String.IsNullOrEmpty(UserId) || String.IsNullOrWhiteSpace(UserId))
        {
            return "사용자 아이디 입력 필수";
        }

        if(String.IsNullOrEmpty(CreateUser) || String.IsNullOrWhiteSpace(CreateUser))
        {
            return "사용자 아이디 입력 필수";
        }

        if(UserId.Equals(CreateUser) == false)
        {
            return "사용자 아이디가 동일하지 않음";
        }

        return String.Empty;
    }    
}