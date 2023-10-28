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

namespace QuanLyTienLuong
{
    public partial class FormTinhLuong : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OI20CUM\ADMIN;Initial Catalog=QuanLyTinhLuong;User ID=sa;Password=1");
        SqlCommand command;
        SqlDataAdapter adapterData = new SqlDataAdapter();
        DataTable dt = new DataTable();
        public FormTinhLuong()
        {
            InitializeComponent();
        }
        void Load_Combobox()
        {
            string query1 = "select tenphongban from phongban";
            string query2 = "select thang from luong";
            string query3 = "select nam from luong";
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
            using (SqlCommand command = new SqlCommand(query2, con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string item = reader["thang"].ToString();
                        cmbThang.Items.Add(item);
                    }
                }
            }
            using (SqlCommand command = new SqlCommand(query3, con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string item = reader["nam"].ToString();
                        cmbNam.Items.Add(item);
                    }
                }
            }
        }
        private void FormTinhLuong_Load(object sender, EventArgs e)
        {
            con.Open();
            Load_Combobox();
            con.Close();
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {

        }
    }
}
