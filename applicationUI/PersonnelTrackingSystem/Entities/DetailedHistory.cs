using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class DetailedHistory
    {
        public int personel_id { get; set; }
        public string aksiyon_tarih_saat { get; set; }
        public string personel_isim { get; set; }
        public string personel_soyisim { get; set; }
        public string kart_no { get; set; }
        public bool giris_mi { get; set; }
    }
}
