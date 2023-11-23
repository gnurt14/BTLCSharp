using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace QuanLyTienLuong
{
    public partial class FormDashboard : Form
    {
        private Form activeForm = null;
        private Button currentButton;
        private Button previousButton;
        private bool isAdmin;
        private Image tempImage;
        public FormDashboard(bool isAdmin)
        {
            InitializeComponent();

            // Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            this.isAdmin = isAdmin;
            tempImage = iconChildForm.Image;
        }
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlChildForm.Controls.Add(childForm);
            pnlChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }


        private void btnMenuTinhLuong_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTinhLuong());
            ActivateButton(sender);
        }

        private void btnMenuTimKiem_Click(object sender, EventArgs e)
        {
            openChildForm(new FormTimKiem());
            ActivateButton(sender);
        }

        
        private void btnDangXuat_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender);
            if (CustomMessageBox.Show("Bạn có muốn đăng xuất khỏi hệ thống?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                FormDangNhap formDangNhap = new FormDangNhap();
                if (formDangNhap.WindowState != FormWindowState.Normal)
                {
                    formDangNhap.WindowState = FormWindowState.Normal;
                }
                this.Hide();
                formDangNhap.ShowDialog();
                this.Close();
            }
            else
            {
                DisableButton();
                currentButton = previousButton;
                ActivateButton(currentButton);
            }
        }

        private void btnMaximizeDashboard_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
                this.WindowState = FormWindowState.Maximized;
        }

        private void btnCloseDashboard_Click(object sender, EventArgs e)
        {
            if (CustomMessageBox.Show("Thông báo", "Bạn có muốn đóng chương trình ?", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            ResetButton();
        }

        private void ResetButton()
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            DisableButton();
        }

        private void ActivateButton(object sender)
        {
            if (sender != null)
            {
                DisableButton();
                previousButton = currentButton;
                currentButton = (Button)sender;
                currentButton.BackColor = System.Drawing.Color.FromArgb(107, 83, 225);
                currentButton.ForeColor = System.Drawing.Color.FromArgb(244, 249, 255);
                if (currentButton == btnMenuThemTaiKhoan)
                {
                    lbChildForm.Text = "Quản lý tài khoản";
                    iconChildForm.Image = currentButton.Image;
                }
                lbChildForm.Text = currentButton.Text;
                iconChildForm.Image = currentButton.Image;
            }
        }

        private void DisableButton()
        {
            if (currentButton != null)
            {
                currentButton.BackColor = System.Drawing.Color.FromArgb(244, 249, 255);
                currentButton.ForeColor = System.Drawing.Color.FromArgb(124, 141, 181);
                lbChildForm.Text = "Trang chủ";
                iconChildForm.Image = tempImage;
            }
        }
        private void btnMenuThemTaiKhoan_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            if (isAdmin == true)
            {
                openChildForm(new FormQuanLyTaiKhoan());
            }
            else
                CustomMessageBox.Show("Chỉ có admin mới thực hiện được thao tác này");
        }

        // Drag form
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMinimizeDashboard_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

    }
}
