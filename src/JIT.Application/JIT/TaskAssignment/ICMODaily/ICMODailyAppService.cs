using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using JIT.JIT.ICMODaily.Dtos;
using JITEF.DIME2Barcode;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using EntityState = System.Data.Entity.EntityState;

namespace JIT.JIT.ICMODaily
{
    public class ICMODailyAppService:ApplicationService
        //,IAsyncCrudAppService<ICMODailyDto,string,ICMODailyGetAllInput, ICMODailyCreatDto, ICMODailyDto,ICMODailyInput, ICMODailyInput>
    {
        DIME2BarcodeContext context = new DIME2BarcodeContext();

        public async Task<ICMODailyDto> Get(ICMODailyInput input)
        {
            var entity = context.ICMODaily.SingleOrDefault(p => p.FID == input.FID);

            if (entity != null)
            {
                return entity.MapTo<ICMODailyDto>();
            }

            return new ICMODailyDto();
        }

        public async Task<PagedResultDto<ICMODailyDto>> GetAll(ICMODailyGetAllInput input)
        {
            var query = from a in context.ICMODaily
                        select a;

            var count = query.Count();

            var data = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();

            var list = data.MapTo<List<ICMODailyDto>>();

            return new PagedResultDto<ICMODailyDto>(count, list);

        }

        public ICMODailyDto Create(ICMODailyCreatDto input)
        {
            // 检查是否已存在任务计划单
            var schedule = context.ICMOSchedule.SingleOrDefault(p =>
                p.FMOBillNo == input.FMOBillNo && p.FMOInterID == input.FMOInterID);
            //不存在则新建
            if (schedule == null)
            {
                schedule = new ICMOSchedule()
                {
                    FID = Guid.NewGuid().ToString(),
                    FBillNo = "SC" + DateTime.Now.ToString("yyyyMMddHHmmss"),//计划单号
                    FMOInterID = input.FMOInterID,//任务单ID
                    FMOBillNo = input.FMOBillNo
                };//任务单号

                context.ICMOSchedule.Add(schedule);//插入任务计划单
            }
            else
            {
                context.ICMOSchedule.Attach(schedule);
                context.Entry(schedule).State = EntityState.Modified;
            }


            //已存在的排程日计划单
            var dailyEntityList = context.ICMODaily.Where(p => p.FSrcID == schedule.FID).ToList();

            foreach (var daily in input.Dailies)
            {
                //比较传入数据是否已存在，如果存在则更新数据，否则插入新记录
               var dailyEntity = dailyEntityList.SingleOrDefault(p =>
                    p.FMachineID == daily.FMachineID && p.FWorkCenterID == daily.FWorkCenterID &&
                    p.FShift == daily.FShift);

               JITEF.DIME2Barcode.ICMODaily item = null;

               if (dailyEntity != null)
               {
                   item = dailyEntity;
                   context.ICMODaily.Attach(item);
                    context.Entry(item).State = EntityState.Modified;
               }
               else
               {
                   var index= Array.IndexOf(input.Dailies,daily)+dailyEntityList.Count+1.ToString("000");

                   context.ICMODaily.Attach(item);
                    item =new JITEF.DIME2Barcode.ICMODaily();
                   context.Entry(item).State = EntityState.Added;
                   item.FMachineID = daily.FMachineID;
                   item.FWorkCenterID = daily.FWorkCenterID;
                   item.FShift = daily.FShift;
                   item.FID = Guid.NewGuid().ToString();
                   item.FBillNo = "DA" + DateTime.Now.ToString("yyyyMMddHHmmss")+"-"+index;//任务计划单号
                   item.FMOInterID = input.FMOInterID;//任务单号
                   item.FMOBillNo = input.FMOBillNo;//任务单号
                   item.FBiller = this.AbpSession.UserId.ToString();//当前登录用户
                   item.FSrcID = schedule.FID;

                   
               }
                
                item.FPlanAuxQty = daily.FPlanAuxQty;
                item.FDate = daily.FDate;
            }

            //更新任务计划单派工数
            //schedule.FPlanAuxQty = planTotalQty;
            var tran = context.Database.BeginTransaction();
            try
            {
                
                context.SaveChanges();
                tran.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                tran.Rollback();
                throw;
            }


            return new ICMODailyDto();
        }

        public async Task<ICMODailyDto> Update(ICMODailyDto input)
        {
            var entity = input.MapTo<JITEF.DIME2Barcode.ICMODaily>();

            context.ICMODaily.Attach(entity);

            context.Entry(entity).State = EntityState.Modified;

            await context.SaveChangesAsync();

            return entity.MapTo<ICMODailyDto>();
        }

        public async Task Delete(ICMODailyInput input)
        {
            var entity = context.ICMODaily.SingleOrDefault(p => p.FID == input.FID);

            if (entity != null)
            {
                context.ICMODaily.Attach(entity);

                context.Entry(entity).State = EntityState.Deleted;

                await context.SaveChangesAsync();
            }
        }



    }
}