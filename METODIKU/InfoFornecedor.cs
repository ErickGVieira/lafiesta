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
    public partial class InfoFornecedor : Form
    {
        int id;
        BD_ITENS itens = new BD_ITENS();

        public InfoFornecedor(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void InfoFornecedor_Load(object sender, EventArgs e)
        {
            String[] informacoes = new String[4];
            informacoes = itens.infoFornecedor(id);
            textBox1.Text = informacoes[0];
            textBox2.Text = informacoes[1];
            textBox3.Text = informacoes[2];
            textBox4.Text = informacoes[3];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            BuscaFornecedor busca = new BuscaFornecedor();
            busca.Show();
        }
    }
}
