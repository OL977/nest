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

namespace WPFПроба
{
    /// <summary>
    /// Логика взаимодействия для TabContr.xaml
    /// </summary>
    public partial class TabContr : Window
    {
        Подключение Под = new Подключение();
        public TabContr()
        {
            InitializeComponent();

        }

        private void dgr1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void Грид()
        {
            string strsql = "SELECT * FROM Categories cat JOIN Goods g ON g.Category = cat.CategoryID";
            DataTable ds = Подключение.Selects(strsql);

            dgr1.ItemsSource = ds.AsDataView();

        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Грид();
        }
        private void btn2_Click(object sender, RoutedEventArgs e)
        {
            string strsql = "DELETE FROM Categories WHERE CategoryID=1";
            Под.Updates(strsql);

            string strsql1 = "SELECT * FROM Categories cat JOIN Goods g ON g.Category = cat.CategoryID";
            DataTable ds = Подключение.Selects(strsql1);

            dgr1.ItemsSource = ds.AsDataView();
        }
    }

}
