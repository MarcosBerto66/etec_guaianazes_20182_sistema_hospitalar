using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SistemaHospitalar.DAO
{
    class DAOConsulta
    {

        public Boolean cadastrar(Model.Consulta c)
        {
            SqlCommand cmd = new SqlCommand("insert into tbConsulta(dataConsulta, horaConsulta, idPaciente, idMedico, idStatusConsulta, idUsuario) " +
                "values('" + c.getDataConsulta() + "', '" + c.getHoraConsulta() + "', " + c.getIdPaciente() + ", " + c.getIdMedico() +
                "," + c.getStatusConsulta() + ", " + c.getUsuario() + ")", Conexao.con);
            Conexao.conectar();
            int qtd = cmd.ExecuteNonQuery();
            Conexao.desconectar();

            cmd = new SqlCommand("select max(idConsulta) from tbConsulta", Conexao.con);
            Conexao.conectar();
            c.setIdConsulta(Convert.ToInt32(cmd.ExecuteScalar()));
            Conexao.desconectar();

            return true;
        }

        public List<Model.Paciente> popularPaciente()
        {
            List<Model.Paciente> paciente = new List<Model.Paciente>();
            SqlCommand cmd = new SqlCommand("select idPaciente, nome from tbPaciente", Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable pac = new DataTable();
            da.Fill(pac);
            Conexao.desconectar();
            foreach (DataRow dataRow in pac.Rows)
            {
                string informacao = dataRow["nome"].ToString();
                string ids = dataRow["idPaciente"].ToString();
                int id = Convert.ToInt16(ids);
                Model.Paciente p = new Model.Paciente();
                p.setId(id);
                p.setNome(informacao);
                paciente.Add(p);
            }
            return paciente;

        }

        public DataTable consultar()
        {
            SqlCommand cmd = new SqlCommand(
                "select idConsulta, dataConsulta, horaConsulta, nome, nomeMedico, descricaoStatusConsulta from tbConsulta " +
                    "inner join tbPaciente " +
                        "on tbConsulta.idPaciente = tbPaciente.idPaciente " +
                            "inner join tbMedico " +
                                "on tbConsulta.idMedico = tbMedico.idMedico " +
                                    "inner join tbStatusConsulta " +
                                        "on tbConsulta.idStatusConsulta = tbStatusConsulta.idStatusConsulta", Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable pac = new DataTable();
            da.Fill(pac);
            Conexao.desconectar();
            return pac;
        }

        public Boolean excluir(int id)
        {
            SqlCommand cmd2 = new SqlCommand("delete tbConsulta where idConsulta = " + id, Conexao.con);
            Conexao.conectar();
            int qtd2 = cmd2.ExecuteNonQuery();
            Conexao.desconectar();
            if (qtd2 > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean editar(Model.Consulta c)
        {
                SqlCommand cmd = new SqlCommand("update tbConsulta" +
                " set dataConsulta = '" + c.getDataConsulta() + "', horaConsulta = '" + c.getHoraConsulta() + "', idPaciente = " + c.getIdPaciente() + ", idMedico = " + c.getIdMedico() + ", idStatusConsulta = " + c.getStatusConsulta() +
                    " where idConsulta = " + c.getIdConsulta(), Conexao.con);
                Conexao.conectar();
                int qtd = cmd.ExecuteNonQuery();
                Conexao.desconectar();
                if (qtd > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }           
        }

        public int[] id(int idConsulta)
        {
            int[] ids = new int[2];
            SqlCommand cmd = new SqlCommand("select idMedico, idStatusConsulta from tbConsulta where idConsulta = " + idConsulta, Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable pac = new DataTable();
            da.Fill(pac);
            Conexao.desconectar();
            foreach (DataRow dataRow in pac.Rows)
            {
                //ids[0] = Convert.ToInt32(dataRow["idPaciente"].ToString());
                ids[0] = Convert.ToInt32(dataRow["idMedico"].ToString());
                ids[1] = Convert.ToInt32(dataRow["idStatusConsulta"].ToString());
            }
            return ids;
        }

        public DataTable pesquisar(string valor)
        {
            SqlCommand cmd = new SqlCommand("select dataConsulta, horaConsulta, nome, nomeMedico, descricaoStatusConsulta from tbConsulta" +
                " inner join tbMedico" +
                    " on tbConsulta.idMedico = tbMedico.idMedico" +
                        " inner join tbPaciente" +
                            " on tbConsulta.idPaciente = tbPaciente.idPaciente" +
                                " inner join tbStatusConsulta" +
                                    " on tbConsulta.idStatusConsulta = tbStatusConsulta.idStatusConsulta" +
                                        " where nomeMedico like '" + valor + "%' or nome like '" + valor + "%'"
                , Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable pac = new DataTable();
            da.Fill(pac);
            Conexao.desconectar();
            return pac;
        }

        public int pesquisarId(int c)
        {
            SqlCommand cmd = new SqlCommand("select idPaciente from tbConsulta where idConsulta = " + c, Conexao.con);
            Conexao.conectar();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable pac = new DataTable();
            da.Fill(pac);
            Conexao.desconectar();
            int id = -1;
            foreach (DataRow dataRow in pac.Rows)
            {
                id = Convert.ToInt32(dataRow["idPaciente"].ToString());
            }
            return id;
        }
    }
        
}
    
