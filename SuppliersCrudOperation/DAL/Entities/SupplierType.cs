using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuppliersCrudOperation.DAL.Entities
{
    public class SupplierType
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
