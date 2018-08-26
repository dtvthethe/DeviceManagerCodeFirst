using DeviceManager.Models.Abstract;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeviceManager.Models
{
    [Table("Providers")]
    public class Provider : IIDKeyName
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        [DisplayName("Provider")]
        public string Name { get; set; }

        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
