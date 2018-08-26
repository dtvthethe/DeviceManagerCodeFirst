using DeviceManager.Models.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeviceManager.Models
{
    [Table("ReceiptDetails")]
    public class ReceiptDetail : IIDKey
    {

        [Key]
        public int ID { get; set; }

        public int IDReceipt { get; set; }

        public int IDDevice { get; set; }

        public int Quantity { get; set; }

        [ForeignKey("IDDevice")]
        public Device Device { get; set; }

        [ForeignKey("IDReceipt")]
        public Receipt Receipt { get; set; }

    }
}