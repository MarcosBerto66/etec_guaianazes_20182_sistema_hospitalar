using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaHospitalar.Model
{
    class Usuario
    {
        int id;
        string login;
        string senha;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }
    }
}
