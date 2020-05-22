using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaEntidades;
using capaDatos;

namespace capaNegocio
{
    public class logicaNegocioRecursos
    {
        accesoDatoRecursos ar = new accesoDatoRecursos();
        public int insertarRecursos(Recursos re)
        {
            return ar.insertarRecursos(re);
        }

        public List<Recursos> listarRecursos()
        {
            return ar.listarRecursos();
        }

        public int eliminarRecursos(int idcoment)
        {
            return ar.eliminarRecursos(idcoment);
        }

        public int editarRecursos(Recursos re)
        {
            return ar.editarRecursos(re);
        }

        public List<Recursos> buscarRecursos(string dato)
        {
            return ar.buscarRecursos(dato);
        }
    }
}
