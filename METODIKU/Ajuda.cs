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
    public partial class Ajuda : Form
    {
        public Ajuda()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(AutenticacaoCliente.pegarTipo() == 2)
            {
                this.Hide();
                MenuCliente menuCliente = new MenuCliente();
                menuCliente.Show();
            }
            else
            {
                this.Hide();
                MenuFornecedor menuFornecedor = new MenuFornecedor();
                menuFornecedor.Show();
            }
        }

        private void Ajuda_Load(object sender, EventArgs e)
        {
            textBox1.Multiline = true;
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox1.AcceptsReturn = true;
            textBox1.AcceptsTab = true;
            textBox1.WordWrap = true;

            textBox1.Text = "\t\t\t\t\t\tAJUDA (CLIENTE)\r\n";
            textBox1.Text += "\r\n\r\n";
            textBox1.Text += "\t1. Como realizar cadastro?\r\n";
            textBox1.Text += "\tO usuário pode realizar um dos dois tipos de cadastro:\r\n";
            textBox1.Text += "\t\tA) Usuário comum:\r\n";
            textBox1.Text += "\t\t\ti. Para realizar o cadastro, é necessário que o usuário informe o CPF, nome, como o usuário deseja ser chamado, endereço, telefone, email, senha e repetir a senha informada. \r\n";
            textBox1.Text += "\t\tB) Fornecedor de produtos/prestador de serviços:\r\n";
            textBox1.Text += "\t\t\ti. Para realizar o cadastro, é necessário que o usuário informe CNPJ, razão social, como o usuário deseja ser chamado, endereço, telefone, email, senha e repetir a senha informada.\r\n\r\n";
            textBox1.Text += "\t2. Como recuperar a senha?\r\n";
            textBox1.Text += "\t\tA) Para recuperar a senha o usuário precisa informar o CPF ou CNPJ  e o nome de usuário.\r\n\r\n";
            textBox1.Text += "\t3. Como excluir cadastro no sistema?\r\n";
            textBox1.Text += "\t\tA) Em minha conta, clique no ícone de avatar com o x vermelho para realizar a exclusão, uma mensagem de confirmação irá aparecer e, em seguida o usuário deve confirmar.\r\n\r\n";
            textBox1.Text += "\t4. Como cadastrar uma festa no sistema?\r\n";
            textBox1.Text += "\tNo menu principal, o usuário deve clicar no botão organizar festa:\r\n";
            textBox1.Text += "\t\tA) Se o usuário tem o local da festa definido:\r\n";
            textBox1.Text += "\t\t\ti. E, em seguida informar o nome da festa, data, local e número de convidados.\r\n";
            textBox1.Text += "\t\tB) Se o usuário não tem o local da festa definido:\r\n";
            textBox1.Text += "\t\t\ti. E, em seguida o nome da festa, data, número de convidados e informar a cidade para encontrar um local de festa.\r\n\r\n";
            textBox1.Text += "\t5. Como adicionar comidas à uma lista?\r\n";
            textBox1.Text += "\t\tA) Para o usuário adicionar comidas à uma festa é necessário selecionar: o grupo de comida, tipo de comida, escolher uma das opções disponíveis e em seguida clicar em adicionar e automaticamente o sistema fará o cálculo baseando-se na lista de convidados.\r\n\r\n";
            textBox1.Text += "\t6. Como adicionar bebidas à uma festa?\r\n";
            textBox1.Text += "\t\tA) Para o usuário adicionar bebidas à uma festa é necessário selecionar: o grupo de bebida , tipo de bebida, escolher uma das opções disponíveis  e em seguida clicar em adicionar e automaticamente o sistema fará o cálculo baseando-se na lista de convidados.\r\n\r\n";
            textBox1.Text += "\t7. Como adicionar utensílios à uma festa?\r\n";
            textBox1.Text += "\t\tA) Para o usuário adicionar utensílios à uma festa é necessário selecionar: o grupo de utensílio, tipo de utensílio, escolher uma das opções disponíveis  e em seguida clicar em adicionar e automaticamente o sistema fará o cálculo baseando-se na lista de convidados.\r\n\r\n";
            textBox1.Text += "\t8. Como fazer o cálculo de uma festa?\r\n";
            textBox1.Text += "\tA) Organizar Festa:\r\n";
            textBox1.Text += "\t\ti. Selecionando a comida, bebida ou utensílio no cadastro de sua festa, automaticamente o sistema fará o cálculo baseando-se na lista de convidados.\r\n";
            textBox1.Text += "\tB) Calculadora Básica:\r\n";
            textBox1.Text += "\t\ti. Selecionando a comida, bebida ou utensílio,  automaticamente o sistema fará o cálculo baseando-se na lista de convidados.\r\n";
            textBox1.Text += "\t9. Como adicionar ou remover um convidado à lista?\r\n";
            textBox1.Text += "\tNo menu principal o usuário deve selecionar a opção de lista de convidados:\r\n";
            textBox1.Text += "\t\tA) Adicionando:\r\n";
            textBox1.Text += "\t\t\ti. E, em seguida informar o nome, a idade e sexo do convidado e clicar no botão adicionar.\r\n";
            textBox1.Text += "\t\tB) Removendo:\r\n";
            textBox1.Text += "\t\t\ti. E, em seguida selecionar o convidado e clicar no botão remover.\r\n\r\n";
            textBox1.Text += "\t10. Como inserir o meu feedback, sugestão ou crítica ao sistema?\r\n";
            textBox1.Text += "\t\tA) No menu principal, o usuário deve clicar em minha e conta, depois em opinião e, em seguida deixar a classificação para o software e a mensagem.\r\n\r\n";

            textBox1.SelectionStart = 0;
        }
    }
}
