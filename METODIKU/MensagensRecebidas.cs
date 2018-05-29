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
    public partial class MensagensRecebidas : Form
    {
        BD_OPINIAO opiniao = new BD_OPINIAO();

        public MensagensRecebidas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            TipoMensagem tipoMsg = new TipoMensagem();
            tipoMsg.Show();
        }

        private void MensagensRecebidas_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = opiniao.ListaOpinioesRespondidas();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String resposta = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            this.Hide();
            VisualizarMensagem visualizarMsg = new VisualizarMensagem(resposta);
            visualizarMsg.Show();
        }
    }
}
