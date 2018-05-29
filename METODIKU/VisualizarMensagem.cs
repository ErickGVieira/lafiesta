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
    public partial class VisualizarMensagem : Form
    {
        String resposta;
        public VisualizarMensagem(String resposta)
        {
            InitializeComponent();
            this.resposta = resposta;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MensagensRecebidas msgRecebidas = new MensagensRecebidas();
            msgRecebidas.Show();
        }

        private void VisualizarMensagem_Load(object sender, EventArgs e)
        {
            textBox1.Text = this.resposta;
        }
    }
}
