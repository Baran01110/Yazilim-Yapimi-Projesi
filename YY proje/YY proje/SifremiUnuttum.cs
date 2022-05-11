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
    public partial class SifremiUnuttum : Form
    {
        
        SqlConnection connection = Form1.connection;
        

        public SifremiUnuttum()
        {
            InitializeComponent();
        }

        private void btnSifreUnuttum_Click(object sender, EventArgs e)
        {
            string KullanıcıAdı = txtKullanıcıAdı.Text;
            string e_mail = txtemail.Text;
            bool isThere = false;
            connection.Open();
            SqlCommand command = new SqlCommand("Select *from Giris", connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (KullanıcıAdı == Sezar.Decryption(reader["KullanıcıAdı"].ToString().TrimEnd(), 2) && e_mail == Sezar.Decryption(reader["e_mail"].ToString().TrimEnd(), 2))
                {
                    isThere = true;
                    txtGöster.Text = (Sezar.Decryption(reader["şifre"].ToString().TrimEnd(), 2));
                    break;
                    
                }
                else
                {
                    isThere = false;
                }
            }
            connection.Close();

            if (isThere)
            {
                MessageBox.Show("Şifreniz Hatırlatıldı !","Program");
               
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı ve e-mail Uyuşmuyor!!! !", "Program");
            }

        }

        private void txtGöster_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

