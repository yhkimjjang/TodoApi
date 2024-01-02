namespace TodoApi.Domains.Todo.ValueObject;

public partial class TodoDetailRqeustVo
{
    /// <summary>
    /// 입력 값 검사
    /// </summary>
    /// <returns>정상이며 String.Empty, 아니라며 string 메세지 전달</returns>
    public string ValidateRequest()
    {
        if(string.IsNullOrEmpty(TodoId) || string.IsNullOrWhiteSpace(TodoId))
            return "todo id가 없음";
        
        if(string.IsNullOrEmpty(UserId) || string.IsNullOrWhiteSpace(UserId))
            return "user id가 없음";

        return String.Empty;
    }
}