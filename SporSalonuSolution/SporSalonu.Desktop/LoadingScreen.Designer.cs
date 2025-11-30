namespace SporSalonu.Desktop
{
    partial class LoadingScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoadingScreen));
            guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(components);
            guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
            guna2CircleProgressBar1 = new Guna.UI2.WinForms.Guna2CircleProgressBar();
            label_Val = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            panel1 = new Panel();
            label2 = new Label();
            guna2CircleProgressBar1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // guna2DragControl1
            // 
            guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            guna2DragControl1.TargetControl = panel1;
            guna2DragControl1.UseTransparentDrag = true;
            // 
            // guna2CircleProgressBar1
            // 
            guna2CircleProgressBar1.Animated = true;
            guna2CircleProgressBar1.AnimationSpeed = 0.2F;
            guna2CircleProgressBar1.BackColor = Color.Black;
            guna2CircleProgressBar1.Controls.Add(label2);
            guna2CircleProgressBar1.Controls.Add(label_Val);
            guna2CircleProgressBar1.Controls.Add(label1);
            guna2CircleProgressBar1.Controls.Add(pictureBox1);
            guna2CircleProgressBar1.FillColor = Color.Black;
            guna2CircleProgressBar1.FillThickness = 777;
            guna2CircleProgressBar1.Font = new Font("Segoe UI", 12F);
            guna2CircleProgressBar1.ForeColor = Color.Black;
            guna2CircleProgressBar1.Location = new Point(80, -372);
            guna2CircleProgressBar1.Minimum = 0;
            guna2CircleProgressBar1.Name = "guna2CircleProgressBar1";
            guna2CircleProgressBar1.ProgressColor = Color.FromArgb(255, 177, 15);
            guna2CircleProgressBar1.ProgressColor2 = Color.FromArgb(255, 177, 15);
            guna2CircleProgressBar1.ProgressThickness = 505;
            guna2CircleProgressBar1.ShadowDecoration.CustomizableEdges = customizableEdges1;
            guna2CircleProgressBar1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            guna2CircleProgressBar1.Size = new Size(1284, 1284);
            guna2CircleProgressBar1.TabIndex = 10;
            guna2CircleProgressBar1.Text = "guna2CircleProgressBar1";
            // 
            // label_Val
            // 
            label_Val.AutoSize = true;
            label_Val.BackColor = Color.Transparent;
            label_Val.Font = new Font("Bahnschrift", 72F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label_Val.ForeColor = Color.White;
            label_Val.Location = new Point(183, 690);
            label_Val.Name = "label_Val";
            label_Val.Size = new Size(102, 115);
            label_Val.TabIndex = 2;
            label_Val.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.White;
            label1.Location = new Point(586, 707);
            label1.Name = "label1";
            label1.Size = new Size(123, 25);
            label1.TabIndex = 1;
            label1.Text = "Yükleniyor...";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(563, 530);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(178, 177);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            timer1.Interval = 35;
            timer1.Tick += timer1_Tick;
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 20;
            guna2Elipse1.TargetControl = this;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.ForeColor = Color.Transparent;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1106, 16);
            panel1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Bahnschrift", 36F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.ForeColor = Color.White;
            label2.Location = new Point(180, 462);
            label2.Name = "label2";
            label2.Size = new Size(323, 58);
            label2.TabIndex = 3;
            label2.Text = "HOŞGELDİNİZ";
            // 
            // LoadingScreen
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1106, 546);
            Controls.Add(panel1);
            Controls.Add(guna2CircleProgressBar1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoadingScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoadingScreen";
            TransparencyKey = Color.Lime;
            Load += LoadingScreen_Load;
            guna2CircleProgressBar1.ResumeLayout(false);
            guna2CircleProgressBar1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2CircleProgressBar guna2CircleProgressBar1;
        private PictureBox pictureBox1;
        private Label label1;
        private Label label_Val;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Panel panel1;
        private Label label2;
    }
}