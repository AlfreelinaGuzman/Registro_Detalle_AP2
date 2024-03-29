using System;
using System.Collections.Generic;
using  System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registro_Detalle_AP2.Models
{
    public class Moras{
        [Key]
        public int MoraId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("MoraId")]
        public virtual List<MorasDetalle> MorasDetalle {get; set;} 

        public Moras()
        {
            MoraId = 0;
            Fecha = DateTime.Now;
            MorasDetalle = new List<MorasDetalle>();
        }
    }
    
}