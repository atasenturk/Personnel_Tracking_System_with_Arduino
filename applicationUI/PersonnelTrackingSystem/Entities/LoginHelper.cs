using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class LoginHelper
    {

        private static Admin instance = null;
        public LoginHelper(Admin admin)
        {
            instance = admin;
        }
        public static Admin Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Admin();
                }
                return instance;
            }
        }
    }
}
