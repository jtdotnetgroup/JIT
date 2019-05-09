using System.ComponentModel.DataAnnotations;

namespace JIT.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}