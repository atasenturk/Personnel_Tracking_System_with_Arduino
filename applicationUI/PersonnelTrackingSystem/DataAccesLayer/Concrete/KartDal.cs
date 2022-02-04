using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;
using DataAccessLayer.Abstract;
using Entities;

namespace DataAccesLayer.Concrete
{
    public class KartDal : IKartDal
    {
        private string _connectionString = "Data Source=SQL5086.site4now.net;Initial Catalog=db_a7eb1f_vtysproje; User Id = db_a7eb1f_vtysproje_admin; Password=admin2580";
        public void Add(Kart kart)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("addKart", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@kart_id", kart.kart_id);
                    command.Parameters.AddWithValue("@kart_no", kart.kart_no);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void Delete(string kart_no)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("deleteKart", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@kart_no", kart_no);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public Kart GetById(int kart_id)
        {
            Kart kart = new Kart();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("getKartID ", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@kart_id", kart_id);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        kart.kart_id = Convert.ToInt32(reader["kart_id"]);
                        kart.kart_no = reader["kart_no"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return kart;
        }

        public List<Kart> GetAll()
        {
            List<Kart> karts = new List<Kart>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("getAllKart", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Kart kart = new Kart
                        {
                            kart_id = Convert.ToInt32(reader["kart_id"]),
                            kart_no = reader["kart_no"].ToString()
                        };
                        karts.Add(kart);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return karts;
        }

    }
}
