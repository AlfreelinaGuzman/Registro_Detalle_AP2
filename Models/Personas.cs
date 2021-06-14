using System;
using System.ComponentModel.DataAnnotations;

namespace Registro_Detalle_AP2.Models
{

    public class Personas
    {
        [Key]
        public int PersonaId { get; set; }
        [Required(ErrorMessage ="Este campo no puede estar vacio.")]
        public string Nombres { get; set; }
        [Required(ErrorMessage ="Este campo no puede estar vacio.")]
        public string Telefono { get; set; }
        [Required(ErrorMessage ="Este campo no puede estar vacio.")]
        public string Cedula { get; set; }
        [Required(ErrorMessage ="Este campo no puede estar vacio.")]
        public string Direccion { get; set; }
        
        public DateTime FechaNacimiento { get; set; } = DateTime.Now; 
        [Required(ErrorMessage ="Este campo no puede estar vacio.")] 
        public decimal Balance { get; set; } 
       
    }
}