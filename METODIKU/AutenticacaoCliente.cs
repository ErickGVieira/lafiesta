using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace METODIKU
{
    static class AutenticacaoCliente
    {
        static int id;
        static String cpf;
        static String cnpj;
        static String nome;
        static String nomeUsuario;
        static String endereco;
        static String telefone;
        static String email;
        static String senha;
        static int tipo;

        static public void login(int idBD, int tipoDB)
        {
            id = idBD;
            tipo = tipoDB;
        }
        static public void Usuario(int idBD, String cpfBD, String nomeBD, String nomeUsuarioBD, String enderecoBD, String telefoneBD, String emailBD, String senhaBD)
        {
            id = idBD;
            cpf = cpfBD;
            nome = nomeBD;
            nomeUsuario = nomeUsuarioBD;
            endereco = enderecoBD;
            telefone = telefoneBD;
            email = emailBD;
            senha = senhaBD;

        }

        static public void Fornecedor(int idBD, String cnpjBD, String nomeBD, String nomeUsuarioBD, String enderecoBD, String telefoneBD, String emailBD, String senhaBD)
        {
            id = idBD;
            cnpj = cnpjBD;
            nome = nomeBD;
            nomeUsuario = nomeUsuarioBD;
            endereco = enderecoBD;
            telefone = telefoneBD;
            email = emailBD;
            senha = senhaBD;

        }
        static public void Sair()
        {
            id = 0;
            cpf = null;
            nome = null;
            nomeUsuario = null;
            endereco = null;
            telefone = null;
            email = null;
        }

        static public int pegarId()
        {
            return id;
        }
        static public int pegarTipo()
        {
            return tipo;
        }
        static public String pegarCpf()
        {
            return cpf;
        }
        static public String pegarCnpj()
        {
            return cnpj;
        }
        static public String pegarNome()
        {
            return nome;
        }
        static public String pegarNomeUsuario()
        {
            return nomeUsuario;
        }
        static public String pegarEndereco()
        {
            return endereco;
        }
        static public String pegarTelefone()
        {
            return telefone;
        }
        static public String pegarEmail()
        {
            return email;
        }
        static public String pegarSenha()
        {
            return senha;
        }
    }
}