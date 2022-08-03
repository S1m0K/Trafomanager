using System.Windows;

namespace DataGridTest
{
    /// <summary>
    /// Interaktionslogik für AddHistoryWindow.xaml
    /// </summary>
    public partial class AddHistoryWindow : Window
    {
        string seriennummer;
        public AddHistoryWindow(string seriennummer)
        {
            InitializeComponent();
            this.seriennummer = seriennummer;
            SeriennummerLabel.Content = seriennummer;
            string[] data = SQL.getStandortAndAufgestellt_amFromHistorieWhere(seriennummer);
            StandortLabel.Content = data[0];
            S1EingebautAmLabel.Content = data[1];

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!S2EingebautAmLabel.Text.Trim().Equals("") && !S2EingebautAmLabel.Text.Trim().Equals("yyyy-MM-dd")) {
                string eid = SQL.getEID(seriennummer);
                SQL.UpdateHistorieDateField(eid, "Ausgebaut_am", S2EingebautAmLabel.Text);
                SQL.InsertHistorieSeriennummer(seriennummer);
                eid = SQL.getEID(seriennummer);
                SQL.UpdateHistorieDateField(eid, "Aufgestellt_am", S2EingebautAmLabel.Text);
                if (moveToArchiv.IsChecked == false)
                {
                    if (moveToLager.IsChecked == false)
                    {

                        SQL.UpdateHistorieTextField(eid, "standort", newStandortLabel.Text);
                        SQL.UpdateTrafolisteTextField(seriennummer, "aktuellerstandort", newStandortLabel.Text);
                        SQL.UpdateImLager(seriennummer, false);
                    }
                    else
                    {
                        SQL.UpdateHistorieTextField(eid, "standort", "Lager");
                        SQL.UpdateTrafolisteTextField(seriennummer, "aktuellerstandort", "Lager");
                        SQL.UpdateImLager(seriennummer, true);
                    }
                }
                else
                {
                    SQL.UpdateHistorieTextField(eid, "standort", "Entsorgt");
                    SQL.UpdateTrafolisteTextField(seriennummer, "aktuellerstandort", "Entsorgt");
                    SQL.UpdateImLager(seriennummer, false);
                }
            }

            this.Close();
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
