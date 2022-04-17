using MyTasks.Models;
using MyTasks.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace MyTasks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\taskDataList.json";
        private BindingList<TaskModel> _taskDataList;
        private FileInputOutputService _fileInputOutputService;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileInputOutputService = new FileInputOutputService(PATH);
            
            try
            {
                _taskDataList = _fileInputOutputService.LoadData();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                Close();
            }

            ListOfTasks.ItemsSource = _taskDataList;
            _taskDataList.ListChanged += _taskDataList_ListChanged;
        }

        private void _taskDataList_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || 
                e.ListChangedType == ListChangedType.ItemDeleted || 
                e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    _fileInputOutputService.SaveData(sender);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
        }
    }
}
