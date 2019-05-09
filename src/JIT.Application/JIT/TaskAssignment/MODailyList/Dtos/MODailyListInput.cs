using System.ComponentModel.DataAnnotations;

namespace JIT.JIT.TaskAssignment.MODailyList.Dtos
{
    public class MODailyListInput
    {
        [Required]
        public int MOInterId { get; set; }
    }
}