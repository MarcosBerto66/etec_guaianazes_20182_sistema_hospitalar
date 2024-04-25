using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace SistemaHospitalar.View
{
    public partial class Consulta : Form
    {


        //Criar os objetos
        SqlDataReader Leitor = null;
        int paginaAtual;


        DAO.DAOConsulta daoConsulta = new DAO.DAOConsulta();
        DAO.DAOPaciente daoPaciente = new DAO.DAOPaciente();
        DAO.DAOMedico daoMedico = new DAO.DAOMedico();
        DAO.DAOstatusConsulta daoStatusConsulta = new DAO.DAOstatusConsulta();

        private List<Model.Paciente> paciente = new List<Model.Paciente>();
        private List<Model.Medico> medico = new List<Model.Medico>();
        private List<Model.StatusConsulta> statusConsulta = new List<Model.StatusConsulta>();
        int[] idStatusConsulta;
        int[] idPaciente;
        int[] idMedico;

        int id;
        int idConsulta = 0;

        Model.Consulta c;

        public Consulta()
        {
            InitializeComponent();
            dataGridViewConsulta.DataSource = daoConsulta.consultar();
            dgv.DataSource = daoPaciente.consultar();

            dataGridViewConsulta.Columns[0].Visible = false;
            dataGridViewConsulta.Columns[1].HeaderText = "Data da consulta";
            dataGridViewConsulta.Columns[2].HeaderText = "Horário da consulta";
            dataGridViewConsulta.Columns[3].HeaderText = "Paciente";
            dataGridViewConsulta.Columns[4].HeaderText = "Médico";
            dataGridViewConsulta.Columns[5].HeaderText = "Status da consulta";

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

            txtDataConsulta.Text = DateTime.Today.Date.ToString();
            desabilitaCampos();
            atualizar();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            habilitaCampos();
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (validacao())
            {
                if (construirConsulta())
                {
                    clear();
                    if (daoConsulta.cadastrar(c))
                    {
                        MessageBox.Show("Consulta agendada com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Consulta não cadastrada!");
                    }

                    dataGridViewConsulta.DataSource = daoConsulta.consultar();
                    desabilitaCampos();
                }
            }
            else {
                MessageBox.Show("Data inválida ou campos vazios!");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            StatusDaConsulta s = new StatusDaConsulta(this);
            s.ShowDialog();
        }
        public void atualizar()
        {
            paciente = daoPaciente.popularCB();
            idPaciente = new int[paciente.Count];
            int i = 0;
            cbPacientes.Items.Clear();
            foreach (Model.Paciente j in paciente)
            {
                cbPacientes.Items.Add(j.getNome());
                idPaciente[i] = j.getId();
                i++;
            }

            medico = daoMedico.medicos();
            idMedico = new int[medico.Count];
            i = 0;
            cbMedicos.Items.Clear();
            foreach (Model.Medico j in medico)
            {
                cbMedicos.Items.Add(j.getNome());
                idMedico[i] = j.getId();
                i++;
            }

            statusConsulta = daoStatusConsulta.statusConsulta();
            idStatusConsulta = new int[statusConsulta.Count];
            i = 0;
            cbStatusConsulta.Items.Clear();
            foreach (Model.StatusConsulta j in statusConsulta)
            {
                cbStatusConsulta.Items.Add(j.DescricaoStatusconsulta);
                idStatusConsulta[i] = j.Codstatusconsulta;
                i++;
            }


        }

        private Boolean construirConsulta()
        {
            var indice = dgv.CurrentRow.Index;
            c = new Model.Consulta();
            c.setIdPaciente(Convert.ToInt32(dgv.Rows[indice].Cells[0].Value));
            c.setIdMedico(idMedico[cbMedicos.SelectedIndex]);
            c.setStatusConsulta(idStatusConsulta[cbStatusConsulta.SelectedIndex]);
            c.setDataConsulta(txtDataConsulta.Text);
            c.setHoraConsulta(txtHorario.Text);
            c.setUsuario(1);

            try
            {
                TimeSpan.Parse(c.getHoraConsulta());
            }
            catch
            {
                MessageBox.Show("Horario invalido!");
                return false;
            }
            return true;
        }

        private void habilitaCampos()
        {
            txtPesquisa.Enabled = false;
            txtDataConsulta.Enabled = true;
            txtHorario.Enabled = true;
            dgv.Enabled = true;
            txtPesquisa.Text = "";

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
                        if (tb is ComboBox)
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
            txtDataConsulta.Enabled = false;
            txtHorario.Enabled = false;
            dgv.Enabled = false;

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
                        if (tb is ComboBox)
                        {
                            tb.Enabled = false;
                        }
                    }
                }
            }
        }

        public void clear()
        {
            cbPacientes.SelectedIndex = -1;
            cbMedicos.SelectedIndex = -1;
            cbStatusConsulta.SelectedIndex = -1;
            txtDataConsulta.Text = DateTime.Now.Date.ToString();
            txtHorario.Text = DateTime.Now.Hour.ToString(format: "00:00");
        }

        public Boolean validacao()
        {
            if (dgv.CurrentRow.Index <= -1 || cbMedicos.SelectedIndex == -1 || cbStatusConsulta.SelectedIndex == -1 )
            {
                return false;
            }
            else
            {
                try
                {
                    DateTime data = DateTime.Now.Date;
                    DateTime outraData = Convert.ToDateTime(txtDataConsulta.Text);

                    if (outraData >= data)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return false;
                }
               
            }
        }

        private void exclui_Click(object sender, EventArgs e)
        {
            try
            {
                var indice = dataGridViewConsulta.CurrentRow.Index;
                if (indice >= 0)
                {
                    if (MessageBox.Show("Deseja realmente excluir?", "Exclusão", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(dataGridViewConsulta.Rows[indice].Cells[0].Value);
                        if (daoConsulta.excluir(id))
                        {
                            MessageBox.Show("Excluido com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível excluir!");
                        }
                        dataGridViewConsulta.DataSource = daoConsulta.consultar();
                        clear();
                        desabilitaCampos();
                        txtPesquisa.Enabled = false;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Selecione uma linha para excluir!");
            }
        }

        private void edita_Click(object sender, EventArgs e)
        {
            if (validacao())
            {
                if (construirConsulta())
                {

                }
                c.setIdConsulta(id);
                if (daoConsulta.editar(c))
                {
                    MessageBox.Show("Dados editados com sucesso!");
                }
                else
                {
                    MessageBox.Show("Não foi possivel editar!");
                }
                clear();
                dataGridViewConsulta.DataSource = daoConsulta.consultar();
                desabilitaCampos();
                txtPesquisa.Enabled = false;
                btnAtivar();
            }
            else {
                MessageBox.Show("Data inválida ou campos vazios!");
            }
        }

        private void dataGridViewConsulta_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            habilitaCampos();
            btnDesativar();
            var indice = dataGridViewConsulta.CurrentRow.Index;
            if (indice >= 0)
            {
                this.id = Convert.ToInt32(dataGridViewConsulta.Rows[indice].Cells[0].Value);

                txtDataConsulta.Text = dataGridViewConsulta.Rows[indice].Cells[1].Value.ToString();
                txtHorario.Text = dataGridViewConsulta.Rows[indice].Cells[2].Value.ToString();
                int[] ids = daoConsulta.id(id);
                for (int i = 0; i < ids.Length; i++)
                {
                    if (i == 0)
                    {
                        for (int x = 0; x < idMedico.Length; x++)
                        {
                            if (idMedico[x] == ids[i])
                            {
                                cbMedicos.SelectedIndex = x;
                            }
                        }
                    }
                    else if (i == 1)
                    {
                        for (int x = 0; x < idStatusConsulta.Length; x++)
                        {
                            if (idStatusConsulta[x] == ids[i])
                            {
                                cbStatusConsulta.SelectedIndex = x;
                            }
                        }
                    }
                }

                int idPaciente = daoConsulta.pesquisarId(Convert.ToInt32(dataGridViewConsulta.Rows[indice].Cells[0].Value));
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dgv.Rows[i].Cells[0].Value) == idPaciente)
                    {
                        dgv.TabIndex = i;
                    }
                }
            }
        }

        private void btnAtivar()
        {
            add.Enabled = true;
        }

        private void btnDesativar()
        {
            add.Enabled = false;
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            dataGridViewConsulta.DataSource = daoConsulta.pesquisar(txtPesquisa.Text);
        }

        private void cbPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void relaEspecifico_Click(object sender, EventArgs e)
        {
            //Define os objetos printdocument e os Eventos Associados
            PrintDocument pd = new PrintDocument();
            //IMPORTANTE - Definimos 3 eventos para tratar a 
            //Impressão: PringPage , BeginPrint e EndPrint
            pd.PrintPage += new PrintPageEventHandler(this.printDocument1_PrintPage);
            pd.BeginPrint += new PrintEventHandler(this.printDocument1_BeginPrint);
            pd.EndPrint += new PrintEventHandler(this.printDocument1_EndPrint);
            //Define o Objeto para visualizar a impressão
            PrintPreviewDialog objPrintPreview = new PrintPreviewDialog();
            try
            {
                //Define o formulário como Maximizado e com Zoom
                {
                    objPrintPreview.Document = pd;
                    objPrintPreview.WindowState = FormWindowState.Maximized;
                    objPrintPreview.PrintPreviewControl.Zoom = 1;
                    objPrintPreview.Text = "RELATÓRIO GERAL CONSULTAS";
                    objPrintPreview.ShowDialog();
                }	
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }

        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
                SqlCommand cmd = new SqlCommand("select tbPaciente.nome, nomeMedico, descricaoStatusConsulta, dataConsulta, horaConsulta from tbConsulta"+
	                " inner join tbPaciente"+
		                " on tbConsulta.idPaciente = tbPaciente.idPaciente"+
			                " inner join tbMedico"+
				                " on tbConsulta.idMedico = tbMedico.idMedico"+
					                " inner join tbStatusConsulta"+
						                " on tbConsulta.idStatusConsulta = tbStatusConsulta.idStatusConsulta", Conexao.con);
                Conexao.conectar();
                Leitor = cmd.ExecuteReader();
                paginaAtual = 1;//Verificar esta linha

        }

        private void printDocument1_EndPrint(object sender, PrintEventArgs e)
        {
            //Fecha o DataReader
            Leitor.Close();
            //Fecha a Conexão
            Conexao.desconectar();
        
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            //Variáveis das Linhas
            float LinhasPorPagina = 0;
            float PosicaoDaLinha = 0;
            int LinhaAtual = 0;

            //Variável para passar um traço
            Pen Risco = new Pen(Color.Black, 1);

            //Define as Fontes
            Font FonteNegrito = new Font("Arial", 9, FontStyle.Bold);
            Font FonteTitulo = new Font("Arial", 15, FontStyle.Bold);
            Font FonteSubTitulo = new Font("Arial", 12, FontStyle.Bold);
            Font FonteRodape = new Font("Arial", 8);
            Font FonteNormal = new Font("Arial", 9);

            //Cabeçalho
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 60, e.MarginBounds.Right, 60);
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 160, e.MarginBounds.Right, 160);

            // criando uma imagem
            /*        Image newImage = Image.FromFile("Image/logo.jpg");

                            // tamanhos e posicionamento da imagem
                            int x = 10;
                            int y = 50;
                            int width = 100;
                            int height = 100;

                            // Insere a imagem no relatório
                            e.Graphics.DrawImage(newImage, x, y, width, height);*/


            //Titulo
            e.Graphics.DrawString("RELATÓRIO GERAL", FonteTitulo, Brushes.Black, e.MarginBounds.Left + 10, 80, new StringFormat());

            //Subtitulo
            e.Graphics.DrawString("CONSULTAS - " +
            System.DateTime.Now, FonteSubTitulo, Brushes.Black,
            e.MarginBounds.Left + 320, 120, new StringFormat());

            //Campos a Serem Impressos
            e.Graphics.DrawString("Paciente", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 50, 170, new StringFormat());
            e.Graphics.DrawString("Médico", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 195, 170, new StringFormat());
            e.Graphics.DrawString("Status da consulta", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 265, 170, new StringFormat());
            e.Graphics.DrawString("Data", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 460, 170, new StringFormat());
            e.Graphics.DrawString("Horário", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 535, 170, new StringFormat());
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 150, e.MarginBounds.Right, 150);
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 190, e.MarginBounds.Right, 190);

            //Linha por Página
            LinhasPorPagina = Convert.ToInt32(e.MarginBounds.Height / FonteNormal.GetHeight(e.Graphics) - 9);

            //Aqui são lidos os Dados
            while ((LinhaAtual < LinhasPorPagina && Leitor.Read()))
            {
                //Ontém os Valores do DataReader
                string nome = Leitor.GetString(0);
                string nomeMedico = Leitor.GetString(1);
                string descricaoStatusConsulta = Leitor.GetString(2);
                string dataConsulta = Leitor.GetString(3);
                string horaConsulta = Leitor.GetString(4);


                //Inicia a Impresão
                PosicaoDaLinha = e.MarginBounds.Top + 100 + (LinhaAtual * FonteNormal.GetHeight(e.Graphics));
                e.Graphics.DrawString(nome.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 50, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString(nomeMedico.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 195, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString(descricaoStatusConsulta.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 265, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString(dataConsulta.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 460, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString(horaConsulta.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 535, PosicaoDaLinha, new StringFormat());
                LinhaAtual += 1;
            }

            //Rodapé
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, e.MarginBounds.Bottom, e.MarginBounds.Right, e.MarginBounds.Bottom);

            e.Graphics.DrawString(System.DateTime.Now.ToString(), FonteRodape, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Bottom, new StringFormat());

            LinhaAtual += Convert.ToInt32(FonteNormal.GetHeight(e.Graphics));
            LinhaAtual += 1;
            e.Graphics.DrawString("Página :" + paginaAtual, FonteRodape, Brushes.Black, e.MarginBounds.Right - 50, e.MarginBounds.Bottom, new StringFormat());

            //Incrementa o Número da Pagina
            paginaAtual += 1;

            //Verifica se Continua Imprimindo
            if ((LinhaAtual > LinhasPorPagina))
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //Define os objetos printdocument e os Eventos Associados
            PrintDocument pd = new PrintDocument();
            //IMPORTANTE - Definimos 3 eventos para tratar a 
            //Impressão: PringPage , BeginPrint e EndPrint
            
            try
            {
                var indice = dataGridViewConsulta.CurrentRow.Index;
                idConsulta = Convert.ToInt32(dataGridViewConsulta.Rows[indice].Cells[0].Value);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex+"");
            }
            if (idConsulta >= 0)
            {
                pd.PrintPage += new PrintPageEventHandler(this.printDocument2_PrintPage);
                pd.BeginPrint += new PrintEventHandler(this.printDocument2_BeginPrint);
                pd.EndPrint += new PrintEventHandler(this.printDocument2_EndPrint);
                //Define o Objeto para visualizar a impressão
                PrintPreviewDialog objPrintPreview = new PrintPreviewDialog();
                try
                {
                    //Define o formulário como Maximizado e com Zoom
                    {
                        objPrintPreview.Document = pd;
                        objPrintPreview.WindowState = FormWindowState.Maximized;
                        objPrintPreview.PrintPreviewControl.Zoom = 1;
                        objPrintPreview.Text = "RELATÓRIO INDIVIDUAL CONSULTAS";
                        objPrintPreview.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro" + ex, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Selecione a consulta!");
            }
            
        }

        private void printDocument2_BeginPrint(object sender, PrintEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select tbPaciente.nome, nomeMedico, descricaoStatusConsulta, dataConsulta, horaConsulta from tbConsulta" +
                                                " inner join tbPaciente" +
                                                    " on tbConsulta.idPaciente = tbPaciente.idPaciente" +
                                                        " inner join tbMedico" +
                                                            " on tbConsulta.idMedico = tbMedico.idMedico" +
                                                                " inner join tbStatusConsulta" +
                                                                    " on tbConsulta.idStatusConsulta = tbStatusConsulta.idStatusConsulta"+
                                                                        " where idConsulta = "+idConsulta, Conexao.con);
            Conexao.conectar();
            Leitor = cmd.ExecuteReader();
            paginaAtual = 1;//Verificar esta linha
        }

        private void printDocument2_EndPrint(object sender, PrintEventArgs e)
        {
            //Fecha o DataReader
            Leitor.Close();
            //Fecha a Conexão
            Conexao.desconectar();
        }

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            //Variáveis das Linhas
            float LinhasPorPagina = 0;
            float PosicaoDaLinha = 0;
            int LinhaAtual = 0;

            //Variável para passar um traço
            Pen Risco = new Pen(Color.Black, 1);

            //Define as Fontes
            Font FonteNegrito = new Font("Arial", 9, FontStyle.Bold);
            Font FonteTitulo = new Font("Arial", 15, FontStyle.Bold);
            Font FonteSubTitulo = new Font("Arial", 12, FontStyle.Bold);
            Font FonteRodape = new Font("Arial", 8);
            Font FonteNormal = new Font("Arial", 9);

            //Cabeçalho
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 60, e.MarginBounds.Right, 60);
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 160, e.MarginBounds.Right, 160);

            // criando uma imagem
            /*        Image newImage = Image.FromFile("Image/logo.jpg");

                            // tamanhos e posicionamento da imagem
                            int x = 10;
                            int y = 50;
                            int width = 100;
                            int height = 100;

                            // Insere a imagem no relatório
                            e.Graphics.DrawImage(newImage, x, y, width, height);*/


            //Titulo
            e.Graphics.DrawString("RELATÓRIO INDIVIDUAL", FonteTitulo, Brushes.Black, e.MarginBounds.Left + 10, 80, new StringFormat());

            //Subtitulo
            e.Graphics.DrawString("CONSULTAS - " +
            System.DateTime.Now, FonteSubTitulo, Brushes.Black,
            e.MarginBounds.Left + 320, 120, new StringFormat());

            //Campos a Serem Impressos
            e.Graphics.DrawString("Paciente", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 50, 170, new StringFormat());
            e.Graphics.DrawString("Médico", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 150, 170, new StringFormat());
            e.Graphics.DrawString("Status da consulta", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 250, 170, new StringFormat());
            e.Graphics.DrawString("Data", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 425, 170, new StringFormat());
            e.Graphics.DrawString("Horário", FonteNegrito, Brushes.Black, e.MarginBounds.Left + 490, 170, new StringFormat());
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 150, e.MarginBounds.Right, 150);
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, 190, e.MarginBounds.Right, 190);

            //Linha por Página
            LinhasPorPagina = Convert.ToInt32(e.MarginBounds.Height / FonteNormal.GetHeight(e.Graphics) - 9);

            //Aqui são lidos os Dados
            while ((LinhaAtual < LinhasPorPagina && Leitor.Read()))
            {
                //Ontém os Valores do DataReader
                string nome = Leitor.GetString(0);
                string nomeMedico = Leitor.GetString(1);
                string descricaoStatusConsulta = Leitor.GetString(2);
                string dataConsulta = Leitor.GetString(3);
                string horaConsulta = Leitor.GetString(4);


                //Inicia a Impresão
                PosicaoDaLinha = e.MarginBounds.Top + 100 + (LinhaAtual * FonteNormal.GetHeight(e.Graphics));
                e.Graphics.DrawString(nome.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 50, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString(nomeMedico.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 200, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString(descricaoStatusConsulta.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 300, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString(dataConsulta.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 400, PosicaoDaLinha, new StringFormat());
                e.Graphics.DrawString(horaConsulta.ToString(), FonteNormal, Brushes.Black, e.MarginBounds.Left + 500, PosicaoDaLinha, new StringFormat());
                LinhaAtual += 1;
            }

            //Rodapé
            e.Graphics.DrawLine(Risco, e.MarginBounds.Left, e.MarginBounds.Bottom, e.MarginBounds.Right, e.MarginBounds.Bottom);

            e.Graphics.DrawString(System.DateTime.Now.ToString(), FonteRodape, Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Bottom, new StringFormat());

            LinhaAtual += Convert.ToInt32(FonteNormal.GetHeight(e.Graphics));
            LinhaAtual += 1;
            e.Graphics.DrawString("Página :" + paginaAtual, FonteRodape, Brushes.Black, e.MarginBounds.Right - 50, e.MarginBounds.Bottom, new StringFormat());

            //Incrementa o Número da Pagina
            paginaAtual += 1;

            //Verifica se Continua Imprimindo
            if ((LinhaAtual > LinhasPorPagina))
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }
    }
}
