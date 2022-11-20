using Icon.Middleware.Infrastructor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Icon.Middleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet("Anonymous")]
        public ApiResult<string> GetAnonymous()
        {
            return new ApiSuccessResult<string>("Anonymous");
        }

        [Authorize]
        [HttpGet("Authorize")]
        public ApiResult<string> GetAuthorize()
        {
            return new ApiSuccessResult<string>("Authorize");
        }

        [Authorize(Roles = "admin")]
        [HttpGet("Admin")]
        public ApiResult<string> GetAdmin()
        {
            return new ApiSuccessResult<string>("Admin");
        }

        [Authorize(Roles = "member")]
        [HttpGet("Member")]
        public ApiResult<string> GetMember()
        {
            return new ApiSuccessResult<string>("Member");
        }
    }
}
