using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace METODIKU
{
    class Fornecedor
    {
        String cnpj;
        String nome;
        String nomeUsuario;
        String endereco;
        String telefone;
        String email;
        String senha;
        int tipo;

        public Fornecedor(String cpf, String nome, String nomeUsuario, String endereco, String telefone, String email, String senha, int tipo)
        {
            this.cnpj = cpf;
            this.nome = nome;
            this.nomeUsuario = nomeUsuario;
            this.endereco = endereco;
            this.telefone = telefone;
            this.email = email;
            this.senha = senha;
            this.tipo = tipo;
        }

        public String pegarCnpj()
        {
            return this.cnpj;
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
        public int pegarTipo()
        {
            return this.tipo;
        }
    }
}
