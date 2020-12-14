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
    public partial class yöneticidiyet : Form
    {
        public yöneticidiyet()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database0.mdb");

        void temizle()
        {
            txtdiyetadi.Text = "";
            txtdiyetsoyad.Text = "";
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

        void getir()
        {
            baglan.Open();
            string sorgu = "select * from diyetler";
            OleDbDataAdapter oku = new OleDbDataAdapter(sorgu, baglan);
            DataTable dat = new DataTable();
            oku.Fill(dat);

            dataGridView1.DataSource = dat;
            baglan.Close();

        }
        private void yöneticidiyet_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            getir();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtdiyetadi.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtdiyetsoyad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtdiyeteposta.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtdiyetkilo.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtdiyetboy.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            dtbaslangıctarihi.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            dtbitistarihi.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            lbldiyetuyelik.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txkahvaltı.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txkusluk.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            txogle.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            txikindi.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            txaksam.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            txara.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();

        }

        private void btndiyetkaydet_Click(object sender, EventArgs e)
        {

            bool durum = false;

            baglan.Open();
            string sorgu = "select * from diyetler where adi like '" + txtdiyetadi.Text + "'";
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
                    lbladı.ForeColor = Color.Red;
                }
                else
                {
                    lbladı.ForeColor = Color.Black;
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
                    lblkayıt.ForeColor = Color.Red;
                }
                else
                {
                    lblkayıt.ForeColor = Color.Black;
                }

                if (dtbitistarihi.Text == "")
                {
                    lblbitis.ForeColor = Color.Red;
                }
                else
                {
                    lblbitis.ForeColor = Color.Black;
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



                if (txtdiyetadi.Text != "" && txtdiyetsoyad.Text != "" && txtdiyeteposta.Text != "" && txtdiyetkilo.Text != "" && txtdiyetboy.Text != "" && dtbaslangıctarihi.Text != "" && dtbitistarihi.Text != "" && txkahvaltı.Text != "" && txkusluk.Text != "" && txogle.Text != "" && txikindi.Text != "" && txaksam.Text != "" && txara.Text != "")
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
                        string sorgu3 = "insert into diyetler (adi,soyadi,eposta,kilo,boy,başlangıc,bitis,sure,kahvaltı,kusluk,ogle,ikindi,aksam,ara) values ('" + txtdiyetadi.Text + "','" + txtdiyetsoyad.Text + "','" + txtdiyeteposta.Text + "',@4,@5,@6,@7,@8,'" + txkahvaltı.Text + "','" + txkusluk.Text + "','" + txogle.Text + "','" + txikindi.Text + "','" + txaksam.Text + "','" + txara.Text + "')";
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
                        getir();
                        temizle();

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



                komut.Parameters.AddWithValue("@1", txtdiyetsoyad.Text);
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
                komut.Parameters.AddWithValue("@14", txtdiyetadi.Text);

                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("güncellendi");
                getir();
                temizle();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message, "HATANIZ VAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btndiyettemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btndiyetsil_Click(object sender, EventArgs e)
        {

            try
            {
                baglan.Open();
                string sorgu = "delete from diyetler where adi = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";

                OleDbCommand komut = new OleDbCommand(sorgu, baglan);

                komut.ExecuteNonQuery();
                baglan.Close();

                MessageBox.Show("silindi");
                if (MessageBox.Show("YENİ BİR KİŞİNİN DİYETİNİ KAYDETMEK İSTERMİSİNİZ", "SELÇUK SPOR SALONU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                 
                    txtdiyetadi.Text = "";
                    txtdiyetsoyad.Text = "";
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
                getir();


            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message, "HATANIZ VAR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            baglan.Open();
            string sorgu = "select * from diyetler where adi like '%" + txtara.Text + "%'";

            OleDbDataAdapter oku = new OleDbDataAdapter(sorgu, baglan);

            DataTable dat = new DataTable();
            oku.Fill(dat);

            dataGridView1.DataSource = dat;
            baglan.Close();



        }

        private void txtdiyetadi_TextChanged(object sender, EventArgs e)
        {
            baglan.Open();

            string sorgu =  "select * from diyetler where adi like '%" + txtdiyetadi.Text + "%'";

            OleDbCommand komut = new OleDbCommand(sorgu, baglan);

            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                txtdiyetsoyad.Text = oku.GetValue(1).ToString();
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

        private void button4_Click(object sender, EventArgs e)
        {
            yöneticianamenu yönet = new yöneticianamenu();
            yönet.Show();
            this.Hide();
        }
    }
}
