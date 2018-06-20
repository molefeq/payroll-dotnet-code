using System.ComponentModel.DataAnnotations;

namespace DotNetCorePayroll.Data.ViewModels
{
    public class RoleModel
    {
        public long? Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Role name is required.")]
        [MaxLength(50, ErrorMessage = "Role name cannot not be more than 50 characters.")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Role code is required and empty spaces are not allowed.")]
        [MaxLength(20, ErrorMessage = "Role code cannot not be more than 20 characters.")]
        public string Code { get; set; }
    }
}
