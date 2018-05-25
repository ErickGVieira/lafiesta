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
    public partial class FornecedorCliente : Form
    {
        public FornecedorCliente()
        {
            InitializeComponent();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            CadastroFornecedor fornecedor = new CadastroFornecedor();
            fornecedor.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Cadastro cliente = new Cadastro();
            cliente.Show();
        }

    }
}
