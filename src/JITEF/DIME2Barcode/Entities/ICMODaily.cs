using Abp.Domain.Entities;

namespace JITEF.DIME2Barcode
{
    public partial class ICMODaily:Entity<string>
    {
        public override string Id { get=>FID; set=>FID=value; }
    }
}