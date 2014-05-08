using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gymverksamhet_G3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Login loginForm = new Login();
            DialogResult dr = loginForm.ShowDialog();
                if(dr == DialogResult.OK)
                {
                    Application.Run(new Form1());                    
                }
                else if(dr == DialogResult.Retry)
                {
                    MessageBox.Show("Nej. Gör om, gör rätt!");
                    //Application.Exit();
                }
                else
                {
                   // Application.Exit();
                }
            
        }
    }
}
