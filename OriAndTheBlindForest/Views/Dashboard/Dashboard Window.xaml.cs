using OriAndTheBlindForest.Views.UtilityFunctions;
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
using System.Windows.Shapes;

namespace OriAndTheBlindForest.Views.Dashboard
{
    public class TaskData
    {
        public int id { get; set; }
        public bool done { get; set; }
        public string taskGiver { get; set; }
        public string task { get; set; }
    }
    /// <summary>
    /// Interaction logic for Dashboard_Window.xaml
    /// </summary>
    public partial class Dashboard_Window : Window
    {
        public Dashboard_Window()
        {
            InitializeComponent();


            this.populateTasksTable();
        }

        public Dashboard_Window(bool naruView)
        {
            InitializeComponent();

            if (naruView) this.NaruView();
            this.populateTasksTable();
            
        }

        private void populateTasksTable()
        {
            var list = new ObservableCollection<TaskData>();
            list.Add(new TaskData() { id = 1, done = true, taskGiver = "Mr. Shakil", task = "payroll for gym" });
            list.Add(new TaskData() { id = 2, done = false, taskGiver = "Mr. Hasan", task = "give petty cash" });
            list.Add(new TaskData() { id = 3, done = false, taskGiver = "Mr. Ahmed", task = "do nothing" });
            this.taskList.ItemsSource = list;
        }

        private void NaruView()
        {
            this.expenses.Visibility = Visibility.Collapsed;
            this.payroll.Visibility = Visibility.Collapsed;
            this.attendance.Visibility = Visibility.Collapsed;
            this.voucher.Visibility = Visibility.Collapsed;
            this.employees.Visibility = Visibility.Collapsed;
            this.partners.Visibility = Visibility.Collapsed;
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            SwitchWindow.Switch(this, new Portal.Portal());
            
        }

        private void hideFunctionality_Click(object sender, RoutedEventArgs e)
        {
            this.NaruView();
        }

        private void AddTasksButton_Click(object sender, RoutedEventArgs e)
        {
            SwitchWindow.Switch(this, new Tasks.AddTask());
        }

        private void goToExpensesWindow(object sender, RoutedEventArgs e)
        {
            SwitchWindow.Switch(this, new Expenses.MainWindow());
        }
    }
}
