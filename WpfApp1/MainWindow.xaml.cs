using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp1.Refresh;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Services> list;
        public static List<string> Names;
        public static List<string> Addresses;
        public static List<string> Ports;
        public List<string> Name;
        public List<string> Address;
        public List<string> Port;
        public MainWindow()
        {
            InitializeComponent();
            list = new();
            Name = new List<string>();
            Address = new List<string>();
            Port = new List<string>();
            Names = new List<string>();
            Addresses = new List<string>();
            Ports = new List<string>();
            SQLiteDatabase.MakeDatabase();
            MakeGrid();
            dataGrid1.ItemsSource = list;
        }

        private void MakeGrid()
        {
            for (int i = 0; i < Names.Count; i++)
            {
                list.Add(new Services(Names[i], Addresses[i], Ports[i]));
            }

        }
        public void UpdateServices()
        {
            list.Add(new Services(Names[Names.Count - 1], Addresses[Addresses.Count - 1], Ports[Ports.Count - 1]));
        }

        private void AddStuff(object sender, RoutedEventArgs e)
        {
            AddStuffWindow addWindow = new AddStuffWindow(this);
            addWindow.Show();
          
        }
    }
}

