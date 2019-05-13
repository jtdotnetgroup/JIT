﻿using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Linq.Extensions;
using JITEF.DIME2Barcode;
using JIT.JIT.TaskAssignment.VW_MODispBillList.Dtos;

namespace JIT.JIT.TaskAssignment.VW_MODispBillList
{
    /// <summary>
    /// 派工任务
    /// </summary>
    public class VW_MODispBillListAppService : IApplicationService
    {
        DIME2BarcodeContext context = new DIME2BarcodeContext();
        /// <summary>
        /// 列表
        /// </summary>
        public PagedResultDto<VW_MODispBillListDto> GetAll(VW_MODispBillListGetAllInput input)
        {
            var query = context.VW_MODispBillList.Where(w => w.操作者 == input.操作者 && w.FStatus == input.FStatus);
            query = input.FStatus == 0 ? query.Where(p => p.FStatus == input.FStatus) : query.Where(p => p.FStatus > 0);
            query = input.FClosed.HasValue ? query.Where(p => p.FClosed == input.FClosed) : query;

            var data = query.OrderBy(input.Sorting).PageBy(input).ToList();
            var count = query.Count();

            var list = data.MapTo<List<VW_MODispBillListDto>>();

            return new PagedResultDto<VW_MODispBillListDto>(count, list);
        }
    }
}
