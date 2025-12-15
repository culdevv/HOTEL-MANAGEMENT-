using Guna.UI2.WinForms;
using System.Data.SqlClient;
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
    public partial class UC_Users : UserControl
    {
        public UC_Users()
        {
            InitializeComponent();
            gvData.CellClick += gvData_CellClick;
            btnAdd.Click += btnAdd_Click;
        }

        private void UC_Users_Load(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            using (SqlConnection conn = DAL.GetConnection())
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT user_id, user_code, full_name, date_of_birth, email, phone, role, status FROM Users";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    gvData.DataSource = dt;

                    gvData.Columns["user_id"].HeaderText = "User ID";
                    gvData.Columns["date_of_birth"].HeaderText = "DOB";
                    gvData.Columns["date_of_birth"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    gvData.Columns["user_code"].HeaderText = "User Code";
                    gvData.Columns["full_name"].HeaderText = "Full Name";
                    gvData.Columns["phone"].HeaderText = "Phone";
                    gvData.Columns["email"].HeaderText = "Email";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
                }
            }
        }

        private int selectedUserId = -1;

        private void gvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = gvData.Rows[e.RowIndex];

                selectedUserId = Convert.ToInt32(row.Cells["user_id"].Value);

                txtFull_name.Text = row.Cells["full_name"].Value.ToString();
                txtEmail.Text = row.Cells["email"].Value.ToString();
                txtPhone_number.Text = row.Cells["phone"].Value.ToString();
                txtRole.SelectedItem = row.Cells["role"].Value.ToString();
                txtStatus.SelectedItem = row.Cells["status"].Value.ToString();

                dtpDOB.Value = row.Cells["date_of_birth"].Value == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(row.Cells["date_of_birth"].Value);

                oldRole = gvData.Rows[e.RowIndex].Cells["role"].Value.ToString();
                
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private string GenerateUserCode(string role)
        {
            string prefix = "";

            switch (role)
            {
                case "admin":
                    prefix = "ADM";
                    break;
                case "receptionist":
                    prefix = "REC";
                    break;
                case "housekeeping":
                    prefix = "HOU";
                    break;
            }

            using (SqlConnection conn = DAL.GetConnection())
            {
                conn.Open();

                string query = @"
                    SELECT 
                        ISNULL(
                            MAX(CAST(SUBSTRING(user_code, 4, LEN(user_code)) AS INT)), 
                            0
                        ) + 1
                    FROM Users
                    WHERE role = @Role";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Role", role);

                int nextNumber = (int)cmd.ExecuteScalar();

                return prefix + nextNumber.ToString("D3");
            }
        }

        private bool ValidateDOB()
        {
            DateTime dob = dtpDOB.Value.Date;

            if (dob > DateTime.Today)
            {
                MessageBox.Show("Ngày sinh không được lớn hơn ngày hiện tại");
                return false;
            }
            return true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtRole.SelectedIndex == -1 || txtStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn Role và Status");
                return;
            }

            if (!ValidateDOB())
                return;

            string role = txtRole.SelectedItem.ToString();
            string userCode = GenerateUserCode(role);

            using (SqlConnection conn = DAL.GetConnection())
            {
                try
                {
                    conn.Open();

                    string query = @"
                INSERT INTO Users 
                (user_code, full_name, date_of_birth, email, phone, role, status)
                VALUES 
                (@UserCode, @FullName, @DOB, @Email, @Phone, @Role, @Status)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserCode", userCode);
                    cmd.Parameters.AddWithValue("@FullName", txtFull_name.Text.Trim());
                    cmd.Parameters.AddWithValue("@DOB", dtpDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Phone", txtPhone_number.Text.Trim());
                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.Parameters.AddWithValue("@Status", txtStatus.SelectedItem.ToString());

                    cmd.ExecuteNonQuery();

                    MessageBox.Show($"Thêm user thành công!\nMã: {userCode}");
                    LoadUsers();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Add User: " + ex.Message);
                }
            }
        }

        private string oldRole = "";

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Vui lòng chọn user");
                return;
            }

            if (!ValidateDOB())
                return;

            string newRole = txtRole.SelectedItem.ToString();
            string userCode;

            if (newRole != oldRole)
            {
                userCode = GenerateUserCode(newRole);
            }
            else
            {
                userCode = gvData.CurrentRow.Cells["user_code"].Value.ToString();
            }

            using (SqlConnection conn = DAL.GetConnection())
            {
                try
                {
                    conn.Open();

                    string query = @"
                        UPDATE Users
                        SET user_code = @UserCode,
                            full_name = @FullName,
                            date_of_birth = @DOB,
                            email = @Email,
                            phone = @Phone,
                            role = @Role,
                            status = @Status
                        WHERE user_id = @UserID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserCode", userCode);
                    cmd.Parameters.AddWithValue("@UserID", selectedUserId);
                    cmd.Parameters.AddWithValue("@FullName", txtFull_name.Text.Trim());
                    cmd.Parameters.AddWithValue("@DOB", dtpDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Phone", txtPhone_number.Text.Trim());
                    cmd.Parameters.AddWithValue("@Role", txtRole.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Status", txtStatus.SelectedItem.ToString());

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cập nhật thành công!");
                    LoadUsers();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Update: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedUserId == -1)
            {
                MessageBox.Show("Vui lòng chọn user cần xóa");
                return;
            }

            DialogResult dr = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa user này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (dr == DialogResult.No) return;

            using (SqlConnection conn = DAL.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM Users WHERE user_id = @UserID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@UserID", selectedUserId);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Xóa thành công!");
                    LoadUsers();
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi Delete: " + ex.Message);
                }
            }
        }

        private void ClearForm()
        {
            selectedUserId = -1;

            txtFull_name.Clear();
            dtpDOB.Value = DateTime.Now;
            txtEmail.Clear();
            txtPhone_number.Clear();
            txtRole.SelectedIndex = -1;
            txtStatus.SelectedIndex = -1;
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void guna2TextBox2_TextChanged(object sender, EventArgs e) { }
        private void guna2TextBox3_TextChanged(object sender, EventArgs e) { }

        private void gvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
