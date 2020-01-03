using System.Drawing;
using AxShockwaveFlashObjects;

namespace PresentDr
{
    partial class Form1
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
        /// 
        // private string usesFont = "B Nazanin";
        private Font font;


        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.t1 = new System.Windows.Forms.Timer(this.components);
            this.t2 = new System.Windows.Forms.Timer(this.components);
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.pnl2 = new System.Windows.Forms.Panel();
            this.ruzha = new System.Windows.Forms.Label();
            this.madrak = new System.Windows.Forms.Label();
            this.biog = new System.Windows.Forms.Label();
            this.farsiName = new System.Windows.Forms.Label();
            this.shNP = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl8 = new System.Windows.Forms.Label();
            this.lbl7 = new System.Windows.Forms.Label();
            this.flashTimer1 = new System.Windows.Forms.Timer(this.components);
            this.picb1 = new System.Windows.Forms.PictureBox();
            this.flashTimer2 = new System.Windows.Forms.Timer(this.components);
            this.lbl_enName = new System.Windows.Forms.Label();
            this.lbl_enSpec = new System.Windows.Forms.Label();
            this.axShockwaveFlash1 = new AxShockwaveFlashObjects.AxShockwaveFlash();
            this.timer_MovieDuration = new System.Windows.Forms.Timer(this.components);
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.timer_flashDuration = new System.Windows.Forms.Timer(this.components);
            this.picB_propaganda = new System.Windows.Forms.PictureBox();
            this.pnl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picb1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picB_propaganda)).BeginInit();
            this.SuspendLayout();
            // 
            // t1
            // 
            this.t1.Enabled = true;
            this.t1.Interval = 500000;
            this.t1.Tick += new System.EventHandler(this.t1_Tick);
            // 
            // t2
            // 
            this.t2.Enabled = true;
            this.t2.Interval = 5000;
            this.t2.Tick += new System.EventHandler(this.t2_Tick);
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Location = new System.Drawing.Point(439, 85);
            this.lbl3.Name = "lbl3";
            this.lbl3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl3.Size = new System.Drawing.Size(103, 19);
            this.lbl3.TabIndex = 5;
            this.lbl3.Text = "نام و نام خانوادگی";
            this.lbl3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbl3.Click += new System.EventHandler(this.lbl3_Click);
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4.Location = new System.Drawing.Point(449, 127);
            this.lbl4.Name = "lbl4";
            this.lbl4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl4.Size = new System.Drawing.Size(93, 19);
            this.lbl4.TabIndex = 7;
            this.lbl4.Text = "مدارک تخصصي";
            this.lbl4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbl4.Click += new System.EventHandler(this.lbl4_Click);
            // 
            // pnl2
            // 
            this.pnl2.BackColor = System.Drawing.Color.Transparent;
            this.pnl2.Controls.Add(this.ruzha);
            this.pnl2.Controls.Add(this.madrak);
            this.pnl2.Controls.Add(this.biog);
            this.pnl2.Controls.Add(this.farsiName);
            this.pnl2.Controls.Add(this.shNP);
            this.pnl2.Controls.Add(this.label1);
            this.pnl2.Controls.Add(this.lbl8);
            this.pnl2.Controls.Add(this.lbl7);
            this.pnl2.Controls.Add(this.lbl4);
            this.pnl2.Controls.Add(this.lbl3);
            this.pnl2.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnl2.Location = new System.Drawing.Point(415, 384);
            this.pnl2.Name = "pnl2";
            this.pnl2.Size = new System.Drawing.Size(599, 384);
            this.pnl2.TabIndex = 0;
            this.pnl2.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl2_Paint);
            // 
            // ruzha
            // 
            this.ruzha.AutoSize = true;
            this.ruzha.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ruzha.Location = new System.Drawing.Point(57, 303);
            this.ruzha.Name = "ruzha";
            this.ruzha.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ruzha.Size = new System.Drawing.Size(54, 19);
            this.ruzha.TabIndex = 16;
            this.ruzha.Text = "label2";
            this.ruzha.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.ruzha.Click += new System.EventHandler(this.ruzha_Click);
            // 
            // madrak
            // 
            this.madrak.AutoSize = true;
            this.madrak.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.madrak.Location = new System.Drawing.Point(53, 127);
            this.madrak.Name = "madrak";
            this.madrak.Size = new System.Drawing.Size(54, 19);
            this.madrak.TabIndex = 15;
            this.madrak.Text = "label2";
            this.madrak.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // biog
            // 
            this.biog.AutoSize = true;
            this.biog.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.biog.Location = new System.Drawing.Point(53, 197);
            this.biog.Name = "biog";
            this.biog.Size = new System.Drawing.Size(54, 19);
            this.biog.TabIndex = 14;
            this.biog.Text = "label2";
            this.biog.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // farsiName
            // 
            this.farsiName.AutoSize = true;
            this.farsiName.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.farsiName.Location = new System.Drawing.Point(53, 85);
            this.farsiName.Name = "farsiName";
            this.farsiName.Size = new System.Drawing.Size(54, 19);
            this.farsiName.TabIndex = 13;
            this.farsiName.Text = "label3";
            this.farsiName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.farsiName.Click += new System.EventHandler(this.label3_Click_1);
            // 
            // shNP
            // 
            this.shNP.AutoSize = true;
            this.shNP.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shNP.Location = new System.Drawing.Point(56, 36);
            this.shNP.Name = "shNP";
            this.shNP.Size = new System.Drawing.Size(51, 19);
            this.shNP.TabIndex = 12;
            this.shNP.Text = "shNP";
            this.shNP.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.shNP.Click += new System.EventHandler(this.shNP_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(438, 176);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(104, 19);
            this.label1.TabIndex = 11;
            this.label1.Text = "بيوگرافي تخصصي";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbl8
            // 
            this.lbl8.AutoSize = true;
            this.lbl8.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl8.Location = new System.Drawing.Point(297, 282);
            this.lbl8.Name = "lbl8";
            this.lbl8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl8.Size = new System.Drawing.Size(245, 19);
            this.lbl8.TabIndex = 9;
            this.lbl8.Text = "روزها و ساعات حضور در کلينيک بيمارستان";
            this.lbl8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbl8.Click += new System.EventHandler(this.label4_Click);
            // 
            // lbl7
            // 
            this.lbl7.AutoSize = true;
            this.lbl7.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl7.Location = new System.Drawing.Point(468, 36);
            this.lbl7.Name = "lbl7";
            this.lbl7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl7.Size = new System.Drawing.Size(74, 19);
            this.lbl7.TabIndex = 8;
            this.lbl7.Text = "نظام پزشکي";
            this.lbl7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbl7.Click += new System.EventHandler(this.label2_Click);
            // 
            // flashTimer1
            // 
            this.flashTimer1.Enabled = true;
            this.flashTimer1.Interval = 14000;
            this.flashTimer1.Tick += new System.EventHandler(this.flashTimer1_Tick);
            // 
            // picb1
            // 
            this.picb1.BackColor = System.Drawing.Color.Transparent;
            this.picb1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picb1.Location = new System.Drawing.Point(12, 214);
            this.picb1.Name = "picb1";
            this.picb1.Size = new System.Drawing.Size(220, 247);
            this.picb1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picb1.TabIndex = 11;
            this.picb1.TabStop = false;
            // 
            // flashTimer2
            // 
            this.flashTimer2.Enabled = true;
            this.flashTimer2.Interval = 5000;
            this.flashTimer2.Tick += new System.EventHandler(this.flashTimer2_Tick);
            // 
            // lbl_enName
            // 
            this.lbl_enName.AutoSize = true;
            this.lbl_enName.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_enName.Location = new System.Drawing.Point(8, 474);
            this.lbl_enName.Name = "lbl_enName";
            this.lbl_enName.Size = new System.Drawing.Size(30, 19);
            this.lbl_enName.TabIndex = 14;
            this.lbl_enName.Text = "Dr.";
            // 
            // lbl_enSpec
            // 
            this.lbl_enSpec.AutoSize = true;
            this.lbl_enSpec.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_enSpec.Location = new System.Drawing.Point(9, 493);
            this.lbl_enSpec.Name = "lbl_enSpec";
            this.lbl_enSpec.Size = new System.Drawing.Size(54, 19);
            this.lbl_enSpec.TabIndex = 15;
            this.lbl_enSpec.Text = "label2";
            // 
            // axShockwaveFlash1
            // 
            this.axShockwaveFlash1.Enabled = true;
            this.axShockwaveFlash1.Location = new System.Drawing.Point(-521, -176);
            this.axShockwaveFlash1.Name = "axShockwaveFlash1";
            this.axShockwaveFlash1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axShockwaveFlash1.OcxState")));
            this.axShockwaveFlash1.Size = new System.Drawing.Size(765, 706);
            this.axShockwaveFlash1.TabIndex = 16;
            this.axShockwaveFlash1.Visible = false;
            this.axShockwaveFlash1.Enter += new System.EventHandler(this.axShockwaveFlash1_Enter_1);
            // 
            // timer_MovieDuration
            // 
            this.timer_MovieDuration.Interval = 3000;
            this.timer_MovieDuration.Tick += new System.EventHandler(this.timer_MovieDuration_Tick_1);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(-713, -196);
            this.axWindowsMediaPlayer1.Margin = new System.Windows.Forms.Padding(0);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(993, 726);
            this.axWindowsMediaPlayer1.TabIndex = 18;
            this.axWindowsMediaPlayer1.TabStop = false;
            this.axWindowsMediaPlayer1.Visible = false;
            this.axWindowsMediaPlayer1.Enter += new System.EventHandler(this.axWindowsMediaPlayer1_Enter_1);
            // 
            // timer_flashDuration
            // 
            this.timer_flashDuration.Interval = 10;
            this.timer_flashDuration.Tick += new System.EventHandler(this.timer_flashDuration_Tick);
            // 
            // picB_propaganda
            // 
            this.picB_propaganda.BackColor = System.Drawing.Color.Transparent;
            this.picB_propaganda.Location = new System.Drawing.Point(-883, -196);
            this.picB_propaganda.Name = "picB_propaganda";
            this.picB_propaganda.Size = new System.Drawing.Size(1367, 780);
            this.picB_propaganda.TabIndex = 0;
            this.picB_propaganda.TabStop = false;
            this.picB_propaganda.Visible = false;
            this.picB_propaganda.Click += new System.EventHandler(this.picB_propaganda_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::PresentDr.Properties.Resources.payambaran11;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1036, 780);
            this.Controls.Add(this.picB_propaganda);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.axShockwaveFlash1);
            this.Controls.Add(this.lbl_enSpec);
            this.Controls.Add(this.lbl_enName);
            this.Controls.Add(this.picb1);
            this.Controls.Add(this.pnl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnl2.ResumeLayout(false);
            this.pnl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picb1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axShockwaveFlash1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picB_propaganda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer t1;
        private System.Windows.Forms.Timer t2;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Panel pnl2;
        private System.Windows.Forms.Label lbl7;
        private System.Windows.Forms.Label lbl8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer flashTimer1;
        private System.Windows.Forms.PictureBox picb1;
        private System.Windows.Forms.Timer flashTimer2;
        private System.Windows.Forms.Label farsiName;
        private System.Windows.Forms.Label shNP;
        private System.Windows.Forms.Label ruzha;
        private System.Windows.Forms.Label madrak;
        private System.Windows.Forms.Label biog;
        private System.Windows.Forms.Label lbl_enName;
        private System.Windows.Forms.Label lbl_enSpec;
        private AxShockwaveFlashObjects.AxShockwaveFlash axShockwaveFlash1;
        private ShockwaveFlashObjects.IShockwaveFlash ocx;
        private System.Windows.Forms.Timer timer_MovieDuration;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.Timer timer_flashDuration;
        private System.Windows.Forms.PictureBox picB_propaganda;
    }
}

