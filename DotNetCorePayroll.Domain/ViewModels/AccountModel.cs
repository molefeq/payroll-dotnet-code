using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetCorePayroll.Data.ViewModels
{
    public class AccountModel
    {
        public long? Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required and empty spaces are not allowed.")]
        [MaxLength(100, ErrorMessage = "Username cannot not be more than 100 characters.")]
        public string Username { get; set; }

        public string Password { get; set; }

        [Required(ErrorMessage = "Firstname is required.")]
        [MaxLength(100, ErrorMessage = "Firstname cannot not be more than 100 characters.")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Lastname is required.")]
        [MaxLength(100, ErrorMessage = "Lastname cannot not be more than 100 characters.")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress(ErrorMessage = "Email Address must be a valid email address.")]
        [MaxLength(100, ErrorMessage = "Email Address cannot not be more than 500 characters.")]
        public string EmailAddress { get; set; }

        public string ContactNumber { get; set; }

        [Required(ErrorMessage ="Organisation is required.")]
        public long OrganisationId { get; set; }

        public long? CompanyId { get; set; }

        [Required(ErrorMessage = "Role is required.")]
        public long RoleId { get; set; }

        public Guid? ForgotPasswordKey { get; set; }

        public long? CreateUserId { get; set; }
    }
}
