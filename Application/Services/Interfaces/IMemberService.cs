using Application.ViewModels.BaseModels;
using Application.ViewModels.MemberViewModels.RequestModels;
using Doman.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IMemberService : IBaseService
    {
       Task<BaseResponse> Login(LoginRequest loginRequest);
    }
}
