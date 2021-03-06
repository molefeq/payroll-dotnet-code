﻿using System.ComponentModel.DataAnnotations;

namespace DotNetCorePayroll.Data.ViewModels
{
    public class LoginModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required and empty spaces are not allowed.")]
        [MaxLength(100, ErrorMessage = "Username cannot not be more than 100 characters.")]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "password is required and empty spaces are not allowed.")]
        public string Password { get; set; }
    }
}
