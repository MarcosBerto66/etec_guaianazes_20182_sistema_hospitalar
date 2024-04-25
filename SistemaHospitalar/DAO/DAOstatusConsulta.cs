using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SistemaHospitalar.DAO
{
    class DAOstatusConsulta
    {
          public String insert(Model.StatusConsulta status)
        {
            SqlCommand verificacao = new SqlCommand("select descricaoStatusConsulta from tbStatusConsulta where descricaoStatusConsulta like '" + status.DescricaoStatusconsulta + "'", Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(verificacao);
            DataTable pac = new DataTable();
            da.Fill(pac);
            Conexao.desconectar();
            foreach (DataRow dataRow in pac.Rows)
            {
                return "Descrição já existente!";
            }


            SqlCommand sql = new SqlCommand("INSERT INTO tbStatusConsulta (descricaoStatusConsulta) VALUES ('"
                
                + status.DescricaoStatusconsulta +"')", Conexao.con);

            Conexao.conectar();

            int qtd = sql.ExecuteNonQuery();
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

        public DataTable select()
        {
            SqlCommand sql = new SqlCommand("SELECT idStatusConsulta, descricaoStatusConsulta from tbStatusConsulta", Conexao.con);

            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Conexao.desconectar();

            return dt;
        }

        public DataTable query(string valor)
        {
            SqlCommand sql = new SqlCommand("SELECT idStatusConsulta, descricaoStatusConsulta from tbStatusConsulta where descricaoStatusConsulta like '"+valor+"%'", Conexao.con);

            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(sql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Conexao.desconectar();

            return dt;
        }

        public String update(Model.StatusConsulta status)
        {
            SqlCommand sql = new SqlCommand("UPDATE tbStatusConsulta set descricaoStatusConsulta = '" + status.DescricaoStatusconsulta + "' where idStatusConsulta = "+status.Codstatusconsulta, Conexao.con);
            Conexao.conectar();

            int qtd = sql.ExecuteNonQuery();

            Conexao.desconectar();

            if(qtd > 0){
                return "Status da consulta alterado com sucesso!";
            }
            else{
                return "Ocorreu um erro ao fazer a edição!";
            }
        }

        public String remove(int id)
        {
            try
            {
                SqlCommand sql = new SqlCommand("DELETE from tbStatusConsulta where idStatusConsulta = " + id, Conexao.con);

                Conexao.conectar();

                int qtd = sql.ExecuteNonQuery();

                Conexao.desconectar();

                if (qtd > 0)
                {
                    return "Status removido com sucesso!";
                }
                else
                {
                    return "Ocorreu um erro ao fazer a remoção!";
                }
            }
            catch {
                Conexao.desconectar();
                return "Não é possível excluir um status que pertence a alguma consulta!";
            }
        }

        public List<Model.StatusConsulta> statusConsulta()
        {
            List<Model.StatusConsulta> statusConsulta = new List<Model.StatusConsulta>();
            SqlCommand cmd = new SqlCommand("select idStatusConsulta, descricaoStatusConsulta from tbStatusConsulta", Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable pac = new DataTable();
            da.Fill(pac);
            Conexao.desconectar();
            foreach (DataRow dataRow in pac.Rows)
            {
                string informacao = dataRow["descricaoStatusConsulta"].ToString();
                string ids = dataRow["idStatusConsulta"].ToString();
                int id = Convert.ToInt16(ids);
                Model.StatusConsulta s = new Model.StatusConsulta();
                s.setCodStatusConsulta(id);
                s.setDescricaoStatusConsulta(informacao);
                statusConsulta.Add(s);
            }
            return statusConsulta;
        }
    }
}
