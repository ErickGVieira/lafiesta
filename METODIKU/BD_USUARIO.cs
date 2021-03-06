﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace METODIKU
{
    class BD_USUARIO
    {
        //private String connString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=ifsp;Database=LAFIESTA;";
        private String connString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=postgres;Database=LAFIESTA;";

        private NpgsqlConnection conn;

        public String conecta()
        {
            String retorno;
            this.conn = new NpgsqlConnection(this.connString);

            try
            {
                this.conn.Open();
                retorno = "Conectado no banco!";
            }
            catch (NpgsqlException ex)
            {
                retorno = ex.Message;
            }
            finally
            {
                this.conn.Close();
            }
            return retorno;
        }

        public bool CadastrarUsuario(Usuario usuario)
        {
            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                    string cmdInserir = String.Format("Insert Into usuario(cpf, nome, nome_usuario, endereco, telefone, email, senha) values({0},'{1}','{2}','{3}','{4}', '{5}', '{6}')", usuario.pegarCpf(), usuario.pegarNome(), 
                           usuario.pegarNomeUsuario(), usuario.pegarEndereco(), usuario.pegarTelefone(), usuario.pegarEmail(), usuario.pegarSenha());
                   
                    using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(cmdInserir, this.conn))
                    {
                        pgsqlcommand.ExecuteNonQuery();
                        return true; 
                    }
                
            }
            catch (NpgsqlException ex)
            {
                //throw ex;
                return false;
            }
            catch (Exception ex)
            {
                //throw ex;
                return false;
            }
            finally
            {
                this.conn.Close();
            }
        }

        public void Login(string nomeUsuario, string senha)
        {
            //DataSet ds = new DataSet();

            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string buscar = String.Format("Select id, coalesce(tipo ,2)  from usuario where nome_usuario = '{0}' and senha = '{1}'", nomeUsuario, senha);

                using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(buscar, this.conn))
                {
                    NpgsqlDataReader dr = pgsqlcommand.ExecuteReader();

                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            AutenticacaoCliente.login(dr.GetInt32(0), dr.GetInt32(1));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Não funcionou!");
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.conn.Close();
            }
        }

        public String recuperarSenha(string nomeUsuario, string cpf)
        {
            DataSet ds = new DataSet();

            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string buscar = String.Format("Select senha from usuario where nome_usuario = '{0}' and cpf = '{1}'", nomeUsuario, cpf);

                using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(buscar, this.conn))
                {
                    //pgsqlcommand.Fill(dt);
                    NpgsqlDataReader dr = pgsqlcommand.ExecuteReader();

                    if (dr.HasRows)
                    {
                        if (dr.Read())
                            return dr.GetString(0);
                    }
                    else
                    {
                        Console.WriteLine("Não funcionou!");
                        return null;
                    }
                    return null;
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
                //return dt.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
                //return dt.ToString();
            }
            finally
            {
                this.conn.Close();
            }
        }

        public bool CadastrarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string cmdInserir = String.Format("Insert Into usuario(cnpj, nome, nome_usuario, endereco, telefone, email, senha, tipo) values({0},'{1}','{2}','{3}','{4}', '{5}', '{6}', {7})", fornecedor.pegarCnpj(), fornecedor.pegarNome(),
                       fornecedor.pegarNomeUsuario(), fornecedor.pegarEndereco(), fornecedor.pegarTelefone(), fornecedor.pegarEmail(), fornecedor.pegarSenha(), fornecedor.pegarTipo());

                using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(cmdInserir, this.conn))
                {
                    pgsqlcommand.ExecuteNonQuery();
                    return true;
                }

            }
            catch (NpgsqlException ex)
            {
                throw ex;
                //return false;
            }
            catch (Exception ex)
            {
                throw ex;
                //return false;
            }
            finally
            {
                this.conn.Close();
            }
        }

        public bool ExcluirUsuario()
        {
            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string cmdInserir = String.Format("DELETE from usuario WHERE id = {0}", AutenticacaoCliente.pegarId());

                using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(cmdInserir, this.conn))
                {
                    pgsqlcommand.ExecuteNonQuery();
                    return true;
                }

            }
            catch (NpgsqlException ex)
            {
                //throw ex;
                return false;
            }
            catch (Exception ex)
            {
                //throw ex;
                return false;
            }
            finally
            {
                this.conn.Close();
            }
        }

        public void PegarCliente()
        {
            DataSet ds = new DataSet();

            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string buscar = String.Format("Select id, cpf, nome, nome_usuario, endereco, telefone, email, senha from usuario where id = {0}", AutenticacaoCliente.pegarId());

                using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(buscar, this.conn))
                {
                    //pgsqlcommand.Fill(dt);
                    NpgsqlDataReader dr = pgsqlcommand.ExecuteReader();

                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            AutenticacaoCliente.Usuario(dr.GetInt32(0), dr.GetInt64(1).ToString(), dr.GetString(2), dr.GetString(3), dr.GetString(4), dr.GetString(5), dr.GetString(6), dr.GetString(7));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Não funcionou!");
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
                //return dt.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
                //return dt.ToString();
            }
            finally
            {
                this.conn.Close();
            }
        }

        public bool AtualizarUsuario(Usuario usuario)
        {
            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string atualizar = String.Format("UPDATE usuario SET cpf = {0}, nome = '{1}', nome_usuario = '{2}', endereco = '{3}', telefone = '{4}', email = '{5}', senha = '{6}' WHERE id = {7}", usuario.pegarCpf(), usuario.pegarNome(),
                       usuario.pegarNomeUsuario(), usuario.pegarEndereco(), usuario.pegarTelefone(), usuario.pegarEmail(), usuario.pegarSenha(), AutenticacaoCliente.pegarId());

                Console.WriteLine(atualizar);
                using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(atualizar, this.conn))
                {
                    pgsqlcommand.ExecuteNonQuery();
                    return true;
                }

            }
            catch (NpgsqlException ex)
            {
                //throw ex;
                return false;
            }
            catch (Exception ex)
            {
                //throw ex;
                return false;
            }
            finally
            {
                this.conn.Close();
            }
        }

        public void PegarFornecedor()
        {
            DataSet ds = new DataSet();

            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string buscar = String.Format("Select id, cnpj, nome, nome_usuario, endereco, telefone, email, senha from usuario where id = {0}", AutenticacaoCliente.pegarId());

                using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(buscar, this.conn))
                {
                    //pgsqlcommand.Fill(dt);
                    NpgsqlDataReader dr = pgsqlcommand.ExecuteReader();

                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            AutenticacaoCliente.Fornecedor(dr.GetInt32(0), dr.GetInt64(1).ToString(), dr.GetString(2), dr.GetString(3), dr.GetString(4), dr.GetString(5), dr.GetString(6), dr.GetString(7));
                        }
                    }
                    else
                    {
                        Console.WriteLine("Não funcionou!");
                    }
                }
            }
            catch (NpgsqlException ex)
            {
                throw ex;
                //return dt.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
                //return dt.ToString();
            }
            finally
            {
                this.conn.Close();
            }
        }

        public bool AtualizarFornecedor(Fornecedor fornecedor)
        {
            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string atualizar = String.Format("UPDATE usuario SET cnpj = {0}, nome = '{1}', nome_usuario = '{2}', endereco = '{3}', telefone = '{4}', email = '{5}', senha = '{6}' WHERE id = {7}", fornecedor.pegarCnpj(), fornecedor.pegarNome(),
                       fornecedor.pegarNomeUsuario(), fornecedor.pegarEndereco(), fornecedor.pegarTelefone(), fornecedor.pegarEmail(), fornecedor.pegarSenha(), AutenticacaoCliente.pegarId());

                Console.WriteLine(atualizar);
                using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(atualizar, this.conn))
                {
                    pgsqlcommand.ExecuteNonQuery();
                    return true;
                }

            }
            catch (NpgsqlException ex)
            {
                //throw ex;
                return false;
            }
            catch (Exception ex)
            {
                //throw ex;
                return false;
            }
            finally
            {
                this.conn.Close();
            }
        }
    }
}
