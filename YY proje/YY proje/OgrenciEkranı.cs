using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YY_proje
{
    public partial class OgrenciEkranı : Form
    {
        public OgrenciEkranı()
        {
            InitializeComponent();
        }
        int sayac = 600;
        int dogru = 0;
        int yanlis = 0;

        public void sonuclar(RadioButton seciliolan)
        {
            if(seciliolan.Checked==true)
            {
                dogru++;
                seciliolan.BackColor = Color.Green;
            }
            else
            {
                yanlis++;
                seciliolan.BackColor = Color.Red;
            }
            lblDogruSayisi.Text = dogru.ToString();
            lblYanlisSayisi.Text = yanlis.ToString();
        }
        public void gruptrue()
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
            groupBox4.Enabled = true;
        }
        public void grupfalse()
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;
        }
        private void OgrenciEkranı_Load(object sender, EventArgs e)
        {
            grupfalse();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac-=  1;
            lblSure.Text = sayac.ToString();
            if (sayac==0)
            {
                timer1.Enabled = false;
                grupfalse();

                MessageBox.Show("Süre Doldu.");
                btnTestiBasla.Enabled = false;
                btnTestiBitir.Enabled = false;

                sonuclar(radioButton1);
                sonuclar(radioButton5);
                sonuclar(radioButton12);
                sonuclar(radioButton15);
            }
        }

        private void btnTestiBasla_Click(object sender, EventArgs e)
        {
            if ((txtOgrenciAd.Text=="") || (txtOgrenciSoyad.Text==""))
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz");
            }
            else
            {
                timer1.Enabled = true;
                gruptrue();
                lblogrgörünenad.Text = txtOgrenciAd.Text;
                lblogrgorunenSyad.Text = txtOgrenciSoyad.Text;
                btnTestiBasla.Enabled = false;
            }
        }

        private void lblYanlisSayisi_Click(object sender, EventArgs e)
        {

        }

        private void btnTestiBitir_Click(object sender, EventArgs e)
        {
            grupfalse();
            btnTestiBitir.Enabled = false;
            timer1.Enabled = false;

            sonuclar(radioButton1);
            sonuclar(radioButton5);
            sonuclar(radioButton12);
            sonuclar(radioButton15);
        }
    }
}
