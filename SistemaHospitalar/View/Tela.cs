using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SistemaHospitalar.View;

namespace SistemaHospitalar
{
    public partial class Tela : Form
    {
        public static Internação i = new Internação();
        public static Medico m = new Medico();
        public Tela()
        {
            Login log = new Login();
            log.ShowDialog();
            InitializeComponent();
            this.Height = Screen.PrimaryScreen.Bounds.Height;
            panel1.Height = Screen.PrimaryScreen.Bounds.Height;
            this.Width = Screen.PrimaryScreen.Bounds.Width;
            //painelPacientes.Visible = false;

            //this.TopMost = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void lblPacientes_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Paciente p = new Paciente();
            p.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            m.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            i = new Internação();
            i.ShowDialog();
            //TipoInternacao ti = new TipoInternacao();
            //ti.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            novoUser u = new novoUser();
            u.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Consulta c = new Consulta();
            c.ShowDialog();
        }
    }
}
