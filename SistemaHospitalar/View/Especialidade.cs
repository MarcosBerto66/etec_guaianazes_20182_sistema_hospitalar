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
    using DAO;
    using Model;
    public partial class Especialidade : Form
    {
        DaoEspecialidade daoEspec = new DaoEspecialidade();
        int id = 0;
        public Especialidade()
        {
            InitializeComponent();
            desativa();
            tableDados.DataSource = daoEspec.preenche();
            tableDados.Columns[0].Visible = false;
            tableDados.Columns[1].HeaderText = "Descrição";
        }

        private void desativa() {
            txtDescricao.Enabled = false;
            txtPesquisar.Enabled = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            habilitar();
            txtDescricao.Clear();
        }

        public void habilitar()
        {
            txtPesquisar.Enabled = false;
            txtDescricao.Enabled = true;
        }

        public void desabilitar()
        {
            txtPesquisar.Enabled = true;
            txtDescricao.Enabled = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text.Equals(""))
            {
                MessageBox.Show("Campos incompletos!");
            }
            else
            {
                Model.Especialidade especialidade = new Model.Especialidade();
                especialidade.Descricaoespcialidade = txtDescricao.Text;

                MessageBox.Show(daoEspec.cadastrar(especialidade));
                txtDescricao.Text = "";
                desativa();
                tableDados.DataSource = daoEspec.preenche();
                Tela.m.atualizar();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void txtDescricao_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void Especialidade_Load(object sender, EventArgs e)
        {

        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            desabilitar();
        }

        private void tableDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            habilitar();
            var indice = tableDados.CurrentRow.Index;
            if (indice >= 0)
            {
                id = Convert.ToInt32(tableDados.Rows[indice].Cells[0].Value);
                string desc = tableDados.Rows[indice].Cells[1].Value.ToString();
                txtDescricao.Text = desc;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Equals(""))
            {
                MessageBox.Show("Campos incompletos!");
            }
            else
            {
                Model.Especialidade especialidade = new Model.Especialidade();
                especialidade.Descricaoespcialidade = txtDescricao.Text;
                especialidade.Codespcialidade = id;
                MessageBox.Show(daoEspec.editar(especialidade));
                txtDescricao.Text = "";
                desativa();
                tableDados.DataSource = daoEspec.preenche();
                Tela.m.atualizar();
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            var indice=-1;
            try
            {
                indice = tableDados.CurrentRow.Index;
                if (indice >= 0)
                {
                    if (MessageBox.Show("Deseja realmente excluir?", "Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(tableDados.Rows[indice].Cells[0].Value);
                        MessageBox.Show(daoEspec.excluir(id));
                        tableDados.DataSource = daoEspec.preenche();
                        txtDescricao.Clear();
                        desativa();
                        Tela.m.atualizar();
                    }
                }
            }
            catch {
                if (indice == -1 || indice == null)
                {
                    MessageBox.Show("Selecione uma linha para excluir!");
                }
            }
        }

        private void txtPesquisar_TextChanged_1(object sender, EventArgs e)
        {
            tableDados.DataSource = daoEspec.pesquisar(txtPesquisar.Text);
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
