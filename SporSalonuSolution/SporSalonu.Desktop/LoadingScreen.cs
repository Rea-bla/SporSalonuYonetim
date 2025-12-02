using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SporSalonu.Desktop
{
    public partial class LoadingScreen : Form
    {
        public LoadingScreen()
        {
            InitializeComponent();
        }

        private void LoadingScreen_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (guna2CircleProgressBar1.Value == 101)
            {
                timer1.Stop();

            }
            else
            {
                guna2CircleProgressBar1.Value += 1;
                label_Val.Text = (Convert.ToInt32(label_Val.Text) + 1).ToString();
                if (label_Val.Text == "101")
                {
                    HomePage _load = new HomePage();

                    // 2. Yükleme ekranını göster
                    _load.Show();

                    // 3. Giriş ekranını GİZLE (Kapatma, sadece gizle)
                    this.Hide();

                }
            }


        }
        
            private void LoadingScreen_FormClosed(object sender, FormClosedEventArgs e)
            {
                Application.Exit(); // Bu komut gizli saklı ne varsa her şeyi kapatır.
            }


    }
}
