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
        accesoDatoUsuario ac = new accesoDatoUsuario();
        public int insertarUsuarios(Usuario co)
        {
            return ac.insertarUsuarios(co);
        }

        //public List<Usuario> listarUsuarios()
        //{
        //    return ac.listarUsuarios();
        //}

        public int eliminarUsuario(int iduser)
        {
            return ac.eliminarUsuario(iduser);
        }

        public int editarUsuario(Usuario U)
        {
            return ac.editarUsuario(U);
        }

        public List<Usuario> buscarUsuarios(string dato)

        {
            return ac.buscarUsuarios(dato);
        }
    }
}
