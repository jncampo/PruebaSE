using NegocioEmp.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEmp.DAL
{
    interface IViajeDAL
    {
        IEnumerable<ViajeM> ObtenerLista();
        IEnumerable<ViajeM> ObtenerLista(ViajeM itemFiltros);
        string Crear(ViajeM item);
    }
}
