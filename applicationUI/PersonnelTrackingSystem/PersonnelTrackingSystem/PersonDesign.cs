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
    public partial class PersonDesign : UserControl
    {
        public PersonDesign()
        {
            InitializeComponent();
        }

        public void setLabelName(string name)
        {
            lblName.Text = name;
        }

        public void setLabelSurname(string surname)
        {
            lblSurname.Text = surname;
        }

        public void setDepartman(string dep)
        {
            lblDepartman.Text = dep;
        }

        public void setLabelCardNo(string card_no)
        {
            lblCardNo.Text = card_no;
        }

        public void setLabelPersonelID(string ID)
        {
            lblPersonelID.Text = ID;
        }
    }
}
