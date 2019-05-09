using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore.Repositories;
using Abp.Linq.Extensions;
using JIT.TaskAssignment.VW_MOBillList.Dtos;
using JITEF.DIME2Barcode;
using JTInformationSystem.JIT.TaskAssignment.VW_MOBillList.Dtos;
using Microsoft.EntityFrameworkCore;

namespace JTInformationSystem.JIT.TaskAssignment.VW_MOBillList
{
    public class VW_MOBillListAppService :IApplicationService
    {
        DIME2BarcodeContext context =new  DIME2BarcodeContext();
        public async  Task<PagedResultDto<VW_MOBillListDto>> GetAll(VW_MOBIllListGetAllInput input)
        {
            var query = from a in context.VW_MOBillList
                select a;

            var data = query.OrderBy(input.Sorting).PageBy(input);
            var count =  query.Count();

            var list = data.MapTo<List<VW_MOBillListDto>>();

            return new PagedResultDto<VW_MOBillListDto>(count,list);
        }


       
    }
}