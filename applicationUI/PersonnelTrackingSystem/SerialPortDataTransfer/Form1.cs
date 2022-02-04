using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.Data.SqlClient;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;


namespace SerialPortDataTransfer
{

    public partial class Form1 : Form
    {
        private string data;
        private string card_no;
        DateTime dateTime = new DateTime();

        public Form1()
        {
            InitializeComponent();
            getAvailablePorts();


        }

        private void getAvailablePorts()
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                cmbPort.Items.Clear();
                cmbPort.Items.AddRange(ports);
            }
            serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialPort_DataReceived);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            data = serialPort.ReadLine();
            this.Invoke(new EventHandler(displayData));
        }

        private void displayData(object sender, EventArgs e)
        {
            string[] value = data.Split(' ');
            string card = value[2] + " " + value[3] + " " + value[4] + " " + value[5];
            for (int i = 0; i < card.Length - 1; i++)
            {
                card_no = card;
            }
            txtID.Text = card_no;
            dateTime = DateTime.Now;
            txtDate.Text = dateTime.ToString();
            addAction();
        }

        private void connectPort_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort.PortName = cmbPort.Text;
                serialPort.Open();
                connectPort.Enabled = false;
                disconnectPort.Enabled = true;
                lblStatus.Text = "Status: Connected";
                lblStatus.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void addAction()
        {
            IAksiyonDal _aksiyonDal = new AksiyonDal();
            _aksiyonDal.Add(card_no, txtDate.Text);
        }

        private void disconnectPort_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort.PortName = cmbPort.Text;
                serialPort.Close();
                connectPort.Enabled = true;
                disconnectPort.Enabled = false;
                lblStatus.Text = "Status: Disconnected";
                lblStatus.ForeColor = Color.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
