using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaHospitalar.Model
{
    class tipoInternacao
    {
        private int idTipoInternacao;
        private string descricao;

        public int IdTipoInternacao
        {
            get { return idTipoInternacao; }
            set { idTipoInternacao = value; }
        }

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
    }
}
