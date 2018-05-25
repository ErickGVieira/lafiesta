using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace METODIKU
{
    class Usuario
    {
        String cpf;
        String nome;
        String nomeUsuario;
        String endereco;
        String telefone;
        String email;
        String senha;

        public Usuario(String cpf, String nome, String nomeUsuario, String endereco, String telefone, String email, String senha)
        {
            this.cpf = cpf;
            this.nome = nome;
            this.nomeUsuario = nomeUsuario;
            this.endereco = endereco;
            this.telefone = telefone;
            this.email = email;
            this.senha = senha;
        }

        public String pegarCpf()
        {
            return this.cpf;
        }
        public String pegarNome()
        {
            return this.nome;
        }
        public String pegarNomeUsuario()
        {
            return this.nomeUsuario;
        }
        public String pegarEndereco()
        {
            return this.endereco;
        }
        public String pegarTelefone()
        {
            return this.telefone;
        }
        public String pegarEmail()
        {
            return this.email;
        }
        public String pegarSenha()
        {
            return this.senha;
        }
    }
}
