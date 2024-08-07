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
    public class ProductService : BaseService, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
