using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PS3Lib;

namespace T5Z_RTM
{
    public partial class Form1 : Form
    {
        public static CCAPI ps3 = new CCAPI();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void connectAndAttach_Click(object sender, EventArgs e)
        {
            if (ps3.ConnectTarget())
            {
                ps3.AttachProcess();
                label1.Text = "Status: Connected";
                connectAndAttach.Enabled = false;
            }
            else
            {
                MessageBox.Show("Couldn't connect to PS3");
                label1.ForeColor = Color.Red;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uint pointsAddress = 0x0110090C;
            int desiredValue = 999999;
            byte[] pointsToSet = BitConverter.GetBytes(desiredValue);
            ps3.SetMemory(pointsAddress, pointsToSet);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uint[] addresses = { 0x010FF148, 0x010FF138, 0x010FF140 };
            for (int i = 0; i < addresses.Length; i++)
            {
                ps3.SetMemory(addresses[i], new byte[] { 0x00, 0x00, 0x0f, 0x40 });
            }
        }
    }
}
