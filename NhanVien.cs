using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTienLuong
{
    internal class NhanVien
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
