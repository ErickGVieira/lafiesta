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
    public partial class MinhaConta : Form
    {
        public MinhaConta()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuCliente menuCliente = new MenuCliente();
            menuCliente.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListaMensagem listaMensagem = new ListaMensagem();
            listaMensagem.Show();
        }

        private void MinhaConta_Load(object sender, EventArgs e)
        {
            BD_OPINIAO opiniao = new BD_OPINIAO();
            label1.Text = opiniao.ListaOpinioesRespondida().ToString();
        }
    }
}
