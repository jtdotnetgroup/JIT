using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Linq.Extensions;
using JIT.JIT.TaskAssignment.TB_BadItemRelation.Dtos;
using JITEF.DIME2Barcode;

namespace JIT.JIT.TaskAssignment.TB_BadItemRelation
{
    public class TB_BadItemRelationAppService : IAsyncCrudAppService<TB_BadItemRelationDto, int, TB_BadItemRelationGetAllInput, TB_BadItemRelationEditDto, TB_BadItemRelationEditDto>
    {
        private DIME2BarcodeContext context = new DIME2BarcodeContext();
        public  async Task<TB_BadItemRelationDto> Create(TB_BadItemRelationEditDto input)
        {
            var entity = input.MapTo<JITEF.DIME2Barcode.TB_BadItemRelation>();
            context.TB_BadItemRelation.Attach(entity);
            context.TB_BadItemRelation.Add(entity);
            context.SaveChanges();
            return entity.MapTo<TB_BadItemRelationDto>();
        }

        public async Task Delete(EntityDto<int> input)
        {
            var entity = context.TB_BadItemRelation.SingleOrDefault(p => p.FID == input.Id);

            context.TB_BadItemRelation.Attach(entity);
            context.Entry(entity).State = EntityState.Deleted;
        }

        public async Task<TB_BadItemRelationDto> Get(EntityDto<int> input)
        {
            var entity = context.TB_BadItemRelation.SingleOrDefault(o => o.FID == input.Id);

            return entity.MapTo<TB_BadItemRelationDto>();
        }

        public async Task<PagedResultDto<TB_BadItemRelationDto>> GetAll(TB_BadItemRelationGetAllInput input)
        {
             var query = from a in context.TB_BadItemRelation select a;

            query = query.OrderBy(p => p.FID).PageBy(input);
            var count = context.TB_BadItemRelation.Count();

            var data = query.ToList();

            var list = data.MapTo<List<TB_BadItemRelationDto>>();

            return new PagedResultDto<TB_BadItemRelationDto>(count, list);
        }

        public async Task<TB_BadItemRelationDto> Update(TB_BadItemRelationEditDto input)
        {
            var entity = input.MapTo<JITEF.DIME2Barcode.TB_BadItemRelation>();
            context.TB_BadItemRelation.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity.MapTo<TB_BadItemRelationDto>();
        }
    }
}
