using System;
using Abp.Application.Services.Dto;

namespace JIT.JIT.TaskAssignment.ICMOSchedule.Dtos
{
    public class ICMOScheduleDto:EntityDto<string>
    {
        public string FID { get; set; }
        public string FBillNo { get; set; }
        public int FTranType { get; set; }
        public int FMOInterID { get; set; }
        public string FMOBillNo { get; set; }
        public int FStatus { get; set; }
        public Nullable<bool> FCancellation { get; set; }
        public Nullable<bool> FClosed { get; set; }
        public Nullable<decimal> FSrcAuxQty { get; set; }
        public Nullable<decimal> FPlanAuxQty { get; set; }
        public Nullable<decimal> FFinishAuxQty { get; set; }
        public Nullable<decimal> FPassAuxQty { get; set; }
        public Nullable<decimal> FFailAuxQty { get; set; }
        public Nullable<System.DateTime> FPlanBeginDate { get; set; }
        public Nullable<System.DateTime> FPlanFinishDate { get; set; }
        public Nullable<System.DateTime> FFinishDate { get; set; }
        public string FBiller { get; set; }
        public Nullable<System.DateTime> FBillTime { get; set; }
        public string FChecker { get; set; }
        public Nullable<System.DateTime> FCheckTime { get; set; }
        public string FCloser { get; set; }
        public Nullable<System.DateTime> FCloseTime { get; set; }
        public string FNote { get; set; }
    }
}