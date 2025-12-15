using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChuongTrinhQuanLyKhachSan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateNewCaptcha();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click_1(object sender, EventArgs e)
        {
            guna2PictureBox1.Dock = DockStyle.Left;
            guna2PictureBox1.Width = 400;
            guna2PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private string currentCaptchaCode; // Biến lưu mã Captcha hiện tại

        private void GenerateNewCaptcha()
        {
            // 1. Tạo chuỗi ngẫu nhiên
            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            int length = 6; // Độ dài 6 ký tự

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                sb.Append(validChars[random.Next(validChars.Length)]);
            }
            currentCaptchaCode = sb.ToString();

            // 2. Tạo hình ảnh Captcha
            int width = 231;
            int height = 71;

            // Tạo Bitmap và đối tượng Graphics
            Bitmap captchaImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(captchaImage))
            {
                // Tô nền trắng
                g.Clear(Color.White);

                // Chọn font chữ đơn giản và to
                Font font = new Font("Arial", 18, FontStyle.Bold);
                SolidBrush brush = new SolidBrush(Color.Black);

                // Thiết lập căn chỉnh văn bản
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                Rectangle rect = new Rectangle(0, 0, width, height);

                // Vẽ chuỗi Captcha lên hình ảnh
                g.DrawString(currentCaptchaCode, font, brush, rect, sf);
            }
            pictureBoxCaptcha.Image = captchaImage;
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            string userInputCaptcha = txtCaptcha.Text;
            string codetoCompare = currentCaptchaCode;

            if (userInputCaptcha != codetoCompare)
            {
                MessageBox.Show("Mã xác nhận không đúng. Vui lòng thử lại!");
                txtCaptcha.Clear();
                GenerateNewCaptcha();
            }
            else
            {
                if (txtTenDangNhap.Text == "Trung" && txtMatKhau.Text == "1")
                {
                    Dashboard ds = new Dashboard();
                    this.Hide();
                    ds.Show();

                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng. Vui lòng thử lại!");
                    txtMatKhau.Clear();
                    txtTenDangNhap.Clear();
                    txtCaptcha.Clear();
                    GenerateNewCaptcha();
                }
            }
        }
    }
}
