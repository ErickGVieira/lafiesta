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
            bool sucesso = opiniao.CadastrarOpiniao(comboBox1.SelectedIndex + 1, textBox1.Text, 0);
            if (sucesso)
            {
                MessageBox.Show("Sucesso!!", "Mensagem enviada com sucesso", MessageBoxButtons.OK);
                comboBox1.Text = "";
                textBox1.Text = "";
            }
            else if (!sucesso)
                MessageBox.Show("ERRO!!", "Convidado não foi cadastrado!", MessageBoxButtons.OK);
        }
    }
}
