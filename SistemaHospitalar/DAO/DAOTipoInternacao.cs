using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace SistemaHospitalar.DAO
{
    using Model;

    class DAOTipoInternacao
    {
        public List<Model.tipoInternacao> popularCB() {
            List<Model.tipoInternacao> tipos = new List<Model.tipoInternacao>();
            SqlCommand cmd = new SqlCommand("select idTipoInternacao,descricao from tbTipoInternacao",Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable pac = new DataTable();
            da.Fill(pac);
            Conexao.desconectar();
            foreach (DataRow dataRow in pac.Rows)
            {
                Model.tipoInternacao t = new Model.tipoInternacao();
                string informação = dataRow["descricao"].ToString();
                t.Descricao = informação;
                string id = dataRow["idTipoInternacao"].ToString();
                t.IdTipoInternacao = Convert.ToInt32(id);
                tipos.Add(t);
            }
            return tipos;
        }

        public string editar(tipoInternacao t) {
            SqlCommand verificacao = new SqlCommand("select descricao from tbTipoInternacao where descricao like '" + t.Descricao + "' and idTipoInternacao <> "+t.IdTipoInternacao+"", Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(verificacao);
            DataTable pac = new DataTable();
            da.Fill(pac);
            Conexao.desconectar();
            foreach (DataRow dataRow in pac.Rows)
            {
                return "Descrição já existente!";
            }

            SqlCommand cmd = new SqlCommand("update tbTipoInternacao set descricao = '"+t.Descricao+
            "' where idTipoInternacao = "+t.IdTipoInternacao,Conexao.con);
            Conexao.conectar();
            int qtd = cmd.ExecuteNonQuery();
            Conexao.desconectar();
            if (qtd > 0) 
            {
                return "Atualizado com sucesso!";
            }else{
                return "Erro ao atualizar!";
            }
        }

        public string cadastrar(tipoInternacao t)
        {
            SqlCommand verificacao = new SqlCommand("select descricao from tbTipoInternacao where descricao like '"+t.Descricao+"'",Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(verificacao);
            DataTable pac = new DataTable();
            da.Fill(pac);
            Conexao.desconectar();
            foreach (DataRow dataRow in pac.Rows)
            {
                return "Descrição já existente!";
            }

            SqlCommand cmd = new SqlCommand("insert into tbTipoInternacao  (descricao) " +
                "values ('" + t.Descricao + "')", Conexao.con);
            Conexao.conectar();
            int qtd = cmd.ExecuteNonQuery();
            Conexao.desconectar();
            if (qtd > 0)
                return ("Cadastro realizado com sucesso!");
            else
                return ("Erro na operação de cadastro!");
        }

                
        public DataTable preencherDataGrid()
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT idTipoInternacao, descricao from tbTipoInternacao"
                , Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable t = new DataTable();
            da.Fill(t);
            Conexao.desconectar();
            return t;
        }

        public DataTable pesquisar(string valor)
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT idTipoInternacao, descricao from tbTipoInternacao where descricao like '"+valor+"%'"
                , Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable t = new DataTable();
            da.Fill(t);
            Conexao.desconectar();
            return t;
        }

        public string excluir(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("delete from tbTipoInternacao where idTipoInternacao = " + id, Conexao.con);
                Conexao.conectar();
                int qtd = cmd.ExecuteNonQuery();
                Conexao.desconectar();

                if (qtd > 0)
                {
                    return "Excluído com sucesso!";
                }
                else
                {
                    return "Erro ao excluir!";
                }
            }
            catch {
                Conexao.desconectar();
                return "Não é possível excluir um tipo que pertence a alguma internação!";
            }
        }
    }
}
