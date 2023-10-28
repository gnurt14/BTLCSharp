namespace QuanLyTienLuong
{
    partial class FormDangNhap
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
            this.txtUserLogin = new System.Windows.Forms.TextBox();
            this.txtPasswordLogin = new System.Windows.Forms.TextBox();
            this.lbLoginFail = new System.Windows.Forms.Label();
            this.ptbLogo = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMinimizeDashboard = new System.Windows.Forms.Button();
            this.btnCloseDashboard = new System.Windows.Forms.Button();
            this.btnDangNhap = new QuanLyTienLuong.CustomButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUserLogin
            // 
            this.txtUserLogin.Font = new System.Drawing.Font("SVN-Sari", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserLogin.Location = new System.Drawing.Point(145, 358);
            this.txtUserLogin.Name = "txtUserLogin";
            this.txtUserLogin.Size = new System.Drawing.Size(279, 35);
            this.txtUserLogin.TabIndex = 0;
            this.txtUserLogin.Text = "Tên đăng nhập";
            this.txtUserLogin.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtUserLogin_MouseClick);
            this.txtUserLogin.TextChanged += new System.EventHandler(this.txtUserLogin_TextChanged);
            // 
            // txtPasswordLogin
            // 
            this.txtPasswordLogin.Font = new System.Drawing.Font("SVN-Sari", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasswordLogin.Location = new System.Drawing.Point(145, 407);
            this.txtPasswordLogin.Name = "txtPasswordLogin";
            this.txtPasswordLogin.PasswordChar = '*';
            this.txtPasswordLogin.Size = new System.Drawing.Size(279, 35);
            this.txtPasswordLogin.TabIndex = 1;
            this.txtPasswordLogin.TextChanged += new System.EventHandler(this.txtPasswordLogin_TextChanged);
            // 
            // lbLoginFail
            // 
            this.lbLoginFail.AutoSize = true;
            this.lbLoginFail.Font = new System.Drawing.Font("SVN-Nexa Light", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLoginFail.ForeColor = System.Drawing.Color.Red;
            this.lbLoginFail.Location = new System.Drawing.Point(116, 456);
            this.lbLoginFail.Name = "lbLoginFail";
            this.lbLoginFail.Size = new System.Drawing.Size(335, 25);
            this.lbLoginFail.TabIndex = 7;
            this.lbLoginFail.Text = "Tài khoản hoặc mật khẩu không chính xác";
            // 
            // ptbLogo
            // 
            this.ptbLogo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ptbLogo.BackgroundImage = global::QuanLyTienLuong.Properties.Resources.VNPT_Logo_svg;
            this.ptbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ptbLogo.Location = new System.Drawing.Point(184, 100);
            this.ptbLogo.Name = "ptbLogo";
            this.ptbLogo.Size = new System.Drawing.Size(181, 143);
            this.ptbLogo.TabIndex = 6;
            this.ptbLogo.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::QuanLyTienLuong.Properties.Resources.icons8_lock_48;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(89, 407);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::QuanLyTienLuong.Properties.Resources.icons8_user_40;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(89, 358);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnMinimizeDashboard
            // 
            this.btnMinimizeDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizeDashboard.BackColor = System.Drawing.Color.Transparent;
            this.btnMinimizeDashboard.FlatAppearance.BorderSize = 0;
            this.btnMinimizeDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizeDashboard.Image = global::QuanLyTienLuong.Properties.Resources.icons8_minimize_window_30__1_;
            this.btnMinimizeDashboard.Location = new System.Drawing.Point(481, 3);
            this.btnMinimizeDashboard.Name = "btnMinimizeDashboard";
            this.btnMinimizeDashboard.Size = new System.Drawing.Size(30, 30);
            this.btnMinimizeDashboard.TabIndex = 4;
            this.btnMinimizeDashboard.TabStop = false;
            this.btnMinimizeDashboard.UseVisualStyleBackColor = false;
            this.btnMinimizeDashboard.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnCloseDashboard
            // 
            this.btnCloseDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseDashboard.BackColor = System.Drawing.Color.Transparent;
            this.btnCloseDashboard.FlatAppearance.BorderSize = 0;
            this.btnCloseDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseDashboard.Image = global::QuanLyTienLuong.Properties.Resources.icons8_close_window_30;
            this.btnCloseDashboard.Location = new System.Drawing.Point(511, 3);
            this.btnCloseDashboard.Name = "btnCloseDashboard";
            this.btnCloseDashboard.Size = new System.Drawing.Size(30, 30);
            this.btnCloseDashboard.TabIndex = 5;
            this.btnCloseDashboard.TabStop = false;
            this.btnCloseDashboard.UseVisualStyleBackColor = false;
            this.btnCloseDashboard.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDangNhap
            // 
            this.btnDangNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(148)))), ((int)(((byte)(240)))));
            this.btnDangNhap.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(148)))), ((int)(((byte)(240)))));
            this.btnDangNhap.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnDangNhap.BorderRadius = 40;
            this.btnDangNhap.BorderSize = 0;
            this.btnDangNhap.FlatAppearance.BorderSize = 0;
            this.btnDangNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangNhap.Font = new System.Drawing.Font("SVN-Sari", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangNhap.ForeColor = System.Drawing.Color.White;
            this.btnDangNhap.Location = new System.Drawing.Point(180, 495);
            this.btnDangNhap.Name = "btnDangNhap";
            this.btnDangNhap.Size = new System.Drawing.Size(184, 53);
            this.btnDangNhap.TabIndex = 2;
            this.btnDangNhap.Text = "Đăng nhập";
            this.btnDangNhap.TextColor = System.Drawing.Color.White;
            this.btnDangNhap.UseVisualStyleBackColor = false;
            this.btnDangNhap.Click += new System.EventHandler(this.btnDangNhap_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(36)))), ((int)(((byte)(77)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCloseDashboard);
            this.panel1.Controls.Add(this.btnMinimizeDashboard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(544, 42);
            this.panel1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SVN-Cintra", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Menu;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Phần mềm quản lý tiền lương";
            // 
            // FormDangNhap
            // 
            this.AcceptButton = this.btnDangNhap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(544, 719);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDangNhap);
            this.Controls.Add(this.lbLoginFail);
            this.Controls.Add(this.ptbLogo);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtPasswordLogin);
            this.Controls.Add(this.txtUserLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(544, 719);
            this.Name = "FormDangNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormDangNhap";
            this.Load += new System.EventHandler(this.FormDangNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtUserLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox txtPasswordLogin;
        private System.Windows.Forms.PictureBox ptbLogo;
        private System.Windows.Forms.Label lbLoginFail;
        private System.Windows.Forms.Button btnMinimizeDashboard;
        private System.Windows.Forms.Button btnCloseDashboard;
        private CustomButton btnDangNhap;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}