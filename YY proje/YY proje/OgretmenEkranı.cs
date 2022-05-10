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
            SqlCommand command = new SqlCommand("Insert Into Sınav (FilmResim,SoruMetni) values (@p1,@p2)", connection);
            command.Parameters.AddWithValue("@p1", txtResim.Text);
            command.Parameters.AddWithValue("@p2", txtSoruMetni.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kayıt Başarıyla Eklendi...","Program");

        }
    }
}
