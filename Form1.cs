using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spor_salonu_projesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            kayıt_sayfası kayıt = new kayıt_sayfası();
            kayıt.Show();
            this.Hide();
        }

        private void adminGirişToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Giriş_sayfası giris = new Giriş_sayfası();
            giris.Show();
            this.Hide();
        }

        private void adminGirişiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yöneticigiris yönet = new yöneticigiris();
            yönet.Show();
            this.Hide();
        }
    }
}
