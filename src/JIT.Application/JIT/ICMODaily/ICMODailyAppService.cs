//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Linq.Dynamic.Core;
//using System.Threading.Tasks;
//using Abp.Application.Services;
//using Abp.Application.Services.Dto;
//using Abp.AutoMapper;
//using Abp.Linq.Extensions;
//using JIT.JIT.ICMODaily.Dtos;
//using JITEF.DIME2Barcode;
//using Microsoft.EntityFrameworkCore;
//using EntityState = System.Data.Entity.EntityState;

//namespace JIT.JIT.ICMODaily
//{
//    public class ICMODailyAppService:IAsyncCrudAppService<ICMODailyDto,string,ICMODailyGetAllInput,ICMODailyDto,ICMODailyDto,ICMODailyDto,ICMODailyDto>
//    {
//        DIME2BarcodeContext context=new DIME2BarcodeContext();

//        public async Task<ICMODailyDto> Get(ICMODailyDto input)
//        {
//            var entity = EntityFrameworkQueryableExtensions.SingleOrDefaultAsync(context.ICMODaily, p => p.FID == input.FID);

//            if (entity != null)
//            {
//                return entity.MapTo<ICMODailyDto>();
//            }

//            return new ICMODailyDto();
//        }

//        public async Task<PagedResultDto<ICMODailyDto>> GetAll(ICMODailyGetAllInput input)
//        {
//            var query = from a in context.ICMODaily
//                select a;

//            var count =  query.Count();

//            var data =await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();

//            var list = data.MapTo<List<ICMODailyDto>>();

//            return new PagedResultDto<ICMODailyDto>(count,list);

//        }

//        public async Task<ICMODailyDto> Create(ICMODailyDto input)
//        {
//            var entity = input.MapTo<JITEF.DIME2Barcode.ICMODaily>();

//            context.ICMODaily.Add(entity);

//            await context.SaveChangesAsync();

//            return entity.MapTo<ICMODailyDto>();
//        }

//        public async Task<ICMODailyDto> Update(ICMODailyDto input)
//        {
//            var entity = input.MapTo<JITEF.DIME2Barcode.ICMODaily>();

//            context.ICMODaily.Attach(entity);

//            context.Entry(entity).State = EntityState.Modified;

//            await context.SaveChangesAsync();

//            return entity.MapTo<ICMODailyDto>();
//        }

//        public async Task Delete(ICMODailyDto input)
//        {
//            var entity = context.ICMODaily.SingleOrDefault(p => p.FID == input.FID);

//            if (entity != null)
//            {
//                context.ICMODaily.Attach(entity);

//                context.Entry(entity).State = EntityState.Deleted;

//                await context.SaveChangesAsync();
//            }
//        }
//    }
//}