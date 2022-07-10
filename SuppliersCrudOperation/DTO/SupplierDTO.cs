using AutoMapper;
using SuppliersCrudOperation.DAL.Entities;
using System;

namespace SuppliersCrudOperation.DTO.Entities
{
    [AutoMap(typeof(Supplier))]
    public class SupplierDTO
    {
        public SupplierDTO() { }
        public SupplierDTO(Supplier entity) 
        {
            Id = entity.Id;
            Name = entity.Name;
            PhoneNumber = entity.PhoneNumber;
            Address = entity.Address;
            TypeId = entity.TypeId;
            GovernorateId = entity.GovernorateId;
            EmailAddress = entity.EmailAddress;

            GovernorateName = entity.Governorate?.Name;
            SupplierTypeName = entity.Type?.Name;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public long TypeId { get; set; }
        public long GovernorateId { get; set; }
        public string EmailAddress { get; set; }

        public string GovernorateName { get; set; }
        public string SupplierTypeName { get; set; }

        public static void Map(SupplierDTO input, Supplier entity)
        {
            entity.Name = input.Name;
            entity.PhoneNumber = input.PhoneNumber;
            entity.Address = input.Address;
            entity.TypeId = input.TypeId;
            entity.GovernorateId = input.GovernorateId;
            entity.EmailAddress = input.EmailAddress;
        }
    }
}
