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
    public partial class novoUser : Form
    {
        DAO.DAOUsuario dao = new DAO.DAOUsuario();
        Model.Usuario model = new Model.Usuario();
        int id = 0;

        public novoUser()
        {
            InitializeComponent();
            dataGridView1.DataSource = dao.consultar();
            desabilitar();
            textBox3.Enabled = false;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Login";
            //dataGridView1.Columns[2].HeaderText = "Senha";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void novoUser_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void habilitar() {
            textBox1.Enabled = true;
            textBox3.Enabled = false;
        }

        private void desabilitar() {
            textBox1.Enabled = false;
            textBox3.Enabled = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("Campos incompletos!");
            }
            else
            {
                model.Login = textBox1.Text;

                MessageBox.Show(dao.cadastrar(model));
                clear();
                dataGridView1.DataSource = dao.consultar();
                desabilitar();
                textBox3.Enabled = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            habilitar();
            clear();
        }

        private void clear() {
            textBox1.Clear();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            desabilitar();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var indice = dataGridView1.CurrentRow.Index;
            if (indice >= 0)
            {
                id = Convert.ToInt32(dataGridView1.Rows[indice].Cells[0].Value);
                string login = dataGridView1.Rows[indice].Cells[1].Value.ToString();
                habilitar();
                textBox1.Text = login;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                var indice = dataGridView1.CurrentRow.Index;
                if (indice >= 0)
                {
                    if (MessageBox.Show("Deseja realmente excluir?", "Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string login = dataGridView1.Rows[indice].Cells[1].Value.ToString();
                        MessageBox.Show(dao.deletarUsuario(login));
                        dataGridView1.DataSource = dao.consultar();
                        clear();
                    }
                }
            }
            catch {
                MessageBox.Show("Selecione uma linha para excluir!");
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("Campos incompletos!");
            }
            else
            {
                model.Id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                model.Login = textBox1.Text;
                MessageBox.Show(dao.editar(model));
                clear();
                desabilitar();
                textBox3.Enabled = false;
                dataGridView1.DataSource = dao.consultar();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dao.pesquisar(textBox3.Text);
        }
    }
}
