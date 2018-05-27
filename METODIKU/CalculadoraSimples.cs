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
    public partial class CalculadoraSimples : Form
    {
        BD_ITENS itens = new BD_ITENS();
        BD_CONVIDADOS convidados = new BD_CONVIDADOS();

        public CalculadoraSimples()
        {
            InitializeComponent();
        }

        private void CalculadoraSimples_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = itens.grupoComidas();
            comboBox1.DisplayMember = "nome";
            comboBox1.ValueMember = "id";
            comboBox1.Text = "";

            comboBox2.DataSource = itens.grupoBebidas();
            comboBox2.DisplayMember = "nome";
            comboBox2.ValueMember = "id";
            comboBox2.Text = "";

            comboBox3.DataSource = itens.grupoUtensilio();
            comboBox3.DisplayMember = "nome";
            comboBox3.ValueMember = "id";
            comboBox3.Text = "";

            comboBox6.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuCliente menuCliente = new MenuCliente();
            menuCliente.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 9;
            if (index != comboBox1.SelectedIndex)
            {
                index = comboBox1.SelectedIndex;
                comboBox4.DataSource = itens.tiposComida(index + 1);
                comboBox4.DisplayMember = "nome";
                comboBox4.ValueMember = "id";
                comboBox4.Text = "";

                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Enabled = true;
                comboBox5.Enabled = false;
                comboBox5.Text = "";
                comboBox6.Enabled = false;
                comboBox6.Text = "";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 9;
            if (index != comboBox2.SelectedIndex)
            {
                index = comboBox2.SelectedIndex;
                comboBox5.DataSource = itens.tiposBebida(index + 1);
                comboBox5.DisplayMember = "nome";
                comboBox5.ValueMember = "id";
                comboBox5.Text = "";

                comboBox1.Text = "";
                comboBox3.Text = "";
                comboBox5.Enabled = true;
                comboBox4.Enabled = false;
                comboBox4.Text = "";
                comboBox6.Enabled = false;
                comboBox6.Text = "";
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 9;
            if (index != comboBox3.SelectedIndex)
            {
                index = comboBox3.SelectedIndex;
                comboBox6.DataSource = itens.tiposUtensilio(index + 1);
                comboBox6.DisplayMember = "nome";
                comboBox6.ValueMember = "id";
                comboBox6.Text = "";

                comboBox2.Text = "";
                comboBox1.Text = "";
                comboBox6.Enabled = true;
                comboBox5.Enabled = false;
                comboBox5.Text = "";
                comboBox4.Enabled = false;
                comboBox4.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double total = 0;
            String grandeza = null;

            if (comboBox1.Text == "CHURRASCO" && (comboBox4.SelectedIndex >= 0 && comboBox4.SelectedIndex <= 4))
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
            }
            else if (comboBox1.Text == "CHURRASCO" && comboBox4.SelectedIndex == 5) //QUEIJO COALHO
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) / 5.0;
                grandeza = " pct";
            }
            else if (comboBox1.Text == "CHURRASCO" && comboBox4.SelectedIndex == 6) //PÃO DE ALHO
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) / 10.0;
                grandeza = " pct";
            }
            else if (comboBox1.Text == "CHURRASCO" && comboBox4.SelectedIndex == 7) // MAIONESE
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) / 10.0;
                total *= 500;
                grandeza = "g";
            }
            else if (comboBox1.Text == "CHURRASCO" && comboBox4.SelectedIndex == 8) //ARROZ
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) / 6.0;
                grandeza = "kg";
            }
            else if (comboBox1.Text == "CHURRASCO" && comboBox4.SelectedIndex == 9) //FAROFA
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) / 10.0;
                grandeza = " pct";
            }
            else if (comboBox1.Text == "CHURRASCO" && comboBox4.SelectedIndex == 10) //PÃO FRANCÊS
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) * 2;
                grandeza = " unidade(s)";
            }
            else if (comboBox1.Text == "CHURRASCO" && (comboBox4.SelectedIndex == 11 || comboBox4.SelectedIndex == 12)) //SALADA
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) * 150;
                grandeza = "g";
            }

            if (comboBox1.Text == "FINGER FOODS" && (comboBox4.SelectedIndex >= 0 && comboBox4.SelectedIndex <= 10))
            { // SALGADINHOS
                total = int.Parse(convidados.TotalConvidados().ToString()) * 15;
                grandeza = " unidade(s)";
            }
            else if (comboBox1.Text == "FINGER FOODS" && (comboBox4.SelectedIndex >= 11 && comboBox4.SelectedIndex <= 13))
            { //PASTEL
                total = int.Parse(convidados.TotalConvidados().ToString()) * 10;
                grandeza = " unidade(s)";
            }

            if (comboBox1.Text == "DOCE" && (comboBox4.SelectedIndex >= 0 && comboBox4.SelectedIndex <= 6))
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) * 6);
                grandeza = " unidade(s)";
            }
            else if (comboBox1.Text == "DOCE" && comboBox4.SelectedIndex == 7) // BOLO FESTA
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) * 150);
                grandeza = "g";
            }
            else if (comboBox1.Text == "DOCE" && comboBox4.SelectedIndex == 8) // BOLO SIMPLES
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) * 200);
                grandeza = "g";
            }

            if (comboBox1.Text == "FRIOS" && comboBox4.SelectedIndex == 0) //MUSSARELA
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) * 75);
                grandeza = "g";
            }
            else if (comboBox1.Text == "FRIOS" && comboBox4.SelectedIndex == 1) // PRESUNTO
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) * 50);
                grandeza = "g";
            }
            else if (comboBox1.Text == "FRIOS" && (comboBox4.SelectedIndex >= 2 && comboBox4.SelectedIndex <= 4)) //SALAME, MORTADELA, COPA
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) * 25);
                grandeza = "g";
            }

            if (comboBox1.Text == "COFFEE BREAK" && comboBox4.SelectedIndex == 0) //PÃO
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) * 3);
                grandeza = " unidade(s)";
            }
            else if (comboBox1.Text == "COFFEE BREAK" && comboBox4.SelectedIndex == 1) //TORRADA
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) * 2);
                grandeza = " unidade(s)";
            }
            else if (comboBox1.Text == "COFFEE BREAK" && comboBox4.SelectedIndex == 2) //BOLACHA RECHEADA
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) / 5.0);
                grandeza = " pct";
            }
            else if (comboBox1.Text == "COFFEE BREAK" && comboBox4.SelectedIndex == 3) //BISCOITO
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) * 150);
                grandeza = "g";
            }
            else if (comboBox1.Text == "COFFEE BREAK" && comboBox4.SelectedIndex == 4) //PÃO DE QUEIJO
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) * 5);
                grandeza = " unidade(s)";
            }
            else if (comboBox1.Text == "COFFEE BREAK" && comboBox4.SelectedIndex == 5) // REQUEIJÃO
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) / 8.0);
                grandeza = " pote";
            }
            else if (comboBox1.Text == "COFFEE BREAK" && comboBox4.SelectedIndex == 6) // CREPIOCA
            {
                total = int.Parse(convidados.TotalConvidados().ToString());
                grandeza = " unidade(s)";
            }

            if (comboBox1.Text == "VEGETARIANA" && comboBox4.SelectedIndex == 0) //TORTA DE LEGUMES
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) / 6.0);
                grandeza = "kg";
            }
            else if (comboBox1.Text == "VEGETARIANA" && (comboBox4.SelectedIndex == 0 || comboBox4.SelectedIndex == 1)) //SALGADO, PÃO DE QUEIJO
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) / 5.0);
                grandeza = " unidade(s)";
            }
            else if (comboBox1.Text == "VEGETARIANA" && comboBox4.SelectedIndex == 3) //SALADA
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) * 150;
                grandeza = "g";
            }

            if (comboBox1.Text == "BOTECO" && (comboBox4.SelectedIndex == 0 || comboBox4.SelectedIndex == 1)) //POLENTA, MANDIOCA
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) / 6.0;
                grandeza = "kg";
            }
            else if (comboBox1.Text == "BOTECO" && comboBox4.SelectedIndex == 0) //AMENDOIM
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) * 100;
                grandeza = "g";
            }
            else if (comboBox1.Text == "BOTECO" && comboBox4.SelectedIndex == 0) //TORRESMO
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) / 8.0;
                grandeza = "kg";
            }


            //BEBIDAS
            if (comboBox2.Text == "ALCOOLICAS" && comboBox5.SelectedIndex == 0)
            {
                total = int.Parse(convidados.TotalHomens().ToString()) * 1000;
                grandeza = "ml";
            }
            else if (comboBox2.Text == "ALCOOLICAS" && (comboBox5.SelectedIndex == 1 || comboBox5.SelectedIndex == 2))
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) / 20.0;
                total *= 1000;
                grandeza = "ml";
            }

            if (comboBox2.Text == "REFRIGERANTES")
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) * 500;
                grandeza = "ml";
            }

            if (comboBox2.Text == "SUCOS")
            {
                total = (int.Parse(convidados.TotalConvidados().ToString()) - int.Parse(convidados.TotalCriancas().ToString())) * 500;
                total += int.Parse(convidados.TotalCriancas().ToString()) * 300;
                grandeza = "ml";
            }

            if (comboBox2.Text == "ÁGUAS" && comboBox5.SelectedIndex == 0)
            {
                total = int.Parse(convidados.TotalCriancas().ToString()) * 100;
                grandeza = "ml";
            }
            else if (comboBox2.Text == "ÁGUAS" && comboBox5.SelectedIndex == 0)
            {
                total = int.Parse(convidados.TotalCriancas().ToString()) * 300;
                grandeza = "ml";
            }

            if (comboBox2.Text == "COFFEE BREAK" && (comboBox5.SelectedIndex == 0 || comboBox5.SelectedIndex == 2))
            {
                total = int.Parse(convidados.TotalCriancas().ToString()) * 200;
                grandeza = "ml";
            }
            else if (comboBox2.Text == "COFFEE BREAK" && (comboBox5.SelectedIndex == 1 || comboBox5.SelectedIndex == 3))
            {
                total = int.Parse(convidados.TotalCriancas().ToString()) * 100;
                grandeza = "ml";
            }



            //UTENSILIOS
            if (comboBox3.Text == "COPOS" && (comboBox6.SelectedIndex >= 0 && comboBox6.SelectedIndex <= 4))
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) * 5;
                grandeza = " unidade(s)";
            }
            else if (comboBox3.Text == "COPOS" && (comboBox6.SelectedIndex >= 5 && comboBox6.SelectedIndex <= 9))
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) * 5;
                grandeza = " unidade(s)";
            }

            if (comboBox3.Text == "GARFOS" || comboBox3.Text == "FACAS" || comboBox3.Text == "COLHERES" || comboBox3.Text == "PRATOS")
            {
                total = int.Parse(convidados.TotalConvidados().ToString());
                total += (total / 100) * 0.2;
                grandeza = " unidade(s)";
            }

            if (comboBox3.Text == "PAPEL")
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) * 8;
                grandeza = " unidade(s)";
            }

            if (comboBox3.Text == "PALITOS" && comboBox6.SelectedIndex == 0) //PALITO DE DENTE
            {
                total = int.Parse(convidados.TotalConvidados().ToString());
                grandeza = " unidade(s)";
            }
            else if (comboBox3.Text == "PALITOS" && comboBox6.SelectedIndex == 1) //PALITO DE CHURRASCO
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) / 3.0;
                grandeza = " unidade(s)";
            }

            if (comboBox3.Text == "PRATOS" && comboBox6.SelectedIndex == 2)
            {
                total = int.Parse(convidados.TotalConvidados().ToString());
                grandeza = " unidade(s)";
            }

            if (comboBox3.Text == "CADEIRAS")
            {
                total = int.Parse(convidados.TotalConvidados().ToString());
                grandeza = " unidade(s)";
            }

            if (comboBox3.Text == "MESAS")
            {
                total = int.Parse(convidados.TotalConvidados().ToString()) / 4.0;
                grandeza = " unidade(s)";
            }

            total = Math.Ceiling(total);
            label1.Visible = true;
            label1.Text = total.ToString() + grandeza;
        }
    }
}
