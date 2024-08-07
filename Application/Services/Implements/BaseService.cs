using Application.Services.Interfaces;
using AutoMapper;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Implements
{
    public class BaseService : IBaseService
    {
        protected readonly IUnitOfWork _unitOfWork;

        protected readonly IMapper _mapper;

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_mapper = mapper;
        }
    }
}
