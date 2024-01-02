using TodoApi.Domains.Common;
using TodoApi.Domains.UserInfo.Dtos;
using TodoApi.Domains.UserInfo.Repositories;

namespace TodoApi.Domains.UserInfo;

public class UserInfoService {

    private readonly UserInfoRepository _userRepo;
    
    public UserInfoService(UserInfoRepository userRepo)
    {
        _userRepo = userRepo;
    }

    /// <summary>
    /// id를 이용해서 사용자 정보 조회
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<ResponseMessage<UserInfoResponse>> GetUerInfoByIdAsync(string id)
    {
        var userInfo = await _userRepo.GetUserInfoAsync(id);
        if(userInfo == null)
        {
            return new ResponseMessageBuilder<UserInfoResponse>()
                .AddCode(System.Net.HttpStatusCode.BadRequest)
                .AddError("사용자 정보가 없음.")
                .Build();
        }

        var userInforResp = new UserInfoResponse
        {
            UserId = userInfo.UserId,
            Email = userInfo.Email,
            SocialUseYn = userInfo.SocialUseYn
        };

        return new ResponseMessageBuilder<UserInfoResponse>()
                .AddData(userInforResp)
                .Build();
    }
}