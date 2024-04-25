using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaHospitalar.Model
{
    class StatusConsulta
    {
        private int codStatusConsulta;
        private String descricaoStatusConsulta;

        public void setCodStatusConsulta(int id)
        {
            this.codStatusConsulta = id;
        }

        public void setDescricaoStatusConsulta(String descricao)
        {
            this.descricaoStatusConsulta = descricao;
        }

        public int Codstatusconsulta
        {
            get
            {
                return codStatusConsulta;
            }
            set
            {
                codStatusConsulta = value;
            }
        }

        public String DescricaoStatusconsulta
        {
            get
            {
                return descricaoStatusConsulta;
            }
            set
            {
                descricaoStatusConsulta = value;
            }
        }
    }
}
