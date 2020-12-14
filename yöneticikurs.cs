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
    public partial class yöneticikurs : Form
    {
        public yöneticikurs()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database0.mdb");
        void getir()
        {
            baglan.Open();
            string sorgu = "select * from derskayıt";
            OleDbDataAdapter oku = new OleDbDataAdapter(sorgu, baglan);
            DataTable dat = new DataTable();
            oku.Fill(dat);

            dataGridView1.DataSource = dat;
            baglan.Close();
        }

        void temizle()
        {
            txtadi.Text = "";
            txtsoyad.Text = "";
            comil.Text = "";
            comilce.Text = "";
            comdersler.Text = "";
            dtkayıt.Text = "";
            dtbitis.Text = "";
            lblsüre.Text = "";
        }
        private void yöneticikurs_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            getir();
            this.Text = "YÖNETİCİ KURS AYARLARI";
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

        private void comil_SelectedIndexChanged(object sender, EventArgs e)
        {
            comilce.Items.Clear();
            comilce.Text = "";
            comdersler.Items.Clear();
            comdersler.Items.Clear();

            baglan.Open();
            string sorgu1 = "Select ilce from ilce where il = '" + comil.SelectedItem + "'";

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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtadi.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtsoyad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comil.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comilce.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comdersler.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dtkayıt.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            dtbitis.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            lblsüre.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void txtadi_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    baglan.Open();
            //    string sorgu = "select * from derskayıt where adi like '%" + txtadi.Text + "%'";
            //    OleDbCommand komut = new OleDbCommand(sorgu, baglan);

            //    OleDbDataReader oku = komut.ExecuteReader();

            //    while (oku.Read())
            //    {
            //        txtsoyad.Text = oku.GetValue(1).ToString();
            //        comil.Text = oku.GetValue(2).ToString();
            //        comilce.Text = oku.GetValue(3).ToString();
            //        comdersler.Text = oku.GetValue(4).ToString();
            //        dtkayıt.Text = oku.GetValue(5).ToString();
            //        dtbitis.Text = oku.GetValue(6).ToString();
            //        lblsüre.Text = oku.GetValue(7).ToString();
            //    }
            //    baglan.Close();
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("hata oluştu", "SELÇUK SPOR SALONU", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void txtara_TextChanged(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                string sorgu = "select * from derskayıt where adi like  '%" + txtara.Text + "%' ";

                OleDbDataAdapter komut = new OleDbDataAdapter(sorgu, baglan);
                DataTable dat = new DataTable();
                komut.Fill(dat);
                dataGridView1.DataSource = dat;

                baglan.Close();



            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message, "HATANIZ VAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool durum = false;

            baglan.Open();
            string sorgu = "select * from derskayıt where adi like '" + txtadi.Text + "'";
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
                        getir();
                        temizle();
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

        private void button3_Click(object sender, EventArgs e)
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
                string sorgu = "update derskayıt set  soyadi = '" + txtsoyad.Text + "',il = '" + comil.SelectedItem + "',ilçe ='" + comilce.SelectedItem + "',dersler = '" + comdersler.SelectedItem + "',kayıt = @1,bitiş = @2,sure =@3 where adi ='" + txtadi.Text + "' ";
                OleDbCommand komut = new OleDbCommand(sorgu, baglan);



                komut.Parameters.AddWithValue("@1", DateTime.Parse(dtkayıt.Text));
                komut.Parameters.AddWithValue("@2", DateTime.Parse(dtbitis.Text));
                komut.Parameters.AddWithValue("@3", lblsüre.Text);


                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("güncellendi");
                getir();
                temizle();

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message, "hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                baglan.Open();
                string sorgu = "delete from derskayıt where adi = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString()+ "'";

                OleDbCommand komut = new OleDbCommand(sorgu, baglan);

                komut.ExecuteNonQuery();
                baglan.Close();

                MessageBox.Show("silindi");
                getir();
                temizle();

            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATANIZ VAR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            yöneticianamenu yönet = new yöneticianamenu();
            yönet.Show();
            this.Hide();
        }
    }
}
