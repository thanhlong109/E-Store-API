using Application.Services.Interfaces;
using Application.ViewModels.MemberViewModels.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShopStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : BaseController
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return GetActionResponse(await _memberService.Login(loginRequest));
        }

        
       
    }
}
