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
    public partial class ListaMensagem : Form
    {
        public ListaMensagem()
        {
            InitializeComponent();
        }

        private void ListaMensagem_Load(object sender, EventArgs e)
        {
            if(AutenticacaoCliente.pegarTipo() == 3)
            {
                button3.Visible = true;
                button7.Visible = true;
                BD_OPINIAO opiniao = new BD_OPINIAO();
                dataGridView1.DataSource = opiniao.ListaOpinioesAdministrador();
            }
            else
            {
                button2.Visible = true;
                BD_OPINIAO opiniao = new BD_OPINIAO();
                dataGridView1.DataSource = opiniao.ListaOpinioes();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mensagem mensagem = new Mensagem();
            mensagem.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MinhaConta minhaConta = new MinhaConta();
            minhaConta.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            String nome = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            String descricao = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            this.Hide();
            ResponderMensagem respMsg = new ResponderMensagem(id, nome, descricao);
            respMsg.Show();
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
    }
}
