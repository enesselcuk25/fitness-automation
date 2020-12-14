using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace spor_salonu_projesi
{
    public partial class yöneticigiris : Form
    {
        public yöneticigiris()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database0.mdb");
        public static string kullanıcıadi, adı, soyadi;
        private void yöneticigiris_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 sayfa = new Form1();
            sayfa.Show();
            this.Hide();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                textBox1.Text = "Kullanıcı Adı";
            }
            
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Şifre";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            bool durum = false;

            try
            {
                baglan.Open();
                string sorgu = "select * from giris";
                OleDbCommand komut = new OleDbCommand(sorgu, baglan);


                OleDbDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    if(oku["kullaniciadi"].ToString() == textBox1.Text && oku["sifre"].ToString()== textBox2.Text)
                    {
                        durum = true;

                        kullanıcıadi = oku.GetValue(0).ToString();
                        adı = oku.GetValue(1).ToString();
                        soyadi = oku.GetValue(2).ToString();

                        yöneticianamenu anamenu = new yöneticianamenu();
                        anamenu.ShowDialog();
                        this.Hide();
                        break;
                    }

                }
                baglan.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message, "bir yerlerde yanlış bilgi girdiniz", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                baglan.Close();
            }
            if(textBox1.Text == "Kullanıcı Adı" && textBox2.Text == "Şifre")
            {
                MessageBox.Show("kullanıcı adı ve parola boş geçilemez", "selçuk spor salonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(textBox1.Text == "Kullanıcı Adı" && textBox2.Text != "")
            {
                MessageBox.Show("kullanıcı adı boş  geçilemez", "selçuk spor salonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox1.Text != "" && textBox2.Text == "Şifre")
            {
                MessageBox.Show("parola boş  geçilemez", "selçuk spor salonu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
