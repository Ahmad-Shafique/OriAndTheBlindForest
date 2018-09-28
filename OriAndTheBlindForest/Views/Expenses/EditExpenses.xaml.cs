using OriAndTheBlindForest.Views.Expenses.DataStructures;
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

namespace OriAndTheBlindForest.Views.Expenses
{
    /// <summary>
    /// Interaction logic for EditExpenses.xaml
    /// </summary>
    public partial class EditExpenses : Window
    {
        public EditExpenses()
        {
            InitializeComponent();
            this.PopulateTable();
        }

        private void PopulateTable()
        {
            var list = new ObservableCollection<Expense>();
            list.Add(new Expense() { Id = 1, Type = "Visa Expense", Date = DateTime.Now, Description = "Some irrelevant? description", Amount = 50 });
            list.Add(new Expense() { Id = 2, Type = "Staff Expense", Date = DateTime.Now, Description = "Some irrelevant? description", Amount = 10 });
            list.Add(new Expense() { Id = 3, Type = "Operating Expense", Date = DateTime.Now, Description = "Some irrelevant? description", Amount = 500 });
            this.expenseList.ItemsSource = list;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            SwitchWindow.Switch(this, new MainWindow());
        }

        private void naruSwitch_Click(object sender, RoutedEventArgs e)
        {
            SwitchWindow.Switch(this, new Dashboard.Dashboard_Window(true));
        }
    }
}
