using System;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace DataGridTest
{
    /// <summary>
    /// Interaktionslogik für ViewWindow.xaml
    /// </summary>
    public partial class ViewWindow : Window
    {
        string seriennummer;
        public ViewWindow(string seriennummer, string mainPath)
        {
            InitializeComponent();
            this.seriennummer = seriennummer;
            string[] data = SQL.getFromTrafolisteWhere(seriennummer);
            int n = 0;
            Seriennummer_Label.Content = data[n];
            aktuellerStandort_Label.Content = data[++n];
            Art_Label.Content = data[++n];
            Fabrikat_Label.Content = data[++n];
            Type_Label.Content = data[++n];
            Baujahr_Label.Content = data[++n];
            Leistung_Label.Content = data[++n];
            if (!data[n].Trim().Equals("kA") && !data[n].Trim().Equals("")) { Leistung_Label.Content += " kVA"; }
            Schaltgruppe_Label.Content = data[++n];
            Betriebsart_Label.Content = data[++n];
            ISO_Label.Content = data[++n];
            Isolierfl_Label.Content = data[++n];
            Oeltemperatur_Label.Content = data[++n];
            if (!data[n].Trim().Equals("kA") && !data[n].Trim().Equals("")) { Oeltemperatur_Label.Content += " °C"; }
            Gesamtgewicht_Label.Content = data[++n];
            if (!data[n].Trim().Equals("kA") && !data[n].Trim().Equals("")) { Gesamtgewicht_Label.Content += " Kg"; }
            Oelgewicht_Label.Content = data[++n];
            if (!data[n].Trim().Equals("kA") && !data[n].Trim().Equals("")) { Oelgewicht_Label.Content += " Kg"; }
            Kuehlung_Label.Content = data[++n];
            PCB_Anteil_Label.Content = data[++n];
            Geraeuschpegel_Label.Content = data[++n];
            if (!data[n].Trim().Equals("kA") && !data[n].Trim().Equals("")) { Geraeuschpegel_Label.Content += " dB"; }
            Aushebbarerteil_Label.Content = data[++n];
            if (!data[n].Trim().Equals("kA") && !data[n].Trim().Equals("")) { Aushebbarerteil_Label.Content += " Kg"; }
            Netzfrequenz_Label.Content = data[++n];
            if (!data[n].Trim().Equals("kA") && !data[n].Trim().Equals("")) { Netzfrequenz_Label.Content += " Hz"; }
            Stellung1_Label.Content = data[++n];
            if (!data[n].Trim().Equals("kA") && !data[n].Trim().Equals("")) { Stellung1_Label.Content += " V"; }
            Stellung2_Label.Content = data[++n];
            if (!data[n].Trim().Equals("kA") && !data[n].Trim().Equals("")) { Stellung2_Label.Content += " V"; }
            Stellung3_Label.Content = data[++n];
            if (!data[n].Trim().Equals("kA") && !data[n].Trim().Equals("")) { Stellung3_Label.Content += " V"; }
            Stellung4_Label.Content = data[++n];
            if (!data[n].Trim().Equals("kA") && !data[n].Trim().Equals("")) { Stellung4_Label.Content += " V"; }
            Stellung5_Label.Content = data[++n];
            if (!data[n].Trim().Equals("kA") && !data[n].Trim().Equals("")) { Stellung5_Label.Content += " V"; }
            Sekundaerspannung_Label.Content = data[++n];
            if (!data[n].Trim().Equals("kA") && !data[n].Trim().Equals("")) { Sekundaerspannung_Label.Content += " V"; }
            Uk_Label.Content = data[++n];
            if (!data[n].Trim().Equals("kA") && !data[n].Trim().Equals("")) { Uk_Label.Content += " %"; }
            Strom_Primaer_Label.Content = data[++n];
            if (!data[n].Trim().Equals("kA") && !data[n].Trim().Equals("")) { Strom_Primaer_Label.Content += " A"; }
            Strom_Sekundaer_Label.Content = data[++n];
            if (!data[n].Trim().Equals("kA") && !data[n].Trim().Equals("")) { Strom_Sekundaer_Label.Content += " A"; }
            Leerlaufverluste_Label.Content = data[++n];
            if (!data[n].Trim().Equals("kA") && !data[n].Trim().Equals("")) { Leerlaufverluste_Label.Content += " W"; }
            Kupferverluste_Label.Content = data[++n];
            if (!data[n].Trim().Equals("kA") && !data[n].Trim().Equals("")) { Kupferverluste_Label.Content += " W"; }
            n++;
            n++;
            n++;
            n++;
            n++;
            Sonstiges_TextBox.Text = data[++n];
            DataTable dt = new DataTable();

            using (SQLiteConnection connection = new SQLiteConnection("Data Source= " + mainPath + "/" + SQL.dbName))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter("select Aufgestellt_am , Standort , Ausgebaut_am  from Historie where Seriennummer ='" + seriennummer + "' order by eintragid asc", connection))
            using (SQLiteCommandBuilder command = new SQLiteCommandBuilder(adapter))
            {
                adapter.Fill(dt);
            }
            HistorieGrid.ItemsSource = null;
            HistorieGrid.Items.Clear();
            HistorieGrid.ItemsSource = dt.DefaultView;
            HistorieGrid.Items.Refresh();
        }



        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PrintDialog dialog = new PrintDialog();

                if (dialog.ShowDialog() != true)
                    return;
                dialog.PrintVisual(win, "IFMS Print Screen");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Print Screen", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
