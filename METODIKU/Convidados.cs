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
    public partial class Convidados : Form
    {
        public Convidados()
        {
            InitializeComponent();
        }

        private void Convidados_Load(object sender, EventArgs e)
        {
            BD_CONVIDADOS conecta = new BD_CONVIDADOS();
            dataGridView1.DataSource = conecta.ListaConvidados();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuCliente menu = new MenuCliente();
            menu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BD_CONVIDADOS convidado = new BD_CONVIDADOS();
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            bool sucesso = convidado.RemoverConvidado(id);
            if (sucesso)
                dataGridView1.DataSource = convidado.ListaConvidados();
            else if (!sucesso)
                MessageBox.Show("ERRO!!", "Convidado não foi cadastrado!", MessageBoxButtons.OK);
            limpar();
        }

        public void limpar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BD_CONVIDADOS convidado = new BD_CONVIDADOS();
            bool sucesso = convidado.CadastraConvidado(textBox1.Text, int.Parse(textBox2.Text), comboBox1.Text);
            if (sucesso)
                dataGridView1.DataSource = convidado.ListaConvidados();
            else if (!sucesso)
                MessageBox.Show("ERRO!!", "Convidado não foi cadastrado!", MessageBoxButtons.OK);
            limpar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
