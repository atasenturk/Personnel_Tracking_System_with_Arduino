using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonnelTrackingSystem
{
    public partial class PersonnelUI : UserControl
    {
        public PersonnelUI()
        {
            InitializeComponent();
        }

        public void setLabelID(string ID)
        {
            lblID.Text = ID;
        }

        public void setLabelName(string name)
        {
            lblName.Text = name;
        }

        public void setLabelDate(string date)
        {
            lblDate.Text = date;
        }

        public void setLabelCardID(string ID)
        {
            lblCardID.Text = ID;
        }

        public void setLabelAction(bool val)
        {
            if (val == false)
            {
                lblAction.Text = "Çıkış";
            }
            else lblAction.Text = "Giriş";
        }

    }

    
}
