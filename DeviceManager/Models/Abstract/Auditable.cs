using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeviceManager.Models.Abstract
{
    public abstract class Auditable : IAuditable
    {
        private DateTime _createdDate;
        private DateTime _updatedDate;

        [Required]
        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }

        [Column(TypeName = "ntext")]
        public string Note { get; set; }

        public DateTime CreatedDate
        {
            set
            {
                _createdDate = DateTime.Now;
            }
            get
            {
                return _createdDate;
            }
        }

        public DateTime? UpdatedDate
        {
            set
            {
                _updatedDate = DateTime.Now;
            }
            get
            {
                return _updatedDate;
            }
        }

        

    }
}