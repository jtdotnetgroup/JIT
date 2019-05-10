using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace JITEF.DIME2Barcode
{
   public  partial class ICMODispBill:Entity<string>
    {
        public override string Id { get=>FID; set=>FID=value; }
    }
}
