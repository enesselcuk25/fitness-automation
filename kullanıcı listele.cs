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
    public partial class kullanıcı_listele : Form
    {
        public kullanıcı_listele()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database0.mdb");

        private void temizle()
        {
            txtadi.Text = "";
            txtsoyadi.Text = "";
            txtmail.Text = "";
            txtsifre.Text = "";
            txtkadi.Text = "";
            txttel.Text = "";
            txtadres.Text = "";
            dateTimePicker1.Text = "";
            txtresim.Text = "";
            pictureBox1.ImageLocation = "";


        }
        

        private void getir()
        {
            baglan.Open();
            string sorgu = "select email as[E- MAİL],adi as[ADI],soyadi as[SOYADI], sifre as [ŞİFRE], kullaniciadi as[KULLANICI ADI], adres as[ADRES],telefonno as[TELEFON NO],kayıttarihi as[KAYIT TARİHİ],resim as[RESİM]  from kullanıcıkayıt";
            OleDbDataAdapter komut = new OleDbDataAdapter(sorgu, baglan);
            DataTable tab = new DataTable();
            komut.Fill(tab);
            dataGridView1.DataSource = tab;
            baglan.Close();
        }

        private void btnsec_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            txtresim.Text = openFileDialog1.FileName;
        }

        private void kullanıcı_listele_Load(object sender, EventArgs e)
        {
            getir();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            this.Text = "KULLANICI LİSTELE";
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

        }

       

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtadi.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtsoyadi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtmail.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtkadi.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtsifre.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtadres.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txttel.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtresim.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            pictureBox1.ImageLocation = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void txtadi_TextChanged(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                string sorgu = "select * from kullanıcıkayıt where adi like '%" + txtadi.Text + "%'";
                OleDbCommand komut = new OleDbCommand(sorgu, baglan);


                OleDbDataReader oku = komut.ExecuteReader();
                while (oku.Read())
                {
                    txtsoyadi.Text = oku.GetValue(2).ToString();
                    txtmail.Text = oku.GetValue(0).ToString();
                    txtkadi.Text = oku.GetValue(4).ToString();
                    txtsifre.Text = oku.GetValue(3).ToString();
                    txtadres.Text = oku.GetValue(5).ToString();
                    txttel.Text = oku.GetValue(6).ToString();
                    dateTimePicker1.Text = oku.GetValue(7).ToString();
                    pictureBox1.ImageLocation = oku.GetValue(8).ToString();

                }
                baglan.Close();

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message, "HATANIZ VAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void txtsoyadi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsoyadi_KeyPress(object sender, KeyPressEventArgs e)
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

            lblskor.Text = "%" + Convert.ToString(parola_skor);
            lblseviye.Text = parola_seviye;

            progressBar1.Value = parola_skor;

        }

        private void txtkadi_TextChanged(object sender, EventArgs e)
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

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                string sorgu = "update kullanıcıkayıt set email = @1,soyadi = @2,sifre =@3,kullaniciadi = @4,adres = @5,telefonno = @6,kayıttarihi = @7,resim = @8 where adi = @10";

                OleDbCommand komut = new OleDbCommand(sorgu, baglan);

                komut.Parameters.AddWithValue("@1", txtmail.Text);
                komut.Parameters.AddWithValue("@2", txtsoyadi.Text);
                komut.Parameters.AddWithValue("@3", txtsifre.Text);
                komut.Parameters.AddWithValue("@4", txtkadi.Text);
                komut.Parameters.AddWithValue("@5", txtadres.Text);
                komut.Parameters.AddWithValue("@6", txttel.Text);
                komut.Parameters.AddWithValue("@7", dateTimePicker1.Text);
               
                komut.Parameters.AddWithValue("@9", pictureBox1.ImageLocation);
                komut.Parameters.AddWithValue("@10", txtadi.Text);





                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("veriler güncellendi","uyarı");
                temizle();
                getir();

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message, "bir yerlerde hata var", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                string sorgu = "delete from kullanıcıkayıt where adi = '" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "'";

                OleDbCommand komut = new OleDbCommand(sorgu, baglan);

                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("silinidi");
                temizle();
                getir();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message, "HATANIZ VAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
           
            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void txtara_TextChanged(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                string sorgu = "select * from kullanıcıkayıt where adi like  '%" + txtara.Text+ "%' or kullaniciadi like '%" +txtara.Text+ "%'";

                OleDbDataAdapter komut = new OleDbDataAdapter(sorgu, baglan);
                DataTable dat = new DataTable();
                komut.Fill(dat);
                dataGridView1.DataSource = dat;

                baglan.Close();


                
            }
            catch (Exception hata )
            {

                MessageBox.Show(hata.Message,"HATANIZ VAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            yöneticianamenu yönet = new yöneticianamenu();
            yönet.Show();
            this.Hide();
        }
    }
}
