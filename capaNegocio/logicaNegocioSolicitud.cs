using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaEntidades;
using capaDatos;

namespace capaNegocio
{
    class logicaNegocioSolicitud
    {
        accesoDatoSolicitud ac = new accesoDatoSolicitud();
        public int insertarSolicitud(Solicitud co)
        {
            return ac.insertarSolicitud(co);
        }

        public List<Solicitud> listarSolicitudes()
        {
            return ac.listarSolicitud();
        }

        public int eliminarSolicitud(int idcoment)
        {
            return ac.eliminarSolicitud(idcoment);
        }

        public int editarSolicitud(Solicitud S)
        {
            return ac.editarSolicitud(S);
        }

        public List<Solicitud> buscarSolicitud(string dato)
        {
            return ac.buscarSolicitud(dato);
        }
    }
}
