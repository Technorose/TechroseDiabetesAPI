using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace TechroseDemo
{
    public class TokenUtility
    {
        public static TokenCreateModelResult CreateToken(TokenCreateModelArgs args)
        {
            TokenCreateModelResult result = new();

            SymmetricSecurityKey secretKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Constants.tConstant_SecretKey));

            SigningCredentials credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: "*azurewebsites.net",
                audience: "*azurewebsites.net",
                claims: args.Claims,
                expires: DateTime.UtcNow.AddDays(CoreStaticVars.TokenExpirationTime),
                signingCredentials: credentials
            );

            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            result.Token = tokenString;

            return result;
        }

        public static TokenDecodeModelResult DecodeToken(TokenDecodeModelArgs args)
        {
            TokenDecodeModelResult result = new();

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            JwtSecurityToken token = handler.ReadJwtToken(args.AuthorizationToken);

            result.Claims = token.Claims.Select(claim => (claim.Type, claim.Value)).ToDictionary();
            result.Issuer = token.Issuer;
            result.Audience = token.Audiences.ToList();
            result.SignatureAlgorithm = token.SignatureAlgorithm;

            return result;
        }
    }
}
