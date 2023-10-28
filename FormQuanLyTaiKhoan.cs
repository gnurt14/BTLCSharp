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
    public partial class FormQuanLyTaiKhoan : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OI20CUM\ADMIN;Initial Catalog=QuanLyTinhLuong;User ID=sa;Password=1");
        SqlCommand command;
        SqlDataAdapter adapterData = new SqlDataAdapter();
        DataTable dt = new DataTable();
        public FormQuanLyTaiKhoan()
        {
            InitializeComponent();
        }
        void Load_Data()
        {
            command = con.CreateCommand();
            command.CommandText = "select username, pass, roletype from Role join Taikhoan on role.roleid = Taikhoan.roleid";
            adapterData.SelectCommand = command;
            dt.Clear();
            adapterData.Fill(dt);
            dgvQLTK.DataSource = dt;
            dgvQLTK.Columns["username"].HeaderText = "Tên đăng nhập";
            dgvQLTK.Columns["username"].Width = 180;
            dgvQLTK.Columns["pass"].HeaderText = "Mật khẩu";
            dgvQLTK.Columns["pass"].Width = 180;
            dgvQLTK.Columns["roletype"].HeaderText = "Loại tài khoản";
            dgvQLTK.Columns["roletype"].Width = 245;
        }
        void Load_Combobox()
        {
            string query = "select roletype from role";
            using (SqlCommand command = new SqlCommand(query, con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string item = reader["roletype"].ToString();
                        cmbLoaiTaiKhoan.Items.Add(item);
                    }
                }
            }
        }
        private void FormQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            con.Open();
            Load_Data();
            Load_Combobox();
            con.Close();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text;
            string password = txtMatKhau.Text;
            string role = cmbLoaiTaiKhoan.SelectedItem?.ToString();

            if (ValidationHelper.ValidateUsername(username) && ValidationHelper.ValidatePassword(password))
            {
                if (!string.IsNullOrEmpty(role))
                {
                    int roleid = role.Equals("Quản trị viên") ? 1 : 2;
                    // Kiểm tra tài khoản đã tồn tại hay chưa
                    string selectQuery = "SELECT COUNT(*) FROM TaiKhoan WHERE username = @username";
                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, con))
                    {
                        selectCommand.Parameters.AddWithValue("@username", username);
                        con.Open();
                        int count = Convert.ToInt32(selectCommand.ExecuteScalar());
                        con.Close();

                        if (count > 0)
                        {
                            CustomMessageBox.Show("Tài khoản đã tồn tại trong cơ sở dữ liệu. Vui lòng chọn tài khoản khác.", "Cảnh báo", MessageBoxButtons.OK);
                            return;
                        }
                    }

                    con.Open();
                    using (SqlCommand command = con.CreateCommand())
                    {
                        // Thêm mới bản ghi vào bảng TaiKhoan
                        command.CommandText = "INSERT INTO TaiKhoan (username, pass, roleid) VALUES (@username, @pass, @roleid)";
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@pass", password);
                        command.Parameters.AddWithValue("@roleid", roleid);
                        command.ExecuteNonQuery();
                    }
                    con.Close();
                    Load_Data();
                }
                else
                {
                    CustomMessageBox.Show("Các trường không được để trống", "Cảnh báo");
                }
            }
            else
            {
                CustomMessageBox.Show("Tài khoản hoặc mật khẩu chưa đúng định dạng", "Cảnh báo");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text != string.Empty && txtMatKhau.Text != string.Empty && cmbLoaiTaiKhoan.SelectedItem != null)
            {
                if (CustomMessageBox.Show("Bạn có chắc chắn muốn xoá tài khoản này?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    con.Open();
                    command = con.CreateCommand();
                    string username = txtTaiKhoan.Text;
                    command.CommandText = "DELETE FROM TaiKhoan WHERE username = @username";
                    command.Parameters.AddWithValue("@username", username);
                    command.ExecuteNonQuery();
                    Load_Data();
                    con.Close();
                }
            }
            else
            {
                CustomMessageBox.Show("Vui lòng chọn tài khoản muốn xoá", "Thông báo");
            }
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTaiKhoan.Text = string.Empty;
            txtMatKhau.Text = string.Empty;
            cmbLoaiTaiKhoan.SelectedItem = null;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string username = txtTaiKhoan.Text, existingUsername = txtTaiKhoan.Text;
            string password = txtMatKhau.Text;
            string role = cmbLoaiTaiKhoan.SelectedItem?.ToString();

            if (ValidationHelper.ValidateUsername(username) && ValidationHelper.ValidatePassword(password))
            {
                int roleid = role.Equals("Quản trị viên") ? 1 : 0;

                bool isUsernameChanged = !username.Equals(existingUsername); // existingUsername là biến lưu trữ tên người dùng hiện tại

                if (isUsernameChanged)
                {
                    // Kiểm tra xem tài khoản đã tồn tại hay chưa
                    string selectQuery = "SELECT COUNT(*) FROM TaiKhoan WHERE username = @username";
                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, con))
                    {
                        selectCommand.Parameters.AddWithValue("@username", username);
                        con.Open();
                        int count = Convert.ToInt32(selectCommand.ExecuteScalar());
                        con.Close();

                        if (count > 0)
                        {
                            CustomMessageBox.Show("Tài khoản đã tồn tại", "Cảnh báo", MessageBoxButtons.OK);
                            return;
                        }
                    }
                }

                if (CustomMessageBox.Show("Bạn có chắc chắn muốn cập nhật tài khoản này?", "Cảnh báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    con.Open();
                    using (SqlCommand command = con.CreateCommand())
                    {
                        command.CommandText = "UPDATE TaiKhoan SET username = @username, pass = @pass, roleid = @roleid WHERE username = @existingUsername";
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@pass", password);
                        command.Parameters.AddWithValue("@roleid", roleid);
                        command.Parameters.AddWithValue("@existingUsername", existingUsername);
                        command.ExecuteNonQuery();
                    }
                    con.Close();
                }
            }
            Load_Data();
        }

        private void dgvQLTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvQLTK.Rows[e.RowIndex];
                txtTaiKhoan.Text = selectedRow.Cells[0].Value.ToString();
                txtMatKhau.Text = selectedRow.Cells[1].Value.ToString();
                string comboBoxValue = selectedRow.Cells[2].Value.ToString();
                cmbLoaiTaiKhoan.SelectedItem = comboBoxValue;
            }
        }

        private void txtTaiKhoan_Click(object sender, EventArgs e)
        {
            txtTaiKhoan.SelectAll();
        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {
            txtMatKhau.Text = string.Empty;
            cmbLoaiTaiKhoan.SelectedItem = null;
        }
    }
}
