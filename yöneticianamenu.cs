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
    public partial class yöneticianamenu : Form
    {
        public yöneticianamenu()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void yöneticianamenu_Load(object sender, EventArgs e)
        {

            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;

            label2.ForeColor = Color.Red;
            label2.Text = yöneticigiris.adı + "  " + yöneticigiris.soyadi;

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            try
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\resim\\" + yöneticigiris.kullanıcıadi + ".png");
            }
            catch
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\resim\\resimyok.jpg");
                

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            Ykullanıcıekle ekle = new Ykullanıcıekle();
            ekle.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            kullanıcı_listele liste = new kullanıcı_listele();
            liste.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ÇIKMAK MI İSTİYORSUNUZ?", "SELÇUK SPOR SALONU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                yöneticigiris geri = new yöneticigiris();
                geri.Show();
                this.Hide();
            }

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            yöneticikurs ders = new yöneticikurs();
            ders.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yöneticidiyet diyet = new yöneticidiyet();
            diyet.Show();
            this.Hide();
        }
    }
}
