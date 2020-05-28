using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaEntidades
{
    public class Solicitud
    {
        public int idsolicitud { get; set; }
        public string aula { get; set; }
        public string nivel { get; set; }
        public string fechasolicitud { get; set; }
        public string fechauso { get; set; }
        public string horainicio { get; set; }
        public string horafinal { get; set; }
        public string carrera { get; set; }
        public string asignatura { get; set; }
        public int idrecursos { get; set; }
        public int idusuario { get; set; }
    }
}
