using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using Entities;
using PersonnelTrackingSystem;

namespace LoginForm
{
    public partial class Login : Form
    {
        public static LoginHelper _loginHelper;
        public Login()
        {
            InitializeComponent();
            txtEmail.GotFocus += RemoveText;
            txtEmail.LostFocus += AddText;
            txtPassword.GotFocus += RemoveText;
            txtPassword.LostFocus += AddText;
        }

        public void RemoveText(object sender, EventArgs e)
        {
            if((sender as TextBox).Text=="Email")
            {
                txtEmail.ForeColor = Color.Black;
                txtEmail.Text = "";
            }
            if ((sender as TextBox).Text == "Password")
            {
                txtPassword.UseSystemPasswordChar = true;
                txtPassword.ForeColor = Color.Black;
                txtPassword.Text = "";
            }
        }
        public void AddText(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                txtEmail.Text = "Email";
                txtEmail.ForeColor = SystemColors.Control;

            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                txtPassword.UseSystemPasswordChar = false;

                txtPassword.Text = "Password";
                txtPassword.ForeColor = SystemColors.Control;
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        Point lastPoint;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - lastPoint.X;
                Top += e.Y - lastPoint.Y;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            IAdminDal _adminDal = new AdminDal();
            Admin admin= _adminDal.GetByEmail(txtEmail.Text);
            if (admin==null)
            {
                MessageBox.Show("E-posta veya şifre yanlış!");
            }
            else
            {
                _loginHelper = new LoginHelper(admin);
                Form1 mainform = new Form1();
                this.Hide();
                mainform.Show();
            }

        }

    }
}
