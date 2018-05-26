using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace METODIKU
{
    class BD_CONVIDADOS
    {
        private String connString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=postgres;Database=LAFIESTA;";
        //private String connString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=ifsp;Database=LAFIESTA;";

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

        public bool CadastraConvidado(String nome, int idade, String sexo)
        {
            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();
                
                string cmdInserir = String.Format("Insert Into convidado(nome, idade, sexo, id_usuario) values('{0}',{1},'{2}', {3})", nome, idade,
                       sexo, AutenticacaoCliente.pegarId());

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

        public DataTable ListaConvidados()
        {
            DataTable dt = new DataTable();

            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string convidados = String.Format("Select id,nome,sexo,idade from convidado where id_usuario = '{0}'", AutenticacaoCliente.pegarId());

                using (NpgsqlDataAdapter pgsqlcommand = new NpgsqlDataAdapter(convidados, this.conn))
                {
                    pgsqlcommand.Fill(dt);
                }

            }
            catch (NpgsqlException ex)
            {
                //throw ex;
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            finally
            {
                this.conn.Close();
            }
            return dt;
        }

        public long TotalConvidados()
        {
            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string totalConvidados = String.Format("Select COUNT(*) from convidado where id_usuario = '{0}'", AutenticacaoCliente.pegarId());

                using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(totalConvidados, this.conn))
                {
                    NpgsqlDataReader dr = pgsqlcommand.ExecuteReader();

                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            return dr.GetInt64(0);
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
            return 0;
        }

        public bool RemoverConvidado(int id)
        {
            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string cmdInserir = String.Format("Delete FROM convidado where id = {0}", id);

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

        public long TotalCriancas()
        {
            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string totalConvidados = String.Format("select count(*) from convidado where idade <= 15 and id_usuario = '{0}'", AutenticacaoCliente.pegarId());

                using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(totalConvidados, this.conn))
                {
                    NpgsqlDataReader dr = pgsqlcommand.ExecuteReader();

                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            return dr.GetInt64(0);
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
            return 0;
        }

        public long TotalHomens()
        {
            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string totalConvidados = String.Format("select count(*) from convidado where idade > 15 and sexo = 'Masculino' and id_usuario = '{0}'", AutenticacaoCliente.pegarId());

                using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(totalConvidados, this.conn))
                {
                    NpgsqlDataReader dr = pgsqlcommand.ExecuteReader();

                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            return dr.GetInt64(0);
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
            return 0;
        }

        public long TotalMulheres()
        {
            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string totalConvidados = String.Format("select count(*) from convidado where idade > 15 and sexo = 'Feminino' and id_usuario = '{0}'", AutenticacaoCliente.pegarId());

                using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(totalConvidados, this.conn))
                {
                    NpgsqlDataReader dr = pgsqlcommand.ExecuteReader();

                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            return dr.GetInt64(0);
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
            return 0;
        }
    }
}
