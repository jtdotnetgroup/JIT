using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using JITEF.DIME2Barcode;

namespace JIT.TaskAssignment.ICMODispBill.Dtos
{
    
    public class ICMODispBillDto : IEntityDto<string>
    {
        public string Id { get => FID; set => FID = value; }

        public string FID { get; set; }
        public string FSrcID { get; set; }
        public string FBillNo { get; set; }
        public int FTranType { get; set; }
        public int FStatus { get; set; }
        public Nullable<bool> FClosed { get; set; }
        public Nullable<int> FMOInterID { get; set; }
        public string FMOBillNo { get; set; }
        public System.DateTime FDate { get; set; }
        public Nullable<int> FShift { get; set; }
        public Nullable<int> FOperID { get; set; }
        public Nullable<int> FWorkCenterID { get; set; }
        public Nullable<int> FMachineID { get; set; }
        public string FWorker { get; set; }
        //public Nullable<decimal> FPlanAuxQty { get; set; }
        //public Nullable<decimal> FCommitAuxQty { get; set; }
        //public Nullable<decimal> FFinishAuxQty { get; set; }
        //public Nullable<decimal> FFInspectAuxQty { get; set; }
        //public Nullable<decimal> FPassAuxQty { get; set; }
        //public Nullable<decimal> FFailAuxQty { get; set; }
        public string FBiller { get; set; }
        public Nullable<System.DateTime> FBillTime { get; set; }
        public string FChecker { get; set; }
        public Nullable<System.DateTime> FCheckTime { get; set; }
        public string FCloser { get; set; }
        public Nullable<System.DateTime> FCloseTime { get; set; }
        public int FPrintCount { get; set; }
        public string FNote { get; set; }

    }
}
