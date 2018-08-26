using DeviceManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeviceManager.Areas.Admin.Models
{
    public class UserEditViewModel
    {
        [Key]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar")]
        public string Username { get; set; }

        [StringLength(256, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [StringLength(256, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }

        [Index("EmailIndex", IsUnique = true)]
        [MaxLength(256)]
        public string Email { get; set; }

        [MaxLength(256)]
        [Required]
        public string FullName { get; set; }

        [MaxLength(256)]
        [Required]
        public string Address { set; get; }

        [Required]
        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDay { set; get; }

        public int IDDepartment { get; set; }

        public int IDRole { get; set; }

        [ForeignKey("IDDepartment")]
        public Department Department { get; set; }

        [ForeignKey("IDRole")]
        public Role Role { get; set; }

        public ICollection<Role> Roles { get; set; }

        public ICollection<Department> Departments { get; set; }
    }
}