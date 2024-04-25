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
    public partial class StatusDaConsulta : Form
    {
        DAO.DAOstatusConsulta statusDao = new DAO.DAOstatusConsulta();
        View.Consulta vConsulta; 
        int id = 0;

        public StatusDaConsulta(View.Consulta vC)
        {
            InitializeComponent();
            vConsulta = vC;
            dgv.DataSource = statusDao.select();
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].HeaderText = "Descrição";
            desabilita();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            novo();
        }

        private void desabilita() {
            txtDesc.Enabled = false;
            txtPesq.Enabled = false;
        }

        private void novo(){
            txtDesc.Enabled = true;
            txtPesq.Enabled = false;
        }

        private void pesq() {
            txtPesq.Enabled = true;
            txtDesc.Enabled = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (txtDesc.Text.Equals(""))
            {
                MessageBox.Show("Campos incompletos!");
            }
            else
            {
                Model.StatusConsulta status = new Model.StatusConsulta();

                status.DescricaoStatusconsulta = txtDesc.Text;

                String resposta;

                resposta = statusDao.insert(status);
                txtDesc.Clear();
                MessageBox.Show(resposta);
                dgv.DataSource = statusDao.select();
                desabilita();
                vConsulta.atualizar();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            desabilita();
            try{
            var indice = dgv.CurrentRow.Index;
            if (indice >= 0)
            {
                if (MessageBox.Show("Deseja realmente excluir?", "Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgv.Rows[indice].Cells[0].Value);
                    MessageBox.Show(statusDao.remove(id));
                    dgv.DataSource = statusDao.select();
                    txtDesc.Clear();
                }
            }
            }catch{
                MessageBox.Show("Selecione uma linha para excluir!");
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pesq();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var indice = dgv.CurrentRow.Index;
            if (indice >= 0)
            {
                novo();
                id = Convert.ToInt32(dgv.Rows[indice].Cells[0].Value);
                string descricao = dgv.Rows[indice].Cells[1].Value.ToString();
                txtDesc.Text = descricao;
            }
        }

        private void txtPesq_TextChanged(object sender, EventArgs e)
        {
            dgv.DataSource = statusDao.query(txtPesq.Text);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (txtDesc.Text.Equals(""))
            {
                MessageBox.Show("Campos incompletos!");
            }
            else
            {
                Model.StatusConsulta status = new Model.StatusConsulta();

                status.DescricaoStatusconsulta = txtDesc.Text;
                status.Codstatusconsulta = id;

                String resposta;

                resposta = statusDao.update(status);
                MessageBox.Show(resposta);
                txtDesc.Clear();
                dgv.DataSource = statusDao.select();
                desabilita();
            }

        }
    }
}
