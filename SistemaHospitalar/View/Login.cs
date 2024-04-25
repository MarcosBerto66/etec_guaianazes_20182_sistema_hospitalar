using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SistemaHospitalar.View
{
    public partial class Login : Form
    {
        public static string l;
        public static string s;
        DAO.DAOUsuario dao = new DAO.DAOUsuario();

        public Login()
        {
            Splash s = new Splash();
            s.ShowDialog();
            InitializeComponent();
            textBox1.Text = "Usuário";
            textBox2.Text = "Senha";
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Usuário")
            {
                textBox1.Text = "";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Senha")
            {
                textBox2.Text = "";
                textBox2.PasswordChar = Convert.ToChar("•");
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Senha";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Usuário";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Model.Usuario u = new Model.Usuario();
            u.Login = textBox1.Text;
            u.Senha = textBox2.Text;
            bool retorno = dao.fazerLogin(u);
            if (retorno)
            {
                MessageBox.Show("Seja bem vindo!");
                Dispose();
            }
            else {
                MessageBox.Show("Login e/ou senha incorretos!");
            }
        }
    }
}
