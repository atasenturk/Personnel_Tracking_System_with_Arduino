using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesLayer.Abstract
{
    public interface IPersonelDal
    {
        Personel GetById(int kart_id);
        Personel GetByName(string name);
        List<Personel> GetAll();
    }
}
