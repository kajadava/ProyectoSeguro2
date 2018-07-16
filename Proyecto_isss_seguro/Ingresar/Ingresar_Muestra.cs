﻿using System;
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
    public partial class Ingresar_Muestra : Form
    {
        Clases.Conexion con = new Clases.Conexion();
        public Ingresar_Muestra()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (con.conectar() == true)
                {
                    comboBox1.Items.Insert(0, "Seleccionar");
                    comboBox1.SelectedIndex = 0;
                    comboBox1.DataSource = Clases.Establecimiento.cargarestablecimientosrefamot(con.conexion);
                    comboBox1.DisplayMember = "nombreEstablecimiento";
                    comboBox1.ValueMember = "idEstablecimiento";
                    
                    con.desconectar();
                    con.conectar();
                    comboBox2.Items.Insert(0, "Seleccionar");
                    comboBox2.SelectedIndex = 0;
                    comboBox2.DataSource = Clases.Establecimiento.cargarestablecimientoscultamot(con.conexion);
                    comboBox2.DisplayMember = "nombreEstablecimiento";
                    comboBox2.ValueMember = "idEstablecimiento";
                    
                    con.desconectar();
                    con.conectar();
                    cbTipoMuestra.Items.Insert(0, "Seleccionar");
                    cbTipoMuestra.SelectedIndex = 0;
                    cbTipoMuestra.DataSource = Clases.TipoMuestra.cargarCbTipoMuestra(con.conexion);
                    cbTipoMuestra.DisplayMember = "nombreTipoMuestra";
                    cbTipoMuestra.ValueMember = "idTipoMuestra";
                    
                }

            }
            catch (MySqlException ex)
            {
                throw ex;
            }

            con.desconectar();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxafiliacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttoncancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ver.Expediente vnt1 = new Ver.Expediente(label7.Text);
            vnt1.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void buttonguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.conectar())
                {
                    Clases.Muestra mu = new Clases.Muestra(Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(label7.Text), this.dateTimePicker2.Value.ToString(), textBoxObservacion.Text, Convert.ToInt32(comboBox1.SelectedValue), Convert.ToInt32(comboBox2.SelectedValue));
                    Clases.Muestra.insertarMuestra(con.conexion, mu);
                    MessageBox.Show("Muestra Ingresada Exitosamente");
                }
            }catch(MySqlException ex)
            {
                MessageBox.Show("Error al insertar la muestra"+ex);
            }
            con.desconectar();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
