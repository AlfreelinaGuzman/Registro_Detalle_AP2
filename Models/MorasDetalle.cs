using System;
using  System.ComponentModel.DataAnnotations;

namespace Registro_Detalle_AP2.Models
{
    public class MorasDetalle{
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Este campo no puede estar vacio.")]
        public int MoraId { get; set; }
        [Required(ErrorMessage ="Este campo no puede estar vacio.")]
        public int PrestamoId { get; set; }
        [Required(ErrorMessage ="Este campo no puede estar vacio.")]
        public decimal Valor { get; set; }

        public MorasDetalle()
        {
            Id = 0;
            MoraId = 0;
            PrestamoId = 0;
            Valor = 0;
        }

        public MorasDetalle(int moraId, int prestamoId, decimal valor)
        {
            Id = 0;
            MoraId = moraId;
            PrestamoId = prestamoId;
            Valor = valor;
        }

    }

    
}