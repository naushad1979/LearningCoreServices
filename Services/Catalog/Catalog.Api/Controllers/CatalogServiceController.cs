using Catalog.Api.Infrastructure;
using Catalog.Api.Models;
using Catalog.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogServiceController : ControllerBase
    {
        private readonly ILogger<CatalogServiceController> logger;
        private readonly ICommandService commandService;
        private readonly IQueryService queryService;

        public CatalogServiceController(ILogger<CatalogServiceController> logger
            , ICommandService commandService, IQueryService queryService)
        {
            this.logger = logger;
            this.commandService = commandService;
            this.queryService = queryService;
        }

        [HttpGet]
        [Route("Get")]
        public string Get()
        {
            return "CatalogService running";
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategoryAsync([FromBody] Category request)
        {
            try
            {
                var result = await commandService.CreateCategoryAsync(request);
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

        [HttpPost]
        [AllowAnonymous]
        [Route("CreateManyCategory")]
        public async Task<IActionResult> CreateManyCategoryAsync([FromBody] IEnumerable<Category> request)
        {
            try
            {
                var result = await commandService.CreateManyCategoryAsync(request);
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
        [Route("GetAllCategories")]
        public async Task<IList<Category>> GetAllCategoriesAsyc()
        {
            var results = await queryService.GetCategoriesAsync();
            return results;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("DeleteCategory")]
        public async Task<IActionResult> DeleteCategoryAsync([FromBody] Category request)
        {
            try
            {
                var result = await commandService.DeleteCategoryAsync(request);
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

        [HttpPost]
        [AllowAnonymous]
        [Route("DeleteAllCategory")]
        public async Task<IActionResult> DeleteAllCategoryAsync()
        {
            try
            {
                var result = await commandService.DeleteAllCategoryAsync();
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


        [HttpPost]
        [AllowAnonymous]
        [Route("CreateSubCategory")]
        public async Task<IActionResult> CreateSubCategoryAsync([FromBody] SubCategory request)
        {
            try
            {
                var result = await commandService.CreateSubCategoryAsync(request);
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

        [HttpPost]
        [AllowAnonymous]
        [Route("CreateManySubCategory")]
        public async Task<IActionResult> CreateManySubCategoryAsync([FromBody] IEnumerable<SubCategory> request)
        {
            try
            {
                var result = await commandService.CreateManySubCategoryAsync(request);
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

        [HttpPost]
        [AllowAnonymous]
        [Route("DeleteSubCategory")]
        public async Task<IActionResult> DeleteSubCategoryAsync([FromBody] SubCategory request)
        {
            try
            {
                var result = await commandService.DeleteSubCategoryAsync(request);
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

        [HttpPost]
        [AllowAnonymous]
        [Route("DeleteAllSubCategory")]
        public async Task<IActionResult> DeleteAllSubCategoryAsync()
        {
            try
            {
                var result = await commandService.DeleteAllSubCategoryAsync();
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
        [Route("GetAllSubCategories")]
        public async Task<IList<SubCategory>> GetSubCategoriesAsync()
        {
            var results = await queryService.GetSubCategoriesAsync();
            return results;
        }

        [HttpGet]
        [Route("GetCategoryItems")]
        public async Task<IList<CategoryItem>> GetCategoryItemsAsyc()
        {
            var results = await queryService.GetCategoryItemsAsync();
            return results;
        }
    }
}
