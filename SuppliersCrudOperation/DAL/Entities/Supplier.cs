using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuppliersCrudOperation.DAL.Entities
{
    public class Supplier 
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [ForeignKey("Type")]
        [Required]
        public long TypeId { get; set; }
        [Required]
        public SupplierType Type { get; set; }
        [ForeignKey("Governorate")]
        public long GovernorateId { get; set; }
        public string EmailAddress { get; set; }
    public Governorate Governorate { get; set; }
    }
}
