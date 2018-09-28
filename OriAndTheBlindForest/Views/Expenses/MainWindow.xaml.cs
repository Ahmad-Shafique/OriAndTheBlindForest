using OriAndTheBlindForest.Views.UtilityFunctions;
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


namespace OriAndTheBlindForest.Views.Expenses
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
        

        private void returnToMainMenu_Click(object sender, RoutedEventArgs e)
        {
            SwitchWindow.Switch(this, new Dashboard.Dashboard_Window());
        }

        private void addExpenseButton_Click(object sender, RoutedEventArgs e)
        {
            SwitchWindow.Switch(this, new AddExpense());

        }

        private void addExpenseTypeButton_Click(object sender, RoutedEventArgs e)
        {
            SwitchWindow.Switch(this, new AddExpenseType());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SwitchWindow.Switch(this, new EditExpenses());
        }
    }
}
