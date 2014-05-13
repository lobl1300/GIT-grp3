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
        {   //HÅRDKODAT, BYTS MOT DATABASFUNKTION...när den är skriven
            if (textBox_Login_User.Text == user1 || textBox_Login_User.Text == user2 || textBox_Login_User.Text == user3)   //Användarnamn OK?
            {
                if (textBox_Login_Pass.Text == pass)                                                                        //Lösenord OK?
                {
                    this.DialogResult = DialogResult.OK;                                                                    //Skicka resultat OK
                    this.Close();                                                                                           //Stäng formulär
                }
                else                                                                                                        //Lösen EJ ok
                {
                    MessageBox.Show("Fel lösenord");                                                                        
                }
            }  
            else                                                                                                            //Användare EJ ok
            {
                MessageBox.Show("Fel Användarnamn");                
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        //METODER





    }
}
