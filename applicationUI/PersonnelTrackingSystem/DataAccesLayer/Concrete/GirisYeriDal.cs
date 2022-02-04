using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;
using DataAccesLayer.Abstract;

namespace DataAccesLayer.Concrete
{
    public class GirisYeriDal : IGirisYeriDal
    {
        private string _connectionString = "Data Source=SQL5086.site4now.net;Initial Catalog=db_a7eb1f_vtysproje; User Id = db_a7eb1f_vtysproje_admin; Password=admin2580";
        public void Add(GirisYerleri girisyeri)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("addGirisYeri", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@giris_id", girisyeri.giris_id);
                    command.Parameters.AddWithValue("@giris_isim", girisyeri.giris_isim);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Delete(int giris_id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("deletedGirisYeri", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@giris_id", giris_id);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public GirisYerleri GetById(int giris_id)
        {
            GirisYerleri girisyeri = new GirisYerleri();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("getGirisYeriById", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@giris_id", giris_id);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        girisyeri.giris_id = Convert.ToInt32(reader["giris_id"]);
                        girisyeri.giris_isim = reader["giris_isim"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return girisyeri;
        }

        public List<GirisYerleri> GetAll()
        {
            List<GirisYerleri> girisyerleri = new List<GirisYerleri>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("getAllGirisYerleri", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        GirisYerleri girisyeri = new GirisYerleri
                        {
                            giris_id = Convert.ToInt32(reader["giris_id"]),
                            giris_isim = reader["giris_isim"].ToString()
                        };
                        girisyerleri.Add(girisyeri);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return girisyerleri;
        }

        public void Update(GirisYerleri girisyeri)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("updateGirisYeri", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@giris_id", girisyeri.giris_id);
                    command.Parameters.AddWithValue("@giris_isim", girisyeri.giris_isim);
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
