using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DataAccesLayer.Abstract
{
    public interface IAdminDal
    {
        Admin GetByEmail(string email);
        List<Admin> GetAll();
        void Add(Admin admin);
        void Delete(int admin_id);
        void setPassword(string mail, string pass);
    }
}
