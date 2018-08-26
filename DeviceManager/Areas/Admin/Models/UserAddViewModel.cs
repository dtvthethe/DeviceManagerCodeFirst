using DeviceManager.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DeviceManager.Areas.Admin.Models
{
    public class UserAddViewModel : User
    {
        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(256, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public override string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(256, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }

        public ICollection<Role> Roles { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}