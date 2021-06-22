using JtoDO.Models;
using JtoDO.Services;
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

namespace JtoDO
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BindingList<TodoModel> todoData;
        private readonly string  path = $"{Environment.CurrentDirectory}\\TodoList.json";

        private InOut _inOut;

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void dgToDoList_Loaded(object sender, RoutedEventArgs e)
        {
            _inOut = new InOut(path);
            
            try
            { 
                todoData = _inOut.LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неудалось загрузить данные списка \n Error {ex}");
                //Close();
            }
            

            dgToDoList.ItemsSource = todoData;

            todoData.ListChanged += TodoData_ListChanged;
        }

        private void TodoData_ListChanged(object sender, ListChangedEventArgs e)
        {

            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
            {
                try
                {
                    _inOut.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Неудалось сохранить данные списка \n Error {ex}");
                    //Close();
                }
            }


            //switch (e.ListChangedType)
            //{
            //    case ListChangedType.Reset:
            //        break;
            //    case ListChangedType.ItemAdded:
            //        break;
            //    case ListChangedType.ItemDeleted:
            //        break;
            //    case ListChangedType.ItemMoved:
            //        break;
            //    case ListChangedType.ItemChanged:
            //        break;
            //    case ListChangedType.PropertyDescriptorAdded:
            //        break;
            //    case ListChangedType.PropertyDescriptorDeleted:
            //        break;
            //    case ListChangedType.PropertyDescriptorChanged:
            //        break;
            //    default:
            //        break;
            //}
        }
    }
}
