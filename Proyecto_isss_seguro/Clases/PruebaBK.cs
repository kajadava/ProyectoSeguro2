using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Proyecto_isss_seguro.Clases
{
    class PruebaBK
    {
        public int idbk;
        public int idprueba;
        public string numerobk;
        public string tipobkmas;
        public string seriebk;
        public string laboratorio;
        public string crb;

        public PruebaBK() { }
        public PruebaBK( int ibk, int idpru, string nubk, string tibk, string sebk, string labo, string cr)
        {
            this.idbk = ibk;
            this.idprueba = idpru;
            this.numerobk = nubk;
            this.tipobkmas = tibk;
            this.seriebk = sebk;
            this.laboratorio = labo;
            this.crb = cr;
        }

        public PruebaBK( int idpru, string nubk, string tibk, string sebk, string labo, string cr)
        {
          
            this.idprueba = idpru;
            this.numerobk = nubk;
            this.tipobkmas = tibk;
            this.seriebk = sebk;
            this.laboratorio = labo;
            this.crb = cr;
        }

        public static void insertarPruebaBK(MySqlConnection conexion, PruebaBK ipbk)
        {
            String query = "INSERT INTO bk(IDPRUEBA, NUMEROBK, TIPOBK+, SERIEBK, LABORATORIO, CRB) VALUES ('" + ipbk.idprueba + "','" + ipbk.numerobk + "','" + ipbk.tipobkmas + "','" + ipbk.seriebk + "','" + ipbk.laboratorio + "','" + ipbk.crb + "',)";
            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                Int32 lector = (Int32)comando.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            { throw ex; }

        }
    }
}
