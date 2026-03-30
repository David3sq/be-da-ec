namespace AuthJWT.Dto
{
    public class UtentiDto
    {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Role { get; set; } = "User";
        public string IsEnabled { get; set; } = "False";
    }
}

