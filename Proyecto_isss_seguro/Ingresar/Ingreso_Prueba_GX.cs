using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Proyecto_isss_seguro
{
    public partial class Ingreso_Prueba_GX : Form
    {
        Clases.Conexion con = new Clases.Conexion();
        public Ingreso_Prueba_GX()
        {
            InitializeComponent();
        }

        private void buttoncancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ver_Prueba vnt0 = new Ver_Prueba();
            vnt0.Show();
        }

        private void buttonguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.conectar())
                {
                    Clases.Prueba ip = new Clases.Prueba(Convert.ToInt32(label4), 1);
                    Clases.Prueba.ingresarprueba(con.conexion, ip);
                    Clases.PruebaGX ipbk = new Clases.PruebaGX(                        );
                    Clases.PruebaGX.insertarPruebaGX(con.conexion, ipbk);

                    MessageBox.Show("Muestra Ingresada Exitosamente");
                }
            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Error al insertar la muestra" + ex);
            }
            con.desconectar();
        }
    }
}
