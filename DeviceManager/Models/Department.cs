using DeviceManager.Models.Abstract;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeviceManager.Models
{
    [Table("Departments")]
    public class Department : IIDKeyName
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        [DisplayName("Department")]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
