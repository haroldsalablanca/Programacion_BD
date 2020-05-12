using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaEntidades;
using capaDatos;

namespace capaNegocio
{
    class logicaNegocioCuenta
    {
        accesoDatoCuenta ac = new accesoDatoCuenta();
        public int insertarCuentas(Cuenta C)
        {
            return ac.insertarCuentas(C);
        }

        public List<Cuenta> listarCuentas()
        {
            return ac.listarCuentas();
        }

        public int eliminarCuentas(int idcoment)
        {
            return ac.eliminarCuentas(idcoment);
        }

        public int editarCuentas(Cuenta C)
        {
            return ac.editarCuentas(C);
        }

        public List<Cuenta> buscarCuentas(string dato)
        {
            return ac.buscarCuentas(dato);
        }
    }
}
