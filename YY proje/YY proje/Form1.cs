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
    public partial class Form1 : Form
    {
       public static SqlConnection connection = new SqlConnection("Data Source=DESKTOP-12BR9N2;Initial Catalog=yazılımyapımı;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtisim.Text=="Kullanıcı adı")
            {
                txtisim.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(txtisim.Text=="")
            {
                txtisim.Text = "Kullanıcı adı";
            }
        }

        private void textBox1_Enter_1(object sender, EventArgs e)
        {
            if(txtSifre.Text=="Şifre")
            {
                txtSifre.Text = "";
                txtSifre.PasswordChar = '*';

            }
        }
        char? none = null;
        private void textBox1_Leave_1(object sender, EventArgs e)
        {
            if(txtSifre.Text=="")
            {
                txtSifre.Text = "Şifre";
                txtSifre.PasswordChar = Convert.ToChar(none);
            }
        }
         
        private void button1_Click(object sender, EventArgs e)
        {
            string KullanıcıAdı = txtisim.Text;
            string şifre = txtSifre.Text;
            bool isThere = false;
            connection.Open();
            SqlCommand command = new SqlCommand("Select *from Giris",connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (KullanıcıAdı ==Sezar.Decryption (reader["KullanıcıAdı"].ToString().TrimEnd(),2) && şifre == Sezar.Decryption(reader["şifre"].ToString().TrimEnd(),2))
                {
                    isThere = true;
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
                    MessageBox.Show("Başarıyla Giriş Yaptınız !","Program");
                }
                else
                {
                    MessageBox.Show("Giriş Yapamadınız !","Program");
                }
            
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            KayıtForm kayıtForm = new KayıtForm();
            kayıtForm.Show();
        }
    }
}
