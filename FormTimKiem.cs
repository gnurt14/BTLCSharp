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
        SqlCommand command;
        SqlDataAdapter adapterData = new SqlDataAdapter();
        DataTable dt = new DataTable();
        public FormTimKiem()
        {
            InitializeComponent();
        }

        void Load_Combobox()
        {
            string query1 = "select tenchuyenmon from chuyenmon";
            string query2 = "select mahesoluong from hesoluong";
            string query3 = "select tentrinhdo from trinhdo";
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
        }
        void Load_data()
        {
            command = con.CreateCommand();
            command.CommandText = "select hosonhanvien.manhanvien,hoten,ngaysinh,gioitinh,tennoisinh,ngayvaocongty,tendantoc," +
                "tenphongban,tenchuyenmon, tenchucvu, tentrinhdo from hosonhanvien" +
                "\r\njoin dantoc on hosonhanvien.madantoc = dantoc.madantoc" +
                "\r\njoin noisinh on hosonhanvien.manoisinh = noisinh.manoisinh" +
                "\r\njoin phongban on hosonhanvien.maphongban = phongban.maphongban" +
                "\r\njoin chuyenmon on hosonhanvien.machuyenmon = chuyenmon.machuyenmon" +
                "\r\njoin NhanVienChucVu on hosonhanvien.manhanvien = NhanVienChucVu.manhanvien" +
                "\r\njoin chucvu on NhanVienChucVu.machucvu = chucvu.machucvu" +
                "\r\njoin nhanvientrinhdo on hosonhanvien.manhanvien = nhanvientrinhdo.manhanvien" +
                "\r\njoin trinhdo on trinhdo.Matrinhdo = nhanvientrinhdo.matrinhdo\r\n";
            adapterData.SelectCommand = command;
            dt.Clear();
            adapterData.Fill(dt);
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
            dgvTimKiem.Columns["tendantoc"].Width= 100;
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
        }
        private void FormTimKiem_Load(object sender, EventArgs e)
        {
            con.Open();
            Load_Combobox();
            //Load_data();
            con.Close(); 
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text == string.Empty && cmbChuyenMon.SelectedItem == null && cmbTrinhDo.SelectedItem == null && cmbHeSoLuong.SelectedItem == null)
            {
                CustomMessageBox.Show("Vui lòng chọn một trường tìm kiếm", "Thông báo");
            }
            // Tìm
            else
            {
                //{
                //    string selectQuery = "SELECT COUNT(*) FROM hosonhanvien hs\r\njoin nhanvientrinhdo nvtd on hs.manhanvien = nvtd.manhanvien\r\njoin trinhdo on trinhdo.Matrinhdo = nvtd.matrinhdo\r\njoin chuyenmon on hs.machuyenmon = chuyenmon.Machuyenmon\r\njoin nhanvienhesoluong nvhsl on hs.manhanvien = nvhsl.manhanvien\r\njoin hesoluong on hesoluong.mahesoluong = nvhsl.mahesoluong\r\nWHERE hoten like N'%@hoten%' and tentrinhdo like N'%@trinhdo%' and tenhesoluong like N'%@hsl%' and tenchuyenmon like N'%@chuyenmon%'\r\n";
                //    using (SqlCommand selectCommand = new SqlCommand(selectQuery, con))
                //    {
                //        selectCommand.Parameters.AddWithValue("@hoten", txtHoTen.Text);
                //        selectCommand.Parameters.AddWithValue("@trinhdo", cmbTrinhDo.ToString());
                //        selectCommand.Parameters.AddWithValue("@chuyemon", cmbChuyenMon.ToString());
                //        con.Open();
                //        int count = Convert.ToInt32(selectCommand.ExecuteScalar());
                //        con.Close();
                //        CustomMessageBox.Show("Tìm thấy " + count + " nhân viên trùng khớp", "Thông báo", MessageBoxButtons.OK);
                //        if (count == 0)
                //        {
                //            dgvTimKiem.DataSource = null;
                //            return;
                //        }
                //        else if (count > 0)
                //        {
                //            selectQuery = "select hosonhanvien.manhanvien,hoten,ngaysinh,gioitinh,tennoisinh,ngayvaocongty,tendantoc," +
                //            "tenphongban,tenchuyenmon, tenchucvu from hosonhanvien" +
                //            "\r\njoin dantoc on hosonhanvien.madantoc = dantoc.madantoc" +
                //            "\r\njoin noisinh on hosonhanvien.manoisinh = noisinh.manoisinh" +
                //            "\r\njoin phongban on hosonhanvien.maphongban = phongban.maphongban" +
                //            "\r\njoin chuyenmon on hosonhanvien.machuyenmon = chuyenmon.machuyenmon" +
                //            "\r\njoin NhanVienChucVu on hosonhanvien.manhanvien = NhanVienChucVu.manhanvien" +
                //            "\r\njoin chucvu on NhanVienChucVu.machucvu = chucvu.machucvu" +
                //            "\r\nwhere hoten like @hoten";
                //            using (SqlCommand selectCommand2 = con.CreateCommand())
                //            {
                //                selectCommand2.CommandText = selectQuery;
                //                selectCommand2.Parameters.AddWithValue("@hoten", txtHoTen.Text);
                //                con.Open();
                //                selectCommand2.ExecuteNonQuery();
                //                adapterData.SelectCommand = selectCommand2;
                //                dt.Clear();
                //                adapterData.Fill(dt);
                //                dgvTimKiem.DataSource = dt;
                //                Load_data();
                //                con.Close();
                //            }
                //        }
                //    }
                //}
                string selectQuery = "SELECT COUNT(*) FROM hosonhanvien hs\r\njoin nhanvientrinhdo nvtd on hs.manhanvien = nvtd.manhanvien\r\njoin trinhdo on trinhdo.Matrinhdo = nvtd.matrinhdo\r\njoin chuyenmon on hs.machuyenmon = chuyenmon.Machuyenmon\r\njoin nhanvienhesoluong nvhsl on hs.manhanvien = nvhsl.manhanvien\r\njoin hesoluong on hesoluong.mahesoluong = nvhsl.mahesoluong\r\nWHERE hoten like N'%' + @hoten + '%' and tentrinhdo like N'%' + @trinhdo + '%' and tenhesoluong like N'%' + @hsl + '%' and tenchuyenmon like N'%' + @chuyenmon + '%'\r\n";

                using (SqlCommand selectCommand = new SqlCommand(selectQuery, con))
                {
                    selectCommand.Parameters.AddWithValue("@hoten", txtHoTen.Text);
                    selectCommand.Parameters.AddWithValue("@trinhdo", cmbTrinhDo.Text);
                    selectCommand.Parameters.AddWithValue("@hsl", cmbHeSoLuong.Text);
                    selectCommand.Parameters.AddWithValue("@chuyenmon", cmbChuyenMon.Text);
                    con.Open();
                    int count = Convert.ToInt32(selectCommand.ExecuteScalar());
                    con.Close();

                    CustomMessageBox.Show("Tìm thấy " + count + " nhân viên trùng khớp", "Thông báo", MessageBoxButtons.OK);

                    if (count == 0)
                    {
                        dgvTimKiem.DataSource = null;
                        return;
                    }
                    else if (count > 0)
                    {
                        selectQuery = "select hosonhanvien.manhanvien,hoten,ngaysinh,gioitinh,tennoisinh,ngayvaocongty,tendantoc," +
                            "tenphongban,tenchuyenmon, tenchucvu from hosonhanvien" +
                            "\r\njoin dantoc on hosonhanvien.madantoc = dantoc.madantoc" +
                            "\r\njoin noisinh on hosonhanvien.manoisinh = noisinh.manoisinh" +
                            "\r\njoin phongban on hosonhanvien.maphongban = phongban.maphongban" +
                            "\r\njoin chuyenmon on hosonhanvien.machuyenmon = chuyenmon.machuyenmon" +
                            "\r\njoin NhanVienChucVu on hosonhanvien.manhanvien = NhanVienChucVu.manhanvien" +
                            "\r\njoin chucvu on NhanVienChucVu.machucvu = chucvu.machucvu" +
                            "\r\nwhere hoten like '%' + @hoten + '%'";

                        using (SqlCommand selectCommand2 = new SqlCommand(selectQuery, con))
                        {
                            selectCommand2.Parameters.AddWithValue("@hoten", txtHoTen.Text);
                            con.Open();
                            SqlDataReader reader = selectCommand2.ExecuteReader();
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            dgvTimKiem.DataSource = dt;
                            con.Close();
                        }
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
        }

        private void txtHoTen_MouseClick(object sender, MouseEventArgs e)
        {
            txtHoTen.SelectAll();
        }
    }
}
