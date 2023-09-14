using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class PersonaCreacionDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre debe tener como máximo 50 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
        public DateTime FechaNacimiento { get; set; }

        [StringLength(25, ErrorMessage = "El teléfono debe tener como máximo 25 caracteres.")]
        public string Telefono { get; set; }

    }
}