using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inf3Project
{
    public partial class ServerData : Form
    {
        private String ip = "";
        private int port = 0;

        public ServerData()
        {
            InitializeComponent();
        }

        public String getIP()
        {
            return ip;
        }

        public int getPort()
        {
            return port;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ip = textBox1.Text;

            try
            {
                port = int.Parse(textBox2.Text);
            }
            catch (Exception)
            {
                //error code here - parse error
            }

            this.Visible = false;
        }
    }
}
