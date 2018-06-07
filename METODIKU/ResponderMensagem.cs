using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            textBox3.Multiline = true;
            textBox3.ScrollBars = ScrollBars.Vertical;
            textBox3.AcceptsReturn = true;
            textBox3.AcceptsTab = true;
            textBox3.WordWrap = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BD_OPINIAO opiniao = new BD_OPINIAO();
            int usuarioDestino = opiniao.PegarUsuario(id);
            String reformatado = RemoveAccents(textBox3.Text);
            bool sucesso = opiniao.CadastrarOpiniao(reformatado, usuarioDestino);
            if (sucesso)
            {
                MessageBox.Show("Mensagem enviada com sucesso!!", "Sucesso!", MessageBoxButtons.OK);
                textBox3.Text = "";
            }
            else if (!sucesso)
                MessageBox.Show("Erro ao enviar mensagem para o usuário!!", "Erro!", MessageBoxButtons.OK);
        }

        public string RemoveAccents(string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }
    }
}
