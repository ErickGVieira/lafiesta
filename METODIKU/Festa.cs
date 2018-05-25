using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace METODIKU
{
    static class Festa
    {
        static int id = 0;
        static String local;
        static int convidados;
        static String data;
        static String nomeFesta;

        static public void CadastrarFesta(String localF, int convidadosF, String dataF, String nomeFestaF)
        {
            local = localF;
            convidados = convidadosF;
            data = dataF;
            nomeFesta = nomeFestaF;
        } 

        static public void setarId(int idF)
        {
            id = idF;
        }
        static public int pegarId()
        {
            return id;
        }
        static public String pegarLocal()
        {
            return local;
        }
        static public int pegarConvidados()
        {
            return convidados;
        }
        static public String pegarData()
        {
            return data;
        }
        static public String pegarNome()
        {
            return nomeFesta;
        }

        static public void limparFesta()
        {
            id = 0;
            local = "";
            convidados = 0;
            data = "";
            nomeFesta = "";
        }
    }
}
