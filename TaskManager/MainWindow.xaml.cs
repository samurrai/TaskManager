using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace TaskManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            taskManagerDataGrid.ItemsSource = Process.GetProcesses();
        }

        private void KillTask(object sender, RoutedEventArgs e)
        {
            foreach (var process in Process.GetProcesses())
            {
                if (process.Id == (taskManagerDataGrid.SelectedItem as Process).Id)
                {
                    try
                    {
                        process.Kill();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Не удается завершить процесс");
                    }
                }
            }
        }
    }
}