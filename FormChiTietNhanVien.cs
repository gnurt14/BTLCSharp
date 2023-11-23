using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using System.Globalization;
using System.Runtime.InteropServices;
using System.CodeDom;

namespace QuanLyTienLuong
{
    public partial class FormChiTietNhanVien : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OI20CUM\ADMIN;Initial Catalog=QuanLyTinhLuong;User ID=sa;Password=1"); 
        string manhanvien;
        bool isUpdateNV;
        HoSoNhanVien nhanVien = new HoSoNhanVien();
        public FormChiTietNhanVien(string manv, bool isUpdate)
        {
            manhanvien = manv;
            isUpdateNV = isUpdate;
            InitializeComponent();
            if (isUpdateNV == false)
            {
                btnThemMoi.Enabled = true;
                btnCapNhat.Enabled = false;
                btnLamMoi.Enabled = true;
            }
            else
            {
                btnCapNhat.Enabled = true;
                btnThemMoi.Enabled = false;
                btnLamMoi.Enabled = false;
            }
        }
        private void btnCloseDashboard_Click(object sender, EventArgs e)
        {

        }
        void Load_Combobox()
        {
            con.Open();
            string querycm = "select tenchuyenmon from chuyenmon";
            string queryhsl = "select mahesoluong from hesoluong";
            string querytd = "select tentrinhdo from trinhdo";
            string queryns = "select tennoisinh from noisinh";
            string querydt = "select tendantoc from dantoc";
            string querypb = "select tenphongban from phongban";
            string querycv = "select tenchucvu from chucvu";
            using (SqlCommand command = new SqlCommand(querypb, con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string item = reader["tenphongban"].ToString();
                        cmbPhongBan.Items.Add(item);
                    }
                }
            }
            using (SqlCommand command = new SqlCommand(querydt, con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string item = reader["tendantoc"].ToString();
                        cmbDanToc.Items.Add(item);
                    }
                }
            }
            using (SqlCommand command = new SqlCommand(queryns, con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string item = reader["tennoisinh"].ToString();
                        cmbNoiSinh.Items.Add(item);
                    }
                }
            }
            using (SqlCommand command = new SqlCommand(queryhsl, con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string item = "HSL Bậc " + reader["mahesoluong"].ToString();
                        cmbHeSoLuong.Items.Add(item);
                    }
                }
            }
            using (SqlCommand command = new SqlCommand(querytd, con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string item = reader["tentrinhdo"].ToString();
                        cmbTrinhDo.Items.Add(item);
                    }
                }
            }
            using (SqlCommand command = new SqlCommand(querycm, con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string item = reader["tenchuyenmon"].ToString();
                        cmbChuyenMon.Items.Add(item);
                    }
                }
            }
            using (SqlCommand command = new SqlCommand(querycv, con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string item = reader["tenchucvu"].ToString();
                        cmbChucVu.Items.Add(item);
                    }
                }
            }

            if (con.State == ConnectionState.Open)
            {
                con.Close();
                con.Dispose();
            }
        }
        private void FormChiTietNhanVien_Load(object sender, EventArgs e)
        {
            Load_Combobox();
            con.ConnectionString = @"Data Source=DESKTOP-OI20CUM\ADMIN;Initial Catalog=QuanLyTinhLuong;User ID=sa;Password=1";
            if (manhanvien != null)
            {
                txtMaNV.Enabled = false;
                string query = "select hs.manhanvien, hoten, ngaysinh,gioitinh,tennoisinh, tendantoc, hs.dienthoai,diachi, ngayvaocongty, \r\ntenphongban,tenchuyenmon, tentrinhdo, ntd.ngayapdung as n1, hesoluong.mahesoluong, nvl.ngayapdung as n2 , tenchucvu, ncv.ngayapdung as n3 from hosonhanvien hs \r\njoin noisinh on hs.manoisinh = noisinh.manoisinh\r\njoin dantoc on hs.madantoc = dantoc.madantoc\r\njoin phongban on hs.maphongban = phongban.maphongban\r\njoin chuyenmon on hs.machuyenmon = chuyenmon.Machuyenmon\r\njoin nhanvientrinhdo ntd on hs.manhanvien = ntd.manhanvien\r\njoin trinhdo on ntd.matrinhdo = trinhdo.Matrinhdo\r\njoin nhanvienhesoluong nvl on nvl.manhanvien = hs.manhanvien\r\njoin hesoluong on nvl.mahesoluong = hesoluong.mahesoluong\r\njoin NhanVienChucVu ncv on ncv.manhanvien = hs.manhanvien\r\njoin chucvu on ncv.machucvu = chucvu.machucvu" +
                    "\r\nwhere hs.manhanvien = N'" + manhanvien + "'";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string hoten = reader["hoten"].ToString();
                        DateTime ngaysinh = (DateTime)reader["ngaysinh"];
                        string gioitinh = reader["gioitinh"].ToString();
                        string tennoisinh = reader["tennoisinh"].ToString();
                        string tendantoc = reader["tendantoc"].ToString();
                        string dienthoai = reader["dienthoai"].ToString();
                        string diachi = reader["diachi"].ToString();
                        DateTime ngayvaocongty = (DateTime)reader["ngayvaocongty"];
                        string tenphongban = reader["tenphongban"].ToString();
                        string tenchuyenmon = reader["tenchuyenmon"].ToString();
                        string tentrinhdo = reader["tentrinhdo"].ToString();
                        string tenhsl = "HSL Bậc " + reader["mahesoluong"].ToString();
                        string chucvu = reader["tenchucvu"].ToString();
                        DateTime ngayapdungtrinhdo = (DateTime)reader["n1"];
                        DateTime ngayapdunghsl = (DateTime)reader["n2"];
                        DateTime ngayapdungchucvu = (DateTime)reader["n3"];

                        txtMaNV.Text = manhanvien;
                        nhanVien.NoiSinh = cmbNoiSinh.Text = reader["tennoisinh"].ToString();
                        nhanVien.DanToc = cmbDanToc.Text = reader["tendantoc"].ToString();
                        nhanVien.HoTen = txtHoTen.Text = reader["hoten"].ToString();
                        nhanVien.NgaySinh = mtbNgaySinh.Text = ((DateTime)reader["ngaysinh"]).ToString("dd/MM/yyyy");
                        nhanVien.GioiTinh = cmbGioiTinh.Text = reader["gioitinh"].ToString();
                        nhanVien.SDT = txtDienThoai.Text = reader["dienthoai"].ToString();
                        nhanVien.DiaChi = txtDiaChi.Text = reader["diachi"].ToString();
                        nhanVien.NgayVaoCongTy = mtbNgayVaoCongTy.Text = ((DateTime)reader["ngayvaocongty"]).ToString("dd/MM/yyyy");
                        nhanVien.PhongBan = cmbPhongBan.Text = reader["tenphongban"].ToString();
                        nhanVien.ChuyenMon = cmbChuyenMon.Text = reader["tenchuyenmon"].ToString();
                        nhanVien.TrinhDo = cmbTrinhDo.Text = reader["tentrinhdo"].ToString();
                        nhanVien.HeSoLuong = cmbHeSoLuong.Text = "HSL Bậc " + reader["mahesoluong"].ToString();
                        nhanVien.ChucVu = cmbChucVu.Text = reader["tenchucvu"].ToString();
                        nhanVien.NgayApDungHSL = mtbNgayApDungHSL.Text = ((DateTime)reader["n2"]).ToString("dd/MM/yyyy");
                        nhanVien.NgayApDungTD = mtbNgayApDungTD.Text = ((DateTime)reader["n1"]).ToString("dd/MM/yyyy");
                        nhanVien.NgayNhamChuc = mtbNgayNhamChuc.Text = ((DateTime)reader["n3"]).ToString("dd/MM/yyyy");
                    }
                    reader.Close();
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                        con.Dispose();
                    }
                }
            }
        }


        //Cập nhật thông tin
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            con.ConnectionString = @"Data Source=DESKTOP-OI20CUM\ADMIN;Initial Catalog=QuanLyTinhLuong;User ID=sa;Password=1";
            if (txtMaNV.Text == string.Empty ||
                txtHoTen.Text.Trim() == string.Empty ||
                mtbNgaySinh.Text == string.Empty ||
                cmbGioiTinh.Text == string.Empty ||
                cmbNoiSinh.Text == string.Empty ||
                cmbDanToc.Text == string.Empty ||
                txtDienThoai.Text == string.Empty ||
                txtDiaChi.Text.Trim() == string.Empty ||
                mtbNgayVaoCongTy.Text == string.Empty ||
                cmbPhongBan.Text == string.Empty ||
                cmbChuyenMon.Text == string.Empty ||
                cmbTrinhDo.Text == string.Empty ||
                cmbHeSoLuong.Text == string.Empty ||
                cmbChucVu.Text == string.Empty ||
                mtbNgayApDungHSL.Text == string.Empty ||
                mtbNgayApDungTD.Text == string.Empty ||
                mtbNgayNhamChuc.Text == string.Empty)
            {
                CustomMessageBox.Show("Vui lòng điền đầy đủ các trường");
            }
            if (ValidationHelper.ValidateTimeMaskTextBox(mtbNgaySinh) == false ||
                    ValidationHelper.ValidateTimeMaskTextBox(mtbNgayVaoCongTy) == false ||
                    ValidationHelper.ValidateTimeMaskTextBox(mtbNgayApDungTD) == false ||
                    ValidationHelper.ValidateTimeMaskTextBox(mtbNgayApDungHSL) == false ||
                    ValidationHelper.ValidateTimeMaskTextBox(mtbNgayNhamChuc) == false)
            {
                CustomMessageBox.Show("Vui lòng nhập đúng dạng ngày tháng năm");
            }
            else if (ValidationHelper.ValidateTimeMaskTextBox(mtbNgaySinh) == true &&
                    ValidationHelper.ValidateTimeMaskTextBox(mtbNgayVaoCongTy) == true &&
                    ValidationHelper.ValidateTimeMaskTextBox(mtbNgayApDungTD) == true &&
                    ValidationHelper.ValidateTimeMaskTextBox(mtbNgayApDungHSL) == true &&
                    ValidationHelper.ValidateTimeMaskTextBox(mtbNgayNhamChuc) == true)
            {
                int cnt = 0;
                DateTime ngaySinh = DateTime.ParseExact(mtbNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime ngayVaoCongTy = DateTime.ParseExact(mtbNgayVaoCongTy.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime ngayApDungTD = DateTime.ParseExact(mtbNgayApDungTD.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime ngayApDungHSL = DateTime.ParseExact(mtbNgayApDungHSL.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime ngayNhamChuc = DateTime.ParseExact(mtbNgayNhamChuc.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (ngaySinh > ngayVaoCongTy)
                {
                    CustomMessageBox.Show("Ngày sinh không hợp lệ, vui lòng kiểm tra lại");
                }
                else if (ngayApDungTD < ngayVaoCongTy)
                {
                    CustomMessageBox.Show("Ngày áp dụng TĐ không hợp lệ, vui lòng kiểm tra lại");
                }
                else if (ngayApDungHSL < ngayVaoCongTy)
                {
                    CustomMessageBox.Show("Ngày áp dụng HSL không hợp lệ, vui lòng kiểm tra lại");
                }
                else if (ngayNhamChuc < ngayVaoCongTy)
                {
                    CustomMessageBox.Show("Ngày nhậm chức không hợp lệ, vui lòng kiểm tra lại");
                }
                else if (CustomMessageBox.Show("Bạn chắc chắn thay đổi thông tin của nhân viên ?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    {
                        SqlCommand cmd = new SqlCommand();

                        if (nhanVien.HoTen.Trim() != txtHoTen.Text.Trim())
                        {
                            con.Open();
                            cmd = con.CreateCommand();
                            cmd.CommandText = "update hosonhanvien set hoten = N'" + txtHoTen.Text + "' where manhanvien = N'" + txtMaNV.Text + "'";
                            cmd.ExecuteNonQuery();
                            if (con.State == ConnectionState.Open)
                                cnt++;
                        }
                        if (nhanVien.NgaySinh != mtbNgaySinh.Text)
                        {
                            if (DateTime.TryParseExact(mtbNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                            {
                                string ngaysinh = parsedDate.ToString("yyyy-MM-dd");
                                con.Open();
                                cmd = con.CreateCommand();
                                cmd.CommandText = "update hosonhanvien set ngaysinh = @ngaysinh where manhanvien = N'" + txtMaNV.Text + "'";
                                cmd.Parameters.AddWithValue("ngaysinh", ngaysinh);
                                cmd.ExecuteNonQuery();
                                if (con.State == ConnectionState.Open)
                                    cnt++;
                            }
                            else
                            {
                                CustomMessageBox.Show("Vui lòng nhập lại ngày sinh hợp lệ");
                            }
                        }
                        if (nhanVien.GioiTinh != cmbGioiTinh.Text)
                        {
                            con.Open();
                            cmd = con.CreateCommand();
                            cmd.CommandText = "update hosonhanvien set gioitinh = N'" + cmbGioiTinh.Text + "' where manhanvien = N'" + txtMaNV.Text + "'";
                            cmd.ExecuteNonQuery();
                            if (con.State == ConnectionState.Open)
                                cnt++;
                        }
                        if (nhanVien.NoiSinh != cmbNoiSinh.Text)
                        {
                            con.Open();
                            cmd = con.CreateCommand();
                            cmd.CommandText = "update hosonhanvien set manoisinh = '" + (cmbNoiSinh.SelectedIndex + 1) + "' where manhanvien = N'" + txtMaNV.Text + "'";
                            cmd.ExecuteNonQuery();
                            if (con.State == ConnectionState.Open)
                                cnt++;
                        }
                        if (nhanVien.DanToc != cmbDanToc.Text)
                        {
                            con.Open();
                            cmd = con.CreateCommand();
                            cmd.CommandText = "update hosonhanvien set madantoc = '" + (cmbDanToc.SelectedIndex + 1) + "' where manhanvien = N'" + txtMaNV.Text + "'";
                            cmd.ExecuteNonQuery();
                            if (con.State == ConnectionState.Open)
                                cnt++;
                        }
                        if (nhanVien.SDT != txtDienThoai.Text)
                        {
                            con.Open();
                            cmd = con.CreateCommand();
                            cmd.CommandText = "update hosonhanvien set dienthoai = '" + txtDienThoai.Text + "' where manhanvien = N'" + txtMaNV.Text + "'";
                            cmd.ExecuteNonQuery();
                            if (con.State == ConnectionState.Open)
                                cnt++;
                        }
                        if (nhanVien.DiaChi != txtDiaChi.Text)
                        {
                            con.Open();
                            cmd = con.CreateCommand();
                            cmd.CommandText = "update hosonhanvien set diachi = '" + txtDiaChi.Text + "' where manhanvien = N'" + txtDiaChi.Text + "'";
                            cmd.ExecuteNonQuery();
                            if (con.State == ConnectionState.Open)
                                cnt++;
                        }
                        if (nhanVien.NgayVaoCongTy != mtbNgayVaoCongTy.Text)
                        {
                            if (DateTime.TryParseExact(mtbNgayVaoCongTy.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                            {
                                string ngayvaocongty = parsedDate.ToString("yyyy-MM-dd");
                                con.Open();
                                cmd = con.CreateCommand();
                                cmd.CommandText = "update hosonhanvien set ngayvaocongty = @ngayvaocongty where manhanvien = N'" + txtMaNV.Text + "'";
                                cmd.Parameters.AddWithValue("ngayvaocongty", ngayvaocongty);
                                cmd.ExecuteNonQuery();
                                if (con.State == ConnectionState.Open)
                                    cnt++;
                            }
                            else
                            {
                                CustomMessageBox.Show("Vui lòng nhập lại ngày/tháng hợp lệ");
                            }
                        }
                        if (nhanVien.PhongBan != cmbPhongBan.Text)
                        {
                            con.Open();
                            cmd = con.CreateCommand();
                            cmd.CommandText = "update hosonhanvien set maphongban = '" + (cmbPhongBan.SelectedIndex + 1) + "' where manhanvien = N'" + txtMaNV.Text + "'";
                            cmd.ExecuteNonQuery();
                            if (con.State == ConnectionState.Open)
                                cnt++;
                        }
                        if (nhanVien.ChuyenMon != cmbChuyenMon.Text)
                        {
                            con.Open();
                            cmd = con.CreateCommand();
                            cmd.CommandText = "update hosonhanvien set machuyenmon = '" + (cmbChuyenMon.SelectedIndex + 1) + "' where manhanvien = N'" + txtMaNV.Text + "'";
                            cmd.ExecuteNonQuery();
                            if (con.State == ConnectionState.Open)
                                cnt++;
                        }
                        if (nhanVien.TrinhDo != cmbTrinhDo.Text)
                        {
                            con.Open();
                            cmd = con.CreateCommand();
                            cmd.CommandText = "update nhanvientrinhdo set matrinhdo = '" + (cmbTrinhDo.SelectedIndex + 1) + "' where manhanvien = N'" + txtMaNV.Text + "'";
                            cmd.ExecuteNonQuery();
                            if (con.State == ConnectionState.Open)
                                cnt++;
                        }
                        if (nhanVien.HeSoLuong != cmbHeSoLuong.Text)
                        {
                            con.Open();
                            cmd = con.CreateCommand();
                            cmd.CommandText = "update nhanvienhesoluong set mahesoluong = '" + (cmbHeSoLuong.SelectedIndex + 1) + "' where manhanvien = N'" + txtMaNV.Text + "'";
                            cmd.ExecuteNonQuery();
                            if (con.State == ConnectionState.Open)
                                cnt++;
                        }
                        if (nhanVien.ChucVu != cmbChucVu.Text)
                        {
                            con.Open();
                            cmd = con.CreateCommand();
                            cmd.CommandText = "update nhanvienchucvu set machucvu = '" + (cmbChucVu.SelectedIndex + 1) + "' where manhanvien = N'" + txtMaNV.Text + "'";
                            cmd.ExecuteNonQuery();
                            if (con.State == ConnectionState.Open)
                                cnt++;
                        }
                        if (nhanVien.NgayApDungHSL != mtbNgayApDungHSL.Text)
                        {
                            if (DateTime.TryParseExact(mtbNgayApDungHSL.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                            {
                                string ngayapdunghsl = parsedDate.ToString("yyyy-MM-dd");
                                con.Open();
                                cmd = con.CreateCommand();
                                cmd.CommandText = "update nhanvienhesoluong set ngayapdung = @ngayapdunghsl where manhanvien = N'" + txtMaNV.Text + "'";
                                cmd.Parameters.AddWithValue("ngayapdunghsl", ngayapdunghsl);
                                cmd.ExecuteNonQuery();
                                if (con.State == ConnectionState.Open)
                                    cnt++;
                            }
                            else
                            {
                                CustomMessageBox.Show("Vui lòng nhập lại ngày/tháng hợp lệ");
                            }
                        }
                        if (nhanVien.NgayApDungTD != mtbNgayApDungTD.Text)
                        {
                            if (DateTime.TryParseExact(mtbNgayApDungTD.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                            {
                                string ngayapdungtd = parsedDate.ToString("yyyy-MM-dd");
                                con.Open();
                                cmd = con.CreateCommand();
                                cmd.CommandText = "update nhanvientrinhdo set ngayapdung = @ngayapdungtd where manhanvien = N'" + txtMaNV.Text + "'";
                                cmd.Parameters.AddWithValue("ngayapdungtd", ngayapdungtd);
                                cmd.ExecuteNonQuery();
                                if (con.State == ConnectionState.Open)
                                    cnt++;
                            }
                            else
                            {
                                CustomMessageBox.Show("Vui lòng nhập lại ngày/tháng hợp lệ");
                            }
                        }
                        if (nhanVien.NgayNhamChuc != mtbNgayNhamChuc.Text)
                        {
                            if (DateTime.TryParseExact(mtbNgayNhamChuc.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                            {
                                string ngaynhamchuc = parsedDate.ToString("yyyy-MM-dd");
                                con.Open();
                                cmd = con.CreateCommand();
                                cmd.CommandText = "update nhanvienchucvu set ngayapdung = @ngaynhamchuc where manhanvien = N'" + txtMaNV.Text + "'";
                                cmd.Parameters.AddWithValue("ngaynhamchuc", ngaynhamchuc);
                                cmd.ExecuteNonQuery();
                                if (con.State == ConnectionState.Open)
                                    cnt++;
                            }
                            else
                            {
                                CustomMessageBox.Show("Vui lòng nhập lại ngày/tháng hợp lệ");
                            }
                        }
                    }
                    CustomMessageBox.Show("Cập nhật thông tin thành công!\n Đã có " + cnt + " thay đổi");
                    this.Close();
                }
            }
        }
        // Làm mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = string.Empty;
            txtHoTen.Text = string.Empty;
            mtbNgaySinh.Text = string.Empty;
            cmbGioiTinh.Text = string.Empty;
            cmbNoiSinh.Text = string.Empty;
            cmbDanToc.Text = string.Empty;
            txtDienThoai.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            mtbNgayVaoCongTy.Text = string.Empty;
            cmbPhongBan.Text = string.Empty;
            cmbChuyenMon.Text = string.Empty;
            cmbTrinhDo.Text = string.Empty;
            cmbHeSoLuong.Text = string.Empty;
            cmbChucVu.Text = string.Empty;
            mtbNgayApDungHSL.Text = string.Empty;
            mtbNgayNhamChuc.Text = string.Empty;
            mtbNgayApDungTD.Text = string.Empty;
        }


        // Thêm nhân viên
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            con.ConnectionString = @"Data Source=DESKTOP-OI20CUM\ADMIN;Initial Catalog=QuanLyTinhLuong;User ID=sa;Password=1";
            if (txtMaNV.Text == string.Empty ||
                txtHoTen.Text.Trim() == string.Empty ||
                mtbNgaySinh.Text == string.Empty ||
                cmbGioiTinh.Text == string.Empty ||
                cmbNoiSinh.Text == string.Empty ||
                cmbDanToc.Text == string.Empty ||
                txtDienThoai.Text == string.Empty ||
                txtDiaChi.Text.Trim() == string.Empty ||
                mtbNgayVaoCongTy.Text == string.Empty ||
                cmbPhongBan.Text == string.Empty ||
                cmbChuyenMon.Text == string.Empty ||
                cmbTrinhDo.Text == string.Empty ||
                cmbHeSoLuong.Text == string.Empty ||
                cmbChucVu.Text == string.Empty ||
                mtbNgayApDungHSL.Text == string.Empty ||
                mtbNgayApDungTD.Text == string.Empty ||
                mtbNgayNhamChuc.Text == string.Empty)
            {
                CustomMessageBox.Show("Vui lòng điền đầy đủ các trường");
            }
            if (ValidationHelper.ValidateTimeMaskTextBox(mtbNgaySinh) == false ||
                    ValidationHelper.ValidateTimeMaskTextBox(mtbNgayVaoCongTy) == false ||
                    ValidationHelper.ValidateTimeMaskTextBox(mtbNgayApDungTD) == false ||
                    ValidationHelper.ValidateTimeMaskTextBox(mtbNgayApDungHSL) == false ||
                    ValidationHelper.ValidateTimeMaskTextBox(mtbNgayNhamChuc) == false)
            {
                CustomMessageBox.Show("Vui lòng nhập đúng dạng ngày tháng năm");
            }
            else if (ValidationHelper.ValidateTimeMaskTextBox(mtbNgaySinh) == true &&
                    ValidationHelper.ValidateTimeMaskTextBox(mtbNgayVaoCongTy) == true &&
                    ValidationHelper.ValidateTimeMaskTextBox(mtbNgayApDungTD) == true &&
                    ValidationHelper.ValidateTimeMaskTextBox(mtbNgayApDungHSL) == true &&
                    ValidationHelper.ValidateTimeMaskTextBox(mtbNgayNhamChuc) == true)
            {
                DateTime ngaySinh = DateTime.ParseExact(mtbNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime ngayVaoCongTy = DateTime.ParseExact(mtbNgayVaoCongTy.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime ngayApDungTD = DateTime.ParseExact(mtbNgayApDungTD.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime ngayApDungHSL = DateTime.ParseExact(mtbNgayApDungHSL.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime ngayNhamChuc = DateTime.ParseExact(mtbNgayNhamChuc.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                if (DateTime.Compare(ngaySinh, ngayVaoCongTy) >= 0)
                {
                    CustomMessageBox.Show("Ngày sinh không hợp lệ, vui lòng kiểm tra lại");
                }
                else if (DateTime.Compare(ngayApDungTD, ngayVaoCongTy) < 0)
                {
                    CustomMessageBox.Show("Ngày áp dụng TĐ không hợp lệ, vui lòng kiểm tra lại");
                }
                else if (DateTime.Compare(ngayApDungHSL, ngayVaoCongTy) < 0)
                {
                    CustomMessageBox.Show("Ngày áp dụng HSL không hợp lệ, vui lòng kiểm tra lại");
                }
                else if (DateTime.Compare(ngayNhamChuc, ngayVaoCongTy) < 0)
                {
                    CustomMessageBox.Show("Ngày nhậm chức không hợp lệ, vui lòng kiểm tra lại");
                }
                else if (CustomMessageBox.Show("Bạn có muốn thêm nhân viên mới", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string checkQuery = "select count(*) from hosonhanvien where manhanvien = @manhanvien";
                    using (SqlCommand command = new SqlCommand(checkQuery, con))
                    {
                        command.Parameters.AddWithValue("@manhanvien", txtMaNV.Text);
                        con.Open();
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        if (count > 0)
                        {
                            CustomMessageBox.Show("Mã nhân viên đã tồn tại, vui lòng nhập mã nhân viên khác.", "Thông báo");
                            con.Close();
                        }
                        else
                        {
                            // Insert bảng HoSoNhanVien
                            string insertHSNV = "insert into hosonhanvien (manhanvien, hoten, gioitinh, manoisinh, ngayvaocongty,madantoc,maphongban,machuyenmon,dienthoai,diachi,ngaysinh)" +
                                "values (N'" + txtMaNV.Text + "'" +
                                ",N'" + txtHoTen.Text + "'" +
                                ", N'" + cmbGioiTinh.Text + "', " +
                                "'" + (cmbNoiSinh.SelectedIndex + 1) + "'," +
                                " @ngayvaocongty, " +
                                "'" + (cmbDanToc.SelectedIndex + 1) + "', " +
                                "'" + (cmbPhongBan.SelectedIndex + 1) + "', " +
                                "'" + (cmbChuyenMon.SelectedIndex + 1) + "', " +
                                "'" + txtDienThoai.Text + "'," +
                                " N'" + txtDiaChi.Text + "', " +
                                "@ngaysinh)";

                            using (SqlCommand commandInsert = new SqlCommand(insertHSNV, con))
                            {
                                string ngayvaocongty = mtbNgayVaoCongTy.Text;
                                string ngaysinh = mtbNgayVaoCongTy.Text;
                                DateTime value1, value2;

                                if (DateTime.TryParseExact(ngayvaocongty, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out value1))
                                {
                                    commandInsert.Parameters.AddWithValue("@ngayvaocongty", value1);
                                }

                                if (DateTime.TryParseExact(ngaysinh, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out value2))
                                {
                                    commandInsert.Parameters.AddWithValue("@ngaysinh", value2);
                                }

                                commandInsert.ExecuteNonQuery();
                            }

                            // Bảng NhanVien_ChucVu
                            string insertNV_CV = "insert into nhanvienchucvu (manhanvien, machucvu, ngayapdung) values(" +
                                "N'" + txtMaNV.Text + "', '" + (cmbChucVu.SelectedIndex + 1) + "', @ngayapdung)";
                            using (SqlCommand commandInsert2 = new SqlCommand(insertNV_CV, con))
                            {
                                string ngayapdung = mtbNgayNhamChuc.Text;
                                DateTime value;

                                if (DateTime.TryParseExact(ngayapdung, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out value))
                                {
                                    commandInsert2.Parameters.AddWithValue("@ngayapdung", value);
                                }

                                commandInsert2.ExecuteNonQuery();
                            }

                            // Bảng NhanVien_HSL
                            string insertNV_HSL = "insert into nhanvienhesoluong (manhanvien, mahesoluong, ngayapdung) values (N'" + txtMaNV.Text + "', '" + (cmbHeSoLuong.SelectedIndex + 1) + "', @ngayapdung)";
                            using (SqlCommand commandInsert3 = new SqlCommand(insertNV_HSL, con))
                            {
                                string ngayapdung = mtbNgayApDungHSL.Text;
                                DateTime value;

                                if (DateTime.TryParseExact(ngayapdung, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out value))
                                {
                                    commandInsert3.Parameters.AddWithValue("@ngayapdung", value);
                                }

                                commandInsert3.ExecuteNonQuery();
                            }

                            // Bảng NhanVien_TD
                            string insertNV_TD = "insert into nhanvientrinhdo (manhanvien, matrinhdo, ngayapdung) values (N'" + txtMaNV.Text + "', '" + (cmbTrinhDo.SelectedIndex + 1) + "', @ngayapdung)";
                            using (SqlCommand commandInsert4 = new SqlCommand(insertNV_TD, con))
                            {
                                string ngayapdung = mtbNgayApDungTD.Text;
                                DateTime value;

                                if (DateTime.TryParseExact(ngayapdung, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out value))
                                {
                                    commandInsert4.Parameters.AddWithValue("@ngayapdung", value);
                                }

                                commandInsert4.ExecuteNonQuery();
                            }

                            CustomMessageBox.Show("Thêm nhân viên thành công");
                            this.Close();
                        }
                    }
                }
            }
        }
        // Quay lại trang tìm kiếm
        private void btnBack_Click(object sender, EventArgs e)
        {

        }


        // Drag
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label13_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCloseDashboard_Click_1(object sender, EventArgs e)
        {
            if (CustomMessageBox.Show("Bạn có rời khỏi trang này?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
