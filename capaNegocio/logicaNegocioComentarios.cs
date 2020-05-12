using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaEntidades;
using capaDatos;

namespace capaNegocio
{
    public class logicaNegocioComentarios
    {
        accesoDatoComentario ac = new accesoDatoComentario();
        public int insertarComentarios(Comentarios co)
        {
            return ac.insertarComentarios(co);
        }

        public List<Comentarios> listarComentarios()
        {
            return ac.listarComentarios();
        }

        public int eliminarComentarios(int idcoment)
        {
            return ac.eliminarComentarios(idcoment);
        }

        public int editarComentarios(Comentarios co)
        {
            return ac.editarComentarios(co);
        }

        public List<Comentarios> buscarComentarios(string dato)
        {
            return ac.buscarComentarios(dato);
        }

    }

}
