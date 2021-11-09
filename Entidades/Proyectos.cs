using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace p2_ap1_wilkins_20170289.Entidades
{
    public class Proyectos
    {
        [Key]
        public int ProyectoId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Descripcion { get; set; }
        public double TiempoTotal { get; set; }

        //———————————————————————————[ ForeingKeys ]———————————————————————————
        [ForeignKey("ProyectoId")]
        public virtual List<ProyectosDetalle> Detalle { get; set; } = new List<ProyectosDetalle>();
    }
}