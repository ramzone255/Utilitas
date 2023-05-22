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
using System.Windows.Shapes;
using System.Xml.Linq;
using Utilitas.Resourses.Classes;
using static System.Net.Mime.MediaTypeNames;

namespace Utilitas
{
    /// <summary>
    /// Логика взаимодействия для SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        int mode;
        public SecondWindow()
        {
            InitializeComponent();
            mode = 0;
        }
        public SecondWindow(ClassLibrary Add)
        {
            InitializeComponent();
            Txb_Name.Text = Add.Name;
            Txb_Number.Text = Add.Number.ToString();
            Txb_Price.Text = Add.Price.ToString();
            Txb_CPrice.Text = Add.Cost_Price.ToString();
            mode = 1;
            AddTextClick.Content = "Добавить";
        }
        private void AddText_Click(object sender, RoutedEventArgs e)

        {
            try
            {
                if (int.Parse(Txb_Price.Text) < 0 || int.Parse(Txb_CPrice.Text) < 0 || int.Parse(Txb_Number.Text) < 0)
                {
                    MessageBox.Show("Колонки завязанные на числах не могут быть отрицательными", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    Txb_Price.Clear();
                    Txb_Price.Focus();
                    Txb_CPrice.Clear();
                    Txb_CPrice.Focus();
                    Txb_Number.Clear();
                    Txb_Number.Focus();

                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Проверьте входные данные: {ex}", "Ошибка!",
                               MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

                if (mode == 0)
                {
                    try
                    {
                        ClassLibrary New_Table_For_Add = new ClassLibrary()
                        {
                            Number = int.Parse(Txb_Number.Text),
                            Price = double.Parse(Txb_Price.Text),
                            Cost_Price = double.Parse(Txb_CPrice.Text),
                            Profit_crisis = double.Parse(Txb_Price.Text) - double.Parse(Txb_CPrice.Text),
                            Name = Txb_Name.Text

                        };

                        ClassHelp.libraries.Add(New_Table_For_Add);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Проверьте входные данные: {ex}", "Ошибка!",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                }
            else
            {
                try
                {
                    for (int i = 0; i < ClassHelp.libraries.Count; i++)
                    {
                        if (ClassHelp.libraries[i].Name == Txb_Name.Text)
                        {
                            ClassHelp.libraries[i].Number = int.Parse(Txb_Number.Text);
                            ClassHelp.libraries[i].Cost_Price = double.Parse(Txb_CPrice.Text);
                            ClassHelp.libraries[i].Price = double.Parse(Txb_Price.Text);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Проверьте входные данные: {ex}", "Ошибка!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }


            }
        }
        private void SecondWindow_moving(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void RollUp_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public void Number_TextBox(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= Number_TextBox;
        }
        public void Name_TextBox(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= Name_TextBox;
        }
        public void Cost_Price_TextBox(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= Cost_Price_TextBox;
        }
        public void Price_TextBox(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = string.Empty;
            tb.GotFocus -= Price_TextBox;
        }
    }
}
