using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JIT.JIT.ICMODaily.Dtos
{
    public class ICMODailyCreatDto
    {
        [Required]
        public int FMOInterID { get; set; }
        [Required]
        public string FMOBillNo { get; set; }
        public DailyDto[] Dailies { get; set; }
    }
}