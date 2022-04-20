namespace JwtApp.Back.Core.Application.Dto
{
    public class CheckUserResponseDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsExists { get; set; }
    }
}
