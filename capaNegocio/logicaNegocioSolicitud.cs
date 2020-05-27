using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using capaEntidades;
using capaDatos;

namespace capaNegocio
{
    public class logicaNegocioSolicitud
    {
        accesoDatoSolicitud ads = new accesoDatoSolicitud();
        public int insertarSolicitud(Solicitud S)
        {
            return ads.insertarSolicitud(S);
        }

        public List<Solicitud> listarSolicitud()
        {
            return ads.listarSolicitud();
        }

        public int eliminarSolicitud(int idsolicit)
        {
            return ads.eliminarSolicitud(idsolicit);
        }

        public int editarSolicitud(Solicitud S)
        {
            return ads.editarSolicitud(S);
        }

        public List<Solicitud> buscarSolicitud(string dato)
        {
            return ads.buscarSolicitud(dato);
        }
    }
}
