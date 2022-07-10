namespace SuppliersCrudOperation.DTO.Entities
{
    public class SupplierFilterDTO:BaseFilter
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public long TypeId { get; set; }
        public long GovernorateId { get; set; }
    }
}
