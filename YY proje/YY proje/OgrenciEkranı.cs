using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace YY_proje
{
    public partial class OgrenciEkranı : Form
    {
        public static SqlConnection connection = new SqlConnection("Data Source=DESKTOP-12BR9N2;Initial Catalog=yazılımyapımı;Integrated Security=True");
        

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

        private void txtSoruIDGetir_TextChanged(object sender, EventArgs e)
        {
            if (txtSoruIDGetir.Text == "") foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            if (txtSoruIDGetir.Text == "") { pictureBox1.Image = null; }
                connection.Open();
            SqlCommand command = new SqlCommand("Select *from Sınav where SoruID like '" + txtSoruIDGetir.Text + "'", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
               
              try
                {
                    txtcvp1.Text = reader["A"].ToString();
                    txtcvp2.Text = reader["B"].ToString();
                    txtcvp3.Text = reader["C"].ToString();
                    txtcvp4.Text = reader["D"].ToString();
                    txtSoruMetnibir.Text = reader["SoruMetni"].ToString();
                    txtSoruistenen1.Text = reader["Soruistenen"].ToString();
                    pictureBox1.Image = Image.FromFile(reader["FilmResim"].ToString());
                }
                catch
                {
                    Console.WriteLine("hata");
                }
                
                
            }
            connection.Close();
            
        }

        private void txtSoruIDGetir2_TextChanged(object sender, EventArgs e)
        {
            if (txtSoruIDGetir2.Text == "") foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            if (txtSoruIDGetir2.Text == "") { pictureBox2.Image = null; }
            connection.Open();
            SqlCommand command = new SqlCommand("Select *from Sınav where SoruID like '" + txtSoruIDGetir2.Text + "'", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    txtcvp1iki.Text = reader["A"].ToString();
                    txtcvp2iki.Text = reader["B"].ToString();
                    txtcvp3iki.Text = reader["C"].ToString();
                    txtcvp4iki.Text = reader["D"].ToString();
                    txtSoruMetniiki.Text = reader["SoruMetni"].ToString();
                    txtSoruistenen2.Text = reader["Soruistenen"].ToString();
                    pictureBox2.Image = Image.FromFile(reader["FilmResim"].ToString());
                }
                catch
                {
                    Console.WriteLine("hata");
                }
            }
            connection.Close();
        }

        private void txtSoruIDGetir3_TextChanged(object sender, EventArgs e)
        {
            if (txtSoruIDGetir3.Text == "") foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            if (txtSoruIDGetir3.Text == "") { pictureBox3.Image = null; }
            connection.Open();
            SqlCommand command = new SqlCommand("Select *from Sınav where SoruID like '" + txtSoruIDGetir3.Text + "'", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    txtcvp1uc.Text = reader["A"].ToString(); 
                    txtcvp2uc.Text = reader["B"].ToString();
                    txtcvp3uc.Text = reader["C"].ToString();
                    txtcvp4uc.Text = reader["D"].ToString();
                    txtSoruMetniuc.Text = reader["SoruMetni"].ToString();
                    txtSoruistenen3.Text = reader["Soruistenen"].ToString();
                    pictureBox3.Image = Image.FromFile(reader["FilmResim"].ToString());
                }
                catch
                {
                    Console.WriteLine("hata");
                }
            }
            connection.Close();
        }

        private void txtSoruIDGetir4_TextChanged(object sender, EventArgs e)
        {
            if (txtSoruIDGetir4.Text == "") foreach (Control item in Controls) if (item is TextBox) item.Text = "";
            if (txtSoruIDGetir4.Text == "") { pictureBox4.Image = null; }
            connection.Open();
            SqlCommand command = new SqlCommand("Select *from Sınav where SoruID like '" + txtSoruIDGetir4.Text + "'", connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    txtcvp1dort.Text = reader["A"].ToString();
                    txtcvp2dort.Text = reader["B"].ToString();
                    txtcvp3dort.Text = reader["C"].ToString();
                    txtcvp4dort.Text = reader["D"].ToString();
                    txtSoruMetnidort.Text = reader["SoruMetni"].ToString();
                    txtSoruistenen4.Text = reader["Soruistenen"].ToString();
                    pictureBox4.Image = Image.FromFile(reader["FilmResim"].ToString());
                }
                catch
                {
                    Console.WriteLine("hata");
                }
            }
            connection.Close();
        }
    }
}
