using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace JITEF.DIME2Barcode.Repository
{
    public class DIME2BarcodeRepositoryBase<TEntity,TPrimaryKey>:EfRepositoryBase<DIME2BarcodeContext,TEntity,TPrimaryKey> where TEntity:class,IEntity<TPrimaryKey>
    {
        public DIME2BarcodeRepositoryBase(IDbContextProvider<DIME2BarcodeContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }

    public class DIME2BarcodeRepositoryBase<TEntity> : EfRepositoryBase<DIME2BarcodeContext, TEntity, int> where TEntity : class, IEntity<int>
    {
        public DIME2BarcodeRepositoryBase(IDbContextProvider<DIME2BarcodeContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}