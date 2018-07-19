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
    class CCBKmuestra
    {
        //atributos de la clase

        public int idCCBasiloscopia;
        public string Año;
        public string Mes;
        public int LaminaEnviada;
        public int LaminaSupervizada;
        public int LaminaNegSup;
        public int LaminaPosSup;
        public int LaminaFalsaN;
        public int LaminaFalsaP;
        public decimal Mucupurulentas;
        public decimal Saliva;
        public decimal BuenosExtendidos;
        public decimal BuenosColoracion;
        public decimal Sensibilidad;
        public decimal Concordancia;
        public decimal Especifidad;
        public decimal Discordancia;
        public decimal PorFalNeg;
        public decimal PorFalPos;








        //constructor vacío para iniciar un nuevo usuario sin asignarle valores a sus atributos
        public CCBKmuestra() { }

        //constructor con parámetros para iniciar un nuevo usuario asignandole valores a sus atributos
        public CCBKmuestra(int idccb, string añ, String me, int laenv, int lamsup, int lamnesup, int lampossup, int lamfn, int lamfp, decimal mucup, decimal sal, decimal buext, decimal buecol, decimal sensi, decimal con, decimal espe, decimal dis, decimal pfn, decimal pfp)

        {

            this.idCCBasiloscopia = idccb;
            this.Año = añ;
            this.Mes = me;
            this.LaminaEnviada = laenv;
            this.LaminaSupervizada = lamsup;
            this.LaminaNegSup = lamnesup;
            this.LaminaPosSup = lampossup;
            this.LaminaFalsaN = lamfn;
            this.LaminaFalsaP = lamfp;
            this.Mucupurulentas = mucup;
            this.Saliva = sal;
            this.BuenosExtendidos = buext;
            this.BuenosColoracion = buecol;
            this.Sensibilidad = sensi;
            this.Concordancia = con;
            this.Especifidad = espe;
            this.Discordancia = dis;
            this.PorFalNeg = pfn;
            this.PorFalPos = pfp;


        }
        //constructor sin id
        public CCBKmuestra(string añ, String me, int laenv, int lamsup, int lamnesup, int lampossup, int lamfn, int lamfp, decimal mucup, decimal sal, decimal buext, decimal buecol, decimal sensi, decimal con, decimal espe, decimal dis, decimal pfn, decimal pfp)

        {


            this.Año = añ;
            this.Mes = me;
            this.LaminaEnviada = laenv;
            this.LaminaSupervizada = lamsup;
            this.LaminaNegSup = lamnesup;
            this.LaminaPosSup = lampossup;
            this.LaminaFalsaN = lamfn;
            this.LaminaFalsaP = lamfp;
            this.Mucupurulentas = mucup;
            this.Saliva = sal;
            this.BuenosExtendidos = buext;
            this.BuenosColoracion = buecol;
            this.Sensibilidad = sensi;
            this.Concordancia = con;
            this.Especifidad = espe;
            this.Discordancia = dis;
            this.PorFalNeg = pfn;
            this.PorFalPos = pfp;


        }

        public static void insertarCCBKmuestras(MySqlConnection conexion, CCBKmuestra cc2)
        {
            //Console.WriteLine("valor del tipo de muestra: " + mu.idtipomuestra);
            String query = "INSERT INTO ccbkmuestras(AÑO, MES, LAMINAENVIADA, LAMINASUPERVIZADA, LAMINANEGSUP, LAMINAPOSSUP, LAMINAFALSAN, LAMINAFALSAP, MUCOPURULENTAS, SALIVA, BUENOSEXTENDIDOS, BUENOSCOLORACION, SENSIBILIDAD, CONCORDANCIA, ESPECIFIDAD, DISCORDANCIA, PORCFALSP, PORCFALSN) VALUES ('" + cc2.Año + "','" + cc2.Mes + "','" + cc2.LaminaEnviada + "','" + cc2.LaminaSupervizada + "','" + cc2.LaminaNegSup + "','" + cc2.LaminaPosSup + "','" + cc2.LaminaFalsaN + "','" + cc2.LaminaFalsaP + "','" + cc2.Mucupurulentas + "','" + cc2.Saliva + "','" + cc2.BuenosExtendidos + "','" + cc2.BuenosColoracion + "','" + cc2.Sensibilidad + "','" + cc2.Concordancia + "','" + cc2.Especifidad + "','" + cc2.Discordancia + "','" + cc2.PorFalPos + "','" + cc2.PorFalNeg + "')";
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

