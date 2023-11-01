using CrystalDecisions.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTienLuong
{
    public partial class FormBaoCaoTienLuong : Form
    {

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OI20CUM\ADMIN;Initial Catalog=QuanLyTinhLuong;User ID=sa;Password=1");
        SqlCommand command;
        SqlDataAdapter adapterData = new SqlDataAdapter();
        DataTable dt = new DataTable();
        public FormBaoCaoTienLuong()
        {
            InitializeComponent();
        }
        private void FormBaoCaoTienLuong_Load(object sender, EventArgs e)
        {

        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            if (cmbThang.SelectedItem != null)
            {
                string[] parts = cmbThang.Text.Split(' ');
                string thang = parts[parts.Length - 1];
                con.Open();
                command = con.CreateCommand();
                command.CommandText = "select tenphongban,hoten, thuclinh, phucapcv, thang from HoSoNhanVien hs \r\njoin luong on hs.manhanvien = luong.manhanvien\r\njoin NhanVienChucVu on hs.manhanvien = NhanVienChucVu.manhanvien\r\njoin chucvu on NhanVienChucVu.machucvu = chucvu.machucvu\r\njoin PhongBan on hs.MaPhongBan = PhongBan.MaPhongBan where thang = @thang";
                command.Parameters.AddWithValue("@thang", thang);
                adapterData.SelectCommand = command;
                dt.Clear();
                adapterData.Fill(dt);

                rptTinhLuong rpt = new rptTinhLuong();
                rpt.SetDataSource(dt);

                crystalReportViewer1.ReportSource = rpt;
                con.Close();
            }
            else
            {
                CustomMessageBox.Show("Vui lòng chọn tháng tạo báo cáo.", "Thông báo");
            }
        }
    }
}
