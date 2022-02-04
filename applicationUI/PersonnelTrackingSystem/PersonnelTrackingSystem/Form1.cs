using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using System.Data.SqlClient;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using System.IO;
using DataAccess.Concrete;

namespace PersonnelTrackingSystem
{
    public partial class Form1 : Form
    {
        private Button btnMonitor;
        private Button btnReports;
        private Button btnAccessPoints;
        private Button btnPersonnelList;
        private Button btnPersonnelSearch;
        private PersonnelUI actionDetail = new PersonnelUI();
        private Button currentButton;
        private Panel dashBoardPanel;
        private Panel personnelPanel;
        private DateTimePicker dtpUpper;
        private DateTimePicker dtpLower;
        private TextBox txtName;
        private TextBox txtSearchById;
        private TextBox txtSearchByName;
        private TextBox txtPass;
        private TextBox txtPassConfirm;
        private List<Monitor> monitorInfos;
        private DataGridView dtg;
        private Admin currentAdmin;
        int PW;
        bool Hided;
        string _connectionString = "Data Source=SQL5086.site4now.net;Initial Catalog=db_a7eb1f_vtysproje;User Id=db_a7eb1f_vtysproje_admin;Password=admin2580";


        public Form1()
        {
            InitializeComponent();
            LoadMainPanel();
            PW = 161;
            Hided = true;
            currentAdmin  = LoginHelper.Instance;
            lblEmail.Text = currentAdmin.admin_mail;
        }

        private void slideTimer_Tick_1(object sender, EventArgs e)
        {
            if (Hided)
            {
                pnlLeft.Width = pnlLeft.Width+5;
                if (pnlLeft.Width >= PW)
                {
                    slideTimer.Stop();
                    Hided = false;
                    this.Refresh();
                }
            }
            else
            {
                pnlLeft.Width = pnlLeft.Width-5;
                if (pnlLeft.Width <= 16)
                {
                    slideTimer.Stop();
                    Hided = true;
                    this.Refresh();
                }
            }
        }


        private void btnDashboard_Click(object sender, EventArgs e)
        {
            if (Hided)
            {
                slideTimer.Start();
            }

            pnlLeft.Controls.Clear();
            pnlMain.Controls.Clear();
            ActiveButton(sender);
            createAllButtons();
            pnlLeft.Controls.Add(btnAccessPoints);
            pnlLeft.Controls.Add(btnReports);
            pnlLeft.Controls.Add(btnMonitor);


            try
            {
                string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "personnel-management-system-5.png");
                PictureBox pb = new PictureBox();
                pb.Image = Image.FromFile(path);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pnlMain.Controls.Add(pb);
                pb.Dock = DockStyle.Fill;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }


        private void btnPersonnels_Click(object sender, EventArgs e)
        {
            if (Hided)
            {
                slideTimer.Start();
            }

            pnlLeft.Controls.Clear();
            pnlMain.Controls.Clear();
            ActiveButton(sender);
            createAllButtons();
            pnlLeft.Controls.Add(btnPersonnelList);
            pnlLeft.Controls.Add(btnPersonnelSearch);

            try
            {
                string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "personnel-management-system-5.png");
                PictureBox pb = new PictureBox();
                pb.Image = Image.FromFile(path);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pnlMain.Controls.Add(pb);
                pb.Dock = DockStyle.Fill;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSupport_Click(object sender, EventArgs e)
        {
            if (Hided)
            {
                slideTimer.Start();
            }
            pnlLeft.Controls.Clear();
            pnlMain.Controls.Clear();
            ActiveButton(sender);



            Label text2 = new Label();
            text2.Location = new Point(51, 71);
            text2.AutoSize = true;
            text2.Text = "Sorumlu Kişi : Cemal Çağrı Çörez";
            text2.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular);
            text2.BackColor = Color.Transparent;

            Label text = new Label();
            text.Location = new Point(51, 111);
            text.AutoSize = true;
            text.Text = "Mail Adresi : cemalcorez@gmail.com";
            text.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular);
            text.BackColor = Color.Transparent;


