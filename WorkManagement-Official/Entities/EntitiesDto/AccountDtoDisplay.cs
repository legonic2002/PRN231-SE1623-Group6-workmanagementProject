
namespace Entities.EntitiesDto
{
    public class AccountDtoDisplay
    {
        public int AccountKey { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
        public int? CompanyKey { get; set; }
    }
}
