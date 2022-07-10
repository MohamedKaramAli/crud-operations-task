using SuppliersCrudOperation.DTO.Entities;
using SuppliersCrudOperation.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuppliersCrudOperation.BLL.Interfaces
{
    public interface ISupplierService
    {
        Task<PagedResult<SupplierDTO>> GetAll(SupplierFilterDTO filter);
        Task<SupplierDTO> InsertOrUpdate(SupplierDTO input);
        Task<bool> Delete(long id);
        Task<SupplierDTO> GetById(long id);
        Task<List<SupplierTypeDto>> GetSupplierTypes();
        Task<List<GovernorateDto>> GetGovernorates();
    }
}
