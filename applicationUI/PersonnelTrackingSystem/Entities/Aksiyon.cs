using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Aksiyon
    {
        public int aksiyon_id { get; set; }
        public int personel_id { get; set; }
        public int giris_id { get; set; }
        public string aksiyon_tarih_saat { get; set; }
        public bool giris_mi { get; set; }
    }
}
