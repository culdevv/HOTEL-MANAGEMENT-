using Guna.UI2.WinForms;
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
using System.Xml.Linq;

namespace ChuongTrinhQuanLyKhachSan
{
    public partial class UC_Customer : UserControl
    {
        public UC_Customer()
        {
            InitializeComponent();
            btnAdd.Click -= btnAdd_Click;
            btnAdd.Click += btnAdd_Click;
            gvCustomerData.CellClick -= gvCustomerData_CellClick;
            gvCustomerData.CellClick += gvCustomerData_CellClick;
            btnUpdate.Click -= btnUpdate_Click;
            btnUpdate.Click += btnUpdate_Click;
        }

        private void UC_Customer_Load(object sender, EventArgs e)
        {
            LoadCustomer();
        }
        private void LoadCustomer(string keyword = "")
        {
            using (SqlConnection conn = DAL.GetConnection())
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT customer_id, full_name, date_of_birth, identity_card, phone_number, email, nationality, address
                                     FROM Customer
                                     WHERE @keyword = '%%' OR
                                        full_name     LIKE @keyword OR
                                        identity_card LIKE @keyword OR
                                        phone_number  LIKE @keyword OR
                                        email         LIKE @keyword";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    gvCustomerData.DataSource = dt;

                    gvCustomerData.Columns["customer_id"].HeaderText = "Customer ID";
                    gvCustomerData.Columns["full_name"].HeaderText = "Full Name";
                    gvCustomerData.Columns["date_of_birth"].HeaderText = "DOB";
                    gvCustomerData.Columns["date_of_birth"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    gvCustomerData.Columns["identity_card"].HeaderText = "Identity Card";
                    gvCustomerData.Columns["phone_number"].HeaderText = "Phone";
                    gvCustomerData.Columns["email"].HeaderText = "Email";
                    gvCustomerData.Columns["nationality"].HeaderText = "Nationality";
                    gvCustomerData.Columns["address"].HeaderText = "Address";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi load dữ liệu: " + ex.Message);
                }
            }
        }

        private int selectedCustomerId = -1;
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

