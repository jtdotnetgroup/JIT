﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DIME2BarcodeContainer : DbContext
    {
        public DIME2BarcodeContainer()
            : base("name=DIME2BarcodeContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<VW_MOBillList> VW_MOBillList { get; set; }
        public virtual DbSet<BillStatus> BillStatus { get; set; }
        public virtual DbSet<ICException> ICException { get; set; }
        public virtual DbSet<ICMaterialPicking> ICMaterialPicking { get; set; }
        public virtual DbSet<ICMODaily> ICMODaily { get; set; }
        public virtual DbSet<ICMODispBill> ICMODispBill { get; set; }
        public virtual DbSet<ICMOInspectBill> ICMOInspectBill { get; set; }
        public virtual DbSet<ICMOSchedule> ICMOSchedule { get; set; }
        public virtual DbSet<ICQualityRpt> ICQualityRpt { get; set; }
        public virtual DbSet<T_PrintTemplate> T_PrintTemplate { get; set; }
        public virtual DbSet<TB_BadItemRelation> TB_BadItemRelation { get; set; }
    
        public virtual int GetMODailyList(Nullable<int> mOInterID)
        {
            var mOInterIDParameter = mOInterID.HasValue ?
                new ObjectParameter("MOInterID", mOInterID) :
                new ObjectParameter("MOInterID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetMODailyList", mOInterIDParameter);
        }
    }
}
