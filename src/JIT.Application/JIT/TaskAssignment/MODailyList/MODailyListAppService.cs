using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JIT.JIT.TaskAssignment.MODailyList.Dtos;
using JITEF.Common;
using JITEF.DIME2Barcode;
using Newtonsoft.Json;

namespace JIT.JIT.TaskAssignment.MODailyList
{
    public class MODailyListAppService : IApplicationService
    {
        DIME2BarcodeContext context = new DIME2BarcodeContext();

        public async Task<string> GetMODailyList(MODailyListInput input)
        {
            var count = context.GetMODailyList(input.MOInterId);

            StoredProcedureHelper spHelper=new StoredProcedureHelper("DIME2Barcode");

            Dictionary<string,object> param= new Dictionary<string, object>();
            param.Add("@MOInterID", input.MOInterId);

            var table= spHelper.Exec("GetMODailyList", param);

            //无值
            return JsonConvert.SerializeObject(table);
        }
    }
}