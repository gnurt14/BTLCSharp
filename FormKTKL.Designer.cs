namespace QuanLyTienLuong
{
    partial class FormKTKL
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtLyDoKTKL = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.rdbKhong = new System.Windows.Forms.RadioButton();
            this.rdbKhenThuong = new System.Windows.Forms.RadioButton();
            this.rdbKyLuat = new System.Windows.Forms.RadioButton();
            this.LbTenNV = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTienKTKL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbThangNam = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lí do KT/KL";
            // 
            // txtLyDoKTKL
            // 
            this.txtLyDoKTKL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLyDoKTKL.Location = new System.Drawing.Point(186, 152);
            this.txtLyDoKTKL.Multiline = true;
            this.txtLyDoKTKL.Name = "txtLyDoKTKL";
            this.txtLyDoKTKL.Size = new System.Drawing.Size(261, 22);
            this.txtLyDoKTKL.TabIndex = 0;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(218, 246);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(102, 41);
            this.btnThem.TabIndex = 2;
            this.btnThem.Text = "Thêm ";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // rdbKhong
            // 
            this.rdbKhong.AutoSize = true;
            this.rdbKhong.Checked = true;
            this.rdbKhong.Location = new System.Drawing.Point(72, 106);
            this.rdbKhong.Name = "rdbKhong";
            this.rdbKhong.Size = new System.Drawing.Size(66, 20);
            this.rdbKhong.TabIndex = 3;
            this.rdbKhong.TabStop = true;
            this.rdbKhong.Text = "Không";
            this.rdbKhong.UseVisualStyleBackColor = true;
            this.rdbKhong.CheckedChanged += new System.EventHandler(this.rdbKhong_CheckedChanged);
            // 
            // rdbKhenThuong
            // 
            this.rdbKhenThuong.AutoSize = true;
            this.rdbKhenThuong.Location = new System.Drawing.Point(186, 106);
            this.rdbKhenThuong.Name = "rdbKhenThuong";
            this.rdbKhenThuong.Size = new System.Drawing.Size(101, 20);
            this.rdbKhenThuong.TabIndex = 3;
            this.rdbKhenThuong.Text = "Khen thưởng";
            this.rdbKhenThuong.UseVisualStyleBackColor = true;
            // 
            // rdbKyLuat
            // 
            this.rdbKyLuat.AutoSize = true;
            this.rdbKyLuat.Location = new System.Drawing.Point(350, 106);
            this.rdbKyLuat.Name = "rdbKyLuat";
            this.rdbKyLuat.Size = new System.Drawing.Size(67, 20);
            this.rdbKyLuat.TabIndex = 3;
            this.rdbKyLuat.Text = "Kỷ luật";
            this.rdbKyLuat.UseVisualStyleBackColor = true;
            // 
            // LbTenNV
            // 
            this.LbTenNV.AutoSize = true;
            this.LbTenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTenNV.Location = new System.Drawing.Point(75, 59);
            this.LbTenNV.Name = "LbTenNV";
            this.LbTenNV.Size = new System.Drawing.Size(53, 20);
            this.LbTenNV.TabIndex = 4;
            this.LbTenNV.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(75, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tiền KT/KL";
            // 
            // txtTienKTKL
            // 
            this.txtTienKTKL.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienKTKL.Location = new System.Drawing.Point(186, 197);
            this.txtTienKTKL.Multiline = true;
            this.txtTienKTKL.Name = "txtTienKTKL";
            this.txtTienKTKL.Size = new System.Drawing.Size(261, 22);
            this.txtTienKTKL.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(81, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Khen thưởng/ Kỷ luật ";
            // 
            // lbThangNam
            // 
            this.lbThangNam.AutoSize = true;
            this.lbThangNam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThangNam.Location = new System.Drawing.Point(277, 24);
            this.lbThangNam.Name = "lbThangNam";
            this.lbThangNam.Size = new System.Drawing.Size(53, 20);
            this.lbThangNam.TabIndex = 5;
            this.lbThangNam.Text = "label4";
            // 
            // FormKTKL
            // 
            this.AcceptButton = this.btnThem;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 308);
            this.Controls.Add(this.lbThangNam);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LbTenNV);
            this.Controls.Add(this.rdbKyLuat);
            this.Controls.Add(this.rdbKhenThuong);
            this.Controls.Add(this.rdbKhong);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtTienKTKL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtLyDoKTKL);
            this.Controls.Add(this.label1);
            this.Name = "FormKTKL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khen thưởng/ Kỷ luật";
            this.Load += new System.EventHandler(this.FormKTKL_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLyDoKTKL;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.RadioButton rdbKhong;
        private System.Windows.Forms.RadioButton rdbKhenThuong;
        private System.Windows.Forms.RadioButton rdbKyLuat;
        private System.Windows.Forms.Label LbTenNV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTienKTKL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbThangNam;
    }
}