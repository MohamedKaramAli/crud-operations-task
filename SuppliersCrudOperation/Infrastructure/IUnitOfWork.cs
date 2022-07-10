using System.Threading.Tasks;

namespace SuppliersCrudOperation.Infrastructure
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }

}
