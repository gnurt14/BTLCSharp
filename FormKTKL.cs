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
namespace QuanLyTienLuong
{
    public partial class FormKTKL : Form
    {
        string tennhanvien, manhanvien, thangktkl, namktkl;
        public FormKTKL(string manv, string tennv, string thang, string nam)
        {
            tennhanvien = tennv;
            manhanvien = manv;
            thangktkl = thang;
            namktkl = nam;
            InitializeComponent();
            if (rdbKhong.Checked == true)
            {
                txtLyDoKTKL.Enabled = false;
                txtTienKTKL.Enabled = false;
            }
        }

        private void rdbKhong_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbKhong.Checked == true)
            {
                txtLyDoKTKL.Enabled = false;
                txtTienKTKL.Enabled = false;
            }
            else
            {
                txtLyDoKTKL.Enabled = true;
                txtTienKTKL.Enabled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (rdbKhong.Checked == true)
            {
                this.Close();
                CustomMessageBox.Show("Thêm hoàn tất");
            }
            else
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OI20CUM\ADMIN;Initial Catalog=QuanLyTinhLuong;User ID=sa;Password=1"))
                {
                    con.Open();
                    string[] parts = thangktkl.Split(' ');
                    string thangs = parts[parts.Length - 1];
                    using (SqlTransaction transaction = con.BeginTransaction())
                    {
                        try
                        {
                            string query = "INSERT INTO khenthuongkyluat(manhanvien, loaiktkl, thang, nam, malydoktkl, tienktkl) VALUES (@manhanvien, @loaiktkl, @thang, @nam, @malydoktkl, @tienktkl)";
                            string updateplusquery = "UPDATE luong SET khenthuongKL = khenthuongKL + @tienktkl, thuclinh = thuclinh + @tienktkl WHERE thang = @thangs AND nam = @nams AND manhanvien = @manhanvien";
                            string updateminusquery = "UPDATE luong SET khenthuongKL = khenthuongKL - @tienktkl, thuclinh = thuclinh - @tienktkl WHERE thang = @thangs AND nam = @nams AND manhanvien = @manhanvien";

                            using (SqlCommand command = new SqlCommand(query, con, transaction))
                            {
                                command.Parameters.AddWithValue("@manhanvien", manhanvien);
                                command.Parameters.AddWithValue("@loaiktkl", txtLyDoKTKL.Text);
                                command.Parameters.AddWithValue("@thang", thangs);
                                command.Parameters.AddWithValue("@nam", namktkl);
                                command.Parameters.AddWithValue("@malydoktkl", rdbKhenThuong.Checked ? 1 : 2);
                                command.Parameters.AddWithValue("@tienktkl", txtTienKTKL.Text);

                                command.ExecuteNonQuery();
                            }

                            string updatequery = rdbKhenThuong.Checked ? updateplusquery : updateminusquery;

                            using (SqlCommand updateCommand = new SqlCommand(updatequery, con, transaction))
                            {
                                updateCommand.Parameters.AddWithValue("@manhanvien", manhanvien);
                                updateCommand.Parameters.AddWithValue("@thangs", thangs);
                                updateCommand.Parameters.AddWithValue("@nams", namktkl);
                                updateCommand.Parameters.AddWithValue("@tienktkl", txtTienKTKL.Text);

                                updateCommand.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            CustomMessageBox.Show(rdbKhenThuong.Checked ? "Thêm khen thưởng thành công!" : "Thêm kỷ luật thành công!");
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            Console.WriteLine(ex.Message);
                            CustomMessageBox.Show("Thêm không thành công. Vui lòng kiểm tra lại.");
                        }
                    }
                }
            }
        }
        private void FormKTKL_Load(object sender, EventArgs e)
        {
            LbTenNV.Text = tennhanvien;
            lbThangNam.Text = thangktkl + " - " + namktkl;
        }
    }
}
