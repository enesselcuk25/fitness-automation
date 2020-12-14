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
    public partial class şifrehatırlam : Form
    {
        public şifrehatırlam()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database0.mdb");

        private void button1_Click(object sender, EventArgs e)
        {

            this.Text = "Şifre Öğrenme Sayfası";
            bool durum = true;
            
            try
            {
                
                baglan.Open();
                string sorgu = "select * from kullanıcıkayıt where email = '" + textBox1.Text + "'  or kullaniciadi  = '" + textBox1.Text + "' ";
                OleDbCommand komut = new OleDbCommand(sorgu,baglan);

                OleDbDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    durum = true;
                    MessageBox.Show(oku.GetValue(3).ToString(),"Şifreniz" );
                    
                    break;

                }
               if(durum == false)
                {
                    MessageBox.Show( "bilgilerinizi kontrol ediniz","selçuk spor salonu" ,MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                baglan.Close();
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message, "bilgilerinizi kontrol ediniz", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                baglan.Close();
            }

            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Giriş_sayfası sayfa = new Giriş_sayfası();
            sayfa.Show();
            this.Hide();
        }

        private void şifrehatırlam_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
