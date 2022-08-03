using System;
using System.Data.SQLite;
using System.Text;
using System.Windows;

namespace DataGridTest
{

    public static class SQL
    {

        readonly public static string[] fieldNames = { "Seriennummer", "aktuellerStandort", "art", "Fabrikat", "Type", "Baujahr", "Leistung", "Schaltgruppe", "Betriebsart",
            "ISO", "Isolierfluessigkeit_Oel", "OeltemperaturMax", "Gesamtgewicht","Oelgewicht", "Kuehlung", "PCB_Anteil", "Geraeuschpegel", "Aushebbarerteil",
            "Netzfrequenz", "Stellung1", "Stellung2", "Stellung3", "Stellung4", "Stellung5", "Spannung_Sekundaer", "Uk", "Strom_Primaer", "Strom2_Sekundaer",
            "Leerlaufverluste_P0", "Kupferverluste_Pk", "Widerstand", "MSA_ISO", "Strang", "Zustand", "imLager","Sonstiges"};
        readonly public static string dbName = "TrafoInfo.db";

        //GENERAL

        private static SQLiteConnection CreateConnection()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source= " + MainWindow.mainPath + "/" + dbName);
            try
            {
                conn.Open();
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Your inserted path might have been invalid please try again. " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;            
            }
            return conn;

        }
        private static void CloseConnection(SQLiteConnection conn)
        {
            if (conn != null) { conn.Close(); };
        }
        public static void CreateTable()
        {
            SQLiteConnection conn = CreateConnection();
            if (conn != null)
            {
                SQLiteCommand sqlite_cmd;
                string Createsql = "create table if not exists TrafoDaten( "
                    + "Seriennummer text primary key, aktuellerStandort text, art text, Fabrikat text, Type text, Baujahr text, " +
                    " Leistung text, Schaltgruppe text, Betriebsart text, ISO text, Isolierfluessigkeit_Oel text, " +
                    "OeltemperaturMax text, Gesamtgewicht text, Oelgewicht text, Kuehlung text, PCB_Anteil text, " +
                    "Geraeuschpegel text, Aushebbarerteil text, Netzfrequenz text, Stellung1 text, Stellung2 text, " +
                    "Stellung3 text, Stellung4 text, Stellung5 text, Spannung_Sekundaer text, Uk text, " +
                    "Strom_Primaer text, Strom2_Sekundaer text, Leerlaufverluste_P0 text, " +
                    "Kupferverluste_Pk text, Widerstand text, MSA_ISO text, Strang text, Zustand text," +
                    " imLager boolean, Sonstiges text);";

                string Createsql1 = "create table if not exists Historie(EintragID integer primary key autoincrement, " +
                    "Seriennummer text, Aufgestellt_am date, Standort text, Ausgebaut_am date, " +
                    "foreign key(Seriennummer) references Trafoliste(Seriennummer));";

                sqlite_cmd = conn.CreateCommand();
                sqlite_cmd.CommandText = Createsql;
                sqlite_cmd.ExecuteNonQuery();
                sqlite_cmd.CommandText = Createsql1;
                sqlite_cmd.ExecuteNonQuery();
                CloseConnection(conn);
            }
            else
            {
                PathInputWindow window = new();
                window.Show();
            }
        }



        //TRAFODATEN

