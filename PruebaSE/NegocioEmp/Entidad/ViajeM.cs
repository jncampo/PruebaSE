using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioEmp.Entidad
{
    public class ViajeM
    {
        public  string Id_Viaje { get; set; }
        public string Id_Empleado { get; set; }
        public string Id_Vehiculo { get; set; }
        public string Placa_Vehiculo { get; set; }
        public string Nombre_Empleado { get; set; }
        public string Apellido { get; set; }
        public string Origen_Viaje { get; set; }
        public string Destino_Viaje { get; set; }
        public string Nombre_Pasajero { get; set; }
        public DateTime Hora_Inicio_Viaje { get; set; }
        public DateTime Hora_Fin_Viaje { get; set; }

    }
}
