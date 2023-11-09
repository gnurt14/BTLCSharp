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

namespace QuanLyTienLuong
{
    public partial class FormChiTietNhanVien : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OI20CUM\ADMIN;Initial Catalog=QuanLyTinhLuong;User ID=sa;Password=1");
        string manhanvien;
        public FormChiTietNhanVien(string manv)
        {
            manhanvien = manv;
            InitializeComponent();
        }

        private void btnCloseDashboard_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.Show("Bạn có muốn thoát", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
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
            using (SqlCommand command = new SqlCommand(querycv, con)) {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string item = reader["tenchucvu"].ToString();
                        cmbChucVu.Items.Add(item);  
                    }
                }
            }
            
            con.Close();
        }
        private void FormChiTietNhanVien_Load(object sender, EventArgs e)
        {
            Load_Combobox();
            if (manhanvien != null)
            {
                string query = "select hs.manhanvien, hoten, ngaysinh,gioitinh,tennoisinh, tendantoc, hs.dienthoai,diachi, ngayvaocongty, \r\ntenphongban,tenchuyenmon, tentrinhdo, ntd.ngayapdung as n1, hesoluong.mahesoluong, nvl.ngayapdung as n2 , tenchucvu, ncv.ngayapdung as n3 from hosonhanvien hs \r\njoin noisinh on hs.manoisinh = noisinh.manoisinh\r\njoin dantoc on hs.madantoc = dantoc.madantoc\r\njoin phongban on hs.maphongban = phongban.maphongban\r\njoin chuyenmon on hs.machuyenmon = chuyenmon.Machuyenmon\r\njoin nhanvientrinhdo ntd on hs.manhanvien = ntd.manhanvien\r\njoin trinhdo on ntd.matrinhdo = trinhdo.Matrinhdo\r\njoin nhanvienhesoluong nvl on nvl.manhanvien = hs.manhanvien\r\njoin hesoluong on nvl.mahesoluong = hesoluong.mahesoluong\r\njoin NhanVienChucVu ncv on ncv.manhanvien = hs.manhanvien\r\njoin chucvu on ncv.machucvu = chucvu.machucvu" +
                    "\r\nwhere hs.manhanvien = N'"+manhanvien+"'";
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
                        cmbNoiSinh.Text = tennoisinh;
                        cmbDanToc.Text = tendantoc;
                        txtHoTen.Text = hoten;
                        mtbNgaySinh.Text = ngaysinh.ToString("dd/MM/yyyy");
                        cmbGioiTinh.Text = gioitinh;
                        txtDienThoai.Text = dienthoai;
                        txtDiaChi.Text = diachi;
                        mtbNgayVaoCongTy.Text = ngayvaocongty.ToString("dd/MM/yyyy");
                        cmbPhongBan.Text = tenphongban;
                        cmbChuyenMon.Text = tenchuyenmon;
                        cmbTrinhDo.Text = tentrinhdo;
                        cmbHeSoLuong.Text = tenhsl;
                        cmbChucVu.Text = chucvu;
                        mtbNgayApDungHSL.Text = ngayapdunghsl.ToString("dd/MM/yyyy");
                        mtbNgayApDungTD.Text = ngayapdungtrinhdo.ToString("dd/MM/yyyy");
                        mtbNgayNhamChuc.Text = ngayapdungchucvu.ToString("dd/MM/yyyy");
                    }
                    reader.Close();
                    con.Close();
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == string.Empty ||
                txtHoTen.Text == string.Empty ||
                mtbNgaySinh.Text == string.Empty ||
                cmbGioiTinh.Text == string.Empty ||
                cmbNoiSinh.Text == string.Empty ||
                cmbDanToc.Text == string.Empty ||
                txtDienThoai.Text == string.Empty ||
                txtDiaChi.Text == string.Empty ||
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
            else
            {
                if (CustomMessageBox.Show("Bạn có chắc chắn muốn chỉnh sửa", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string query = "update hosonhanvien";
                    using (SqlCommand command = new SqlCommand(query, con))
                    {

                    }
                }
            }
        }

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

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == string.Empty ||
                txtHoTen.Text == string.Empty ||
                mtbNgaySinh.Text == string.Empty ||
                cmbGioiTinh.Text == string.Empty ||
                cmbNoiSinh.Text == string.Empty ||
                cmbDanToc.Text == string.Empty ||
                txtDienThoai.Text == string.Empty ||
                txtDiaChi.Text == string.Empty ||
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
            else
            {
                if (CustomMessageBox.Show("Bạn có muốn thêm nhân viên mới", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string checkQuery = "select count(*) from hosonhanvien where manhanvien = @manhanvien";
                    using (SqlCommand command = new SqlCommand(checkQuery, con))
                    {
                        command.Parameters.AddWithValue("@manhanvien", txtMaNV.Text);
                        con.Open();
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        con.Close();
                        if (count > 0)
                        {
                            CustomMessageBox.Show("Mã nhân viên đã tồn tại, vui lòng nhập mã nhân viên khác.", "Thông báo");
                        }
                        else
                        {
                            // Insert bang HoSoNhanVien
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
                                    commandInsert.Parameters.AddWithValue("@ngayvaocongty", ngayvaocongty);
                                }
                                if (DateTime.TryParseExact(ngaysinh, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out value2))
                                {
                                    commandInsert.Parameters.AddWithValue("@ngaysinh", ngaysinh);
                                }
                                con.Open();
                                commandInsert.ExecuteNonQuery();
                                con.Close();
                            }
                            // Bang NhanVien_ChucVu
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
                                con.Open();
                                commandInsert2.ExecuteNonQuery();
                                con.Close();
                            }

                            // Bang NhanVien_HSL
                            string insertNV_HSL = "insert into nhanvienhesoluong (manhanvien, mahesoluong, ngayapdung) values (N'" + txtMaNV.Text + "', '"+(cmbHeSoLuong.SelectedIndex + 1)+"', @ngayapdung)";
                            using (SqlCommand commandInsert3 = new SqlCommand (insertNV_HSL, con))
                            {
                                string ngayapdung = mtbNgayApDungHSL.Text;
                                DateTime value;
                                if (DateTime.TryParseExact(ngayapdung, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out value))
                                {
                                    commandInsert3.Parameters.AddWithValue("@ngayapdung", value);
                                }
                                con.Open();
                                commandInsert3.ExecuteNonQuery();
                                con.Close();
                            }

                            // Bang NhanVien_TD
                            string insertNV_TD = "insert into nhanvientrinhdo (manhanvien, matrinhdo, ngayapdung) values (N'" + txtMaNV.Text + "', '" + (cmbTrinhDo.SelectedIndex + 1) + "', @ngayapdung)";
                            using (SqlCommand commandInsert4 = new SqlCommand(insertNV_TD, con))
                            {
                                string ngayapdung = mtbNgayApDungTD.Text;
                                DateTime value;
                                if (DateTime.TryParseExact(ngayapdung, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out value))
                                {
                                    commandInsert4.Parameters.AddWithValue("@ngayapdung", value);
                                }
                                con.Open();
                                commandInsert4.ExecuteNonQuery();
                                con.Close();
                            }
                            CustomMessageBox.Show("Thêm nhân viên thành công");
                        }
                    }
                }
            }
        }
    }
}
