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
    public partial class Comida : Form
    {
        public Comida()
        {
            InitializeComponent();
        }

        private void Comida_Load(object sender, EventArgs e)
        {
            BD_ITENS itens = new BD_ITENS();
            BD_FESTA festa = new BD_FESTA();

            comboBox1.DataSource = itens.grupoComidas();
            comboBox1.DisplayMember = "nome";
            comboBox1.ValueMember = "id";
            comboBox1.Text = "";
            comboBox2.DataSource = null;

            dataGridView1.DataSource = itens.comidas(festa.pegarFesta(AutenticacaoCliente.pegarId()));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BD_ITENS itens = new BD_ITENS();
            int index = 9;
            if (index != comboBox1.SelectedIndex)
            {
                index = comboBox1.SelectedIndex;
                comboBox2.DataSource = itens.tiposComida(index + 1);
                comboBox2.DisplayMember = "nome";
                comboBox2.ValueMember = "id";
                comboBox2.Enabled = true;

            }
            comboBox2.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BD_ITENS itens = new BD_ITENS();
            BD_FESTA festa = new BD_FESTA();

            int verifica = itens.verificaComida(festa.pegarFesta(AutenticacaoCliente.pegarId()), comboBox2.Text);

            if(verifica == 0)
            {
                bool sucesso = itens.CadastraComida(comboBox2.Text);
                if (sucesso)
                    dataGridView1.DataSource = itens.comidas(festa.pegarFesta(AutenticacaoCliente.pegarId()));
                else if (!sucesso)
                    MessageBox.Show("ERRO!!", "Convidado não foi cadastrado!", MessageBoxButtons.OK);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CadastroFesta cadastrarFesta = new CadastroFesta();
            cadastrarFesta.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BD_FESTA festa = new BD_FESTA();
            BD_ITENS itens = new BD_ITENS();

            int idFesta = festa.pegarFesta(AutenticacaoCliente.pegarId());
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            bool sucesso = itens.RemoverComida(id, idFesta);
            if (sucesso)
                dataGridView1.DataSource = itens.comidas(idFesta);
            else if (!sucesso)
                MessageBox.Show("ERRO!!", "Convidado não foi cadastrado!", MessageBoxButtons.OK);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bebida bebida = new Bebida();
            bebida.Show();
        }
    }
}
