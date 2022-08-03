using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;

namespace DataGridTest
{
    /// <summary>
    /// Interaktionslogik für PathInputWindow.xaml
    /// </summary>
    public partial class PathInputWindow : Window
    {
        public PathInputWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!newPath.Text.Trim().Equals("") && !newPath.Text.Trim().Equals("C:\\source"))
            {
                MainWindow.mainPath = newPath.Text.Trim();
                SQL.CreateTable();
                this.Close();
            }
            else
            {
                InstructionLabel.Content = "Please insert a valid path";
                InstructionLabel.BorderBrush = Brushes.Black;
                InstructionLabel.BorderThickness = new Thickness(2);
            }

        }
        
    }
}
