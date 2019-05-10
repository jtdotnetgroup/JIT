using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace JIT.JIT.ICMODaily.Dtos
{
    public class ICMODailyInput:EntityDto<string>
    {
        [Required]
        public string FID { get; set; }
    }
}