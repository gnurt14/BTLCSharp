using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyTienLuong
{
    internal class InBangLuong
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OI20CUM\ADMIN;Initial Catalog=QuanLyTinhLuong;User ID=sa;Password=1");
        SqlCommand command = new SqlCommand();
        public void InBangLuongChiTiet(string query, string tenbangluong, string thangluong, string phongban)
        {
            
            con.Open();

            // Truy vấn dữ liệu từ SQL Server
            SqlDataReader reader = command.ExecuteReader();

            // Tạo danh sách nhân viên
            List<NhanVien> employees = new List<NhanVien>();
            while (reader.Read())
            {
                NhanVien nhanvien = new NhanVien
                {
                    hoten = reader["hoten"].ToString(),
                    luong = (float)Convert.ToDouble(reader["luong"]),
                    PhuCap = (float)Convert.ToDouble(reader["phucap"]),
                    BHYT = (float)Convert.ToDouble(reader["baohiemyte"]),
                    BHXH = (float)Convert.ToDouble(reader["baohiemxahoi"]),
                    KTKL = (float)Convert.ToDouble(reader["khenthuongKL"]),
                    ThucLinh = (float)Convert.ToDouble(reader["thuclinh"])
                };
                employees.Add(nhanvien);
            }
            reader.Close();

            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;

            worksheet.Cells[1, 3]  = "TẬP ĐOÀN VIỄN THÔNG VIỆT NAM";
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

            worksheet.Cells[5, 2] = "BẢNG LƯƠNG CHI TIẾT THÁNG " + thangluong;
            worksheet.Cells[5, 2].Font.Bold = true;
            //gộp
            Excel.Range mergeRange = worksheet.Range["B5:E5"];
            mergeRange.Merge();
            if (phongban != string.Empty)
            {
                worksheet.Cells[6, 2] = phongban;
                worksheet.Cells[6, 2].Font.Bold = true;
                Excel.Range mergeRangee = worksheet.Range["B6:E6"];
                mergeRangee.Merge();
            }

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

            // Format tiền
            Excel.Range dataRange = worksheet.Range["C8:H" + (employees.Count + 7)];
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
            saveFileDialog.FileName = tenbangluong.Trim();
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                workbook.SaveAs(filePath);
                workbook.Close();
                excelApp.Quit();
                CustomMessageBox.Show("Lưu file thành công");
            }
        }
        public void BaoCaoLuongToanCoQuan(string thang)
        {
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
            for(int i = 0; i < listLuong.Count; i++)
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

        public class NhanVien
        {
            public string hoten { get; set; }
            public float luong { get; set; }
            public float PhuCap { get; set; }
            public float BHYT { get; set; }
            public float BHXH { get; set; }
            public float KTKL { get; set; }
            public float ThucLinh { get; set; }
        }
        public class TienLuong
        {
            public string TenPhongBan { get; set; }
            public float TongLuongPhongBan { get; set; }
            public float PhuCapChucVu { get; set; }
        }
    }
}
