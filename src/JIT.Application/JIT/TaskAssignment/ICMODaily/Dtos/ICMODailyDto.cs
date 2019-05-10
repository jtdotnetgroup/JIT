using System;
using Abp.Application.Services.Dto;

namespace JIT.JIT.ICMODaily.Dtos
{
    public class ICMODailyDto:EntityDto<string>
    {
        public string FID { get; set; }
        public string FSrcID { get; set; }
        public string FBillNo { get; set; }
        public Nullable<int> FTranType { get; set; }
        public int FStatus { get; set; }
        public Nullable<bool> FClosed { get; set; }
        public Nullable<int> FMOInterID { get; set; }
        public string FMOBillNo { get; set; }
        public int FEntryID { get; set; }
        public System.DateTime FDate { get; set; }
        public Nullable<int> FShift { get; set; }
        public Nullable<int> FWorkCenterID { get; set; }
        public Nullable<int> FMachineID { get; set; }
        public string FWorker { get; set; }
        public Nullable<decimal> FPlanAuxQty { get; set; }
        public Nullable<decimal> FCommitAuxQty { get; set; }
        public Nullable<decimal> FFinishAuxQty { get; set; }
        public Nullable<decimal> FPassAuxQty { get; set; }
        public Nullable<decimal> FFailAuxQty { get; set; }
        public Nullable<int> FOperID { get; set; }
        public string FOperNote { get; set; }
        public string FBiller { get; set; }
        public Nullable<System.DateTime> FBillTime { get; set; }
        public string FChecker { get; set; }
        public Nullable<System.DateTime> FCheckTime { get; set; }
        public string FCloser { get; set; }
        public Nullable<System.DateTime> FCloseTime { get; set; }
        public string FNote { get; set; }
    }
}