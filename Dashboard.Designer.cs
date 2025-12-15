namespace ChuongTrinhQuanLyKhachSan
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.btnExit = new Guna.UI2.WinForms.Guna2Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnBill = new Guna.UI2.WinForms.Guna2Button();
            this.btnService_Use = new Guna.UI2.WinForms.Guna2Button();
            this.btnBooking = new Guna.UI2.WinForms.Guna2Button();
            this.btnCustomer = new Guna.UI2.WinForms.Guna2Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnService = new Guna.UI2.WinForms.Guna2Button();
            this.btnRoom_Type = new Guna.UI2.WinForms.Guna2Button();
            this.btnRoom = new Guna.UI2.WinForms.Guna2Button();
            this.btnUser = new Guna.UI2.WinForms.Guna2Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.uC_Users1 = new ChuongTrinhQuanLyKhachSan.UC_Users();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExit.FillColor = System.Drawing.Color.NavajoWhite;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageSize = new System.Drawing.Size(50, 50);
            this.btnExit.Location = new System.Drawing.Point(-1, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(62, 45);
            this.btnExit.TabIndex = 0;
            this.btnExit.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btnBill);
            this.panel3.Controls.Add(this.btnService_Use);
            this.panel3.Controls.Add(this.btnBooking);
            this.panel3.Controls.Add(this.btnCustomer);
            this.panel3.Location = new System.Drawing.Point(1780, 160);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(240, 753);
            this.panel3.TabIndex = 1;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // btnBill
            // 
            this.btnBill.BorderRadius = 20;
            this.btnBill.BorderThickness = 2;
            this.btnBill.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnBill.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBill.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBill.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBill.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBill.FillColor = System.Drawing.Color.Chocolate;
            this.btnBill.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBill.ForeColor = System.Drawing.Color.White;
            this.btnBill.Location = new System.Drawing.Point(6, 595);
            this.btnBill.Name = "btnBill";
            this.btnBill.Size = new System.Drawing.Size(225, 121);
            this.btnBill.TabIndex = 4;
            this.btnBill.Text = "HÓA ĐƠN";
            this.btnBill.Click += new System.EventHandler(this.btnBill_Click);
            // 
            // btnService_Use
            // 
            this.btnService_Use.BorderRadius = 20;
            this.btnService_Use.BorderThickness = 2;
            this.btnService_Use.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnService_Use.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnService_Use.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnService_Use.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnService_Use.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnService_Use.FillColor = System.Drawing.Color.Chocolate;
            this.btnService_Use.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnService_Use.ForeColor = System.Drawing.Color.White;
            this.btnService_Use.Location = new System.Drawing.Point(6, 411);
            this.btnService_Use.Name = "btnService_Use";
            this.btnService_Use.Size = new System.Drawing.Size(225, 121);
            this.btnService_Use.TabIndex = 3;
            this.btnService_Use.Text = "DỊCH VỤ ĐÃ DÙNG";
            this.btnService_Use.Click += new System.EventHandler(this.btnService_Use_Click);
            // 
            // btnBooking
            // 
            this.btnBooking.BorderRadius = 20;
            this.btnBooking.BorderThickness = 2;
            this.btnBooking.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnBooking.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnBooking.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnBooking.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnBooking.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnBooking.FillColor = System.Drawing.Color.Chocolate;
            this.btnBooking.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBooking.ForeColor = System.Drawing.Color.White;
            this.btnBooking.Location = new System.Drawing.Point(6, 224);
            this.btnBooking.Name = "btnBooking";
            this.btnBooking.Size = new System.Drawing.Size(225, 121);
            this.btnBooking.TabIndex = 2;
            this.btnBooking.Text = "ĐẶT PHÒNG";
            this.btnBooking.Click += new System.EventHandler(this.btnBooking_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.BorderRadius = 20;
            this.btnCustomer.BorderThickness = 2;
            this.btnCustomer.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnCustomer.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCustomer.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCustomer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCustomer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCustomer.FillColor = System.Drawing.Color.Chocolate;
            this.btnCustomer.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomer.ForeColor = System.Drawing.Color.White;
            this.btnCustomer.Location = new System.Drawing.Point(6, 35);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(225, 121);
            this.btnCustomer.TabIndex = 1;
            this.btnCustomer.Text = "KHÁCH HÀNG";
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.btnService);
            this.panel1.Controls.Add(this.btnRoom_Type);
            this.panel1.Controls.Add(this.btnRoom);
            this.panel1.Controls.Add(this.btnUser);
            this.panel1.Location = new System.Drawing.Point(50, 160);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 753);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnService
            // 
            this.btnService.BorderRadius = 20;
            this.btnService.BorderThickness = 2;
            this.btnService.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnService.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnService.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnService.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnService.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnService.FillColor = System.Drawing.Color.Chocolate;
            this.btnService.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnService.ForeColor = System.Drawing.Color.White;
            this.btnService.Location = new System.Drawing.Point(5, 595);
            this.btnService.Name = "btnService";
            this.btnService.Size = new System.Drawing.Size(225, 121);
            this.btnService.TabIndex = 3;
            this.btnService.Text = "DANH SÁCH DỊCH VỤ";
            this.btnService.Click += new System.EventHandler(this.btnService_Click);
            // 
            // btnRoom_Type
            // 
            this.btnRoom_Type.BorderRadius = 20;
            this.btnRoom_Type.BorderThickness = 2;
            this.btnRoom_Type.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnRoom_Type.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRoom_Type.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRoom_Type.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRoom_Type.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRoom_Type.FillColor = System.Drawing.Color.Chocolate;
            this.btnRoom_Type.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoom_Type.ForeColor = System.Drawing.Color.White;
            this.btnRoom_Type.Location = new System.Drawing.Point(5, 411);
            this.btnRoom_Type.Name = "btnRoom_Type";
            this.btnRoom_Type.Size = new System.Drawing.Size(225, 121);
            this.btnRoom_Type.TabIndex = 2;
            this.btnRoom_Type.Text = "LOẠI PHÒNG";
            this.btnRoom_Type.Click += new System.EventHandler(this.btnRoom_Type_Click);
            // 
            // btnRoom
            // 
            this.btnRoom.BorderRadius = 20;
            this.btnRoom.BorderThickness = 2;
            this.btnRoom.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnRoom.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRoom.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRoom.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRoom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRoom.FillColor = System.Drawing.Color.Chocolate;
            this.btnRoom.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoom.ForeColor = System.Drawing.Color.White;
            this.btnRoom.Location = new System.Drawing.Point(5, 224);
            this.btnRoom.Name = "btnRoom";
            this.btnRoom.Size = new System.Drawing.Size(225, 121);
            this.btnRoom.TabIndex = 1;
            this.btnRoom.Text = "PHÒNG";
            this.btnRoom.Click += new System.EventHandler(this.btnRoom_Click);
            // 
            // btnUser
            // 
            this.btnUser.BorderRadius = 20;
            this.btnUser.BorderThickness = 2;
            this.btnUser.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.btnUser.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUser.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUser.FillColor = System.Drawing.Color.Chocolate;
            this.btnUser.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUser.ForeColor = System.Drawing.Color.White;
            this.btnUser.Location = new System.Drawing.Point(5, 35);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(225, 121);
            this.btnUser.TabIndex = 0;
            this.btnUser.Text = "NGƯỜI DÙNG HỆ THỐNG";
            this.btnUser.Click += new System.EventHandler(this.btnUser_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.uC_Users1);
            this.panel2.Location = new System.Drawing.Point(353, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1366, 964);
            this.panel2.TabIndex = 4;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // uC_Users1
            // 
            this.uC_Users1.BackColor = System.Drawing.Color.NavajoWhite;
            this.uC_Users1.Location = new System.Drawing.Point(-2, -2);
            this.uC_Users1.Name = "uC_Users1";
            this.uC_Users1.Size = new System.Drawing.Size(1366, 964);
            this.uC_Users1.TabIndex = 0;
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.TargetControl = this;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.NavajoWhite;
            this.ClientSize = new System.Drawing.Size(1942, 1102);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnExit;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2Button btnUser;
        private Guna.UI2.WinForms.Guna2Button btnRoom;
        private Guna.UI2.WinForms.Guna2Button btnCustomer;
        private Guna.UI2.WinForms.Guna2Button btnService;
        private Guna.UI2.WinForms.Guna2Button btnRoom_Type;
        private Guna.UI2.WinForms.Guna2Button btnBill;
        private Guna.UI2.WinForms.Guna2Button btnService_Use;
        private Guna.UI2.WinForms.Guna2Button btnBooking;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private UC_Users uC_Users1;
    }
}