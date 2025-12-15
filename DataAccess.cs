using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ChuongTrinhQuanLyKhachSan
{
    public class DAL
    {
        // THAY THẾ CHUỖI KẾT NỐI NÀY VỚI TÊN SERVER CỦA BẠN
        private static string connectionString = "Data Source=LAPTOP-TAA8H0JQ\\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True;TrustServerCertificate=True";

        // Phương thức Tĩnh (static) để lấy đối tượng SqlConnection
        public static SqlConnection GetConnection()
        {
            // Trả về một đối tượng kết nối mới
            return new SqlConnection(connectionString);
        }

        // Phương thức kiểm tra kết nối (Test Connection)
        public static bool TestConnection()
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    // Thử mở kết nối
                    conn.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    // Có lỗi xảy ra, có thể in lỗi ra cửa sổ Output để debug
                    Console.WriteLine("Lỗi kết nối CSDL: " + ex.Message);
                    return false;
                }
            }
        }
    }
    internal class DataAccess
    {
    }
}
