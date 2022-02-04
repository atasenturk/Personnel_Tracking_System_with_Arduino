using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data;
using System.Data.SqlClient;

namespace DataAccesLayer.Abstract
{
    public interface IAksiyonDal
    {
        void Add(string card_no, string date);
        Aksiyon GetByDate(DateTime aksiyon_tarih_saat);
        List<Aksiyon> GetAll();
        List<Monitor> GetMonitor();
        DetailedHistory GetDetailedHistory(int aksiyonId);
    }
}
