using Capa_Datos;
using Capa_Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class ClassNegocio
    {
        ClassDatos objd = new ClassDatos();

        public DataTable N_listar_clientes()
        {
            return objd.D_Listar_Clientes();
        }

        public DataTable N_buscar_clientes(ClassEntidad obje)
        {
            return objd.D_buscar_clientes(obje);
        }

        public string N_mantenimiento_clientes(ClassEntidad obje)
        {
            return objd.D_mantenimiento_clientes(obje);
        }
    }
}
