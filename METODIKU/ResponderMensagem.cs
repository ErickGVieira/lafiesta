using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace METODIKU
{
    public partial class ResponderMensagem : Form
    {
        private int id;
        private String nome;
        private String descricao;
        public ResponderMensagem(int id, String nome, String descricao)
        {
            InitializeComponent();
            this.id = id;
            this.nome = nome;
            this.descricao = descricao;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListaMensagem listaMensagem = new ListaMensagem();
            listaMensagem.Show(); 
        }

        private void ResponderMensagem_Load(object sender, EventArgs e)
        {
            textBox1.Text = this.nome;
            textBox2.Text = this.descricao;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BD_OPINIAO opiniao = new BD_OPINIAO();
            int usuarioDestino = opiniao.PegarUsuario(id);
            textBox3.Text = usuarioDestino.ToString();
            bool sucesso = opiniao.CadastrarOpiniao(0, textBox3.Text, usuarioDestino);
            if (sucesso)
            {
                MessageBox.Show("Sucesso!!", "Mensagem enviada com sucesso", MessageBoxButtons.OK);
                textBox3.Text = "";
            }
            else if (!sucesso)
                MessageBox.Show("ERRO!!", "Convidado não foi cadastrado!", MessageBoxButtons.OK);
        }
    }
}
