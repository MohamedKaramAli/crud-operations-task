using AutoMapper;
using SuppliersCrudOperation.DAL.Entities;

namespace SuppliersCrudOperation.DTO.Entities
{
    [AutoMap(typeof(SupplierType))]
    public class SupplierTypeDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
