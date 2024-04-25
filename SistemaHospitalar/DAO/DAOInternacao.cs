using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SistemaHospitalar.DAO
{
    class DAOInternacao
    {
           public DataTable pesquisar(string valor)
        {
            SqlCommand cmd = new SqlCommand(
                "	SELECT idInternacao, dataEntradainternacao, dataAltaInternacao, resumoAlta, tbPaciente.nome, "+
		"tbTipoInternacao.descricao, nomeMedico, loginUsuario  from tbInternacao "+
			"inner join tbPaciente "+
				"on tbInternacao.idPaciente = tbPaciente.idPaciente "+
					"inner join tbTipoInternacao "+
						"on tbInternacao.idTipoInternacao= tbTipoInternacao.idTipoInternacao "+ 
							"inner join tbMedico "+
								"on tbInternacao.idMedico = tbMedico.idMedico "+
									"inner join tbUsuario "+
										"on tbInternacao.idUsuario = tbUsuario.idUsuario where tbPaciente.nome like '%"+valor+"%'", Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable t = new DataTable();
            da.Fill(t);
            Conexao.desconectar();
            return t;
        }

        public string cadastrar(Model.Internacao i) {
            SqlCommand cmd = new SqlCommand("insert into tbInternacao  (dataEntradaInternacao, dataAltaInternacao, resumoAlta, idPaciente, idTipoInternacao,idMedico,idUsuario) " +
    "values ('" + i.DataInternacao + "', '"+i.DataAlta+"', '"+i.ResumoAlta+"', "+i.IdPaciente+","+i.IdTipoInternacao+","+i.IdMedico+","+i.IdUsuario+")", Conexao.con);
            Conexao.conectar();
            int qtd = cmd.ExecuteNonQuery();
            Conexao.desconectar();
            if (qtd > 0)
                return ("Cadastro realizado com sucesso!");
            else
                return ("Erro na operação de cadastro!");
        }

        public string editar(Model.Internacao i)
        {
            SqlCommand cmd = new SqlCommand("update tbInternacao set dataEntradaInternacao = '" + i.DataInternacao +
            "', dataAltaInternacao = '"+i.DataAlta+"', resumoAlta = '"+i.ResumoAlta+"', idPaciente = "+i.IdPaciente+", idTipoInternacao = "+i.IdTipoInternacao+", idMedico = "+i.IdMedico+", idUsuario="+i.IdUsuario+" where idInternacao = " + i.IdInternacao, Conexao.con);
            Conexao.conectar();
            int qtd = cmd.ExecuteNonQuery();
            Conexao.desconectar();
            if (qtd > 0)
            {
                return "Atualizado com sucesso!";
            }
            else
            {
                return "Erro ao atualizar!";
            }
        }

        public string excluir(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("delete from tbInternacao where idInternacao = " + id, Conexao.con);
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
            catch
            {
                Conexao.desconectar();
                return "Erro ao excluir!";
            }
        }

        public DataTable preencherDataGrid()
        {
            SqlCommand cmd = new SqlCommand(
                "	SELECT idInternacao, dataEntradainternacao, dataAltaInternacao, resumoAlta, tbPaciente.nome, "+
		"tbTipoInternacao.descricao, nomeMedico, loginUsuario  from tbInternacao "+
			"inner join tbPaciente "+
				"on tbInternacao.idPaciente = tbPaciente.idPaciente "+
					"inner join tbTipoInternacao "+
						"on tbInternacao.idTipoInternacao= tbTipoInternacao.idTipoInternacao "+ 
							"inner join tbMedico "+
								"on tbInternacao.idMedico = tbMedico.idMedico "+
									"inner join tbUsuario "+
										"on tbInternacao.idUsuario = tbUsuario.idUsuario", Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable t = new DataTable();
            da.Fill(t);
            Conexao.desconectar();
            return t;
        }

        public Model.Paciente pegaPaciente(int idInternacao)
        {
            Model.Paciente p = new Model.Paciente();
            SqlCommand cmd = new SqlCommand(
                "	SELECT tbPaciente.idPaciente,nome from tbInternacao inner join tbPaciente on tbInternacao.idPaciente = tbPaciente.idPaciente where idInternacao = "+idInternacao+"", Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable t = new DataTable();
            da.Fill(t);
            foreach (DataRow dataRow in t.Rows)
            {
                string idP = dataRow["idPaciente"].ToString();
                p.setId(Convert.ToInt32(idP));
                string nome = dataRow["nome"].ToString();
                p.setNome(nome);
            }
            Conexao.desconectar();
            return p;
        }
    }
}
