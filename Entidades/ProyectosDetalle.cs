using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace p2_ap1_wilkins_20170289.Entidades
{
    public class ProyectosDetalle
    {
        [Key]
        public int ProyectosDetalleId { get; set; }
        public int ProyectoId { get; set; }
        public int TareaId { get; set; }
        public string Requerimiento { get; set; }
        public double Tiempo { get; set; }

        //———————————————————————————[ ForeingKeys ]———————————————————————————
        [ForeignKey("TareaId")]
        public virtual Tareas tareas { get; set; }
    }
}