using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace JITEF.DIME2Barcode
{
   public partial class TB_BadItemRelation:Entity<int>
    {
        public override int Id { get=>FID; set=>FID=value; }
    }
}
