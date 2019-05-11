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

        public DIME2BarcodeContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public virtual IDbSet<VW_MOBillList> VW_MOBillList { get; set; }
        public virtual IDbSet<BillStatus> BillStatus { get; set; }
        public virtual IDbSet<ICException> ICException { get; set; }
        public virtual IDbSet<ICMaterialPicking> ICMaterialPicking { get; set; }
        public virtual IDbSet<ICMODaily> ICMODaily { get; set; }
        public virtual IDbSet<ICMODispBill> ICMODispBill { get; set; }
        public virtual IDbSet<ICMOInspectBill> ICMOInspectBill { get; set; }
        public virtual IDbSet<ICMOSchedule> ICMOSchedule { get; set; }
        public virtual IDbSet<ICQualityRpt> ICQualityRpt { get; set; }
        public virtual IDbSet<T_PrintTemplate> T_PrintTemplate { get; set; }
        public virtual IDbSet<TB_BadItemRelation> TB_BadItemRelation { get; set; }
        public  virtual IDbSet<VM_MOICMODispBill> VM_MOICMODispBill { get; set; }

        public virtual int GetMODailyList(Nullable<int> mOInterID)
        {
            var mOInterIDParameter = mOInterID.HasValue ?
                new ObjectParameter("MOInterID", mOInterID) :
                new ObjectParameter("MOInterID", typeof(int));

            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetMODailyList", mOInterIDParameter);
        }
    }
}