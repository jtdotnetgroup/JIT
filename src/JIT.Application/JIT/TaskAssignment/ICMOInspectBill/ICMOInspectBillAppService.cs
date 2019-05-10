using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using JIT.TaskAssignment.ICMOInspectBill;
using JIT.TaskAssignment.ICMOInspectBill.Dtos;
using JITEF.DIME2Barcode;

namespace JIT.TaskAssignment.ICMOInspectBill
{
    public class ICMOInspectBillAppService : IAsyncCrudAppService< ICMOInspectBillDto, string, ICMOInspectBillGetAllInput, ICMOInspectBillEditDto, ICMOInspectBillEditDto>
    {
        private DIME2BarcodeContext context = new DIME2BarcodeContext();
        public async Task<ICMOInspectBillDto> Get(EntityDto<string> input)
        {
            var entity = context.ICMOInspectBill.SingleOrDefault(o => o.FID == input.Id);

            return entity.MapTo<ICMOInspectBillDto>();


        }

        public async Task<PagedResultDto<ICMOInspectBillDto>> GetAll(ICMOInspectBillGetAllInput input)
        {
            var query = from a in context.ICMOInspectBill select a;

            query = query.OrderBy(p => p.FID).PageBy(input);
            var count = context.ICMOInspectBill.Count();

            var data = query.ToList();

            var list = data.MapTo<List<ICMOInspectBillDto>>();

            return  new PagedResultDto<ICMOInspectBillDto>(count, list);
        }

        public async Task<ICMOInspectBillDto> Create(ICMOInspectBillEditDto input)
        {
            var entity = input.MapTo<JITEF.DIME2Barcode.ICMOInspectBill>();
            context.ICMOInspectBill.Attach(entity);
            context.ICMOInspectBill.Add(entity);
            context.SaveChanges();
            return entity.MapTo<ICMOInspectBillDto>();
        }

        public async Task<ICMOInspectBillDto> Update(ICMOInspectBillEditDto input)
        {
            var entity = input.MapTo<JITEF.DIME2Barcode.ICMOInspectBill>();
            context.ICMOInspectBill.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity.MapTo<ICMOInspectBillDto>();
        }

        public async Task Delete(EntityDto<string> input)
        {
            var entity = context.ICMOInspectBill.SingleOrDefault(p=>p.FID==input.Id);

            context.ICMOInspectBill.Attach(entity);
            context.Entry(entity).State = EntityState.Deleted;
          
        }
    }
}
