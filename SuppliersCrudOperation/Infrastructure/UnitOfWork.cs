using SuppliersCrudOperation.DAL;
using System;
using System.Threading.Tasks;

namespace SuppliersCrudOperation.Infrastructure
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SuppliersDbContext _context;
      //  private readonly ILogger _logger;

        

        public UnitOfWork(SuppliersDbContext context)// ILoggerFactory loggerFactory
        {
            _context = context;
            
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
