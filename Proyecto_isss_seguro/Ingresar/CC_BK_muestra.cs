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

namespace Proyecto_isss_seguro.Ingresar
{
    

    public partial class CC_BK_muestra : Form
    {
        Clases.Conexion con = new Clases.Conexion();
        public CC_BK_muestra()
        {
            InitializeComponent();
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void buttonguardar_Click(object sender, EventArgs e)
        {
            try
            {

                if (con.conectar())
                {
                    Clases.CCBKmuestra cc2 = new Clases.CCBKmuestra(comboBox2.Text, comboBox1.Text, Convert.ToInt32(textBox17.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox15.Text), Convert.ToInt32(textBox16.Text), Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text), Convert.ToDecimal(textBox7.Text), Convert.ToDecimal(textBox18.Text), Convert.ToDecimal(textBox8.Text), Convert.ToDecimal(textBox1.Text), Convert.ToDecimal(textBox9.Text), Convert.ToDecimal(textBox2.Text), Convert.ToDecimal(textBox10.Text), Convert.ToDecimal(textBox11.Text), Convert.ToDecimal(textBox4.Text), Convert.ToDecimal(textBox12.Text));
                    Clases.CCBKmuestra.insertarCCBKmuestras(con.conexion, cc2);
                    MessageBox.Show("Consolidado Ingresado Exitosamente");
                    comboBox2.Text = "";
                    comboBox1.Text = "";
                    textBox17.Text = "";
                    textBox3.Text = "";
                    textBox15.Text = "";
                    textBox16.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox18.Text = "";
                    textBox8.Text = "";
                    textBox1.Text = "";
                    textBox9.Text = "";
                    textBox2.Text = "";
                    textBox10.Text = "";
                    textBox11.Text = "";
                    textBox4.Text = "";
                    textBox12.Text = "";

                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al insertar el consolidado" + ex);
            }
            con.desconectar();
        }

        private void buttoncancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu_Consolidados vnt0 = new Menu_Consolidados();
            vnt0.Show();
        }
    }
}
