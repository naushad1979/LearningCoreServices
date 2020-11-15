using Supplier.Api.Infrastructure;
using Supplier.Api.Models;
using System.Threading.Tasks;

namespace Supplier.Api.Services
{
    public interface ICommandService
    {
       Task<Result> RegisterSupplierAsync(Models.Supplier supplier);
    }
}
