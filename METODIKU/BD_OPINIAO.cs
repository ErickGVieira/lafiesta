using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace METODIKU
{
    class BD_OPINIAO
    {
        private String connString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=postgres;Database=LAFIESTA;";
        //private String connString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=ifsp;Database=LAFIESTA;";
        private NpgsqlConnection conn;

        public bool CadastrarOpiniaoLF(int classificacao, String descricao, int destino)
        {
            try
            {
                Encoding enc = new UTF8Encoding(true, true);

                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string cmdInserir = String.Format("Insert INTO opiniao (classificacao, id_usuario, descricao, destino) values({0},{1},'{2}', {3})", classificacao, AutenticacaoCliente.pegarId(),
                       descricao, destino);

                byte[] bytes = Encoding.Default.GetBytes(cmdInserir);
                cmdInserir = Encoding.UTF8.GetString(bytes);

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

        public bool CadastrarOpiniao(String descricao, int destino)
        {
            try
            {
                Encoding enc = new UTF8Encoding(true, true);

                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string cmdInserir = String.Format("Insert INTO opiniao (descricao, destino) values('{0}', {1})", descricao, destino);

                byte[] bytes = Encoding.Default.GetBytes(cmdInserir);
                cmdInserir = Encoding.UTF8.GetString(bytes);

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

        public DataTable ListaOpinioes()
        {
            DataTable dt = new DataTable();

            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string convidados = String.Format("Select id,descricao from opiniao where id_usuario = '{0}'", AutenticacaoCliente.pegarId());

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

        public DataTable ListaOpinioesAdministrador()
        {
            DataTable dt = new DataTable();

            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string convidados = String.Format("Select o.id,  u.nome, o.descricao from opiniao o, usuario u where destino = 0 and o.id_usuario = u.id");

                using (NpgsqlDataAdapter pgsqlcommand = new NpgsqlDataAdapter(convidados, this.conn))
                {
                    pgsqlcommand.Fill(dt);
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
            return dt;
        }

        public long SomaOpinioesRespondida()
        {
            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string opinioesRespondidas = String.Format("Select COUNT(*) from opiniao where destino = {0}", AutenticacaoCliente.pegarId());
                Console.WriteLine(opinioesRespondidas);

                using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(opinioesRespondidas, this.conn))
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
                //throw ex;
                return 0;
            }
            catch (Exception ex)
            {
                //throw ex;
                return 0;
            }
            finally
            {
                this.conn.Close();
            }
            return 0;
        }

        public int PegarUsuario(int id)
        {
            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string opinioesRespondidas = String.Format("Select id_usuario from opiniao where id = {0}", id);

                using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(opinioesRespondidas, this.conn))
                {
                    NpgsqlDataReader dr = pgsqlcommand.ExecuteReader();

                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            return dr.GetInt16(0);
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
                //return 0;
            }
            catch (Exception ex)
            {
                throw ex;
                //return 0;
            }
            finally
            {
                this.conn.Close();
            }
            return 0;
        }

        public DataTable ListaOpinioesRespondidas()
        {
            DataTable dt = new DataTable();

            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string convidados = String.Format("Select id,descricao from opiniao where destino = {0}", AutenticacaoCliente.pegarId());

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
    }
}
