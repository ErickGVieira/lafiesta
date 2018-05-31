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
        BD_ITENS itens = new BD_ITENS();
        BD_FESTA festa = new BD_FESTA();
        BD_CONVIDADOS convidados = new BD_CONVIDADOS();

        public Comida()
        {
            InitializeComponent();
        }

        private void Comida_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = itens.grupoComidas();
            comboBox1.DisplayMember = "nome";
            comboBox1.ValueMember = "id";
            comboBox1.Text = "";
            comboBox2.DataSource = null;

            dataGridView1.DataSource = itens.comidas(festa.pegarFesta(AutenticacaoCliente.pegarId()));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            double total = 0;
            String grandeza = null;

            int verifica = itens.verificaComida(festa.pegarFesta(AutenticacaoCliente.pegarId()), comboBox2.Text);
            if(comboBox1.Text == "CHURRASCO" && (comboBox2.SelectedIndex >= 0 && comboBox2.SelectedIndex <= 4))
            {
                //Calculo CARNES HOMENS
                long quantidade = itens.quantidadeCarne() + 1;
                quantidade = 600 / quantidade;
                quantidade *= convidados.TotalHomens();
                total = int.Parse(quantidade.ToString());

                //Calculo CARNES MULHERES
                quantidade = itens.quantidadeCarne() + 1;
                quantidade = 400 / quantidade;
                quantidade *= convidados.TotalMulheres();
                total += int.Parse(quantidade.ToString());

                //Calculo CARNES CRIANÇAS
                quantidade = itens.quantidadeCarne() + 1;
                quantidade = 200 / quantidade;
                quantidade *= convidados.TotalMulheres();
                total += int.Parse(quantidade.ToString());

                itens.AtualizarCarnes(total.ToString());
                grandeza = "g";
            }else if(comboBox1.Text == "CHURRASCO" && comboBox2.SelectedIndex == 5) //QUEIJO COALHO
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) / 5.0;
                grandeza = " pct";
            }
            else if (comboBox1.Text == "CHURRASCO" && comboBox2.SelectedIndex == 6) //PÃO DE ALHO
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) / 10.0;
                grandeza = " pct";
            }
            else if (comboBox1.Text == "CHURRASCO" && comboBox2.SelectedIndex == 7) // MAIONESE
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) / 10.0;
                total *= 500;
                grandeza = "g";
            }
            else if (comboBox1.Text == "CHURRASCO" && comboBox2.SelectedIndex == 8) //ARROZ
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) / 6.0;
                grandeza ="kg";
            }
            else if (comboBox1.Text == "CHURRASCO" && comboBox2.SelectedIndex == 11) //FAROFA
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) / 10.0;
                grandeza = " pct";
            }
            else if (comboBox1.Text == "CHURRASCO" && comboBox2.SelectedIndex == 12) //PÃO FRANCÊS
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) * 2;
                grandeza = " unidade(s)";
            }
            else if (comboBox1.Text == "CHURRASCO" && (comboBox2.SelectedIndex == 9 || comboBox2.SelectedIndex == 10)) //SALADA
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) * 150;
                grandeza = "g";
            }

            if (comboBox1.Text == "FINGER FOODS" && (comboBox2.SelectedIndex >= 0 && comboBox2.SelectedIndex <= 10)){ // SALGADINHOS
                if (int.Parse(itens.totalComidas().ToString()) == 0)
                {
                    total = int.Parse(convidados.TotalConvidados().ToString()) * 15;
                }
                else
                {
                    total = (int.Parse(convidados.TotalConvidados().ToString()) * 8) / (int) itens.totalComidas();
                    itens.AtualizarSalgadinhos(total.ToString());
                }
                grandeza = " unidade(s)";
            }
            else if (comboBox1.Text == "FINGER FOODS" && (comboBox2.SelectedIndex >= 11 && comboBox2.SelectedIndex <= 13)){ //PASTEL
                if (int.Parse(itens.totalComidas().ToString()) == 0)
                {
                    total = int.Parse(convidados.TotalConvidados().ToString()) * 10;
                }
                else
                {
                    total = (int.Parse(convidados.TotalConvidados().ToString()) * 2) / (int)itens.totalComidas();
                    itens.AtualizarPasteis(total.ToString());
                }
                grandeza = " unidade(s)";
            }

            if (comboBox1.Text == "DOCE" && (comboBox2.SelectedIndex >= 0 && comboBox2.SelectedIndex <= 6))
            {
                    total = (int.Parse(convidados.TotalConvidados().ToString()) * 6);
                grandeza = " unidade(s)";
            }
            else if (comboBox1.Text == "DOCE" && comboBox2.SelectedIndex == 7) // BOLO FESTA
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) * 150);
                grandeza = "g";
            }
            else if (comboBox1.Text == "DOCE" && comboBox2.SelectedIndex == 8) // BOLO SIMPLES
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) * 200);
                grandeza = "g";
            }

            if (comboBox1.Text == "FRIOS" && comboBox2.SelectedIndex == 0) //MUSSARELA
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) * 75);
                grandeza = "g";
            }
            else if (comboBox1.Text == "FRIOS" && comboBox2.SelectedIndex == 1) // PRESUNTO
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) * 50);
                grandeza = "g";
            }
            else if (comboBox1.Text == "FRIOS" && (comboBox2.SelectedIndex >= 2 && comboBox2.SelectedIndex <= 4)) //SALAME, MORTADELA, COPA
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) * 25);
                grandeza = "g";
            }

            if (comboBox1.Text == "COFFEE BREAK" && comboBox2.SelectedIndex == 0) //PÃO
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) * 3);
                grandeza = " unidade(s)";
            }
            else if (comboBox1.Text == "COFFEE BREAK" && comboBox2.SelectedIndex == 1) //TORRADA
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) * 2);
                grandeza = " unidade(s)";
            }
            else if (comboBox1.Text == "COFFEE BREAK" && comboBox2.SelectedIndex == 2) //BOLACHA RECHEADA
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) / 5.0);
                grandeza = " pct";
            }
            else if (comboBox1.Text == "COFFEE BREAK" && comboBox2.SelectedIndex == 3) //BISCOITO
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) * 150);
                grandeza = "g";
            }
            else if (comboBox1.Text == "COFFEE BREAK" && comboBox2.SelectedIndex == 4) //PÃO DE QUEIJO
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) * 5);
                grandeza = " unidade(s)";
            }
            else if (comboBox1.Text == "COFFEE BREAK" && comboBox2.SelectedIndex == 5) // REQUEIJÃO
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) / 8.0);
                grandeza = " pote";
            }
            else if (comboBox1.Text == "COFFEE BREAK" && comboBox2.SelectedIndex == 6) // CREPIOCA
            {
                total = int.Parse(convidados.TotalConvidados().ToString());
                grandeza = " unidade(s)";
            }

            if (comboBox1.Text == "VEGETARIANA" && comboBox2.SelectedIndex == 0) //TORTA DE LEGUMES
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) / 6.0);
                grandeza = "kg";
            }
            else if (comboBox1.Text == "VEGETARIANA" && (comboBox2.SelectedIndex == 0 || comboBox2.SelectedIndex == 1)) //SALGADO, PÃO DE QUEIJO
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) / 5.0);
                grandeza = " unidade(s)";
            }
            else if (comboBox1.Text == "VEGETARIANA" && comboBox2.SelectedIndex == 3) //SALADA
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) * 150;
                grandeza = "g";
            }

            if (comboBox1.Text == "BOTECO" && (comboBox2.SelectedIndex == 0 || comboBox2.SelectedIndex == 1)) //POLENTA, MANDIOCA
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) / 6.0;
                grandeza = "kg";
            }
            else if (comboBox1.Text == "BOTECO" && comboBox2.SelectedIndex == 0) //AMENDOIM
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) * 100;
                grandeza = "g";
            }
            else if (comboBox1.Text == "BOTECO" && comboBox2.SelectedIndex == 0) //TORRESMO
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) / 8.0;
                grandeza = "kg";
            }

            total = Math.Ceiling(total);
            if (verifica == 0)
            {
                bool sucesso = itens.CadastraComida(comboBox1.Text, comboBox2.Text, total.ToString() + grandeza);
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
            int total = 0;
            int idFesta = festa.pegarFesta(AutenticacaoCliente.pegarId());
            int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            bool sucesso = itens.RemoverComida(id, idFesta);

            String grupo = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            if(grupo == "CHURRASCO")
            {
                //Calculo CARNES HOMENS
                long quantidade = itens.quantidadeCarne();
                quantidade = 600 / quantidade;
                quantidade *= convidados.TotalHomens();
                total = int.Parse(quantidade.ToString());

                //Calculo CARNES MULHERES
                quantidade = itens.quantidadeCarne();
                quantidade = 400 / quantidade;
                quantidade *= convidados.TotalMulheres();
                total += int.Parse(quantidade.ToString());

                //Calculo CARNES CRIANÇAS
                quantidade = itens.quantidadeCarne();
                quantidade = 200 / quantidade;
                quantidade *= convidados.TotalMulheres();
                total += int.Parse(quantidade.ToString());

                itens.AtualizarCarnes(total.ToString());
            }
            
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
