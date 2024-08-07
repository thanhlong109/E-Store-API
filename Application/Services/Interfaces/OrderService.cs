using Application.Services.Implements;
using AutoMapper;
using Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public class OrderService : BaseService, IOrderService
    {
        public OrderService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
