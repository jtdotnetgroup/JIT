using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Linq.Extensions;
using JIT.JIT.TaskAssignment.ICMaterialPicking.Dtos;
using JITEF.DIME2Barcode;

namespace JIT.JIT.TaskAssignment.ICMaterialPicking
{
    /// <summary>
    /// 派工异常记录  IAsyncCrudAppService《全部，添加，修改，明细，删除》
    /// </summary>
    public class ICMaterialPickingAppService :IAsyncCrudAppService<ICMaterialPickingDto, string, ICMaterialPickingGetAllInput,
        ICMaterialPickingCreateDto, ICMaterialPickingUpdateDto, ICMaterialPickingGetDto, ICMaterialPickingDeleteDto>
    {
        DIME2BarcodeContext context =new DIME2BarcodeContext();
        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <param name="input">条件</param>
        /// <returns></returns>
        public async Task<PagedResultDto<ICMaterialPickingDto>> GetAll(ICMaterialPickingGetAllInput input)
        {
            var query = from a in context.ICMaterialPicking.OrderBy(p => p.FID).PageBy(input)
                select a;

            query = query.OrderBy(p => p.FID).PageBy(input);

            var count = await context.ICMaterialPicking.CountAsync();

            var data = await query.ToListAsync();

            var list = data.MapTo<List<ICMaterialPickingDto>>();

            return new PagedResultDto<ICMaterialPickingDto>(count, list);

        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="input">条件</param>
        /// <returns></returns>
        public async Task<ICMaterialPickingDto> Create(ICMaterialPickingCreateDto input)
        {
            var entity = input.MapTo<JITEF.DIME2Barcode.ICMaterialPicking>();

            context.ICMaterialPicking.Attach(entity);

            context.ICMaterialPicking.Add(entity);

            await context.SaveChangesAsync();

            return entity.MapTo<ICMaterialPickingDto>();

        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="input">条件</param>
        /// <returns></returns>
        public async Task<ICMaterialPickingDto> Update(ICMaterialPickingUpdateDto input)
        {
            var entity = input.MapTo<JITEF.DIME2Barcode.ICMaterialPicking>();

            context.ICMaterialPicking.Attach(entity);

            context.Entry(entity).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return entity.MapTo<ICMaterialPickingDto>();
        }
        /// <summary>
        /// 获取明细
        /// </summary>
        /// <param name="input">条件</param>
        /// <returns></returns>
        public async Task<ICMaterialPickingDto> Get(ICMaterialPickingGetDto input)
        {
            var entity = context.ICMaterialPicking.SingleOrDefault(p => p.FID == input.FID);
            return entity.MapTo<ICMaterialPickingDto>();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="input">条件</param>
        /// <returns></returns>
        public async Task Delete(ICMaterialPickingDeleteDto input)
        {
            var entity = await
                context.ICMaterialPicking.SingleOrDefaultAsync(p =>
                    p.FID == input.FID);

            context.ICMaterialPicking.Attach(entity);

            context.Entry(entity).State = EntityState.Deleted;

            await context.SaveChangesAsync();
        }
        /// <summary>
        /// 删除全部
        /// </summary>
        /// <param name="input">条件</param>
        /// <returns></returns>
        public async Task AllDelete(ICMaterialPickingAllDeleteDto input)
        {
            var entity = context.ICMaterialPicking.Where(w => input.Id.Any(a => a.Equals(w.FID)));
            context.Entry(entity).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }
    }

}
