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
    public interface IGetDetailedHistory
    {
        DetailedHistory GetDetailedHistory(int aksiyonId);

    }
}
