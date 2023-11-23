using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyTienLuong
{
    public partial class FormTinhLuong : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OI20CUM\ADMIN;Initial Catalog=QuanLyTinhLuong;User ID=sa;Password=1");
        SqlDataAdapter adapterData = new SqlDataAdapter();
        DataTable dt = new DataTable();

        bool isTinhLuongButtonClick = false;
        bool isCal_HanhChinh = false;
        bool isCal_KiemToan = false;
        bool isCal_KeToan = false;
        bool isCal_NhanSu = false;
        bool isCal_CNTT = false;

        int selectedIndex;
        public FormTinhLuong()
        {
            InitializeComponent();
            if (isTinhLuongButtonClick == false)
            {
                btnInBangLuongNV.Enabled = false;
                btnInBangLuongPhongBan.Enabled = false;
                btnBaoCaoLuong.Enabled = false;
            }
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
                cmbPhongBan.Items.Add("Toàn cơ quan");
            }
        }
        public void Load_data(string thang, bool phongban)
        {
            string query = "SELECT hosonhanvien.manhanvien, hoten, tenphongban,tenchucvu, luong, thang, phucap, baohiemyte, baohiemxahoi, khenthuongkl, thuclinh FROM luong " +
                                      "JOIN hosonhanvien ON hosonhanvien.manhanvien = luong.manhanvien " +
                                      "JOIN NhanVienChucVu ON luong.manhanvien = NhanVienChucVu.manhanvien " +
                                      "JOIN chucvu ON chucvu.machucvu = NhanVienChucVu.machucvu " +
                                      "JOIN phongban ON hosonhanvien.maphongban = phongban.maphongban " +
                                      "WHERE tenphongban LIKE N'%' + @tenphongban + N'%' AND thang = @thang";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                if (phongban == true)
                    command.Parameters.AddWithValue("@tenphongban", cmbPhongBan.SelectedItem.ToString());
                else
                {
                    command.Parameters.AddWithValue("@tenphongban", "");
                }
                command.Parameters.AddWithValue("@thang", thang);

                dt.Clear();

                adapterData.SelectCommand = command;
                adapterData.Fill(dt);

                dgvTinhLuong.DataSource = dt;

                dgvTinhLuong.Columns["manhanvien"].HeaderText = "Mã nhân viên";
                dgvTinhLuong.Columns["manhanvien"].Width = 120;
                dgvTinhLuong.Columns["hoten"].HeaderText = "Họ tên";
                dgvTinhLuong.Columns["hoten"].Width = 150;
                dgvTinhLuong.Columns["tenphongban"].Width = 150;
                dgvTinhLuong.Columns["tenphongban"].HeaderText = "Phòng ban";
                dgvTinhLuong.Columns["tenchucvu"].HeaderText = "Chức vụ";
                dgvTinhLuong.Columns["tenchucvu"].Width = 120;
                dgvTinhLuong.Columns["luong"].HeaderText = "Lương";
                dgvTinhLuong.Columns["luong"].Width = 150;
                dgvTinhLuong.Columns["thang"].HeaderText = "Tháng";
                dgvTinhLuong.Columns["thang"].Width = 50;
                dgvTinhLuong.Columns["phucap"].HeaderText = "Phụ cấp";
                dgvTinhLuong.Columns["phucap"].Width = 150;
                dgvTinhLuong.Columns["baohiemyte"].HeaderText = "BHYT";
                dgvTinhLuong.Columns["baohiemyte"].Width = 150;
                dgvTinhLuong.Columns["baohiemxahoi"].HeaderText = "BHXH";
                dgvTinhLuong.Columns["baohiemxahoi"].Width = 150;
                dgvTinhLuong.Columns["khenthuongkl"].HeaderText = "KT/KL";
                dgvTinhLuong.Columns["khenthuongkl"].Width = 150;
                dgvTinhLuong.Columns["thuclinh"].HeaderText = "Thực lĩnh";
                dgvTinhLuong.Columns["thuclinh"].Width = 150;
            }
        }
        private void FormTinhLuong_Load(object sender, EventArgs e)
        {
            con.Open();
            Load_Combobox();
            con.Close();
            ToolTip tt1 = new ToolTip();
            tt1.SetToolTip(btnBaoCaoLuong, "Báo cáo bảng lương cho toàn cơ quan trong tháng");
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {

            // Bắt buộc phải chọn đủ các trường
            if (cmbPhongBan.SelectedItem == null || cmbThang.SelectedItem == null || cmbNam.SelectedItem == null)
            {
                CustomMessageBox.Show("Vui lòng chọn đầy đủ các trường.", "Thông báo");
            }
            else
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OI20CUM\ADMIN;Initial Catalog=QuanLyTinhLuong;User ID=sa;Password=1"))
                {
                    con.Open();

                    int currentMonth = DateTime.Now.Month;
                    int currentYear = DateTime.Now.Year;

                    string[] parts = cmbThang.Text.Split(' ');
                    string thang = parts[parts.Length - 1];

                    int selectedMonth;
                    if (int.TryParse(thang, out selectedMonth))
                    {

                    }
                    int selectedYear = Convert.ToInt32(cmbNam.SelectedItem.ToString());

                    if (selectedYear < currentYear || (selectedMonth < currentMonth && selectedYear == currentYear))
                    {
                        int maphongban1;

                        switch (cmbPhongBan.SelectedItem.ToString())
                        {
                            case "Phòng ban hành chính":
                                maphongban1 = 1;
                                break;
                            case "Phòng ban kiểm toán":
                                maphongban1 = 2;
                                break;
                            case "Phòng ban kế toán":
                                maphongban1 = 3;
                                break;
                            case "Phòng ban nhân sự":
                                maphongban1 = 4;
                                break;
                            case "Phòng ban công nghệ thông tin":
                                maphongban1 = 5;
                                break;
                            default:
                                maphongban1 = 6;
                                isCal_CNTT = true;
                                isCal_HanhChinh = true;
                                isCal_KeToan = true;
                                isCal_KiemToan = true;
                                isCal_NhanSu = true;
                                break;
                        }
                        if(maphongban1 == 6)
                        {
                            List<int> Maphongban = new List<int> { 1, 2, 3, 4, 5 };
                            foreach (int departmentCode in Maphongban)
                            {
                                string checkQuery = "SELECT COUNT(*) FROM luong WHERE thang = @thang AND nam = @nam AND maphongban = @maphongban";

                                using (SqlCommand checkCommand = new SqlCommand(checkQuery, con))
                                {
                                    checkCommand.Parameters.AddWithValue("@thang", selectedMonth);
                                    checkCommand.Parameters.AddWithValue("@nam", selectedYear);
                                    checkCommand.Parameters.AddWithValue("@maphongban", departmentCode);

                                    int existingRecordsCount = (int)checkCommand.ExecuteScalar();

                                    if (existingRecordsCount > 0)
                                    {

                                    }
                                    else
                                    {
                                        List<LuongNhanVien> nhanVienList = new List<LuongNhanVien>();
                                        try
                                        {
                                            using (var command = con.CreateCommand())
                                            {
                                                command.CommandText = "SELECT manhanvien FROM hosonhanvien";

                                                using (var reader = command.ExecuteReader())
                                                {
                                                    while (reader.Read())
                                                    {
                                                        if (!reader.IsDBNull(0))
                                                        {
                                                            LuongNhanVien nv = new LuongNhanVien();
                                                            string manhanvien = reader.GetString(0);
                                                            nv.manv = manhanvien;

                                                            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-OI20CUM\ADMIN;Initial Catalog=QuanLyTinhLuong;User ID=sa;Password=1");

                                                            // HSL
                                                            try
                                                            {
                                                                SqlCommand commandHSL = conn.CreateCommand();
                                                                commandHSL.CommandText = "SELECT tenhesoluong FROM hesoluong JOIN nhanvienhesoluong ON hesoluong.mahesoluong = nhanvienhesoluong.mahesoluong WHERE nhanvienhesoluong.manhanvien = @manhanvien";
                                                                commandHSL.Parameters.AddWithValue("@manhanvien", manhanvien);
                                                                conn.Open();
                                                                string temp = (string)commandHSL.ExecuteScalar();
                                                                nv.hsl = float.Parse(temp);
                                                                conn.Close();
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                Console.WriteLine($"Lỗi khi truy vấn HSL cho nhân viên {manhanvien}: {ex.Message}");
                                                            }

                                                            // phucaptd
                                                            try
                                                            {
                                                                SqlCommand commandPhucapTD = conn.CreateCommand();
                                                                commandPhucapTD.CommandText = "select phucap from trinhdo join nhanvientrinhdo on nhanvientrinhdo.matrinhdo = trinhdo.Matrinhdo where nhanvientrinhdo.manhanvien = @manhanvien";
                                                                commandPhucapTD.Parameters.AddWithValue("@manhanvien", manhanvien);
                                                                conn.Open();
                                                                double temp = (double)commandPhucapTD.ExecuteScalar();
                                                                nv.phucaptd = (float)temp;
                                                                conn.Close();
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                Console.WriteLine($"Lỗi khi truy vấn phụ cấp trình độ cho nhân viên {manhanvien}: {ex.Message}");
                                                            }

                                                            // phucapcv
                                                            try
                                                            {
                                                                SqlCommand commandPhucapCV = conn.CreateCommand();

                                                                commandPhucapCV.CommandText = "select phucapcv from chucvu join NhanVienChucVu on NhanVienChucVu.machucvu = chucvu.machucvu where NhanVienChucVu.manhanvien = @manhanvien";
                                                                commandPhucapCV.Parameters.AddWithValue("@manhanvien", manhanvien);
                                                                conn.Open();
                                                                double temp = (double)commandPhucapCV.ExecuteScalar();
                                                                nv.phucapcv = (float)temp;
                                                                conn.Close();
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                Console.WriteLine($"Lỗi khi truy vấn phụ cấp chức vụ cho nhân viên {manhanvien}: {ex.Message}");
                                                            }
                                                            //phongban
                                                            try
                                                            {
                                                                SqlCommand commandPB = conn.CreateCommand();

                                                                commandPB.CommandText = "select maphongban from hosonhanvien where manhanvien = @manhanvien";
                                                                commandPB.Parameters.AddWithValue("@manhanvien", manhanvien);
                                                                conn.Open();
                                                                int temp = (int)commandPB.ExecuteScalar();
                                                                nv.maphongban = (int)temp;
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                Console.WriteLine($"Lỗi khi truy vấn mã phòng ban cho nhân viên {manhanvien}: {ex.Message}");
                                                            }
                                                            // ktkl
                                                            try
                                                            {
                                                                SqlCommand commandKTKL = conn.CreateCommand();

                                                                commandKTKL.CommandText = "select tienktkl from khenthuongkyluat where manhanvien = @manhanvien and thang = @thang and nam = @nam";
                                                                commandKTKL.Parameters.AddWithValue("@manhanvien", manhanvien);
                                                                commandKTKL.Parameters.AddWithValue("@thang", selectedMonth);
                                                                commandKTKL.Parameters.AddWithValue("@nam", selectedYear);
                                                                conn.Open();
                                                                if (commandKTKL.ExecuteScalar() != null)
                                                                {
                                                                    double temp = (double)commandKTKL.ExecuteScalar();
                                                                    nv.ktkl = (float)temp;
                                                                    Console.WriteLine(nv.ktkl);
                                                                }
                                                                else
                                                                {
                                                                    nv.ktkl = 0;
                                                                }
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                Console.WriteLine($"Lỗi khi truy vấn khenthuongkyluat cho nhân viên {manhanvien}: {ex.Message}");
                                                            }
                                                            finally
                                                            {
                                                                conn.Close();
                                                            }
                                                            nv.luong = nv.hsl * 1800000;
                                                            nv.bhxt = (float)(nv.luong * 0.1);
                                                            nv.bhyt = (float)(nv.luong * 0.05);
                                                            nv.thuclinh = nv.luong + nv.phucapcv + nv.phucaptd - nv.bhxt - nv.bhyt + nv.ktkl;

                                                            // Thêm nhân viên hiện tại vào list
                                                            nhanVienList.Add(nv);
                                                        }
                                                    }
                                                    reader.Close();
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine($"Lỗi chung: {ex.Message}");
                                        }
                                        finally
                                        {

                                        }

                                        // Insert calculated salaries into the database
                                        string insertQuery = "INSERT INTO luong(maphongban, manhanvien, thang, nam, luong, phucap, baohiemyte, baohiemxahoi, khenthuongKL, thuclinh) VALUES (@maphongban, @manhanvien, @thang, @nam, @luong, @phucap, @baohiemyte, @baohiemxahoi, @khenthuongKL, @thuclinh)";

                                        using (var command = con.CreateCommand())
                                        {
                                            foreach (LuongNhanVien nv in nhanVienList)
                                            {
                                                if (nv.maphongban == departmentCode)
                                                {
                                                    command.CommandText = insertQuery;
                                                    command.Parameters.Clear();
                                                    command.Parameters.AddWithValue("@maphongban", nv.maphongban);
                                                    command.Parameters.AddWithValue("@manhanvien", nv.manv);
                                                    command.Parameters.AddWithValue("@thang", selectedMonth);
                                                    command.Parameters.AddWithValue("@nam", selectedYear);
                                                    command.Parameters.AddWithValue("@luong", nv.luong.ToString());
                                                    command.Parameters.AddWithValue("@phucap", (nv.phucapcv + nv.phucaptd).ToString());
                                                    command.Parameters.AddWithValue("@baohiemyte", nv.bhyt.ToString());
                                                    command.Parameters.AddWithValue("@baohiemxahoi", nv.bhxt.ToString());
                                                    command.Parameters.AddWithValue("@khenthuongKL", nv.ktkl.ToString());
                                                    command.Parameters.AddWithValue("@thuclinh", nv.thuclinh.ToString());
                                                    command.ExecuteNonQuery();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            CustomMessageBox.Show($"Tính lương cho tháng {thang} hoàn tất.");
                            Load_data(selectedMonth.ToString(), false);
                            btnInBangLuongPhongBan.Enabled = true;
                            btnInBangLuongNV.Enabled = true;
                            btnBaoCaoLuong.Enabled = true;
                        }
                        // tinh luong tung phong ban
                        else if (KiemTraLuongDaDuocTinh(selectedMonth, maphongban1) == true)
                        {
                            CustomMessageBox.Show("Lương tháng " + thang + " đã được tính");
                            Load_data(selectedMonth.ToString(), true);
                            btnInBangLuongPhongBan.Enabled = true;
                            btnInBangLuongNV.Enabled = true;


                            if (isCal_CNTT && isCal_HanhChinh && isCal_KeToan && isCal_KiemToan && isCal_NhanSu)
                            {
                                btnBaoCaoLuong.Enabled = true;
                            }
                        }
                        else if (KiemTraLuongDaDuocTinh(selectedMonth, maphongban1) == false)
                        {
                            List<LuongNhanVien> nhanVienList = new List<LuongNhanVien>();
                            try
                            {
                                using (var command = con.CreateCommand())
                                {
                                    command.CommandText = "SELECT manhanvien FROM hosonhanvien WHERE maphongban = @maphongban";
                                    command.Parameters.AddWithValue("@maphongban", maphongban1.ToString());

                                    using (var reader = command.ExecuteReader())
                                    {
                                        while (reader.Read())
                                        {
                                            if (!reader.IsDBNull(0))
                                            {
                                                LuongNhanVien nv = new LuongNhanVien();
                                                string manhanvien = reader.GetString(0);
                                                nv.manv = manhanvien;

                                                SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-OI20CUM\ADMIN;Initial Catalog=QuanLyTinhLuong;User ID=sa;Password=1");

                                                // HSL
                                                try
                                                {
                                                    SqlCommand commandHSL = conn.CreateCommand();
                                                    commandHSL.CommandText = "SELECT tenhesoluong FROM hesoluong JOIN nhanvienhesoluong ON hesoluong.mahesoluong = nhanvienhesoluong.mahesoluong WHERE nhanvienhesoluong.manhanvien = @manhanvien";
                                                    commandHSL.Parameters.AddWithValue("@manhanvien", manhanvien);
                                                    conn.Open();
                                                    string temp = (string)commandHSL.ExecuteScalar();
                                                    nv.hsl = float.Parse(temp);
                                                    conn.Close();
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine($"Lỗi khi truy vấn HSL cho nhân viên {manhanvien}: {ex.Message}");
                                                }

                                                // phucaptd
                                                try
                                                {
                                                    SqlCommand commandPhucapTD = conn.CreateCommand();
                                                    commandPhucapTD.CommandText = "select phucap from trinhdo join nhanvientrinhdo on nhanvientrinhdo.matrinhdo = trinhdo.Matrinhdo where nhanvientrinhdo.manhanvien = @manhanvien";
                                                    commandPhucapTD.Parameters.AddWithValue("@manhanvien", manhanvien);
                                                    conn.Open();
                                                    double temp = (double)commandPhucapTD.ExecuteScalar();
                                                    nv.phucaptd = (float)temp;
                                                    conn.Close();
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine($"Lỗi khi truy vấn phụ cấp trình độ cho nhân viên {manhanvien}: {ex.Message}");
                                                }

                                                // phucapcv
                                                try
                                                {
                                                    SqlCommand commandPhucapCV = conn.CreateCommand();

                                                    commandPhucapCV.CommandText = "select phucapcv from chucvu join NhanVienChucVu on NhanVienChucVu.machucvu = chucvu.machucvu where NhanVienChucVu.manhanvien = @manhanvien";
                                                    commandPhucapCV.Parameters.AddWithValue("@manhanvien", manhanvien);
                                                    conn.Open();
                                                    double temp = (double)commandPhucapCV.ExecuteScalar();
                                                    nv.phucapcv = (float)temp;
                                                    conn.Close();
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine($"Lỗi khi truy vấn phụ cấp chức vụ cho nhân viên {manhanvien}: {ex.Message}");
                                                }

                                                // ktkl
                                                try
                                                {
                                                    SqlCommand commandKTKL = conn.CreateCommand();

                                                    commandKTKL.CommandText = "select tienktkl from khenthuongkyluat where manhanvien = @manhanvien and thang = @thang and nam = @nam";
                                                    commandKTKL.Parameters.AddWithValue("@manhanvien", manhanvien);
                                                    commandKTKL.Parameters.AddWithValue("@thang", selectedMonth);
                                                    commandKTKL.Parameters.AddWithValue("@nam", selectedYear);
                                                    conn.Open();
                                                    if (commandKTKL.ExecuteScalar() != null)
                                                    {
                                                        double temp = (double)commandKTKL.ExecuteScalar();
                                                        nv.ktkl = (float)temp;
                                                        Console.WriteLine(nv.ktkl);
                                                    }
                                                    else
                                                    {
                                                        nv.ktkl = 0;
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine($"Lỗi khi truy vấn khenthuongkyluat cho nhân viên {manhanvien}: {ex.Message}");
                                                }
                                                finally
                                                {
                                                    conn.Close();
                                                }
                                                nv.luong = nv.hsl * 1800000;
                                                nv.bhxt = (float)(nv.luong * 0.1);
                                                nv.bhyt = (float)(nv.luong * 0.05);
                                                nv.thuclinh = nv.luong + nv.phucapcv + nv.phucaptd - nv.bhxt - nv.bhyt + nv.ktkl;

                                                // Thêm nhân viên hiện tại vào list
                                                nhanVienList.Add(nv);
                                            }
                                        }
                                        reader.Close();
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Lỗi chung: {ex.Message}");
                            }
                            finally
                            {

                            }
                            string insertQuery = "insert into luong(maphongban, manhanvien, thang, nam, luong, phucap, baohiemyte, baohiemxahoi, khenthuongKL, thuclinh) values (@maphongban, @manhanvien, @thang, @nam, @luong, @phucap, @baohiemyte, @baohiemxahoi, @khenthuongKL, @thuclinh)";
                            using (var command = con.CreateCommand())
                            {
                                //command.CommandText = clearQuery;
                                //command.ExecuteNonQuery();
                                foreach (LuongNhanVien nv in nhanVienList)
                                {
                                    command.CommandText = insertQuery;
                                    command.Parameters.Clear();
                                    command.Parameters.AddWithValue("@maphongban", maphongban1);
                                    command.Parameters.AddWithValue("@manhanvien", nv.manv);
                                    command.Parameters.AddWithValue("@thang", selectedMonth);
                                    command.Parameters.AddWithValue("@nam", selectedYear);
                                    command.Parameters.AddWithValue("@luong", nv.luong.ToString());
                                    command.Parameters.AddWithValue("@phucap", (nv.phucapcv + nv.phucaptd).ToString());
                                    command.Parameters.AddWithValue("@baohiemyte", nv.bhyt.ToString());
                                    command.Parameters.AddWithValue("@baohiemxahoi", nv.bhxt.ToString());
                                    command.Parameters.AddWithValue("@khenthuongKL", nv.ktkl.ToString());
                                    command.Parameters.AddWithValue("@thuclinh", nv.thuclinh.ToString());
                                    command.ExecuteNonQuery();
                                }
                            }
                            CustomMessageBox.Show("Tính lương tháng " + thang + " hoàn tất");
                            Load_data(selectedMonth.ToString(), true);
                            btnInBangLuongPhongBan.Enabled = true;
                            btnInBangLuongNV.Enabled = true;
                        }
                        else
                        {
                            CustomMessageBox.Show("Vui lòng chọn tháng/năm nhỏ hơn thời gian hiện tại", "Cảnh báo");
                        }
                    }
                }
            }
        }


        //Bảng lương phòng ban
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
                        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-OI20CUM\ADMIN;Initial Catalog=QuanLyTinhLuong;User ID=sa;Password=1");
                        SqlCommand commandInBangLuongPhongban = conn.CreateCommand();
                        List<NhanVien> employees = new List<NhanVien>();
                        commandInBangLuongPhongban.CommandText = "select hoten, luong, phucap, baohiemyte, baohiemxahoi, khenthuongKL, thuclinh from luong join hosonhanvien on hosonhanvien.manhanvien = luong.manhanvien and luong.thang = @thang where hosonhanvien.maphongban = @maphongban";
                        try
                        {
                            conn.Open();
                            commandInBangLuongPhongban.Parameters.AddWithValue("@thang", thang);
                            commandInBangLuongPhongban.Parameters.AddWithValue("@maphongban", (cmbPhongBan.SelectedIndex));
                            SqlDataReader readerIn = commandInBangLuongPhongban.ExecuteReader();
                            while (readerIn.Read())
                            {
                                if (!readerIn.IsDBNull(0))
                                {
                                    NhanVien nhanvien = new NhanVien();
                                    nhanvien.hoten = readerIn["hoten"].ToString();
                                    nhanvien.luong = (float)Convert.ToDouble(readerIn["luong"]);
                                    nhanvien.PhuCap = (float)Convert.ToDouble(readerIn["phucap"]);
                                    nhanvien.BHYT = (float)Convert.ToDouble(readerIn["baohiemyte"]);
                                    nhanvien.BHXH = (float)Convert.ToDouble(readerIn["baohiemxahoi"]);
                                    nhanvien.KTKL = (float)Convert.ToDouble(readerIn["khenthuongKL"]);
                                    nhanvien.ThucLinh = (float)Convert.ToDouble(readerIn["thuclinh"]);
                                    employees.Add(nhanvien);
                                }
                            }
                            conn.Close();
                        }
                        catch
                        {
                            Console.WriteLine("Lỗi khi thêm nhân viên vào list");
                        }

                        Excel.Application excelApp = new Excel.Application();
                        Excel.Workbook workbook = excelApp.Workbooks.Add();
                        Excel.Worksheet worksheet = workbook.ActiveSheet;

                        worksheet.Cells[1, 3] = "TẬP ĐOÀN VIỄN THÔNG VIỆT NAM";
                        Excel.Range rangeTenCty = worksheet.Range["A1:F1"];
                        rangeTenCty.Merge();
                        worksheet.Cells[2, 1] = "ĐỊA CHỈ: 1111 đường Láng, Láng Thượng, Đống Đa, Hà Nội";
                        Excel.Range rangeTenCty1 = worksheet.Range["A1:F1"];
                        rangeTenCty1.Merge();
                        worksheet.Cells[3, 1] = "HOTLINE: (024) 999 9999";
                        Excel.Range rangeTenCty2 = worksheet.Range["A1:F1"];
                        rangeTenCty2.Merge();
                        Excel.Range companyInfoRange = worksheet.Range["A1:A3"];
                        companyInfoRange.Font.Bold = true;

                        worksheet.Cells[5, 2] = "BẢNG LƯƠNG CHI TIẾT THÁNG " + selectedMonth;
                        worksheet.Cells[5, 2].Font.Bold = true;
                        //gộp các cột
                        Excel.Range mergeRange = worksheet.Range["B5:E5"];
                        mergeRange.Merge();
                        worksheet.Cells[6, 2] = cmbPhongBan.SelectedItem.ToString();
                        worksheet.Cells[6, 2].Font.Bold = true;
                        Excel.Range mergeRangee = worksheet.Range["B6:E6"];
                        mergeRangee.Merge();

                        worksheet.Cells[7, 1] = "STT";
                        worksheet.Cells[7, 2] = "Họ tên";
                        worksheet.Cells[7, 3] = "Lương";
                        worksheet.Cells[7, 4] = "Phụ cấp";
                        worksheet.Cells[7, 5] = "BHYT";
                        worksheet.Cells[7, 6] = "BHXH";
                        worksheet.Cells[7, 7] = "KTKL";
                        worksheet.Cells[7, 8] = "Thực lĩnh";

                        Excel.Range headerRange = worksheet.Range["A7:H7"];
                        headerRange.Font.Bold = true;
                        headerRange.Interior.Color = System.Drawing.Color.LightGray;

                        // Format độ rộng
                        int startColumn = 2; // Cột B
                        int endColumn = 8; // Cột G
                        int desiredWidth = 15; // Độ rộng mong muốn
                        for (int col = startColumn; col <= endColumn; col++)
                        {
                            Excel.Range column1 = worksheet.Columns[col];
                            column1.ColumnWidth = desiredWidth;
                        }

                        // căn chỉnh 
                        Excel.Range dataRangee = worksheet.UsedRange;

                        for (int col = 1; col <= dataRangee.Columns.Count; col++)
                        {
                            Excel.Range column = dataRangee.Columns[col];

                            // Kiểm tra nếu cột không thuộc A1, A2, A3 và nằm trong khoảng từ A đến H
                            if (column.Cells[1, 1].Address != "$A$1" && column.Cells[1, 1].Address != "$A$2" && column.Cells[1, 1].Address != "$A$3" && col >= 1 && col <= 8)
                            {
                                column.HorizontalAlignment = Excel.Constants.xlCenter; // Căn giữa ngang
                                column.VerticalAlignment = Excel.Constants.xlCenter; // Căn giữa dọc
                            }
                        }

                        for (int i = 0; i < employees.Count; i++)
                        {
                            worksheet.Cells[i + 8, 1] = i + 1;
                            worksheet.Cells[i + 8, 2] = employees[i].hoten;
                            worksheet.Cells[i + 8, 3] = employees[i].luong;
                            worksheet.Cells[i + 8, 4] = employees[i].PhuCap;
                            worksheet.Cells[i + 8, 5] = employees[i].BHYT;
                            worksheet.Cells[i + 8, 6] = employees[i].BHXH;
                            worksheet.Cells[i + 8, 7] = employees[i].KTKL;
                            worksheet.Cells[i + 8, 8] = employees[i].ThucLinh;
                        }

                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Excel Files|*.xlsx";
                        saveFileDialog.Title = "Save file...";
                        saveFileDialog.FileName = "BangLuong_" + cmbPhongBan.SelectedItem.ToString() + "_" + cmbThang.SelectedItem.ToString().Trim() + "_" + cmbNam.SelectedItem.ToString();
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string filePath = saveFileDialog.FileName;
                            workbook.SaveAs(filePath);
                            workbook.Close();
                            excelApp.Quit();
                            CustomMessageBox.Show("Lưu file thành công");
                        }
                    }
                }
                else
                {
                    CustomMessageBox.Show("Vui lòng chọn tháng/năm nhỏ hơn thời gian hiện tại", "Cảnh báo");
                }
            }
        }


        // Bảng lương nhân viên 
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
                    string manhanvien = dgvTinhLuong.Rows[selectedIndex].Cells["manhanvien"].Value.ToString();
                    if (CustomMessageBox.Show("In bảng lương chi tiết cho nhân viên " + ten + " ?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string[] parts = cmbThang.Text.Split(' ');
                        string thang = parts[parts.Length - 1];
                        string phongban = string.Empty;

                        Excel.Application excelApp = new Excel.Application();
                        Excel.Workbook workbook = excelApp.Workbooks.Add();
                        Excel.Worksheet worksheet = workbook.ActiveSheet;

                        worksheet.Cells[8, 1] = 1;
                        worksheet.Cells[8, 2] = ten;
                        worksheet.Cells[8, 3] = dgvTinhLuong.Rows[selectedIndex].Cells["luong"].Value.ToString();
                        worksheet.Cells[8, 4] = dgvTinhLuong.Rows[selectedIndex].Cells["phucap"].Value.ToString();
                        worksheet.Cells[8, 5] = dgvTinhLuong.Rows[selectedIndex].Cells["baohiemyte"].Value.ToString();
                        worksheet.Cells[8, 6] = dgvTinhLuong.Rows[selectedIndex].Cells["baohiemxahoi"].Value.ToString();
                        worksheet.Cells[8, 7] = dgvTinhLuong.Rows[selectedIndex].Cells["khenthuongKL"].Value.ToString();
                        worksheet.Cells[8, 8] = dgvTinhLuong.Rows[selectedIndex].Cells["thuclinh"].Value.ToString();


                        worksheet.Cells[1, 3] = "TẬP ĐOÀN VIỄN THÔNG VIỆT NAM";
                        Excel.Range rangeTenCty = worksheet.Range["A1:F1"];
                        rangeTenCty.Merge();
                        worksheet.Cells[2, 1] = "ĐỊA CHỈ: 1111 đường Láng, Láng Thượng, Đống Đa, Hà Nội";
                        Excel.Range rangeTenCty1 = worksheet.Range["A1:F1"];
                        rangeTenCty1.Merge();
                        worksheet.Cells[3, 1] = "HOTLINE: (024) 999 9999";
                        Excel.Range rangeTenCty2 = worksheet.Range["A1:F1"];
                        rangeTenCty2.Merge();
                        Excel.Range companyInfoRange = worksheet.Range["A1:A3"];
                        companyInfoRange.Font.Bold = true;

                        worksheet.Cells[5, 2] = "BẢNG LƯƠNG CHI TIẾT THÁNG " + thang;
                        worksheet.Cells[5, 2].Font.Bold = true;
                        //gộp các cột
                        Excel.Range mergeRange = worksheet.Range["B5:E5"];
                        mergeRange.Merge();
                        worksheet.Cells[6, 2] = cmbPhongBan.SelectedItem.ToString();
                        worksheet.Cells[6, 2].Font.Bold = true;
                        Excel.Range mergeRangee = worksheet.Range["B6:E6"];
                        mergeRangee.Merge();

                        worksheet.Cells[7, 1] = "STT";
                        worksheet.Cells[7, 2] = "Họ tên";
                        worksheet.Cells[7, 3] = "Lương";
                        worksheet.Cells[7, 4] = "Phụ cấp";
                        worksheet.Cells[7, 5] = "BHYT";
                        worksheet.Cells[7, 6] = "BHXH";
                        worksheet.Cells[7, 7] = "KTKL";
                        worksheet.Cells[7, 8] = "Thực lĩnh";

                        Excel.Range headerRange = worksheet.Range["A7:H7"];
                        headerRange.Font.Bold = true;
                        headerRange.Interior.Color = System.Drawing.Color.LightGray;

                        // Format độ rộng
                        int startColumn = 2; // Cột B
                        int endColumn = 8; // Cột G
                        int desiredWidth = 15; // Độ rộng mong muốn
                        for (int col = startColumn; col <= endColumn; col++)
                        {
                            Excel.Range column1 = worksheet.Columns[col];
                            column1.ColumnWidth = desiredWidth;
                        }

                        // căn chỉnh 
                        Excel.Range dataRangee = worksheet.UsedRange;

                        for (int col = 1; col <= dataRangee.Columns.Count; col++)
                        {
                            Excel.Range column = dataRangee.Columns[col];

                            // Kiểm tra nếu cột không thuộc A1, A2, A3 và nằm trong khoảng từ A đến H
                            if (column.Cells[1, 1].Address != "$A$1" && column.Cells[1, 1].Address != "$A$2" && column.Cells[1, 1].Address != "$A$3" && col >= 1 && col <= 8)
                            {
                                column.HorizontalAlignment = Excel.Constants.xlCenter; // Căn giữa ngang
                                column.VerticalAlignment = Excel.Constants.xlCenter; // Căn giữa dọc
                            }
                        }

                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Excel Files|*.xlsx";
                        saveFileDialog.Title = "Save file...";
                        saveFileDialog.FileName = "Bảng Lương nhân viên " + ten + " - " + cmbPhongBan.SelectedItem.ToString() + "_" + cmbThang.SelectedItem.ToString().Trim() + "_" + cmbNam.SelectedItem.ToString();
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string filePath = saveFileDialog.FileName;
                            workbook.SaveAs(filePath);
                            workbook.Close();
                            excelApp.Quit();
                            CustomMessageBox.Show("Lưu file thành công");
                        }
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


        // Báo cáo lương toàn cơ quan
        private void btnBaoCaoLuong_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.Show("Bạn có muốn xuất báo cáo lương " + cmbThang.Text + " toàn cơ quan?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string[] parts = cmbThang.Text.Split(' ');
                string thang = parts[parts.Length - 1];
                List<TienLuong> listLuong = new List<TienLuong>();

                con.Open();
                using (var command = new SqlCommand("SELECT tenphongban, SUM(thuclinh) AS tongtien, SUM(phucapcv) AS phucapcv FROM luong " +
                                                    "JOIN phongban ON luong.maphongban = phongban.maphongban " +
                                                    "JOIN NhanVienChucVu nvcv ON luong.manhanvien = nvcv.manhanvien " +
                                                    "JOIN chucvu ON nvcv.machucvu = chucvu.machucvu " +
                                                    "WHERE thang = @thang " +
                                                    "GROUP BY tenphongban", con))
                {
                    command.Parameters.AddWithValue("@thang", thang);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tenPhongBan = reader.GetString(reader.GetOrdinal("tenphongban"));
                            double tongLuongPhongBan = reader.GetDouble(reader.GetOrdinal("tongtien"));
                            double phuCapChucVu = reader.GetDouble(reader.GetOrdinal("phucapcv"));

                            TienLuong tienLuong = new TienLuong
                            {
                                TenPhongBan = tenPhongBan,
                                TongLuongPhongBan = (float)tongLuongPhongBan,
                                PhuCapChucVu = (float)phuCapChucVu
                            };
                            listLuong.Add(tienLuong);
                        }
                    }
                }
                con.Close();
                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = workbook.ActiveSheet;

                worksheet.Cells[1, 3] = "TẬP ĐOÀN VIỄN THÔNG VIỆT NAM";
                Excel.Range rangeTenCty = worksheet.Range["A1:F1"];
                rangeTenCty.Merge();
                worksheet.Cells[2, 1] = "ĐỊA CHỈ: 1111 đường Láng, Láng Thượng, Đống Đa, Hà Nội";
                Excel.Range rangeTenCty1 = worksheet.Range["A1:F1"];
                rangeTenCty1.Merge();
                worksheet.Cells[3, 1] = "HOTLINE: (024) 999 9999";
                Excel.Range rangeTenCty2 = worksheet.Range["A1:F1"];
                rangeTenCty2.Merge();
                Excel.Range companyInfoRange = worksheet.Range["A1:A3"];
                companyInfoRange.Font.Bold = true;

                worksheet.Cells[5, 2] = "BÁO CÁO LƯƠNG TOÀN CƠ QUAN THÁNG " + thang;
                worksheet.Cells[5, 2].Font.Bold = true;
                //gộp
                Excel.Range mergeRange = worksheet.Range["B5:E5"];
                mergeRange.Merge();
                Excel.Range mergeRangee = worksheet.Range["B6:E6"];
                mergeRangee.Merge();


                worksheet.Cells[7, 1] = "STT";
                worksheet.Cells[7, 2] = "Tên phòng ban";
                worksheet.Cells[7, 3] = "Phụ cấp chức vụ";
                worksheet.Cells[7, 4] = "Thực lĩnh";
                for (int i = 0; i < listLuong.Count; i++)
                {
                    worksheet.Cells[i + 8, 1] = i + 1;
                    worksheet.Cells[i + 8, 2] = listLuong[i].TenPhongBan;
                    worksheet.Cells[i + 8, 3] = listLuong[i].PhuCapChucVu.ToString();
                    worksheet.Cells[i + 8, 4] = listLuong[i].TongLuongPhongBan.ToString();
                }

                // Tổng 
                int lastRow = listLuong.Count + 8;

                // Tính tổng tiền lương và phụ cấp chức vụ
                double totalSalary = listLuong.Sum(item => item.TongLuongPhongBan);
                double totalAllowance = listLuong.Sum(item => item.PhuCapChucVu);

                // Thêm hàng tổng cộng vào cuối bảng
                worksheet.Cells[lastRow, 1] = "Tổng cộng";
                worksheet.Cells[lastRow, 3] = totalAllowance.ToString("N");
                worksheet.Cells[lastRow, 4] = totalSalary.ToString("N");


                Excel.Range headerRange = worksheet.Range["A7:H7"];
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = System.Drawing.Color.LightGray;

                // Format tiền
                Excel.Range dataRange = worksheet.Range["C8:D" + (listLuong.Count + 7)];
                dataRange.NumberFormat = "#,##0.00";

                // Format độ rộng
                int startColumn = 2; // Cột B
                int endColumn = 8; // Cột G
                int desiredWidth = 15; // Độ rộng mong muốn
                for (int col = startColumn; col <= endColumn; col++)
                {
                    Excel.Range column1 = worksheet.Columns[col];
                    column1.ColumnWidth = desiredWidth;
                }

                // căn chỉnh 
                Excel.Range dataRangee = worksheet.UsedRange;

                for (int col = 1; col <= dataRangee.Columns.Count; col++)
                {
                    Excel.Range column = dataRangee.Columns[col];

                    // Kiểm tra nếu cột không thuộc A1, A2, A3 và nằm trong khoảng từ A đến H
                    if (column.Cells[1, 1].Address != "$A$1" && column.Cells[1, 1].Address != "$A$2" && column.Cells[1, 1].Address != "$A$3" && col >= 1 && col <= 8)
                    {
                        column.HorizontalAlignment = Excel.Constants.xlCenter; // Căn giữa ngang
                        column.VerticalAlignment = Excel.Constants.xlCenter; // Căn giữa dọc
                    }
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Save file...";
                saveFileDialog.FileName = "BÁO CÁO LƯƠNG TOÀN CƠ QUAN THÁNG " + thang;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;
                    workbook.SaveAs(filePath);
                    workbook.Close();
                    excelApp.Quit();
                    CustomMessageBox.Show("Lưu file thành công");
                }
            }
        }

        private bool KiemTraLuongDaDuocTinh(int thang, int maphongban)
        { 
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-OI20CUM\ADMIN;Initial Catalog=QuanLyTinhLuong;User ID=sa;Password=1");
            SqlCommand command = conn.CreateCommand();
            conn.Open();
            command.CommandText = "select count(*) from luong where thang = @thang and maphongban = @maphongban";
            command.Parameters.AddWithValue("@thang", thang);
            command.Parameters.AddWithValue("@maphongban", maphongban);
            int count = (int)command.ExecuteScalar();
            conn.Close();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void cmbPhongBan_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int maphongban1;
            switch (cmbPhongBan.SelectedItem.ToString())
            {
                case "Phòng ban hành chính":
                    maphongban1 = 1;
                    break;
                case "Phòng ban kiểm toán":
                    maphongban1 = 2;
                    break;
                case "Phòng ban kế toán":
                    maphongban1 = 3;
                    break;
                case "Phòng ban nhân sự":
                    maphongban1 = 4;
                    break;
                case "Phòng ban công nghệ thông tin":
                    maphongban1 = 5;
                    break;
                default:
                    maphongban1 = 6;
                    break;
            }
            string selectallQuery = "select manhanvien, hoten from hosonhanvien";
            string selectQuery = "select manhanvien, hoten from hosonhanvien where maphongban = @maphongban";
            if (maphongban1 == 6)
            {
                using (SqlCommand selectCommand2 = new SqlCommand(selectallQuery, con))
                {
                    con.Open();
                    SqlDataReader reader = selectCommand2.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dgvTinhLuong.DataSource = dt;
                    dgvTinhLuong.Columns["manhanvien"].HeaderText = "Mã nhân viên";
                    dgvTinhLuong.Columns["manhanvien"].Width = 120;
                    dgvTinhLuong.Columns["hoten"].HeaderText = "Họ tên";
                    dgvTinhLuong.Columns["hoten"].Width = 180;
                    con.Close();
                }
            }
            else
            {
                using (SqlCommand selectCommand2 = new SqlCommand(selectQuery, con))
                {
                    selectCommand2.Parameters.AddWithValue("@maphongban", maphongban1);
                    con.Open();
                    SqlDataReader reader = selectCommand2.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dgvTinhLuong.DataSource = dt;
                    dgvTinhLuong.Columns["manhanvien"].HeaderText = "Mã nhân viên";
                    dgvTinhLuong.Columns["manhanvien"].Width = 120;
                    dgvTinhLuong.Columns["hoten"].HeaderText = "Họ tên";
                    dgvTinhLuong.Columns["hoten"].Width = 180;
                    con.Close();
                }
            }
        }
        private void dgvTinhLuong_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(cmbThang.SelectedItem == null || cmbNam.SelectedItem == null)
            {
                CustomMessageBox.Show("Vui lòng chọn đầy đủ trường tháng,năm");
            }
            else
            {
                string manv = dgvTinhLuong.Rows[selectedIndex].Cells["manhanvien"].Value.ToString();
                string tennv = dgvTinhLuong.Rows[selectedIndex].Cells["hoten"].Value.ToString();
                FormKTKL formKTKL = new FormKTKL(manv, tennv, cmbThang.SelectedItem.ToString(), cmbNam.SelectedItem.ToString());
                formKTKL.FormClosed += FormKTKL_FormClosed;
                formKTKL.ShowDialog();
            }
        }
        private void FormKTKL_FormClosed(object sender, FormClosedEventArgs e)
        {
            string[] parts = cmbThang.Text.Split(' ');
            string thang = parts[parts.Length - 1];
            Load_data(thang, false);
        }
    }

}

