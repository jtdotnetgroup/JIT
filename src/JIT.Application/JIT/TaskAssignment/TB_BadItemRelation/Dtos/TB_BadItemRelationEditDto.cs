using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace JIT.JIT.TaskAssignment.TB_BadItemRelation.Dtos
{
    public class TB_BadItemRelationEditDto:EntityDto<int>
    {

        public int Id { get => FID; set => FID = value; }

        public int FID { get; set; }
        public Nullable<int> FItemID { get; set; }
        public int FOperID { get; set; }
        public string FNumber { get; set; }
        public string FName { get; set; }
        public Nullable<bool> FDeleted { get; set; }
        public string FRemark { get; set; }
    }
}
