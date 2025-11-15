using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace Bai05.Shared
{
    /// <summary>
    /// Helper class để quản lý Database SQLite
    /// </summary>
    public static class DatabaseHelper
    {
        /// <summary>
        /// Khởi tạo database với 2 bảng: NguoiDung và MonAn
        /// </summary>
        public static void InitializeDatabase(string dbPath)
        {
            try
            {
                // Tạo file database nếu chưa có
                if (!File.Exists(dbPath))
                {
                    SQLiteConnection.CreateFile(dbPath);
                }

                string connString = $"Data Source={dbPath};Version=3;";
                using (var conn = new SQLiteConnection(connString))
                {
                    conn.Open();

                    // Tạo bảng NguoiDung
                    string sqlNguoiDung = @"
                        CREATE TABLE IF NOT EXISTS NguoiDung (
                            IDNCC INTEGER PRIMARY KEY AUTOINCREMENT,
                            HoVaTen TEXT NOT NULL UNIQUE,
                            QuyenHan TEXT
                        );";

                    // Tạo bảng MonAn
                    string sqlMonAn = @"
                        CREATE TABLE IF NOT EXISTS MonAn (
                            IDMA INTEGER PRIMARY KEY AUTOINCREMENT,
                            TenMon TEXT NOT NULL,
                            HinhAnh TEXT,
                            IDNCC INTEGER,
                            FOREIGN KEY (IDNCC) REFERENCES NguoiDung(IDNCC)
                        );";

                    using (var cmd = new SQLiteCommand(sqlNguoiDung, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    using (var cmd = new SQLiteCommand(sqlMonAn, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khởi tạo database: {ex.Message}");
            }
        }

        /// <summary>
        /// Thêm hoặc lấy ID người dùng
        /// </summary>
        public static int AddOrGetUser(string dbPath, string hoVaTen, string quyenHan)
        {
            string connString = $"Data Source={dbPath};Version=3;";
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();

                // Kiểm tra xem người dùng đã tồn tại
                string checkSql = "SELECT IDNCC FROM NguoiDung WHERE HoVaTen = @name";
                using (var cmd = new SQLiteCommand(checkSql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", hoVaTen);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                }

                // Nếu chưa có, thêm mới
                string insertSql = "INSERT INTO NguoiDung (HoVaTen, QuyenHan) VALUES (@name, @perm); SELECT last_insert_rowid();";
                using (var cmd = new SQLiteCommand(insertSql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", hoVaTen);
                    cmd.Parameters.AddWithValue("@perm", quyenHan);
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        /// <summary>
        /// Thêm món ăn vào database
        /// </summary>
        public static void AddFood(string dbPath, string tenMon, string hinhAnh, int idNcc)
        {
            string connString = $"Data Source={dbPath};Version=3;";
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();

                string sql = "INSERT INTO MonAn (TenMon, HinhAnh, IDNCC) VALUES (@ten, @hinh, @id)";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@ten", tenMon);
                    cmd.Parameters.AddWithValue("@hinh", hinhAnh);
                    cmd.Parameters.AddWithValue("@id", idNcc);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lấy tất cả món ăn từ database
        /// </summary>
        public static List<(string ten, string nguoi, string quyen, string hinh)> GetAllFoods(string dbPath)
        {
            var result = new List<(string, string, string, string)>();
            string connString = $"Data Source={dbPath};Version=3;";

            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();

                string sql = @"
                    SELECT m.TenMon, n.HoVaTen, n.QuyenHan, m.HinhAnh
                    FROM MonAn m
                    LEFT JOIN NguoiDung n ON m.IDNCC = n.IDNCC
                    ORDER BY m.IDMA";

                using (var cmd = new SQLiteCommand(sql, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string ten = reader[0]?.ToString() ?? "";
                        string nguoi = reader[1]?.ToString() ?? "N/A";
                        string quyen = reader[2]?.ToString() ?? "N/A";
                        string hinh = reader[3]?.ToString() ?? "";

                        result.Add((ten, nguoi, quyen, hinh));
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Xóa món ăn theo ID
        /// </summary>
        public static void DeleteFood(string dbPath, int idma)
        {
            string connString = $"Data Source={dbPath};Version=3;";
            using (var conn = new SQLiteConnection(connString))
            {
                conn.Open();

                string sql = "DELETE FROM MonAn WHERE IDMA = @id";
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idma);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}