using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace TestMaterial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckYear() && !CheckName())
            {
                return;
            }
            if (PensiaCapital.Text != "")
            {
                double pensia = Convert.ToDouble(PensiaCapital.Text) / 252 + 5334.19;
                PensiaMounth.Text = Math.Round(pensia, 3).ToString();
            }
            else
            {
                MessageBox.Show("Вы не ввели размер пенсионного капитала !");
            }
        }

      

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!CheckYear() || !CheckName())
            {
                return;
            }
            if (Base.Text=="")
            {
                    MessageBox.Show("Вы не ввели базу");
                    return;
            }
            
            double insuranceBase = Convert.ToDouble(Base.Text);
            double percentPFR =0.22;
            double socialInsurance = 0.029;
            double medicalInsurance = 0.051;
            if (insuranceBase <= 1150000)
            {
                percentPFR = 0.10;
            }
            double anwear=insuranceBase*percentPFR+insuranceBase*socialInsurance+insuranceBase*medicalInsurance;
            SummInsurance.Text = Math.Round(anwear,3).ToString();
        }

        private bool CheckName()
        {
            
            if(Name.Text!="")
            {
                return true;
            }
            else
            {
                MessageBox.Show("Вы не ввели имя");
                return false;
            }

        }
        private bool CheckYear()
        {
            int year = Convert.ToInt32(Year.Text);
            if(year <= DateTime.Now.Year & DateTime.Now.Year-year<=80)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Некоректно введен год");
                return false;
            }
            
        }

        private void Name_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^A-zА-я]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
