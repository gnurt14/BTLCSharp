using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTienLuong
{
    public class ValidationHelper
    {
        public static bool ValidateUsername(string username)
        {
            /*Tên người dùng chỉ được chứa các chữ cái, số, dấu chấm và dấu gạch dưới*/
            string pattern = @"^[a-zA-Z0-9._]+$";
            return Regex.IsMatch(username, pattern);
        }

        public static bool ValidatePassword(string password)
        {
            /* mật khẩu có độ dài tối thiểu là 6, bao gồm ít nhất 1 kí tự viết hoa, 1 kí tự viết thường 
             và 1 kí tự đặc biệt */
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$";
            return Regex.IsMatch(password, pattern);
        }
        public static bool ValidateTimeMaskTextBox(MaskedTextBox maskedTextBox)
        {
            DateTime parsedDate;

            string input = maskedTextBox.Text;
            if (DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
