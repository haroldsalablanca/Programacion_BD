using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaEntidades;
using capaDatos;

namespace capaNegocio
{
    class logicaNegocioUsuario
    {
        accesoDatoUsuario adu = new accesoDatoUsuario();
        public int insertarUsuarios(Usuario U)
        {
            return adu.insertarUsuarios(U);
        }

        public List<Usuario> listarUsuarios()
        {
            return adu.listarUsuarios();
        }

        public int eliminarUsuario(int iduser)
        {
            return adu.eliminarUsuario(iduser);
        }

        public int editarUsuario(Usuario U)
        {
            return adu.editarUsuario(U);
        }

        public List<Usuario> buscarUsuarios(string dato)
        {
            return adu.buscarUsuarios(dato);
        }
    }
}
