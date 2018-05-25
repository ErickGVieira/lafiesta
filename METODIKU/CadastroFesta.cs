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
    public partial class CadastroFesta : Form
    {
        public CadastroFesta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuCliente menuCliente = new MenuCliente();
            menuCliente.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BD_FESTA festa = new BD_FESTA();

            if (Festa.pegarId() == 0)
            {
                Festa.CadastrarFesta(textBox2.Text, int.Parse(label1.Text), dateTimePicker1.Text, textBox1.Text);
                bool sucesso = festa.CadastrarFesta();
                Festa.setarId(festa.pegarFesta(AutenticacaoCliente.pegarId()));
                if (sucesso)
                {
                    this.Hide();
                    Comida comida = new Comida();
                    comida.Show();
                }
                else if (!sucesso)
                    MessageBox.Show("ERRO!!", "Convidado não foi cadastrado!", MessageBoxButtons.OK);
            }else if(Festa.pegarId() != 0)
            {
                Festa.setarId(festa.pegarFesta(AutenticacaoCliente.pegarId()));
                Festa.CadastrarFesta(textBox2.Text, int.Parse(label1.Text), dateTimePicker1.Text, textBox1.Text);
                bool sucesso = festa.AtualizarFesta();
                if (sucesso)
                {
                    this.Hide();
                    Comida comida = new Comida();
                    comida.Show();
                }
                else if (!sucesso)
                    MessageBox.Show("ERRO!!", "Convidado não foi cadastrado!", MessageBoxButtons.OK);
            }
          
        }

        private void CadastroFesta_Load(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Today.AddDays(-1);
            BD_CONVIDADOS convidados = new BD_CONVIDADOS();
            label1.Text = convidados.TotalConvidados().ToString();
            textBox1.Text = Festa.pegarNome();
            dateTimePicker1.Text = Festa.pegarData();
            textBox2.Text = Festa.pegarLocal();
        }
    }
}
