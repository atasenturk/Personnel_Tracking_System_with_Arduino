using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using DataAccesLayer.Abstract;
using System.Data.SqlClient;
using System.Data;

namespace DataAccesLayer.Concrete
{
    public class AdminDal : IAdminDal
    {
        private string _connectionString = "Data Source=SQL5086.site4now.net;Initial Catalog=db_a7eb1f_vtysproje; User Id = db_a7eb1f_vtysproje_admin; Password=admin2580";
        public Admin GetByEmail(string admin_mail)
        {
            Admin admin = new Admin();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("getAdminByEmail", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@admin_mail", admin_mail);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        admin.admin_id = Convert.ToInt32(reader["admin_id"]);
                        admin.admin_mail = reader["admin_mail"].ToString();
                        admin.admin_sifre = reader["admin_sifre"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            if (admin.admin_mail == null)
            {
                return null;
            }
            else return admin;
        }

        public List<Admin> GetAll()
        {
            List<Admin> admins = new List<Admin>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("getAllAdmin", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Admin admin = new Admin
                        {
                            admin_id = Convert.ToInt32(reader["admin_id"]),
                            admin_mail = reader["admin_mail"].ToString(),
                            admin_sifre = reader["admin_sifre"].ToString(),
                        };
                        admins.Add(admin);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return admins;
        }
        public void Add(Admin admin)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("addAdmin", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@admin_id", admin.admin_id);
                    command.Parameters.AddWithValue("@admin_mail", admin.admin_mail);
                    command.Parameters.AddWithValue("@admin_sifre", admin.admin_sifre);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Delete(int admin_id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("deleteAdmin", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@admin_id", admin_id);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void setPassword(string mail, string pass)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("setAdminPassword", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@admin_mail", mail);
                    command.Parameters.AddWithValue("@admin_sifre", pass);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
