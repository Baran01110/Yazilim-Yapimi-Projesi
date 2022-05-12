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
    public partial class OgretmenEkranı : Form
    {
        public static SqlConnection connection = new SqlConnection("Data Source=DESKTOP-12BR9N2;Initial Catalog=yazılımyapımı;Integrated Security=True");
        public OgretmenEkranı()
        {
            InitializeComponent();
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnResimEkle_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            pictureBox1.ImageLocation = openFileDialog1.FileName;
            txtResim.Text = openFileDialog1.FileName;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Insert Into Sınav (FilmResim,SoruMetni,Soruistenen,A,B,C,D,DogruCevap) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", connection);
            command.Parameters.AddWithValue("@p1", txtResim.Text);
            command.Parameters.AddWithValue("@p2", txtSoruMetni.Text);
            command.Parameters.AddWithValue("@p3", txtSoruIstenen.Text);
            command.Parameters.AddWithValue("@p4", txtcvpA.Text);
            command.Parameters.AddWithValue("@p5", txtcvpB.Text);
            command.Parameters.AddWithValue("@p6", txtcvpC.Text);
            command.Parameters.AddWithValue("@p7", txtcvpD.Text);
            command.Parameters.AddWithValue("@p8", txtDogruCvp.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kayıt Başarıyla Eklendi...","Program");

        }

        private void OgretmenEkranı_Load(object sender, EventArgs e)
        {

        }
    }
}
