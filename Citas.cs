using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAp
{
    public class Citas
    {
        public string Especialidad { get; set; }
        public string Doctor { get; set; }
        public DateTime FechaHora { get; set; }
        public DateTime Hora { get; set; }
        public string Consultorio { get; set; }
        public string Estado { get; internal set; } = "Activa";
        public object Cliente { get; internal set; }

        public override string ToString()
        {
            return $"{FechaHora.ToShortDateString()} - {Hora} - {Especialidad}";
        }
    }
}
