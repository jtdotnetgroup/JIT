//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace JITEF.DIME2Barcode
{
    using System;
    using System.Collections.Generic;
    
    public partial class ICMOSchedule
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
