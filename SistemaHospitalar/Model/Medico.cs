using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaHospitalar.Model
{
    class Medico
    {
        private int id;
        private string nome;
        private string crm;
        private int especialidade;

        public void setId(int id)
        {
            this.id = id;
        }
        public int getId()
        {
            return id;
        }

        public void setNome(string nome)
        {
            this.nome = nome;
        }
        public string getNome()
        {
            return nome;
        }

        public void setCrm(string crm)
        {
            this.crm = crm;
        }
        public string getCrm()
        {
            return crm;
        }

        public void setEspecialidade(int especialidade)
        {
            this.especialidade = especialidade;
        }
        public int getEspecialidade()
        {
            return especialidade;
        }
    }
}
