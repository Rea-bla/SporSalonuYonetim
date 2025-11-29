using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;
using SporSalonu.Desktop;

namespace SporSalonu.Desktop
{
    public partial class Form1 : Form
    {
        SqlBaglantisi bgl = new SqlBaglantisi();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

    
            private void guna2Button1_Click(object sender, EventArgs e)
            {
             string kullanici = guna2TextBox1.Text.Trim();
             string sifre = guna2TextBox2.Text.Trim();

                 if (kullanici == "" || sifre == "")
                 {
                MessageBox.Show("Lütfen kullanýcý adý ve þifre giriniz!", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                 }

             SqlConnection conn = bgl.Baglanti();
             conn.Open();

             SqlCommand cmd = new SqlCommand(
                 "SELECT COUNT(*) FROM Yoneticiler WHERE KullaniciAdi=@k AND Sifre=@s", conn);

             cmd.Parameters.AddWithValue("@k", kullanici);
             cmd.Parameters.AddWithValue("@s", sifre);

             int sonuc = (int)cmd.ExecuteScalar();
             conn.Close();

                  if (sonuc > 0)
                  {
                MessageBox.Show("Giriþ baþarýlý, hoþ geldin Ýmparator!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Buraya admin panelinin açýlacaðý kod gelecek
                // ör: 
                // AdminPanel admin = new AdminPanel();
                // admin.Show();
                // this.Hide();
                LoadingScreen _load = new LoadingScreen();
                _load.Show();


            }
                  else
                  {
                MessageBox.Show("Hatalý kullanýcý adý veya þifre!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                  }
            


        }
    }
    }


