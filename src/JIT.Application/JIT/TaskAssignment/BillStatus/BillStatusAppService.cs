using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using JIT.JIT.TaskAssignment.BillStatus.Dtos;
using JITEF.DIME2Barcode;

namespace JIT.JIT.TaskAssignment.BillStatus
{
    public class BillStatusAppService:IAsyncCrudAppService<BillStatusDto,int,BillStatusGetAllInput,BillStatusDto,BillStatusDto,BillStatusDto,BillStatusDto>
    {
        DIME2BarcodeContext context=new DIME2BarcodeContext();

        public async  Task<BillStatusDto> Get(BillStatusDto input)
        {
            var entity = await context.BillStatus.SingleOrDefaultAsync(p => p.FTranType == input.FTranType && p.FStatus == input.FStatus);

            return entity.MapTo<BillStatusDto>();
        }

        public async  Task<PagedResultDto<BillStatusDto>> GetAll(BillStatusGetAllInput input)
        {
            var query = from a in context.BillStatus
                select a;

            query = query.OrderBy(p=>p.FTranType).PageBy(input);

            var count = await context.BillStatus.CountAsync();

            var data = await query.ToListAsync();

            var list = data.MapTo<List<BillStatusDto>>();

            return new PagedResultDto<BillStatusDto>(count,list);

        }

        public async Task<BillStatusDto> Create(BillStatusDto input)
        {
            var entity = input.MapTo<JITEF.DIME2Barcode.BillStatus>();

            context.BillStatus.Attach(entity);

            context.BillStatus.Add(entity);

            await context.SaveChangesAsync();

            return entity.MapTo<BillStatusDto>();

        }

        public async Task<BillStatusDto> Update(BillStatusDto input)
        {
            var entity = input.MapTo<JITEF.DIME2Barcode.BillStatus>();

            context.BillStatus.Attach(entity);

            context.Entry(entity).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return entity.MapTo<BillStatusDto>();
        }

        public async Task Delete(BillStatusDto input)
        {
            var entity = await 
                context.BillStatus.SingleOrDefaultAsync(p =>
                    p.FTranType == input.FTranType && p.FStatus == input.FStatus);

            context.BillStatus.Attach(entity);

            context.Entry(entity).State = EntityState.Deleted;

            await context.SaveChangesAsync();
        }
        
    }
}