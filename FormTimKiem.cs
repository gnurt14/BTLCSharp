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
                        Console.WriteLine(item);
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
    }
}
