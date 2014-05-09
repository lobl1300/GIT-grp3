using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using NpgsqlTypes;

namespace Gymverksamhet_G3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox_Medlem.DataSource = Databasfunktioner.GetMedlemmar();
            listBox_Instruktor.DataSource = Databasfunktioner.GetInstruktor();
        }
        //VARIABLER


        //KNAPPAR & KONTROLLER


        //METODER



    }
}
