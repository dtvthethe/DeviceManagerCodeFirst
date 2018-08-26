using DeviceManager.Models.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeviceManager.Models
{
    [Table("Receipts")]
    public class Receipt : Auditable, IIDKey
    {

        [Key]
        public int ID { get; set; }

        public int IDProvider { get; set; }

        [ForeignKey("IDProvider")]
        public Provider Provider { get; set; }

        public virtual ICollection<ReceiptDetail> ReceiptDetails { get; set; }

    }
}