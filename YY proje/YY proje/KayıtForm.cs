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
    public partial class KayıtForm : Form
    {
        SqlConnection connection = Form1.connection;
        public KayıtForm()
        {
            InitializeComponent();
        }

        private void txtisim_Enter(object sender, EventArgs e)
        {
            if (txtisim.Text == "Kullanıcı Adı")
            {
                txtisim.Text = "";
            }
        }

        private void txtisim_Leave(object sender, EventArgs e)
        {
            if (txtisim.Text == "")
            {
                txtisim.Text = "Kullanıcı Adı";
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Şifre")
            {
                textBox1.Text = "";
                textBox1.PasswordChar = '*';

            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            char? none =  null;
            if (textBox1.Text == "")
            {
                textBox1.Text = "Şifre";
                textBox1.PasswordChar = Convert.ToChar(none);
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Şifre Tekrar")
            {
                textBox2.Text = "";
                textBox2.PasswordChar = '*';

            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            char? none = null;
            if (textBox2.Text == "")
            {
                textBox2.Text = "Şifre Tekrar";
                textBox2.PasswordChar = Convert.ToChar(none);
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "e-Mail")
            {
                textBox3.Text = "";
                

            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            
            if (textBox3.Text == "")
            {
                textBox3.Text = "e-Mail";
                
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Telefon Numarası")
            {
                textBox4.Text = "";


            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Telefon Numarası";

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Insert Into Giris (KullanıcıAdı,şifre,re_şifre,e_mail,telefon) values ('" +Sezar.Encryption(txtisim.Text,2) + "','" + Sezar.Encryption(textBox1.Text,2) + "','" + Sezar.Encryption(textBox2.Text,2) + "','" + Sezar.Encryption(textBox3.Text,2) + "','" + Sezar.Encryption(textBox4.Text,2) + "')", connection);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Tebrikler... Kaydınız Başarı İle Yapılmıştır.","Program");
        }
    }
}
