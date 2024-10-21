using System.ComponentModel.DataAnnotations;

namespace Web_Subasta.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string email { get; set; } = null!;

        [Required]
        public string contrasenia{ get; set; } = null!;
    }
}