            Label text1 = new Label();
            text1.Location = new Point(51, 151);
            text1.AutoSize = true;
            text1.Text = "Site : https://theixion.com/";
            text1.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular);
            text1.BackColor = Color.Transparent;


            pnlMain.Controls.Add(text);
            pnlMain.Controls.Add(text1);
            pnlMain.Controls.Add(text2);

            try
            {
                string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "personnel-management-system-5.png");
                PictureBox pb = new PictureBox();
                pb.Image = Image.FromFile(path);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pnlMain.Controls.Add(pb);
                pb.Dock = DockStyle.Fill;
                text.Parent = pb;
                text1.Parent = pb;
                text2.Parent = pb;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void createAllButtons()
        {
            btnMonitor = new Button();
            btnMonitor.Dock = DockStyle.Top;
            btnMonitor.FlatAppearance.BorderColor = Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(120)))), ((int)(((byte)(163)))));
            btnMonitor.FlatStyle = FlatStyle.Flat;
            btnMonitor.FlatAppearance.BorderSize = 0;
            btnMonitor.Font = new Font("Gill Sans MT", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            btnMonitor.ForeColor = Color.White;
            btnMonitor.Name = "btnMonitor";
            btnMonitor.Size = new System.Drawing.Size(161, 59);
            btnMonitor.Text = "Monitor";
            btnMonitor.Click += Click_Dashboard_Butt;

            btnReports = new Button();
            btnReports.Dock = DockStyle.Top;
            btnReports.FlatAppearance.BorderColor = Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(120)))), ((int)(((byte)(163)))));
            btnReports.FlatStyle = FlatStyle.Flat;
            btnReports.FlatAppearance.BorderSize = 0;
            btnReports.Font = new Font("Gill Sans MT", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            btnReports.ForeColor = Color.White;
            btnReports.Name = "btnReports";
            btnReports.Size = new System.Drawing.Size(161, 59);
            btnReports.Text = "Reports";
            btnReports.Click += Click_Dashboard_Butt;

            btnAccessPoints = new Button();
            btnAccessPoints.Dock = DockStyle.Top;
            btnAccessPoints.FlatAppearance.BorderColor = Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(120)))), ((int)(((byte)(163)))));
            btnAccessPoints.FlatStyle = FlatStyle.Flat;
            btnAccessPoints.FlatAppearance.BorderSize = 0;
            btnAccessPoints.Font = new Font("Gill Sans MT", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            btnAccessPoints.ForeColor = Color.White;
            btnAccessPoints.Name = "btnAccessPoints";
            btnAccessPoints.Size = new System.Drawing.Size(161, 59);
            btnAccessPoints.Text = "AccessPoints";
            btnAccessPoints.Click += Click_Dashboard_Butt;

            btnPersonnelList = new Button();
            btnPersonnelList.Dock = DockStyle.Top;
            btnPersonnelList.FlatAppearance.BorderColor = Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(120)))), ((int)(((byte)(163)))));
            btnPersonnelList.FlatStyle = FlatStyle.Flat;
            btnPersonnelList.FlatAppearance.BorderSize = 0;
            btnPersonnelList.Font = new Font("Gill Sans MT", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            btnPersonnelList.ForeColor = Color.White;
            btnPersonnelList.Name = "btnPersonnelList";
            btnPersonnelList.Size = new System.Drawing.Size(161, 59);
            btnPersonnelList.Text = "Personnel List";
            btnPersonnelList.Click += Click_Personnel_Butt;

            btnPersonnelSearch = new Button();
            btnPersonnelSearch.Dock = DockStyle.Top;
            btnPersonnelSearch.FlatAppearance.BorderColor = Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(120)))), ((int)(((byte)(163)))));
            btnPersonnelSearch.FlatStyle = FlatStyle.Flat;
            btnPersonnelSearch.FlatAppearance.BorderSize = 0;
            btnPersonnelSearch.Font = new Font("Gill Sans MT", 14.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            btnPersonnelSearch.ForeColor = Color.White;
            btnPersonnelSearch.Name = "btnPersonnelSearch";
            btnPersonnelSearch.Size = new System.Drawing.Size(161, 59);
            btnPersonnelSearch.Text = "Personnel Search";
            btnPersonnelSearch.Click += Click_Personnel_Butt;
        }

        private void Click_Personnel_Butt(object sender, EventArgs e)
        {
            DisableLeftButtons();
            Panel color = new Panel();
            color.Size = new Size(7, 59);
            color.BackColor = Color.FromArgb(32, 75, 104);
            (sender as Button).Controls.Add(color);
            color.Dock = DockStyle.Right;

            personnelPanel = new Panel();
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(personnelPanel);
            personnelPanel.Visible = true;
            personnelPanel.BringToFront();
            personnelPanel.Dock = DockStyle.Fill;
            if ((sender as Button).Name == "btnPersonnelList")
            {
                PersonnelListClick();
            }

            if ((sender as Button).Name == "btnPersonnelSearch")
            {
                PersonnelSearchClick();
            }
        }

        private void PersonnelSearchClick()
        {
            Application.DoEvents();
            personnelPanel.Controls.Clear();

            Panel pnlMiddle = new Panel();
            pnlMiddle.Size = new Size(8, 713);
            pnlMiddle.BackColor = Color.FromArgb(32, 133, 247);
            pnlMiddle.Location = new Point(500, 0);


            Label text = new Label();
            text.Location = new Point(51, 71);
            text.AutoSize = true;
            text.Text = "Kart ID'sine\n Göre Ara";
            text.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular);

            txtSearchById = new TextBox();
            txtSearchById.Location = new Point(171, 71);
            txtSearchById.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular);
            txtSearchById.Size = new Size(300, 100);

            Button searchByCardId = new Button();
            searchByCardId.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular);
            searchByCardId.FlatAppearance.BorderSize = 0;
            searchByCardId.Location = new Point(171, 121);
            searchByCardId.Text = "Ara!";
            searchByCardId.AutoSize = true;
            searchByCardId.Click += new EventHandler(Click_Search_ById);

            Label text1 = new Label();
            text1.Location = new Point(520, 71);
            text1.AutoSize = true;
            text1.Text = "Personel İsmine\n Göre Ara";
            text1.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular);

            txtSearchByName = new TextBox();
            txtSearchByName.Location = new Point(640, 71);
            txtSearchByName.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular);
            txtSearchByName.Size = new Size(300, 100);


            Button searchByName = new Button();
            searchByName.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular);
            searchByName.FlatAppearance.BorderSize = 0;
            searchByName.Location = new Point(640, 121);
            searchByName.Text = "Ara!";
            searchByName.AutoSize = true;
            searchByName.Click += new EventHandler(Click_Search_ByName);



            personnelPanel.Controls.Add(text);
            personnelPanel.Controls.Add(text1);
            personnelPanel.Controls.Add(searchByCardId);
            personnelPanel.Controls.Add(txtSearchByName);
            personnelPanel.Controls.Add(txtSearchById);
            personnelPanel.Controls.Add(searchByName);
            personnelPanel.Controls.Add(pnlMiddle);

        }

        private void Click_Search_ByName(object sender, EventArgs e)
        {
            PersonDesign pd = new PersonDesign();
            Personel personel = new Personel();
            IPersonelDal _personelDal = new PersonelDal();

            personel = _personelDal.GetByName(txtSearchByName.Text);
            if (personel.personel_id == 0)
            {
                MessageBox.Show("Bu isme sahip bir personel bulunamadı!");
            }

            else
            {
                pd.Location = new Point(51, 181);
                pd.setLabelName(personel.personel_isim);
                pd.setLabelPersonelID(personel.personel_id.ToString());
                pd.setLabelCardNo(personel.kart_id.ToString());
                pd.setDepartman(personel.departman_id.ToString());
                pd.setLabelSurname(personel.personel_soyisim);
                personnelPanel.Controls.Add(pd);
            }
            txtSearchByName.Clear();
        }

        private void Click_Search_ById(object sender, EventArgs e)
        {
            PersonDesign pd = new PersonDesign();
            Personel personel = new Personel();
            IPersonelDal _personelDal = new PersonelDal();
            
            personel = _personelDal.GetById(Convert.ToInt32(txtSearchById.Text));
            if (personel.personel_id==0)
            {
                MessageBox.Show("Bu ID'ye sahip bir personel bulunamadı!");
            }

            else
            {
                pd.Location = new Point(51, 181);
                pd.setLabelName(personel.personel_isim);
                pd.setLabelPersonelID(personel.personel_id.ToString());
                pd.setLabelCardNo(personel.kart_id.ToString());
                pd.setDepartman(personel.departman_id.ToString());
                pd.setLabelSurname(personel.personel_soyisim);
                personnelPanel.Controls.Add(pd);
            }
            txtSearchById.Clear();
        }

        private void PersonnelListClick()
        {
            Application.DoEvents();
            personnelPanel.Controls.Clear();
            Panel pnl = new Panel();
            pnl.Location = new Point(93, 71);
            pnl.Size = new Size(818, 444);
            FlowLayoutPanel flw = new FlowLayoutPanel();
            personnelPanel.Controls.Add(pnl);
            pnl.BackColor = Color.FromArgb(2, 86, 181);
            pnl.Controls.Add(flw);

            pnl.Controls.Add(flw);
            List<PersonDesign> pts = new List<PersonDesign>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                PersonDesign pt;
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("getPersonnels", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        pt = new PersonDesign();
                        pt.setLabelName(reader["personel_isim"].ToString());
                        pt.setLabelSurname(reader["personel_soyisim"].ToString());
                        pt.setDepartman(reader["departman_isim"].ToString());
                        pt.setLabelCardNo(reader["kart_no"].ToString());
                        pt.setLabelPersonelID(reader["personel_id"].ToString());
                        pts.Add(pt);
                    }
                    reader.Close();
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (PersonDesign pt in pts)
            {
                flw.Controls.Add(pt);
            }

            flw.Visible = true;
            flw.BringToFront();
            flw.Dock = DockStyle.Fill;
            flw.AutoScroll = true;
        }

        void Click_Dashboard_Butt(object sender, EventArgs e)
        {
            DisableLeftButtons();
            Panel color = new Panel();
            color.Size = new Size(7, 59);
            color.BackColor = Color.FromArgb(32, 75, 104);
            (sender as Button).Controls.Add(color);
            color.Dock = DockStyle.Right;

            dashBoardPanel = new Panel();
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(dashBoardPanel);
            dashBoardPanel.Visible = true;
            dashBoardPanel.BringToFront();
            dashBoardPanel.Dock = DockStyle.Fill;
            if ((sender as Button).Name == "btnMonitor")
            {
                MonitorClick(); 
            }

            if ((sender as Button).Name == "btnReports")
            {
                ReportsClick();
            }

            if ((sender as Button).Name == "btnAccessPoints")
            {
                AccessPoints();
            }

        }

        private void AccessPoints()
        {
            Application.DoEvents();
            dashBoardPanel.Controls.Clear();
            List<GirisYerleri> girisYerleri = new List<GirisYerleri>();
            DataGridView dtg = new DataGridView();

            IGirisYeriDal _girisYeriDal = new GirisYeriDal();
            girisYerleri = _girisYeriDal.GetAll();

            dtg.Columns.Add("giris_id", "Giriş Yeri ID");
            dtg.Columns[0].DataPropertyName = "giris_id";
            dtg.Columns.Add("giris_isim", "Giriş Yeri İsmi");
            dtg.Columns[1].DataPropertyName = "giris_isim";

            dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtg.Font = new Font("Coolvetica", 10F, FontStyle.Regular);

            Label text = new Label();
            text.Location = new Point(113, 71);
            text.Text = "Giriş Yerleri";
            text.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular);
            dtg.DataSource = girisYerleri;
            dtg.BackgroundColor = Color.White;
            dtg.Location = new Point(113, 107);
            dtg.Size = new Size(400, 326);
            dtg.BorderStyle = BorderStyle.None;
            dtg.MultiSelect = false;
            dtg.ReadOnly = true;
            dtg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dashBoardPanel.Controls.Add(dtg);
            dashBoardPanel.Controls.Add(text);

        }

        private void DisableLeftButtons()
        {
            foreach (Control previousBtn in pnlLeft.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.Controls.Clear();
                }
            }
        }

        private void ReportsClick()
        {
            Application.DoEvents();
            dashBoardPanel.Controls.Clear();
            List<Reports> reports = new List<Reports>();
            DataGridView dtg = new DataGridView();

            IReportDal _reportDal = new ReportDal();
            reports = _reportDal.GetReports();

            dtg.Columns.Add("personel_isim", "Personel İsim");
            dtg.Columns[0].DataPropertyName = "personel_isim";
            dtg.Columns.Add("personel_soyisim", "Soyisim");
            dtg.Columns[1].DataPropertyName = "personel_soyisim";
            dtg.Columns.Add("aksiyon_sayisi", "Aksiyon Sayısı");
            dtg.Columns[2].DataPropertyName = "aksiyon_sayisi";

            dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtg.Font = new Font("Coolvetica", 10F, FontStyle.Regular);

            Label text = new Label();
            text.Location = new Point(113, 71);
            text.Text = "Raporlar";
            text.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular);
            dtg.DataSource = reports;
            dtg.BackgroundColor = Color.White;
            dtg.Location = new Point(113, 107);
            dtg.Size = new Size(400, 326);
            dtg.BorderStyle = BorderStyle.None;
            dtg.MultiSelect = false;
            dtg.ReadOnly = true;
            dtg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dashBoardPanel.Controls.Add(dtg);
            dashBoardPanel.Controls.Add(text);
        }

        private void MonitorClick()
        {
            Application.DoEvents();
            dashBoardPanel.Controls.Clear();
            IAksiyonDal _aksiyonDal = new AksiyonDal();
            monitorInfos = _aksiyonDal.GetMonitor();
            dtg = new DataGridView();

            dtg.Columns.Add("aksiyon_id", "Aksiyon ID");
            dtg.Columns[0].DataPropertyName = "aksiyon_id";
            dtg.Columns.Add("aksiyon_tarih_saat", "Tarih/Saat");
            dtg.Columns[1].DataPropertyName = "aksiyon_tarih_saat";
            dtg.Columns.Add("personel_isim", "Personel İsim");
            dtg.Columns[2].DataPropertyName = "personel_isim";
            dtg.Columns.Add("personel_soyisim", "Soyisim");
            dtg.Columns[3].DataPropertyName = "personel_soyisim";
            dtg.Columns.Add("giris_isim", "Giriş Yeri");
            dtg.Columns[4].DataPropertyName = "giris_isim";

            dtg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtg.Font= new Font("Coolvetica", 10F, FontStyle.Regular);

            Label text = new Label();
            text.Location = new Point(113, 71);
            text.Text = "Monitor";
            text.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular);

            Label text1 = new Label();
            text1.Location = new Point(700, 91);
            text1.Text = "ARAMA YAP";
            text1.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular);

            Label text2 = new Label();
            text2.Location = new Point(700, 151);
            text2.Text = "İsme göre";
            text2.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular);

            txtName = new TextBox();
            txtName.Location = new Point(700, 191);
            txtName.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular);
            txtName.Size = new Size(300, 100);
            Label text3 = new Label();
            text3.Location = new Point(700, 251);
            text3.Text = "Tarihe göre";
            text3.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular);

            Label text4 = new Label();
            text4.Location = new Point(700, 291);
            text4.Text = "Alt sınır";
            text4.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular);

            dtpLower = new DateTimePicker();
            dtpLower.Location = new Point(810, 291);
            dtpLower.CustomFormat = "MMMM dd yyyy";
            dtpLower.Format = DateTimePickerFormat.Custom;

            Label text5 = new Label();
            text5.Location = new Point(700, 341);
            text5.Text = "Üst sınır";
            text5.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular);

            dtpUpper = new DateTimePicker();
            dtpUpper.Location = new Point(810, 341);
            dtpUpper.CustomFormat = "MMMM dd yyyy";
            dtpUpper.Format = DateTimePickerFormat.Custom;

            Button search = new Button();
            search.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular);
            search.FlatAppearance.BorderSize = 0;
            search.Location = new Point(700, 433);
            search.Text = "Ara!";
            search.AutoSize = true;
            search.Click += new EventHandler(click_search);

            dtg.DataSource = monitorInfos;
            dtg.BackgroundColor = Color.White;
            dtg.Location = new Point(113, 107);
            dtg.Size=new Size(550, 326);
            dtg.MultiSelect = false;
            dtg.ReadOnly = true;
            dtg.BorderStyle = BorderStyle.None;
            dtg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtg.ColumnHeadersHeight = 60;
            dtg.SelectionChanged += new EventHandler(dataSelectChange);

            dashBoardPanel.Controls.Add(dtg);
            dashBoardPanel.Controls.Add(actionDetail);
            dashBoardPanel.Controls.Add(text);
            dashBoardPanel.Controls.Add(text1);
            dashBoardPanel.Controls.Add(text2);
            dashBoardPanel.Controls.Add(text3);
            dashBoardPanel.Controls.Add(search);
            dashBoardPanel.Controls.Add(txtName);
            dashBoardPanel.Controls.Add(dtpLower);
            dashBoardPanel.Controls.Add(dtpUpper);
            dashBoardPanel.Controls.Add(text4);
            dashBoardPanel.Controls.Add(text5);
        }

        private void click_search(object sender, EventArgs e)
        {
            List<Monitor> monitor = new List<Monitor>();
            if (txtName.Text != "")
            {
                foreach(Monitor m in monitorInfos)
                {

                    if (m.personel_isim.ToLower().Contains(txtName.Text.ToLower()))
                    {

                        //DateTime myDate;
                        //if (!DateTime.TryParse(m.aksiyon_tarih_saat, out myDate))
                        //{
                        //    // handle parse failure
                        //}
                        //if (dtpUpper.Value.CompareTo(myDate) == -1 && dtpLower.Value.CompareTo(myDate) == 1)
                        //{
                        monitor.Add(m);
                        //}

                    }
                }
                dtg.DataSource = monitor;
            }
            else if (txtName.Text == "")
            {
                dtg.DataSource = monitorInfos;
            }
            txtName.Clear();
        }

        private void dataSelectChange(object sender, EventArgs e)
        {
            IAksiyonDal _aksiyonDal = new AksiyonDal();
            DetailedHistory detailedHistory = new DetailedHistory();
            actionDetail.Location= new Point(113, 450);
            DataGridView dtg = sender as DataGridView;
            if(dtg.SelectedRows.Count == 1)
            {
                
                int aksiyon_id = Convert.ToInt32(dtg.CurrentRow.Cells[0].Value);
                detailedHistory = _aksiyonDal.GetDetailedHistory(aksiyon_id);

                actionDetail.setLabelID(detailedHistory.personel_id.ToString());
                actionDetail.setLabelDate(detailedHistory.aksiyon_tarih_saat);
                actionDetail.setLabelName(detailedHistory.personel_isim + " " + detailedHistory.personel_soyisim);
                actionDetail.setLabelCardID(detailedHistory.kart_no);
                actionDetail.setLabelAction(detailedHistory.giris_mi);
            }
        }

        private void ActiveButton(object btnSender)
        {
            if (btnSender != null)
            {

                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    Panel color = new Panel();
                    color.Size = new Size(190, 7);
                    color.BackColor = Color.FromArgb(155, 166, 38);
                    
                    currentButton.Controls.Add(color);
                    color.Dock = DockStyle.Bottom;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in pnlTop.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.Controls.Clear();
                }
            }
        }

        private void lblLogo_Click(object sender, EventArgs e)
        {
            foreach(Control c in pnlTop.Controls)
            {
                foreach(Control c1 in c.Controls)
                {
                    if (c1.GetType() == typeof(Panel))
                    {
                        c.Controls.Clear();
                    }
                }
            }
            if (!Hided)
            {
                slideTimer.Start();
            }
            LoadMainPanel();
        }

        private void LoadMainPanel()
        {
            pnlMain.Controls.Clear();
            pnlLeft.Size = new Size(16, 713);
            pnlLeft.Controls.Clear();
            Label text = new Label();
            text.Location = new Point(113, 71);
            text.Text = "Tekrardan HASC Personel Takip Sistemine Hoşgeldiniz!";
            text.BackColor = Color.Transparent;
            text.AutoSize = true;
            text.Font = new Font("Bahnschrift Condensed", 34.25F, FontStyle.Regular);
            pnlMain.Controls.Add(text);
            
            try
            {
                string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "personnel-management-system-5.png");
                PictureBox pb = new PictureBox();
                pb.Image = Image.FromFile(path);
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                pnlMain.Controls.Add(pb);
                text.Parent = pb;
                pb.Dock = DockStyle.Fill;
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            pnlMain.Controls.Clear();
            Label text = new Label();
            text.Location = new Point(51, 71);
            text.AutoSize = true;
            text.Text = "Şifreni değiştir";
            text.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular);

            txtPass = new TextBox();
            txtPass.Location = new Point(171, 71);
            txtPass.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular);
            txtPass.Size = new Size(300, 100);
            txtPass.UseSystemPasswordChar = true;

            Label text1 = new Label();
            text1.Location = new Point(51, 131);
            text1.AutoSize = true;
            text1.Text = "Şifre tekrarı";
            text1.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular);

            txtPassConfirm = new TextBox();
            txtPassConfirm.Location = new Point(171, 131);
            txtPassConfirm.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular);
            txtPassConfirm.Size = new Size(300, 100);
            txtPassConfirm.UseSystemPasswordChar = true;


            Button updatePass = new Button();
            updatePass.Font = new Font("Bahnschrift Condensed", 14.25F, FontStyle.Regular);
            updatePass.FlatAppearance.BorderSize = 0;
            updatePass.Location = new Point(171, 221);
            updatePass.Text = "Değiştir!";
            updatePass.AutoSize = true;
            updatePass.Click += new EventHandler(Click_Update_Pass);

            pnlMain.Controls.Add(text);
            pnlMain.Controls.Add(txtPass);
            pnlMain.Controls.Add(updatePass);
            pnlMain.Controls.Add(txtPassConfirm);
            pnlMain.Controls.Add(text1);


        }

        private void Click_Update_Pass(object sender, EventArgs e)
        {
            if(txtPass.Text!="" && txtPassConfirm.Text != "")
            {
                if (txtPass.Text == txtPassConfirm.Text)
                {
                    IAdminDal _adminDal = new AdminDal();
                    _adminDal.setPassword(currentAdmin.admin_mail, txtPass.Text);
                    MessageBox.Show("Şifreniz başarıyla değiştirildi!");
                    txtPass.Clear();
                    txtPassConfirm.Clear();
                }
                else
                {
                    MessageBox.Show("Şifre ve şifre tekrarı uyuşmuyor!");
                    txtPass.Clear();
                    txtPassConfirm.Clear();
                }
            }
        }
    }
}
