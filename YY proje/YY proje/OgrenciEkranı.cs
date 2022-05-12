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


            if ((txtOgrenciAd.Text == "") || (txtOgrenciSoyad.Text == ""))
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
            {
                Random rastgele = new Random();
                int sayi = rastgele.Next(1, 13);
                int sayi2 = rastgele.Next(1, 13);
                int sayi3 = rastgele.Next(1, 13);
                int sayi4 = rastgele.Next(1, 13);
                lbldeneme.Text = Convert.ToString(sayi);
                if (lbldeneme.Text == "") foreach (Control item in Controls) if (item is TextBox) item.Text = "";
                if (lbldeneme.Text == "") { pictureBox1.Image = null; }
                connection.Open();
                SqlCommand command = new SqlCommand("Select *from Sınav where SoruID like '" + lbldeneme.Text + "'", connection);
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
            
                lbldeneme2.Text = Convert.ToString(sayi2);
                if (lbldeneme2.Text == "") foreach (Control item in Controls) if (item is TextBox) item.Text = "";
                if (lbldeneme2.Text == "") { pictureBox2.Image = null; }
                connection.Open();
                SqlCommand command2 = new SqlCommand("Select *from Sınav where SoruID like '" + sayi2 + "'", connection);
                SqlDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    try
                    {
                        txtcvp1iki.Text = reader2["A"].ToString();
                        txtcvp2iki.Text = reader2["B"].ToString();
                        txtcvp3iki.Text = reader2["C"].ToString();
                        txtcvp4iki.Text = reader2["D"].ToString();
                        txtSoruMetniiki.Text = reader2["SoruMetni"].ToString();
                        txtSoruistenen2.Text = reader2["Soruistenen"].ToString();
                        pictureBox2.Image = Image.FromFile(reader2["FilmResim"].ToString());
                    }
                    catch
                    {
                        Console.WriteLine("hata");
                    }
                }
                connection.Close();

                lbldeneme3.Text = Convert.ToString(sayi3);
                if (lbldeneme3.Text == "") foreach (Control item in Controls) if (item is TextBox) item.Text = "";
                if (lbldeneme3.Text == "") { pictureBox3.Image = null; }
                connection.Open();
                SqlCommand command3 = new SqlCommand("Select *from Sınav where SoruID like '" + lbldeneme3.Text + "'", connection);
                SqlDataReader reader3 = command3.ExecuteReader();
                while (reader3.Read())
                {
                    try
                    {
                        txtcvp1uc.Text = reader3["A"].ToString();
                        txtcvp2uc.Text = reader3["B"].ToString();
                        txtcvp3uc.Text = reader3["C"].ToString();
                        txtcvp4uc.Text = reader3["D"].ToString();
                        txtSoruMetniuc.Text = reader3["SoruMetni"].ToString();
                        txtSoruistenen3.Text = reader3["Soruistenen"].ToString();
                        pictureBox3.Image = Image.FromFile(reader3["FilmResim"].ToString());
                    }
                    catch
                    {
                        Console.WriteLine("hata");
                    }
                }
                connection.Close();

                lbldeneme4.Text = Convert.ToString(sayi4);
                if (lbldeneme4.Text == "") foreach (Control item in Controls) if (item is TextBox) item.Text = "";
                if (lbldeneme4.Text == "") { pictureBox4.Image = null; }
                connection.Open();
                SqlCommand command4 = new SqlCommand("Select *from Sınav where SoruID like '" + lbldeneme4.Text + "'", connection);
                SqlDataReader reader4 = command4.ExecuteReader();
                while (reader4.Read())
                {
                    try
                    {
                        txtcvp1dort.Text = reader4["A"].ToString();
                        txtcvp2dort.Text = reader4["B"].ToString();
                        txtcvp3dort.Text = reader4["C"].ToString();
                        txtcvp4dort.Text = reader4["D"].ToString();
                        txtSoruMetnidort.Text = reader4["SoruMetni"].ToString();
                        txtSoruistenen4.Text = reader4["Soruistenen"].ToString();
                        pictureBox4.Image = Image.FromFile(reader4["FilmResim"].ToString());
                    }
                    catch
                    {
                        Console.WriteLine("hata");
                    }
                }
                connection.Close();
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
