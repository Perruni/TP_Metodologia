using System.ComponentModel.DataAnnotations;

namespace Web_Subasta.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(100, ErrorMessage = "La contraseña debe tener al menos {2} caracteres.", MinimumLength = 6)]
        public string Contrasenia { get; set; }

        // Otros campos que desees agregar, como nombre, apellido, etc.
    }
}
