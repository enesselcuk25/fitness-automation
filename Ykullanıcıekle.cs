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
using System.Text.RegularExpressions;
using System.IO;

namespace spor_salonu_projesi
{
    public partial class Ykullanıcıekle : Form
    {
        public Ykullanıcıekle()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database0.mdb");

        void temizle()
        {
            txtadi.Text = "";
            txtsoyad.Text = "";
            txtmail.Text = "";
            txtsifre.Text = "";
            txtsifretekrar.Text = "";
            txtkadi.Text = "";
            pictureBox1.ImageLocation = "";
            txtresim.Text = "";
            dateTimePicker1.Text = "";
            txtadres.Text = "";
            maskedTextBox1.Text = "";


        }

        private void button_kayıt_Click(object sender, EventArgs e)
        {
            bool kayıtkontrol = false;

            baglan.Open();

            string sorgu0 = "select * from kullanıcıkayıt where kullaniciadi = '" + txtkadi.Text + "'";
            OleDbCommand komut0 = new OleDbCommand(sorgu0, baglan);

            OleDbDataReader oku = komut0.ExecuteReader();

            while (oku.Read())
            {
                kayıtkontrol = true;
                break;
            }
            baglan.Close();
            if (kayıtkontrol == false)
            {
                if (pictureBox1.ImageLocation == "")
                {
                    btnfoto.ForeColor = Color.Red;
                }
                else
                {
                    btnfoto.ForeColor = Color.Black;
                }


                if (txtmail.Text == "")
                {
                    lblmail.ForeColor = Color.Red;
                }
                else
                {
                    lblmail.ForeColor = Color.Black;
                }

                if (txtadi.Text.Length < 2 || txtadi.Text == "")
                {
                    lblad.ForeColor = Color.Red;
                }
                else
                {
                    lblad.ForeColor = Color.Black;
                }

                if (txtsoyad.Text.Length < 2 || txtsoyad.Text == "")
                {
                    lblsoyad.ForeColor = Color.Red;
                }
                else
                {
                    lblsoyad.ForeColor = Color.Black;
                }

                if (txtsifre.Text.Length < 2 || txtsifre.Text == "")
                {
                    lblsifre.ForeColor = Color.Red;
                }
                else
                {
                    lblsifre.ForeColor = Color.Black;
                }

                if (txtsifretekrar.Text == "" || txtsifretekrar.Text != txtsifre.Text)
                {
                    lblsifretekrar.ForeColor = Color.Red;
                }
                else
                {
                    lblsifretekrar.ForeColor = Color.Black;
                }

                if (txtadres.Text == "")
                {
                    lbladres.ForeColor = Color.Red;
                }
                else
                {
                    lbladres.ForeColor = Color.Black;
                }

                if (maskedTextBox1.MaskCompleted == false)
                {
                    lbltel.ForeColor = Color.Red;
                }
                else
                {
                    lbltel.ForeColor = Color.Black;
                }

                if (txtkadi.Text == "")
                {
                    lblkullanıcı.ForeColor = Color.Red;
                }
                else
                {
                    lblkullanıcı.ForeColor = Color.Black;
                }

                if (dateTimePicker1.Text == "")
                {
                    lbltarih.ForeColor = Color.Red;
                }
                else
                {
                    lbltarih.ForeColor = Color.Black;
                }


                if (txtadi.Text.Length > 2 && txtadi.Text != "" && txtsoyad.Text.Length > 2 && txtsoyad.Text != "" && txtsifre.Text.Length > 2 && txtsifre.Text != "" && txtsifretekrar.Text != "" && txtadres.Text != "" && maskedTextBox1.MaskCompleted != false && dateTimePicker1.Text != "" && pictureBox1.ImageLocation != "")
                {
                    try
                    {
                        baglan.Open();
                        string sorgu1 = "insert into kullanıcıkayıt (email,adi,soyadi,sifre,kullaniciadi,adres,telefonno,kayıttarihi,resim) values (@1,@2,@3,@4,@5,@6,@7,@8,@9)";
                        OleDbCommand komut1 = new OleDbCommand(sorgu1, baglan);

                        komut1.Parameters.AddWithValue("@1", txtmail.Text);
                        komut1.Parameters.AddWithValue("@2", txtadi.Text);
                        komut1.Parameters.AddWithValue("@3", txtsoyad.Text);
                        komut1.Parameters.AddWithValue("@4", txtsifre.Text);
                        //komut1.Parameters.AddWithValue("@4", txtsifretekrar.Text);
                        komut1.Parameters.AddWithValue("@5", txtkadi.Text);
                        komut1.Parameters.AddWithValue("@6", txtadres.Text);
                        komut1.Parameters.AddWithValue("@7", maskedTextBox1.Text);
                        komut1.Parameters.AddWithValue("@8", DateTime.Parse(dateTimePicker1.Text));
                        komut1.Parameters.AddWithValue("@9", txtresim.Text);



                        komut1.ExecuteNonQuery();
                        baglan.Close();
                        MessageBox.Show("veriler kaydedildi");
                        temizle();


                    }
                    catch (Exception hata)
                    {

                        MessageBox.Show(hata.Message, "bir yerlerde bir yanlışlık var", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    baglan.Close();
                }
                else
                {
                    MessageBox.Show("kırmızı olanları tekrar gözden geçiriniz.", "SELÇUK SPOR SALONU", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                baglan.Close();
            }
            else
            {
                MessageBox.Show("Böyle bir kayıt var zaten.", "SELÇUK SPOR SALONU", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtmail_TextChanged(object sender, EventArgs e)
        {
            if (txtmail.Text.Length < 16)
            {
                errorProvider1.SetError(txtmail, "mail numarsı  en az 16 karekter olmalı");

            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void btnfoto_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            txtresim.Text = openFileDialog1.FileName;
        }

        private void Ykullanıcıekle_Load(object sender, EventArgs e)
        {

            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            maskedTextBox1.Mask = "00000000000";
            txtadi.MaxLength = 15;
            txtsoyad.MaxLength = 15;
            toolTip1.SetToolTip(this.txtsifre, "sifre küçük harf,büyük hart sayı ve kareketer olması gereker");

            txtadi.CharacterCasing = CharacterCasing.Upper;
            txtsoyad.CharacterCasing = CharacterCasing.Upper;
            txtadres.CharacterCasing = CharacterCasing.Upper;
            txtkadi.MaxLength = 8;
            txtsifre.MaxLength = 11;
            txtsifretekrar.MaxLength = 11;


            DateTime zaman = DateTime.Now;
            int yil = int.Parse(zaman.ToString("yyyy"));
            int ay = int.Parse(zaman.ToString("MM"));
            int gun = int.Parse(zaman.ToString("dd"));

            dateTimePicker1.MinDate = new DateTime(2018, 1, 1);
            dateTimePicker1.MaxDate = new DateTime(2020, 12, 30);

            progressBar1.Maximum = 100;
            progressBar1.Value = 0;

            this.Text = "KULLANICI KAYIT SAYFASI";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            yöneticianamenu yönet = new yöneticianamenu();
            yönet.Show();
            this.Hide();
             
        }

        private void txtadi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true) // ısletter harf demek  klavyeden girilen harf ise 
            {                                                                                                                // IsSeparator boşluk ise 
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtsoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void txtadi_TextChanged(object sender, EventArgs e)
        {
            if (txtkadi.Text.Length != 8)
            {
                errorProvider1.SetError(txtkadi, "kullanıcı adı 8 karekter olmalı");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtkadi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsDigit(e.KeyChar) == true)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        int parola_skor = 0;
        private void txtsifre_TextChanged(object sender, EventArgs e)
        {
            string parola_seviye = "";
            int kucuk_harf = 0;
            int buyuk_harf = 0;
            int rakam_skoru = 0;
            int sembol_skoru = 0;

            string sifre = txtsifre.Text;

            string duzelt = "";

            duzelt = sifre;
            duzelt = duzelt.Replace('İ', 'i');
            duzelt = duzelt.Replace('ı', 'i');
            duzelt = duzelt.Replace('Ç', 'C');
            duzelt = duzelt.Replace('ç', 'c');
            duzelt = duzelt.Replace('Ş', 'S');
            duzelt = duzelt.Replace('ş', 's');
            duzelt = duzelt.Replace('Ğ', 'G');
            duzelt = duzelt.Replace('ğ', 'g');
            duzelt = duzelt.Replace('Ü', 'U');
            duzelt = duzelt.Replace('ü', 'u');
            duzelt = duzelt.Replace('Ö', 'O');
            duzelt = duzelt.Replace('ö', 'o');


            if (sifre != duzelt)
            {
                sifre = duzelt;
                txtsifre.Text = sifre;
                MessageBox.Show("paroladaki türkçe karekterler ingilizce karektere çevirilmiştir");
            }

            int az_karekter_sayısı = sifre.Length - Regex.Replace(sifre, "[a-z]", "").Length;   //sifre string ifadesi küçük olan karekterleri boş bırak
            kucuk_harf = Math.Min(2, az_karekter_sayısı) * 10;

            int Az_karekter_sayısı = sifre.Length - Regex.Replace(sifre, "[a-z]", "").Length;   //sifre string ifadesi küçük olan karekterleri boş bırak
            buyuk_harf = Math.Min(2, Az_karekter_sayısı) * 10;

            int rakam_sayısı = sifre.Length - Regex.Replace(sifre, "[0-9]", "").Length;   //sifre string ifadesi küçük olan karekterleri boş bırak
            rakam_skoru = Math.Min(2, rakam_sayısı) * 10;

            //1sembol 10 puan , 2  ve üzeri sembol 20 puan 
            int sembol_sayısı = sifre.Length - az_karekter_sayısı - Az_karekter_sayısı - rakam_sayısı;   //sifre string ifadesi küçük olan karekterleri boş bırak
            sembol_skoru = Math.Min(2, sembol_sayısı) * 10;

            parola_skor = kucuk_harf + buyuk_harf + rakam_skoru + sembol_skoru;


            if (sifre.Length == 9)
            {
                parola_skor += 10;

            }
            else if (sifre.Length == 10)
            {
                parola_skor += 20;
            }

            if (kucuk_harf == 0 || buyuk_harf == 0 || rakam_skoru == 0 || sembol_skoru == 0)
            {
                label6.Text = "PAROLA KÜÇÜK HARF,BÜYÜK HARF, SAYI VE ÖZEL\n KAREKTERLERLE OLUŞMASI GEREKMEKTEDİR!! ";
            }
            //if (buyuk_harf != 0 && kucuk_harf != 0 && rakam_skoru != 0 && sembol_skoru != 0)
            //{
            //    label18.Text = "";
            //}

            if (parola_skor < 70)
            {
                parola_seviye = "kabul edilemez";
            }
            else if (parola_skor == 70 || parola_skor == 80)
            {
                parola_seviye = "yeterli";
            }
            else if (parola_skor == 90 || parola_skor == 100)
            {
                parola_seviye = "güçlü şifre";
            }

            label1.Text = "%" + Convert.ToString(parola_skor);
            label4.Text = parola_seviye;

            progressBar1.Value = parola_skor;


        }

        private void txtsifretekrar_TextChanged(object sender, EventArgs e)
        {
            if (txtsifretekrar.Text != txtsifre.Text)
            {
                errorProvider1.SetError(txtsifretekrar, "parola eşleşmiyor");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
