namespace SporSalonu.Desktop
{
    partial class Payments
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(components);
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            TcNo = new Guna.UI2.WinForms.Guna2TextBox();
            BtnOdeme = new Guna.UI2.WinForms.Guna2Button();
            guna2AnimateWindow2 = new Guna.UI2.WinForms.Guna2AnimateWindow(components);
            UyelikTip = new ComboBox();
            TipTxt = new Guna.UI2.WinForms.Guna2TextBox();
            TipButon = new Guna.UI2.WinForms.Guna2Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(103, 25);
            label1.TabIndex = 1;
            label1.Text = "Ödemeler";
            // 
            // TcNo
            // 
            TcNo.BorderColor = Color.MintCream;
            TcNo.CustomizableEdges = customizableEdges1;
            TcNo.DefaultText = "";
            TcNo.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            TcNo.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            TcNo.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            TcNo.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            TcNo.FillColor = Color.IndianRed;
            TcNo.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            TcNo.Font = new Font("Segoe UI", 9F);
            TcNo.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            TcNo.Location = new Point(82, 95);
            TcNo.Name = "TcNo";
            TcNo.PlaceholderText = "";
            TcNo.SelectedText = "";
            TcNo.ShadowDecoration.CustomizableEdges = customizableEdges2;
            TcNo.Size = new Size(200, 36);
            TcNo.TabIndex = 2;
            // 
            // BtnOdeme
            // 
            BtnOdeme.CustomizableEdges = customizableEdges3;
            BtnOdeme.DisabledState.BorderColor = Color.DarkGray;
            BtnOdeme.DisabledState.CustomBorderColor = Color.DarkGray;
            BtnOdeme.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            BtnOdeme.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            BtnOdeme.Font = new Font("Segoe UI", 9F);
            BtnOdeme.ForeColor = Color.White;
            BtnOdeme.Location = new Point(82, 179);
            BtnOdeme.Name = "BtnOdeme";
            BtnOdeme.ShadowDecoration.CustomizableEdges = customizableEdges4;
            BtnOdeme.Size = new Size(200, 45);
            BtnOdeme.TabIndex = 3;
            BtnOdeme.Text = "guna2Button1";
            BtnOdeme.Click += BtnOdeme_Click;
            // 
            // UyelikTip
            // 
            UyelikTip.FormattingEnabled = true;
            UyelikTip.Location = new Point(751, 95);
            UyelikTip.Name = "UyelikTip";
            UyelikTip.Size = new Size(121, 23);
            UyelikTip.TabIndex = 4;
            // 
            // TipTxt
            // 
            TipTxt.CustomizableEdges = customizableEdges5;
            TipTxt.DefaultText = "";
            TipTxt.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            TipTxt.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            TipTxt.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            TipTxt.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            TipTxt.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            TipTxt.Font = new Font("Segoe UI", 9F);
            TipTxt.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            TipTxt.Location = new Point(751, 167);
            TipTxt.Name = "TipTxt";
            TipTxt.PlaceholderText = "";
            TipTxt.SelectedText = "";
            TipTxt.ShadowDecoration.CustomizableEdges = customizableEdges6;
            TipTxt.Size = new Size(200, 36);
            TipTxt.TabIndex = 5;
            // 
            // TipButon
            // 
            TipButon.CustomizableEdges = customizableEdges7;
            TipButon.DisabledState.BorderColor = Color.DarkGray;
            TipButon.DisabledState.CustomBorderColor = Color.DarkGray;
            TipButon.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            TipButon.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            TipButon.Font = new Font("Segoe UI", 9F);
            TipButon.ForeColor = Color.White;
            TipButon.Location = new Point(751, 266);
            TipButon.Name = "TipButon";
            TipButon.ShadowDecoration.CustomizableEdges = customizableEdges8;
            TipButon.Size = new Size(180, 45);
            TipButon.TabIndex = 6;
            TipButon.Text = "guna2Button1";
            TipButon.Click += TipButon_Click;
            // 
            // Payments
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1205, 578);
            Controls.Add(TipButon);
            Controls.Add(TipTxt);
            Controls.Add(UyelikTip);
            Controls.Add(BtnOdeme);
            Controls.Add(TcNo);
            Controls.Add(label1);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Payments";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Payments";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2TextBox TcNo;
        private Guna.UI2.WinForms.Guna2Button BtnOdeme;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow2;
        private ComboBox UyelikTip;
        private Guna.UI2.WinForms.Guna2TextBox TipTxt;
        private Guna.UI2.WinForms.Guna2Button TipButon;
    }
}