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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            label1 = new Label();
            guna2AnimateWindow1 = new Guna.UI2.WinForms.Guna2AnimateWindow(components);
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            guna2AnimateWindow2 = new Guna.UI2.WinForms.Guna2AnimateWindow(components);
            UyelikTip = new ComboBox();
            TipTxt = new Guna.UI2.WinForms.Guna2TextBox();
            TipButon = new Guna.UI2.WinForms.Guna2Button();
            guna2DataGridView2 = new Guna.UI2.WinForms.Guna2DataGridView();
            panel1 = new Panel();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView2).BeginInit();
            panel1.SuspendLayout();
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
            // UyelikTip
            // 
            UyelikTip.FormattingEnabled = true;
            UyelikTip.Location = new Point(88, 95);
            UyelikTip.Name = "UyelikTip";
            UyelikTip.Size = new Size(121, 23);
            UyelikTip.TabIndex = 4;
            // 
            // TipTxt
            // 
            TipTxt.CustomizableEdges = customizableEdges1;
            TipTxt.DefaultText = "";
            TipTxt.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            TipTxt.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            TipTxt.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            TipTxt.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            TipTxt.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            TipTxt.Font = new Font("Bahnschrift SemiCondensed", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            TipTxt.ForeColor = Color.Black;
            TipTxt.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            TipTxt.Location = new Point(50, 137);
            TipTxt.Margin = new Padding(3, 4, 3, 4);
            TipTxt.Name = "TipTxt";
            TipTxt.PlaceholderText = "";
            TipTxt.SelectedText = "";
            TipTxt.ShadowDecoration.CustomizableEdges = customizableEdges2;
            TipTxt.Size = new Size(207, 34);
            TipTxt.TabIndex = 5;
            // 
            // TipButon
            // 
            TipButon.CustomizableEdges = customizableEdges3;
            TipButon.DisabledState.BorderColor = Color.DarkGray;
            TipButon.DisabledState.CustomBorderColor = Color.DarkGray;
            TipButon.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            TipButon.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            TipButon.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            TipButon.ForeColor = Color.Black;
            TipButon.Location = new Point(61, 213);
            TipButon.Name = "TipButon";
            TipButon.ShadowDecoration.CustomizableEdges = customizableEdges4;
            TipButon.Size = new Size(180, 45);
            TipButon.TabIndex = 6;
            TipButon.Text = "Güncelle";
            TipButon.Click += TipButon_Click_1;
            // 
            // guna2DataGridView2
            // 
            dataGridViewCellStyle1.BackColor = Color.White;
            guna2DataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            guna2DataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            guna2DataGridView2.ColumnHeadersHeight = 40;
            guna2DataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            guna2DataGridView2.DefaultCellStyle = dataGridViewCellStyle3;
            guna2DataGridView2.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView2.Location = new Point(104, 135);
            guna2DataGridView2.Name = "guna2DataGridView2";
            guna2DataGridView2.RowHeadersVisible = false;
            guna2DataGridView2.Size = new Size(294, 300);
            guna2DataGridView2.TabIndex = 7;
            guna2DataGridView2.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            guna2DataGridView2.ThemeStyle.AlternatingRowsStyle.Font = null;
            guna2DataGridView2.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            guna2DataGridView2.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            guna2DataGridView2.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            guna2DataGridView2.ThemeStyle.BackColor = Color.White;
            guna2DataGridView2.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView2.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            guna2DataGridView2.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            guna2DataGridView2.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            guna2DataGridView2.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            guna2DataGridView2.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            guna2DataGridView2.ThemeStyle.HeaderStyle.Height = 40;
            guna2DataGridView2.ThemeStyle.ReadOnly = false;
            guna2DataGridView2.ThemeStyle.RowsStyle.BackColor = Color.White;
            guna2DataGridView2.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            guna2DataGridView2.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            guna2DataGridView2.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            guna2DataGridView2.ThemeStyle.RowsStyle.Height = 25;
            guna2DataGridView2.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            guna2DataGridView2.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // panel1
            // 
            panel1.Controls.Add(label2);
            panel1.Controls.Add(UyelikTip);
            panel1.Controls.Add(TipTxt);
            panel1.Controls.Add(TipButon);
            panel1.Location = new Point(470, 144);
            panel1.Name = "panel1";
            panel1.Size = new Size(291, 276);
            panel1.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(23, 10);
            label2.Name = "label2";
            label2.Size = new Size(248, 23);
            label2.TabIndex = 9;
            label2.Text = "Üyelik Tipi Fiyat Güncelleme";
            // 
            // Payments
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1205, 578);
            Controls.Add(panel1);
            Controls.Add(guna2DataGridView2);
            Controls.Add(label1);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Payments";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Payments";
            Load += Payments_Load;
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView2).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2AnimateWindow guna2AnimateWindow2;
        private ComboBox UyelikTip;
        private Guna.UI2.WinForms.Guna2TextBox TipTxt;
        private Guna.UI2.WinForms.Guna2Button TipButon;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView2;
        private Panel panel1;
        private Label label2;
    }
}