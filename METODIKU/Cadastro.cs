﻿using System;
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
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            limpar();
        }

        public void limpar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") label1.Visible = true;
            if (textBox2.Text == "") label2.Visible = true;
            if (textBox3.Text == "") label3.Visible = true;
            if (textBox4.Text == "") label4.Visible = true;
            if (textBox5.Text == "") label5.Visible = true;
            if (textBox6.Text == "") label6.Visible = true;
            if (textBox7.Text == "") label7.Visible = true;
            if (textBox7.Text != textBox8.Text) label8.Visible = true;

            else if (label1.Visible == false && label2.Visible == false && label3.Visible == false &&
                     label4.Visible == false && label5.Visible == false && label6.Visible == false &&
                     label7.Visible == false && label8.Visible == false)
            {
                String cpf = textBox1.Text;
                String nome = textBox2.Text;
                String nomeUsuario = textBox3.Text;
                String endereco = textBox4.Text;
                String telefone = textBox5.Text;
                String email = textBox6.Text;
                String senha = textBox7.Text;

                BD_USUARIO conecta = new BD_USUARIO();
                Usuario usuario = new Usuario(cpf, nome, nomeUsuario, endereco, telefone, email, senha);
                bool sucesso = conecta.CadastrarUsuario(usuario);
                if (sucesso)
                    MessageBox.Show("Sucesso!!", "Cadastro com sucesso!", MessageBoxButtons.OK);
                else if (!sucesso)
                    MessageBox.Show("ERRO!!", "Usuário não foi cadastrado!", MessageBoxButtons.OK);
                limpar();
            }
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "") label3.Visible = true;
            else label3.Visible = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "") label4.Visible = true;
            else label4.Visible = false;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "") label5.Visible = true;
            else label5.Visible = false;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text == "") label6.Visible = true;
            else label6.Visible = false;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text == "") label7.Visible = true;
            else label7.Visible = false;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text == "") label9.Visible = true;
            else label9.Visible = false;
            if ((textBox7.Text != textBox8.Text) && textBox8.Text != "") label8.Visible = true;
            else label8.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FornecedorCliente fc = new FornecedorCliente();
            fc.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
