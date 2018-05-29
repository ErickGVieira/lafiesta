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
    public partial class Mensagem : Form
    {
        public Mensagem()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListaMensagem listaMensagem = new ListaMensagem();
            listaMensagem.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BD_OPINIAO opiniao = new BD_OPINIAO();
            String reformatado = RemoveAccents(textBox1.Text);
            bool sucesso = opiniao.CadastrarOpiniaoLF(comboBox1.SelectedIndex + 1, reformatado, 0);
            if (sucesso)
            {
                MessageBox.Show("Mensagem enviada com sucesso!!", "Sucesso!", MessageBoxButtons.OK);
                comboBox1.Text = "";
                textBox1.Text = "";
            }
            else if (!sucesso)
                MessageBox.Show("Erro ao enviar mensagem para a equipe lá fiesta!!", "Erro!!", MessageBoxButtons.OK);
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
