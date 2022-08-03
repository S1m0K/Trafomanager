using System;
using System.Windows;
using System.Windows.Media;

namespace DataGridTest
{
    /// <summary>
    /// Interaktionslogik für AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public static string[] fieldNames = SQL.fieldNames;

        public AddWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string seriennummer = "";
            if (!SeriennummerTB.Text.Trim().Equals("insert here") && !SeriennummerTB.Text.Trim().Equals(""))
            {
                seriennummer = SeriennummerTB.Text;
                SQL.InsertTrafolisteSeriennummer(seriennummer);
            }
            else
            {
                SeriennummerTB.BorderThickness = new Thickness(3);
                SeriennummerTB.BorderBrush = Brushes.Red;

                return;
            }



            if (!ArtTB.Text.Trim().Equals("insert here") && !ArtTB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[2], ArtTB.Text);
            }
            if (!FabrikatTB.Text.Trim().Equals("insert here") && !FabrikatTB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[3], FabrikatTB.Text);
            }
            if (!TypeTB.Text.Trim().Equals("insert here") && !TypeTB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[4], TypeTB.Text);
            }
            if (!BaujahrTB.Text.Trim().Equals("insert here") && !BaujahrTB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[5], BaujahrTB.Text);
            }
            if (!LeistungTB.Text.Trim().Equals("insert here") && !LeistungTB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[6], LeistungTB.Text);
            }
            if (!SchaltgruppeTB.Text.Trim().Equals("insert here") && !SchaltgruppeTB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[7], SchaltgruppeTB.Text);
            }
            if (!BetriebsartTB.Text.Trim().Equals("insert here") && !BetriebsartTB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[8], BetriebsartTB.Text);
            }
            if (!ISOTB.Text.Trim().Equals("insert here") && !ISOTB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[9], ISOTB.Text);
            }
            if (!IsolierfluessigkeitOelTB.Text.Trim().Equals("insert here") && !IsolierfluessigkeitOelTB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[10], IsolierfluessigkeitOelTB.Text);
            }
            if (!OeltemperaturMaxTB.Text.Trim().Equals("insert here") && !OeltemperaturMaxTB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[11], OeltemperaturMaxTB.Text);
            }
            if (!GesamtgewichtTB.Text.Trim().Equals("insert here") && !GesamtgewichtTB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[12], GesamtgewichtTB.Text);
            }
            if (!OelgewichtTB.Text.Trim().Equals("insert here") && !OelgewichtTB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[13], OelgewichtTB.Text);
            }
            if (!KuehlungTB.Text.Trim().Equals("insert here") && !KuehlungTB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[14], KuehlungTB.Text);
            }
            if (!PCBAnteilTB.Text.Trim().Equals("insert here") && !PCBAnteilTB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[15], PCBAnteilTB.Text);
            }
            if (!GeraeuschpegelTB.Text.Trim().Equals("insert here") && !GeraeuschpegelTB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[16], GeraeuschpegelTB.Text);
            }
            if (!AushebbarerTeilTB.Text.Trim().Equals("insert here") && !AushebbarerTeilTB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[17], AushebbarerTeilTB.Text);
            }
            if (!NetzfrequenzTB.Text.Trim().Equals("insert here") && !NetzfrequenzTB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[18], NetzfrequenzTB.Text);
            }
            if (!Spannung1TB.Text.Trim().Equals("insert here") && !Spannung1TB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[19], Spannung1TB.Text);
            }
            if (!Spannung2TB.Text.Trim().Equals("insert here") && !Spannung2TB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[20], Spannung2TB.Text);
            }
            if (!Spannung3TB.Text.Trim().Equals("insert here") && !Spannung3TB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[21], Spannung3TB.Text);
            }
            if (!Spannung4TB.Text.Trim().Equals("insert here") && !Spannung4TB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[22], Spannung4TB.Text);
            }
            if (!Spannung5TB.Text.Trim().Equals("insert here") && !Spannung5TB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[23], Spannung5TB.Text);
            }
            if (!SpannungSekundaerTB.Text.Trim().Equals("insert here") && !SpannungSekundaerTB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[24], SpannungSekundaerTB.Text);
            }
            if (!UkTB.Text.Trim().Equals("insert here") && !UkTB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[25], UkTB.Text);
            }
            if (!StromPrimaerTB.Text.Trim().Equals("insert here") && !StromPrimaerTB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[26], StromPrimaerTB.Text);
            }
            if (!Strom2SekundaerTB.Text.Trim().Equals("insert here") && !Strom2SekundaerTB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[27], Strom2SekundaerTB.Text);
            }
            if (!LeerlaufverTB.Text.Trim().Equals("insert here") && !LeerlaufverTB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[28], LeerlaufverTB.Text);
            }
            if (!KurzschlussTB.Text.Trim().Equals("insert here") && !KurzschlussTB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[29], KurzschlussTB.Text);
            }
            if (!WiderstandTB.Text.Trim().Equals("insert here") && !WiderstandTB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[30], WiderstandTB.Text);
            }
            if (!MSAISOTB.Text.Trim().Equals("insert here") && !MSAISOTB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[31], MSAISOTB.Text);
            }
            if (!StrangTB.Text.Trim().Equals("insert here") && !StrangTB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[32], StrangTB.Text);
            }
            if (!ZustandTB.Text.Trim().Equals("insert here") && !ZustandTB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[33], ZustandTB.Text);
            }
            if (!SonstigesTB.Text.Trim().Equals("insert here") && !SonstigesTB.Text.Trim().Equals(""))
            {
                SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[35], SonstigesTB.Text);
            }

            SQL.UpdateTrafolisteTextField(seriennummer, fieldNames[1], "Lager");
            SQL.UpdateImLager(seriennummer, true);


            SQL.InsertHistorieSeriennummer(seriennummer);
            string eid = SQL.getEID(seriennummer);
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            SQL.UpdateHistorieTextField(eid, "standort", "Lager");
            SQL.UpdateHistorieDateField(eid, "Aufgestellt_am", currentDate);


            this.Close();
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
