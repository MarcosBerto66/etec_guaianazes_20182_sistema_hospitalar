using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SistemaHospitalar.DAO
{
    using Model;
    class DAOUsuario
    {

        public String deletarUsuario(string l)
        {
            SqlCommand cmd = new SqlCommand("delete from tbUsuario where loginUsuario like '"+l+"'",Conexao.con);
            Conexao.conectar();
            int qtd = cmd.ExecuteNonQuery();
            Conexao.desconectar();
            if (qtd > 0) {
                return "Excluído com sucesso!";
            }else{
                return "Erro ao excluir!";
            }
        }

        public string editar(Usuario u)
        {

            SqlCommand verificacao = new SqlCommand("select loginUsuario from tbUsuario where loginUsuario like '" + u.Login + "' and idUsuario <> "+u.Id, Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(verificacao);
            DataTable pac = new DataTable();
            da.Fill(pac);
            Conexao.desconectar();
            int cont = 0;
            foreach (DataRow dataRow in pac.Rows)
            {
                if (cont >=0) {
                    return "Usuário já existente!";
                }
            }

            SqlCommand cmd = new SqlCommand("update tbUsuario set loginUsuario = '"+u.Login+
            "' where idUsuario like '"+u.Id+"'",Conexao.con);
            Conexao.conectar();
            int qtd = cmd.ExecuteNonQuery();
            Conexao.desconectar();

            if (qtd > 0)
            {
                return "Alterações realizadas com sucesso!";
            }
            else
            {
                return "Erro ao atualizar!";
            }
        }

        public String cadastrar(Usuario u)
        {
            int qtd = 0;
            List<Model.Usuario> users = usuarios();
            string informação="";
            u.Senha = "123456";

            SqlCommand verificacao = new SqlCommand("select loginUsuario from tbUsuario where loginUsuario like '"+u.Login+"'",Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(verificacao);
            DataTable pac = new DataTable();
            da.Fill(pac);
            Conexao.desconectar();
            foreach (DataRow dataRow in pac.Rows)
            {
                informação = dataRow["loginUsuario"].ToString();
            }

            if (informação.Equals(""))
            {

                SqlCommand cmd = new SqlCommand("INSERT INTO tbUsuario (loginUsuario,senhaUsuario)"

                    + " values ('" + u.Login + "' , '" + u.Senha + "')", Conexao.con);

                Conexao.conectar();
                qtd = cmd.ExecuteNonQuery();
                Conexao.desconectar();

                if (qtd > 0)
                {
                    return ("Cadastrado com sucesso! Senha padrão: 123456");
                }
                else
                {
                    return ("Erro ao cadastrar!");
                }
            }
            else {
                return "Usuário já existente!";
            }

        }

        public DataTable consultar()
        {
            SqlCommand cmd = new SqlCommand("select idUsuario,loginUsuario from tbUsuario", Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable pac = new DataTable();
            da.Fill(pac);
            Conexao.desconectar();
            return pac;
        }

        public DataTable pesquisar(string valor)
        {
            SqlCommand cmd = new SqlCommand("select idUsuario,loginUsuario from tbUsuario where loginUsuario like '"+valor+"%'", Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable pac = new DataTable();
            da.Fill(pac);
            Conexao.desconectar();
            return pac;
        }

        public List<Model.Usuario> usuarios()
        {
            List<Model.Usuario> logs = new List<Model.Usuario>();
            SqlCommand cmd = new SqlCommand("select idUsuario,loginUsuario from tbUsuario", Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable pac = new DataTable();
            da.Fill(pac);
            Conexao.desconectar();
            foreach (DataRow dataRow in pac.Rows)
            {
                Model.Usuario u = new Model.Usuario();
                string informação = dataRow["loginUsuario"].ToString();
                u.Login = informação;
                string id = dataRow["idUsuario"].ToString();
                u.Id = Convert.ToInt32(id);
                logs.Add(u);
            }
            return logs;
        }

        public bool fazerLogin(Usuario u)
        {
            try
            {
                string log="";
                SqlCommand cmd = new SqlCommand("select loginUsuario from tbUsuario where loginUsuario like '" + u.Login + "' and senhaUsuario like '" + u.Senha+"'", Conexao.con);
                Conexao.conectar();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable pac = new DataTable();
                da.Fill(pac);
                Conexao.desconectar();
                foreach (DataRow dataRow in pac.Rows)
                {
                    log = dataRow["loginUsuario"].ToString();
                }
                if (!log.Equals(""))
                {
                    return true;
                }
                else {
                    return false;
                }
            }
            catch {
                return false;
            }
        }
    }
}
