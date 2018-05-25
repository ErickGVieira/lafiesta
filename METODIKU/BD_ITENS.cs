using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;
namespace METODIKU
{
    class BD_ITENS
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

        public DataTable grupoComidas()
        {
            DataTable dt = new DataTable();

            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string buscarGrupoComidas = String.Format("Select * from grupo_comida");

                using (NpgsqlDataAdapter pgsqlcommand = new NpgsqlDataAdapter(buscarGrupoComidas, this.conn))
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

        public DataTable tiposComida(int idGrupo)
        {
            DataTable dt = new DataTable();

            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string buscarGrupoComidas = String.Format("Select * from tipo_comida where id_grupo = {0}", idGrupo);

                using (NpgsqlDataAdapter pgsqlcommand = new NpgsqlDataAdapter(buscarGrupoComidas, this.conn))
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

        public bool CadastraComida(String tipo)
        {
            try
            {
                BD_FESTA festa = new BD_FESTA();
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string cmdInserir = String.Format("Insert Into comida(tipo, id_festa) values('{0}',{1})", tipo, festa.pegarFesta(AutenticacaoCliente.pegarId()));

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

        public bool RemoverComida(int id, int idFesta)
        {
            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string cmdInserir = String.Format("Delete FROM comida where id = {0} and id_festa = {1}", id, idFesta);

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

        public DataTable comidas(int idFesta)
        {
            DataTable dt = new DataTable();

            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string convidados = String.Format("select c.id, g.nome, c.tipo from comida c, tipo_comida t, grupo_comida g where id_festa = {0} and c.tipo = t.nome and t.id_grupo = g.id", idFesta);

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

        public int verificaComida(int idFesta, String tipo)
        {
            DataTable dt = new DataTable();

            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string verificaComida = String.Format("Select id from comida where id_festa = {0} and tipo = '{1}'", idFesta, tipo);

                using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(verificaComida, this.conn))
                {
                    NpgsqlDataReader dr = pgsqlcommand.ExecuteReader();

                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            return dr.GetInt32(0);
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
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            finally
            {
                this.conn.Close();
            }
            return 0;
        }

        public DataTable grupoBebidas()
        {
            DataTable dt = new DataTable();

            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string buscarGrupoComidas = String.Format("Select * from grupo_bebida");

                using (NpgsqlDataAdapter pgsqlcommand = new NpgsqlDataAdapter(buscarGrupoComidas, this.conn))
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

        public DataTable tiposBebida(int idGrupo)
        {
            DataTable dt = new DataTable();

            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string buscarTipos = String.Format("Select * from tipo_bebida where id_grupo = {0}", idGrupo);

                using (NpgsqlDataAdapter pgsqlcommand = new NpgsqlDataAdapter(buscarTipos, this.conn))
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

        public bool CadastraBebida(String tipo)
        {
            try
            {
                BD_FESTA festa = new BD_FESTA();
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string cmdInserir = String.Format("Insert Into bebida(tipo, id_festa) values('{0}',{1})", tipo, festa.pegarFesta(AutenticacaoCliente.pegarId()));

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

        public DataTable bebidas(int idFesta)
        {
            DataTable dt = new DataTable();

            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string convidados = String.Format("select c.id, g.nome, c.tipo from bebida c, tipo_bebida t, grupo_bebida g where id_festa = {0} and c.tipo = t.nome and t.id_grupo = g.id", idFesta);

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

        public bool RemoverBebida(int id, int idFesta)
        {
            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string cmdInserir = String.Format("Delete FROM bebida where id = {0} and id_festa = {1}", id, idFesta);

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

        public int verificaBebida(int idFesta, String tipo)
        {
            DataTable dt = new DataTable();

            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string verificaBebida = String.Format("Select id from bebida where id_festa = {0} and tipo = '{1}'", idFesta, tipo);

                using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(verificaBebida, this.conn))
                {
                    NpgsqlDataReader dr = pgsqlcommand.ExecuteReader();

                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            return dr.GetInt32(0);
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
            }
            catch (Exception ex)
            {
                //throw ex;
            }
            finally
            {
                this.conn.Close();
            }
            return 0;
        }
    }
}
