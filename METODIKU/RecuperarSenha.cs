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
    public partial class RecuperarSenha : Form
    {
        public RecuperarSenha()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") label1.Visible = true;
            if (textBox2.Text == "") label2.Visible = true;
            else if (label1.Visible == false && label2.Visible == false){
                BD_USUARIO recuperarSenha = new BD_USUARIO();
                String senha = recuperarSenha.recuperarSenha(textBox2.Text, textBox1.Text);
                if (senha != null)
                    label3.Text = senha;
                else
                    MessageBox.Show("Não há usuário com esses dados", "Erro!", MessageBoxButtons.OK);
            }
        }
    }
}
