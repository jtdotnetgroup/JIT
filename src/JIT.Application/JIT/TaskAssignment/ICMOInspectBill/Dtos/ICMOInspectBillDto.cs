using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace JIT.TaskAssignment.ICMOInspectBill.Dtos
{
    //[AutoMapFrom(typeof(JITEF.DIME2Barcode.ICMOInspectBill))]
    public class ICMOInspectBillDto : IEntityDto<string>
    {
        public string Id { get => FID; set => FID = value; }


        public string FID { get; set; }
        public Nullable<int> FMOInterID { get; set; }
        public string FBillNo { get; set; }
        public int FTranType { get; set; }
        public int FStatus { get; set; }
        public Nullable<int> FOperID { get; set; }
        public Nullable<int> FWorkcenterID { get; set; }
        public Nullable<int> FMachineID { get; set; }
        public Nullable<decimal> FAuxQty { get; set; }
        public Nullable<decimal> FCheckAuxQty { get; set; }
        public Nullable<decimal> FPassAuxQty { get; set; }
        public Nullable<decimal> FFailAuxQty { get; set; }
        public Nullable<decimal> FFailAuxQtyP { get; set; }
        public Nullable<decimal> FFailAuxQtyM { get; set; }
        public Nullable<decimal> FPassAuxQtyP { get; set; }
        public Nullable<decimal> FPassAuxQtyM { get; set; }
        public string FNote { get; set; }
        public string FWorker { get; set; }
        public string FInspector { get; set; }
        public Nullable<System.DateTime> FInspectTime { get; set; }
        public string FBiller { get; set; }
        public Nullable<System.DateTime> FBillTime { get; set; }
        public string FChecker { get; set; }
        public Nullable<System.DateTime> FCheckTime { get; set; }
    }
}