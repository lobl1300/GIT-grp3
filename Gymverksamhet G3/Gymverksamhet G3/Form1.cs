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
        //VARIABLER
        private Medlem aktuellMedlem;
        private Instruktor aktuellInstruktor;       


        //METODER
        private void Form1_Load(object sender, EventArgs e)
        {
            Uppdatera_Medlemslista();
            Uppdatera_Instruktorslista();
        }
        private void Uppdatera_Medlemslista()
        {
            listBox_Medlem.DataSource = Databasfunktioner.GetMedlemmar();
        }
        private void Rensa_Textboxar_Medlem()
        {
            textBox_Medlem_Medlemsnummer.Clear();
            textBox_Medlem_Fornamn.Clear();
            textBox_Medlem_Efternamn.Clear();
            textBox_Medlem_Gatuadress.Clear();
            textBox_Medlem_Mailadress.Clear();
            textBox_Medlem_Telefon.Clear();
            textBox_Medlem_Giltig.Clear();
            domainUpDown_Medlem_Typ.Text = "Välj";
            domainUpDown_Medlem_Kort.Text = "Välj";
        }
        private void Uppdatera_Instruktorslista()
        {
            listBox_Instruktor.DataSource = Databasfunktioner.GetInstruktor();
        }
        private void Rensa_Textboxar_Instruktor()
        {
            textBox_Instruktor_Personnummer.Clear();
            textBox_Instruktor_Fornamn.Clear();
            textBox_Instruktor_Efternamn.Clear();
            textBox_Instruktor_Gatuadress.Clear();
            textBox_Instruktor_Mailadress.Clear();
            textBox_Instruktor_Telefonnummer.Clear();
        }


        //KNAPPAR & KONTROLLER
        //**************************************************************************************************************
        //**************************************************************************************************************
        //Medlemmar
        private void button_Medlem_Registrera_Click(object sender, EventArgs e)
        {
            Databasfunktioner.AddMedlem(textBox_Medlem_Medlemsnummer.Text, textBox_Medlem_Fornamn.Text, textBox_Medlem_Efternamn.Text, textBox_Medlem_Telefon.Text, textBox_Medlem_Mailadress.Text, textBox_Medlem_Gatuadress.Text, domainUpDown_Medlem_Typ.Text, domainUpDown_Medlem_Kort.Text);
            Uppdatera_Medlemslista();
        }
        private void listBox_Medlem_SelectedIndexChanged(object sender, EventArgs e)
        {
            aktuellMedlem = (Medlem)listBox_Medlem.SelectedItem;

            textBox_Medlem_Medlemsnummer.Text = aktuellMedlem.Medlemsnummer;
            textBox_Medlem_Fornamn.Text = aktuellMedlem.Fornamn;
            textBox_Medlem_Efternamn.Text = aktuellMedlem.Efternamn;
            textBox_Medlem_Telefon.Text = aktuellMedlem.Telefonummer;
            textBox_Medlem_Mailadress.Text = aktuellMedlem.Mailadress;
            textBox_Medlem_Gatuadress.Text = aktuellMedlem.Gatuadress;
            domainUpDown_Medlem_Typ.Text = aktuellMedlem.Medlemsskapstyp;
            domainUpDown_Medlem_Kort.Text = aktuellMedlem.Medlemskort;
        }

        private void button_Medlem_Uppdatera_Click(object sender, EventArgs e)
        {
            Databasfunktioner.UpdateMedlem(aktuellMedlem.Medlemsnummer, textBox_Medlem_Fornamn.Text, textBox_Medlem_Efternamn.Text, textBox_Medlem_Telefon.Text, textBox_Medlem_Mailadress.Text, textBox_Medlem_Gatuadress.Text, domainUpDown_Medlem_Typ.Text, domainUpDown_Medlem_Kort.Text);
            Uppdatera_Medlemslista();
        }
        private void button_Medlem_Tabort_Click(object sender, EventArgs e)
        {
            Databasfunktioner.RemoveMedlem(aktuellMedlem.Medlemsnummer);
            Uppdatera_Medlemslista();
        }
        private void button_Medlem_Rensa_Click(object sender, EventArgs e)
        {
            Rensa_Textboxar_Medlem();
        }
        //**************************************************************************************************************************************
        //**************************************************************************************************************************************
        //Instruktörer


        

       

       

        

       


    }
}
