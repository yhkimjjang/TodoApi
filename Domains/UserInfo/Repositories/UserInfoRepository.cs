using Microsoft.EntityFrameworkCore;
using TodoApi.Domains.UserInfo;
using TodoApi.Domains.UserInfo.Entities;

namespace TodoApi.Domains.UserInfo.Repositories;

public class UserInfoRepository
{
    private readonly TodoDb _db;

    public UserInfoRepository(TodoDb db)
    {
        _db = db;
    }

    /// <summary>
    /// 사용자 정보 저장
    /// </summary>
    /// <param name="userInfo"></param>
    /// <returns></returns>
    public async ValueTask SaveItemAsync(UserInfoEntity userInfo)
    {
        _db.userInfos.Add(userInfo);
        _ = await _db.SaveChangesAsync();
    }

    /// <summary>
    /// 이메일을 통해서 중복 확인
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    public async ValueTask<bool> IsDuplicateAsync(string email)
    {
        return await _db.userInfos.AnyAsync(e => e.Email.Equals(email) && e.IsUseYn == false);
    }

    /// <summary>
    /// id를 이용해서 사용자 정보 조회
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<UserInfoEntity?> GetUserInfoAsync(string id)
    {
        return await _db.userInfos.SingleOrDefaultAsync(e => e.UserId == id);
    }
}