        private bool ValidateIdentityCard()
        {
            if (string.IsNullOrWhiteSpace(txtIdentity_card.Text))
            {
                MessageBox.Show("Vui lòng nhập CCCD / Hộ chiếu!",
                                "Thiếu thông tin",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtIdentity_card.Focus();
                return false;
            }

            return true;
        }

        private bool IsIdentityCardExists(SqlConnection conn, string identityCard)
        {
            string sql = "SELECT COUNT(*) FROM Customer WHERE identity_card = @IdentityCard";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@IdentityCard", SqlDbType.NVarChar).Value = identityCard;
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private bool IsIdentityCardExistsForUpdate(SqlConnection conn, string identityCard, int currentCustomerId)
        {
            string sql = @"SELECT COUNT(*) FROM Customer WHERE identity_card = @IdentityCard AND customer_id <> @CustomerID";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.Add("@IdentityCard", SqlDbType.NVarChar).Value = identityCard;
                cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = currentCustomerId;

                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private void gvCustomerData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = gvCustomerData.Rows[e.RowIndex];

                selectedCustomerId = Convert.ToInt32(row.Cells["customer_id"].Value);

                txtFull_name.Text = row.Cells["full_name"].Value?.ToString();
                txtIdentity_card.Text = row.Cells["identity_card"].Value?.ToString();
                txtPhone_number.Text = row.Cells["phone_number"].Value?.ToString();
                txtEmail.Text = row.Cells["email"].Value?.ToString();
                txtNationality.Text = row.Cells["nationality"].Value?.ToString();
                txtAddress.Text = row.Cells["address"].Value?.ToString();

                dtpDOB.Value = row.Cells["date_of_birth"].Value == DBNull.Value
                    ? DateTime.Now
                    : Convert.ToDateTime(row.Cells["date_of_birth"].Value);

                btnUpdate.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;

            try
            {
                if (!ValidateDOB()) return;
                if (!ValidateIdentityCard()) return;

                using (SqlConnection conn = DAL.GetConnection())
                {
                    conn.Open();

                    if (IsIdentityCardExists(conn, txtIdentity_card.Text.Trim()))
                    {
                        MessageBox.Show("CCCD / Hộ chiếu đã tồn tại!",
                                        "Trùng dữ liệu",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        return;
                    }

                    string query = @"
                INSERT INTO Customer 
                (full_name, date_of_birth, email, phone_number, identity_card, nationality, address)
                VALUES 
                (@FullName, @DOB, @Email, @PhoneNumber, @IdentityCard, @Nationality, @Address)";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@FullName", txtFull_name.Text.Trim());
                    cmd.Parameters.AddWithValue("@DOB", dtpDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@PhoneNumber", txtPhone_number.Text.Trim());
                    cmd.Parameters.AddWithValue("@IdentityCard", txtIdentity_card.Text.Trim());
                    cmd.Parameters.AddWithValue("@Nationality", txtNationality.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());

                    cmd.ExecuteNonQuery();

                    MessageBox.Show($"Thêm customer thành công!");
                    LoadCustomer();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Add Customer: " + ex.Message);
            }
            finally
            {
                btnAdd.Enabled = true;
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == -1)
            {
                MessageBox.Show("Vui lòng chọn customer");
                return;
            }
            
            btnUpdate.Enabled = false;

            try
            {
                if (!ValidateDOB()) return;
                if (!ValidateIdentityCard()) return;

                using (SqlConnection conn = DAL.GetConnection())
                {
                    conn.Open();

                    if (IsIdentityCardExistsForUpdate(conn, txtIdentity_card.Text.Trim(), selectedCustomerId))
                    {
                        MessageBox.Show("CCCD / Hộ chiếu đã tồn tại!",
                                        "Trùng dữ liệu",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        return;
                    }

                    string query = @"
                        UPDATE Customer
                        SET full_name = @FullName,
                            date_of_birth = @DOB,
                            email = @Email,
                            phone_number = @PhoneNumber,
                            identity_card = @IdentityCard,
                            nationality = @Nationality,
                            address = @Address
                        WHERE customer_id = @CustomerID";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CustomerID", selectedCustomerId);
                    cmd.Parameters.AddWithValue("@FullName", txtFull_name.Text.Trim());
                    cmd.Parameters.AddWithValue("@DOB", dtpDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@PhoneNumber", txtPhone_number.Text.Trim());
                    cmd.Parameters.AddWithValue("@IdentityCard", txtIdentity_card.Text.Trim());
                    cmd.Parameters.AddWithValue("@Nationality", txtNationality.Text.Trim());
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text.Trim());

                    cmd.ExecuteNonQuery();

                    MessageBox.Show($"Cập nhật thành công!");
                    LoadCustomer();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi update: " + ex.Message);
            }
            finally
            {
                btnUpdate.Enabled = true;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
                string keyword = txtSearch.Text.Trim();
                LoadCustomer(keyword);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedCustomerId == -1)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xoá!");
                return;
            }
            
            btnDelete.Enabled = false;
            try
            {
                DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn xoá khách hàng này không?",
                "Xác nhận xoá",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );

                if (result != DialogResult.Yes)
                    return;

                using (SqlConnection conn = DAL.GetConnection())
                {
                    conn.Open();

                    string query = "DELETE FROM Customer WHERE customer_id = @CustomerId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CustomerId", selectedCustomerId);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Xoá khách hàng thành công!");

                    LoadCustomer(txtSearch.Text.Trim());

                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Delete Customer: " + ex.Message);
            }
            finally
            {
                btnDelete.Enabled = true;
            }
        }
        private void ClearForm()
        {
            selectedCustomerId = -1;

            txtFull_name.Clear();
            dtpDOB.Value = DateTime.Now;
            txtEmail.Clear();
            txtPhone_number.Clear();
            txtIdentity_card.Clear();
            txtNationality.Clear();
            txtAddress.Clear();

            btnUpdate.Enabled = false;
        }
    }
}