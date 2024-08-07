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
    public class CategoryService : BaseService, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
