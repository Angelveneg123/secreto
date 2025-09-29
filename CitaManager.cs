using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaludAp
{
    public static class CitaManager      //// funciona como una base de datos temporal
    {
        private static List<Citas> CitasAgendadas { get; } = new List<Citas>();

        public static void AgendarCita(Citas nuevaCita)
        {
            CitasAgendadas.Add(nuevaCita);
        }

        public static List<Citas> ObtenerCitas()
        {
            return CitasAgendadas;
        }
    }
}

