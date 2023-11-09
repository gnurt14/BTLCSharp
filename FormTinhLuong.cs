using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
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
using System.Windows.Markup;

namespace QuanLyTienLuong
{
    public partial class FormTinhLuong : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OI20CUM\ADMIN;Initial Catalog=QuanLyTinhLuong;User ID=sa;Password=1");
        SqlCommand command;
        SqlDataAdapter adapterData = new SqlDataAdapter();
        DataTable dt = new DataTable();

        int selectedIndex;
        public FormTinhLuong()
        {
            InitializeComponent();
        }
        void Load_Combobox()
        {
            string query1 = "select tenphongban from phongban";
            using (SqlCommand command = new SqlCommand(query1, con))
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
        }
        void Load_data(string thang)
        {
            command.Parameters.Clear();
            command.CommandText = "select hosonhanvien.manhanvien, hoten, tenchucvu, luong, thang, phucap, baohiemyte, baohiemxahoi ,khenthuongkl, thuclinh from luong \r\njoin hosonhanvien on hosonhanvien.manhanvien = luong.manhanvien\r\njoin NhanVienChucVu on luong.manhanvien = NhanVienChucVu.manhanvien\r\njoin chucvu on chucvu.machucvu = NhanVienChucVu.machucvu\r\njoin phongban on hosonhanvien.maphongban = phongban.maphongban\r\nwhere tenphongban like N'%' + @tenphongban + N'%' and thang = @thang";
            command.Parameters.AddWithValue("@tenphongban", cmbPhongBan.SelectedItem.ToString());
            command.Parameters.AddWithValue("@thang",thang);
            dt.Clear();
            command.ExecuteNonQuery();
            adapterData.SelectCommand = command;
            adapterData.Fill(dt);
            dgvTinhLuong.DataSource = dt;
        }
        private void FormTinhLuong_Load(object sender, EventArgs e)
        {
            con.Open();
            Load_Combobox();
            con.Close();
            ToolTip  tt1 = new ToolTip();
            tt1.SetToolTip(btnBaoCaoLuong, "Báo cáo bảng lương cho toàn cơ quan trong tháng");
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {

            // Bắt buộc phải chọn đủ các trường
            if(cmbPhongBan.SelectedItem == null || cmbThang.SelectedItem == null || cmbNam.SelectedItem == null)
            {
                CustomMessageBox.Show("Vui lòng chọn đầy đủ các trường.", "Thông báo");
            }
            else
            {
                int currentMonth = DateTime.Now.Month;
                int currentYear = DateTime.Now.Year;
                string[] parts = cmbThang.Text.Split(' ');
                string thang = parts[parts.Length - 1];
                //int selectedMonth = Convert.ToInt32(thang);
                int selectedMonth;
                if (int.TryParse(thang, out selectedMonth))
                {
                    
                }
                int selectedYear = Convert.ToInt32(cmbNam.SelectedItem.ToString());
                con.Open();
                // Xét tháng phải  < tháng hiện tại (tính lương cho tháng vừa qua)
                if (selectedYear < currentYear || (selectedMonth < currentMonth && selectedYear == currentYear))
                {
                    int maphongban1;
                    if (cmbPhongBan.SelectedItem.ToString().Equals("Phòng ban hành chính"))
                    {
                        maphongban1 = 1;
                    }
                    else if (cmbPhongBan.SelectedItem.ToString().Equals("Phòng ban kiểm toán"))
                    {
                        maphongban1 = 2;
                    }
                    else if (cmbPhongBan.SelectedItem.ToString().Equals("Phòng ban kế toán"))
                    {
                        maphongban1 = 3;
                    }
                    else if (cmbPhongBan.SelectedItem.ToString().Equals("Phòng ban nhân sự"))
                    {
                        maphongban1 = 4;
                    }
                    else
                    {
                        maphongban1 = 5;
                    }
                    command = con.CreateCommand();
                    command.CommandText = "SELECT manhanvien FROM hosonhanvien WHERE maphongban = @maphongban";
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@maphongban", maphongban1.ToString());
                    List<string> nhanVientList = new List<string>();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0))
                            {
                                string manhanvien = reader.GetString(0);
                                nhanVientList.Add(manhanvien);
                            }
                        }
                    }
                    string checkQuery = "select count(*) from luong where thang = @thang and nam = @nam and manhanvien = @manhanvien";
                    command = con.CreateCommand();
                    foreach (string manhanvien in nhanVientList)
                    {
                        command.CommandText = checkQuery;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@manhanvien", manhanvien);
                        command.Parameters.AddWithValue("@thang", selectedMonth);
                        command.Parameters.AddWithValue("@nam", selectedYear);
                        int count = Convert.ToInt32(command.ExecuteScalar());
                        if (count < 1)
                        {
                            string getHosoNhanVienQuery = "SELECT NgayVaoCongTy FROM hosonhanvien WHERE manhanvien = @manhanvien";
                            command.CommandText = getHosoNhanVienQuery;
                            command.Parameters.Clear();
                            command.Parameters.AddWithValue("@manhanvien", manhanvien);
                            DateTime ngayVaoCongTy = (DateTime)command.ExecuteScalar();

                            // Kiểm tra điều kiện NgayVaoCongTy phải nhỏ hơn tháng hiện tại, nếu không không được tính
                            if (ngayVaoCongTy.Year < selectedYear || (ngayVaoCongTy.Year == selectedYear && ngayVaoCongTy.Month < selectedMonth))
                            {
                                string insertQuery = "INSERT INTO luong (maphongban, manhanvien, thang, nam) VALUES (@maphongban, @manhanvien2, @thang, @nam)";
                                command.CommandText = insertQuery;
                                command.Parameters.Clear();
                                command.Parameters.AddWithValue("@maphongban", maphongban1);
                                command.Parameters.AddWithValue("@manhanvien2", manhanvien);
                                command.Parameters.AddWithValue("@thang", selectedMonth);
                                command.Parameters.AddWithValue("@nam", selectedYear);
                                command.ExecuteNonQuery();
                            }
                        }
                    }
                    CustomMessageBox.Show("Tính lương tháng " + thang + " hoàn tất");
                    Load_data(selectedMonth.ToString());
                    con.Close();
                }
                else
                {
                    CustomMessageBox.Show("Vui lòng chọn tháng/năm nhỏ hơn thời gian hiện tại", "Cảnh báo");
                }
            }
        }
        private void btnInBangLuongPhongBan_Click(object sender, EventArgs e)
        {
            if (cmbPhongBan.SelectedItem == null || cmbThang.SelectedItem == null || cmbNam.SelectedItem == null)
            {
                CustomMessageBox.Show("Vui lòng chọn đầy đủ các trường.", "Thông báo");
            }
            else
            {
                int currentMonth = DateTime.Now.Month;
                string[] parts = cmbThang.Text.Split(' ');
                string thang = parts[parts.Length - 1];
                int selectedMonth = Convert.ToInt32(thang);
                bool result = selectedMonth >= currentMonth;
                if (result == false)
                {
                    if (CustomMessageBox.Show("In bảng lương chi tiết cho " + cmbPhongBan.SelectedItem.ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string query = "select hoten, luong, phucap, baohiemyte, baohiemxahoi, khenthuongKL, thuclinh from luong join hosonhanvien on hosonhanvien.manhanvien = luong.manhanvien and thang = '"+thang+"'";
                        InBangLuong inBangLuong = new InBangLuong();
                        string tenBangLuong = "BangLuong_" + cmbPhongBan.SelectedItem.ToString() + "_" + cmbThang.SelectedItem.ToString().Trim() + "_" + cmbNam.SelectedItem.ToString();
                        string phongban = cmbPhongBan.SelectedItem.ToString();
                        inBangLuong.InBangLuongChiTiet(query, tenBangLuong,thang, phongban);
                    } 
                }
                else
                {
                    CustomMessageBox.Show("Vui lòng chọn tháng/năm nhỏ hơn thời gian hiện tại", "Cảnh báo");
                }
            }
        }

        private void btnInBangLuongNV_Click(object sender, EventArgs e)
        {
            if (cmbPhongBan.SelectedItem == null || cmbThang.SelectedItem == null || cmbNam.SelectedItem == null)
            {
                CustomMessageBox.Show("Vui lòng chọn đầy đủ các trường.", "Thông báo");
            }
            else
            {
                if (dgvTinhLuong.Rows.Count > 0)
                {
                    string ten = dgvTinhLuong.Rows[selectedIndex].Cells["hoten"].Value.ToString();
                    if (CustomMessageBox.Show("In bảng lương chi tiết cho nhân viên " + ten + " ?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string query = "SELECT hoten, luong, phucap, baohiemyte, baohiemxahoi, khenthuongkl, thuclinh FROM luong join hosonhanvien on hosonhanvien.manhanvien = luong.manhanvien WHERE hoten = N'" + ten + "'";
                        InBangLuong inBangLuong = new InBangLuong();
                        string tenBangLuong = "BangLuongNhanVien_" + ten + "_" + cmbPhongBan.SelectedItem.ToString() + "_" + cmbThang.SelectedItem.ToString().Trim() + "_" + cmbNam.SelectedItem.ToString();
                        string[] parts = cmbThang.Text.Split(' ');
                        string thang = parts[parts.Length - 1];
                        string phongban = string.Empty;
                        inBangLuong.InBangLuongChiTiet(query, tenBangLuong, thang, phongban);
                    } 
                }
                else
                {
                    CustomMessageBox.Show("Vui lòng chọn 1 nhân viên");
                }
            }
        }

        private void dgvTinhLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedIndex = e.RowIndex;
        }

        private void btnBaoCaoLuong_Click(object sender, EventArgs e)
        {
            if( CustomMessageBox.Show("Bạn có muốn xuất báo cáo lương "+ cmbThang.Text +" toàn cơ quan?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string[] parts = cmbThang.Text.Split(' ');
                string thang = parts[parts.Length - 1];
                InBangLuong inBangLuong = new InBangLuong();
                inBangLuong.BaoCaoLuongToanCoQuan(thang);
            }
        }
    }
}

