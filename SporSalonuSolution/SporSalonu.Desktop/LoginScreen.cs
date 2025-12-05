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


        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(guna2TextBox1.Text) || string.IsNullOrWhiteSpace(guna2TextBox2.Text))
            {
                MessageBox.Show("Lütfen kullanýcý adý ve þifre giriniz!", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            guna2Button1.Enabled = false;
            guna2Button1.Text = "Kontrol Ediliyor...";

            try
            {
                ApiServices servis = new ApiServices();


                bool girisBasarili = await servis.GirisYap(guna2TextBox1.Text.Trim(), guna2TextBox2.Text.Trim());


                if (girisBasarili)
                {
                    
                   
                    LoadingScreen _load = new LoadingScreen();    //LoadingScreen loadingscreen = new LoadingScreen();  loadingscreen.Show(); da oluyor galiba

                    _load.Show();

                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Hatalý kullanýcý adý veya þifre!", "Giriþ Baþarýsýz", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beklenmedik bir hata oluþtu: " + ex.Message);
            }
            finally
            {
                guna2Button1.Enabled = true;
                guna2Button1.Text = "Giriþ Yap";
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}


