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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") label1.Visible = true;
            if (textBox2.Text == "") label2.Visible = true;
            else
            {
                BD_USUARIO usuario = new BD_USUARIO();
                usuario.Login(textBox1.Text, textBox2.Text);
                if(AutenticacaoCliente.pegarId() != 0)
                {
                   if (AutenticacaoCliente.pegarTipo() == 2)
                    {
                        this.Hide();
                        MenuCliente menuCliente = new MenuCliente();
                        menuCliente.Show();
                    }
                    else if (AutenticacaoCliente.pegarTipo() == 0 || AutenticacaoCliente.pegarTipo() == 1)
                    {
                        this.Hide();
                        MenuFornecedor menuFornecedor = new MenuFornecedor();
                        menuFornecedor.Show();
                    }
                    else if (AutenticacaoCliente.pegarTipo() == 3)
                    {
                        this.Hide();
                        ListaMensagem listaMensagem = new ListaMensagem();
                        listaMensagem.Show();
                    }
                }
                else if(AutenticacaoCliente.pegarId() == 0)
                {
                    MessageBox.Show("Não há usuário com esses dados", "Erro!", MessageBoxButtons.OK);
                }
                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "") label1.Visible = true;
            else label1.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "") label2.Visible = true;
            else label2.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            FornecedorCliente cadastro = new FornecedorCliente();
            cadastro.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Hide();
            RecuperarSenha recuperarSenha = new RecuperarSenha();
            recuperarSenha.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
