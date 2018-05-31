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
        BD_USUARIO usuario = new BD_USUARIO();

        public MinhaConta()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (AutenticacaoCliente.pegarTipo() == 0 || AutenticacaoCliente.pegarTipo() == 1)
            {
                this.Hide();
                MenuFornecedor menuFornecedor = new MenuFornecedor();
                menuFornecedor.Show();
            }
            else
            {
                this.Hide();
                MenuCliente menuCliente = new MenuCliente();
                menuCliente.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            TipoMensagem tipoMensagem = new TipoMensagem();
            tipoMensagem.Show();
        }

        private void MinhaConta_Load(object sender, EventArgs e)
        {
            BD_OPINIAO opiniao = new BD_OPINIAO();
            label1.Text = opiniao.SomaOpinioesRespondida().ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Deseja realmente excluir a sua conta?", "Atenção", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bool excluido = usuario.ExcluirUsuario();
                if (excluido)
                {
                    AutenticacaoCliente.Sair();
                    this.Hide();
                    Login login = new Login();
                    login.Show();
                }
                else
                {
                    MessageBox.Show("Erro ao excluir sua conta", "Erro!", MessageBoxButtons.OK);
                }
                    
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tipo = AutenticacaoCliente.pegarTipo();

            if(tipo == 2)
            {
                this.Hide();
                Cadastro cadastro = new Cadastro();
                cadastro.Show();
            }

            if (tipo == 1)
            {
                this.Hide();
                CadastroFornecedor cadastroFornecedor = new CadastroFornecedor();
                cadastroFornecedor.Show();
            }
        }
    }
}
