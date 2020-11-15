using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.Api.Infrastructure;
using Account.Api.Models;
using Account.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Account.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountServiceController : ControllerBase
    {
        private readonly ICommandService commandService;
        public AccountServiceController(ICommandService commandService)
        {
            this.commandService = commandService;
        }

        [HttpPost]
        [Route("UserRegister")]
        public async Task<IActionResult> Register([FromBody] UserRegistration request)
        {
            try
            {
                var response = await commandService.RegisterAsync(request);
                if (response.ResultCode != ResultCode.Exception)
                {
                    return Ok(response);
                }
                else
                {
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
