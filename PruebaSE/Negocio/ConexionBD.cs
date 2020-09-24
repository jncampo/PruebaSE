using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ConexionBD
/// </summary>
public class ConexionBD
{

    public static string ObtenerCadenaConexion()
    {
        return ConfigurationManager.ConnectionStrings["ConexionBD"].ToString();
    }
}
