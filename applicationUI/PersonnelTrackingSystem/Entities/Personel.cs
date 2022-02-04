using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Personel
    {
        public int personel_id { get; set; }
        public string personel_isim { get; set; }
        public string personel_soyisim { get; set; }
        public int kart_id { get; set; }
        public int departman_id { get; set; }
    }
}
