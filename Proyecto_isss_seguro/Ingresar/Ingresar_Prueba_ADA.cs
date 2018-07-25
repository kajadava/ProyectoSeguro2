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
    public partial class Ingresar_Prueba_ADA : Form
    {
        Clases.Conexion con = new Clases.Conexion();
        public Ingresar_Prueba_ADA()
        {
            InitializeComponent();
        }

        private void Ingresar_Prueba_ADA_Load(object sender, EventArgs e)
        {

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
                    Clases.PruebaADA ipada = new Clases.PruebaADA();
                    Clases.PruebaADA.insertarPruebaADA(con.conexion, ipada);

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

