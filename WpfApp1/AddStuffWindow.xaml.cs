using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.Refresh;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for AddStuffWindow.xaml
    /// </summary>
    public partial class AddStuffWindow : Window
    {
        MainWindow main;
        public AddStuffWindow()
        {
            InitializeComponent();
        }
        public AddStuffWindow(MainWindow Main)
        {
            InitializeComponent();
            main=Main;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Database._itemss.Add(new Services(addName.Text,addIP.Text,addPort.Text));
            MainWindow.Names.Add(addName.Text);
            MainWindow.Addresses.Add(addIP.Text);
            MainWindow.Ports.Add(addPort.Text);
            SQLiteDatabase.InsertData();
            

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            main.UpdateServices();
            main.dataGrid1.ItemsSource = main.list;
            Close();
            UiRefresh.Refresh(main);
        }
    }
}
