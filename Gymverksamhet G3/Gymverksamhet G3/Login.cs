using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gymverksamhet_G3
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        //VARIABLER
        public string user1 = "Medlem";
        public string user2 = "Personal";
        public string user3 = "Ägare";
        public string pass = "Password";
    
        //KONTROLLER
        private void button_Login_Click(object sender, EventArgs e)
        {
            if (textBox_Login_User.Text == user1 || textBox_Login_User.Text == user2 || textBox_Login_User.Text == user3 && textBox_Login_User.Text == pass)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.Retry;
            }
        }

        //METODER





    }
}
