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
    public partial class MenuCliente : Form
    {
        public MenuCliente()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Convidados convidados = new Convidados();
            convidados.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                AutenticacaoCliente.Sair();
                this.Hide();
                Login login = new Login();
                login.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            CadastroFesta cadastroFesta = new CadastroFesta();
            cadastroFesta.Show();
        }

        private void MenuCliente_Load(object sender, EventArgs e)
        {
            Festa.limparFesta();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            MinhaConta minhaConta = new MinhaConta();
            minhaConta.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            CalculadoraSimples calculadoraSimples = new CalculadoraSimples();
            calculadoraSimples.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            BuscaFornecedor busca = new BuscaFornecedor();
            busca.Show();
        }

        private void ajudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ajuda ajuda = new Ajuda();
            ajuda.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            MinhasFestas minhasFestas = new MinhasFestas();
            minhasFestas.Show();
        }
    }
}
