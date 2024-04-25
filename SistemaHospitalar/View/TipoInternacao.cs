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
    public partial class TipoInternacao : Form
    {
        int id = 0;
        DAO.DAOTipoInternacao d = new DAO.DAOTipoInternacao();
        Model.tipoInternacao m = new Model.tipoInternacao();

        public TipoInternacao()
        {
            InitializeComponent();
            dataGridView1.DataSource = d.preencherDataGrid();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Descrição";
            desabiltar();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            habilitarAdd();
            clear();
        }

        public void habilitarAdd() {
            txtDesc.Enabled = true;
            txtPesq.Enabled = false;
            btnAdd.Enabled = false;
            btnSave.Enabled = true;
        }

        public void habilitarPesq() {
            txtDesc.Enabled = false;
            btnAdd.Enabled = true;
            btnSave.Enabled = false;
            txtPesq.Enabled = true;
        }

        public void desabiltar() {
            txtDesc.Enabled = false;
            txtPesq.Enabled = false;
        }

        public void clear() {
            txtDesc.Text = "";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            habilitarPesq();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDesc.Text.Equals(""))
            {
                MessageBox.Show("Campos incompletos!");
            }
            else
            {
                m.Descricao = txtDesc.Text;
                MessageBox.Show(d.cadastrar(m));

                dataGridView1.DataSource = d.preencherDataGrid();
                Tela.i.atualizacbTipo();
                clear();
                desabiltar();
                btnAdd.Enabled = true;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                var indice = dataGridView1.CurrentRow.Index;
                if (indice >= 0)
                {
                    if (MessageBox.Show("Deseja realmente excluir?", "Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dataGridView1.Rows[indice].Cells[0].Value);
                        MessageBox.Show(d.excluir(id));
                        dataGridView1.DataSource = d.preencherDataGrid();
                        clear();
                        desabiltar();
                        btnAdd.Enabled = true;
                        Tela.i.atualizacbTipo();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Selecione uma linha para excluir!");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtDesc.Equals(""))
            {
                MessageBox.Show("Campos incompletos!");
            }
            else
            {
                m.Descricao = txtDesc.Text;
                m.IdTipoInternacao = id;
                MessageBox.Show(d.editar(m));
                dataGridView1.DataSource = d.preencherDataGrid();
                clear();
                desabiltar();
                btnAdd.Enabled = true;
                Tela.i.atualizacbTipo();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             var indice = dataGridView1.CurrentRow.Index;
            if (indice >= 0)
            {
                id = Convert.ToInt32(dataGridView1.Rows[indice].Cells[0].Value);
                string desc = Convert.ToString(dataGridView1.Rows[indice].Cells[1].Value);
                habilitarAdd();
                txtDesc.Text = desc;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtPesq_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = d.pesquisar(txtPesq.Text);
        }
    }
}
