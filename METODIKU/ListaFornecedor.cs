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
    public partial class ListaFornecedor : Form
    {

        BD_ALUGUEL aluguel = new BD_ALUGUEL();
        public ListaFornecedor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FornecedorFesta fornecedorFesta = new FornecedorFesta();
            fornecedorFesta.Show();
        }

        private void ListaFornecedor_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = aluguel.ListaAlugueis();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            bool sucesso = aluguel.RemoverAluguel(id);
            if (sucesso)
                dataGridView1.DataSource = aluguel.ListaAlugueis();
            else
                MessageBox.Show("Erro ao apagar um aluguel", "Erro", MessageBoxButtons.OK);
        }
    }
}
