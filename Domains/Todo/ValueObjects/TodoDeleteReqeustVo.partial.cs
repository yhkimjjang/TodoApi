namespace TodoApi.Domains.Todo.ValueObject;

public partial class TodoDeleteRequestVo
{
    /// <summary>
    /// 입력 값 검사
    /// </summary>
    /// <returns>정상이며 String.Empty, 아니라며 string 메세지 전달</returns>
    public string VaildeRequest()
    {
        if(string.IsNullOrEmpty(TodoId) || string.IsNullOrWhiteSpace(TodoId))
            return "todo 아이디 없음";

        if(string.IsNullOrEmpty(UserId) || string.IsNullOrWhiteSpace(UserId))
            return "user 아이디 없음";

        return String.Empty;
    }
}