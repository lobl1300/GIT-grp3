using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NpgsqlTypes;
using System.ComponentModel;
using System.Configuration;


namespace Gymverksamhet_G3
{
    class Databasfunktioner
    {
        //VARIABLER
        //private const string conString = "GYM";
        private const string conString = "grp3vt14";
        
        //METODER
        //Lägg till medlem med parametrar
        public static void AddMedlem(string regMedlemsnummer, string regFornamn, string regEfternamn, string regTelefon, string regMailadress, string regGatuadress, string regMedlemsskapstyp, string regMedlemskort)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[conString];      //Hämta constant kopplingssträng
            NpgsqlConnection conn = new NpgsqlConnection(settings.ConnectionString);                    //skapa koppling
            NpgsqlTransaction trans = null;                                                             //skapa transaktion
            try
            {
                conn.Open();                                                                            //öppna koppling
                trans = conn.BeginTransaction();                                                        //påbörja transaktion
                                                                                                        //ladda command

                NpgsqlCommand command1 = new NpgsqlCommand(@"INSERT INTO medlem (medlemsnummer, fornamn, efternamn, telefonnummer, mailadress, gatuadress, medlemsskapstyp, medlemskort)
                                                            VALUES (:newMedlemsnummer, :newFornamn, :newEfternamn, :newTelefonnummer, :newMailadress, :newGatuadress, :newMedlemsskapstyp, :newMedlemskort)", conn);

                command1.Parameters.Add(new NpgsqlParameter("newMedlemsnummer", NpgsqlDbType.Varchar));
                command1.Parameters["newMedlemsnummer"].Value = regMedlemsnummer;
                command1.Parameters.Add(new NpgsqlParameter("newFornamn", NpgsqlDbType.Varchar));
                command1.Parameters["newFornamn"].Value = regFornamn;
                command1.Parameters.Add(new NpgsqlParameter("newEfternamn", NpgsqlDbType.Varchar));
                command1.Parameters["newEfternamn"].Value = regEfternamn;
                command1.Parameters.Add(new NpgsqlParameter("newTelefonnummer", NpgsqlDbType.Varchar));
                command1.Parameters["newTelefonnummer"].Value = regTelefon;
                command1.Parameters.Add(new NpgsqlParameter("newMailadress", NpgsqlDbType.Varchar));
                command1.Parameters["newMailadress"].Value = regMailadress;
                command1.Parameters.Add(new NpgsqlParameter("newGatuadress", NpgsqlDbType.Varchar));
                command1.Parameters["newGatuadress"].Value = regGatuadress;
                command1.Parameters.Add(new NpgsqlParameter("newMedlemsskapstyp", NpgsqlDbType.Varchar));
                command1.Parameters["newMedlemsskapstyp"].Value = regMedlemsskapstyp;
                command1.Parameters.Add(new NpgsqlParameter("newMedlemskort", NpgsqlDbType.Varchar));
                command1.Parameters["newMedlemskort"].Value = regMedlemskort;
                command1.Transaction = trans;                                                           //sätt första transaktionskommando
                int numberofAffectedRows = command1.ExecuteNonQuery();                                  //kör command, lagra antal påverkade rader

                    // select medlemsnummret för den row där kolumner överensstämmer med parametervärden
                NpgsqlCommand command2 = new NpgsqlCommand(@"SELECT medlemsnummer
                                                            FROM medlem
                                                            WHERE fornamn = :regFornamn
                                                            AND efternamn = :regEfternamn
                                                            AND efternamn = :regEfternamn
                                                            AND telefonnummer = :regTelefonnummer
                                                            AND mailadress = :regMailadress
                                                            AND gatuadress = :regGatuadress
                                                            AND medlemsskapstyp = :regMedlemsskapstyp
                                                            AND medlemskort = :regMedlemskort", conn);

                command2.Parameters.Add(new NpgsqlParameter("regFornamn", NpgsqlDbType.Varchar));
                command2.Parameters["regFornamn"].Value = regFornamn;
                command2.Parameters.Add(new NpgsqlParameter("regEfternamn", NpgsqlDbType.Varchar));
                command2.Parameters["regEfternamn"].Value = regEfternamn;
                command2.Parameters.Add(new NpgsqlParameter("regTelefonnummer", NpgsqlDbType.Varchar));
                command2.Parameters["regTelefonnummer"].Value = regTelefon;
                command2.Parameters.Add(new NpgsqlParameter("regMailadress", NpgsqlDbType.Varchar));
                command2.Parameters["regMailadress"].Value = regMailadress;
                command2.Parameters.Add(new NpgsqlParameter("regGatuadress", NpgsqlDbType.Varchar));
                command2.Parameters["regGatuadress"].Value = regGatuadress;
                command2.Parameters.Add(new NpgsqlParameter("regMedlemsskapstyp", NpgsqlDbType.Varchar));
                command2.Parameters["regMedlemsskapstyp"].Value = regMedlemsskapstyp;
                command2.Parameters.Add(new NpgsqlParameter("regMedlemskort", NpgsqlDbType.Varchar));
                command2.Parameters["regMedlemskort"].Value = regMedlemskort;
                command2.Transaction = trans;                                                   //Sätt ett andra transaktionskommando
                string medlemsnummer = (string)command2.ExecuteScalar();                        //ta medlemsnummer från första kolumn på första rad

                trans.Commit();                                                                 //Utför transaktionen
            }
            catch (NpgsqlException except)                                                      //fånga och rulla tillbaka transaktionens pågående värde
            {
                trans.Rollback();
            }
            finally
            {
                conn.Close();                                                                   //stäng koppling
            }
        }

        //Uppdatera databasens medlemstabell med parametrar
        public static void UpdateMedlem(string Medlemsnummer, string nyttFornamn, string nyttEfternamn, string nyTelefon, string nyMailadress, string nyGatuadress, string nyMedlemskapstyp, string nyttMedlemskort)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[conString];
            NpgsqlConnection conn = new NpgsqlConnection(settings.ConnectionString);
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand(@"UPDATE medlem
                                                        SET fornamn = :nFornamn,
                                                            efternamn = :nEfternamn,
                                                            telefonnummer = :nTelefon,
                                                            mailadress = :nMailadress,
                                                            gatuadress = :nGatuadress,
                                                            medlemsskapstyp = :nMedlemsskapstyp,
                                                            medlemskort = :nMedlemskort
                                                        WHERE medlemsnummer = :Medlemsnummer", conn);

            command.Parameters.Add(new NpgsqlParameter("Medlemsnummer", NpgsqlDbType.Varchar));
            command.Parameters["Medlemsnummer"].Value = Medlemsnummer;
            command.Parameters.Add(new NpgsqlParameter("nFornamn", NpgsqlDbType.Varchar));
            command.Parameters["nFornamn"].Value = nyttFornamn;
            command.Parameters.Add(new NpgsqlParameter("nEfternamn", NpgsqlDbType.Varchar));
            command.Parameters["nEfternamn"].Value = nyttEfternamn;
            command.Parameters.Add(new NpgsqlParameter("ntelefon", NpgsqlDbType.Varchar));
            command.Parameters["nTelefon"].Value = nyTelefon;
            command.Parameters.Add(new NpgsqlParameter("nMailadress", NpgsqlDbType.Varchar));
            command.Parameters["nMailadress"].Value = nyMailadress;
            command.Parameters.Add(new NpgsqlParameter("nGatuadress", NpgsqlDbType.Varchar));   //Kommer ej gå att uppdatera pg fk-pk constraint
            command.Parameters["nGatuadress"].Value = nyGatuadress;                             //adresser har en egen tabell, denna parameter pekar på fk
            command.Parameters.Add(new NpgsqlParameter("nMedlemsskapstyp", NpgsqlDbType.Varchar));
            command.Parameters["nMedlemsskapstyp"].Value = nyMedlemskapstyp;
            command.Parameters.Add(new NpgsqlParameter("nMedlemskort", NpgsqlDbType.Varchar));
            command.Parameters["nMedlemskort"].Value = nyttMedlemskort;

            int numberOfRowsAffected = command.ExecuteNonQuery();
            conn.Close();
        }

        //Ta bort vald medlemsrad ur databasen
        public static void RemoveMedlem(string Medlemsnummer)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[conString];
            NpgsqlConnection conn = new NpgsqlConnection(settings.ConnectionString);
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("DELETE FROM medlem WHERE medlemsnummer ='" + Medlemsnummer + "'", conn);
            int numberOfRowsAffected = command.ExecuteNonQuery();
            conn.Close();
        }



