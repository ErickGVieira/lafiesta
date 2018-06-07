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

        public bool CadastraComida(String grupo, String tipo, String quantidade)
        {
            try
            {
                BD_FESTA festa = new BD_FESTA();
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string cmdInserir = String.Format("Insert Into comida(tipo, id_festa, grupo, quantidade) values('{0}',{1}, '{2}', '{3}')", tipo, festa.pegarFesta(AutenticacaoCliente.pegarId()), grupo, quantidade);

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

                string convidados = String.Format("select c.id, g.nome, c.tipo, c.quantidade from comida c, tipo_comida t, grupo_comida g where id_festa = {0} and c.tipo = t.nome and t.id_grupo = g.id order by c.id", idFesta);

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

        public bool CadastraBebida(String tipo, String quantidade)
        {
            try
            {
                BD_FESTA festa = new BD_FESTA();
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string cmdInserir = String.Format("Insert Into bebida(tipo, id_festa, quantidade) values('{0}',{1},'{2}')", tipo, festa.pegarFesta(AutenticacaoCliente.pegarId()), quantidade);

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

                string convidados = String.Format("select c.id, g.nome, c.tipo, c.quantidade from bebida c, tipo_bebida t, grupo_bebida g where id_festa = {0} and c.tipo = t.nome and t.id_grupo = g.id", idFesta);

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

        public long quantidadeCarne()
        {
            try
            {
                BD_FESTA festa = new BD_FESTA();
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string verificaComida = String.Format("select count(*) from comida where id_festa = '{0}' and (grupo = 'CHURRASCO' and (tipo like '%CARNE%' or tipo like '%LINGUI%'))", festa.pegarFesta(AutenticacaoCliente.pegarId()));
                using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(verificaComida, this.conn))
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

        public void AtualizarCarnes(String quantidade)
        {
            try
            {
                BD_FESTA festa = new BD_FESTA();
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string atualizar = String.Format("UPDATE comida SET quantidade = '{0}' where id_festa = {1}  and (grupo = 'CHURRASCO' and (tipo like '%CARNE%' or tipo like '%LINGUI%'))", quantidade, festa.pegarFesta(AutenticacaoCliente.pegarId()));
                Console.WriteLine(atualizar);
                using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(atualizar, this.conn))
                {
                    pgsqlcommand.ExecuteNonQuery();
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
        }

        public long totalComidas()
        {
            try
            {
                BD_FESTA festa = new BD_FESTA();
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string verificaComida = String.Format("select count(*) from comida where id_festa = {0}", festa.pegarFesta(AutenticacaoCliente.pegarId()));
                using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(verificaComida, this.conn))
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

        public void AtualizarSalgadinhos(String quantidade)
        {
            try
            {
                BD_FESTA festa = new BD_FESTA();
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string atualizar = String.Format("UPDATE comida SET quantidade = '{0}' where id_festa = {1}  and (grupo = 'FINGER FOODS' and tipo not like '%PASTEL%')", quantidade, festa.pegarFesta(AutenticacaoCliente.pegarId()));
                Console.WriteLine(atualizar);
                using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(atualizar, this.conn))
                {
                    pgsqlcommand.ExecuteNonQuery();
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
        }

        public void AtualizarPasteis(String quantidade)
        {
            try
            {
                BD_FESTA festa = new BD_FESTA();
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string atualizar = String.Format("UPDATE comida SET quantidade = '{0}' where id_festa = {1}  and (grupo = 'FINGER FOODS' and tipo like '%PASTEL%')", quantidade, festa.pegarFesta(AutenticacaoCliente.pegarId()));
                Console.WriteLine(atualizar);
                using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(atualizar, this.conn))
                {
                    pgsqlcommand.ExecuteNonQuery();
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
        }

        public DataTable grupoUtensilio()
        {
            DataTable dt = new DataTable();

            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string buscarGrupoComidas = String.Format("Select * from grupo_utensilio");

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

        public DataTable utensilios(int idFesta)
        {
            DataTable dt = new DataTable();

            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string convidados = String.Format("select u.id, g.nome, u.tipo, u.quantidade from utensilio u, tipo_utensilio t, grupo_utensilio g where id_festa = {0} and u.tipo = t.nome and t.id_grupo = g.id order by u.id", idFesta);

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

        public DataTable tiposUtensilio(int idGrupo)
        {
            DataTable dt = new DataTable();

            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string buscarGrupoComidas = String.Format("Select * from tipo_utensilio where id_grupo = {0}", idGrupo);

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

        public int verificaUtensilio(int idFesta, String tipo)
        {
            DataTable dt = new DataTable();

            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string verificaComida = String.Format("Select id from utensilio where id_festa = {0} and tipo = '{1}'", idFesta, tipo);

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

        public bool CadastrarUtensilio(String grupo, String tipo, String quantidade)
        {
            try
            {
                BD_FESTA festa = new BD_FESTA();
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string cmdInserir = String.Format("Insert Into utensilio(tipo, id_festa, grupo, quantidade) values('{0}',{1}, '{2}', '{3}')", tipo, festa.pegarFesta(AutenticacaoCliente.pegarId()), grupo, quantidade);

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

        public bool RemoverUtensilio(int id, int idFesta)
        {
            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string cmdInserir = String.Format("Delete FROM utensilio where id = {0} and id_festa = {1}", id, idFesta);

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

        public DataTable tiposProdutos(int id_grupo)
        {
            DataTable dt = new DataTable();

            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string buscarGrupoComidas = String.Format("Select nome from tipo_produto where id_grupo = {0}", id_grupo);

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

        public bool CadastraProduto(String tipo, String observacao, String cidade)
        {
            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string cmdInserir = String.Format("Insert Into produto(id_fornecedor, tipo, observacao, cidade) values({0},'{1}', '{2}', '{3}')", AutenticacaoCliente.pegarId(), tipo, observacao, cidade);

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
        public DataTable BuscaFornecedor(String cidade, String tipo)
        {
            DataTable dt = new DataTable();

            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string buscarfornecedor = String.Format("select id,tipo,observacao,cidade from produto where cidade like '{0}' and tipo = '{1}'", cidade, tipo);

                using (NpgsqlDataAdapter pgsqlcommand = new NpgsqlDataAdapter(buscarfornecedor, this.conn))
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

        public String[] infoFornecedor(int id)
        {
            String[] retorno = new String[4];
            //DataSet ds = new DataSet();

            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string buscar = String.Format("select c.nome, c.telefone, p.cidade, p.observacao  from produto p INNER JOIN usuario c ON p.id_fornecedor = c.id where p.id = {0}", id);

                using (NpgsqlCommand pgsqlcommand = new NpgsqlCommand(buscar, this.conn))
                {
                    NpgsqlDataReader dr = pgsqlcommand.ExecuteReader();

                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            retorno[0] = dr.GetString(0);
                            retorno[1] = dr.GetString(1);
                            retorno[2] = dr.GetString(2);
                            retorno[3] = dr.GetString(3);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Não funcionou!");
                        retorno = null;
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
            return retorno;
        }

        public DataTable BuscaLocal(String cidade)
        {
            DataTable dt = new DataTable();

            try
            {
                this.conn = new NpgsqlConnection(this.connString);

                //Abra a conexão com o PgSQL                  
                this.conn.Open();

                string buscarfornecedor = String.Format("select id,tipo,observacao,cidade from produto where tipo = 'ESPACO' and cidade = '{0}'", cidade);

                using (NpgsqlDataAdapter pgsqlcommand = new NpgsqlDataAdapter(buscarfornecedor, this.conn))
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
    }
}
