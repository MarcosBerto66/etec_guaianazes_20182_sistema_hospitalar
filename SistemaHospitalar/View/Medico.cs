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
    public partial class Medico : Form
    {
        private List<Model.Especialidade> nomes = new List<Model.Especialidade>();
        DAO.DAOMedico daoMedico = new DAO.DAOMedico();
        int id = 0;
        int[] vet;

        public Medico()
        {
            InitializeComponent();
            dataGridViewMedico.DataSource = daoMedico.consultar();
            dataGridViewMedico.Columns[0].Visible = false;
            dataGridViewMedico.Columns[1].HeaderText = "Nome";
            dataGridViewMedico.Columns[2].HeaderText = "CRM";
            dataGridViewMedico.Columns[3].HeaderText = "Especialidade";
            atualizar();
            desativa();
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (txtNomeMedico.Text == "" || txtCrmMedico.Text == "" || comboEspecialidadeMedico.SelectedIndex == -1)
            {
                MessageBox.Show("Insira todos os dados!");
            }
            else
            {
                Model.Medico m = new Model.Medico();
                m.setNome(txtNomeMedico.Text);
                m.setCrm(txtCrmMedico.Text);
                int indice = comboEspecialidadeMedico.SelectedIndex;
                m.setEspecialidade(vet[indice]);
               
                MessageBox.Show(daoMedico.cadastrar(m));
                dataGridViewMedico.DataSource = daoMedico.consultar();
                desativa();
                clear();
            }
        }

        private void clear()
        {
            txtNomeMedico.Text = "";
            txtCrmMedico.Text = "";
            comboEspecialidadeMedico.SelectedIndex = -1;
        }

        private void exclui_Click(object sender, EventArgs e)
        {
            var indice = dataGridViewMedico.CurrentRow.Index;
            if (indice >= 0)
            {
                if (MessageBox.Show("Deseja realmente excluir?", "Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridViewMedico.Rows[indice].Cells[0].Value);
                    MessageBox.Show(daoMedico.excluir(id));
                    dataGridViewMedico.DataSource = daoMedico.consultar();
                    desativa();
                    clear();
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Especialidade es = new Especialidade();
            es.ShowDialog();
        }

        public void atualizar()
        {
            nomes = daoMedico.popularEspecialidade();
            vet = new int[nomes.Count];
            int i = 0;
            comboEspecialidadeMedico.Items.Clear();
            foreach (Model.Especialidade j in nomes)
            {
                comboEspecialidadeMedico.Items.Add(j.Descricaoespcialidade);
                vet[i] = j.Codespcialidade;
                i++;
            }
        }

        private void habilita() {
            txtNomeMedico.Enabled = true;
            txtCrmMedico.Enabled = true;
            comboEspecialidadeMedico.Enabled = true;
            textBox3.Enabled = false;
        }

        private void desabilita() {
            txtNomeMedico.Enabled = false;
            txtCrmMedico.Enabled = false;
            comboEspecialidadeMedico.Enabled = false;
            textBox3.Enabled = true;
        }

        private void desativa() {
            txtNomeMedico.Enabled = false;
            txtCrmMedico.Enabled = false;
            comboEspecialidadeMedico.Enabled = false;
            textBox3.Enabled = false;        
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            habilita();
            clear();
        }

        private void relaEspecifico_Click(object sender, EventArgs e)
        {

        }

        private void relaGeral_Click(object sender, EventArgs e)
        {
            desabilita();
        }

        private void dataGridViewMedico_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           var indice = dataGridViewMedico.CurrentRow.Index;
           if (indice >= 0)
           {
               id = Convert.ToInt32(dataGridViewMedico.Rows[indice].Cells[0].Value);
               string nome = dataGridViewMedico.Rows[indice].Cells[1].Value.ToString();
               string crm = dataGridViewMedico.Rows[indice].Cells[2].Value.ToString();
               string espec = dataGridViewMedico.Rows[indice].Cells[3].Value.ToString();

               txtNomeMedico.Text = nome;
               txtCrmMedico.Text = crm;
               comboEspecialidadeMedico.SelectedItem = espec;
               habilita();
           }
        }

        private void edita_Click(object sender, EventArgs e)
        {
            if (txtNomeMedico.Text == "" || txtCrmMedico.Text == "" || comboEspecialidadeMedico.SelectedIndex == -1)
            {
                MessageBox.Show("Insira todos os dados!");
            }
            else
            {
                Model.Medico m = new Model.Medico();
                m.setNome(txtNomeMedico.Text);
                m.setCrm(txtCrmMedico.Text);
                int indice = comboEspecialidadeMedico.SelectedIndex;
                m.setEspecialidade(vet[indice]);
                m.setId(id);

                MessageBox.Show(daoMedico.editar(m));
                clear();
                desativa();
                dataGridViewMedico.DataSource = daoMedico.consultar();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            dataGridViewMedico.DataSource = daoMedico.pesquisar(textBox3.Text);
        }
    }
}
