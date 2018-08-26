using DeviceManager.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeviceManager.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [MaxLength(100)]
        [Column(TypeName = "nvarchar")]
        public string Username { get; set; }

        [MaxLength(256)]
        [Required]
        public virtual string Password { get; set; }

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
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDay { set; get; }

        public int IDDepartment { get; set; }

        public int IDRole { get; set; }

        [ForeignKey("IDDepartment")]
        public Department Department { get; set; }

        [ForeignKey("IDRole")]
        public Role Role { get; set; }

        public virtual ICollection<Delivery> Deliveries { get; set; }
        public virtual ICollection<Device> Devices { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
