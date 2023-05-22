using System;
using System.Collections.Generic;
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
using Utilitas.Resourses.Classes;

namespace Utilitas.Resourses.Pages
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();

            DtgListBooks.ItemsSource = ClassHelp.libraries;


        }
        private void Re_Click(object sender, RoutedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(DtgListBooks.ItemsSource).Refresh();
            DtgListBooks.ItemsSource = ClassHelp.libraries.OrderByDescending(x => x.Cost_Price).ToList();
            DtgListProfit.ItemsSource = ClassHelp.libraries.Where(x => x.Profit_crisis > 0);
            DtgListCrisis.ItemsSource = ClassHelp.libraries.Where(x => x.Profit_crisis < 0);
        }

    }
}
