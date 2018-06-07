using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace METODIKU
{
    public partial class CadastroProdServ : Form
    {
        BD_ITENS itens = new BD_ITENS();

        public CadastroProdServ()
        {
            InitializeComponent();
        }

        private void CadastroProdServ_Load(object sender, EventArgs e)
        {
            textBox1.Multiline = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.AcceptsReturn = true;
            textBox1.AcceptsTab = true;
            textBox1.WordWrap = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuFornecedor menuFornecedor = new MenuFornecedor();
            menuFornecedor.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.DataSource = itens.tiposProdutos(comboBox1.SelectedIndex + 1);
            comboBox2.DisplayMember = "nome";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String reformatado = RemoveAccents(textBox1.Text);
            bool sucesso = itens.CadastraProduto(comboBox2.Text, reformatado, textBox2.Text.ToUpper());
            if (sucesso)
                MessageBox.Show("Sucesso!!", "Cadastrado com sucesso!", MessageBoxButtons.OK);
            else if (!sucesso)
                MessageBox.Show("ERRO!!", "Erro ao cadastrar!", MessageBoxButtons.OK);

            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox2.Text = "";
        }

        public string RemoveAccents(string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }
    }
}
