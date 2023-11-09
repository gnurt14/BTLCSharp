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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QuanLyTienLuong
{
    public partial class FormTimKiem : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OI20CUM\ADMIN;Initial Catalog=QuanLyTinhLuong;User ID=sa;Password=1");
        string selectedMaNV;
        public FormTimKiem()
        {
            InitializeComponent();
        }

        void Load_Combobox()
        {
            string query1 = "select tenchuyenmon from chuyenmon";
            string query2 = "select mahesoluong from hesoluong";
            string query3 = "select tentrinhdo from trinhdo";
            con.Open();
            using (SqlCommand command = new SqlCommand(query2, con))
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
            using (SqlCommand command = new SqlCommand(query3, con))
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
            using (SqlCommand command = new SqlCommand(query1, con))
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
            con.Close();
        }
        public void Load_data()
        {
            string selectQuery = "SELECT DISTINCT hs.manhanvien, hoten, ngaysinh, gioitinh, tennoisinh, ngayvaocongty, " +
                            "tendantoc, tenphongban, tenchuyenmon, tenchucvu, tentrinhdo " +
                            "FROM hosonhanvien hs " +
                            "JOIN nhanvientrinhdo nvtd ON hs.manhanvien = nvtd.manhanvien " +
                            "JOIN trinhdo ON trinhdo.Matrinhdo = nvtd.matrinhdo " +
                            "JOIN chuyenmon ON hs.machuyenmon = chuyenmon.Machuyenmon " +
                            "JOIN nhanvienhesoluong nvhsl ON hs.manhanvien = nvhsl.manhanvien " +
                            "JOIN hesoluong ON hesoluong.mahesoluong = nvhsl.mahesoluong " +
                            "JOIN noisinh ON hs.manoisinh = noisinh.manoisinh " +
                            "JOIN dantoc ON hs.madantoc = dantoc.madantoc " +
                            "JOIN phongban ON hs.maphongban = phongban.maphongban " +
                            "JOIN NhanVienChucVu ON hs.manhanvien = NhanVienChucVu.manhanvien " +
                            "JOIN chucvu ON NhanVienChucVu.machucvu = chucvu.machucvu " +
                            "WHERE hoten LIKE N'%' + @hoten + N'%' " +
                            "AND tentrinhdo LIKE N'%' + @trinhdo + N'%' " +
                            "AND hesoluong.mahesoluong LIKE N'%' + @hsl2 + N'%' " +
                            "AND tenchuyenmon LIKE N'%' + @chuyenmon + N'%'";
            using (SqlCommand selectCommand2 = new SqlCommand(selectQuery, con))
            {
                string[] parts = cmbHeSoLuong.Text.Split(' ');
                string hsl2 = parts[parts.Length - 1];
                selectCommand2.Parameters.AddWithValue("@hoten", txtHoTen.Text);
                selectCommand2.Parameters.AddWithValue("@trinhdo", cmbTrinhDo.Text);
                selectCommand2.Parameters.AddWithValue("@hsl2", hsl2);
                selectCommand2.Parameters.AddWithValue("@chuyenmon", cmbChuyenMon.Text);
                con.Open();
                SqlDataReader reader = selectCommand2.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);
                dgvTimKiem.DataSource = dt;
                dgvTimKiem.Columns["manhanvien"].HeaderText = "Mã nhân viên";
                dgvTimKiem.Columns["manhanvien"].Width = 120;
                dgvTimKiem.Columns["hoten"].HeaderText = "Họ tên";
                dgvTimKiem.Columns["hoten"].Width = 180;
                dgvTimKiem.Columns["ngaysinh"].HeaderText = "Ngày sinh";
                dgvTimKiem.Columns["ngaysinh"].Width = 120;
                dgvTimKiem.Columns["gioitinh"].HeaderText = "Giới tính";
                dgvTimKiem.Columns["gioitinh"].Width = 100;
                dgvTimKiem.Columns["tennoisinh"].HeaderText = "Nơi sinh";
                dgvTimKiem.Columns["tennoisinh"].Width = 100;
                dgvTimKiem.Columns["tendantoc"].HeaderText = "Dân tộc";
                dgvTimKiem.Columns["tendantoc"].Width = 100;
                dgvTimKiem.Columns["ngayvaocongty"].HeaderText = "Ngày vào công ty";
                dgvTimKiem.Columns["ngayvaocongty"].Width = 150;
                dgvTimKiem.Columns["tenphongban"].HeaderText = "Phòng ban";
                dgvTimKiem.Columns["tenphongban"].Width = 200;
                dgvTimKiem.Columns["tenchuyenmon"].HeaderText = "Chuyên môn";
                dgvTimKiem.Columns["tenchuyenmon"].Width = 180;
                dgvTimKiem.Columns["tenchucvu"].HeaderText = "Chức vụ";
                dgvTimKiem.Columns["tenchucvu"].Width = 120;
                dgvTimKiem.Columns["tentrinhdo"].HeaderText = "Trình độ";
                dgvTimKiem.Columns["tentrinhdo"].Width = 100;
                con.Close();
            }
        }
        
        private void FormTimKiem_Load(object sender, EventArgs e)
        {
            Load_data();
            Load_Combobox();
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text == string.Empty && cmbChuyenMon.SelectedItem == null && cmbTrinhDo.SelectedItem == null && cmbHeSoLuong.SelectedItem == null)
            {
                CustomMessageBox.Show("Vui lòng chọn một trường tìm kiếm", "Thông báo");
            }
            // Tìm kiếm
            else
            {
                
                string selectQuery = "SELECT COUNT(*) FROM hosonhanvien hs\r\njoin nhanvientrinhdo nvtd on hs.manhanvien = nvtd.manhanvien\r\njoin trinhdo on trinhdo.Matrinhdo = nvtd.matrinhdo\r\njoin chuyenmon on hs.machuyenmon = chuyenmon.Machuyenmon\r\njoin nhanvienhesoluong nvhsl on hs.manhanvien = nvhsl.manhanvien\r\njoin hesoluong on hesoluong.mahesoluong = nvhsl.mahesoluong\r\nWHERE hoten like N'%' + @hoten + '%' and tentrinhdo like N'%' + @trinhdo + '%' and hesoluong.mahesoluong like N'%' + @hsl + '%' and tenchuyenmon like N'%' + @chuyenmon + '%'\r\n";

                using (SqlCommand selectCommand = new SqlCommand(selectQuery, con))
                {
                    string[] parts = cmbHeSoLuong.Text.Split(' ');
                    string hsl = parts[parts.Length - 1];
                    selectCommand.Parameters.AddWithValue("@hoten", txtHoTen.Text);
                    selectCommand.Parameters.AddWithValue("@trinhdo", cmbTrinhDo.Text);
                    selectCommand.Parameters.AddWithValue("@hsl", hsl);
                    selectCommand.Parameters.AddWithValue("@chuyenmon", cmbChuyenMon.Text);
                    con.Open();
                    int count = Convert.ToInt32(selectCommand.ExecuteScalar());
                    con.Close();

                    CustomMessageBox.Show("Tìm thấy " + count + " nhân viên trùng khớp", "Thông báo", MessageBoxButtons.OK);

                    if (count == 0)
                    {
                        dgvTimKiem.DataSource = null;
                        Load_data();
                        return;
                    }
                    else if (count > 0)
                    {
                        Load_data();
                    }
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = string.Empty;
            cmbChuyenMon.SelectedItem = null;
            cmbHeSoLuong.SelectedItem = null;
            cmbTrinhDo.SelectedItem = null;
            dgvTimKiem.DataSource = null;
            Load_data();
        }

        private void txtHoTen_MouseClick(object sender, MouseEventArgs e)
        {
            txtHoTen.SelectAll();
        }
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            FormChiTietNhanVien frm = new FormChiTietNhanVien(null);
            frm.ShowDialog();
        }

        private void dgvTimKiem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvTimKiem.Rows[e.RowIndex];
                selectedMaNV = selectedRow.Cells["manhanvien"].Value.ToString();
                FormChiTietNhanVien frm = new FormChiTietNhanVien(selectedMaNV);
                frm.ShowDialog();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            FormChiTietNhanVien frm = new FormChiTietNhanVien(selectedMaNV);
            frm.ShowDialog();
        }

        private void dgvTimKiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvTimKiem.Rows[e.RowIndex];
                selectedMaNV = selectedRow.Cells["manhanvien"].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = CustomMessageBox.Show("Bạn có chắc chắn muốn xoá nhân viên này?", "Cảnh báo", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    string queryDeleteNhanVien = "DELETE FROM hosonhanvien WHERE manhanvien = @manhanvien";
                    string queryDeleteChucVu = "DELETE FROM nhanvienchucvu WHERE manhanvien = @manhanvien";
                    string queryDeleteTrinhDo = "DELETE FROM nhanvientrinhdo WHERE manhanvien = @manhanvien";
                    string queryDeleteHeSoLuong = "DELETE FROM nhanvienhesoluong WHERE manhanvien = @manhanvien";
                    string queryDeleteKhenThuongKyLuat = "DELETE FROM khenthuongkyluat WHERE manhanvien = @manhanvien";
                    string queryDeleteLuong = "DELETE FROM luong WHERE manhanvien = @manhanvien";
                    con.Open();
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                            using (SqlCommand commandNhanVien = new SqlCommand(queryDeleteNhanVien, con, transaction))
                            {
                                commandNhanVien.Parameters.AddWithValue("@manhanvien", selectedMaNV);
                                commandNhanVien.ExecuteNonQuery();
                            }

                            using (SqlCommand commandHeSoLuong = new SqlCommand(queryDeleteHeSoLuong, con, transaction))
                            {
                                commandHeSoLuong.Parameters.AddWithValue("@manhanvien", selectedMaNV);
                                commandHeSoLuong.ExecuteNonQuery();
                            }

                            using (SqlCommand commandTrinhDo = new SqlCommand(queryDeleteTrinhDo, con, transaction))
                            {
                                commandTrinhDo.Parameters.AddWithValue("@manhanvien", selectedMaNV);
                                commandTrinhDo.ExecuteNonQuery();
                            }

                            using (SqlCommand commandKhenThuongKyLuat = new SqlCommand(queryDeleteKhenThuongKyLuat, con, transaction))
                            {
                                commandKhenThuongKyLuat.Parameters.AddWithValue("@manhanvien", selectedMaNV);
                                commandKhenThuongKyLuat.ExecuteNonQuery();
                            }

                            using (SqlCommand commandLuong = new SqlCommand(queryDeleteLuong, con, transaction))
                            {
                                commandLuong.Parameters.AddWithValue("@manhanvien", selectedMaNV);
                                commandLuong.ExecuteNonQuery();
                            }

                            using (SqlCommand commandChucVu = new SqlCommand(queryDeleteChucVu, con, transaction))
                            {
                                commandChucVu.Parameters.AddWithValue("@manhanvien", selectedMaNV);
                                commandChucVu.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            CustomMessageBox.Show("Xoá nhân viên hoàn tất");
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            CustomMessageBox.Show("Đã xảy ra lỗi khi xoá nhân viên: " + ex.Message);
                        }
                    }
                    con.Close();
                }
                catch (Exception ex)
                {
                    CustomMessageBox.Show("Đã xảy ra lỗi khi kết nối cơ sở dữ liệu: " + ex.Message);
                }
                Load_data();
            }
        }
       
    }
}