        public static void InsertTrafolisteSeriennummer(string seriennummer)
        {
            SQLiteConnection conn = CreateConnection();
            SQLiteCommand sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "Insert into TrafoDaten(seriennummer) values ('" + seriennummer + "');";
            sqlite_cmd.ExecuteNonQuery();
            CloseConnection(conn);
        }
        public static void UpdateTrafolisteTextField(string seriennummer, string field, string text)
        {
            SQLiteConnection conn = CreateConnection();
            StringBuilder sb = new StringBuilder("Update Trafodaten set ");
            sb.Append(field);
            sb.Append("= '");
            sb.Append(text);
            sb.Append("' where seriennummer = '");
            sb.Append(seriennummer);
            sb.Append("';");

            SQLiteCommand sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = sb.ToString();
            sqlite_cmd.ExecuteNonQuery();
            CloseConnection(conn);
        }
        public static string[] getFromTrafolisteWhere(string seriennummer)
        {
            int n = 36;
            string[] data = new string[n];
            SQLiteConnection conn = CreateConnection();
            SQLiteCommand sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "select * from Trafodaten where seriennummer = '" + seriennummer + "' ;";
            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                for (int i = 0; i < n; i++)
                {
                    data[i] = sqlite_datareader.GetValue(i).ToString();
                }
            }
            CloseConnection(conn);
            return data;
        }
        public static void UpdateImLager(string seriennummer, bool tof)
        {
            SQLiteConnection conn = CreateConnection();
            StringBuilder sb = new StringBuilder("Update Trafodaten set imLager = ");
            sb.Append(tof.ToString());
            sb.Append(" where seriennummer = '");
            sb.Append(seriennummer);
            sb.Append("';");

            SQLiteCommand sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = sb.ToString();
            sqlite_cmd.ExecuteNonQuery();
            CloseConnection(conn);
        }
        public static string selectAllFromTrafoDaten()
        {
            SQLiteConnection conn = CreateConnection();
            var csv = new StringBuilder();
            SQLiteCommand sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "select * from Trafodaten order by seriennummer asc";
            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                for (int i = 0; i < 36; i++)
                {
                    csv.Append(sqlite_datareader.GetValue(i).ToString());
                    csv.Append(";");
                }
                csv.Append("\n");
            }

            CloseConnection(conn);
            return csv.ToString();
        }


        //HISTORIE

        public static string[] getStandortAndAufgestellt_amFromHistorieWhere(string seriennummer)
        {
            SQLiteConnection conn = CreateConnection();
            string[] standort_eingebautAm = new string[2];
            SQLiteCommand sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "select Standort,Aufgestellt_am from Historie where seriennummer = '" + seriennummer + "' order by Aufgestellt_am desc limit 1;";
            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                standort_eingebautAm[0] = sqlite_datareader.GetValue(0).ToString();
                standort_eingebautAm[1] = sqlite_datareader.GetValue(1).ToString();
            }
            CloseConnection(conn);
            return standort_eingebautAm;
        }
        public static void InsertHistorieSeriennummer(string seriennummer)
        {
            SQLiteConnection conn = CreateConnection();
            SQLiteCommand sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "Insert into Historie(seriennummer) values ('" + seriennummer + "');";
            sqlite_cmd.ExecuteNonQuery();
            CloseConnection(conn);
        }
        public static void UpdateHistorieTextField(string HID, string field, string text)
        {
            SQLiteConnection conn = CreateConnection();
            StringBuilder sb = new StringBuilder("Update Historie set ");
            sb.Append(field);
            sb.Append("= '");
            sb.Append(text);
            sb.Append("' where EintragID = ");
            sb.Append(HID);
            sb.Append(";");

            SQLiteCommand sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = sb.ToString();
            sqlite_cmd.ExecuteNonQuery();
            CloseConnection(conn);
        }
        public static string getEID(string seriennummer)
        {
            SQLiteConnection conn = CreateConnection();
            string eid = "";
            SQLiteCommand sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "select eintragid from Historie where seriennummer = '" + seriennummer + "' order by eintragID desc limit 1;";
            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                eid = sqlite_datareader.GetValue(0).ToString();

            }
            CloseConnection(conn);
            return eid;
        }
        public static void UpdateHistorieDateField(string EID, string field, string date)
        {
            if (!EID.Trim().Equals(""))
            {
                SQLiteConnection conn = CreateConnection();
                StringBuilder sb = new StringBuilder("Update Historie set ");
                sb.Append(field);
                sb.Append(" = '");
                sb.Append(date);
                sb.Append("' where EintragID  = ");
                sb.Append(EID);
                sb.Append(";");

                SQLiteCommand sqlite_cmd = conn.CreateCommand();
                sqlite_cmd.CommandText = sb.ToString();
                sqlite_cmd.ExecuteNonQuery();
                CloseConnection(conn);
            }
        }
        public static string getAllFromHistorie()
        {
            var csv = new StringBuilder();
            SQLiteConnection conn = CreateConnection();
            SQLiteCommand sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "select seriennummer,aufgestellt_am,standort,ausgebaut_am from Historie order by seriennummer asc, aufgestellt_am asc";
            SQLiteDataReader sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                for (int i = 0; i < 4; i++)
                {
                    csv.Append(sqlite_datareader.GetValue(i).ToString());
                    csv.Append(";");
                }
                csv.Append("\n");
            }
            CloseConnection(conn);
            return csv.ToString();
        }


    }
}
