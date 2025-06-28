namespace SPC.Api.Controllers.DTO_s.Account
{
    public class RegisterRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Initials { get; set; }
        public Guid SiteId { get; set; }
    }
}
