using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SistemaHospitalar
{
    public static class Conexao
    {
        public static SqlConnection con = new SqlConnection(
           @"Server=[ExampleName]; Database=bdSistemaHospitalar; 
            Integrated Security=SSPI;");

        public static String conectar()
        {
            try
            {
                con.Open();
                return ("Conexão realizada com sucesso.");
            }
            catch (SqlException e)
            {
                return (e.ToString());
            }
        }

        public static String desconectar()
        {
            try
            {
                con.Close();
                return ("Conexão encerrada.");
            }
            catch (SqlException e)
            {
                return (e.ToString());
            }
        }
    }
}

