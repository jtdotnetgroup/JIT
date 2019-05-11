using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JIT.JIT.TaskAssignment.VW_MOBillList.Dtos
{
    public  class VM_ICMODispBillDto
    {
        public System.DateTime 日期 { get; set; }
        public string 计划单号 { get; set; }
        public string 车间 { get; set; }
        public string 任务单号 { get; set; }
        public string 产品名称 { get; set; }
        public string 产品编码 { get; set; }
        public string 规格型号 { get; set; }
        public Nullable<System.DateTime> 计划开工日期 { get; set; }
        public Nullable<System.DateTime> 计划完工日期 { get; set; }
        public Nullable<decimal> 计划生产数量 { get; set; }
        public Nullable<decimal> 汇报数量 { get; set; }
        public string FSrcID { get; set; }
        public int FMOInterID { get; set; }
    }
}
