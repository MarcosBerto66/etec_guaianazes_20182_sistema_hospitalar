using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaHospitalar.Model
{
    class Internacao
    {
        private string dataInternacao;
        private string dataAlta;
        private string resumoAlta;
        private int idPaciente;
        private int idTipoInternacao;
        private int idUsuario;
        private int idMedico;
        private int idInternacao;

        public int IdInternacao
        {
            get { return idInternacao; }
            set { idInternacao = value; }
        }

        public int IdMedico
        {
            get { return idMedico; }
            set { idMedico = value; }
        }

        public string DataInternacao
        {
            get { return dataInternacao; }
            set { dataInternacao = value; }
        }

        public string DataAlta
        {
            get { return dataAlta; }
            set { dataAlta = value; }
        }

        public string ResumoAlta
        {
            get { return resumoAlta; }
            set { resumoAlta = value; }
        }

        public int IdPaciente
        {
            get { return idPaciente; }
            set { idPaciente = value; }
        }

        public int IdTipoInternacao
        {
            get { return idTipoInternacao; }
            set { idTipoInternacao = value; }
        }

        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }
    }
}
