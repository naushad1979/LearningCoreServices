using Supplier.Api.Database.Repositories;
using Supplier.Api.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Api.Services
{
    public class QueryService : IQueryService
    {
        private readonly IRepositoty repositoty;
        public QueryService(IRepositoty repositoty)
        {
            this.repositoty = repositoty;
        }
        public async Task<IList<Supplier.Api.Models.Supplier>> GetSuppliersAsync()
        {
            return await repositoty.GetSuppliersAsync();
        }           
    }
}
