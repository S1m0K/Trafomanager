using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataGridTest
{
    /// <summary>
    /// Interaktionslogik für WriteCsvWindow.xaml
    /// </summary>
    public partial class WriteCsvWindow : Window
    {
        public WriteCsvWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!newPath.Text.Trim().Equals("") && !newPath.Text.Trim().Equals("C:\\source"))
            {

                try
                {
                    string csv = SQL.selectAllFromTrafoDaten();
                    File.AppendAllText(newPath.Text + "\\TrafoDaten.csv", csv.ToString());
                    csv = SQL.getAllFromHistorie();
                    File.AppendAllText(newPath.Text + "\\Historie.csv", csv.ToString());
                }catch (System.IO.DirectoryNotFoundException ex)
                {
                    MessageBox.Show("Your inserted path might have been invalid please try again. " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
                    WriteCsvWindow window = new();
                    window.Show();
                }
                this.Close();
            }
            else
            {
                InstructionLabel.Content = "Please insert a valid path";
                InstructionLabel.BorderBrush = Brushes.Black;
                InstructionLabel.BorderThickness = new Thickness(2);
            }

        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {

            // see https://docs.microsoft.com/dotnet/api/system.diagnostics.processstartinfo.useshellexecute#property-value
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }
    }
}
