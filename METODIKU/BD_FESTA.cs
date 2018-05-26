using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace METODIKU
{
    class BD_FESTA
    {
        private String connString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=postgres;Database=LAFIESTA;";
        //private String connString = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=ifsp;Database=LAFIESTA;";

        private NpgsqlConnection conn;

        public int pegarFesta(int idUser)
        {
            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string buscar = String.Format("select * from festa where id_usuario = '{0}' order by id DESC;", idUser);

                using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(buscar, this.conn))
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

        public bool CadastrarFesta()
        {
            try
            {
                Encoding enc = new UTF8Encoding(true, true);
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string cmdInserir = String.Format("Insert Into festa(local, id_usuario, convidados, data, nome_festa) values('{0}',{1},{2},'{3}','{4}')", Festa.pegarLocal(), AutenticacaoCliente.pegarId(),
                       Festa.pegarConvidados(), Festa.pegarData(), Festa.pegarNome());

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
                //return true;
            }
            catch (Exception ex)
            {
                throw ex;
                //return true;
            }
            finally
            {
                this.conn.Close();
            }
        }

        public bool AtualizarFesta()
        {
            try
            {
                this.conn = new NpgsqlConnection(this.connString);
                Encoding enc = new UTF8Encoding(true, true);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string cmdInserir = String.Format("UPDATE festa SET local = '{0}', convidados = {1}, data = '{2}', nome_festa = '{3}' where id = {4} and id_usuario = {5}", Festa.pegarLocal(),
                       Festa.pegarConvidados(), Festa.pegarData(), Festa.pegarNome(), Festa.pegarId(), AutenticacaoCliente.pegarId());

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
    }
}
