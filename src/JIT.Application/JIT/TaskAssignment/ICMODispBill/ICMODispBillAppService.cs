﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Linq.Extensions;
using JIT.JIT.TaskAssignment.VW_MOBillList.Dtos;
using JIT.TaskAssignment.ICMODispBill.Dtos;
using JITEF.DIME2Barcode;
using Microsoft.EntityFrameworkCore;
using EntityState = System.Data.Entity.EntityState;

namespace JIT.TaskAssignment.ICMODispBill
{
   
    public class ICMODispBillAppService : IAsyncCrudAppService<ICMODispBillDto, string, ICMODispBillGetAllInput, ICMODispBillEditDto, ICMODispBillEditDto>
    {
   
        DIME2BarcodeContext context = new DIME2BarcodeContext();


        //查询数据
        public async Task<PagedResultDto<VM_ICMODispBillDto>> GetDaTask(ICMODispBillGetAllInput input)
        {

            var query = from a in context.VM_MOICMODispBill
                select a;

            var data = query.OrderBy(input.Sorting).Skip(input.MaxResultCount * (input.SkipCount - 1)).Take(input.MaxResultCount).ToList();

            var count = query.Count();

            var list = data.MapTo<List<VM_ICMODispBillDto>>();

            return new PagedResultDto<VM_ICMODispBillDto>(count, list);
        }





        public async Task<ICMODispBillDto> Get(EntityDto<string> input)
        {
            var  quers =  context.ICMODispBill.SingleOrDefault(o => o.FID == input.Id);

            return quers.MapTo<ICMODispBillDto>();

        }

        public async Task<PagedResultDto<ICMODispBillDto>> GetAll(ICMODispBillGetAllInput input)
        {
            var query = from a in context.ICMODispBill
                select a;

            query = query.OrderBy(p => p.FID).PageBy(input);

            var count =  context.ICMODispBill.Count();

            var data = query.ToList();

            var list = data.MapTo<List<ICMODispBillDto>>();

            return new PagedResultDto<ICMODispBillDto>(count, list);
        }

        public async Task<ICMODispBillDto> Create(ICMODispBillEditDto input)
        {

            var entity = input.MapTo<JITEF.DIME2Barcode.ICMODispBill>();

            context.ICMODispBill.Attach(entity);
            context.ICMODispBill.Add(entity);

             context.SaveChanges();

            return entity.MapTo<ICMODispBillDto>();
           

        }

        public async Task<ICMODispBillDto> Update(ICMODispBillEditDto input)
        {
            var entity = input.MapTo<JITEF.DIME2Barcode.ICMODispBill>();
            context.ICMODispBill.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();


            return entity.MapTo<ICMODispBillDto>();


        }

        public async Task Delete(EntityDto<string> input)
        {
            var quers = context.ICMODispBill.SingleOrDefault(o => o.FID == input.Id);
            context.ICMODispBill.Attach(quers);
            context.Entry(quers).State = EntityState.Deleted;
        }
    }
}
