using Application.ViewModels.BaseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ShopStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult GetActionResponse(BaseResponse baseResponse)
        {
            switch (baseResponse.ResponseCode)
            {
                case StatusCodes.Status401Unauthorized:
                    {
                        return Unauthorized(baseResponse);
                    }
                case StatusCodes.Status200OK:
                    {
                        return Ok(baseResponse);
                    }
                case StatusCodes.Status400BadRequest:
                    {
                        return BadRequest(baseResponse);
                    }
                case StatusCodes.Status404NotFound:
                    {
                        return NotFound(baseResponse);
                    }
                case StatusCodes.Status500InternalServerError:
                    {
                        return BadRequest(baseResponse);
                    }
                default:
                    {
                        return BadRequest(baseResponse);
                    }
            };
        }
    }
}
