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
using System.Text.RegularExpressions;

namespace QuanLyTienLuong
{
    public partial class FormDangNhap : Form
    {
        private bool isAdmin;
        public FormDangNhap()
        {
            InitializeComponent();
            lbLoginFail.Visible = false;
            isAdmin = false;
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OI20CUM\ADMIN;Initial Catalog=QuanLyTinhLuong;User ID=sa;Password=1");
        private void btnLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDashboard formDashboard = new FormDashboard(isAdmin);
            formDashboard.ShowDialog();
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(CustomMessageBox.Show("Thông báo", "Bạn có muốn thoát chương trình ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormTimKiem formDangKy = new FormTimKiem();
            formDangKy.ShowDialog();
            this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (ValidationHelper.ValidateUsername(txtUserLogin.Text) == true 
                && ValidationHelper.ValidatePassword(txtPasswordLogin.Text) == true)
            {
                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("select username, pass, roletype from Taikhoan inner join Role on Taikhoan.roleid = role.roleid where username = @username and pass = @password", con);
                    command.Parameters.AddWithValue("@username", txtUserLogin.Text);
                    command.Parameters.AddWithValue("@password", txtPasswordLogin.Text);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string usertype = dt.Rows[0][2].ToString();
                        if (usertype.Equals("Quản trị viên"))
                        {
                            CustomMessageBox.Show("Welcome Adminitrator!");
                            isAdmin = true;
                        }
                        else if (usertype.Equals("Nhân viên"))
                        {
                            CustomMessageBox.Show("Welcome Employee");
                        }
                        this.Hide();
                        FormDashboard frm = new FormDashboard(isAdmin);
                        frm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        lbLoginFail.Visible = true;
                    }
                    con.Close();
                }
                catch
                {
                    lbLoginFail.Visible = true;
                }
            }
            else
            {
                lbLoginFail.Visible = true;
            }
            
        }

        private void FormDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void txtUserLogin_TextChanged(object sender, EventArgs e)
        {
            lbLoginFail.Visible = false;
            txtPasswordLogin.Text = string.Empty;
        }

        private void txtPasswordLogin_TextChanged(object sender, EventArgs e)
        {
            lbLoginFail.Visible = false;
        }

        private void txtUserLogin_MouseClick(object sender, MouseEventArgs e)
        {
            txtUserLogin.SelectAll();
        }
        public static bool ValidateUsername(string username)
        {
            string pattern = @"^[a-zA-Z0-9._]+$";
            return Regex.IsMatch(username, pattern);
        }

        public static bool ValidatePassword(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$";
            return Regex.IsMatch(password, pattern);
        }
    }
}
