using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_isss_seguro.Clases
{
    class Prueba
    {
        public int idprueba;
        public int idmuestra;
        public int idtipoprueba;

        public Prueba() { }

        public Prueba(int idpru, int idmue, int idtipo)
        {
            this.idprueba = idpru;
            this.idmuestra = idmue;
            this.idtipoprueba = idtipo;
        }

        public Prueba(int idmue, int idtipo)
        {
            this.idmuestra = idmue;
            this.idtipoprueba = idtipo;
        }


    }
}