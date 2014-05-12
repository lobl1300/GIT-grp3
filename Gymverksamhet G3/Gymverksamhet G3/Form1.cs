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
        private Aktivitet aktuellAktivitet;
        private Bokning aktuellBokning;
        private Medlem bokningsmarkeradMedlem;      //ny för att undvika dubbelmarkering på olika flikar
        private Aktivitet bokningsmarkeradAktivitet; //same ^
        


        //METODER
        private void Form1_Load(object sender, EventArgs e)
        {
            Uppdatera_Medlemslista();       //möjlig bugg gör det svårt att öppna connection via denna metodreferens vid programstart
            //listBox_Medlem.DataSource = Databasfunktioner.GetMedlemmar();
            Uppdatera_Instruktorslista();
            Uppdatera_Aktivitetslista();
            Uppdatera_Bokningslista();
        }
        private void Uppdatera_Medlemslista()
        {
            listBox_Medlem.DataSource = Databasfunktioner.GetMedlemmar();
            listBox_Bokning_Medlem.DataSource = Databasfunktioner.GetMedlemmar();
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
            listBox_Instruktor.DataSource = Databasfunktioner.GetInstruktorer();
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
        private void Uppdatera_Aktivitetslista()
        {
            listBox_Bokning_Aktivitet.DataSource = Databasfunktioner.GetAktiviteter();
        }
        private void Uppdatera_Bokningslista()
        {
            listBox_Bokningar.DataSource = Databasfunktioner.GetBokningar();
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

        private void button_Instruktor_LaggTill_Click(object sender, EventArgs e)
        {
            Databasfunktioner.AddInstruktor(textBox_Instruktor_Personnummer.Text, textBox_Instruktor_Fornamn.Text, textBox_Instruktor_Efternamn.Text, textBox_Instruktor_Telefonnummer.Text, textBox_Instruktor_Mailadress.Text, textBox_Instruktor_Gatuadress.Text);
            Uppdatera_Instruktorslista();
        }

        private void listBox_Instruktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            aktuellInstruktor = (Instruktor)listBox_Instruktor.SelectedItem;

            textBox_Instruktor_Personnummer.Text = aktuellInstruktor.Instruktorsnummer;
            textBox_Instruktor_Fornamn.Text = aktuellInstruktor.Fornamn;
            textBox_Instruktor_Efternamn.Text = aktuellInstruktor.Efternamn;
            textBox_Instruktor_Telefonnummer.Text = aktuellInstruktor.Telefonummer;
            textBox_Instruktor_Mailadress.Text = aktuellInstruktor.Mailadress;
            textBox_Instruktor_Gatuadress.Text = aktuellInstruktor.Gatuadress;
        }

        private void button_Instruktor_Uppdatera_Click(object sender, EventArgs e)
        {
            Databasfunktioner.UpdateInstruktor(aktuellInstruktor.Instruktorsnummer, textBox_Instruktor_Fornamn.Text, textBox_Instruktor_Efternamn.Text, textBox_Instruktor_Telefonnummer.Text, textBox_Instruktor_Mailadress.Text, textBox_Instruktor_Gatuadress.Text);
            Uppdatera_Instruktorslista();
        }

        private void button_Instruktor_TaBort_Click(object sender, EventArgs e)
        {
            Databasfunktioner.RemoveInstruktor(aktuellInstruktor.Instruktorsnummer);
            Uppdatera_Instruktorslista();
        }

        private void button_Instruktor_Rensa_Click(object sender, EventArgs e)
        {
            Rensa_Textboxar_Instruktor();
        }
        //**************************************************************************************************************************************
        //**************************************************************************************************************************************
        //Aktiviteter
        
        //So..how in the hela hela helvetet gör man ett interaktivt schema?

        //**************************************************************************************************************************************
        //**************************************************************************************************************************************
        //Bokningar
        private void listBox_Bokning_Medlem_SelectedIndexChanged(object sender, EventArgs e)
        {
            bokningsmarkeradMedlem = (Medlem)listBox_Bokning_Medlem.SelectedItem;            
        }
        private void listBox_Bokning_Aktivitet_SelectedIndexChanged(object sender, EventArgs e)
        {
            bokningsmarkeradAktivitet = (Aktivitet)listBox_Bokning_Aktivitet.SelectedItem;
        }

        private void button_Bokning_Boka_Click(object sender, EventArgs e)
        {
            Databasfunktioner.AddBokning(bokningsmarkeradAktivitet.Passnummer, bokningsmarkeradMedlem.Medlemsnummer);
            Uppdatera_Bokningslista();
        }
        private void listBox_Bokningar_SelectedIndexChanged(object sender, EventArgs e)
        {
            aktuellBokning = (Bokning)listBox_Bokningar.SelectedItem;
        }

        private void button_Bokning_Avboka_Click(object sender, EventArgs e)
        {
            Databasfunktioner.RemoveBokning(aktuellBokning.PassnummerID, aktuellBokning.MedlemsID);
            Uppdatera_Bokningslista();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] userLevel = new string[] { "Instruktör, Medlem, Reception, Ägare" };
            comboBoxUserLevel.Items.AddRange(userLevel);
        }














 










       
        
        

       

       

        

       


    }
}
