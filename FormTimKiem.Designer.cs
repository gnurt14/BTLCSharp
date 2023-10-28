namespace QuanLyTienLuong
{
    partial class FormTimKiem
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
            this.dgvTimKiem = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.cmbHeSoLuong = new System.Windows.Forms.ComboBox();
            this.cmbChuyenMon = new System.Windows.Forms.ComboBox();
            this.cmbTrinhDo = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiem)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTimKiem
            // 
            this.dgvTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTimKiem.BackgroundColor = System.Drawing.Color.White;
            this.dgvTimKiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimKiem.Location = new System.Drawing.Point(29, 154);
            this.dgvTimKiem.Name = "dgvTimKiem";
            this.dgvTimKiem.RowHeadersWidth = 51;
            this.dgvTimKiem.RowTemplate.Height = 24;
            this.dgvTimKiem.Size = new System.Drawing.Size(1002, 454);
            this.dgvTimKiem.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SVN-Nexa Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Họ tên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SVN-Nexa Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(449, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chuyên môn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SVN-Nexa Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 29);
            this.label3.TabIndex = 1;
            this.label3.Text = "Trình độ ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SVN-Nexa Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(449, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 29);
            this.label4.TabIndex = 1;
            this.label4.Text = "Hệ số lương";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Font = new System.Drawing.Font("SVN-Nexa Light", 12F);
            this.txtHoTen.Location = new System.Drawing.Point(132, 41);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(277, 35);
            this.txtHoTen.TabIndex = 2;
            // 
            // cmbHeSoLuong
            // 
            this.cmbHeSoLuong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHeSoLuong.Font = new System.Drawing.Font("SVN-Nexa Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbHeSoLuong.FormattingEnabled = true;
            this.cmbHeSoLuong.Location = new System.Drawing.Point(582, 41);
            this.cmbHeSoLuong.Name = "cmbHeSoLuong";
            this.cmbHeSoLuong.Size = new System.Drawing.Size(237, 37);
            this.cmbHeSoLuong.TabIndex = 3;
            // 
            // cmbChuyenMon
            // 
            this.cmbChuyenMon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChuyenMon.Font = new System.Drawing.Font("SVN-Nexa Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbChuyenMon.FormattingEnabled = true;
            this.cmbChuyenMon.Location = new System.Drawing.Point(582, 90);
            this.cmbChuyenMon.Name = "cmbChuyenMon";
            this.cmbChuyenMon.Size = new System.Drawing.Size(237, 37);
            this.cmbChuyenMon.TabIndex = 5;
            // 
            // cmbTrinhDo
            // 
            this.cmbTrinhDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrinhDo.Font = new System.Drawing.Font("SVN-Nexa Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTrinhDo.FormattingEnabled = true;
            this.cmbTrinhDo.Location = new System.Drawing.Point(132, 90);
            this.cmbTrinhDo.Name = "cmbTrinhDo";
            this.cmbTrinhDo.Size = new System.Drawing.Size(277, 37);
            this.cmbTrinhDo.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(208)))), ((int)(((byte)(168)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(172)))), ((int)(((byte)(255)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(172)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("SVN-Nexa Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::QuanLyTienLuong.Properties.Resources.icons8_search_25__2_;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(881, 80);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(150, 50);
            this.button1.TabIndex = 4;
            this.button1.Text = "Tìm kiếm";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // FormTimKiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1071, 620);
            this.Controls.Add(this.cmbTrinhDo);
            this.Controls.Add(this.cmbChuyenMon);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbHeSoLuong);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTimKiem);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(53)))));
            this.Name = "FormTimKiem";
            this.Text = "FormTimKiem";
            this.Load += new System.EventHandler(this.FormTimKiem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimKiem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTimKiem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.ComboBox cmbHeSoLuong;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbChuyenMon;
        private System.Windows.Forms.ComboBox cmbTrinhDo;
    }
}