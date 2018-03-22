using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotNetCorePayroll.Data.ViewModels
{
    public class ResetPasswordModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "password is required and empty spaces are not allowed.")]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "password is required and empty spaces are not allowed.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public Guid ResetPasswordKey { get; set; }
    }
}
