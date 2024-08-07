using Application.Services.Interfaces;
using Application.ViewModels.BaseModels;
using AutoMapper;
using Doman.Models;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Application.ViewModels.MemberViewModels.RequestModels;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace Application.Services.Implements
{
    public class MemberService : BaseService, IMemberService
    {
        private readonly IConfiguration _configuration;
        public MemberService(IUnitOfWork unitOfWork, IConfiguration configuration) : base(unitOfWork)
        {
            _configuration = configuration;
        }

        #region Login
        public async Task<BaseResponse> Login(LoginRequest loginRequest)
        {
            try
            {
                var members = await _unitOfWork.MemberRepository.GetAsync(filter: m => m.Email.Equals(loginRequest.Email)&&m.Password.Equals(loginRequest.Password));
                var member = members.FirstOrDefault();
                return member == null ? new BaseResponse
                {
                    Message = "Email or password is not correct!",
                    ResponseCode = StatusCodes.Status401Unauthorized
                } : new BaseResponse()
                {
                    ResponseCode = StatusCodes.Status200OK,
                    Data = GenerateAccessToken(member)
                };
            }catch (Exception ex)
            {
                return new BaseResponse { Message = ex.Message,ResponseCode = StatusCodes.Status500InternalServerError};
            }
        }
        #endregion

        #region GenerateAccessToken
        public string GenerateAccessToken(Member member)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, member.Email),
               // new Claim(ClaimTypes.Role, member.ro)
            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? ""));
            var signInCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddSeconds(30),
                signingCredentials: signInCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return tokenString;
        }
        #endregion
    }
}
