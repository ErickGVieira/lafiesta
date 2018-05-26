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
    public partial class Utensilio : Form
    {
        BD_ITENS itens = new BD_ITENS();
        BD_FESTA festa = new BD_FESTA();
        BD_CONVIDADOS convidados = new BD_CONVIDADOS();

        public Utensilio()
        {
            InitializeComponent();
        }

        private void Utensilio_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = itens.grupoUtensilio();
            comboBox1.DisplayMember = "nome";
            comboBox1.ValueMember = "id";
            comboBox1.Text = "";
            comboBox2.DataSource = null;

            dataGridView1.DataSource = itens.utensilios(festa.pegarFesta(AutenticacaoCliente.pegarId()));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 9;
            if (index != comboBox1.SelectedIndex)
            {
                index = comboBox1.SelectedIndex;
                comboBox2.DataSource = itens.tiposUtensilio(index + 1);
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

            int verifica = itens.verificaUtensilio(festa.pegarFesta(AutenticacaoCliente.pegarId()), comboBox2.Text);

            if(comboBox1.Text == "COPOS" && (comboBox2.SelectedIndex >= 0 && comboBox2.SelectedIndex <= 4))
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) * 5;
                grandeza = " unidade(s)";
            }
            else if(comboBox1.Text == "COPOS" && (comboBox2.SelectedIndex >= 5 && comboBox2.SelectedIndex <= 9))
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) * 5;
                grandeza = " unidade(s)";
            }

            if (comboBox1.Text == "GARFOS" || comboBox1.Text == "FACAS" || comboBox1.Text == "COLHERES" || comboBox1.Text == "PRATOS")
            {
                total = int.Parse(convidados.TotalConvidados().ToString());
                total += (total / 100) * 0.2;
                grandeza = " unidade(s)";
            }

            if (comboBox1.Text == "PAPEL")
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) * 8;
                grandeza = " unidade(s)";
            }

            if (comboBox1.Text == "PALITOS" && comboBox2.SelectedIndex == 0) //PALITO DE DENTE
            {
                total = int.Parse(convidados.TotalConvidados().ToString());
                grandeza = " unidade(s)";
            }
            else if (comboBox1.Text == "PALITOS" && comboBox2.SelectedIndex == 1) //PALITO DE CHURRASCO
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) / 3.0;
                grandeza = " unidade(s)";
            }

            if(comboBox1.Text == "PRATOS" && comboBox2.SelectedIndex == 2)
            {
                total = int.Parse(convidados.TotalConvidados().ToString());
                grandeza = " unidade(s)";
            }

            if(comboBox1.Text == "CADEIRAS")
            {
                total = int.Parse(convidados.TotalConvidados().ToString());
                grandeza = " unidade(s)";
            }

            if(comboBox1.Text == "MESAS")
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) / 4.0;
                grandeza = " unidade(s)";
            }

            total = Math.Ceiling(total);
            if (verifica == 0)
            {
                bool sucesso = itens.CadastrarUtensilio(comboBox1.Text, comboBox2.Text, total.ToString() + grandeza);
                if (sucesso)
                    dataGridView1.DataSource = itens.utensilios(festa.pegarFesta(AutenticacaoCliente.pegarId()));
                else if (!sucesso)
                    MessageBox.Show("ERRO!!", "Convidado não foi cadastrado!", MessageBoxButtons.OK);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int idFesta = festa.pegarFesta(AutenticacaoCliente.pegarId());
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            bool sucesso = itens.RemoverUtensilio(id, idFesta);
            if (sucesso)
                dataGridView1.DataSource = itens.utensilios(idFesta);
            else if (!sucesso)
                MessageBox.Show("ERRO!!", "Convidado não foi cadastrado!", MessageBoxButtons.OK);
        }
    }
}
