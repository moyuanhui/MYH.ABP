using System.ComponentModel.DataAnnotations;

namespace MYH.ABP.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}