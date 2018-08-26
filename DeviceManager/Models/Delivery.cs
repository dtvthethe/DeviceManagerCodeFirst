using DeviceManager.Models.Abstract;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeviceManager.Models
{
    [Table("Deliveries")]
    public class Delivery : Auditable, IIDKey
    {

        [Key]
        public int ID { get; set; }

        [MaxLength(100)]
        [Column(TypeName = "nvarchar")]
        [DisplayName("Delivery To User")]
        public string DeliveryToUser { set; get; }

        [MaxLength(100)]
        [Column(TypeName = "nvarchar")]
        [DisplayName("Delivery From User")]
        public string DeliveryFromUser { set; get; }

        [ForeignKey("DeliveryToUser")]
        public User UserDeliveryTo { get; set; }

        [ForeignKey("DeliveryFromUser")]
        public User UserDeliveryFrom { get; set; }

        public virtual ICollection<DeliveryDetail> DeliveryDetails { get; set; }

    }
}