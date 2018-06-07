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
    public partial class FornecedorFesta : Form
    {
        BD_ITENS itens = new BD_ITENS();
        BD_ALUGUEL aluguel = new BD_ALUGUEL();

        public FornecedorFesta()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.DataSource = itens.tiposProdutos(comboBox1.SelectedIndex + 1);
            comboBox2.DisplayMember = "nome";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button3.Visible = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dataGridView1.DataSource = itens.BuscaFornecedor(textBox1.Text.ToUpper(), comboBox2.Text);
                if (dataGridView1.RowCount > 1)
                    button3.Visible = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Utensilio utensilio = new Utensilio();
            utensilio.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            bool criado = aluguel.CadastraAlguel(id);
            if (criado)
            {
                MessageBox.Show("Inserido na sua festa com sucesso!", "Sucesso!", MessageBoxButtons.OK);
                label1.Text = aluguel.TotalAluguel().ToString();
            }
            else
                MessageBox.Show("Erro ao inserir um fornecedor na sua festa!", "Erro!", MessageBoxButtons.OK);
        }

        private void FornecedorFesta_Load(object sender, EventArgs e)
        {
            label1.Text = aluguel.TotalAluguel().ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListaFornecedor listaFornecedores = new ListaFornecedor();
            listaFornecedores.Show();
        }
    }
}
