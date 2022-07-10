using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SuppliersCrudOperation.BLL.Interfaces;
using SuppliersCrudOperation.DAL.Entities;
using SuppliersCrudOperation.DTO.Entities;
using SuppliersCrudOperation.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuppliersCrudOperation.BLL.Services
{
    public class SupplierService:ISupplierService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IGenericRepository<Supplier> supplierRep;
        private readonly IGenericRepository<SupplierType> _typeRep;
        private readonly IGenericRepository<Governorate> _governorateRep;
        private readonly IMapper mapper;

        public SupplierService(IUnitOfWork unitOfWork, IGenericRepository<Supplier> supplierRep, IGenericRepository<SupplierType> typeRep, IGenericRepository<Governorate> governorateRep, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.supplierRep = supplierRep;
            _typeRep = typeRep;
            _governorateRep = governorateRep;
            this.mapper = mapper;
        }

        public async Task<bool> Delete(long id)
        {
            var entity =  supplierRep.GetById(id).Result;
            var res= this.supplierRep.Delete(entity);
            await unitOfWork.CompleteAsync();
            return res;
        }

        public async Task<PagedResult<SupplierDTO>> GetAll(SupplierFilterDTO filter) 
        {


            if (filter.PageCount == 0)
                filter.PageCount = 10;

            PagedResult<SupplierDTO> paged = new PagedResult<SupplierDTO>();
            var query = this.supplierRep.All();

            if (filter.Name != null) query = query.Where(v => v.Name.Contains(filter.Name));
            query = query.Include(v => v.Governorate)
                .Include(v => v.Type);

            query = sortQuery(filter,query);

            paged.TotalCount = query.Count();

            query = query.Skip(filter.page * filter.PageCount).Take(filter.PageCount);



            var List = await query.ToListAsync();
            var Dtos = List.Select(v => new SupplierDTO(v)).ToList();
            paged.Items = Dtos;

            return paged;
        }

        private IQueryable<Supplier> sortQuery(SupplierFilterDTO filter,IQueryable<Supplier> query)
        {
            if (filter.Sort?.ToLower() == "name")
                query = filter.SortDir=="asc" ? query.OrderBy(v=>v.Name): query.OrderByDescending(v => v.Name);

            if (filter.Sort?.ToLower() == "governorateid")
                query = filter.SortDir == "asc" ? query.OrderBy(v => v.Governorate.Name) : query.OrderByDescending(v => v.Governorate.Name);


            if (filter.Sort?.ToLower() == "typeid")
                query = filter.SortDir == "asc" ? query.OrderBy(v => v.Type.Name) : query.OrderByDescending(v => v.Type.Name);
            return query;
        }

        public async Task<SupplierDTO> GetById(long id)
        {
            var entity = await this.supplierRep.GetById(id);
            return mapper.Map<SupplierDTO>(entity);
        }

        public async Task<List<GovernorateDto>> GetGovernorates()
        {
            var list =await this._governorateRep.All().ToListAsync();
            var dtos = list.Select(v => mapper.Map<GovernorateDto>(v)).ToList();
            return dtos;
        }

        public async Task<List<SupplierTypeDto>> GetSupplierTypes()
        {
            var list = await this._typeRep.All().ToListAsync();
            var dtos = list.Select(v => mapper.Map<SupplierTypeDto>(v)).ToList();
            return dtos;
        }

        public async Task<SupplierDTO> InsertOrUpdate(SupplierDTO input)
        {
            Supplier entity = input.Id > 0 ?
                await this.supplierRep.GetById(input.Id) :
                new Supplier();

            SupplierDTO.Map(input,entity);


            if (entity.Id > 0)
                entity = this.supplierRep.Update(entity);
            else
                entity = await this.supplierRep.Add(entity);

            await this.unitOfWork.CompleteAsync();
            return mapper.Map<SupplierDTO>(entity);
        }
    }
}
