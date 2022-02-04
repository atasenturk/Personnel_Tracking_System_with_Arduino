using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IKartDal
    {
        void Add(Kart kart);
        void Delete(string kart_no);
        Kart GetById(int kart_id);
        List<Kart> GetAll();
    }
}
