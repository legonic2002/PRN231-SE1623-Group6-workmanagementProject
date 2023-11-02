using System;
using System.Collections.Generic;

namespace Entities.EntitiesDto
{
    public partial class AccountDtoChangeable
    {
        public int AccountKey { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmNewPassword { get; set; }
    }
}
