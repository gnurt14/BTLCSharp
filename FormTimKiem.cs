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
        private void FormTimKiem_Load(object sender, EventArgs e)
        {
            con.Open();
            Load_Combobox();
            con.Close(); 
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
                        return;
                    }
                    else if (count > 0)
                    {
                        selectQuery = "select hosonhanvien.manhanvien,hoten,ngaysinh,gioitinh,tennoisinh,ngayvaocongty,tendantoc,tenphongban,tenchuyenmon, tenchucvu, tentrinhdo from hosonhanvien join dantoc on hosonhanvien.madantoc = dantoc.madantoc join noisinh on hosonhanvien.manoisinh = noisinh.manoisinh join phongban on hosonhanvien.maphongban = phongban.maphongban join chuyenmon on hosonhanvien.machuyenmon = chuyenmon.machuyenmon join NhanVienChucVu on hosonhanvien.manhanvien = NhanVienChucVu.manhanvien join chucvu on NhanVienChucVu.machucvu = chucvu.machucvu join nhanvientrinhdo on nhanvientrinhdo.manhanvien = hosonhanvien.manhanvien  join trinhdo on trinhdo.matrinhdo = nhanvientrinhdo.matrinhdo where hoten like '%' + @hoten + '%'";

                        using (SqlCommand selectCommand2 = new SqlCommand(selectQuery, con))
                        {
                            selectCommand2.Parameters.AddWithValue("@hoten", txtHoTen.Text);
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
