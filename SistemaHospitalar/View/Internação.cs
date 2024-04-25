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

    public partial class Internação : Form
    {
        DAOTipoInternacao t = new DAOTipoInternacao();
        DAOUsuario d = new DAOUsuario();
        DAOMedico daoM = new DAOMedico();
        DAOInternacao dao = new DAOInternacao();

        int [] vetM;
        int[] vetU;
        int[] vetT;

        int id = 0;

        public Internação()
        {
            InitializeComponent();
            atualizacbTipo();

            desabilitaCampos();

            DAOInternacao dao = new DAOInternacao();
            dataGridView1.DataSource = dao.preencherDataGrid();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Entrada";
            dataGridView1.Columns[2].HeaderText = "Saída";
            dataGridView1.Columns[3].HeaderText = "Resumo";
            dataGridView1.Columns[4].HeaderText = "Paciente";
            dataGridView1.Columns[5].HeaderText = "Tipo de internação";
            dataGridView1.Columns[6].HeaderText = "Médico";
            dataGridView1.Columns[7].HeaderText = "Usuário";

            clear();


            List<Model.Usuario> usuarios = new List<Model.Usuario>();
            usuarios = d.usuarios();
            vetU = new int[usuarios.Count];
            int l = 0;
            foreach (Model.Usuario i in usuarios)
            {
                cbUsers.Items.Add(i.Login);
                vetU[l] = i.Id;
                l++;
            }

            List<Model.Medico> m = new List<Model.Medico>();
            m = daoM.medicos();
            vetM = new int[m.Count];
            int j = 0;
            foreach (Model.Medico i in m)
            {
                cbMedicos.Items.Add(i.getNome());
                vetM[j] = i.getId();
                j++;
            }
        }

        public void atualizacbTipo() {
            cbTipo.Items.Clear();
            List<Model.tipoInternacao> tipos = new List<Model.tipoInternacao>();
            tipos = t.popularCB();
            vetT = new int[tipos.Count];
            int h = 0;
            foreach (Model.tipoInternacao i in tipos)
            {
                cbTipo.Items.Add(i.Descricao);
                vetT[h] = i.IdTipoInternacao;
                h++;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Internação_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            TipoInternacao t = new TipoInternacao();
            t.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (validacao())
            {
                Model.Internacao i = new Model.Internacao();
                i.DataAlta = txtDataAlta.Text;
                i.DataInternacao = txtDataEntrada.Text;
                i.IdTipoInternacao = vetT[cbTipo.SelectedIndex];
                i.IdUsuario = vetU[cbUsers.SelectedIndex];
                i.ResumoAlta = txtAlta.Text;
                i.IdMedico = vetM[cbMedicos.SelectedIndex];
                i.IdPaciente = Model.Paciente.pacienteSelecionado.getId();

                string retorno = dao.cadastrar(i);

                MessageBox.Show(retorno);
                dataGridView1.DataSource = dao.preencherDataGrid();
                clear();
                desabilitaCampos();
            }
            else {
                MessageBox.Show("Campos incompletos ou datas inválidas!");
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            clear();
            halitaCampos();
            txtPesquisa.Enabled = false;
        }

        public bool validacao() {
            if (txtAlta.Text.Equals("") || cbMedicos.SelectedIndex == -1
                 || Model.Paciente.pacienteSelecionado==null || cbTipo.SelectedIndex == -1 || cbUsers.SelectedIndex == -1) {
                    return false;
            }
            try
            {
                DateTime data = DateTime.Now.Date;
                DateTime outraData = Convert.ToDateTime(txtDataEntrada.Text);
                DateTime outraData2 = Convert.ToDateTime(txtDataAlta.Text);

                if (outraData >= data && outraData2 >= data)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch {
                return false;
            }
        }

        public void clear() {
            DateTime data = DateTime.Now.Date;
            txtPesquisa.Text = "";
            txtAlta.Text = "";
            txtDataAlta.Text = data.ToString();
            txtDataEntrada.Text = data.ToString();
            cbMedicos.SelectedIndex = -1;
            cbTipo.SelectedIndex = -1;
            cbUsers.SelectedIndex = -1;
            Model.Paciente.pacienteSelecionado = null;
            lblP.Text = "Nenhum paciente selecionado";
        }

        private void desabilitaCampos() {
            txtPesquisa.Enabled = false;
            txtAlta.Enabled = false;
            txtDataAlta.Enabled = false;
            txtDataEntrada.Enabled = false;
            cbMedicos.Enabled = false;
            cbTipo.Enabled = false;
            cbUsers.Enabled = false;
            addP.Enabled = false;
        }

        private void halitaCampos()
        {
            txtPesquisa.Enabled = true;
            txtAlta.Enabled = true;
            txtDataAlta.Enabled = true;
            txtDataEntrada.Enabled = true;
            cbMedicos.Enabled = true;
            cbTipo.Enabled = true;
            cbUsers.Enabled = true;
            addP.Enabled = true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            desabilitaCampos();
            txtPesquisa.Enabled = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
             var indice = dataGridView1.CurrentRow.Index;
             if (indice >= 0)
             {
                 id = Convert.ToInt32(dataGridView1.Rows[indice].Cells[0].Value);
                 txtDataEntrada.Text = dataGridView1.Rows[indice].Cells[1].Value.ToString();
                 txtDataAlta.Text = dataGridView1.Rows[indice].Cells[2].Value.ToString();
                 txtAlta.Text = dataGridView1.Rows[indice].Cells[3].Value.ToString();
                 cbTipo.SelectedItem = dataGridView1.Rows[indice].Cells[5].Value.ToString();
                 cbMedicos.SelectedItem = dataGridView1.Rows[indice].Cells[6].Value.ToString();
                 cbUsers.SelectedItem = dataGridView1.Rows[indice].Cells[7].Value.ToString();
                 Model.Paciente.pacienteSelecionado = new Model.Paciente();
                 Model.Paciente.pacienteSelecionado.setId(dao.pegaPaciente(id).getId());
                 Model.Paciente.pacienteSelecionado.setNome(dao.pegaPaciente(id).getNome());

                 lblP.Text = Model.Paciente.pacienteSelecionado.getNome();

                 halitaCampos();
                 txtPesquisa.Enabled = false;
             }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (validacao())
            {
                Model.Internacao i = new Model.Internacao();
                i.DataAlta = txtDataAlta.Text;
                i.DataInternacao = txtDataEntrada.Text;
                i.IdTipoInternacao = vetT[cbTipo.SelectedIndex];
                i.IdUsuario = vetU[cbUsers.SelectedIndex];
                i.ResumoAlta = txtAlta.Text;
                i.IdMedico = vetM[cbMedicos.SelectedIndex];
                i.IdInternacao = id;
                i.IdPaciente = Model.Paciente.pacienteSelecionado.getId();

                DAOInternacao dao = new DAOInternacao();
                string retorno = dao.editar(i);

                MessageBox.Show(retorno);
                dataGridView1.DataSource = dao.preencherDataGrid();
                clear();
                desabilitaCampos();
            }
            else
            {
                MessageBox.Show("Campos incompletos ou datas inválidas!");
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                DAOInternacao dao = new DAOInternacao();
                var indice = dataGridView1.CurrentRow.Index;
                if (indice >= 0)
                {
                    if (MessageBox.Show("Deseja realmente excluir?", "Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dataGridView1.Rows[indice].Cells[0].Value);
                        MessageBox.Show(dao.excluir(id));
                        dataGridView1.DataSource = dao.preencherDataGrid();
                        clear();
                        desabilitaCampos();
                    }
                }
            }
            catch {
                MessageBox.Show("Selecione uma linha para excluir!");
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            DAOInternacao dao = new DAOInternacao();
            dataGridView1.DataSource = dao.pesquisar(txtPesquisa.Text);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            tabelaPaciente tbP = new tabelaPaciente();
            tbP.Show();
        }

        public void atualizaCliente(String nome) {
            lblP.Text = nome;
            lblP.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
