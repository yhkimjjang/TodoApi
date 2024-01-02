using System.Text.RegularExpressions;
using Visus.Cuid;

namespace TodoApi.Domains.UserInfo.Entities;

public partial class UserInfoEntity
{
    /// <summary>
    /// 아이디 생성
    /// </summary>
    /// <returns></returns>
    public string CreateId()
    {
        Cuid2 cuid = new Cuid2();
        return cuid.ToString();
    }

    /// <summary>
    /// 이메일 형식 검사
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public bool IsValidEmail()
    {
        bool valid = Regex.IsMatch(Email, @"[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-zA-Z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?\.)+[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?");
        return valid;
    }

    /// <summary>
    /// 패스워드 형식 검사<br></br>
    /// 최쇠 1 이상의 영문 대소문자, 특수문자, 1 이상의 숫자, 최소 8자 이상
    /// </summary>
    /// <param name="password"></param>
    /// <returns></returns>
    public bool IsValidPassword(string password)
    {
        bool valid = Regex.IsMatch(password, @"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");
        return valid;
    }
}