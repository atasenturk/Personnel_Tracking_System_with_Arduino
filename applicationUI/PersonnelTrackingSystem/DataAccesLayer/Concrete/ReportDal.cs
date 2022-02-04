using DataAccesLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient;
using System.Data;

namespace DataAccesLayer.Concrete
{
    public class ReportDal:IReportDal
    {
        private string _connectionString = "Data Source=SQL5086.site4now.net;Initial Catalog=db_a7eb1f_vtysproje; User Id = db_a7eb1f_vtysproje_admin; Password=admin2580";
        public List<Reports> GetReports()
        {
            List<Reports> raporlar = new List<Reports>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("getReports", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Reports report = new Reports
                        {
                            personel_isim = reader["personel_isim"].ToString(),
                            personel_soyisim = reader["personel_soyisim"].ToString(),
                            aksiyon_sayisi = Convert.ToInt32(reader["aksiyon_sayisi"]),
                        };
                        raporlar.Add(report);
                    }
                    reader.Close();
                    return raporlar;
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return raporlar;
        }
    }
}