        //Hämta medlemmar, sortera efter förnamn och efternamn, placera i och returnera en Bindinglist
        public static BindingList<Medlem> GetMedlemmar()         //System ComponentModel Binding möjliggör uppdatering av listbox vid anrop
        {
            BindingList<Medlem> medlemslista = new BindingList<Medlem>();
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[conString];
            NpgsqlConnection conn = new NpgsqlConnection(settings.ConnectionString);
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM medlem order by fornamn, efternamn", conn);
            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                Medlem medlem = new Medlem
                {
                    Medlemsnummer = (string)dr["medlemsnummer"],
                    Fornamn = (string)dr["fornamn"],
                    Efternamn = (string)dr["efternamn"],
                    Telefonummer = (string)dr["telefonnummer"],
                    Mailadress = (string)dr["mailadress"],
                    Gatuadress = (string)dr["gatuadress"],
                    Medlemsskapstyp = (string)dr["medlemsskapstyp"],
                    Medlemskort = (string)dr["medlemskort"]
                };
                medlemslista.Add(medlem);
            }
            conn.Close();

            return medlemslista;
        }
        //*************************************************************************************************************************************
        //*************************************************************************************************************************************
        //Tränare

        public static void AddInstruktor(string regInstruktorsnummer, string regFornamn, string regEfternamn, string regTelefon, string regMailadress, string regGatuadress)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[conString];
            NpgsqlConnection conn = new NpgsqlConnection(settings.ConnectionString);
            NpgsqlTransaction trans = null;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();

