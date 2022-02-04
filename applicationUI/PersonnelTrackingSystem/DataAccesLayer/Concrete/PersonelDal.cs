using DataAccesLayer.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class PersonelDal : IPersonelDal
    {
        private string _connectionString = "Data Source=SQL5086.site4now.net;Initial Catalog=db_a7eb1f_vtysproje; User Id = db_a7eb1f_vtysproje_admin; Password=admin2580";
        public Personel GetById(int kart_id)
        {
            Personel personel = new Personel();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("getPersonelByKartId", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@kart_id", kart_id);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        personel.personel_id = Convert.ToInt32(reader["personel_id"]);
                        personel.personel_isim = reader["personel_isim"].ToString();
                        personel.personel_soyisim = reader["personel_soyisim"].ToString();
                        personel.kart_id = Convert.ToInt32(reader["kart_id"]);
                        personel.departman_id = Convert.ToInt32(reader["departman_id"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return personel;
        }

        public Personel GetByName(string name)
        {
            Personel personel = new Personel();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM Personeller WHERE personel_isim = @name", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", name);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        personel.personel_id = Convert.ToInt32(reader["personel_id"]);
                        personel.personel_isim = reader["personel_isim"].ToString();
                        personel.personel_soyisim = reader["personel_soyisim"].ToString();
                        personel.kart_id = Convert.ToInt32(reader["kart_id"]);
                        personel.departman_id = Convert.ToInt32(reader["departman_id"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return personel;
        }

        public List<Personel> GetAll()
        {
            List<Personel> personeller = new List<Personel>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("getAllPersonel", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Personel personel = new Personel
                        {
                            personel_id = Convert.ToInt32(reader["personel_id"]),
                            personel_isim = reader["personel_isim"].ToString(),
                            personel_soyisim = reader["personel_soyisim"].ToString(),
                            kart_id = Convert.ToInt32(reader["kart_id"]),
                            departman_id = Convert.ToInt32(reader["departman_id"])
                        };
                        personeller.Add(personel);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return personeller;
        }
    }
}
