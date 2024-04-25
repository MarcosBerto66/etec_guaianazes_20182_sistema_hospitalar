using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SistemaHospitalar.DAO
{
    using Model;

    class DaoEspecialidade
    {
        public string excluir(int id) {
            try
            {
                SqlCommand cmd = new SqlCommand("delete from tbEspecialidade where idEspecialidade = " + id, Conexao.con);
                Conexao.conectar();
                int qtd = cmd.ExecuteNonQuery();
                Conexao.desconectar();
                if (qtd > 0)
                {
                    return "Excluído com sucesso";
                }
                else
                {
                    return "Erro ao excluir";
                }
            }
            catch {
                Conexao.desconectar();
                return "Não é possível excluir uma especialidade que esteja associada a algum médico!";
            }
        }


        public string editar(Especialidade e) {
            SqlCommand verifica = new SqlCommand("select descricao from tbEspecialidade"
            + " where descricao = '" + e.Descricaoespcialidade + "' and idEspecialidade <> "+e.Codespcialidade+"", Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(verifica);
            DataTable pac = new DataTable();
            da.Fill(pac);
            Conexao.desconectar();
            foreach (DataRow dataRow in pac.Rows)
            {
                return "Especialidade já existente!";
            }

            SqlCommand cmd = new SqlCommand("update tbEspecialidade set descricao = '"+e.Descricaoespcialidade+"'"+
                " where idEspecialidade = "+e.Codespcialidade,Conexao.con);
            Conexao.conectar();
            int qtd = cmd.ExecuteNonQuery();
            Conexao.desconectar();
            if (qtd > 0)
            {
                return ("Atualizado com sucesso!");
            }
            else
            {
                return ("Erro ao atualizar!");
            }
        }


        public String cadastrar(Especialidade espec)
        {
            SqlCommand verifica = new SqlCommand("select descricao from tbEspecialidade"
            +" where descricao = '"+espec.Descricaoespcialidade+"'",Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(verifica);
            DataTable pac = new DataTable();
            da.Fill(pac);
            Conexao.desconectar();
            foreach (DataRow dataRow in pac.Rows)
            {
                return "Especialidade já existente!";
            }

            SqlCommand cmd = new SqlCommand("INSERT INTO tbEspecialidade (descricao)"

                + " values ('" + espec.Descricaoespcialidade + "')", Conexao.con);

            Conexao.conectar();
            int qtd = cmd.ExecuteNonQuery();
            Conexao.desconectar();
            if (qtd > 0)
            {
                return ("Cadastrado com sucesso!");
            }
            else
            {
                return ("Erro ao cadastrar!");
            }
        }

        public DataTable preenche()
        {
            SqlCommand cmd = new SqlCommand("SELECT idEspecialidade, descricao from tbEspecialidade", Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable especialidade = new DataTable();
            da.Fill(especialidade);
            Conexao.desconectar();
            return especialidade;
        }

        public DataTable pesquisar(string valor)
        {
            SqlCommand cmd = new SqlCommand("SELECT idEspecialidade, descricao from tbEspecialidade where descricao like '"+valor+"%'", Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable especialidade = new DataTable();
            da.Fill(especialidade);
            Conexao.desconectar();
            return especialidade;
        }

    }
}