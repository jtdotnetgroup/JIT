using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace JITEF.DIME2Barcode
{
    public partial class ICMODaily:Entity<string>
    {
        [Column("FID")]
        public override string Id { get=>FID; set=>FID=value; }
    }
}