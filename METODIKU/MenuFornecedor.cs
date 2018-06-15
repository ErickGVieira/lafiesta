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
    public partial class MenuFornecedor : Form
    {
        public MenuFornecedor()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Deseja realmente sair?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                AutenticacaoCliente.Sair();
                this.Hide();
                Login login = new Login();
                login.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MinhaConta minhaConta = new MinhaConta();
            this.Hide();
            minhaConta.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CadastroProdServ cadastroProdServ = new CadastroProdServ();
            cadastroProdServ.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ListaProdServ lista = new ListaProdServ();
            lista.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            AgendaFesta agenda = new AgendaFesta();
            agenda.Show();
        }
    }
}
