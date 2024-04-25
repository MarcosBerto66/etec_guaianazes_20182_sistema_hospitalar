using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaHospitalar.Model
{
    class Paciente
    {
        int id;
        string nome;
        string cpf;
        string nascimento;
        string rg;
        string logradouro;
        string cep;
        string n;
        string bairro;
        string cidade;
        string estado;
        List<string> telefones = new List<string>();
        public static Model.Paciente pacienteSelecionado = new Model.Paciente();

        public void setNome(string nome)
        {
            this.nome = nome;
        }

        public string getNome()
        {
            return nome;
        }

        public void setCpf(string cpf)
        {
            this.cpf = cpf;
        }

        public string getCpf()
        {
            return cpf;
        }

        public void setNascimento(string nascimento)
        {
            this.nascimento = nascimento;
        }

        public string getNascimento()
        {
            return nascimento;
        }

        public void setRg(string rg)
        {
            this.rg = rg;
        }

        public string getRg()
        {
            return rg;
        }

        public void setLogradouro(string logradouro)
        {
            this.logradouro = logradouro;
        }

        public string getLogradouro()
        {
            return logradouro;
        }

        public void setCep(string cep)
        {
            this.cep = cep;
        }

        public string getCep()
        {
            return cep;
        }

        public void setN(string n)
        {
            this.n = n;
        }

        public string getN()
        {
            return n;
        }

        public void setBairro(string bairro)
        {
            this.bairro = bairro;
        }

        public string getBairro()
        {
            return bairro;
        }

        public void setCidade(string cidade)
        {
            this.cidade = cidade;
        }

        public string getCidade()
        {
            return cidade;
        }

        public void setEstado(string estado)
        {
            this.estado = estado;
        }

        public string getEstado()
        {
            return estado;
        }

        public void setTelefones(List<string> tels)
        {
            foreach (string i in tels)
            {
                telefones.Add(i);
            }
        }

        public List<String> getTelefones()
        {
            return telefones;
        }


        public void setId(int id)
        {
            this.id = id;
        }

        public int getId() {
            return id;
        }
    }
}
