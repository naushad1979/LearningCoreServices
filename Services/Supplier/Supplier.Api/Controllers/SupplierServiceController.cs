using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Supplier.Api.Infrastructure;
using Supplier.Api.Services;

namespace Supplier.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierServiceController : ControllerBase
    {
        private readonly ICommandService commandService;
        private readonly IQueryService queryService;
        private readonly ILogger<SupplierServiceController> logger;

        public SupplierServiceController(ILogger<SupplierServiceController> logger, 
            ICommandService commandService, IQueryService queryService)
        {
            this.logger = logger;
            this.commandService = commandService;
            this.queryService = queryService;
        }

        [HttpGet]
        [Route("Get")]
        public string Get()
        {
            return "Supplier Service running";
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IActionResult> RegisterSupplierAsync([FromBody] Models.Supplier request)
        {
            try
            {
                var result = await commandService.RegisterSupplierAsync(request);
                if (result.ResultCode != ResultCode.Exception)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetSuppliers")]
        public async Task<IList<Supplier.Api.Models.Supplier>> GetSuppliersAsync()
        {
            var results = await queryService.GetSuppliersAsync();
            return results;
        }
    }
}
