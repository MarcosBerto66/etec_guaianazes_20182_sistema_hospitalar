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
    public partial class tabelaPaciente : Form
    {
        Model.Paciente p;

        public tabelaPaciente()
        {
            InitializeComponent();
            DAO.DAOPaciente dao = new DAO.DAOPaciente();
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
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var indice = dgv.CurrentRow.Index;
            if (indice >= 0)
            {
                int id = Convert.ToInt32(dgv.Rows[indice].Cells[0].Value);
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

                p = new Model.Paciente();
                p.setId(id);
                p.setNome(nome);
                p.setCpf(cpf);
                p.setNascimento(nasc);
                p.setRg(rg);
                p.setLogradouro(logra);
                p.setCep(cep);
                p.setN(n);
                p.setBairro(bairro);
                p.setCidade(cid);
                p.setEstado(est);

                Model.Paciente.pacienteSelecionado = p;
                Tela.i.atualizaCliente(nome);
                Dispose();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DAO.DAOPaciente dao = new DAO.DAOPaciente();
            dgv.DataSource = dao.pesquisar(textBox1.Text);
        }
    }
}
