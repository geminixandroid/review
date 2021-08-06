namespace SecondService.Models
{
    public class User
    {
        public int UserId { get; set; }

        public int OrganizationId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string SecondName { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
