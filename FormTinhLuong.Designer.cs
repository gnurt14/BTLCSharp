namespace QuanLyTienLuong
{
    partial class FormTinhLuong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPhongBan = new System.Windows.Forms.ComboBox();
            this.dgvTinhLuong = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbThang = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNam = new System.Windows.Forms.ComboBox();
            this.btnTinhLuong = new System.Windows.Forms.Button();
            this.btnInBangLuongNV = new System.Windows.Forms.Button();
            this.InLuongPhongBan = new System.Windows.Forms.Button();
            this.btnBaoCaoLuong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTinhLuong)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SVN-Nexa Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(714, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Phòng ban ";
            // 
            // cmbPhongBan
            // 
            this.cmbPhongBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPhongBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPhongBan.Font = new System.Drawing.Font("SVN-Nexa Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPhongBan.FormattingEnabled = true;
            this.cmbPhongBan.Location = new System.Drawing.Point(823, 31);
            this.cmbPhongBan.Name = "cmbPhongBan";
            this.cmbPhongBan.Size = new System.Drawing.Size(239, 37);
            this.cmbPhongBan.TabIndex = 1;
            // 
            // dgvTinhLuong
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Empty;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(172)))), ((int)(((byte)(255)))));
            this.dgvTinhLuong.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTinhLuong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTinhLuong.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(208)))), ((int)(((byte)(168)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(172)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTinhLuong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTinhLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(172)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTinhLuong.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTinhLuong.Location = new System.Drawing.Point(12, 12);
            this.dgvTinhLuong.Name = "dgvTinhLuong";
            this.dgvTinhLuong.ReadOnly = true;
            this.dgvTinhLuong.RowHeadersWidth = 51;
            this.dgvTinhLuong.RowTemplate.Height = 24;
            this.dgvTinhLuong.Size = new System.Drawing.Size(693, 596);
            this.dgvTinhLuong.TabIndex = 6;
            this.dgvTinhLuong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTinhLuong_CellClick);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SVN-Nexa Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(715, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tháng";
            // 
            // cmbThang
            // 
            this.cmbThang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbThang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbThang.Font = new System.Drawing.Font("SVN-Nexa Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbThang.FormattingEnabled = true;
            this.cmbThang.Items.AddRange(new object[] {
            "Tháng 1 ",
            "Tháng 2 ",
            "Tháng 3",
            "Tháng 4",
            "Tháng 5",
            "Tháng 6",
            "Tháng 7\t",
            "Tháng 8",
            "Tháng 9",
            "Tháng 10",
            "Tháng 11",
            "Tháng 12"});
            this.cmbThang.Location = new System.Drawing.Point(824, 92);
            this.cmbThang.Name = "cmbThang";
            this.cmbThang.Size = new System.Drawing.Size(159, 37);
            this.cmbThang.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SVN-Nexa Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(720, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Năm";
            // 
            // cmbNam
            // 
            this.cmbNam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbNam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNam.Font = new System.Drawing.Font("SVN-Nexa Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNam.FormattingEnabled = true;
            this.cmbNam.Items.AddRange(new object[] {
            "2023",
            "2024"});
            this.cmbNam.Location = new System.Drawing.Point(825, 150);
            this.cmbNam.Name = "cmbNam";
            this.cmbNam.Size = new System.Drawing.Size(144, 37);
            this.cmbNam.TabIndex = 1;
            // 
            // btnTinhLuong
            // 
            this.btnTinhLuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTinhLuong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(208)))), ((int)(((byte)(168)))));
            this.btnTinhLuong.FlatAppearance.BorderSize = 0;
            this.btnTinhLuong.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(172)))), ((int)(((byte)(255)))));
            this.btnTinhLuong.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(172)))), ((int)(((byte)(255)))));
            this.btnTinhLuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTinhLuong.Font = new System.Drawing.Font("SVN-Nexa Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTinhLuong.Image = global::QuanLyTienLuong.Properties.Resources.icons8_accept_25;
            this.btnTinhLuong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTinhLuong.Location = new System.Drawing.Point(746, 247);
            this.btnTinhLuong.Name = "btnTinhLuong";
            this.btnTinhLuong.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnTinhLuong.Size = new System.Drawing.Size(291, 58);
            this.btnTinhLuong.TabIndex = 5;
            this.btnTinhLuong.Text = "Tính lương phòng ban";
            this.btnTinhLuong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTinhLuong.UseVisualStyleBackColor = false;
            this.btnTinhLuong.Click += new System.EventHandler(this.btnTinhLuong_Click);
            // 
            // btnInBangLuongNV
            // 
            this.btnInBangLuongNV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInBangLuongNV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(208)))), ((int)(((byte)(168)))));
            this.btnInBangLuongNV.FlatAppearance.BorderSize = 0;
            this.btnInBangLuongNV.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(172)))), ((int)(((byte)(255)))));
            this.btnInBangLuongNV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(172)))), ((int)(((byte)(255)))));
            this.btnInBangLuongNV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInBangLuongNV.Font = new System.Drawing.Font("SVN-Nexa Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInBangLuongNV.Image = global::QuanLyTienLuong.Properties.Resources.icons8_printer_25;
            this.btnInBangLuongNV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInBangLuongNV.Location = new System.Drawing.Point(746, 374);
            this.btnInBangLuongNV.Name = "btnInBangLuongNV";
            this.btnInBangLuongNV.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnInBangLuongNV.Size = new System.Drawing.Size(291, 58);
            this.btnInBangLuongNV.TabIndex = 7;
            this.btnInBangLuongNV.Text = "In bảng lương nhân viên";
            this.btnInBangLuongNV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInBangLuongNV.UseVisualStyleBackColor = false;
            this.btnInBangLuongNV.Click += new System.EventHandler(this.btnInBangLuongNV_Click);
            // 
            // InLuongPhongBan
            // 
            this.InLuongPhongBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InLuongPhongBan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(208)))), ((int)(((byte)(168)))));
            this.InLuongPhongBan.FlatAppearance.BorderSize = 0;
            this.InLuongPhongBan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(172)))), ((int)(((byte)(255)))));
            this.InLuongPhongBan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(172)))), ((int)(((byte)(255)))));
            this.InLuongPhongBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.InLuongPhongBan.Font = new System.Drawing.Font("SVN-Nexa Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InLuongPhongBan.Image = global::QuanLyTienLuong.Properties.Resources.icons8_printer_25;
            this.InLuongPhongBan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InLuongPhongBan.Location = new System.Drawing.Point(746, 311);
            this.InLuongPhongBan.Name = "InLuongPhongBan";
            this.InLuongPhongBan.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.InLuongPhongBan.Size = new System.Drawing.Size(291, 58);
            this.InLuongPhongBan.TabIndex = 8;
            this.InLuongPhongBan.Text = "In bảng lương phòng ban";
            this.InLuongPhongBan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.InLuongPhongBan.UseVisualStyleBackColor = false;
            this.InLuongPhongBan.Click += new System.EventHandler(this.btnInBangLuongPhongBan_Click);
            // 
            // btnBaoCaoLuong
            // 
            this.btnBaoCaoLuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBaoCaoLuong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(208)))), ((int)(((byte)(168)))));
            this.btnBaoCaoLuong.FlatAppearance.BorderSize = 0;
            this.btnBaoCaoLuong.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(172)))), ((int)(((byte)(255)))));
            this.btnBaoCaoLuong.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(172)))), ((int)(((byte)(255)))));
            this.btnBaoCaoLuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoCaoLuong.Font = new System.Drawing.Font("SVN-Nexa Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaoCaoLuong.Image = global::QuanLyTienLuong.Properties.Resources.icons8_printer_25;
            this.btnBaoCaoLuong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCaoLuong.Location = new System.Drawing.Point(746, 438);
            this.btnBaoCaoLuong.Name = "btnBaoCaoLuong";
            this.btnBaoCaoLuong.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnBaoCaoLuong.Size = new System.Drawing.Size(291, 58);
            this.btnBaoCaoLuong.TabIndex = 7;
            this.btnBaoCaoLuong.Text = "Báo cáo lương tháng  ";
            this.btnBaoCaoLuong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBaoCaoLuong.UseVisualStyleBackColor = false;
            this.btnBaoCaoLuong.Click += new System.EventHandler(this.btnBaoCaoLuong_Click);
            // 
            // FormTinhLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1071, 620);
            this.Controls.Add(this.InLuongPhongBan);
            this.Controls.Add(this.btnBaoCaoLuong);
            this.Controls.Add(this.btnInBangLuongNV);
            this.Controls.Add(this.dgvTinhLuong);
            this.Controls.Add(this.btnTinhLuong);
            this.Controls.Add(this.cmbNam);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbThang);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbPhongBan);
            this.Controls.Add(this.label1);
            this.Name = "FormTinhLuong";
            this.Text = "FormTinhLuong";
            this.Load += new System.EventHandler(this.FormTinhLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTinhLuong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPhongBan;
        private System.Windows.Forms.Button btnTinhLuong;
        private System.Windows.Forms.DataGridView dgvTinhLuong;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbThang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbNam;
        private System.Windows.Forms.Button btnInBangLuongNV;
        private System.Windows.Forms.Button InLuongPhongBan;
        private System.Windows.Forms.Button btnBaoCaoLuong;
    }
}