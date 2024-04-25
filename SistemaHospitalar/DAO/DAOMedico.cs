using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SistemaHospitalar.DAO
{
    class DAOMedico
    {
        public string excluir(int id) {
            SqlCommand cmd = new SqlCommand("delete from tbMedico where idMedico = "+id,Conexao.con);
            Conexao.conectar();
            int qtd = cmd.ExecuteNonQuery();
            Conexao.desconectar();
            if (qtd > 0)
            {
                return "Excluído com sucesso!";
            }
            else {
                return "Erro ao excluir!";
            }
        }

        public string editar(Model.Medico m) {
            SqlCommand verifica = new SqlCommand("select crmMedico from tbMedico where crmMedico like '" + m.getCrm() + "' and idMedico <> "+m.getId(), Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(verifica);
            DataTable pac = new DataTable();
            da.Fill(pac);
            Conexao.desconectar();
            int cont=0;
            foreach (DataRow dataRow in pac.Rows)
            {
                if(cont>=0){
                    return "Médico já existente!";
                }
                cont++;
            }

            SqlCommand cmd = new SqlCommand("update tbMedico set nomeMedico = '"+m.getNome()+"', crmMedico = '"+m.getCrm()+"', idEspecialidadeMedico = "+m.getEspecialidade()+" where idMedico = "+m.getId(),Conexao.con);
            Conexao.conectar();
            int qtd = cmd.ExecuteNonQuery();
            Conexao.desconectar();
            if (qtd > 0)
            {
                return "Médico atualizado com sucesso!";
            }
            else
            {
                return "Ocorreu um erro ao tentar atualizar o médico.";
            }
        }

        public string cadastrar(Model.Medico medico)
        {
            SqlCommand verifica = new SqlCommand("select crmMedico from tbMedico where crmMedico like '"+medico.getCrm()+"'",Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(verifica);
            DataTable pac = new DataTable();
            da.Fill(pac);
            Conexao.desconectar();
            foreach (DataRow dataRow in pac.Rows)
            {
                return "Médico já existente!";
            }

            try
            {
                SqlCommand cmd = new SqlCommand("insert into tbMedico(nomeMedico, crmMedico, idEspecialidadeMedico) values ('"+medico.getNome()+"','"+medico.getCrm()+"', "+medico.getEspecialidade()+")", Conexao.con);
                Conexao.conectar();
                int qtd = cmd.ExecuteNonQuery();
                Conexao.desconectar();
                if (qtd > 0)
                {
                    return "Médico cadastrado com sucesso!";
                }
                else
                {
                    return "Ocorreu um erro ao tentar cadastrar o médico.";
                }

            }
            catch (Exception e)
            {
                return e + "";
            }
        }

        public DataTable consultar() {
            SqlCommand cmd = new SqlCommand("select idMedico, nomeMedico, crmMedico, descricao from tbMedico "+
                "inner join tbEspecialidade on tbMedico.idEspecialidadeMedico = tbEspecialidade.idEspecialidade",Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable pac = new DataTable();
            da.Fill(pac);
            Conexao.desconectar();
            return pac;
        }

        public List<Model.Medico> medicos()
        {
            List<Model.Medico> nomes = new List<Model.Medico>();
            SqlCommand cmd = new SqlCommand("select idMedico,nomeMedico from tbMedico", Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable pac = new DataTable();
            da.Fill(pac);
            Conexao.desconectar();
            foreach (DataRow dataRow in pac.Rows)
            {
                string informação = dataRow["nomeMedico"].ToString();
                string ids = dataRow["idMedico"].ToString();
                int id = Convert.ToInt16(ids);
                Model.Medico m = new Model.Medico();
                m.setId(id);
                m.setNome(informação);
                nomes.Add(m);
            }
            return nomes;
        }

        public DataTable pesquisar(string valor)
        {
            SqlCommand cmd = new SqlCommand("select idMedico, nomeMedico, crmMedico, descricao from tbMedico " +
                "inner join tbEspecialidade on tbMedico.idEspecialidadeMedico = tbEspecialidade.idEspecialidade"+
             " where nomeMedico like '"+valor+"%'", Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable pac = new DataTable();
            da.Fill(pac);
            Conexao.desconectar();
            return pac;
        }

        public List<Model.Especialidade> popularEspecialidade()
        {
            List<Model.Especialidade> especialidade  = new List<Model.Especialidade>();
            SqlCommand cmd = new SqlCommand("SELECT idEspecialidade, descricao from tbEspecialidade", Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable pac = new DataTable();
            da.Fill(pac);
            Conexao.desconectar();
            foreach (DataRow dataRow in pac.Rows)
            {
                string informação = dataRow["descricao"].ToString();
                string ids = dataRow["idEspecialidade"].ToString();
                int id = Convert.ToInt16(ids);
                Model.Especialidade e = new Model.Especialidade();
                e.Codespcialidade = id;
                e.Descricaoespcialidade = informação;
                especialidade.Add(e);
            }
            return especialidade;

        }
    }
}
