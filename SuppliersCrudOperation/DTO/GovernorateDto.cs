using AutoMapper;
using SuppliersCrudOperation.DAL.Entities;

namespace SuppliersCrudOperation.DTO.Entities
{
    [AutoMap(typeof( Governorate))]
    public class GovernorateDto
    {        
        public long Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
