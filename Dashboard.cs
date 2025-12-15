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

namespace ChuongTrinhQuanLyKhachSan
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private UC_Users ucUsers;
        private UC_Customer ucCustomer;

        private void AddUCToPanel(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            uc.Visible = false;
            panel2.Controls.Add(uc);
        }
        private void ShowUC(UserControl uc)
        {
            foreach (Control c in panel2.Controls)
                c.Visible = false;

            uc.Visible = true;
            uc.BringToFront();
        }
        private void Dashboard_Load(object sender, EventArgs e)
        {
            ucUsers = new UC_Users();
            ucCustomer = new UC_Customer();

            AddUCToPanel(ucUsers);
            AddUCToPanel(ucCustomer);

            ShowUC(ucUsers);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            ShowUC(ucUsers);
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {

        }

        private void btnRoom_Type_Click(object sender, EventArgs e)
        {

        }

        private void btnService_Click(object sender, EventArgs e)
        {

        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            ShowUC(ucCustomer);
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {

        }

        private void btnService_Use_Click(object sender, EventArgs e)
        {

        }

        private void btnBill_Click(object sender, EventArgs e)
        {

        }
    }
}
