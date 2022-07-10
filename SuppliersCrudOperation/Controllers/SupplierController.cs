using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SuppliersCrudOperation.BLL.Interfaces;
using SuppliersCrudOperation.DAL.Entities;
using SuppliersCrudOperation.DTO.Entities;
using SuppliersCrudOperation.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuppliersCrudOperation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupplierController : ControllerBase
    {


        private readonly ILogger<SupplierController> _logger;

        private readonly ISupplierService supplierService;

        public SupplierController(ILogger<SupplierController> logger, ISupplierService supplierService)
        {
            _logger = logger;
            this.supplierService = supplierService;
        }

        [HttpPost]
        [Route("getall")]
        public async Task<IActionResult> GetAll(SupplierFilterDTO filter)
        {
            var pagedSuppliers = await this.supplierService.GetAll(filter);

            return Ok(pagedSuppliers);
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(SupplierDTO input)
        {
            SupplierDTO supplier = await this.supplierService.InsertOrUpdate(input);
            return Ok(supplier);
        }
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(SupplierDTO input)
        {
            SupplierDTO supplier = await this.supplierService.InsertOrUpdate(input);
            return Ok(supplier);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var res = await this.supplierService.Delete(id);
            return Ok(res);
        }

        [HttpGet]
        [Route("getbyid/{id}")]

        public async Task<IActionResult> GetById(long id)
        {
            var suppliers = await this.supplierService.GetById(id);
            return Ok(suppliers);
        }
        [HttpGet]
        [Route("getsuppliertypes")]
        public async Task<List<SupplierTypeDto>> GetSupplierTypes(){
          
            return await supplierService.GetSupplierTypes();
            }
        [HttpGet]
        [Route("getgovernorates")]
        public async Task<List<GovernorateDto>> GetGovernorates() 
        {
            return await supplierService.GetGovernorates();
        }
       


    }
}
