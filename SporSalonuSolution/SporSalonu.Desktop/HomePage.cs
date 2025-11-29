using Guna.UI2.WinForms;
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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
            container(new Dashboard());
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void container(object _form)
        {
            if (guna2PanelA_container.Controls.Count > 0) guna2PanelA_container.Controls.Clear();

            Form fm = _form as Form;
            fm.TopLevel = false;
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.Dock = DockStyle.Fill;
            guna2PanelA_container.Controls.Add(fm);
            guna2PanelA_container.Tag = fm;
            fm.Show();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            container(new Dashboard());
        }
    }
}
