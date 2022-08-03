using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace DataGridTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //C:\Users\Simon\Desktop\Stww_TrafoManager
        //C:/Users/Simon/Desktop/Stww_TrafoManager
        public static string mainPath = "";
        private bool hasRefreshBeenPressed = false;

        public MainWindow()
        {
            InitializeComponent();
            dataGrid.Items.Clear();
            dataGrid.Items.Refresh();

            PathInputWindow window = new PathInputWindow();
            window.Show();
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
            string seriennummer = dataRowView[0].ToString();
            ViewWindow window = new ViewWindow(seriennummer, mainPath);
            window.Show();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {

            DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
            string seriennummer = dataRowView[0].ToString();
            UpdateWindow window = new UpdateWindow(seriennummer);
            window.Show();
        }

        private void btnNeu_Click(object sender, RoutedEventArgs e)
        {
            if (hasRefreshBeenPressed)
            {
                AddWindow window = new AddWindow();
                window.Show();
            }


        }

        public void refreshData(object sender, RoutedEventArgs e)
        {

            if (!mainPath.Trim().Equals(""))
            {
                hasRefreshBeenPressed = true;
                DataTable dt = new DataTable();
                try
                {
                    using (SQLiteConnection connection = new SQLiteConnection("Data Source= " + mainPath + "/" + SQL.dbName))
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter("select seriennummer, aktuellerstandort, imlager from Trafodaten", connection))
                    using (SQLiteCommandBuilder command = new SQLiteCommandBuilder(adapter))
                    {
                        adapter.Fill(dt);
                    }
                    dataGrid.ItemsSource = null;
                    dataGrid.Items.Clear();
                    dataGrid.ItemsSource = dt.DefaultView;
                    dataGrid.Items.Refresh();
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show(ex.Message + "\nrestart the programm and try to fix the path", "Invalid Path Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                PathInputWindow window = new PathInputWindow();
                window.Show();
            }
        }

        private void btnAddHistory_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)((Button)e.Source).DataContext;
            string seriennummer = dataRowView[0].ToString();
            AddHistoryWindow window = new AddHistoryWindow(seriennummer);
            window.Show();
        }

        private void btn_EXIT_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void WriteCSV(object sender, RoutedEventArgs e)
        {
            if (hasRefreshBeenPressed)
            {
                WriteCsvWindow window = new();
                window.Show();
            }
            

        }
    }
}
