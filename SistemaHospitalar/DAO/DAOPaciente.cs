using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace SistemaHospitalar.DAO
{
    class DAOPaciente
    {
        int id = 0;

        public List<Model.Paciente> popularCB()
        {
            List<Model.Paciente> pacientes = new List<Model.Paciente>();
            SqlCommand cmd = new SqlCommand("select idPaciente,nome from tbPaciente", Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable pac = new DataTable();
            da.Fill(pac);
            Conexao.desconectar();
            foreach (DataRow dataRow in pac.Rows)
            {
                Model.Paciente p = new Model.Paciente();
                string informação = dataRow["nome"].ToString();
                p.setNome(informação);
                string id = dataRow["idPaciente"].ToString();
                p.setId(Convert.ToInt32(id));
                pacientes.Add(p);
            }
            return pacientes;
        }

        public string excluir(int id) {
            SqlCommand cmd = new SqlCommand("delete from tbTelefonePaciente where idPaciente = " + id, Conexao.con);
            Conexao.conectar();
            int qtd = cmd.ExecuteNonQuery();
            Conexao.desconectar();

            SqlCommand cmd2 = new SqlCommand("delete from tbPaciente where idPaciente = " + id, Conexao.con);
            Conexao.conectar();
            int qtd2 = cmd2.ExecuteNonQuery();
            Conexao.desconectar();


            if (qtd2 > 0)
            {
                return "Excluído com sucesso!";
            }
            else {
                return "Erro ao excluir!";
            }
        }
        public string editar(Model.Paciente p, List<string> tels) {
            SqlCommand verificacao = new SqlCommand("select rg,cpf from tbPaciente where idPaciente <> "+p.getId()+" and rg like '" + p.getRg() + "' or cpf like '" + p.getCpf() + "'", Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(verificacao);
            DataTable pac = new DataTable();
            da.Fill(pac);
            Conexao.desconectar();
            int cont = 0;
            foreach (DataRow dataRow in pac.Rows)
            {
                if (cont > 0)
                {
                    return "Impossível editar, paciente já existente!";
                }
                cont++;
            }

            SqlCommand cmd = new SqlCommand("delete from tbTelefonePaciente where idPaciente = " + p.getId(), Conexao.con);
            Conexao.conectar();
            int qtd = cmd.ExecuteNonQuery();
            Conexao.desconectar();

            SqlCommand cmd2 = new SqlCommand("update tbPaciente set nome = '"+p.getNome()+"', nasc = '"+p.getNascimento()
                +"', logra = '"+p.getLogradouro()+"', cpf = '"+p.getCpf()+"', bairro = '"+p.getBairro()+"', cep = '"+p.getCep()+
            "', n = '"+p.getN()+"', cid = '"+p.getCidade()+"', est = '"+p.getEstado()+"' where idPaciente = "+p.getId(),Conexao.con);
            Conexao.conectar();
            int qtd2 = cmd2.ExecuteNonQuery();
            Conexao.desconectar();

            foreach (string i in tels)
            {
                SqlCommand cmd3 = new SqlCommand("insert into tbTelefonePaciente (descricao,idPaciente)" +
                " values ('" + i + "'," + p.getId() + ")", Conexao.con);
                Conexao.conectar();
                int qtd3 = cmd3.ExecuteNonQuery();
                Conexao.desconectar();
            }

            if (qtd2 > 0)
            {
                return ("Alteração realizada com sucesso!");
            }
            else
            {
                return ("Erro na operação de edição!");
            }
        }

        public string cadastrar(Model.Paciente p, List<string> tels) {
            try
            {
                SqlCommand verificacao = new SqlCommand("select rg,cpf from tbPaciente where rg like '"+p.getRg()+"' or cpf like '"+p.getCpf()+"'",Conexao.con);
                Conexao.conectar();
                SqlDataAdapter da = new SqlDataAdapter(verificacao);
                DataTable pac = new DataTable();
                da.Fill(pac);
                Conexao.desconectar();
                foreach (DataRow dataRow in pac.Rows)
                {
                    return "Impossível cadastrar, paciente já existente!";
                }


                SqlCommand cmd = new SqlCommand("insert into tbPaciente  (nome,nasc,rg,logra,cpf,bairro,cep,n,cid,est) " +
                    "values ('" + p.getNome() + "','" + p.getNascimento() + "','" + p.getRg() + "','" + p.getLogradouro() + "','" +
                    p.getCpf() + "','" + p.getBairro() + "','" + p.getCep() + "','" + p.getN() + "','" + p.getCidade() + "','" + p.getEstado() + "')", Conexao.con);
                Conexao.conectar();
                int qtd = cmd.ExecuteNonQuery();
                Conexao.desconectar();

                SqlCommand sqlCommand = new SqlCommand("Select MAX(idPaciente) from tbPaciente", Conexao.con);
                Conexao.conectar();
                id = Convert.ToInt32(sqlCommand.ExecuteScalar());
                Conexao.desconectar();

                foreach (string i in tels)
                {
                    SqlCommand cm2 = new SqlCommand("insert into tbTelefonePaciente (descricao,idPaciente)" +
                    " values ('" + i + "'," + id + ")", Conexao.con);
                    Conexao.conectar();
                    int qtd2 = cm2.ExecuteNonQuery();
                    Conexao.desconectar();
                }

                if (qtd > 0)
                {
                    return ("Cadastro realizado com sucesso! Código: "+id);
                }
                else
                {
                    return ("Erro na operação de cadastro!");
                }
                
            }
            catch (Exception e) {
                return e+"";
            }
        }

        public DataTable consultar() {
            SqlCommand cmd = new SqlCommand(
                "SELECT idPaciente, nome, cpf, nasc, rg, logra, cep,"+
                "n,bairro,cid,est from tbPaciente"
                , Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable pac = new DataTable();
            da.Fill(pac);
            Conexao.desconectar();
            return pac;
        }

        public DataTable pesquisar(string valor)
        {
            SqlCommand cmd = new SqlCommand(
                "SELECT idPaciente, nome, cpf, nasc, rg, logra, cep," +
                "n,bairro,cid,est from tbPaciente where nome like '"+valor+"%'"
                , Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable pac = new DataTable();
            da.Fill(pac);
            Conexao.desconectar();
            return pac;
        }

        public List<string> consultar(int id)
        {
            List<string> n = new List<string>();
            SqlCommand cmd = new SqlCommand(
                "SELECT descricao from tbTelefonePaciente where idPaciente = "+id
                , Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable pac = new DataTable();
            da.Fill(pac);
            Conexao.desconectar();
            foreach (DataRow dataRow in pac.Rows)
            {
                string informação = dataRow["descricao"].ToString();
                n.Add(informação);
            }
            return n;
        }
    }
}
