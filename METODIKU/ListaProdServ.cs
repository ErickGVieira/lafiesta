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
    public partial class ListaProdServ : Form
    {
        BD_FESTA festa = new BD_FESTA();

        public ListaProdServ()
        {
            InitializeComponent();
            dataGridView1.DataSource = festa.PegarProdServ();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            MenuFornecedor menu = new MenuFornecedor();
            menu.Show();
        }
    }
}
