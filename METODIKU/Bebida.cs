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
    public partial class Bebida : Form
    {
        BD_ITENS itens = new BD_ITENS();
        BD_FESTA festa = new BD_FESTA();
        BD_CONVIDADOS convidados = new BD_CONVIDADOS();

        public Bebida()
        {
            InitializeComponent();
        }

        private void Bebida_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = itens.grupoBebidas();
            comboBox1.DisplayMember = "nome";
            comboBox1.ValueMember = "id";
            comboBox1.Text = "";
            comboBox2.DataSource = null;

            dataGridView1.DataSource = itens.bebidas(festa.pegarFesta(AutenticacaoCliente.pegarId()));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 9;
            if (index != comboBox1.SelectedIndex)
            {
                index = comboBox1.SelectedIndex;
                comboBox2.DataSource = itens.tiposBebida(index + 1);
                comboBox2.DisplayMember = "nome";
                comboBox2.ValueMember = "id";
                comboBox2.Enabled = true;

            }
            comboBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double total = 0;
            String grandeza = null;

            int verifica = itens.verificaBebida(festa.pegarFesta(AutenticacaoCliente.pegarId()), comboBox2.Text);
            if (comboBox1.Text == "ALCOOLICAS" && comboBox2.SelectedIndex == 0)
            {
                total = int.Parse(convidados.TotalHomens().ToString()) * 1000;
                grandeza = "ml";
            }else if (comboBox1.Text == "ALCOOLICAS" && (comboBox2.SelectedIndex == 1 || comboBox2.SelectedIndex == 2))
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) / 20.0;
                total *= 1000;
                grandeza = "ml";
            }

            if (comboBox1.Text == "REFRIGERANTES")
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) * 500;
                grandeza = "ml";
            }

            if (comboBox1.Text == "SUCOS")
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) - int.Parse(convidados.TotalCriancas().ToString())) * 500;
                total += int.Parse(convidados.TotalCriancas().ToString()) * 300;
                grandeza = "ml";
            }

            if(comboBox1.Text == "ÁGUAS" && comboBox2.SelectedIndex == 0)
            {
                total = int.Parse(convidados.TotalCriancas().ToString()) * 100;
                grandeza = "ml";
            }else if (comboBox1.Text == "ÁGUAS" && comboBox2.SelectedIndex == 0)
            {
                total = int.Parse(convidados.TotalCriancas().ToString()) * 300;
                grandeza = "ml";
            }

            if(comboBox1.Text == "COFFEE BREAK" && (comboBox2.SelectedIndex == 0 || comboBox2.SelectedIndex == 2))
            {
                total = int.Parse(convidados.TotalCriancas().ToString()) * 200;
                grandeza = "ml";
            }
            else if (comboBox1.Text == "COFFEE BREAK" && (comboBox2.SelectedIndex == 1 || comboBox2.SelectedIndex == 3))
            {
                total = int.Parse(convidados.TotalCriancas().ToString()) * 100;
                grandeza = "ml";
            }

            total = Math.Ceiling(total);
            if (verifica == 0)
            {
                bool sucesso = itens.CadastraBebida(comboBox2.Text, total.ToString() + grandeza);
                if (sucesso)
                    dataGridView1.DataSource = itens.bebidas(festa.pegarFesta(AutenticacaoCliente.pegarId()));
                else if (!sucesso)
                    MessageBox.Show("ERRO!!", "Convidado não foi cadastrado!", MessageBoxButtons.OK);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Comida cadastrarFesta = new Comida();
            cadastrarFesta.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int idFesta = festa.pegarFesta(AutenticacaoCliente.pegarId());
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            bool sucesso = itens.RemoverBebida(id, idFesta);
            if (sucesso)
                dataGridView1.DataSource = itens.bebidas(idFesta);
            else if (!sucesso)
                MessageBox.Show("ERRO!!", "Convidado não foi cadastrado!", MessageBoxButtons.OK);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Utensilio utensilio = new Utensilio();
            utensilio.Show();
        }
    }
}
