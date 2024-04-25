using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaHospitalar.Model
{
    class Consulta
    {
        private int idConsulta;
        private string dataConsulta;
        private string horaConsulta;
        private int idPaciente;
        private int idMedico;
        private int idStatusConsulta;
        private int idUsuario;

        public void setIdConsulta(int idConsulta)
        {
            this.idConsulta = idConsulta;
        }

        public int getIdConsulta()
        {
            return idConsulta;
        }

        public void setDataConsulta(string dataConsulta)
        {
            this.dataConsulta = dataConsulta;
        }

        public string getDataConsulta()
        {
            return dataConsulta;
        }

        public void setHoraConsulta(string horaConsulta)
        {
            this.horaConsulta = horaConsulta;
        }

        public string getHoraConsulta()
        {
            return horaConsulta;
        }

        public void setIdPaciente(int idPaciente)
        {
            this.idPaciente = idPaciente;
        }

        public int getIdPaciente()
        {
            return idPaciente;
        }

        public void setIdMedico(int idMedico)
        {
            this.idMedico = idMedico;
        }

        public int getIdMedico()
        {
            return idMedico;
        }

        public void setStatusConsulta(int idStatusConsulta)
        {
            this.idStatusConsulta = idStatusConsulta;
        }

        public int getStatusConsulta()
        {
            return idStatusConsulta;
        }

        public void setUsuario(int idUsuario)
        {
            this.idUsuario = idUsuario;
        }

        public int getUsuario()
        {
            return idUsuario;
        }

    }
}
