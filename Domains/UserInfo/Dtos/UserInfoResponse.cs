using Newtonsoft.Json;

namespace TodoApi.Domains.UserInfo.Dtos;

public class UserInfoResponse
{
    [JsonProperty("userId")]
    public required string UserId {get; set;}

    [JsonProperty("email")]
    public required string Email {get; set;}

    [JsonProperty("socialUserYn")]
    public bool SocialUseYn {get; set;}
}