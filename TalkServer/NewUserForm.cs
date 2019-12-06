using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkyTalk
{
    public partial class NewUserForm : Form
    {

        public string username, password;

        public NewUserForm()
        {
            InitializeComponent();
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {

            username = userNameTextBox.Text.Trim();
            password = userPasswordTextBox.Text.Trim();

        }
    }
}
