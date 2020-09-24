using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Negocio.Entidad
{

    /// <summary>
    /// Descripción breve de MEmpleado
    /// </summary>
    [DataContract]
    public class EmpleadoM
    {
        [DataMember]
        public string Id_Empleado { get; set; }
        [DataMember]
        public string Id_Tipo_Documento { get; set; }
        [DataMember]
        public string Numero_Documento { get; set; }
        [DataMember]
        public string Nombre_Empleado { get; set; }
        [DataMember]
        public string Apellido_Empleado { get; set; }
        [DataMember]
        public bool Estado_Empleado { get; set; }
    }
}
