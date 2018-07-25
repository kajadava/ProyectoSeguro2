using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_isss_seguro.Clases
{
    class PruebaBAAR
    {
        public int idbaar;
        public int idprueba;
        public string fecharecepcionc;
        public string fecharecepcionl;
        public string mediocultivo;
        public string motivoindicacion;
        public string fecharesultadobkcc;
        public string rbkcc;
        public string rcultivo;
        public string fecharesultadocultivo;
        public string fechalnr;
        public string tipificacion;
        public string fechatipicacion;
        public string psd;
        public string fechapsd;
        public string observaciones;
        public string fechaindicacioncultmed;
        public string rbkreferencia;
        public string fecharbkreferencia;

        public PruebaBAAR() { }
        public PruebaBAAR(int idbaa, int idpru, string fecharecc, string fecharecl, string mediocu, string motivoin, string fechares, string rbkc, string rcul, string fecharescu, string fechal, string tipi, string fechatipi, string ps, string fechaps, string obs, string fechaindi, string rbkref, string fecharbkref)
        {
            this.idbaar = idbaa;
            this.idprueba = idpru;
            this.fecharecepcionc = fecharecc;
            this.fecharecepcionl = fecharecl;
            this.mediocultivo = mediocu;
            this.motivoindicacion = motivoin;
            this.fecharesultadobkcc = fechares;
            this.rbkcc = rbkc;
            this.rcultivo = rcul;
            this.fecharesultadocultivo = fecharescu;
            this.fechalnr = fechal;
            this.tipificacion = tipi;
            this.fechatipicacion = fechatipi;
            this.psd = ps;
            this.fechapsd = fechaps;
            this.observaciones = obs;
            this.fechaindicacioncultmed = fechaindi;
            this.rbkreferencia = rbkref;
            this.fecharbkreferencia = fecharbkref;
        }

        public PruebaBAAR(int idpru, string fecharecc, string fecharecl, string mediocu, string motivoin, string fechares, string rbkc, string rcul, string fecharescu, string fechal, string tipi, string fechatipi, string ps, string fechaps, string obs, string fechaindi, string rbkref, string fecharbkref)
        {
            this.idprueba = idpru;
            this.fecharecepcionc = fecharecc;
            this.fecharecepcionl = fecharecl;
            this.mediocultivo = mediocu;
            this.motivoindicacion = motivoin;
            this.fecharesultadobkcc = fechares;
            this.rbkcc = rbkc;
            this.rcultivo = rcul;
            this.fecharesultadocultivo = fecharescu;
            this.fechalnr = fechal;
            this.tipificacion = tipi;
            this.fechatipicacion = fechatipi;
            this.psd = ps;
            this.fechapsd = fechaps;
            this.observaciones = obs;
            this.fechaindicacioncultmed = fechaindi;
            this.rbkreferencia = rbkref;
            this.fecharbkreferencia = fecharbkref;
        }

    }
}
