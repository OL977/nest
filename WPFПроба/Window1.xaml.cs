using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using System.IO;
using System.IO.Compression;

namespace WPFПроба
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Подключение Под = new Подключение();
        public Window1()
        {
            InitializeComponent();
            WindowState = WindowState.Maximized;

            //Подключение df = new Подключение();
            //df.Start();

        }
        //private void Windows1_load(object sender, RoutedEventArgs e)
        //{


        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
        }


        private void button1_Click(object sender, RoutedEventArgs e)
        {

            string strsql = "SELECT ProductName FROM Goods";
            
            DataTable ds = Подключение.Selects(strsql);

            foreach (DataRow row in ds.Rows)
            {
                combobox1.Items.Add(row[0]);
            }
            //MessageBox.Show("Как то так");

            //Me.ComboBox4.AutoCompleteCustomSource.Clear()
            //Me.ComboBox4.Items.Clear()
            //For Each r As DataRow In ds.Rows
            //    Me.ComboBox4.AutoCompleteCustomSource.Add(r.Item(0).ToString())
            //    Me.ComboBox4.Items.Add(r(0).ToString)
            //Next




        }

        private void combobox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void заполняемКомбобокс()
        {

        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            string strsql = "SELECT ProductName FROM Goods";

            DataTable ds = Подключение.Selects(strsql);

            foreach (DataRow row in ds.Rows)
            {
                lst1.Items.Add(row[0]);
            }
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {

            string PrName = "Карамель";
            Double PrName1 = 25;
            int PrName2 = 965;

            //string strsql = "SELECT * FROM Goods";
           
            string strsql = "INSERT INTO Goods(Category,ProductName,Price,Количество) VALUES (2,'" + PrName + "'," + PrName1  + "," + PrName2 + ")";
            Под.Updates(strsql);

            string strsql1 = "SELECT * FROM Goods";
            DataTable ds = Подключение.Selects(strsql1);

            grid1.ItemsSource = ds.AsDataView();
        }
    }
}
