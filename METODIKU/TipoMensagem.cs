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
    public partial class TipoMensagem : Form
    {
        public TipoMensagem()
        {
            InitializeComponent();
        }

        private void TipoMensagem_Load(object sender, EventArgs e)
        {
            BD_OPINIAO opiniao = new BD_OPINIAO();
            label1.Text = opiniao.SomaOpinioesRespondida().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListaMensagem listaMensagem = new ListaMensagem();
            listaMensagem.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MensagensRecebidas mensagensRecebidas = new MensagensRecebidas();
            mensagensRecebidas.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MinhaConta minhaConta = new MinhaConta();
            minhaConta.Show();
        }
    }
}
