using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escritorio
{
    public class ViajeGM
    {
        public string IdViaje { get; set; }
        public string IdEmpleado { get; set; }
        public string Placa { get; set; }
        public string NombrePasajero { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }

        public ViajeGM()
        {

        }

        public ViajeGM( ServiceReference1.ViajeM item)
        {
            IdViaje = item.Id_Viaje;
            IdEmpleado = item.Id_Empleado;
            Placa = item.Placa_Vehiculo;
            NombrePasajero = item.Nombre_Pasajero;
            HoraInicio = item.Hora_Inicio_Viaje.ToString();
            HoraFin = item.Hora_Fin_Viaje.ToString();
        }

    }
}
