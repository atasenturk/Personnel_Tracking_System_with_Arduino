using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccesLayer.Abstract
{
    public interface IGirisYeriDal
    {
        void Add(GirisYerleri girisyeri);
        void Delete(int giris_id);
        GirisYerleri GetById(int giris_id);
        List<GirisYerleri> GetAll();
        void Update(GirisYerleri girisyeri);
    }
}