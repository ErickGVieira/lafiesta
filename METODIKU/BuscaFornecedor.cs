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
    public partial class BuscaFornecedor : Form
    {
        BD_ITENS itens = new BD_ITENS();
        public BuscaFornecedor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuCliente menuCliente = new MenuCliente();
            menuCliente.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.DataSource = itens.tiposProdutos(comboBox1.SelectedIndex + 1);
            comboBox2.DisplayMember = "nome";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button2.Visible = false;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dataGridView2.DataSource = itens.BuscaFornecedor(textBox2.Text.ToUpper(), comboBox4.Text);
                if (dataGridView2.RowCount > 1)
                    button2.Visible = true;
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.DataSource = itens.tiposProdutos(comboBox3.SelectedIndex + 1);
            comboBox4.DisplayMember = "nome";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView2.CurrentRow.Cells[0].Value;
            this.Hide();
            InfoFornecedor info = new InfoFornecedor(id);
            info.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            MenuCliente menuCliente = new MenuCliente();
            menuCliente.Show();
        }

        private void BuscaFornecedor_Load(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
