using TodoApi.Domains.Common;
using TodoApi.Domains.UserInfo.Dtos;
using TodoApi.Domains.UserInfo.Entities;
using TodoApi.Domains.UserInfo.Repositories;

namespace TodoApi.Domains.UserInfo.Services;

public class SignUpService
{
    private readonly UserInfoRepository _userRepo;
    private readonly ILogger _logger;

    public SignUpService(UserInfoRepository repo, ILoggerFactory loggerFactory)
    {
        _userRepo = repo;
        _logger = loggerFactory.CreateLogger("SignUpService");
    }

    /// <summary>
    /// 사용자 생성 프로세스 처리
    /// </summary>
    /// <param name="signUpInfo"></param>
    /// <returns></returns>
    public async Task<ResponseMessage<UserInfoEntity>> CreateUserAsync(SignUpRequest signUpInfo)
    {
        var userInfo = new UserInfoEntity
        {
            Email = signUpInfo.email
        };

        if(userInfo.IsValidEmail() == false)
        {
            _logger.LogDebug("이메일 형식이 올바르지 않음");
            return new ResponseMessageBuilder<UserInfoEntity>()
                .AddCode(System.Net.HttpStatusCode.BadRequest)
                .AddError("이메일 형식이 올바르지 않음.")
                .Build();
        }

        if(userInfo.IsValidPassword(signUpInfo.passwod) == false)
        {
            _logger.LogDebug("비밀번호 형식이 올바르지 않음");
           return new ResponseMessageBuilder<UserInfoEntity>()
                .AddCode(System.Net.HttpStatusCode.BadRequest)
                .AddError("비밀번호 형식이 올바르지 않음")
                .Build();
        }

        if(await _userRepo.IsDuplicateAsync(userInfo.Email))
        {
            _logger.LogDebug("이메일 중복");
            return new ResponseMessageBuilder<UserInfoEntity>()
                .AddCode(System.Net.HttpStatusCode.BadRequest)
                .AddError("이메일 중복")
                .Build();
        }

        try
        {
            await _userRepo.SaveItemAsync(userInfo);
        }
        catch
        {
            return new ResponseMessageBuilder<UserInfoEntity>()
                .AddCode(System.Net.HttpStatusCode.InternalServerError)
                .AddError("저장 오류")
                .Build();
        }
        

        return new ResponseMessageBuilder<UserInfoEntity>()
                .AddCode(System.Net.HttpStatusCode.Created)
                .AddData(userInfo)
                .Build();
    }
}