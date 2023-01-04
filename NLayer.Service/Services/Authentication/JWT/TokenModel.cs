namespace NLayer.Service.Services.Authentication.JWT;

public class TokenModel
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}