using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.EntityFramework;
using JITEF.DIME2Barcode.Repository;

namespace JITEF.DIME2Barcode
{
    [AutoRepositoryTypes(
        typeof(IRepository<>),
        typeof(IRepository<,>),
        typeof(DIME2BarcodeRepositoryBase<>),
        typeof(DIME2BarcodeRepositoryBase<,>))]
    public partial class DIME2BarcodeContext:AbpDbContext,ITransientDependency
    {

        public DIME2BarcodeContext() : base("DIME2BarcodeContainer")
        {
        }

        //public static DIME2BarcodeContext GetInstance()
        //{
        //    if (context == null)
        //    {
        //        lock (obj)
        //        {
        //            if (context == null)
        //            {
        //                context=new DIME2BarcodeContext();;
        //            }
        //        }
        //    }

        //    return context;
        //}
        public virtual DbSet<VW_MODispBillList> VW_MODispBillList { get; set; }
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