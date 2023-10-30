using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
using System.Windows.Media;.
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataParserWPF_Test
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

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {          
            if (DateFrom.SelectedDate == null || DateTo.SelectedDate == null || string.IsNullOrEmpty(Article.Text))
            {
                MessageBox.Show("How about date or maybe you forget news registration number ?");
                return;
            }
            var dateFrom = (DateTime)DateFrom.SelectedDate;
            var dateTo = (DateTime)DateFrom.SelectedDate;
            var artickle = Article.Text;

            IWebDriver driver = new ChromeDriver();
            driver.Url = @"https://github.com/AndreyPinchukDeveloper";
        }
    }
}
