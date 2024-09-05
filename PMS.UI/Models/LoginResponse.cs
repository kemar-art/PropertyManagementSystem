namespace PMS.UI.Models
{
    public class LoginResponse
    {
        public bool IsAuthenticate { get; set; }
        public string Role { get; set; } = string.Empty;
    }
}
