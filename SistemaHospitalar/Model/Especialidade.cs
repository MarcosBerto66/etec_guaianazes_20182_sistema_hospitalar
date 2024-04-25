using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaHospitalar.Model
{
    class Especialidade
    {
        private int codespcialidade;
        private string descricaoespcialidade;

        public int Codespcialidade
        {
            get
            {
                return codespcialidade;
            }

            set
            {
                codespcialidade = value;
            }
        }

        public string Descricaoespcialidade
        {
            get
            {
                return descricaoespcialidade;
            }

            set
            {
                descricaoespcialidade = value;
            }
        }

    }
}
