using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inf3Project.Game
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void liveServerButton_Click(object sender, EventArgs e)
        {
            Connector connector = new Connector("85.214.103.114", 110);
            this.Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            Connector connector = new Connector(textBox1.Text.ToString(), Int16.Parse(textBox2.Text.ToString()));
            this.Close();
        }
    }
}
