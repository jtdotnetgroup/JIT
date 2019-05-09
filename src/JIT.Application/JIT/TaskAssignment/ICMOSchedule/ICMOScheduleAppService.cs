using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Linq.Extensions;
using JIT.JIT.TaskAssignment.ICMOSchedule.Dtos;
using JITEF.DIME2Barcode;
using Microsoft.EntityFrameworkCore;
using EntityState = System.Data.Entity.EntityState;

namespace JIT.JIT.TaskAssignment.ICMOSchedule
{
    public class ICMOScheduleAppService : IAsyncCrudAppService<ICMOScheduleDto, string, ICMOScheduleGetAllInput, ICMOScheduleDto, ICMOScheduleDto, ICMOScheduleDto, ICMOScheduleDto>
    {
        DIME2BarcodeContext context = new DIME2BarcodeContext();

        public async Task<ICMOScheduleDto> Get(ICMOScheduleDto input)
        {
            var entity = await context.ICMOSchedule.SingleOrDefaultAsync(p => p.FID == input.FID);
            return entity.MapTo<ICMOScheduleDto>();
        }

        public async Task<PagedResultDto<ICMOScheduleDto>> GetAll(ICMOScheduleGetAllInput input)
        {
            var query = from a in context.ICMOSchedule
                        select a;

            var count = query.Count();

            var data = query.OrderBy(input.Sorting).PageBy(input).ToList();

            var list = data.MapTo<List<ICMOScheduleDto>>();

            return new PagedResultDto<ICMOScheduleDto>(count, list);
        }

        public async Task<ICMOScheduleDto> Create(ICMOScheduleDto input)
        {
            var entity = input.MapTo<JITEF.DIME2Barcode.ICMOSchedule>();

            context.ICMOSchedule.Attach(entity);

            context.Entry(entity).State = EntityState.Added;
            await context.SaveChangesAsync();

            return entity.MapTo<ICMOScheduleDto>();
        }

        public async Task<ICMOScheduleDto> Update(ICMOScheduleDto input)
        {
            var entity = input.MapTo<JITEF.DIME2Barcode.ICMOSchedule>();

            context.ICMOSchedule.Attach(entity);

            context.Entry(entity).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return entity.MapTo<ICMOScheduleDto>();
        }

        public async Task Delete(ICMOScheduleDto input)
        {
            var entity = await context.ICMOSchedule.SingleOrDefaultAsync(p=>p.FID==input.FID);

            if (entity != null)
            {
                context.ICMOSchedule.Attach(entity);

                context.Entry(entity).State = EntityState.Deleted;

                await context.SaveChangesAsync();
            }
        }
    }
}