                NpgsqlCommand command1 = new NpgsqlCommand(@"INSERT INTO instruktor (instruktorsnummer, fornamn, efternamn, telefonnummer, mailadress, gatuadress)
                                                            VALUES (:newInstruktorsnummer, :newFornamn, :newEfternamn, :newTelefonnummer, :newMailadress, :newGatuadress)", conn);

                command1.Parameters.Add(new NpgsqlParameter("newInstruktorsnummer", NpgsqlDbType.Varchar));
                command1.Parameters["newInstruktorsnummer"].Value = regInstruktorsnummer;
                command1.Parameters.Add(new NpgsqlParameter("newFornamn", NpgsqlDbType.Varchar));
                command1.Parameters["newFornamn"].Value = regFornamn;
                command1.Parameters.Add(new NpgsqlParameter("newEfternamn", NpgsqlDbType.Varchar));
                command1.Parameters["newEfternamn"].Value = regEfternamn;
                command1.Parameters.Add(new NpgsqlParameter("newTelefonnummer", NpgsqlDbType.Varchar));
                command1.Parameters["newTelefonnummer"].Value = regTelefon;
                command1.Parameters.Add(new NpgsqlParameter("newMailadress", NpgsqlDbType.Varchar));
                command1.Parameters["newMailadress"].Value = regMailadress;
                command1.Parameters.Add(new NpgsqlParameter("newGatuadress", NpgsqlDbType.Varchar));
                command1.Parameters["newGatuadress"].Value = regGatuadress;
                command1.Transaction = trans;
                int numberofAffectedRows = command1.ExecuteNonQuery();

                // hämta personnummer
                NpgsqlCommand command2 = new NpgsqlCommand(@"SELECT personnummer
                                                            FROM tranare
                                                            WHERE fornamn = :regFornamn
                                                            AND efternamn = :regEfternamn
                                                            AND efternamn = :regEfternamn
                                                            AND telefonnummer = :regTelefonnummer
                                                            AND mailadress = :regMailadress
                                                            AND gatuadress = :regGatuadress", conn);

                command2.Parameters.Add(new NpgsqlParameter("regFornamn", NpgsqlDbType.Varchar));
                command2.Parameters["regFornamn"].Value = regFornamn;
                command2.Parameters.Add(new NpgsqlParameter("regEfternamn", NpgsqlDbType.Varchar));
                command2.Parameters["regEfternamn"].Value = regEfternamn;
                command2.Parameters.Add(new NpgsqlParameter("regTelefonnummer", NpgsqlDbType.Varchar));
                command2.Parameters["regTelefonnummer"].Value = regTelefon;
                command2.Parameters.Add(new NpgsqlParameter("regMailadress", NpgsqlDbType.Varchar));
                command2.Parameters["regMailadress"].Value = regMailadress;
                command2.Parameters.Add(new NpgsqlParameter("regGatuadress", NpgsqlDbType.Varchar));
                command2.Parameters["regGatuadress"].Value = regGatuadress;
                command2.Transaction = trans;
                string personnummer = (string)command2.ExecuteScalar();

                trans.Commit();
            }
            catch (NpgsqlException except)                                          
            {
                trans.Rollback();
            }
            finally
            {
                conn.Close();
            }
        }
        public static void UpdateInstruktor(string Instruktorsnummer, string nyttFornamn, string nyttEfternamn, string nyTelefon, string nyMailadress, string nyGatuadress)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[conString];
            NpgsqlConnection conn = new NpgsqlConnection(settings.ConnectionString);
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand(@"UPDATE instruktor
                                                       SET fornamn = :nFornamn,
                                                           efternamn = :nEfternamn,
                                                           telefonnummer = :nTelefon,
                                                           mailadress = :nMailadress,
                                                           gatuadress = :nGatuadress                                                          
                                                       WHERE instruktorsnummer = :Instruktorsnummer", conn);

            command.Parameters.Add(new NpgsqlParameter("instruktorsnummer", NpgsqlDbType.Varchar));
            command.Parameters["instruktorsnummer"].Value = Instruktorsnummer;
            command.Parameters.Add(new NpgsqlParameter("nFornamn", NpgsqlDbType.Varchar));
            command.Parameters["nFornamn"].Value = nyttFornamn;
            command.Parameters.Add(new NpgsqlParameter("nEfternamn", NpgsqlDbType.Varchar));
            command.Parameters["nEfternamn"].Value = nyttEfternamn;
            command.Parameters.Add(new NpgsqlParameter("ntelefon", NpgsqlDbType.Varchar));
            command.Parameters["nTelefon"].Value = nyTelefon;
            command.Parameters.Add(new NpgsqlParameter("nMailadress", NpgsqlDbType.Varchar));
            command.Parameters["nMailadress"].Value = nyMailadress;
            command.Parameters.Add(new NpgsqlParameter("nGatuadress", NpgsqlDbType.Varchar));
            command.Parameters["nGatuadress"].Value = nyGatuadress;

            int numberOfRowsAffected = command.ExecuteNonQuery();
            conn.Close();
        }

