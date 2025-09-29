using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAp
{
    public class Doctor
    {
        public string Nombre { get; set; }
        public string Especialidad { get; set; }

        // Esto define cómo se mostrará en el ComboBox automáticamente
        public override string ToString()
        {
            return $"{Nombre} - {Especialidad}";
        }
    }
}
