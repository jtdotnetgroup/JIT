using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace JIT.JIT.ICMODaily.Dtos
{
    public class ICMODailyImportInput
    {
        [Required]
        public IFormFile File { get; set; }
    }
}