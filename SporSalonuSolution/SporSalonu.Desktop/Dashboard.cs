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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Şu anki zamanı al
            DateTime simdi = DateTime.Now;

            // Saati Güncelle (Saat:Dakika şeklinde)
            // Saniye de görünsün isterseniz: simdi.ToString("HH:mm:ss"); yapın
            lblSaat.Text = simdi.ToString("HH:mm");

            // Tarihi Güncelle (Gün Ay Yıl GünAdı)
            // Örnek Çıktı: 29 Kasım 2025 Cumartesi
            lblTarih.Text = simdi.ToString("dd MMMM yyyy dddd");

        }




    }
}
