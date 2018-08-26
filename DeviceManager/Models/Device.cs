using DeviceManager.Models.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeviceManager.Models
{
    [Table("Devices")]
    public class Device : Auditable, IIDKeyName
    {

        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        public int Quantity { get; set; }

        public int IDCategory { get; set; }

        public int IDUnit { get; set; }

        public int IDStatus { get; set; }

        public decimal Price { get; set; }

        [Column(TypeName = "ntext")]
        public string Info { get; set; }

        [ForeignKey("IDCategory")]
        public virtual Category Category { get; set; }

        [ForeignKey("IDUnit")]
        public virtual Unit Unit { get; set; }

        [ForeignKey("IDStatus")]
        public virtual Status Status { get; set; }

        public virtual ICollection<DeliveryDetail> DeliveryDetails { get; set; }

        public virtual ICollection<ReceiptDetail> ReceiptDetails { get; set; }

    }
}
