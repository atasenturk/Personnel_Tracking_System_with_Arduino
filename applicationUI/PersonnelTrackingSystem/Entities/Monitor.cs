using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Monitor
    {
        public int aksiyon_id { get; set; }
        public string aksiyon_tarih_saat { get; set; }
        public string personel_isim { get; set; }
        public string personel_soyisim { get; set; }
        public string giris_isim { get; set; }
    }
}
