using DeviceManager.Models.Abstract;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeviceManager.Models
{
    [Table("Units")]
    public class Unit : IIDKeyName
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        [DisplayName("Unit")]
        public string Name { get; set; }

        public virtual ICollection<Device> Devices { get; set; }
    }
}
