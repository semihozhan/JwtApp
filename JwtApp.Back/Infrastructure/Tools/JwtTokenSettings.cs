namespace JwtApp.Back.Infrastructure.Tools
{
    public class JwtTokenSettings
    {
        /*
         *   ValidAudience = "localhost",
        ValidIssuer = "localhost",
        ClockSkew = TimeSpan.Zero,
        ValidateLifetime=true,
        IssuerSigningKey =new SymmetricSecurityKey(Encoding.UTF8.GetBytes("semihsemihsemih1.")),
        ValidateIssuerSigningKey=true
         */

        public const string Issuer = "http://localhost";
        public const string Audience = "http://localhost";
        public const string Key = "semihsemihsemih1.";
        public const int Expire = 30;
    }
}
