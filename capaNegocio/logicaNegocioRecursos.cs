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
        accesoDatoRecursos ac = new accesoDatoRecursos();
        public int insertarRecursos(Recursos co)
        {
            return ac.insertarRecursos(co);
        }

        public List<Recursos> listarRecursos()
        {
            return ac.listarRecursos();
        }

        public int eliminarRecurosos(int idcoment)
        {
            return ac.eliminarRecursos(idcoment);
        }

        public int editarRecursos(Recursos re)
        {
            return ac.editarRecursos(re);
        }

        public List<Recursos> buscarRecursos(string dato)
        {
            return ac.buscarRecursos(dato);
        }
    }
}
