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
    public partial class Paciente : Form
    {
        int id=0;
        Model.Paciente pac;
        DAO.DAOPaciente dao = new DAO.DAOPaciente();
        List<string> tels;
        Model.Paciente p;
        DAO.DAOPaciente dp = new DAO.DAOPaciente();
        string retorno;
        public Paciente()
        {
            InitializeComponent();
            dgv.DataSource = dao.consultar();
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].HeaderText = "Nome";
            dgv.Columns[2].HeaderText = "CPF";
            dgv.Columns[4].HeaderText = "RG";
            dgv.Columns[3].HeaderText = "Data de nascimento";
            dgv.Columns[5].HeaderText = "Logradouro";
            dgv.Columns[6].HeaderText = "CEP";
            dgv.Columns[7].HeaderText = "Casa";
            dgv.Columns[8].HeaderText = "Bairro";
            dgv.Columns[9].HeaderText = "Cidade";
            dgv.Columns[10].HeaderText = "Estado";
            desabilitaCampos();
            txtPesquisa.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            List<string> tels = listBox1.Items.Cast<String>().ToList();
            bool retorno=false;
            foreach(string i in tels){
                if (i.Equals(txtTelefone.Text)) {
                    retorno = true;
                }
            }
            if (retorno == false)
            {
                if (txtTelefone.Text.Length > 13)
                {
                    listBox1.Items.Add(txtTelefone.Text);
                    txtTelefone.Clear();
                    txtTelefone.Focus();
                }
                else {
                }
            }
            else {
                MessageBox.Show("Já possui este telefone na lista!");
                txtTelefone.Clear();
                txtTelefone.Focus();
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private bool validacao() {
             if (txtNome.Text.Equals("") || txtNascimento.Text.Trim().Length < 8 ||
                txtNum.Text.Equals("") || txtRG.Text.Equals("") || txtBairro.Text.Equals("")
                || txtCEP.Text.Trim().Length < 9 || txtCidade.Text.Equals("") || txtEstado.SelectedIndex == -1
                || txtCPF.Text.Trim().Length < 11 || txtLogradouro.Text.Equals(""))
            {
                MessageBox.Show("Campos incompletos!");
                 return false;
            }
            else {
                 return true;
             }
        }

        private void construirPaciente(){
                    p = new Model.Paciente();
                    p.setNome(txtNome.Text);
                    p.setNascimento(txtNascimento.Text);
                    p.setN(txtNum.Text);
                    p.setRg(txtRG.Text);
                    p.setBairro(txtBairro.Text);
                    p.setCep(txtCEP.Text);
                    p.setCidade(txtCidade.Text);
                    p.setEstado(txtCidade.Text);
                    p.setEstado(txtEstado.SelectedItem.ToString());
                    p.setCpf(txtCPF.Text);
                    p.setLogradouro(txtLogradouro.Text);
                    tels = listBox1.Items.Cast<String>().ToList();
                    p.setTelefones(tels);
        }

        private void add_Click(object sender, EventArgs e)
        {
            if(validacao()){
                construirPaciente();
                retorno = dp.cadastrar(p, tels);
                clear();
                MessageBox.Show(retorno);
                dgv.DataSource = dao.consultar();
                desabilitaCampos();
                txtPesquisa.Enabled = false;
             }
        }

        public void clear() {
            txtNome.Text= ""; 
            txtNascimento.Text="";
            txtNum.Text="";
            txtRG.Text="";
            txtBairro.Text="";
            txtCEP.Text="";
            txtCidade.Text="";
            txtEstado.SelectedIndex = -1;
            txtCPF.Text="";
            txtLogradouro.Text = "";
            listBox1.Items.Clear();
        }

        private void exclui_Click(object sender, EventArgs e)
        {
            try
            {
                var indice = dgv.CurrentRow.Index;
                if (indice >= 0)
                {
                    if (MessageBox.Show("Deseja realmente excluir?", "Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dgv.Rows[indice].Cells[0].Value);
                        MessageBox.Show(dao.excluir(id));
                        dgv.DataSource = dao.consultar();
                        clear();
                        desabilitaCampos();
                        txtPesquisa.Enabled = false;
                    }
                }
            }
            catch {
                MessageBox.Show("Selecione uma linha para excluir!");
            }
        }

        private void edita_Click(object sender, EventArgs e)
        {
            if (validacao())
            {
                construirPaciente();
                p.setId(id);
                retorno = dp.editar(p, tels);
                clear();
                MessageBox.Show(retorno);
                dgv.DataSource = dao.consultar();
                desabilitaCampos();
                txtPesquisa.Enabled = false;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtLogradouro_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCPF_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtCEP_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            habilitaCampos();
            clear();
        }

        private void habilitaCampos() {
            txtPesquisa.Enabled = false;

            txtEstado.Enabled = true;

            foreach (Control gb in this.Controls)
            {
                if (gb is GroupBox)
                {
                    foreach (Control tb in gb.Controls)
                    {
                        if (tb is TextBox)
                        {
                            tb.Enabled = true;
                        }
                        if (tb is MaskedTextBox)
                        {
                            tb.Enabled = true;
                        }
                    }
                }
            }
        }

        private void desabilitaCampos()
        {
            txtPesquisa.Enabled = true;
            txtEstado.Enabled = false;

            foreach (Control gb in this.Controls)
            {
                if (gb is GroupBox)
                {
                    foreach (Control tb in gb.Controls)
                    {
                        if (tb is TextBox)
                        {
                            tb.Enabled = false;
                        }
                        if (tb is MaskedTextBox)
                        {
                            tb.Enabled = false;
                        }
                    }
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            clear();
            desabilitaCampos();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            habilitaCampos();
            var indice = dgv.CurrentRow.Index;
            if (indice >= 0)
            {
                id = Convert.ToInt32(dgv.Rows[indice].Cells[0].Value);
                string nome = Convert.ToString(dgv.Rows[indice].Cells[1].Value);
                string cpf = Convert.ToString(dgv.Rows[indice].Cells[2].Value);
                string nasc = Convert.ToString(dgv.Rows[indice].Cells[3].Value);
                string rg = Convert.ToString(dgv.Rows[indice].Cells[4].Value);
                string logra = Convert.ToString(dgv.Rows[indice].Cells[5].Value);
                string cep = Convert.ToString(dgv.Rows[indice].Cells[6].Value);
                string n = Convert.ToString(dgv.Rows[indice].Cells[7].Value);
                string bairro = Convert.ToString(dgv.Rows[indice].Cells[8].Value);
                string cid = Convert.ToString(dgv.Rows[indice].Cells[9].Value);
                string est = Convert.ToString(dgv.Rows[indice].Cells[10].Value);

                txtNome.Text = nome;
                txtCPF.Text = cpf;
                txtNascimento.Text = nasc;
                txtRG.Text = rg;
                txtLogradouro.Text = logra;
                txtCEP.Text = cep;
                txtNum.Text = n;
                txtBairro.Text = bairro;
                txtCidade.Text = cid;
                txtEstado.SelectedItem = est;

                List<string> tels = dao.consultar(id);

                foreach (string t in tels)
                {
                    listBox1.Items.Add(t);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index >= 0)
            {
                listBox1.Items.RemoveAt(index);
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            dgv.DataSource = dao.pesquisar(txtPesquisa.Text);
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
