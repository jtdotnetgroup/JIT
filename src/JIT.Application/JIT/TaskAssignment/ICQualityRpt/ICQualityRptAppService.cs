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
using JIT.TaskAssignment.ICMOInspectBill.Dtos;
using JIT.TaskAssignment.ICQualityRpt.Dtos;
using JITEF.DIME2Barcode;


namespace JIT.TaskAssignment.ICQualityRpt
{
    public class ICQualityRptAppService : IAsyncCrudAppService<ICQualityRptDto, string, ICQualityRptGetAllInput, ICQualityRptEditDto, ICQualityRptEditDto>
    {
        private DIME2BarcodeContext context = new DIME2BarcodeContext();
        public async Task<ICQualityRptDto> Get(EntityDto<string> input)
        {
            var entity = context.ICQualityRpt.SingleOrDefault(o => o.FID == input.Id);

            return entity.MapTo<ICQualityRptDto>();

        }

        public async Task<PagedResultDto<ICQualityRptDto>> GetAll(ICQualityRptGetAllInput input)
        {
            var query = from a in context.ICQualityRpt select a;

            query = query.OrderBy(p => p.FID).PageBy(input);
            var count = context.ICQualityRpt.Count();

            var data = query.ToList();

            var list = data.MapTo<List<ICQualityRptDto>>();

            return new PagedResultDto<ICQualityRptDto>(count, list);
        }

        public async Task<ICQualityRptDto> Create(ICQualityRptEditDto input)
        {
            var entity = input.MapTo<JITEF.DIME2Barcode.ICQualityRpt>();
            context.ICQualityRpt.Attach(entity);
            context.ICQualityRpt.Add(entity);
            context.SaveChanges();
            return entity.MapTo<ICQualityRptDto>();
        }

        public async Task<ICQualityRptDto> Update(ICQualityRptEditDto input)
        {
            var entity = input.MapTo<JITEF.DIME2Barcode.ICQualityRpt>();
            context.ICQualityRpt.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
            return entity.MapTo<ICQualityRptDto>();
        }

        public async Task Delete(EntityDto<string> input)
        {
            var entity = context.ICQualityRpt.SingleOrDefault(p => p.FID == input.Id);

            context.ICQualityRpt.Attach(entity);
            context.Entry(entity).State = EntityState.Deleted;
        }
    }
}