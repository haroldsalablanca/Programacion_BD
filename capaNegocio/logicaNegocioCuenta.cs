using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaEntidades;
using capaDatos;

namespace capaNegocio
{
    public class logicaNegocioCuenta
    {
        accesoDatoCuenta adc = new accesoDatoCuenta();
        public int insertarCuentas(Cuenta C)
        {
            return adc.insertarCuentas(C);
        }

        public List<Cuenta> listarCuentas()
        {
            return adc.listarCuentas();
        }

        public int eliminarCuentas(int idcoment)
        {
            return adc.eliminarCuentas(idcoment);
        }

        public int editarCuentas(Cuenta C)
        {
            return adc.editarCuentas(C);
        }

        public List<Cuenta> buscarCuentas(string dato)
        {
            return adc.buscarCuentas(dato);
        }
    }
}
