using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuppliersCrudOperation.DTO
{
    public class BaseFilter
    {
        public int page { get; set; }
        public int PageCount { get; set; }
        public string Sort { get; set; }
        public string SortDir { get; set; }
    }
}