        public static void RemoveInstruktor(string Instruktorsnummer)           //Ta bort rad från tabell tränare
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[conString];
            NpgsqlConnection conn = new NpgsqlConnection(settings.ConnectionString);
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("DELETE FROM tranare WHERE instruktorsnummer ='" + Instruktorsnummer + "'", conn);
            int numberOfRowsAffected = command.ExecuteNonQuery();
            conn.Close();
        }

        public static BindingList<Instruktor> GetInstruktor()                 //Hämta, läs in, sortera & presentera instruktörslista
        {
            BindingList<Instruktor> instruktorslista = new BindingList<Instruktor>();
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[conString];
            NpgsqlConnection conn = new NpgsqlConnection(settings.ConnectionString);
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM instruktor order by fornamn, efternamn", conn);
            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                Instruktor instruktor = new Instruktor
                {
                    Instruktorsnummer = (string)dr["instruktorsnummer"],
                    Fornamn = (string)dr["fornamn"],
                    Efternamn = (string)dr["efternamn"],
                    Telefonummer = (string)dr["telefonnummer"],
                    Mailadress = (string)dr["mailadress"],
                    Gatuadress = (string)dr["gatuadress"]
                };
                instruktorslista.Add(instruktor);
            }
            conn.Close();

            return instruktorslista;
        }

        //************************************************************************************************************************
        //*************************************************************************************************************************
        //Bokningar
        public static void Boka(string bokAktivitet, string bokMedlem)
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[conString];
            NpgsqlConnection conn = new NpgsqlConnection(settings.ConnectionString);
            NpgsqlTransaction trans = null;
            try
            {
                conn.Open();
                trans = conn.BeginTransaction();

                NpgsqlCommand command1 = new NpgsqlCommand(@"INSERT INTO bokning (id_passnummer, id_medlemsnummer)
                                                             VALUES (:bokaAktivitet, :bokaMedlem)", conn);
                command1.Parameters.Add(new NpgsqlParameter("bokaAktivitet", NpgsqlDbType.Varchar));
                command1.Parameters["bokaAktivitet"].Value = bokAktivitet;
                command1.Parameters.Add(new NpgsqlParameter("bokaMedlem", NpgsqlDbType.Varchar));
                command1.Parameters["bokaMedlem"].Value = bokMedlem;
                command1.Transaction = trans;
                int numberOfRowsAffected = command1.ExecuteNonQuery();

                NpgsqlCommand command2 = new NpgsqlCommand(@"SELECT id_passnummer, id_medlemsnummer
                                                             FROM bokning 
                                                             WHERE id_passnummer = :bAktivitet
                                                             AND id_medlemsnummer = :bMedlem", conn);
                command2.Parameters.Add(new NpgsqlParameter("bAktivitet", NpgsqlDbType.Varchar));
                command2.Parameters["bMedlem"].Value = bokAktivitet;
                command2.Parameters.Add(new NpgsqlParameter("bMedlem", NpgsqlDbType.Varchar));
                command2.Parameters["bMedlem"].Value = bokMedlem;
                command2.Transaction = trans;
                string dagtid = (string)command2.ExecuteScalar();

                trans.Commit();
            }
            catch (NpgsqlException ex)
            {
                trans.Rollback();
            }
            finally
            {
                conn.Close();
            }
        }


        public static BindingList<Bokning> GetBokning()         
        {
            BindingList<Bokning> bokningslista = new BindingList<Bokning>();
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[conString];
            NpgsqlConnection conn = new NpgsqlConnection(settings.ConnectionString);
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM bokning order by id_passnummer, id_medlemsnummer", conn);
            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                Bokning bokning = new Bokning
                {
                    PassnummerID = (string)dr["id_passnummer"],
                    MedlemsID = (string)dr["id_medlemsnummer"]                    
                };
                bokningslista.Add(bokning);
            }
            conn.Close();

            return bokningslista;
        }
        //************************************************************************************************************************
        //*************************************************************************************************************************
        //Aktivitet

        public static BindingList<Aktivitet> GetAktivitet()
        {
            BindingList<Aktivitet> aktivitetslista = new BindingList<Aktivitet>();
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[conString];
            NpgsqlConnection conn = new NpgsqlConnection(settings.ConnectionString);
            conn.Open();
            NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM aktivitet order by passnummer", conn);
            NpgsqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                Aktivitet aktivitet = new Aktivitet
                {
                    Passnummer = (string)dr["passnummer"],
                    Tidsperiod = (string)dr["tidsperiod"],
                    Ledande_Instruktor = (string)dr["ledande_instruktor"],
                    Traningstyp = (string)dr["traningstyp"],
                    Lokal = (int)dr["lokal"]
                };
                aktivitetslista.Add(aktivitet);
            }
            conn.Close();

            return aktivitetslista;
        }



    }
}
