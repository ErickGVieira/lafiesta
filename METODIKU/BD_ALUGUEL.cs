using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace METODIKU
{
    class BD_ALUGUEL
    {
        private String connString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=postgres;Database=LAFIESTA;";
        //private String connString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=ifsp;Database=LAFIESTA;";

        private NpgsqlConnection conn;

        public bool CadastraAlguel(int tipo)
        {
            try
            {
                BD_FESTA festa = new BD_FESTA();
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string cmdInserir = String.Format("Insert Into aluguel(id_festa, id_produto) values({0},{1})", festa.pegarFesta(AutenticacaoCliente.pegarId()), tipo);

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


        public long TotalAluguel()
        {
            BD_FESTA festa = new BD_FESTA();
            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string totalConvidados = String.Format("Select COUNT(*) from aluguel where id_festa = {0}", festa.pegarFesta(AutenticacaoCliente.pegarId()));

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


        public DataTable ListaAlugueis()
        {
            BD_FESTA festa = new BD_FESTA();
            DataTable dt = new DataTable();

            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string convidados = String.Format("select a.id, p.tipo, p.observacao, p.cidade from aluguel a INNER JOIN produto p ON a.id_produto = p.id where a.id_festa = {0}", festa.pegarFesta(AutenticacaoCliente.pegarId()));

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

        public bool RemoverAluguel(int tipo)
        {
            try
            {
                BD_FESTA festa = new BD_FESTA();
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string cmdInserir = String.Format("delete from aluguel where id = {0}", tipo);

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
    }
}
