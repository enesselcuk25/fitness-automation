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
    public partial class kullanıcıbilgileri : Form
    {
        public kullanıcıbilgileri()
        {
            InitializeComponent();
        }

        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database0.mdb");

        void diyetbilgi()
        {
            baglan.Open();
            string sorgu = "select * from diyetler where adi = '" + Giriş_sayfası.adi + "' and soyadi = '" + Giriş_sayfası.soyad + "'";
            OleDbCommand komut = new OleDbCommand(sorgu, baglan);

            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                lblkiloo.Text = oku.GetValue(3).ToString();
                lblboyy.Text = oku.GetValue(4).ToString();
                dateTimePicker5.Text = oku.GetValue(5).ToString();
                dateTimePicker4.Text = oku.GetValue(6).ToString();

                txtkahvaltı.Text = oku.GetValue(8).ToString();
                txtkusluk.Text = oku.GetValue(9).ToString();
                txtogle.Text = oku.GetValue(10).ToString();
                txtikindi.Text = oku.GetValue(11).ToString();
                txtaksam.Text = oku.GetValue(12).ToString();
                txtara.Text = oku.GetValue(13).ToString();

               
            }
            baglan.Close();
        }

         void dersler()
         {
            baglan.Open();
            string sorgu = "select * from derskayıt where adi =  '" + Giriş_sayfası.adi + "' and soyadi = '" + Giriş_sayfası.soyad + "' ";

            OleDbCommand komut = new OleDbCommand(sorgu, baglan);

            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                txtil.Text = oku.GetValue(2).ToString();
                txtilce.Text = oku.GetValue(3).ToString();

                txtders.Text = oku.GetValue(4).ToString();
                dateTimePicker1.Text = oku.GetValue(5).ToString();
                dateTimePicker2.Text = oku.GetValue(6).ToString();
                label8.Text = oku.GetValue(7).ToString();


            }

            baglan.Close();
         }

        private void kullanıcıbilgigoster()
        {

            txtbileposta.Text = Giriş_sayfası.eposta;
            txtbiladi.Text = Giriş_sayfası.adi;
            txtbilsoyad.Text = Giriş_sayfası.soyad;
            txtbilsifre.Text = Giriş_sayfası.sifre;
            txtbilkullanıcıadi.Text = Giriş_sayfası.kullanıcıadı;
            txtbiladres.Text = Giriş_sayfası.adres;
            txtbiltelno.Text = Giriş_sayfası.telefonno;
            dtbilkayıt.Text = Giriş_sayfası.kayıt;
            txtbilresim.Text = Giriş_sayfası.resim;
            pictureBox2.ImageLocation = Giriş_sayfası.resim;

        }

        void goster()
        {
            try
            {
                baglan.Open();
                string sorgu = "Select * from diyetler where adi = '" + Giriş_sayfası.adi + "' and soyadi = '" + Giriş_sayfası.soyad + "'";
                OleDbCommand komut = new OleDbCommand(sorgu, baglan);

                OleDbDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    txtdiyeteposta.Text = oku.GetValue(2).ToString();
                    txtdiyetkilo.Text = oku.GetValue(3).ToString();
                    txtdiyetboy.Text = oku.GetValue(4).ToString();
                    dtbaslangıctarihi.Text = oku.GetValue(5).ToString();
                    dtbitistarihi.Text = oku.GetValue(6).ToString();
                    lbldiyetuyelik.Text = oku.GetValue(7).ToString();
                    txkahvaltı.Text = oku.GetValue(8).ToString();
                    txkusluk.Text = oku.GetValue(9).ToString();
                    txogle.Text = oku.GetValue(10).ToString();
                    txikindi.Text = oku.GetValue(11).ToString();
                    txaksam.Text = oku.GetValue(12).ToString();
                    txara.Text = oku.GetValue(13).ToString();

                }


                baglan.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message, "hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

           

           





            bool durum = false;

            baglan.Open();
            string sorgu = "select * from giris where adi = '" + txtadi.Text + "' or '" + txtsoyad.Text + "'";
            OleDbCommand komut = new OleDbCommand(sorgu, baglan);

            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                durum = true;
                break;
            }
            baglan.Close();
            if (durum == true)
            {
                if (txtadi.Text.Length < 2 || txtadi.Text == "")
                {
                    lbladi.ForeColor = Color.Red;
                }
                else
                {
                    lbladi.ForeColor = Color.Black;
                }

                if (txtsoyad.Text.Length < 2 || txtsoyad.Text == "")
                {
                    lblsoyad.ForeColor = Color.Red;
                }
                else
                {
                    lblsoyad.ForeColor = Color.Black;
                }

                if (comil.Text == "")
                {
                    lblil.ForeColor = Color.Red;
                }
                else
                {
                    lblil.ForeColor = Color.Black;
                }

                if (comilce.Text == "")
                {
                    lblilce.ForeColor = Color.Red;
                }
                else
                {
                    lblilce.ForeColor = Color.Black;
                }

                if (comdersler.Text == "")
                {
                    lblders.ForeColor = Color.Red;
                }
                else
                {
                    lblders.ForeColor = Color.Black;
                }

                if (dtkayıt.Text == "")
                {
                    lblkayıt.ForeColor = Color.Red;
                }
                else
                {
                    lblkayıt.ForeColor = Color.Black;
                }

                if (dtbitis.Text == "")
                {
                    lblbitiş.ForeColor = Color.Red;
                }
                else
                {
                    lblbitiş.ForeColor = Color.Black;
                }


                if (txtadi.Text != "" && txtsoyad.Text != "" && comil.Text != "" && comilce.Text != "" && comdersler.Text != "")
                {
                    try
                    {
                        TimeSpan fark;
                        fark = DateTime.Parse(dtbitis.Text) - DateTime.Parse(dtkayıt.Text);
                        string sonuc = fark.TotalDays.ToString();
                        lblsüre.Text = sonuc;
                        int gun = Int32.Parse(sonuc);
                        DateTime.Parse(dtkayıt.Text.ToString());
                        DateTime.Parse(dtbitis.Text.ToString());

                        baglan.Open();
                        string sorgu0 = "insert into derskayıt (adi,soyadi,il,ilçe,dersler,kayıt,bitiş,sure) values ('" + txtadi.Text + "','" + txtsoyad.Text + "','" + comil.Text + "','" + comilce.Text + "','" + comdersler.Text + "',@1,@2,@3)";
                        OleDbCommand komut0 = new OleDbCommand(sorgu0, baglan);

                        komut0.Parameters.AddWithValue("@1", DateTime.Parse(dtkayıt.Text));
                        komut0.Parameters.AddWithValue("@2", DateTime.Parse(dtbitis.Text));
                        komut0.Parameters.AddWithValue("@3", lblsüre.Text);

                        komut0.ExecuteNonQuery();
                        baglan.Close();
                        MessageBox.Show("kaydedildi");
                    
                    }
                    catch (Exception hata)
                    {

                        MessageBox.Show(hata.Message, "hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("kırmızı olanları tekarar gözden geçiriniz", "SELÇUK SPOR SALONU", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("böyle bir kayıt var zaten", "SELÇUK SPOR SALONU", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        

        private void kullanıcıbilgileri_Load(object sender, EventArgs e)
        {
           
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            dersler();
            diyetbilgi();
            kullanıcıbilgigoster();
            goster();
            label2.Text = Giriş_sayfası.adi +"  " + Giriş_sayfası.soyad;
            pictureBox1.ImageLocation = Giriş_sayfası.resim;

            txtadi.Text = Giriş_sayfası.adi;
            txtsoyad.Text = Giriş_sayfası.soyad;
            txtadi.Enabled = false;
            txtsoyad.Enabled = false;

          

            label2.ForeColor = Color.Red;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            txtdiyetadi.Text = Giriş_sayfası.adi;
            txtdiyetsoyad.Text = Giriş_sayfası.soyad;

            txtdiyetadi.Enabled = false;
            txtdiyetsoyad.Enabled = false;


            baglan.Open();
            string sorgu = "Select il from il";

            OleDbCommand komut = new OleDbCommand(sorgu, baglan);

            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
               comil.Items.Add(oku.GetValue(0).ToString());

            }
            baglan.Close();


            

        



        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ÇIKMAK MI İSTİYORSUNUZ?", "SELÇUK SPOR SALONU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Giriş_sayfası sayfa = new Giriş_sayfası();
                sayfa.Show();
                this.Hide();
            }
             
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comil_SelectedIndexChanged(object sender, EventArgs e)
        {
            comilce.Items.Clear();
            comilce.Text = "";
            comdersler.Items.Clear();
            comdersler.Items.Clear();

            baglan.Open();
            string sorgu1 = "Select ilce from ilce where il = '"+comil.SelectedItem+"'";

            OleDbCommand komut1 = new OleDbCommand(sorgu1, baglan);

            OleDbDataReader oku1 = komut1.ExecuteReader();
            while (oku1.Read())
            {
                comilce.Items.Add(oku1.GetValue(0).ToString());

            }
            baglan.Close();
        }

        private void comilce_SelectedIndexChanged(object sender, EventArgs e)
        {
            comdersler.Items.Clear();
            comdersler.Items.Clear();

            baglan.Open();
            string sorgu1 = "Select ders from ogrderskayıt where ilce = '" + comilce.SelectedItem + "'";

            OleDbCommand komut1 = new OleDbCommand(sorgu1, baglan);

            OleDbDataReader oku1 = komut1.ExecuteReader();
            while (oku1.Read())
            {
                comdersler.Items.Add(oku1.GetValue(0).ToString());

            }
            baglan.Close();
        }

     


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                TimeSpan fark;
                fark = DateTime.Parse(dtbitis.Text) - DateTime.Parse(dtkayıt.Text);
                string sonuc = fark.TotalDays.ToString();
                lblsüre.Text = sonuc;
                int gun = Int32.Parse(sonuc);
                DateTime.Parse(dtkayıt.Text.ToString());
                DateTime.Parse(dtbitis.Text.ToString());

                baglan.Open();
                string sorgu = "update derskayıt set  soyadi = '" + txtsoyad.Text + "',il = '"+ comil.SelectedItem + "',ilçe ='" + comilce.SelectedItem + "',dersler = '" + comdersler.SelectedItem + "',kayıt = @1,bitiş = @2,sure =@3 where adi ='" + txtadi.Text + "' ";
                OleDbCommand komut = new OleDbCommand(sorgu, baglan);



                komut.Parameters.AddWithValue("@1", DateTime.Parse(dtkayıt.Text));
                komut.Parameters.AddWithValue("@2", DateTime.Parse(dtbitis.Text));
                komut.Parameters.AddWithValue("@3", lblsüre.Text);


                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("güncellendi");
             
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message, "hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                string sorgu = "delete from derskayıt where adi = '" + Giriş_sayfası.adi + "'";

                OleDbCommand komut = new OleDbCommand(sorgu, baglan);

                komut.ExecuteNonQuery();
                baglan.Close();

                MessageBox.Show("silindi");


            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATANIZ VAR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
          
            comil.Text = "";
            comilce.Text = "";
            comdersler.Text = "";
            dtkayıt.Text = "";
            dtbitis.Text = "";
            lblsüre.Text = "";
        }

        private void btndiyetkaydet_Click(object sender, EventArgs e)
        {

            bool durum = false;

            baglan.Open();
            string sorgu = "select * from diyetler where adi = '" + txtdiyetadi.Text + "' and soyadi = '" + txtdiyetsoyad.Text + "'";
            OleDbCommand komut = new OleDbCommand(sorgu, baglan);

            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                durum = true;
                break;
            }

            baglan.Close();
            if (durum == false)
            {
                if (txtdiyetadi.Text.Length < 2 || txtdiyetadi.Text == "")
                {
                    lblad.ForeColor = Color.Red;
                }
                else
                {
                    lblad.ForeColor = Color.Black;
                }

                if (txtdiyetsoyad.Text.Length < 2 || txtdiyetsoyad.Text == "")
                {
                    lblsoyad.ForeColor = Color.Red;
                }
                else
                {
                    lblsoyad.ForeColor = Color.Black;
                }

                if (txtdiyeteposta.Text == "")
                {
                    lblposta.ForeColor = Color.Red;
                }
                else
                {
                    lblposta.ForeColor = Color.Black;
                }

                if (txtdiyetkilo.Text == "")
                {
                    lblkilo.ForeColor = Color.Red;
                }
                else
                {
                    lblkilo.ForeColor = Color.Black;
                }

                if (txtdiyetboy.Text == "")
                {
                    lblboy.ForeColor = Color.Red;
                }
                else
                {
                    lblboy.ForeColor = Color.Black;
                }

                if (dtbaslangıctarihi.Text == "")
                {
                    lblkay.ForeColor = Color.Red;
                }
                else
                {
                    lblkay.ForeColor = Color.Black;
                }

                if (dtbitistarihi.Text == "")
                {
                    lblbit.ForeColor = Color.Red;
                }
                else
                {
                    lblbit.ForeColor = Color.Black;
                }
                if (txkahvaltı.Text == "")
                {
                    lblkahvaltı.ForeColor = Color.Red;
                }
                else
                {
                    lblkahvaltı.ForeColor = Color.Black;
                }
                if (txkusluk.Text == "")
                {
                    lblkusluk.ForeColor = Color.Red;
                }
                else
                {
                    lblkusluk.ForeColor = Color.Black;
                }
                if (txogle.Text == "")
                {
                    lblogle.ForeColor = Color.Red;
                }
                else
                {
                    lblogle.ForeColor = Color.Black;
                }
                if (txikindi.Text == "")
                {
                    lblikindi.ForeColor = Color.Red;
                }
                else
                {
                    lblikindi.ForeColor = Color.Black;
                }
                if (txaksam.Text == "")
                {
                    lblaksam.ForeColor = Color.Red;
                }
                else
                {
                    lblaksam.ForeColor = Color.Black;
                }
                if (txara.Text == "")
                {
                    lblara.ForeColor = Color.Red;
                }
                else
                {
                    lblara.ForeColor = Color.Black;
                }



                if (txtdiyetadi.Text != "" && txtdiyetsoyad.Text != "" && txtdiyeteposta.Text != "" && txtdiyetkilo.Text != "" && txtdiyetboy.Text != "" && dtbaslangıctarihi.Text != "" && dtbitistarihi.Text != "" && txkahvaltı.Text !="" && txkusluk.Text !=""&& txogle.Text != "" && txikindi.Text != "" && txaksam.Text != "" &&txara.Text != "")
                {
                    try
                    {
                        TimeSpan fark;
                        fark = DateTime.Parse(dtbitistarihi.Text) - DateTime.Parse(dtbaslangıctarihi.Text);
                        string sonuc = fark.TotalDays.ToString();
                        lbldiyetuyelik.Text = sonuc;
                        int gun = Int32.Parse(sonuc);
                        DateTime.Parse(dtbaslangıctarihi.Text.ToString());
                        DateTime.Parse(dtbitistarihi.Text.ToString());

                        baglan.Open();
                        string sorgu3 = "insert into diyetler (adi,soyadi,eposta,kilo,boy,başlangıc,bitis,sure,kahvaltı,kusluk,ogle,ikindi,aksam,ara) values ('"+ Giriş_sayfası.adi + "','" + Giriş_sayfası.soyad+ "','" + txtdiyeteposta.Text + "',@4,@5,@6,@7,@8,'" + txkahvaltı.Text + "','" + txkusluk.Text + "','" + txogle.Text + "','" + txikindi.Text + "','" + txaksam.Text + "','" + txara.Text + "')";
                        OleDbCommand komut3 = new OleDbCommand(sorgu3, baglan);

                        //komut0.Parameters.AddWithValue("@1", txtdiyetadi.Text);
                        //komut0.Parameters.AddWithValue("@2", txtdiyetsoyad.Text);
                        //komut0.Parameters.AddWithValue("@3", txtdiyeteposta.Text);
                        komut3.Parameters.AddWithValue("@4", OleDbType.Integer).Value = txtdiyetkilo.Text;
                        komut3.Parameters.AddWithValue("@5", OleDbType.Integer).Value = txtdiyetboy.Text;
                        komut3.Parameters.AddWithValue("@6", DateTime.Parse(dtbaslangıctarihi.Text));
                        komut3.Parameters.AddWithValue("@7", DateTime.Parse(dtbitistarihi.Text));
                        komut3.Parameters.AddWithValue("@8", OleDbType.Integer).Value = lbldiyetuyelik.Text;
                        //komut0.Parameters.AddWithValue("@9", txkahvaltı.Text);
                        //komut0.Parameters.AddWithValue("@10", txkusluk.Text);
                        //komut0.Parameters.AddWithValue("@11", txogle.Text);
                        //komut0.Parameters.AddWithValue("@12", txikindi.Text);
                        //komut0.Parameters.AddWithValue("@13", txaksam.Text);
                        //komut0.Parameters.AddWithValue("@14", txara.Text);

                        komut3.ExecuteNonQuery();
                        baglan.Close();
                        MessageBox.Show("kaydedildi");

                    }
                    catch (Exception hata)
                    {

                        MessageBox.Show(hata.Message, "hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        baglan.Close();
                    }
                }
                else
                {
                    MessageBox.Show("kırmızı olanları tekarar gözden geçiriniz", "SELÇUK SPOR SALONU", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("böyle bir kayıt var zaten", "SELÇUK SPOR SALONU", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btndiyetguncelle_Click(object sender, EventArgs e)
        {
            try
            {
                TimeSpan fark;
                fark = DateTime.Parse(dtbitistarihi.Text) - DateTime.Parse(dtbaslangıctarihi.Text);
                string sonuc = fark.TotalDays.ToString();
                lbldiyetuyelik.Text = sonuc;
                int gun = Int32.Parse(sonuc);
                DateTime.Parse(dtbaslangıctarihi.Text.ToString());
                DateTime.Parse(dtbitistarihi.Text.ToString());

                baglan.Open();
                string sorgu = "update diyetler set soyadi = @1,eposta = @2,kilo = @3,boy =@4,başlangıc = @5,bitis = @6,sure = @7,kahvaltı =@8,kusluk= @9,ogle =@10,ikindi =@11,aksam =@12,ara =@13 where adi =@14";

                OleDbCommand komut = new OleDbCommand(sorgu, baglan);


               
                komut.Parameters.AddWithValue("@1", Giriş_sayfası.soyad);
                komut.Parameters.AddWithValue("@2", txtdiyeteposta.Text);
                komut.Parameters.AddWithValue("@3", OleDbType.Integer).Value = txtdiyetkilo.Text;
                komut.Parameters.AddWithValue("@4", OleDbType.Integer).Value = txtdiyetboy.Text;
                komut.Parameters.AddWithValue("@5", DateTime.Parse(dtbaslangıctarihi.Value.ToString()));
                komut.Parameters.AddWithValue("@6", DateTime.Parse(dtbitistarihi.Value.ToString()));
                komut.Parameters.AddWithValue("@7", OleDbType.Integer).Value = lbldiyetuyelik.Text;
                komut.Parameters.AddWithValue("@8", txkahvaltı.Text);
                komut.Parameters.AddWithValue("@9", txkusluk.Text);
                komut.Parameters.AddWithValue("@10", txogle.Text);
                komut.Parameters.AddWithValue("@11", txikindi.Text);
                komut.Parameters.AddWithValue("@12", txaksam.Text);
                komut.Parameters.AddWithValue("@13", txara.Text);
                komut.Parameters.AddWithValue("@14", Giriş_sayfası.adi);

                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("güncellendi");
               
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message, "HATANIZ VAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btndiyettemizle_Click(object sender, EventArgs e)
        {
        
            txtdiyeteposta.Text = "";
            txtdiyetkilo.Text = "";
            txtdiyetboy.Text = "";
            dtbaslangıctarihi.Text = "";
            dtbitistarihi.Text = "";
            lbldiyetuyelik.Text = "";
            txkahvaltı.Text = "";
            txkusluk.Text = "";
            txogle.Text = "";
            txikindi.Text = "";
            txaksam.Text = "";
            txara.Text = "";

        }

        private void btndiyetsil_Click(object sender, EventArgs e)
        {
            bool kayıt = true;
            if (MessageBox.Show("SİLMEK İSTEDİĞİNİZE EMİNMİSİNİZ!", "SELÇUK SPOR SALONU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {


                try
                {
                    baglan.Open();
                    string sorgu = "delete from diyetler where adi = '" + Giriş_sayfası.adi + "'";

                    OleDbCommand komut = new OleDbCommand(sorgu, baglan);

                    komut.ExecuteNonQuery();
                    baglan.Close();

                    MessageBox.Show("silindi");
                    if(MessageBox.Show("YENİ BİR DİYETE KAYDOLMAK İSTER MİSİNİZ", "SELÇUK SPOR SALONU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        kayıt = true;
                        txtdiyeteposta.Text = "";
                        txtdiyetkilo.Text = "";
                        txtdiyetboy.Text = "";
                        dtbaslangıctarihi.Text = "";
                        dtbitistarihi.Text = "";
                        lbldiyetuyelik.Text = "";
                        txkahvaltı.Text = "";
                        txkusluk.Text = "";
                        txogle.Text = "";
                        txikindi.Text = "";
                        txaksam.Text = "";
                        txara.Text = "";

                    }



                }
                catch (Exception hata)
                {
                    MessageBox.Show(hata.Message, "HATANIZ VAR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("SİLME İŞLEMİ İPTAL EDİLMİŞTİR", "SELÇUK SPOR SALONU", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
      
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    baglan.Open();
            //    string sorgu = "update kullanıcıkayıt set email = @1,soyadi = @2,sifre = @3,kullaniciadi = @4,adres =@5,telefonno = @6,kayıttarihi =@7,resim =@8 where adi = @9 ";
            //    OleDbCommand komut = new OleDbCommand(sorgu, baglan);

            //    komut.Parameters.AddWithValue("@1", txtbileposta.Text = Giriş_sayfası.eposta);
            //    komut.Parameters.AddWithValue("@2", txtbilsoyad.Text = Giriş_sayfası.soyad);
            //    komut.Parameters.AddWithValue("@3", txtbilsifre.Text = Giriş_sayfası.sifre);
            //    komut.Parameters.AddWithValue("@4", txtbilkullanıcıadi.Text = Giriş_sayfası.kullanıcıadı);
               
            //    komut.Parameters.AddWithValue("@5", txtbiladres.Text = Giriş_sayfası.adres);
            //    komut.Parameters.AddWithValue("@6", txtbiltelno.Text = Giriş_sayfası.telefonno);
            //    komut.Parameters.AddWithValue("@7", dtbilkayıt.Text = Giriş_sayfası.kayıt);
            //    komut.Parameters.AddWithValue("@8", txtbilresim.Text = Giriş_sayfası.resim);
            //    komut.Parameters.AddWithValue("@8", pictureBox2.ImageLocation = Giriş_sayfası.resim);
            //    komut.Parameters.AddWithValue("@8", txtbiladi.Text = Giriş_sayfası.adi);

            //    komut.ExecuteNonQuery();
            //    baglan.Close();
            //    MessageBox.Show("güncellendi");


            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ÇIKMAK MI İSTİYORSUNUZ?", "SELÇUK SPOR SALONU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Giriş_sayfası sayfa = new Giriş_sayfası();
                sayfa.Show();
                this.Hide();
            }
               
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("ÇIKMAK MI İSTİYORSUNUZ?", "SELÇUK SPOR SALONU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Giriş_sayfası sayfa = new Giriş_sayfası();
                sayfa.Show();
                this.Hide();
            }
            
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            diyetbilgi();
            dersler();
        }

        private void txtbiladi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
