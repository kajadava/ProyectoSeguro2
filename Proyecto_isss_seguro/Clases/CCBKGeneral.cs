using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace Proyecto_isss_seguro.Clases
{
    class CCBKGeneral
    {
        //atributos de la clase

        public int idCCBKGeneral;
        public int idEstablecimiento;
        public String Mes;
        public String Año;
        public int SR;
        public int SRTotal;
        public int CasoTB;
        public int BKDX;
        public int BKTX;
        public int BKDXmas;
        public int BKDXmaspor;
        public int BKDXmenos;
        public int BKTXmas;





        //constructor vacío para iniciar un nuevo usuario sin asignarle valores a sus atributos
        public CCBKGeneral() { }

        //constructor con parámetros para iniciar un nuevo usuario asignandole valores a sus atributos
        public CCBKGeneral(int id, int esta, String me, String añ, int s, int st, int ctb, int bd, int bt, int bdma, int bdmp, int bdme, int btma)

        {

            this.idCCBKGeneral = id;
            this.idEstablecimiento = esta;
            this.Mes = me;
            this.Año = añ;
            this.SR = s;
            this.SRTotal = st;
            this.CasoTB = ctb;
            this.BKDX = bd;
            this.BKTX = bt;
            this.BKDXmas = bdma;
            this.BKDXmaspor = bdmp;
            this.BKDXmenos = bdme;
            this.BKTXmas = btma;

        }
        //constructor sin id
        public CCBKGeneral(int esta, String me, String añ, int s, int st, int ctb, int bd, int bt, int bdma, int bdmp, int bdme, int btma)

        {
            this.idEstablecimiento = esta;
            this.Mes = me;
            this.Año = añ;
            this.SR = s;
            this.SRTotal = st;
            this.CasoTB = ctb;
            this.BKDX = bd;
            this.BKTX = bt;
            this.BKDXmas = bdma;
            this.BKDXmaspor = bdmp;
            this.BKDXmenos = bdme;
            this.BKTXmas = btma;

        }

        public static void insertarCCBKgeneral(MySqlConnection conexion, CCBKGeneral cc1)
        {

            String query = "INSERT INTO ccbkgeneral(IDESTABLECIMIENTO, MES, AÑO, SR+, SRTOTAL, BKDX, BKTX, BKTX+, BKDX+PORCENTAJE, BKDX-, BKTK+) VALUES ('" + cc1.idEstablecimiento + "','" + cc1.Mes + "','" + cc1.Año + "','" + cc1.SR + "','" + cc1.SRTotal + "','" + cc1.BKDX + "','" + cc1.BKTX + "','" + cc1.BKDXmas + "','" + cc1.BKDXmaspor + "','" + cc1.BKDXmenos + "','" + cc1.BKTXmas + "')";
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