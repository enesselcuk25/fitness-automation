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
    public partial class Giriş_sayfası : Form
    {
        public Giriş_sayfası()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database0.mdb");


        void listele()
        {
            this.Text = "selçuk spor salonu";
            this.AcceptButton = button2;

            lblhak.Text = Convert.ToString(hak);


           

        }
        public  static string kullanıcıadı,adi,soyad,resim,sifre,adres,telefonno,kayıt,eposta;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            listele();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Form1 sayfa = new Form1();
            sayfa.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void Giriş_sayfası_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
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
            if(textBox2.Text == "")
            {
                textBox2.Text = "Şifre";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            şifrehatırlam sifre = new şifrehatırlam();
            sifre.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            kayıt_sayfası kayıt = new kayıt_sayfası();
            kayıt.Show();
            this.Hide();
            
        }

        int hak = 3;
        bool durum = false;
        private void button2_Click_1(object sender, EventArgs e)
        {

            
            if (hak != 0)
            {
              
                baglan.Open();

                string sorgu = "select * from kullanıcıkayıt ";
                OleDbCommand komut = new OleDbCommand(sorgu, baglan);
                OleDbDataReader oku = komut.ExecuteReader();

              while (oku.Read())
              {
                   if (oku.GetValue(4).ToString() == textBox1.Text && oku.GetValue(3).ToString() == textBox2.Text )
                   {

                         durum = true;
                         kullanıcıadı = oku.GetValue(4).ToString();
                         adi = oku.GetValue(1).ToString();
                         soyad = oku.GetValue(2).ToString();
                         resim = oku.GetValue(8).ToString();
                         eposta = oku.GetValue(0).ToString();
                         sifre = oku.GetValue(3).ToString();
                         adres = oku.GetValue(5).ToString();
                         telefonno = oku.GetValue(6).ToString();
                         kayıt = oku.GetValue(7).ToString();

                                   
                         kullanıcıbilgileri form = new kullanıcıbilgileri();
                         form.Show();
                         this.Hide();
                         break;
                   }
              }
               if (durum == false)
               {
                    hak--;

               }
                 baglan.Close();

            }
             lblhak.Text = Convert.ToString(hak);
            if (hak == 0)
            {
                MessageBox.Show("GİRİŞ HAKKINIZ BİTMİŞTİR!! ", "SELÇUK SPOR SALONU", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Form1 bitti = new Form1();
                bitti.Show();
                this.Hide();
            }
            
          else  if (textBox1.Text == "Kullanıcı Adı" && textBox2.Text == "Şifre")
            {
                MessageBox.Show("KULLANICI ADI VE ŞİFRE BOŞ GEÇİLEMEZ", "SELÇUK SPOR SALONU", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                
            }

            else if (textBox1.Text == "Kullanıcı Adı" && textBox2.Text != "")
            {
                MessageBox.Show("KULLANICI ADI  BOŞ GEÇİLEMEZ", "SELÇUK SPOR SALONU", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (textBox1.Text != "" && textBox2.Text == "Şifre")
            {
                MessageBox.Show("ŞİFRE  BOŞ GEÇİLEMEZ", "SELÇUK SPOR SALONU", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            
        }
    }
}
