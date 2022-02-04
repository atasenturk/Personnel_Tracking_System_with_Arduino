using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccesLayer.Abstract;
using Entities;

namespace DataAccesLayer.Concrete
{
    public class AksiyonDal : IAksiyonDal
    {
        private string _connectionString = "Data Source=SQL5086.site4now.net;Initial Catalog=db_a7eb1f_vtysproje; User Id = db_a7eb1f_vtysproje_admin; Password=admin2580";

        public void Add(string card_no, string date)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("addAction", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@card_no", card_no);
                    command.Parameters.AddWithValue("@datetime", date);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public Aksiyon GetByDate(DateTime aksiyon_tarih_saat)
        {
            Aksiyon aksiyon = new Aksiyon();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("getAksiyonByDate", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@aksiyon_tarih_saat", aksiyon_tarih_saat);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        aksiyon.aksiyon_id = Convert.ToInt32(reader["aksiyon_id"]);
                        aksiyon.personel_id = Convert.ToInt32(reader["personel_id"]);
                        aksiyon.giris_id = Convert.ToInt32(reader["giris_id"]);
                        aksiyon.aksiyon_tarih_saat = reader["aksiyon_tarih_saat"].ToString();
                        aksiyon.giris_mi = (bool)reader["giris_mi"];
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return aksiyon;
        }

        public List<Aksiyon> GetAll()
        {
            List<Aksiyon> aksiyonlar = new List<Aksiyon>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("getAllAksiyon", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Aksiyon aksiyon = new Aksiyon
                        {
                            aksiyon_id = Convert.ToInt32(reader["aksiyon_id"]),
                            personel_id = Convert.ToInt32(reader["personel_id"]),
                            giris_id = Convert.ToInt32(reader["giris_id"]),
                            aksiyon_tarih_saat = reader["aksiyon_tarih_saat"].ToString(),
                            giris_mi = (bool)reader["giris_mi"]
                        };
                        aksiyonlar.Add(aksiyon);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return aksiyonlar;
        }



        public List<Monitor> GetMonitor()
        {
            List<Monitor> monitorInfos = new List<Monitor>();


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {

                    connection.Open();
                    SqlCommand command = new SqlCommand("getMonitor", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Monitor monitorInfo = new Monitor
                        {
                            aksiyon_id = Convert.ToInt32(reader["aksiyon_id"]),
                            aksiyon_tarih_saat = reader["aksiyon_tarih_saat"].ToString(),
                            personel_isim = reader["personel_isim"].ToString(),
                            personel_soyisim = reader["personel_soyisim"].ToString(),
                            giris_isim = reader["giris_isim"].ToString(),
                        };
                        monitorInfos.Add(monitorInfo);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return monitorInfos;
        }


        public DetailedHistory GetDetailedHistory(int aksiyonId)
        {
            DetailedHistory detailedHistory = new DetailedHistory();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("getDetailedHistory", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@aks_id", aksiyonId);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        detailedHistory.personel_id = Convert.ToInt32(reader["personel_id"]);
                        detailedHistory.aksiyon_tarih_saat = reader["aksiyon_tarih_saat"].ToString();
                        detailedHistory.personel_isim = reader["personel_isim"].ToString();
                        detailedHistory.personel_soyisim = reader["personel_soyisim"].ToString();
                        detailedHistory.kart_no = reader["kart_no"].ToString();
                        detailedHistory.giris_mi = Convert.ToBoolean(reader["giris_mi"]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return detailedHistory;
        }

    }
}
